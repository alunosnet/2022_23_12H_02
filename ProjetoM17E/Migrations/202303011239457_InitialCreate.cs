namespace ProjetoM17E.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Entregas",
                c => new
                    {
                        EntregaId = c.Int(nullable: false, identity: true),
                        utilizadorid = c.Int(nullable: false),
                        ProdutoId = c.Int(nullable: false),
                        data_entrega = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EntregaId)
                .ForeignKey("dbo.Produtoes", t => t.ProdutoId, cascadeDelete: true)
                .ForeignKey("dbo.Utilizadors", t => t.utilizadorid, cascadeDelete: true)
                .Index(t => t.utilizadorid)
                .Index(t => t.ProdutoId);
            
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        ProdutoId = c.Int(nullable: false, identity: true),
                        Peso = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Tipo = c.Int(nullable: false),
                        Fragil = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProdutoId);
            
            CreateTable(
                "dbo.Utilizadors",
                c => new
                    {
                        UtilizadorId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Perfil = c.Int(nullable: false),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UtilizadorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Entregas", "utilizadorid", "dbo.Utilizadors");
            DropForeignKey("dbo.Entregas", "ProdutoId", "dbo.Produtoes");
            DropIndex("dbo.Entregas", new[] { "ProdutoId" });
            DropIndex("dbo.Entregas", new[] { "utilizadorid" });
            DropTable("dbo.Utilizadors");
            DropTable("dbo.Produtoes");
            DropTable("dbo.Entregas");
        }
    }
}
