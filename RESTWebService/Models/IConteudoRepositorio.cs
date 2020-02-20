using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTWebService.Models
{
    public interface IConteudoRepositorio
    {
        List<Conteudo> GetAll();
        Conteudo Get(int id);
        Conteudo Add(Conteudo item);
        void Remove(Conteudo item);
        bool Update(Conteudo item);

    }
}