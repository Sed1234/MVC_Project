using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SaleCo.Models;

namespace SaleCo.Controllers
{
    public class MOVE_ORDERSController : Controller
    {
        private TestDBEntities db = new TestDBEntities();

        // GET: MOVE_ORDERS
        public ActionResult Index()
        {
            var mOVE_ORDERS = db.MOVE_ORDERS.Include(m => m.ITEMS).Include(m => m.STOCKS).Include(m => m.STORE);
            return View(mOVE_ORDERS.ToList());
        }

        // GET: MOVE_ORDERS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MOVE_ORDERS mOVE_ORDERS = db.MOVE_ORDERS.Find(id);
            if (mOVE_ORDERS == null)
            {
                return HttpNotFound();
            }
            return View(mOVE_ORDERS);
        }

        // GET: MOVE_ORDERS/Create
        public ActionResult Create()
        {
            ViewBag.ITEM_ID = new SelectList(db.ITEMS, "ITEM_ID", "ITEM_DESRIPTION");
            ViewBag.STOCK_ID = new SelectList(db.STOCKS, "STOCK_ID", "ADDRESS");
            ViewBag.STORE_ID = new SelectList(db.STORE, "STORE_ID", "STORE_NAME");
            return View();
        }

        // POST: MOVE_ORDERS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MOVE_ORDER_ID,MOVE_ORDER_NUMBER,ITEM_ID,PRICE,QUANTITY,STORE_ID,STOCK_ID")] MOVE_ORDERS mOVE_ORDERS)
        {
            if (ModelState.IsValid)
            {
                db.MOVE_ORDERS.Add(mOVE_ORDERS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ITEM_ID = new SelectList(db.ITEMS, "ITEM_ID", "ITEM_DESRIPTION", mOVE_ORDERS.ITEM_ID);
            ViewBag.STOCK_ID = new SelectList(db.STOCKS, "STOCK_ID", "ADDRESS", mOVE_ORDERS.STOCK_ID);
            ViewBag.STORE_ID = new SelectList(db.STORE, "STORE_ID", "STORE_NAME", mOVE_ORDERS.STORE_ID);
            return View(mOVE_ORDERS);
        }

        // GET: MOVE_ORDERS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MOVE_ORDERS mOVE_ORDERS = db.MOVE_ORDERS.Find(id);
            if (mOVE_ORDERS == null)
            {
                return HttpNotFound();
            }
            ViewBag.ITEM_ID = new SelectList(db.ITEMS, "ITEM_ID", "ITEM_DESRIPTION", mOVE_ORDERS.ITEM_ID);
            ViewBag.STOCK_ID = new SelectList(db.STOCKS, "STOCK_ID", "ADDRESS", mOVE_ORDERS.STOCK_ID);
            ViewBag.STORE_ID = new SelectList(db.STORE, "STORE_ID", "STORE_NAME", mOVE_ORDERS.STORE_ID);
            return View(mOVE_ORDERS);
        }

        // POST: MOVE_ORDERS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MOVE_ORDER_ID,MOVE_ORDER_NUMBER,ITEM_ID,PRICE,QUANTITY,STORE_ID,STOCK_ID")] MOVE_ORDERS mOVE_ORDERS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mOVE_ORDERS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ITEM_ID = new SelectList(db.ITEMS, "ITEM_ID", "ITEM_DESRIPTION", mOVE_ORDERS.ITEM_ID);
            ViewBag.STOCK_ID = new SelectList(db.STOCKS, "STOCK_ID", "ADDRESS", mOVE_ORDERS.STOCK_ID);
            ViewBag.STORE_ID = new SelectList(db.STORE, "STORE_ID", "STORE_NAME", mOVE_ORDERS.STORE_ID);
            return View(mOVE_ORDERS);
        }

        // GET: MOVE_ORDERS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MOVE_ORDERS mOVE_ORDERS = db.MOVE_ORDERS.Find(id);
            if (mOVE_ORDERS == null)
            {
                return HttpNotFound();
            }
            return View(mOVE_ORDERS);
        }

        // POST: MOVE_ORDERS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MOVE_ORDERS mOVE_ORDERS = db.MOVE_ORDERS.Find(id);
            db.MOVE_ORDERS.Remove(mOVE_ORDERS);
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
