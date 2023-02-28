using System;
using System.Collections.Generic;
using System.Linq;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace DATN.Models.EF
{
    public class Order
    { 
        public Order()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }
        [ForeignKey("InformationUser")]
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        public virtual InformationUser InformationUser { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}