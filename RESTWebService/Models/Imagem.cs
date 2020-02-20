using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace RESTWebService.Models
{
    public class Imagem
    {
        public Imagem()
        {

        }
        public string nome { get; set; }

        public byte[] image { get; set; }


    }
}