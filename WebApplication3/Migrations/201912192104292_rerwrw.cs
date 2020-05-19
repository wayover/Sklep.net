namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rerwrw : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "SurName", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "SurName");
        }
    }
}
