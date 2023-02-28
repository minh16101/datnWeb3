using DATN.Models;
using DATN.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DATN.Areas.Admin.Controllers
{
    public class BookingHotelController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/BookingHotel
        public ActionResult Index(int? page)
        {
            var items = db.BookingHotel.OrderByDescending(x => x.Id);
            return View(items);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(BookingHotel bookingHotel)
        {
            if(ModelState.IsValid)
            {
                db.BookingHotel.Add(bookingHotel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookingHotel);
        }
    }
}