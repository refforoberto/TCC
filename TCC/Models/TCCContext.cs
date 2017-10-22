using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace TCC.Models
{
    public class TCCContext: DbContext
    {
        public TCCContext() : base("DefaultConnection")
        {
            Database.SetInitializer<TCCContext>(new DropCreateDatabaseIfModelChanges<TCCContext>());
        }

        public virtual DbSet<Estilo> Estilo { get; set; }
        public virtual DbSet<Contratante> Contratante { get; set; }
        public virtual DbSet<Artista> Artista { get; set; }
        public virtual DbSet<Relacao> Relacao { get; set; }
        public virtual DbSet<ContratanteEstilo> ContratanteEstilo { get; set; }
        public virtual DbSet<EstiloArtista> EstiloArtista { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}