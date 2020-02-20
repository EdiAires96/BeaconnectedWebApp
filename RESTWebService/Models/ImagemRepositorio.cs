using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace RESTWebService.Models
{
    public class ImagemRepositorio : IImagemRepositorio
    {
        public ImagemRepositorio()
        {

        }

        public Imagem Get(string nome)
        {
            Imagem item = new Imagem();
            item.nome = nome;
            item.image=System.IO.File.ReadAllBytes(
          System.Web.Hosting.HostingEnvironment.MapPath
              ("~/Images/") + nome);
            return item;
        }


        public Imagem Add(Imagem item)
        {

            MemoryStream ms = new MemoryStream(item.image);

            FileStream fs = new FileStream(System.Web.Hosting.HostingEnvironment.MapPath
                        ("~/Images/") + item.nome, FileMode.Create);


            ms.WriteTo(fs);

            ms.Close();
            fs.Close();
            fs.Dispose();

            return item;
        }

        public void Remove(string nome)
        {
            string path = System.Web.Hosting.HostingEnvironment.MapPath
                        ("~/Images/") + nome;
            File.Delete(path);

        }
    }
}