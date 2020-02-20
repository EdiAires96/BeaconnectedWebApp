using BeaconnectedWebApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace BeaconnectedWebApp.Super
{

    public partial class Entidades : System.Web.UI.Page
    {
  
         
        public  List<Entidade> GetEntidades()
        {
            HttpClient client = new HttpClient();
            try
            {
                string url = "http://beaconnectedwebservice.azurewebsites.net/api/entidade";
                var response = client.GetStringAsync(url).Result;
                var entidades = JsonConvert.DeserializeObject<List<Entidade>>(response);
                return entidades;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





        private void BindGrid()
        {
            GridEntidade.DataSource = GetEntidades();
            GridEntidade.DataBind();
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!this.IsPostBack)
            {
                    
                this.BindGrid();
            }
            

        }
        public void AddEntidade_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddEntidade");
        }
    }
}