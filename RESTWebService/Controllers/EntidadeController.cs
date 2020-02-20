using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RESTWebService.Models;

namespace RESTWebService.Controllers
{
    public class EntidadeController : ApiController
    {

        static readonly IEntidadeRepositorio entidadeRepositorio = new EntidadeRepositorio();

        public List<Entidade> GetAllEntidades()
        {
            return entidadeRepositorio.GetAll();
        }

        public Entidade GetEntidade(int id)
        {
            Entidade item = entidadeRepositorio.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        public HttpResponseMessage PostEntidade(Entidade item)
        {
            item = entidadeRepositorio.Add(item);
            var response = Request.CreateResponse<Entidade>(HttpStatusCode.Created, item);
            string uri = Url.Link("DefaultApi", new { id = item.entidade_id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void PutEntidade(Entidade item)
        {
            if (!entidadeRepositorio.Update(item))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void DeleteEntidade(Entidade item)
        {
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            entidadeRepositorio.Remove(item);
        }

    }
}
