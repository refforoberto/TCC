namespace TCC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TCC.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TCC.Models.TCCContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TCC.Models.TCCContext context)
        {
            context.Estilo.AddOrUpdate(
                 p => p.Id,
                 new Estilo { Id = 1, Nome = "Rock" },
                 new Estilo { Id = 2, Nome = "Pop" },
                 new Estilo { Id = 3, Nome = "Pagode" },
                 new Estilo { Id = 4, Nome = "Sertanejo" },
                 new Estilo { Id = 5, Nome = "MPB" },
                 new Estilo { Id = 6, Nome = "Samba" },
                 new Estilo { Id = 7, Nome = "Outros" }

                 );
            context.SaveChanges();




            context.Contratante.AddOrUpdate(
                p => p.EmailContratante,
                new Contratante
                {
                    EmailContratante = "e@e.com",
                    //ContratanteEstilo = context.Estilo.ToList(),
                    Senha = "123",
                    Nome = "American Pub",
                    Descricao = "Music Pub",
                    CNPJ = "132.123.123.126-22",
                    Rua = "Rua Inacio Alves",
                    Numero = 12,
                    CEP = 89555520,
                    Cidade = "Joinville",
                    Estado = "SC",
                    Bairro = "Centro",
                    Compl = "",
                    Site = "www.american.com",
                    Telefone1 = "(47)99999-88-77",
                    Telefone2 = "(47)3344-88-77",
                    img2 = "assets/images/american.png",
                    Facebook = "https://www.facebook.com/AmericanMusicPub/",
                    Detalhe = "Mussum Ipsum, cacilds vidis litro abertis. Todo mundo vê os porris que eu tomo, " +
                    "mas ninguém vê os tombis que eu levo! Manduma pindureta quium dia nois paga. Atirei o pau no gatis," +
                    " per gatis num morreus. Quem num gosta di mé, boa gentis num é."

                },
                new Contratante
                {
                    EmailContratante = "c@c.com",
                    Senha = "123",
                    Nome = "Duds Bar",
                    Descricao = "Bar e Lanchonete",
                    CNPJ = "132.123.123.126-22",
                    Rua = "Rua Inacio Alves",
                    Numero = 12,
                    CEP = 89555520,
                    Cidade = "Garuva",
                    Estado = "SC",
                    Bairro = "Centro",
                    Compl = "",
                    Site = "www.duds.com.br",
                    Telefone1 = "(47)99999-88-77",
                    img2 = "assets/images/duds.jpg",
                    Detalhe = "Mussum Ipsum, cacilds vidis litro abertis. Todo mundo vê os porris que eu tomo, " +
                    "mas ninguém vê os tombis que eu levo! Manduma pindureta quium dia nois paga. Atirei o pau no gatis," +
                    " per gatis num morreus. Quem num gosta di mé, boa gentis num é."
                },
                new Contratante
                {
                    EmailContratante = "f@f.com",
                    Senha = "123",
                    Nome = "Manos Bar",
                    Descricao = "Bar e Lanchonete",
                    CNPJ = "132.123.123.126-22",
                    Rua = "Rua Inacio Alves",
                    Numero = 12,
                    CEP = 89555520,
                    Cidade = "Joinville",
                    Estado = "SC",
                    Bairro = "Centro",

                    Compl = "",
                    Site = "www.manosbar.com.br",
                    Telefone1 = "(47)99999-88-77",
                    img2 = "assets/images/manos.jpg",
                    Detalhe = "Mussum Ipsum, cacilds vidis litro abertis. Todo mundo vê os porris que eu tomo, " +
                    "mas ninguém vê os tombis que eu levo! Manduma pindureta quium dia nois paga. Atirei o pau no gatis," +
                    " per gatis num morreus. Quem num gosta di mé, boa gentis num é."
                },
                new Contratante
                {
                    EmailContratante = "g@g.com",
                    Senha = "123",
                    Nome = "Bar dos Amigos",
                    Descricao = "Bar e Lanchonete",
                    CNPJ = "132.123.123.126-22",
                    Rua = "Rua Inacio Alves",
                    Numero = 12,
                    CEP = 89555520,
                    Cidade = "Joinville",
                    Estado = "SC",
                    Bairro = "Centro",
                    Compl = "",
                    Site = "www.bardosamigos.com",
                    Telefone1 = "(47)99999-88-77",
                    img2 = "assets/images/barAmigos.jpg",
                    Detalhe = "Mussum Ipsum, cacilds vidis litro abertis. Todo mundo vê os porris que eu tomo, " +
                    "mas ninguém vê os tombis que eu levo! Manduma pindureta quium dia nois paga. Atirei o pau no gatis," +
                    " per gatis num morreus. Quem num gosta di mé, boa gentis num é."
                }
            );
            context.SaveChanges();

            context.Artista.AddOrUpdate(
                p => p.EmailArtista,
                new Artista
                {
                    EmailArtista = "a@a.com",
                    Senha = "123",
                    Nome = "Edinho Santos",
                    Descricao = "Músico com mais de 20 anos de experiência.",
                    CPF = "132.123.123.12",
                    Rua = "Rua das Cegonhas",
                    Numero = 444,
                    CEP = 89555520,
                    Cidade = "Joinville",
                    Estado = "SC",
                    Bairro = "Iririu",
                    Compl = "",
                    Site = "www.edinhoshow.com.br",
                    Telefone1 = "(47) 9875-8974"
                },
                new Artista
                {
                    EmailArtista = "b@b.com",
                    Senha = "123",
                    Nome = "Fabio Amarantes",
                    Descricao = "Voz e Violão focado em pop/rock",
                    CPF = "132.123.123.12",
                    Rua = "Rua Santa Catarina",
                    Numero = 777,
                    CEP = 89555520,
                    Cidade = "Joinville",
                    Estado = "SC",
                    Bairro = "floresta",
                    Compl = "",
                    Site = "www.amarantemusic.com.br",
                    Telefone1 = "(47) 9875-87774"
                }
            );
            context.SaveChanges();


            context.Relacao.AddOrUpdate(p => p.Id,
                new Relacao
                {
                    Artista = context.Artista.Where(a => a.EmailArtista == "a@a.com").FirstOrDefault(),
                    Contratante = context.Contratante.Where(a => a.EmailContratante == "e@e.com").FirstOrDefault(),
                    Status = "p",
                    DataSolicitacao = DateTime.Now,
                    Solicitante = "A"
                }
            );
            context.SaveChanges();

            context.ContratanteEstilo.AddOrUpdate(c => c.Id,
                new ContratanteEstilo
                {
                    Contratante = context.Contratante.FirstOrDefault(),
                    Estilo = context.Estilo.FirstOrDefault()

                });
            context.SaveChanges();

            context.EstiloArtista.AddOrUpdate(c => c.Id,
                new EstiloArtista
                {
                    Artista = context.Artista.FirstOrDefault(),
                    Estilo = context.Estilo.FirstOrDefault()

                });
            context.SaveChanges();

        }
    }
}
