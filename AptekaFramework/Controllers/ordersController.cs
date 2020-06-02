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
    public class ordersController : Controller
    {
        private AptekaContext db = new AptekaContext();

        // GET: orders
        public ActionResult Index()
        {
            var orders = db.orders.Include(o => o.customer).Include(o => o.delivery).Include(o => o.payment);
            return View(orders.ToList());
        }

        // GET: orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order order = db.orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: orders/Create
        public ActionResult Create()
        {
            ViewBag.customers_ID = new SelectList(db.customers, "ID_cust", "cust_name");
            ViewBag.delivery_ID = new SelectList(db.deliveries, "ID_delivery", "delivery_method");
            ViewBag.payment_ID = new SelectList(db.payments, "ID_payment", "payment_method");
            return View();
        }

        // POST: orders/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_order,customers_ID,order_time,payment_ID,delivery_ID")] order order)
        {
            if (ModelState.IsValid)
            {
                db.orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.customers_ID = new SelectList(db.customers, "ID_cust", "cust_name", order.customers_ID);
            ViewBag.delivery_ID = new SelectList(db.deliveries, "ID_delivery", "delivery_method", order.delivery_ID);
            ViewBag.payment_ID = new SelectList(db.payments, "ID_payment", "payment_method", order.payment_ID);
            return View(order);
        }

        // GET: orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order order = db.orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.customers_ID = new SelectList(db.customers, "ID_cust", "cust_name", order.customers_ID);
            ViewBag.delivery_ID = new SelectList(db.deliveries, "ID_delivery", "delivery_method", order.delivery_ID);
            ViewBag.payment_ID = new SelectList(db.payments, "ID_payment", "payment_method", order.payment_ID);
            return View(order);
        }

        // POST: orders/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_order,customers_ID,order_time,payment_ID,delivery_ID")] order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.customers_ID = new SelectList(db.customers, "ID_cust", "cust_name", order.customers_ID);
            ViewBag.delivery_ID = new SelectList(db.deliveries, "ID_delivery", "delivery_method", order.delivery_ID);
            ViewBag.payment_ID = new SelectList(db.payments, "ID_payment", "payment_method", order.payment_ID);
            return View(order);
        }

        // GET: orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order order = db.orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            order order = db.orders.Find(id);
            db.orders.Remove(order);
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
