namespace RESTWebService.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class db : DbContext
    {
        public db()
            : base("name=db")
        {
        }

        public virtual DbSet<Beacon> Beacon { get; set; }
        public virtual DbSet<Conteudo> Conteudo { get; set; }
        public virtual DbSet<Entidade> Entidade { get; set; }
        public virtual DbSet<Gosto> Gosto { get; set; }
        public virtual DbSet<Tema> Tema { get; set; }
        public virtual DbSet<Utilizador> Utilizador { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Beacon>()
                .HasMany(e => e.Conteudo)
                .WithRequired(e => e.Beacon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Entidade>()
                .HasMany(e => e.Beacon)
                .WithRequired(e => e.Entidade)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tema>()
                .HasMany(e => e.Entidade)
                .WithRequired(e => e.Tema)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tema>()
                .HasMany(e => e.Gosto)
                .WithRequired(e => e.Tema)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Utilizador>()
                .HasMany(e => e.Gosto)
                .WithRequired(e => e.Utilizador)
                .WillCascadeOnDelete(false);
        }
    }
}
