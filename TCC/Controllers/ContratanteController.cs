using System;
using System.Linq;
using System.Web.Http;
using TCC.Models;
using System.Data.Entity;
using System.Net.Http;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;

namespace TCC.Controllers
{
    public class ContratanteController : ApiController
    {
        private TCCContext db = new TCCContext();


        [HttpGet]
        [Route("contratante/all")]
        public IHttpActionResult all()
        {


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

            var contratante =  db.Contratante.
                    Include(x => x.ContratanteEstilo)                          
                           .ToList();


            return Ok(contratante);
        }

        [HttpPost]
        [Route("contratante/create")]

        public IHttpActionResult Create(JObject obj)
        {
            Contratante contratante;

            String email = (String)obj["email"];

            try
            { 
                try
                {
                    contratante = db.Contratante.Where(c => c.EmailContratante == email).FirstOrDefault();

                    if (contratante != null)
                    {
                        return Json(
                            new
                            {
                                code = 1,
                                status = "NOK",
                                message = "Contratante já Cadastrado"
                            });
                    }

                    contratante = new Contratante();
                    
                    contratante.Bairro           = (String)obj["bairro"];
                    contratante.CEP              = (long)  obj["cep"];
                    contratante.Cidade           = (String)obj["cidade"];
                    contratante.CNPJ             = (String)obj["cnpj"];
                    contratante.Compl            = (String)obj["complemento"];
                    contratante.Descricao        = (String)obj["descricao"];
                    contratante.Detalhe          = (String)obj["detalhe"];
                    contratante.EmailContratante = (String)obj["email"];
                    contratante.Estado           = (String)obj["estado"];
                    contratante.Nome             = (String)obj["nome"];
                    contratante.Numero           = (int)   obj["numero"];
                    contratante.Rua              = (String)obj["rua"];
                    contratante.Senha            = (String)obj["senha"];
                    contratante.Facebook         = (String)obj["facebook"];
                   
                    contratante.Site             = (String)obj["site"];
                    contratante.Telefone1        = (String)obj["whatsapp"];
                    contratante.Telefone2        = (String)obj["telefone"];

                    String img = (String)obj["img"];

                    contratante.img = LoadImage(img);



                    db.Contratante.Add(contratante);
                    db.SaveChanges();
                } catch
                {
                    throw;
                }
    
                try
                {
                    IList<Estilo> estilos = new List<Estilo>();

                    foreach (int i in obj["estilo"])  {

                        ContratanteEstilo contratanteEstilo = new ContratanteEstilo();
                        contratanteEstilo.Contratante = contratante;
                        contratanteEstilo.Estilo = db.Estilo.Where(e => e.Id == i).FirstOrDefault();
                        db.ContratanteEstilo.Add(contratanteEstilo);
                        db.SaveChanges();
                    }
                    
                } catch
                {
                    throw;
                }

                return Json(new
                {
                    code = 2,
                    status = "OK",
                    message = "Contratante cadastrado com sucesso"
                });

  






            } catch (Exception ex)
            {
                return Json(new
                {
                    status = "ERROR",
                    message = "Error: " + ex.Message
                });
            }



            
        }

        public byte[] LoadImage(String o)
        {
            //data:image/gif;base64,
            //this image is a single pixel (black)
            byte[] bytes = Convert.FromBase64String(o);

            

            return bytes;
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


