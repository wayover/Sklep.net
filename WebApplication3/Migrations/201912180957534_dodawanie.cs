namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dodawanie : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Producents(nazwa) values ('SwiatGwozdzi')");
            Sql("INSERT INTO Producents(nazwa) values ('StepienSsA')");
            Sql("INSERT INTO Producents(nazwa) values ('ScamSpZOO')");
            Sql("INSERT INTO Producents(nazwa) values ('SlabeAleTanie')");
            Sql("INSERT INTO Producents(nazwa) values ('KasaNajwazniejsza')");
            Sql("INSERT INTO Producents(nazwa) values ('BlachoKwadrat')");
            Sql("INSERT INTO Kategorias(nazwa) values ('Gwozdzie')");
            Sql("INSERT INTO Kategorias(nazwa) values ('Srubka')");
            Sql("INSERT INTO Kategorias(nazwa) values ('Kolki')");
            Sql("INSERT INTO Kategorias(nazwa) values ('Blachy')");
            Sql("INSERT INTO Kategorias(nazwa) values ('Kolumny')");

        }
        
        public override void Down()
        {
        }
    }
}
