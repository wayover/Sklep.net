namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class appadnotation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Kategorias", "Nazwa", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Przedmiots", "Nazwa", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Producents", "Nazwa", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Producents", "Nazwa", c => c.String());
            AlterColumn("dbo.Przedmiots", "Nazwa", c => c.String());
            AlterColumn("dbo.Kategorias", "Nazwa", c => c.String());
            AlterColumn("dbo.Customers", "Name", c => c.String());
        }
    }
}
