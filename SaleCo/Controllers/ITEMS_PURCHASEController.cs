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
    public class ITEMS_PURCHASEController : Controller
    {
        private TestDBEntities db = new TestDBEntities();

        // GET: ITEMS_PURCHASE
        public ActionResult Index()
        {
            var iTEMS_PURCHASE = db.ITEMS_PURCHASE.Include(i => i.ITEMS).Include(i => i.STOCKS).Include(i => i.SUPPLIERS);
            return View(iTEMS_PURCHASE.ToList());
        }

        // GET: ITEMS_PURCHASE/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ITEMS_PURCHASE iTEMS_PURCHASE = db.ITEMS_PURCHASE.Find(id);
            if (iTEMS_PURCHASE == null)
            {
                return HttpNotFound();
            }
            return View(iTEMS_PURCHASE);
        }

        // GET: ITEMS_PURCHASE/Create
        public ActionResult Create()
        {
            ViewBag.ITEM_ID = new SelectList(db.ITEMS, "ITEM_ID", "ITEM_DESRIPTION");
            ViewBag.STOCK_ID = new SelectList(db.STOCKS, "STOCK_ID", "ADDRESS");
            ViewBag.SUPPLIER_ID = new SelectList(db.SUPPLIERS, "SUPPLIER_ID", "SUPPLIERS_NAME");
            return View();
        }

        // POST: ITEMS_PURCHASE/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PURCHASE_ID,PURCHASE_NUMBER,ITEM_ID,PRICE,QUANTITY,PURCHASE_DATE,STOCK_ID,SUPPLIER_ID")] ITEMS_PURCHASE iTEMS_PURCHASE)
        {
            if (ModelState.IsValid)
            {
                db.ITEMS_PURCHASE.Add(iTEMS_PURCHASE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ITEM_ID = new SelectList(db.ITEMS, "ITEM_ID", "ITEM_DESRIPTION", iTEMS_PURCHASE.ITEM_ID);
            ViewBag.STOCK_ID = new SelectList(db.STOCKS, "STOCK_ID", "ADDRESS", iTEMS_PURCHASE.STOCK_ID);
            ViewBag.SUPPLIER_ID = new SelectList(db.SUPPLIERS, "SUPPLIER_ID", "SUPPLIERS_NAME", iTEMS_PURCHASE.SUPPLIER_ID);
            return View(iTEMS_PURCHASE);
        }

        // GET: ITEMS_PURCHASE/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ITEMS_PURCHASE iTEMS_PURCHASE = db.ITEMS_PURCHASE.Find(id);
            if (iTEMS_PURCHASE == null)
            {
                return HttpNotFound();
            }
            ViewBag.ITEM_ID = new SelectList(db.ITEMS, "ITEM_ID", "ITEM_DESRIPTION", iTEMS_PURCHASE.ITEM_ID);
            ViewBag.STOCK_ID = new SelectList(db.STOCKS, "STOCK_ID", "ADDRESS", iTEMS_PURCHASE.STOCK_ID);
            ViewBag.SUPPLIER_ID = new SelectList(db.SUPPLIERS, "SUPPLIER_ID", "SUPPLIERS_NAME", iTEMS_PURCHASE.SUPPLIER_ID);
            return View(iTEMS_PURCHASE);
        }

        // POST: ITEMS_PURCHASE/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PURCHASE_ID,PURCHASE_NUMBER,ITEM_ID,PRICE,QUANTITY,PURCHASE_DATE,STOCK_ID,SUPPLIER_ID")] ITEMS_PURCHASE iTEMS_PURCHASE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iTEMS_PURCHASE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ITEM_ID = new SelectList(db.ITEMS, "ITEM_ID", "ITEM_DESRIPTION", iTEMS_PURCHASE.ITEM_ID);
            ViewBag.STOCK_ID = new SelectList(db.STOCKS, "STOCK_ID", "ADDRESS", iTEMS_PURCHASE.STOCK_ID);
            ViewBag.SUPPLIER_ID = new SelectList(db.SUPPLIERS, "SUPPLIER_ID", "SUPPLIERS_NAME", iTEMS_PURCHASE.SUPPLIER_ID);
            return View(iTEMS_PURCHASE);
        }

        // GET: ITEMS_PURCHASE/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ITEMS_PURCHASE iTEMS_PURCHASE = db.ITEMS_PURCHASE.Find(id);
            if (iTEMS_PURCHASE == null)
            {
                return HttpNotFound();
            }
            return View(iTEMS_PURCHASE);
        }

        // POST: ITEMS_PURCHASE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ITEMS_PURCHASE iTEMS_PURCHASE = db.ITEMS_PURCHASE.Find(id);
            db.ITEMS_PURCHASE.Remove(iTEMS_PURCHASE);
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
