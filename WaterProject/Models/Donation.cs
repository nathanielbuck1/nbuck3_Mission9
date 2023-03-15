using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WaterProject.Models
{
    public class Donation
    {
        [Key]
        [BindNever]
        public int DonationId { get; set; }

        [BindNever]
        public ICollection<BasketLineItem> Lines { get; set; }

        [Required(ErrorMessage ="Please Eneter Yo Name:")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Eneter Yo Addyresteraunt:")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }

        [Required(ErrorMessage = "Maneee why you think I know yo city locattion? Enter:")]
        public string City { get; set; }

        [Required(ErrorMessage = "Lquid? Solid? idk enter the state of yo residencey:")]
        public string State { get; set; }

        public string Zip { get; set; }
        [Required(ErrorMessage = "Please Eneter Yo Cuntry Foo:")]
        public string Country { get; set; }
    }
}
