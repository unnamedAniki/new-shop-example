using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shop.DAL.Models
{
    public class Order
    {
        [BindNever]
        public int OrderId { get; set; }
        [BindNever]
        public ICollection<CartLine> Lines { get; set; }
        [BindNever]
        public bool Shipped { get; set; }
        [Required(ErrorMessage ="Please enter your name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter your adress")]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        [Required(ErrorMessage = "Please enter your city")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter your region")]
        public string Region { get; set; }
        public int Zip { get; set; }
        [Required(ErrorMessage = "Please enter your country")]
        public string Country { get; set; }
    }
}
