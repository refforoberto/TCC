﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCC.Models
{
    public class ContratanteEstilo
    {
        public long Id { get; set; }
      
        public virtual Estilo Estilo { get; set; }

        [JsonIgnore]
        public virtual Contratante Contratante { get; set; }
    }
}