using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DATN.Models.EF
{
    public class InformationUser
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string FirstNameInformationUser { get; set; }
        [Required]
        [StringLength(150)]
        public string LastNameInformationUser { get; set; }
        [Required]
        [StringLength(15)]
        public string NumberInformationUser { get; set; }
        [Required]
        [StringLength(200)]
        public string AvatarInformationUser { get; set; }
        [Required]
        [StringLength(200)]
        public string AddressInformationUser { get; set; }
        [Required]
        [StringLength(100)]
        public string EmailInformationUser { get; set; }
        [Required]
        public int IsBookingInformationUser { get; set; }
        public virtual Order Order { get; set; }
    }
}