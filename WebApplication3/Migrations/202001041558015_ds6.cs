namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ds6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tranzakcjes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PrzedmiotId = c.Int(nullable: false),
                        UserId = c.String(nullable: false),
                        Date = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Przedmiots", t => t.PrzedmiotId, cascadeDelete: true)
                .Index(t => t.PrzedmiotId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tranzakcjes", "PrzedmiotId", "dbo.Przedmiots");
            DropIndex("dbo.Tranzakcjes", new[] { "PrzedmiotId" });
            DropTable("dbo.Tranzakcjes");
        }
    }
}
