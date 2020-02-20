using BeaconnectedWebApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BeaconnectedWebApp.Super
{
    public partial class AddBeacon : System.Web.UI.Page
    {
        public void NewBeacon(Beacon b)
        {
            HttpClient client = new HttpClient();
            try
            {
                string url = "http://beaconnectedwebservice.azurewebsites.net/api/beacon/{0}";
                var uri = new Uri(string.Format(url, b.beacon_id));
                var data = JsonConvert.SerializeObject(b);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;

                response = client.PostAsync(uri, content).Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Erro ao incluir o beacon");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Entidade> GetEntidades()
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

        public void UpdateBeacon(Beacon b)
        {
            HttpClient client = new HttpClient();
            try
            {
                string url = "http://beaconnectedwebservice.azurewebsites.net/api/beacon/{0}";
                var uri = new Uri(string.Format(url, b.beacon_id));
                var data = JsonConvert.SerializeObject(b);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;

                response = client.PutAsync(uri,content).Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Erro ao incluir a entidade");
                }
                Response.Redirect("Beacons");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!this.IsPostBack)
            {
                if (Request.QueryString["BeaconID"] != null)
                {
                    int id = Int32.Parse(Request.QueryString["BeaconID"]);
                    Beacon beacon = GetBeacons().Where(b => b.beacon_id == id).First();
                    listaEntidades.DataSource = GetEntidades();
                    listaEntidades.DataTextField = "nome";
                    listaEntidades.DataValueField = "entidade_id";
                    listaEntidades.DataBind();
                    listaEntidades.SelectedValue =beacon.Entidade.entidade_id.ToString();
                    listaEntidades.DataBind();
                    if (beacon.estado==true)
                         Estado.SelectedValue="yes";
                    else
                        Estado.SelectedValue = "no";

                    
                }
                else
                {
                    listaEntidades.DataSource = GetEntidades();
                    listaEntidades.DataTextField = "nome";
                    listaEntidades.DataValueField = "entidade_id";
                    listaEntidades.DataBind();
                }
            }

        }
        public void Save_Click(object sender, EventArgs e)
        {
            //Editar Beacon
            if (Request.QueryString["BeaconID"] != null)
            {
                int id = Int32.Parse(Request.QueryString["BeaconID"]);
                Beacon beacon = GetBeacons().Where(b => b.beacon_id == id).First();
                beacon.entidade_id = Convert.ToInt32(listaEntidades.SelectedItem.Value);
                if (Estado.SelectedValue.Equals("yes"))
                    beacon.estado = true;
                else
                    beacon.estado = false;

                UpdateBeacon(beacon);

            }

            //Registar um novo
            else
            {
                Beacon bea = new Beacon();
                bea.entidade_id = Convert.ToInt32(listaEntidades.SelectedItem.Value);
                if (Estado.SelectedValue.Equals("yes"))
                    bea.estado = true;
                else
                    bea.estado = false;

                NewBeacon(bea);
                Response.Redirect("Beacons");
            }


        }
        public void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Beacons");
        }
    }
}