using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BeaconnectedWebApp.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace BeaconnectedWebApp.Super
{
    public partial class Beacons : System.Web.UI.Page
    {
         public List<Beacon> GetBeacons()
        {
            HttpClient client = new HttpClient();
            try
            {
                string url = "http://beaconnectedwebservice.azurewebsites.net/api/beacon";
                var response = client.GetStringAsync(url).Result;
                var beacons = JsonConvert.DeserializeObject<List<Beacon>>(response);
                return beacons;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void BindGrid()
        {
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

        public void AddBeacon_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddBeacon") ;
        }

    }
}