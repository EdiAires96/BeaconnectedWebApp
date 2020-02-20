using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTWebService.Models
{
    public interface IBeaconRepositorio
    {

        List<Beacon> GetAll();
        Beacon Get(int id);
        Beacon Add(Beacon item);
        void Remove(Beacon item);
        bool Update(Beacon item);
    }
}