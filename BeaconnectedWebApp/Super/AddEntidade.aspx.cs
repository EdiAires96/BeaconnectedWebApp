using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BeaconnectedWebApp.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Specialized;

namespace BeaconnectedWebApp.Super
{
    public partial class AddEntidade : System.Web.UI.Page
    {
        public void NewEntidade(Entidade e)
        {
            HttpClient client = new HttpClient();
            try
            {
                string url = "http://beaconnectedwebservice.azurewebsites.net/api/entidade/{0}";
                var uri = new Uri(string.Format(url, e.entidade_id));
                var data = JsonConvert.SerializeObject(e);
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
        public List<Tema> GetTemas()
        {
            HttpClient client = new HttpClient();
            try
            {
                string url = "http://beaconnectedwebservice.azurewebsites.net/api/tema";
                var response = client.GetStringAsync(url).Result;
                var temas = JsonConvert.DeserializeObject<List<Tema>>(response);
                return temas;
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

        public void UpdateEntidade(Entidade e)
        {
            HttpClient client = new HttpClient();
            try
            {
                string url = "http://beaconnectedwebservice.azurewebsites.net/api/entidade/{0}";
                var uri = new Uri(string.Format(url, e.entidade_id));
                var data = JsonConvert.SerializeObject(e);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;

                response = client.PutAsync(uri, content).Result;
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
        public List<Conteudo> GetConteudos(string email)
        {
            HttpClient client = new HttpClient();
            try
            {
                string url = "http://beaconnectedwebservice.azurewebsites.net/api/conteudo";
                var response = client.GetStringAsync(url).Result;
                var conteudo = JsonConvert.DeserializeObject<List<Conteudo>>(response);
                
                return conteudo.Where(c => c.Beacon.Entidade.email == email).ToList();

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
                    throw new Exception("Erro ao incluir a entidade");
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
                if (Request.QueryString["EntidadeID"] != null)
                {
                    int id = Int32.Parse(Request.QueryString["EntidadeID"]);
                    Entidade entidade = GetEntidades().Where(ent => ent.entidade_id == id).First();
                    TextBoxNome.Text = entidade.nome;
                    TextBoxEmail.Text = entidade.email;
                    TextBoxMorada.Text = entidade.morada;
                    listaTemas.DataSource = GetTemas();
                    listaTemas.DataTextField = "nome";
                    listaTemas.DataValueField = "tema_id";
                    listaTemas.DataBind();
                    listaTemas.SelectedValue = entidade.tema_id.ToString();
                    listaTemas.DataBind();
                    if (entidade.estado == true)
                        Estado.SelectedValue = "yes";
                    else
                        Estado.SelectedValue = "no";

                    LabelTitle.Visible = true;
                    LabelNome.Visible = true;
                    LabelConteudo.Visible = true;         
                    LabelNome.Text = entidade.nome;
                    GridViewConteudos.Visible = true;
                    GridViewConteudos.DataSource = GetConteudos(entidade.email);
                    GridViewConteudos.DataBind();

                    listaTitulos.DataTextField = "titulo";
                    listaTitulos.DataValueField = "conteudo_id";
                    listaTitulos.DataSource = GetConteudos(entidade.email);
                    listaTitulos.DataBind();


                }
                else
                {
                    listaTemas.DataTextField = "nome";
                    listaTemas.DataValueField = "tema_id";
                    listaTemas.DataSource = GetTemas();
                    listaTemas.DataBind();

                    listaTitulos.Visible = false;
                    EstadoConteudo.Visible = false;
                   
                }
            }

        }
        public void Save_Click(object sender, EventArgs e)
        {
            //Editar entidade
            if (Request.QueryString["EntidadeID"] != null)
            {
                int id = Int32.Parse(Request.QueryString["EntidadeID"]);
                Entidade entidade = GetEntidades().Where(ent => ent.entidade_id == id).First();
                entidade.nome = TextBoxNome.Text;
                entidade.email = TextBoxEmail.Text;
                entidade.morada = TextBoxMorada.Text;
                entidade.tema_id= Convert.ToInt32(listaTemas.SelectedItem.Value);
                if (Estado.SelectedValue.Equals("yes"))
                    entidade.estado = true;
                else
                    entidade.estado = false;

                UpdateEntidade(entidade);

                //Editar o estado dos conteudos     
                if (EstadoConteudo.SelectedValue.Equals("yes") || EstadoConteudo.SelectedValue.Equals("no"))
                {

                    int cont_id = Convert.ToInt32(listaTemas.SelectedItem.Value);
                    Conteudo cont = GetConteudos(entidade.email).Where(p => p.conteudo_id == cont_id).First();
                    if (EstadoConteudo.SelectedValue.Equals("yes"))
                        cont.estado = true;
                    if (EstadoConteudo.SelectedValue.Equals("no"))
                        cont.estado = false;

                    UpdateConteudo(cont);
                }
                Response.Redirect("Entidades");
            }

            //Registar nova Entidade
            else
            {
                Entidade ent = new Entidade();
                ent.nome = TextBoxNome.Text;
                ent.email = TextBoxEmail.Text;
                ent.morada = TextBoxMorada.Text;
                ent.tema_id = Convert.ToInt32(listaTemas.SelectedItem.Value);
                if (Estado.SelectedValue.Equals("yes"))
                    ent.estado = true;
                else
                    ent.estado = false;

                NewEntidade(ent);

                //Atribuiçao do ROLE de administrador a esta entidade
                Models.ApplicationDbContext context = new ApplicationDbContext();
                IdentityResult IdRoleResult;
                IdentityResult IdUserResult;

                var roleStore = new RoleStore<IdentityRole>(context);

                var roleMgr = new RoleManager<IdentityRole>(roleStore);

                if (!roleMgr.RoleExists("Admin"))
                {
                    IdRoleResult = roleMgr.Create(new IdentityRole { Name = "Admin" });
                }

                var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var appUser = new ApplicationUser
                {
                    UserName = TextBoxEmail.Text,
                    Email = TextBoxEmail.Text
                };
                IdUserResult = userMgr.Create(appUser, "Pa$$word1");

                if (!userMgr.IsInRole(userMgr.FindByEmail(TextBoxEmail.Text).Id, "Admin"))
                {
                    IdUserResult = userMgr.AddToRole(userMgr.FindByEmail(TextBoxEmail.Text).Id, "Admin");
                }

                Response.Redirect("Entidades");
            }
        }
        public void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Entidades");
        }
        public static IOrderedDictionary GetValues(GridViewRow row)
        {
            IOrderedDictionary values = new OrderedDictionary();
            foreach (DataControlFieldCell cell in row.Cells)
            {
                if (cell.Visible)
                {
                    // Extract values from the cell.
                    cell.ContainingField.ExtractValuesFromCell(values, cell, row.RowState, true);
                }
            }
            return values;
        }
        public struct ListUpdates
        {
            public string titulo;
            public bool RemoveItem;
        }
    }
}