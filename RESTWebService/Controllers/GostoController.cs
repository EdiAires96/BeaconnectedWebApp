using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RESTWebService.Models;

namespace RESTWebService.Controllers
{
    public class GostoController : ApiController
    {

        static readonly IGostoRepositorio gostoRepositorio = new GostoRepositorio();

        public List<Gosto> GetAllGostos()
        {
            return gostoRepositorio.GetAll();
        }

        public Gosto GetGosto(int id)
        {
            Gosto item = gostoRepositorio.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        public HttpResponseMessage PostGosto(Gosto item)
        {
            item = gostoRepositorio.Add(item);
            var response = Request.CreateResponse<Gosto>(HttpStatusCode.Created, item);
            string uri = Url.Link("DefaultApi", new { id = item.gosto_id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void PutGosto(Gosto item)
        {
            if (!gostoRepositorio.Update(item))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void DeleteGosto(Gosto item)
        {
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            gostoRepositorio.Remove(item);
        }

    }
}
