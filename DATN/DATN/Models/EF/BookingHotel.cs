using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DATN.Models.EF
{
    public class BookingHotel
    {
        public BookingHotel()
        {
            this.BookingRooms = new HashSet<BookingRoom>();
            this.ImageHotel = new HashSet<ImageHotel>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(150, ErrorMessage = "tên không được vượt quá 150 ký tự")]
        public string NameBookingHotel { get; set; }
        public int LikeBookingHotel { get; set; }
        public string CityBookingHotel { get; set; }
        public string AddressBookingHotel { get; set; }
        public string NotiBookingHotel { get; set; }
        public string QuanBookingHotel { get; set; }
        public ICollection<BookingRoom> BookingRooms { get; set; }
        public ICollection<ImageHotel> ImageHotel { get; set; }
    }
}