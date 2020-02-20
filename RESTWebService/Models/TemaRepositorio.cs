using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTWebService.Models
{
    public class TemaRepositorio : ITemaRepositorio
    {
        public TemaRepositorio()
        {

        }

        public Tema Add(Tema item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            else
            {
                db _db = new db();
                _db.Tema.Add(item);
                _db.SaveChanges();
            }

            return item;
        }

        public Tema Get(int id)
        {
            db _db = new db();
            return _db.Tema.Where(t => t.tema_id == id).FirstOrDefault();
        }

        public List<Tema> GetAll()
        {
            db _db = new db();
            return _db.Tema.ToList<Tema>();
        }

        public void Remove(Tema item)
        {
            db _db = new db();
            var aux = _db.Tema.Where(t => t.tema_id == item.tema_id).FirstOrDefault();
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            _db.Tema.Remove(aux);
            _db.SaveChanges();
        }

        public bool Update(Tema item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            else if (item.tema_id <= -1 )
            {
                return false;
            }
            else
            {
                db _db = new db();
                var aux = _db.Tema.Where(t => t.tema_id == item.tema_id).FirstOrDefault();
                aux.nome= item.nome;
                _db.SaveChanges();
            }
            return true;
        }
    }
}