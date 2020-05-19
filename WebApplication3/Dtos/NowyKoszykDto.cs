using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Dtos
{
    public class NowyKoszykDto
    {

        public int CustomerId { get; set; }
        public List<int> PrzedmiotIds { get; set; }
    }
}