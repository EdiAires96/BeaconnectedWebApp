using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTWebService.Models
{
    public class UtilizadorRepositorio : IUtlizadorRepositorio
    {

        public UtilizadorRepositorio()
        {

        }

        public Utilizador Add(Utilizador item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            else
            {
                db _db = new db();
                _db.Utilizador.Add(item);
                _db.SaveChanges();
            }

            return item;
        }

        public Utilizador Get(int id)
        {
            db _db = new db();
            return _db.Utilizador.Where(u => u.utilizador_id == id).FirstOrDefault();
        }

        public List<Utilizador> GetAll()
        {
            db _db = new db();
            return _db.Utilizador.ToList<Utilizador>();
        }

        public void Remove(Utilizador item)
        {
            db _db = new db();
            var aux = _db.Utilizador.Where(u => u.utilizador_id == item.utilizador_id).FirstOrDefault();
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            _db.Utilizador.Remove(aux);
            _db.SaveChanges();
        }

        public bool Update(Utilizador item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            else if (item.utilizador_id <= -1 )
            {
                return false;
            }
            else
            {
                db _db = new db();
                var aux = _db.Utilizador.Where(u => u.utilizador_id == item.utilizador_id).FirstOrDefault();
                aux.nome=item.nome;
                aux.email = item.email;
                _db.SaveChanges();
            }
            return true;
        }

    }
}