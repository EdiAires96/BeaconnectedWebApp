using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RESTWebService.Models;

namespace RESTWebService.Controllers
{
    public class UtilizadorController : ApiController
    {

        static readonly IUtlizadorRepositorio utilizadorRepositorio = new UtilizadorRepositorio();

        public List<Utilizador> GetAllUtilizadores()
        {
            return utilizadorRepositorio.GetAll();
        }

        public Utilizador GetUtilizador(int id)
        {
            Utilizador item = utilizadorRepositorio.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        public HttpResponseMessage PostUtilizador(Utilizador item)
        {
            item = utilizadorRepositorio.Add(item);
            var response = Request.CreateResponse<Utilizador>(HttpStatusCode.Created, item);
            string uri = Url.Link("DefaultApi", new { id = item.utilizador_id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void PutUtilizador(Utilizador item)
        {
            if (!utilizadorRepositorio.Update(item))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void DeleteUtilizador(Utilizador item)
        {
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            utilizadorRepositorio.Remove(item);
        }

    }
}
