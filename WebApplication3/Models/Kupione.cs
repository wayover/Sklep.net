using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Kupione
    {

        public int Id { get; set; }
        public Przedmiot Przedmiot { get; set; }

        public string UserId { get; set; }
        [Required]
        public string Imie { get; set; }
        [Required]
        public string Nazwisko { get; set; }
        [Required]
        public string Ulica { get; set; }
        [Required]
        public int nrdomu { get; set; }
        public int nrmieszkania { get; set; }
        [Required]
        public string kodpocztowy { get; set; }
        [Required]
        public string miasto { get; set; }
        

        

    }
}