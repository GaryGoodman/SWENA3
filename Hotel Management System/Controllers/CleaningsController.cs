using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hotel_Management_System.Models;

namespace Hotel_Management_System.Controllers
{
    public class CleaningsController : Controller
    {
        private CleaningDBContext db = new CleaningDBContext();

        // GET: Cleanings
        public ActionResult Index()
        {
            return View(db.Cleanings.ToList());
        }

        // GET: Cleanings/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cleaning cleaning = db.Cleanings.Find(id);
            if (cleaning == null)
            {
                return HttpNotFound();
            }
            return View(cleaning);
        }

        // GET: Cleanings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cleanings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Task_ID,Room_ID,Task_Time,Task_Date,Staff_ID")] Cleaning cleaning)
        {
            if (ModelState.IsValid)
            {
                db.Cleanings.Add(cleaning);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cleaning);
        }

        // GET: Cleanings/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cleaning cleaning = db.Cleanings.Find(id);
            if (cleaning == null)
            {
                return HttpNotFound();
            }
            return View(cleaning);
        }

        // POST: Cleanings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Task_ID,Room_ID,Task_Time,Task_Date,Staff_ID")] Cleaning cleaning)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cleaning).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cleaning);
        }

        // GET: Cleanings/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cleaning cleaning = db.Cleanings.Find(id);
            if (cleaning == null)
            {
                return HttpNotFound();
            }
            return View(cleaning);
        }

        // POST: Cleanings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Cleaning cleaning = db.Cleanings.Find(id);
            db.Cleanings.Remove(cleaning);
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
