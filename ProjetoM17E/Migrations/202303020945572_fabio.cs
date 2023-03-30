namespace ProjetoM17E.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fabio : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Utilizadors", "Password", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Utilizadors", "Password", c => c.String(nullable: false));
        }
    }
}
