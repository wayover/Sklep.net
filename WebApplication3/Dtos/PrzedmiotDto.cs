using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication3.Models;

namespace WebApplication3.Dtos
{
    public class PrzedmiotDto
    {

        public int ID { get; set; }
        [Required]
        [StringLength(255)]
        public string Nazwa { get; set; }

        [Required]
        public int KategoriaId { get; set; }

        public KategoriaDto Kategoria { get; set; }

        [Required]
        public int ProducentId { get; set; }

        public ProducentDto Producent { get; set; }

        


        [Required]
        public int Ilosc { get; set; }
        [Required]
        public decimal Cena { get; set; }
        public string Opis { get; set; }
        public string Zdjecie { get; set; }

    }
}