using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.Web.Resources
{
    public class EditProductResource
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Notes { get; set; }
        public int CategoryId { get; set; }
        public int ColorId { get; set; }
    }
}
