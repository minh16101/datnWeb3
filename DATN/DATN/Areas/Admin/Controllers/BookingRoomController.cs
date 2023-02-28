using DATN.Models;
using DATN.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DATN.Areas.Admin.Controllers
{
    public class BookingRoomController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/BookingRoom
        public ActionResult Index()
        {
            var items = db.BookingRoom.OrderByDescending(x => x.Id);
            return View(items);
        }
        public ActionResult Add()
        {
            ViewBag.BookingHotelId = new SelectList(db.BookingHotel.ToList(), "Id", "NameBookingHotel");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(BookingRoom bookingRoom)
        { 
            if(ModelState.IsValid)
            {
                db.BookingRoom.Add(bookingRoom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }    
            return View();
        }
    }
}