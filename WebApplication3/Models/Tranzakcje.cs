using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApplication3.Models
{
    public class Tranzakcje
    {

        
        public int Id { get; set; }
        public Przedmiot Przedmiot  { get; set; }
        public int PrzedmiotId { get; set; }
        public string UserId { get; set; }
        [DisplayName("Data zakupu")]
        public string Date { get; set; }

        public string Cena { get; set; }
        public string Nazwa { get; set; }




    }
}