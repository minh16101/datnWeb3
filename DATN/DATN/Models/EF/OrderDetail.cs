using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DATN.Models.EF
{
    public class OrderDetail
    {
        
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int BookingRoomId { get; set; }
        public decimal Price { get; set; }
        public virtual Order Order { get; set; }
        public virtual BookingRoom BookingRoom { get; set; }
    }
}