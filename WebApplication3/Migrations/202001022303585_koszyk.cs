namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class koszyk : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Koszyks", name: "CustomerId", newName: "Customer_Id");
            RenameColumn(table: "dbo.Koszyks", name: "PrzedmiotId", newName: "Przedmiot_ID");
            RenameIndex(table: "dbo.Koszyks", name: "IX_CustomerId", newName: "IX_Customer_Id");
            RenameIndex(table: "dbo.Koszyks", name: "IX_PrzedmiotId", newName: "IX_Przedmiot_ID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Koszyks", name: "IX_Przedmiot_ID", newName: "IX_PrzedmiotId");
            RenameIndex(table: "dbo.Koszyks", name: "IX_Customer_Id", newName: "IX_CustomerId");
            RenameColumn(table: "dbo.Koszyks", name: "Przedmiot_ID", newName: "PrzedmiotId");
            RenameColumn(table: "dbo.Koszyks", name: "Customer_Id", newName: "CustomerId");
        }
    }
}
