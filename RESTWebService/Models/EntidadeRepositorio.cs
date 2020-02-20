using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTWebService.Models
{
    public class EntidadeRepositorio : IEntidadeRepositorio
    {

        public EntidadeRepositorio()
        {

        }

        public Entidade Add(Entidade item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            else
            {
                db _db = new db();
                _db.Entidade.Add(item);
                _db.SaveChanges();
            }

            return item;
        }

        public Entidade Get(int id)
        {
            db _db = new db();
            return _db.Entidade.Where(e => e.entidade_id == id).FirstOrDefault();
        }

        public List<Entidade> GetAll()
        {
            db _db = new db();
            return _db.Entidade.ToList<Entidade>();
        }

        public void Remove(Entidade item)
        {
            db _db = new db();
            var aux = _db.Entidade.Where(e => e.entidade_id == item.entidade_id).FirstOrDefault();
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            _db.Entidade.Remove(aux);
            _db.SaveChanges();
        }

        public bool Update(Entidade item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            else if (item.entidade_id <= -1 || item.tema_id <= -1)
            {
                return false;
            }
            else
            {
                db _db = new db();
                var aux = _db.Entidade.Where(e => e.entidade_id == item.entidade_id).FirstOrDefault();
                aux.nome = item.nome;
                aux.email = item.email;
                aux.morada = item.morada;
                aux.tema_id = item.tema_id;
                aux.estado = item.estado;
                _db.SaveChanges();
            }
            return true;
        }

    }
}