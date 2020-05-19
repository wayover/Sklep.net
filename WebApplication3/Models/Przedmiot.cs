using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Przedmiot
    {
        public int ID { get; set; }
        [Required]
        [StringLength(255)]
        public string Nazwa { get; set; }

        public Kategoria Kategoria { get; set; }
        [Required]
        [Display(Name = "Kategoria")]
        public int KategoriaId { get; set; }

        public Producent Producent { get; set; }
        [Required]
        [Display(Name = "Producent")]
        public int ProducentId { get; set; }


        [Required]
        public decimal Cena { get; set; }
        public string Opis { get; set; }
        public string Zdjecie { get; set; }

    }
}