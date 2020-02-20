using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RESTWebService.Models;

namespace RESTWebService.Controllers
{
    public class BeaconController : ApiController
    {
        static readonly IBeaconRepositorio beaconRepositorio = new BeaconRepositorio();

        public List<Beacon> GetAllBeacons()
        {
            return beaconRepositorio.GetAll();
        }

        public Beacon GetBeacon(int id)
        {
            Beacon item = beaconRepositorio.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        public HttpResponseMessage PostBeacon(Beacon item)
        {
            item = beaconRepositorio.Add(item);
            var response = Request.CreateResponse<Beacon>(HttpStatusCode.Created, item);
            string uri = Url.Link("DefaultApi", new { id = item.beacon_id });
            response.Headers.Location=new Uri(uri);
            return response;
        }

        public void PutBeacon(Beacon item)
        {
            if (!beaconRepositorio.Update(item))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void DeleteBeacon(Beacon item)
        {
            if (item==null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            beaconRepositorio.Remove(item);
        }
    }
}
