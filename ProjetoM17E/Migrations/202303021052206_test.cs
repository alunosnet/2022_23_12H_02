namespace ProjetoM17E.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Utilizadors", "Estado", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Utilizadors", "Estado", c => c.Boolean(nullable: false));
        }
    }
}
