using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TCC.Models;
using System.Data.Entity;

namespace TCC.Controllers
{
    public class LoginController : ApiController
    {
        private TCCContext db = new TCCContext();

        [HttpPost]
        [Route("login/logar")]

        public IHttpActionResult logar(Login login)
        {
            try
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

            } catch(Exception e)
            {
                return BadRequest();
            }            
        }
    }
}
