using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class TranzakcjesController : Controller
    {


        private ApplicationDbContext _context;

        public TranzakcjesController()
        {
            _context = new ApplicationDbContext();
        }







   //     [HttpPost]
        public ActionResult Buy(int prodId, string prodnaz, string prodcen)
        {

            string userID = User.Identity.GetUserId();
            string date = DateTime.Today.ToString("yyyy-MM-dd");

            Tranzakcje tranzakcje = new Tranzakcje();
            tranzakcje.PrzedmiotId = prodId;
            tranzakcje.UserId = userID;
            tranzakcje.Date = date;
            tranzakcje.Nazwa = prodnaz;
            tranzakcje.Cena = prodcen;

            _context.Tranzakcjes.Add(tranzakcje);
            _context.SaveChanges();

            return Redirect("~/Przedmiots/Index");
        }







        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            Tranzakcje tranzakcje = _context.Tranzakcjes.Find(id);
            if (tranzakcje == null)
            {
                return HttpNotFound();
            }
            return View(tranzakcje);
        }



        
        public ActionResult Historia()
        {
            string userId = User.Identity.GetUserId();
            var historia = _context.Tranzakcjes.Where(c =>c.UserId  == userId).ToList();
            return View(historia);


        }


     //   [HttpPost, ActionName("Usuń")]
      //  [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Tranzakcje tranzakcje = _context.Tranzakcjes.Find(id);
            _context.Tranzakcjes.Remove(tranzakcje);
            _context.SaveChanges();
            return RedirectToAction("Historia");
        }




    }
}