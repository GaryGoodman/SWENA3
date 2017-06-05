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
    public class BookingsController : Controller
    {
        private HMS_DatabaseEntities db = new HMS_DatabaseEntities();

        // GET: Bookings
        public ActionResult Index()
        {
            var bookings = db.Bookings.Include(b => b.Guest).Include(b => b.Room);
            return View(bookings.ToList());
        }

        // GET: Bookings/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Bookings/Create
        public ActionResult Create()
        {
            //Limit rooms available for booking by available ones only
            var rooms = from p in db.Rooms
                        where (p.room_status == "Available")
                        select p.room_id; //Get available rooms only

            ViewBag.guest_id = new SelectList(db.Guests, "guest_id", "guest_id");
            ViewBag.room_id = new SelectList(rooms);
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "book_id,room_id,people_pax,start_date,end_date,guest_id")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                //Set room to Occupied
                string status = "Occupied";
                Room r = db.Rooms.Find(booking.room_id);
                r.room_status = status;
                RoomsController RC = new RoomsController();
                RC.UpdateRoomStatus(r);

                db.Bookings.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Create", "GuestDetails");
            }

            ViewBag.guest_id = new SelectList(db.Guests, "guest_id", "first_name", booking.guest_id);
            ViewBag.room_id = new SelectList(db.Rooms, "room_id", "room_no", booking.room_id);
            return View(booking);
        }

        // GET: Bookings/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.guest_id = new SelectList(db.Guests, "guest_id", "first_name", booking.guest_id);
            ViewBag.room_id = new SelectList(db.Rooms, "room_id", "room_no", booking.room_id);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "book_id,room_id,people_pax,start_date,end_date,guest_id")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.guest_id = new SelectList(db.Guests, "guest_id", "first_name", booking.guest_id);
            ViewBag.room_id = new SelectList(db.Rooms, "room_id", "room_no", booking.room_id);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Booking booking = db.Bookings.Find(id);
            db.Bookings.Remove(booking);
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
