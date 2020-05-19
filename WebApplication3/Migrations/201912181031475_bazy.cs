namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bazy : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Przedmiots (Nazwa,KategoriaId,ProducentId,Ilosc,Cena,Opis) values ('Zestaw gwozdzi',1,1,32,12.45,'Zestaw 100 gwozdzi')");
            Sql("INSERT INTO Przedmiots (Nazwa,KategoriaId,ProducentId,Ilosc,Cena,Opis) values ('Sruby stepnia',2,2,53,2.49,'zlamana sruba stepnia')");
            Sql("INSERT INTO Przedmiots (Nazwa,KategoriaId,ProducentId,Ilosc,Cena,Opis) values ('Kolek',3,4,432,3.45,'Po prostu kolek')");
            Sql("INSERT INTO Przedmiots (Nazwa,KategoriaId,ProducentId,Ilosc,Cena,Opis) values ('Kwadratowa blacha',4,6,32,72.45,'Blacha 10x10')");
            Sql("INSERT INTO Przedmiots (Nazwa,KategoriaId,ProducentId,Ilosc,Cena,Opis) values ('Tania kolumna',5,4,54,62.65,'Kolumna bardzo slaba')");
            Sql("INSERT INTO Przedmiots (Nazwa,KategoriaId,ProducentId,Ilosc,Cena,Opis) values ('Drogie sruby',2,5,86,22.45,'droga sruba')");
        }
        
        public override void Down()
        {
        }
    }
}


