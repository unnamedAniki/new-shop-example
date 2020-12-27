using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shop.DAL.Models
{
    public partial class Product
    { 
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public decimal Price { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public int ColorID { get; set; } = 1;
        public virtual Color Color { get; set; }

    }
}
