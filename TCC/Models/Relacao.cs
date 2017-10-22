using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TCC.Models
{
    public class Relacao
    {
        [Key]
        public long Id { get; set; }

      
        public String EmailContratante { get; set; }

      
        public String EmailArtista { get; set; }

        public String Solicitante { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DataSolicitacao { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DataFinalizacao { get; set; }

        public String Status { get; set; }

       
        public virtual Artista Artista { get; set; }
       
        public virtual Contratante Contratante { get; set; }
    }
}