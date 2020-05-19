using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.Controllers;
using WebApplication3.Models;

namespace WebApplication3.ViewModels
{
    public class RandomProducentViewModel
    {
        public Producent Producent { get; set; }
        public List<Customer> Customers { get; set; }
    }
}