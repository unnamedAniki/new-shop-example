using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shop.DAL.Models
{
    public class Color
    {
        public Color()
        {
            Product = new HashSet<Product>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
