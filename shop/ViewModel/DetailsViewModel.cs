using shop.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.Web.ViewModel
{
    public class DetailsViewModel
    {
        public Product Product { get; set; }
        public string ReturnUrl { get; set; }
        public IEnumerable<string> AvailableColor { get; set; }
    }
}
