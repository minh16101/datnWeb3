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
    public class ImageRoomController : Controller
    {
        // GET: Admin/ImageRoom
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View(db.ImageRoom.ToList());
        }
        public ActionResult Add()
        {
            ViewBag.BookingRoomId = new SelectList(db.BookingRoom.ToList(), "Id", "NameBookingRoom");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ImageRoom imageRoom)
        {
            var fileName = Path.GetFileNameWithoutExtension(imageRoom.ImageFile.FileName);
            var extension = Path.GetExtension(imageRoom.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            imageRoom.src = "~/Upload/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Upload/"), fileName);
            imageRoom.ImageFile.SaveAs(fileName);
            using (ApplicationDbContext dba = new ApplicationDbContext())
            {
                //imageRoom.BookingRoomId = 2;
                dba.ImageRoom.Add(imageRoom);
                dba.SaveChanges();
            }    
          
            ModelState.Clear();
            return RedirectToAction("Index");
        }
    }
}