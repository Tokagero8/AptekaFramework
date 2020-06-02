using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AptekaFramework.Models;

namespace AptekaFramework.Controllers
{
    public class order_medController : Controller
    {
        private AptekaContext db = new AptekaContext();

        // GET: order_med
        public ActionResult Index()
        {
            var order_med = db.order_med.Include(o => o.medicine);
            return View(order_med.ToList());
        }

        // GET: order_med/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order_med order_med = db.order_med.Find(id);
            if (order_med == null)
            {
                return HttpNotFound();
            }
            return View(order_med);
        }

        // GET: order_med/Create
        public ActionResult Create()
        {
            ViewBag.medicines_ID = new SelectList(db.medicines, "ID_med", "med_name");
            return View();
        }

        // POST: order_med/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_order_med,medicines_ID,quantity")] order_med order_med)
        {
            if (ModelState.IsValid)
            {
                db.order_med.Add(order_med);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.medicines_ID = new SelectList(db.medicines, "ID_med", "med_name", order_med.medicines_ID);
            return View(order_med);
        }

        // GET: order_med/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order_med order_med = db.order_med.Find(id);
            if (order_med == null)
            {
                return HttpNotFound();
            }
            ViewBag.medicines_ID = new SelectList(db.medicines, "ID_med", "med_name", order_med.medicines_ID);
            return View(order_med);
        }

        // POST: order_med/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_order_med,medicines_ID,quantity")] order_med order_med)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order_med).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.medicines_ID = new SelectList(db.medicines, "ID_med", "med_name", order_med.medicines_ID);
            return View(order_med);
        }

        // GET: order_med/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order_med order_med = db.order_med.Find(id);
            if (order_med == null)
            {
                return HttpNotFound();
            }
            return View(order_med);
        }

        // POST: order_med/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            order_med order_med = db.order_med.Find(id);
            db.order_med.Remove(order_med);
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
    }
}
