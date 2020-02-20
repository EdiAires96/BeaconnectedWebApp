namespace WebService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Conteudo")]
    public partial class Conteudo
    {
        [Key]
        public int conteudo_id { get; set; }

        public int beacon_id { get; set; }

        [Required]
        [StringLength(50)]
        public string titulo { get; set; }

        [Required]
        [StringLength(500)]
        public string noticia { get; set; }

        [StringLength(20)]
        public string imagem { get; set; }

        [StringLength(20)]
        public string categoria { get; set; }

        public DateTime m_data { get; set; }

        public bool estado { get; set; }

        public virtual Beacon Beacon { get; set; }
    }
}
