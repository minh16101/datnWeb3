using DATN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DATN.Controllers
{
    public class MenuController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MenuBookingHotel()
        {
            var items = db.BookingHotel.ToList();
            return PartialView("_MenuBookingHotel", items);
        }
        public ActionResult MenuArrivalBookingHotel()
        {
            var items = db.BookingHotel.ToList();
            return PartialView("_MenuArrivalBookingHotel", items);
        }
    }
}