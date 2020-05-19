namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fdfd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Koszyks", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Koszyks", "Przedmiot_ID", "dbo.Przedmiots");
            DropIndex("dbo.Koszyks", new[] { "Customer_Id" });
            DropIndex("dbo.Koszyks", new[] { "Przedmiot_ID" });
            CreateTable(
                "dbo.Kupiones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        Ulica = c.String(nullable: false),
                        nrdomu = c.Int(nullable: false),
                        nrmieszkania = c.Int(nullable: false),
                        kodpocztowy = c.String(nullable: false),
                        miasto = c.String(nullable: false),
                        Przedmiot_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Przedmiots", t => t.Przedmiot_ID)
                .Index(t => t.Przedmiot_ID);
            
            DropTable("dbo.Koszyks");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Koszyks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ilosc = c.Int(nullable: false),
                        Customer_Id = c.Int(nullable: false),
                        Przedmiot_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Kupiones", "Przedmiot_ID", "dbo.Przedmiots");
            DropIndex("dbo.Kupiones", new[] { "Przedmiot_ID" });
            DropTable("dbo.Kupiones");
            CreateIndex("dbo.Koszyks", "Przedmiot_ID");
            CreateIndex("dbo.Koszyks", "Customer_Id");
            AddForeignKey("dbo.Koszyks", "Przedmiot_ID", "dbo.Przedmiots", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Koszyks", "Customer_Id", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
