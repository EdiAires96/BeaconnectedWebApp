using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTWebService.Models
{
    public interface IUtlizadorRepositorio
    {

        List<Utilizador> GetAll();
        Utilizador Get(int id);
        Utilizador Add(Utilizador item);
        void Remove(Utilizador item);
        bool Update(Utilizador item);

    }
}