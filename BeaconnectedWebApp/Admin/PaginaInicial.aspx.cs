using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Threading.Tasks;
using BeaconnectedWebApp.Models;
using Microsoft.AspNet.Identity;

namespace BeaconnectedWebApp.Admin
{
    public partial class PaginaInicial : System.Web.UI.Page
    {

        public List<Conteudo> GetConteudos()
        {
            HttpClient client = new HttpClient();
            try
            {
                string url = "http://beaconnectedwebservice.azurewebsites.net/api/conteudo";
                var response = client.GetStringAsync(url).Result;
                var conteudo = JsonConvert.DeserializeObject<List<Conteudo>>(response);

                string email = User.Identity.GetUserName();
                return conteudo.Where(c => c.Beacon.Entidade.email == email).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Beacon> GetBeacons()
        {
            HttpClient client = new HttpClient();
            try
            {
                string url = "http://beaconnectedwebservice.azurewebsites.net/api/beacon";
                var response = client.GetStringAsync(url).Result;
                var beacons = JsonConvert.DeserializeObject<List<Beacon>>(response);

                string email = User.Identity.GetUserName();
                List<Beacon> associate_beacons = new List<Beacon>();
                  
                foreach(Beacon b in beacons)
                {
                   if(b.Entidade.email.Equals(email))
                    {
                        associate_beacons.Add(b);
                    }     
                }
                return associate_beacons;



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void BindGrid()
        {
            GridViewConteudos.DataSource = GetConteudos();
            GridViewConteudos.DataBind();
            GridBeacons.DataSource = GetBeacons();
            GridBeacons.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
           if(!this.IsPostBack)
            {
                this.BindGrid();
            }

           
        }
        public void AddConteudo_Click(Object sender, EventArgs e)
        {
            Response.Redirect("AddConteudo");
        }


    }
}