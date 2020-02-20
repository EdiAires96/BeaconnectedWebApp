using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTWebService.Models
{
    public class BeaconRepositorio : IBeaconRepositorio
    {

        public BeaconRepositorio()
        {

        }

        public Beacon Add(Beacon item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            else
            {
                db _db = new db();
                _db.Beacon.Add(item);
                _db.SaveChanges();
            }

            return item;
        }

        public Beacon Get(int id)
        {
            db _db = new db();
            return _db.Beacon.Where(b => b.beacon_id == id).FirstOrDefault();
        }

        public List<Beacon> GetAll()
        {
            db _db = new db();
            return _db.Beacon.ToList<Beacon>(); 
        }

        public void Remove(Beacon item)
        {
            db _db = new db();
            var aux = _db.Beacon.Where(b => b.beacon_id == item.beacon_id).FirstOrDefault();
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            _db.Beacon.Remove(aux);
            _db.SaveChanges();
        }

        public bool Update(Beacon item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item"); 
            }
            else if(item.beacon_id<=-1 || item.entidade_id<=-1){
                return false;
            }
            else
            {
                db _db = new db();
                var aux = _db.Beacon.Where(b=>b.beacon_id==item.beacon_id).FirstOrDefault();
                aux.entidade_id = item.entidade_id;
                aux.estado = item.estado;
                _db.SaveChanges();
            }
            return true;
        }
    }
}