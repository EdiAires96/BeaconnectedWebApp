using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTWebService.Models
{
    public interface IGostoRepositorio
    {
        List<Gosto> GetAll();
        Gosto Get(int id);
        Gosto Add(Gosto item);
        void Remove(Gosto item);
        bool Update(Gosto item);

    }
}