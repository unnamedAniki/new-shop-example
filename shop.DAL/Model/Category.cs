using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.DAL.Models
{
    public partial class Category
    {
        public Category()
        {
            Product = new HashSet<Product>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
