using DATN.Models;
using DATN.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DATN.Controllers
{
    public class ProductsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Products
        public ActionResult Index()
        {
            var items = db.BookingRoom.ToList();
            List<BookingRoom> tempItem = new List<BookingRoom>();
            foreach (var i in items)
            {
                i.ImageRoom.Add(db.ImageRoom.FirstOrDefault(x => x.BookingRoomId == i.Id));
                tempItem.Add(i);
            }
            return View(tempItem);
        }
        public ActionResult ItemDetail(int id)
        {
            var item = db.BookingRoom.Find(id);
            BookingRoom tempItem = new BookingRoom();
            var listImg = db.ImageRoom.Where(x => x.BookingRoomId == item.Id).ToList();
            tempItem = item;
            foreach (var i in listImg)
            {
                tempItem.ImageRoom.Add(i);
            }
            return View(tempItem);
        }
        public ActionResult ItemPartialView()
        {
            //
            var items = db.BookingHotel.OrderByDescending(x => x.Id).Take(8).ToList();
            foreach (var i in items)
            {
                var itemImages = db.ImageHotel.Where(x => x.BookingHotelId == i.Id).FirstOrDefault();
                i.ImageHotel.Add(itemImages);
            }
            foreach (var i in items)
            {
                BookingRoom itemRooms = db.BookingRoom.Where(x => x.BookingHotelId == i.Id).FirstOrDefault();
                //ImageRoom itemImages = db.ImageRoom.Where(x => x.BookingRoomId == itemRooms.Id).FirstOrDefault();
                //itemRooms.ImageRoom.Add(itemImages);  
                i.BookingRooms.Add(itemRooms);
            }
            return PartialView(items);
        }
    }
}