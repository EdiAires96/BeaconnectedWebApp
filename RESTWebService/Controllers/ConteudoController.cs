using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RESTWebService.Models;

namespace RESTWebService.Controllers
{
    public class ConteudoController : ApiController
    {
        static readonly IConteudoRepositorio conteudoRepositorio = new ConteudoRepositorio();

        public List<Conteudo> GetAllConteudos()
        {
            return conteudoRepositorio.GetAll();
        }

        public Conteudo GetConteudo(int id)
        {
            Conteudo item = conteudoRepositorio.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        public HttpResponseMessage PostConteudo(Conteudo item)
        {
            item = conteudoRepositorio.Add(item);
            var response = Request.CreateResponse<Conteudo>(HttpStatusCode.Created, item);
            string uri = Url.Link("DefaultApi", new { id = item.conteudo_id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void PutConteudo(Conteudo item)
        {
            if (!conteudoRepositorio.Update(item))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void DeleteConteudo(Conteudo item)
        {
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            conteudoRepositorio.Remove(item);
        }

    }
}
