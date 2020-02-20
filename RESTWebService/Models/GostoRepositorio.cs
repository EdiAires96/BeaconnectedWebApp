using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTWebService.Models
{
    public class GostoRepositorio  : IGostoRepositorio
    {

        public GostoRepositorio()
        {

        }

        public Gosto Add(Gosto item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            else
            {
                db _db = new db();
                _db.Gosto.Add(item);
                _db.SaveChanges();
            }

            return item;
        }

        public Gosto Get(int id)
        {
            db _db = new db();
            return _db.Gosto.Where(g => g.gosto_id == id).FirstOrDefault();
        }

        public List<Gosto> GetAll()
        {
            db _db = new db();
            return _db.Gosto.ToList<Gosto>();
        }

        public void Remove(Gosto item)
        {
            db _db = new db();
            var aux = _db.Gosto.Where(g => g.gosto_id == item.gosto_id).FirstOrDefault();
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            _db.Gosto.Remove(aux);
            _db.SaveChanges();
        }

        public bool Update(Gosto item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            else if (item.gosto_id <= -1 || item.utilizador_id <= -1 | item.tema_id <= -1)
            {
                return false;
            }
            else
            {
                db _db = new db();
                var aux = _db.Gosto.Where(g => g.gosto_id == item.gosto_id).FirstOrDefault();
                aux.utilizador_id = item.utilizador_id;
                aux.tema_id = item.tema_id;
                _db.SaveChanges();
            }
            return true;
        }

    }
}