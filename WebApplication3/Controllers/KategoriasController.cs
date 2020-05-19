using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;
using WebApplication3.ViewModels;

namespace WebApplication3.Controllers
{
    public class KategoriasController : Controller
    {




        private ApplicationDbContext _context;

        public KategoriasController()
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
                var kategoria = _context.Kategorias.ToList();
                return View(kategoria);
            }

            return View("Uprawnienia");
        }


        [HttpPost]
        public ActionResult Save(Kategoria kategoria)
        {

            if (!ModelState.IsValid)
            {
                return View("New", kategoria);
            }



            if (kategoria.Id == 0)
            {
                _context.Kategorias.Add(kategoria);
            }
            else
            {
                var kategoriaDb = _context.Kategorias.Single(c => c.Id == kategoria.Id);

                kategoriaDb.Nazwa = kategoria.Nazwa;

            }



            _context.SaveChanges();
            return RedirectToAction("Index", "Kategorias");
        }



        public ActionResult New()
        {


            if (User.IsInRole(RoleName.CanManagePredmiot))
            {
                var kategoria=new Kategoria();


                return View(kategoria);

            }

            

            return View("Uprawnienia");

        }




        public ActionResult Edit(int id)
        {

            if (User.IsInRole(RoleName.CanManagePredmiot))
            {

                var kategoria = _context.Kategorias.SingleOrDefault(c => c.Id == id);


                if (kategoria == null)
                {
                    return HttpNotFound();
                }


                return View("New", kategoria);
            }

            return View("Uprawnienia");
        }



    }
}