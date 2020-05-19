using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Microsoft.Owin.Security.Provider;
using WebApplication3.Models;
using WebApplication3.ViewModels;

namespace WebApplication3.Controllers
{
    public class ProducentsController : Controller
    {

        private ApplicationDbContext _context;

        public ProducentsController()
        {
            _context = new ApplicationDbContext();
        }


        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ViewResult Index()
        {
            if (User.IsInRole(RoleName.CanManagePredmiot))
            {
                var producent = _context.Producents.ToList();
                return View(producent);
            }

            return View("Uprawnienia");
        }


        [HttpPost]
        public ActionResult Save(Producent producent)
        {

            if (!ModelState.IsValid)
            {
                return View("New", producent);
            }




            if (producent.Id == 0)
            {
                _context.Producents.Add(producent);
            }
            else
            {
                var producentdb = _context.Producents.Single(c => c.Id == producent.Id);

                producentdb.Nazwa = producent.Nazwa;

            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Producents");
        }



        public ActionResult New()
        {

            var prod=new Producent();

            return View(prod);

        }




        public ActionResult Edit(int id)
        {

            if (User.IsInRole(RoleName.CanManagePredmiot))
            {
                var producent = _context.Producents.SingleOrDefault(c => c.Id == id);


                if (producent == null)
                {
                    return HttpNotFound();
                }


                return View("New", producent);
            }

            return View("Uprawnienia");
        }
        


    }
}