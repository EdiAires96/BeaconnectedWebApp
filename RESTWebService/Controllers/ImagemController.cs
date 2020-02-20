using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RESTWebService.Models;

namespace RESTWebService.Controllers
{
    public class ImagemController : ApiController
    {
        static readonly IImagemRepositorio imagemRepositorio = new ImagemRepositorio();

        public Imagem GetImagem(string nome)
        {
            Imagem item = imagemRepositorio.Get(nome);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        public Imagem PostImagem(Imagem item)
        {
            item = imagemRepositorio.Add(item);
            return item;
        }

        public void DeleteImagem(string nome)
        {

            imagemRepositorio.Remove(nome);
        }
    }
}
