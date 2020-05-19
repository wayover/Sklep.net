namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class innit5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Koszyks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PrzedmiotId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        Ilosc = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Przedmiots", t => t.PrzedmiotId, cascadeDelete: true)
                .Index(t => t.PrzedmiotId)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Koszyks", "PrzedmiotId", "dbo.Przedmiots");
            DropForeignKey("dbo.Koszyks", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Koszyks", new[] { "CustomerId" });
            DropIndex("dbo.Koszyks", new[] { "PrzedmiotId" });
            DropTable("dbo.Koszyks");
        }
    }
}
