namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _21312312l : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tranzakcjes", "UserId", c => c.String());

        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tranzakcjes", "UserId", c => c.String(nullable: false));

        }
    }
}
