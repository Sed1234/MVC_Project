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
    public class ITEMSController : Controller
    {
        private TestDBEntities db = new TestDBEntities();

        // GET: ITEMS
        public ActionResult Index()
        {
            return View(db.ITEMS.ToList());
        }

        // GET: ITEMS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ITEMS iTEMS = db.ITEMS.Find(id);
            if (iTEMS == null)
            {
                return HttpNotFound();
            }
            return View(iTEMS);
        }

        // GET: ITEMS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ITEMS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ITEM_ID,ITEM_DESRIPTION,CATEGORY_ID,isActive")] ITEMS iTEMS)
        {
            if (ModelState.IsValid)
            {
                db.ITEMS.Add(iTEMS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(iTEMS);
        }

        // GET: ITEMS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ITEMS iTEMS = db.ITEMS.Find(id);
            if (iTEMS == null)
            {
                return HttpNotFound();
            }
            return View(iTEMS);
        }

        // POST: ITEMS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ITEM_ID,ITEM_DESRIPTION,CATEGORY_ID,isActive")] ITEMS iTEMS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iTEMS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(iTEMS);
        }

        // GET: ITEMS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ITEMS iTEMS = db.ITEMS.Find(id);
            if (iTEMS == null)
            {
                return HttpNotFound();
            }
            return View(iTEMS);
        }

        // POST: ITEMS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ITEMS iTEMS = db.ITEMS.Find(id);
            db.ITEMS.Remove(iTEMS);
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
