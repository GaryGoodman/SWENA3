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
    public class GuestDetailsController : Controller
    {
        private HMS_DatabaseEntities db = new HMS_DatabaseEntities();

        // GET: GuestDetails
        public ActionResult Index()
        {
            var guestDetails = db.GuestDetails.Include(g => g.Guest);
            return View(guestDetails.ToList());
        }

        // GET: GuestDetails/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GuestDetail guestDetail = db.GuestDetails.Find(id);
            if (guestDetail == null)
            {
                return HttpNotFound();
            }
            return View(guestDetail);
        }

        // GET: GuestDetails/Create
        public ActionResult Create()
        {
            ViewBag.guest_id = new SelectList(db.Guests, "guest_id", "guest_id");
            return View();
        }

        // POST: GuestDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "guest_id,checkIn_time,checkIn_date,checkOut_time,checkOut_date,remarks")] GuestDetail guestDetail)
        {
            if (ModelState.IsValid)
            {
                db.GuestDetails.Add(guestDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.guest_id = new SelectList(db.Guests, "guest_id", "first_name", guestDetail.guest_id);
            return View(guestDetail);
        }

        // GET: GuestDetails/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GuestDetail guestDetail = db.GuestDetails.Find(id);
            if (guestDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.guest_id = new SelectList(db.Guests, "guest_id", "first_name", guestDetail.guest_id);
            return View(guestDetail);
        }

        // POST: GuestDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "guest_id,checkIn_time,checkIn_date,checkOut_time,checkOut_date,remarks")] GuestDetail guestDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(guestDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.guest_id = new SelectList(db.Guests, "guest_id", "first_name", guestDetail.guest_id);
            return View(guestDetail);
        }

        // GET: GuestDetails/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GuestDetail guestDetail = db.GuestDetails.Find(id);
            if (guestDetail == null)
            {
                return HttpNotFound();
            }
            return View(guestDetail);
        }

        // POST: GuestDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            GuestDetail guestDetail = db.GuestDetails.Find(id);
            db.GuestDetails.Remove(guestDetail);
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
