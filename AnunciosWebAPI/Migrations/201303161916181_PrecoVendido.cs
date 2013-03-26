namespace AnunciosWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrecoVendido : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Anuncios", "Vendido", c => c.Boolean(nullable: false));
            AddColumn("dbo.Anuncios", "Preco", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Anuncios", "Preco");
            DropColumn("dbo.Anuncios", "Vendido");
        }
    }
}
