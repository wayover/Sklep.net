using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;
using System.Data.Entity;
using System.Web.UI.WebControls;
using WebApplication3.ViewModels;

namespace WebApplication3.Controllers
{
    public class PrzedmiotsController : Controller
    {
        private ApplicationDbContext _context;

        public PrzedmiotsController()
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
                
                return View("Index");

            }

            var przedmiot = _context.Przedmiots.Include(c => c.Producent).Include(c => c.Kategoria).ToList();

            return View("ReadOnlyList", przedmiot);

        }



        
        public ActionResult Details(int id)
        {
            var przedmiot = _context.Przedmiots.Include(c => c.Producent).Include(c => c.Kategoria).SingleOrDefault(c=>c.ID==id);

            if (przedmiot == null)
                return HttpNotFound();

            return View(przedmiot);
        }



        [Authorize(Roles= RoleName.CanManagePredmiot)]
        public ActionResult New()
        {

            if (User.IsInRole(RoleName.CanManagePredmiot))
            {
                var kategoria = _context.Kategorias.ToList();
                var producent = _context.Producents.ToList();

                var viewModel = new NewPrzedmiotViewModel
                {
                    Przedmiot = new Przedmiot(),
                    Kategoria = kategoria,
                    Producent = producent

                };
                return View(viewModel);

            }

            return View("ReadOnlyList");

        }

        [HttpPost]
        public ActionResult Save(Przedmiot przedmiot)
        {


            if (!ModelState.IsValid)
            {

                var viewModel = new NewPrzedmiotViewModel
                {
                    Przedmiot = przedmiot,
                    Kategoria = _context.Kategorias.ToList(),
                    Producent = _context.Producents.ToList()

                };


                return View("New", viewModel);
            }





            if (przedmiot.ID == 0)
            {
                _context.Przedmiots.Add(przedmiot);
            }
            else
            {
                var przedmiotDb = _context.Przedmiots.Single(c => c.ID == przedmiot.ID);

                przedmiotDb.Nazwa = przedmiot.Nazwa;
                przedmiotDb.Cena = przedmiot.Cena;
                przedmiotDb.Opis = przedmiot.Opis;
                przedmiotDb.Zdjecie = przedmiot.Zdjecie;
                przedmiotDb.ProducentId = przedmiot.ProducentId;
                przedmiotDb.KategoriaId = przedmiot.KategoriaId;
            }
            
            _context.SaveChanges();
            return RedirectToAction("Index","Przedmiots");
        }

        [Authorize(Roles = RoleName.CanManagePredmiot)]
        public ActionResult Edit(int id)
        {

            if (User.IsInRole(RoleName.CanManagePredmiot))
            {

                var przedmiot = _context.Przedmiots.SingleOrDefault(c => c.ID == id);


                if (przedmiot == null)
                {
                    return HttpNotFound();
                }

                var viewModel = new NewPrzedmiotViewModel()
                {
                    Przedmiot = przedmiot,
                    Producent = _context.Producents.ToList(),
                    Kategoria = _context.Kategorias.ToList()

                };
                return View("New", viewModel);

            }

            return View("ReadOnlyList");
        }
    }
}