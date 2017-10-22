using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCC.Models
{
   
    public class Estilo
    {
        public Estilo()
        {
            this.ContratanteEstilo = new List<ContratanteEstilo>();
            this.EstiloArtista = new List<EstiloArtista>();
        }

        
        public long Id { get; set; }
       
        public String Nome { get; set; }


        // public virtual ICollection<Contratante> Contratantes { get; set; }

        
        public virtual IList<ContratanteEstilo> ContratanteEstilo { get; set; }

        
        public virtual IList<EstiloArtista> EstiloArtista { get; set; }

        //public virtual ICollection<Artista> Artista { get; set; }
    }
}