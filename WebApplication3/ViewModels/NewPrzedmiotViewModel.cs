using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.Models;

namespace WebApplication3.ViewModels
{
    public class NewPrzedmiotViewModel
    {
        public IEnumerable<Producent> Producent { get; set; }
        public IEnumerable<Kategoria> Kategoria { get; set; }
        public Przedmiot Przedmiot { get; set; }
    }
}