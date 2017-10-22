using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TCC.Models;


using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

using System.Data.Entity;
using Newtonsoft.Json;

namespace TCC.Controllers
{
    public class ContratanteController : ApiController
    {
        private TCCContext db = new TCCContext();

      

        [Route("contratante/all")]
        public IHttpActionResult All()
        {
            var contratante = "";

            //db.Configuration.ProxyCreationEnabled = false;
            /* db.Configuratio.ProxyCreationEnabled = false;
             var contratante =
             db.Contratante
             .Include(t => t.ContratanteEstilo)
             .Include(t => t.Relacoes)
             .Select(s => new {
                 s.Bairro,
                 s.CEP,
                 s.Cidade,
                 s.CNPJ,
                 s.Compl,
                 s.Descricao,
                 s.Detalhe,
                 s.EmailContratante,
                 s.Estado,
                 s.Facebook,
                 s.img,
                 s.Nome,
                 s.Numero,
                 s.Rua,
                 s.Senha,
                 s.Site,
                 s.Telefone1,
                 s.Telefone2,
                 s.Estilos,
                 s.Relacoes
             }).ToList();*/




            return Ok(contratante);
        }

        [HttpPost]
        [Route("contratante/login")]
        
        public IHttpActionResult login(Login login)
        {

            var logado = new Object();

            var perfil = (string)login.perfil;
            var email = (string)login.email;
            var senha = (string)login.senha;

            if (perfil == "contratante")
            {
                logado = db.Contratante.
                     Include(x => x.ContratanteEstilo)
                            .Where(c => c.EmailContratante == email && c.Senha == senha)
                            .FirstOrDefault();
            }
            else
            {
                logado = db.Artista
                            .Include(x => x.EstiloArtista)
                            .Where(c => c.EmailArtista == email && c.Senha == senha)
                            .FirstOrDefault();
           }


            var response = new
            {
               data = logado,
                login = login
            };



            return Ok(response);
        }

    }
}


