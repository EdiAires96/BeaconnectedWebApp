using BeaconnectedWebApp.Models;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace BeaconnectedWebApp.Admin
{
    public partial class AddConteudo : System.Web.UI.Page
    {
        public void NewConteudo(Conteudo c)
        {
            HttpClient client = new HttpClient();
            try
            {
                string url = "http://beaconnectedwebservice.azurewebsites.net/api/conteudo/{0}";
                var uri = new Uri(string.Format(url, c.conteudo_id));
                var data = JsonConvert.SerializeObject(c);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;

                response = client.PostAsync(uri, content).Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Erro ao incluir a entidade");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Conteudo GetConteudo(int id)
        {
            HttpClient client = new HttpClient();
            try
            {
                string url = "http://beaconnectedwebservice.azurewebsites.net/api/conteudo/"+id;
                var response = client.GetStringAsync(url).Result;
                var conteudo = JsonConvert.DeserializeObject<Conteudo>(response);
                return conteudo;
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
                return beacons.Where(b=>b.Entidade.email== User.Identity.GetUserName()).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void NewImage(Imagem i)
        {
            HttpClient client = new HttpClient();
            try
            {
                string url = "http://beaconnectedwebservice.azurewebsites.net/api/imagem/{0}";
                var uri = new Uri(string.Format(url,0));
                var data = JsonConvert.SerializeObject(i);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;

                response = client.PostAsync(uri, content).Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Erro ao incluir a entidade");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Imagem GetImagem(string nome)
        {
            HttpClient client = new HttpClient();
            try
            {
                string url = "http://beaconnectedwebservice.azurewebsites.net/api/imagem/?nome="+nome;
                var response = client.GetStringAsync(url).Result;
                var imagem = JsonConvert.DeserializeObject<Imagem>(response);
                return imagem;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DeleteImagem(string nome)
        {
            HttpClient client = new HttpClient();
            try
            {
                string url = "http://beaconnectedwebservice.azurewebsites.net/api/imagem/?nome=" + nome;
                var response = client.DeleteAsync(url).Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateConteudo(Conteudo c)
        {
            HttpClient client = new HttpClient();
            try
            {
                string url = "http://beaconnectedwebservice.azurewebsites.net/api/conteudo/{0}";
                var uri = new Uri(string.Format(url, c.conteudo_id));
                var data = JsonConvert.SerializeObject(c);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;

                response = client.PutAsync(uri, content).Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Erro ao incluir o Conteudo");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request.QueryString["ConteudoID"] != null)
                {
                    int id = Int32.Parse(Request.QueryString["ConteudoID"]);
                    Conteudo c = GetConteudo(id);
                    BeaconsList.SelectedValue = c.beacon_id.ToString();

                    if (c.estado == true)
                        Estado.SelectedValue = "yes";
                    else
                        Estado.SelectedValue = "no";

                    TextBoxTitulo.Text = c.titulo;
                    TextBoxNoticia.Text = c.noticia;
                    TextBoxCategoria.Text = c.categoria;

                    ImagemAtual.Visible = true;
                    Imagem.Visible = true;
                    Imagem.ImageUrl = "http://beaconnectedwebservice.azurewebsites.net/images/" + c.imagem;
                    Imagem.Height = 200;
                    Imagem.Width=200;
                   

                }
                BeaconsList.DataTextField = "beacon_id";
                BeaconsList.DataValueField = "beacon_id";
                BeaconsList.DataSource = GetBeacons();
                BeaconsList.DataBind();

            }
        }



        public void Save_Click(object sender, EventArgs e)
        {

            Conteudo c = new Conteudo();
            c.beacon_id = Convert.ToInt32(BeaconsList.SelectedItem.Value);
            c.categoria = TextBoxCategoria.Text;
            c.m_data = DateTime.Now;

            Imagem i = new Imagem();

            if (conteudoImage.HasFile)
            {
                i.nome = conteudoImage.FileName;
                i.image = conteudoImage.FileBytes;
                NewImage(i);
                c.imagem = conteudoImage.FileName;
                if (Request.QueryString["ConteudoID"] != null)
                {
                    int id = Int32.Parse(Request.QueryString["ConteudoID"]);
                    Conteudo aux = GetConteudo(id);
                    if (aux.imagem!=null)
                    {
                        DeleteImagem(aux.imagem);
                    } 
                }

            }
            else
            {
                if (Request.QueryString["ConteudoID"] != null)
                {
                    int id = Int32.Parse(Request.QueryString["ConteudoID"]);
                    Conteudo aux = GetConteudo(id);
                    c.imagem = aux.imagem;
                    //aqui
                }
            }
            c.titulo = TextBoxTitulo.Text;
            c.noticia = TextBoxNoticia.Text;
            if (Estado.SelectedValue.Equals("yes"))
                c.estado = true;
            else
                c.estado = false;

            if (Request.QueryString["ConteudoID"] != null)
            {
                int id = Int32.Parse(Request.QueryString["ConteudoID"]);
                Conteudo aux = GetConteudo(id);
                c.conteudo_id = aux.conteudo_id;
                UpdateConteudo(c);
            }
            else
            {
                NewConteudo(c);
            }

            Response.Redirect("PaginaInicial");
        }
        public void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaginaInicial");
        }
    }
}