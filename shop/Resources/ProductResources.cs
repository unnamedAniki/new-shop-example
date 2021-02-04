using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.Web.Resources
{
    public class ProductResources
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Notes { get; set; }
        public CategoryResources Category { get; set; }
        public ColorResources Color { get; set; }
    }
}
