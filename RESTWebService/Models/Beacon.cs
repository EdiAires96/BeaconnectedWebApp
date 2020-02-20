namespace RESTWebService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Beacon")]
    public partial class Beacon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Beacon()
        {
            Conteudo = new HashSet<Conteudo>();
        }

        [Key]
        public int beacon_id { get; set; }

        public int entidade_id { get; set; }

        public bool estado { get; set; }

        public virtual Entidade Entidade { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Conteudo> Conteudo { get; set; }
    }
}
