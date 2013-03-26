namespace AnunciosWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        IdCategoria = c.Int(nullable: false, identity: true),
                        NomeCategoria = c.String(),
                    })
                .PrimaryKey(t => t.IdCategoria);
            
            CreateTable(
                "dbo.Anuncios",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IdAnunciante = c.Int(nullable: false),
                        IdCategoria = c.Int(nullable: false),
                        DtCadastro = c.DateTime(nullable: false),
                        Titulo = c.String(),
                        Descricao = c.String(),
                        Gold = c.Boolean(nullable: false),
                        Imagem = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categorias", t => t.IdCategoria, cascadeDelete: true)
                .ForeignKey("dbo.Anunciantes", t => t.IdAnunciante, cascadeDelete: true)
                .Index(t => t.IdCategoria)
                .Index(t => t.IdAnunciante);
            
            CreateTable(
                "dbo.Anunciantes",
                c => new
                    {
                        IdAnunciante = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Email = c.String(),
                        Telefone = c.String(),
                    })
                .PrimaryKey(t => t.IdAnunciante);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Anuncios", new[] { "IdAnunciante" });
            DropIndex("dbo.Anuncios", new[] { "IdCategoria" });
            DropForeignKey("dbo.Anuncios", "IdAnunciante", "dbo.Anunciantes");
            DropForeignKey("dbo.Anuncios", "IdCategoria", "dbo.Categorias");
            DropTable("dbo.Anunciantes");
            DropTable("dbo.Anuncios");
            DropTable("dbo.Categorias");
        }
    }
}
