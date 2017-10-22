using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TCC.Models
{
    public class Artista
    {
        public Artista()
        {
            this.EstiloArtista = new List<EstiloArtista>();
        }

        [Key]
        public String EmailArtista { get; set; }

        public String Senha { get; set; }

        public String Nome { get; set; }

        public String Descricao { get; set; }

        public String Detalhe { get; set; }

        public String Rua { get; set; }

        public int Numero { get; set; }

        public String Compl { get; set; }

        public String Bairro { get; set; }

        public String Cidade { get; set; }

        public String Estado { get; set; }

        public long CEP { get; set; }

        public String img { get; set; }

        public String Telefone1 { get; set; }

        public String Telefone2 { get; set; }

        public String Site { get; set; }

        public String Facebook { get; set; }

        public String CPF { get; set; }

        public virtual ICollection<EstiloArtista> EstiloArtista { get; set; }

        //[JsonIgnore]
        public virtual ICollection<Relacao> Relacoes { get; set; }
    }
}