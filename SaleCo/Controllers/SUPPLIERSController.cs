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
    public class SUPPLIERSController : Controller
    {
        private TestDBEntities db = new TestDBEntities();

        // GET: SUPPLIERS
        public ActionResult Index()
        {
            return View(db.SUPPLIERS.ToList());
        }

        // GET: SUPPLIERS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUPPLIERS sUPPLIERS = db.SUPPLIERS.Find(id);
            if (sUPPLIERS == null)
            {
                return HttpNotFound();
            }
            return View(sUPPLIERS);
        }

        // GET: SUPPLIERS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SUPPLIERS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SUPPLIER_ID,SUPPLIERS_NAME,ADDRESS,PHONE_NUMBER,isActive")] SUPPLIERS sUPPLIERS)
        {
            if (ModelState.IsValid)
            {
                db.SUPPLIERS.Add(sUPPLIERS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sUPPLIERS);
        }

        // GET: SUPPLIERS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUPPLIERS sUPPLIERS = db.SUPPLIERS.Find(id);
            if (sUPPLIERS == null)
            {
                return HttpNotFound();
            }
            return View(sUPPLIERS);
        }

        // POST: SUPPLIERS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SUPPLIER_ID,SUPPLIERS_NAME,ADDRESS,PHONE_NUMBER,isActive")] SUPPLIERS sUPPLIERS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sUPPLIERS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sUPPLIERS);
        }

        // GET: SUPPLIERS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUPPLIERS sUPPLIERS = db.SUPPLIERS.Find(id);
            if (sUPPLIERS == null)
            {
                return HttpNotFound();
            }
            return View(sUPPLIERS);
        }

        // POST: SUPPLIERS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SUPPLIERS sUPPLIERS = db.SUPPLIERS.Find(id);
            db.SUPPLIERS.Remove(sUPPLIERS);
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
