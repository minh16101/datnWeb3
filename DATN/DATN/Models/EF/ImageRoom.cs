using System;
using System.Collections.Generic;
using System.Linq;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace DATN.Models.EF
{
    public class ImageRoom
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int BookingRoomId { get; set; }
        public string src { get; set; }
        public virtual BookingRoom BookingRoom { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

    }
}