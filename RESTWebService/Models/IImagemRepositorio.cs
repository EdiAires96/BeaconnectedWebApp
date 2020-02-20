using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTWebService.Models
{
    public interface IImagemRepositorio
    {
        Imagem Get(string nome);
        Imagem Add(Imagem Add);
        void Remove(string nome);
    }
}