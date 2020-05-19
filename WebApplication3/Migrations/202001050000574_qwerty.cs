namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class qwerty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tranzakcjes", "Cena", c => c.String());
            AddColumn("dbo.Tranzakcjes", "Nazwa", c => c.String());
            DropColumn("dbo.Przedmiots", "Ilosc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Przedmiots", "Ilosc", c => c.Int(nullable: false));
            DropColumn("dbo.Tranzakcjes", "Nazwa");
            DropColumn("dbo.Tranzakcjes", "Cena");
        }
    }
}
