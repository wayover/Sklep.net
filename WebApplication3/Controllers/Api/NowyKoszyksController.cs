using System;
using System.Collections.Generic;
using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
//using WebApplication3.Dtos;
//using WebApplication3.Models;

//namespace WebApplication3.Controllers.Api
//{
//    public class NowyKoszyksController : ApiController
//    {


//        private ApplicationDbContext _context;

//        public NowyKoszyksController()
//        {
//            _context = new ApplicationDbContext();
//        }

//        [HttpPost]
//        public IHttpActionResult CreateKoszyks(NowyKoszykDto nowyKoszyk)
//        {
//            var customer = _context.Customers.Single(c => c.Id == nowyKoszyk.CustomerId);

//            var przedmiots = _context.Przedmiots.Where(m => nowyKoszyk.PrzedmiotIds.Contains(m.ID)).ToList();

//            foreach (var przedmiot in przedmiots)
//            {


//                var koszyk = new Kupione()
//                {
//                    Customer = customer,
//                    Przedmiot = przedmiot,
//                };

//                _context.Koszyks.Add(koszyk);
//            }

//            _context.SaveChanges();
//            return Ok();
//        }

//    }
//}
