namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class innit3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Przedmiots",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(),
                        KategoriaId = c.Int(nullable: false),
                        ProducentId = c.Int(nullable: false),
                        Ilosc = c.Int(nullable: false),
                        Cena = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Opis = c.String(),
                        Zdjecie = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Kategorias", t => t.KategoriaId, cascadeDelete: true)
                .ForeignKey("dbo.Producents", t => t.ProducentId, cascadeDelete: true)
                .Index(t => t.KategoriaId)
                .Index(t => t.ProducentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Przedmiots", "ProducentId", "dbo.Producents");
            DropForeignKey("dbo.Przedmiots", "KategoriaId", "dbo.Kategorias");
            DropIndex("dbo.Przedmiots", new[] { "ProducentId" });
            DropIndex("dbo.Przedmiots", new[] { "KategoriaId" });
            DropTable("dbo.Przedmiots");
        }
    }
}
