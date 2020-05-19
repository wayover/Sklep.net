using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper.Internal;
using Microsoft.AspNet.Identity;
using WebApplication3.Dtos;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class KupionesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Kupiones
        public ActionResult Index()
        {
            return View(db.Kupiones.ToList());
        }

        // GET: Kupiones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kupione kupione = db.Kupiones.Find(id);
            if (kupione == null)
            {
                return HttpNotFound();
            }
            return View(kupione);
        }

        // GET: Kupiones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kupiones/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,Ulica,nrdomu,nrmieszkania,kodpocztowy,miasto")] Kupione kupione)
        {
            if (ModelState.IsValid)
            {
                
                db.Kupiones.Add(kupione);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kupione);
        }

        // GET: Kupiones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kupione kupione = db.Kupiones.Find(id);
            if (kupione == null)
            {
                return HttpNotFound();
            }
            return View(kupione);
        }

        // POST: Kupiones/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,Ulica,nrdomu,nrmieszkania,kodpocztowy,miasto")] Kupione kupione)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kupione).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kupione);
        }

        // GET: Kupiones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kupione kupione = db.Kupiones.Find(id);
            if (kupione == null)
            {
                return HttpNotFound();
            }
            return View(kupione);
        }

        // POST: Kupiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kupione kupione = db.Kupiones.Find(id);
            db.Kupiones.Remove(kupione);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }




       // public ActionResult Kup(string imie,string nazwisko,string ulica, string kod, string miasto,int nrdomu,int nrmieszkania)
        public ActionResult Kup(Kupione kupione)
        {

            string userID = User.Identity.GetUserId();

            kupione.UserId = userID;
            db.Kupiones.Add(kupione);
            db.SaveChanges();

            return Redirect("~/Tranzakcjes/Historia");
        }



        public ActionResult Dane()
        {

            return View();
        }
    }
}
