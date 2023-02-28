using DATN.Models;
using DATN.Models.EF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DATN.Areas.Admin.Controllers
{
    public class ImageHotelController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/ImageHotel
        public ActionResult Index()
        {
            return View(db.ImageHotel.ToList());
        }
        public ActionResult Add()
        {
            ViewBag.BookingHotelId = new SelectList(db.BookingHotel.ToList(), "Id", "NameBookingHotel");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ImageHotel imageHotel)
        {
            var fileName = Path.GetFileNameWithoutExtension(imageHotel.ImageFile.FileName);
            var extension = Path.GetExtension(imageHotel.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            imageHotel.src = "~/Upload/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Upload/"), fileName);
            imageHotel.ImageFile.SaveAs(fileName);
            using (ApplicationDbContext dba = new ApplicationDbContext())
            {
                //imageHotel.BookingHotelId = 1;
                dba.ImageHotel.Add(imageHotel);
                dba.SaveChanges();
            }

            ModelState.Clear();
            return RedirectToAction("Index");
        }
    }
}