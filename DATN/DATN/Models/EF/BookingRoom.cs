using System;
using System.Collections.Generic;
using System.Linq;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace DATN.Models.EF
{
    public class BookingRoom
    {
        public BookingRoom()
        {
            this.ImageRoom = new HashSet<ImageRoom>();
            this.OrderDetail = new HashSet<OrderDetail>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(150, ErrorMessage = "tên không được vượt quá 150 ký tự")]
        public string NameBookingRoom { get; set; }
        public int PeopleBookingRoom { get; set; }
        
        public decimal PriceBookingRoom { get; set; }
        
        public int DayBookingRoom { get; set; }
        public int BookingHotelId { get; set; }

        public int MonthBookingRoom { get; set; }
        
        public int YearBookingRoom { get; set; }
        
        public int DuringBookingRoom { get; set; }
        public int IsBookingRoom { get; set; }
        public int IsUserBookingRoom { get; set; }
        public virtual BookingHotel BookingHotel { get; set; }
        public ICollection<OrderDetail> OrderDetail { get; set; }
        public ICollection<ImageRoom> ImageRoom { get; set; }
    }
}