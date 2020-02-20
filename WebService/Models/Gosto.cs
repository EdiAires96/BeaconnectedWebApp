namespace WebService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Gosto")]
    public partial class Gosto
    {
        [Key]
        public int gosto_id { get; set; }

        public int utilizador_id { get; set; }

        public int tema_id { get; set; }

        public virtual Tema Tema { get; set; }

        public virtual Utilizador Utilizador { get; set; }
    }
}
