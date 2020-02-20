using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTWebService.Models
{
    public interface ITemaRepositorio
    {
        List<Tema> GetAll();
        Tema Get(int id);
        Tema Add(Tema item);
        void Remove(Tema item);
        bool Update(Tema item);

    }
}