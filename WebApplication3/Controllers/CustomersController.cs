using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;


namespace WebApplication3.Controllers
{
    public class CustomersController : Controller
    {
        // GET: CustomersControler

        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context=new ApplicationDbContext();
        }


        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }




        public ViewResult Index()
        {
          //  if (MemoryCache.Default["Kategorias"] == null)
           // {
           //     MemoryCache.Default["Kategorias"] = _context.Kategorias.ToList();
           // }

           // var kategorias = MemoryCache.Default["Kategorias"] as IEnumerable<Kategoria>;


           var customers = _context.Customers.ToList();
                return View(customers);
            }
        



        public ActionResult Details(int id)
            {
                var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

                if (customer == null)
                    return HttpNotFound();

                return View(customer);
            }


        public ActionResult New()
        {
            var user = new Customer();


                return View(user);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {

            if (!ModelState.IsValid)
            {
                return View("New", customer);
            }



            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.SurName = customer.SurName;

            }



            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }


        public ActionResult Edit(int id)
        {



                var customer = _context.Customers.SingleOrDefault(c => c.Id == id);


                if (customer == null)
                {
                    return HttpNotFound();
                }


                return View("New", customer);
            

        }


    }
} 

            
