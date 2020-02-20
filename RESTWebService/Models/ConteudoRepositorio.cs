using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTWebService.Models
{
    public class ConteudoRepositorio : IConteudoRepositorio
    {

        public ConteudoRepositorio()
        {

        }

        public Conteudo Add(Conteudo item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            else
            {
                db _db = new db();
                _db.Conteudo.Add(item);
                _db.SaveChanges();
            }

            return item;
        }

        public Conteudo Get(int id)
        {
            db _db = new db();
            return _db.Conteudo.Where(c => c.conteudo_id == id).FirstOrDefault();
        }

        public List<Conteudo> GetAll()
        {
            db _db = new db();
            return _db.Conteudo.ToList<Conteudo>();
        }

        public void Remove(Conteudo item)
        {
            db _db = new db();
            var aux = _db.Conteudo.Where(c => c.conteudo_id == item.conteudo_id).FirstOrDefault();
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            _db.Conteudo.Remove(aux);
            _db.SaveChanges();
        }

        public bool Update(Conteudo item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            else if (item.conteudo_id <= -1 || item.beacon_id <= -1)
            {
                return false;
            }
            else
            {
                db _db = new db();
                var aux = _db.Conteudo.Where(c => c.conteudo_id == item.conteudo_id).FirstOrDefault();
                aux.beacon_id = item.beacon_id;
                aux.titulo = item.titulo;
                aux.noticia = item.noticia;
                aux.imagem = item.imagem;
                aux.categoria = item.categoria;
                aux.m_data = item.m_data;
                aux.estado = item.estado;
                _db.SaveChanges();
            }
            return true;
        }
    }
}