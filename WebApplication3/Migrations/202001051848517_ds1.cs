namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ds1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Kupiones", "Imie", c => c.String(nullable: false));
            AddColumn("dbo.Kupiones", "Nazwisko", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Kupiones", "Nazwisko");
            DropColumn("dbo.Kupiones", "Imie");
        }
    }
}
