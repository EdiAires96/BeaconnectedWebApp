using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTWebService.Models
{
    public interface IEntidadeRepositorio
    {

        List<Entidade> GetAll();
        Entidade Get(int id);
        Entidade Add(Entidade item);
        void Remove(Entidade item);
        bool Update(Entidade item);

    }
}