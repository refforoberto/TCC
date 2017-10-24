namespace TCC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artista",
                c => new
                    {
                        EmailArtista = c.String(nullable: false, maxLength: 128),
                        Senha = c.String(),
                        Nome = c.String(),
                        Descricao = c.String(),
                        Detalhe = c.String(),
                        Rua = c.String(),
                        Numero = c.Int(nullable: false),
                        Compl = c.String(),
                        Bairro = c.String(),
                        Cidade = c.String(),
                        Estado = c.String(),
                        CEP = c.Long(nullable: false),
                        img = c.String(),
                        Telefone1 = c.String(),
                        Telefone2 = c.String(),
                        Site = c.String(),
                        Facebook = c.String(),
                        CPF = c.String(),
                    })
                .PrimaryKey(t => t.EmailArtista);
            
            CreateTable(
                "dbo.EstiloArtista",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Artista_EmailArtista = c.String(maxLength: 128),
                        Estilo_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artista", t => t.Artista_EmailArtista)
                .ForeignKey("dbo.Estilo", t => t.Estilo_Id)
                .Index(t => t.Artista_EmailArtista)
                .Index(t => t.Estilo_Id);
            
            CreateTable(
                "dbo.Estilo",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContratanteEstilo",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Contratante_EmailContratante = c.String(maxLength: 128),
                        Estilo_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contratante", t => t.Contratante_EmailContratante)
                .ForeignKey("dbo.Estilo", t => t.Estilo_Id)
                .Index(t => t.Contratante_EmailContratante)
                .Index(t => t.Estilo_Id);
            
            CreateTable(
                "dbo.Contratante",
                c => new
                    {
                        EmailContratante = c.String(nullable: false, maxLength: 128),
                        Senha = c.String(),
                        Nome = c.String(),
                        Descricao = c.String(),
                        Detalhe = c.String(),
                        Rua = c.String(),
                        Numero = c.Int(nullable: false),
                        Compl = c.String(),
                        Bairro = c.String(),
                        Cidade = c.String(),
                        Estado = c.String(),
                        CEP = c.Long(nullable: false),
                        img = c.Binary(),
                        img2 = c.String(),
                        Telefone1 = c.String(),
                        Telefone2 = c.String(),
                        Site = c.String(),
                        Facebook = c.String(),
                        CNPJ = c.String(),
                    })
                .PrimaryKey(t => t.EmailContratante);
            
            CreateTable(
                "dbo.Relacao",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        EmailContratante = c.String(maxLength: 128),
                        EmailArtista = c.String(maxLength: 128),
                        Solicitante = c.String(),
                        DataSolicitacao = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DataFinalizacao = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artista", t => t.EmailArtista)
                .ForeignKey("dbo.Contratante", t => t.EmailContratante)
                .Index(t => t.EmailContratante)
                .Index(t => t.EmailArtista);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EstiloArtista", "Estilo_Id", "dbo.Estilo");
            DropForeignKey("dbo.ContratanteEstilo", "Estilo_Id", "dbo.Estilo");
            DropForeignKey("dbo.Relacao", "EmailContratante", "dbo.Contratante");
            DropForeignKey("dbo.Relacao", "EmailArtista", "dbo.Artista");
            DropForeignKey("dbo.ContratanteEstilo", "Contratante_EmailContratante", "dbo.Contratante");
            DropForeignKey("dbo.EstiloArtista", "Artista_EmailArtista", "dbo.Artista");
            DropIndex("dbo.Relacao", new[] { "EmailArtista" });
            DropIndex("dbo.Relacao", new[] { "EmailContratante" });
            DropIndex("dbo.ContratanteEstilo", new[] { "Estilo_Id" });
            DropIndex("dbo.ContratanteEstilo", new[] { "Contratante_EmailContratante" });
            DropIndex("dbo.EstiloArtista", new[] { "Estilo_Id" });
            DropIndex("dbo.EstiloArtista", new[] { "Artista_EmailArtista" });
            DropTable("dbo.Relacao");
            DropTable("dbo.Contratante");
            DropTable("dbo.ContratanteEstilo");
            DropTable("dbo.Estilo");
            DropTable("dbo.EstiloArtista");
            DropTable("dbo.Artista");
        }
    }
}
