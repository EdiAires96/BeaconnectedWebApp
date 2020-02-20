using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RESTWebService.Models;

namespace RESTWebService.Controllers
{
    public class TemaController : ApiController
    {

        static readonly ITemaRepositorio temaRepositorio = new TemaRepositorio();

        public List<Tema> GetAllTemas()
        {
            return temaRepositorio.GetAll();
        }

        public Tema GetTema(int id)
        {
            Tema item = temaRepositorio.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        public HttpResponseMessage PostTema(Tema item)
        {
            item = temaRepositorio.Add(item);
            var response = Request.CreateResponse<Tema>(HttpStatusCode.Created, item);
            string uri = Url.Link("DefaultApi", new { id = item.tema_id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void PutTema(Tema item)
        {
            if (!temaRepositorio.Update(item))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void DeleteTema(Tema item)
        {
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            temaRepositorio.Remove(item);
        }

    }
}
