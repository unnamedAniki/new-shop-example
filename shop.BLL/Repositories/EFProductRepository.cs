using Microsoft.EntityFrameworkCore;
using shop.DAL.Connect;
using shop.DAL.Interfaces;
using shop.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.BLL.Repositories
{
    public class EFProductRepository : IProductRepository
    {
        private ProductContext _context;
        public EFProductRepository(ProductContext context)
        {
            _context = context;
        }
        public IEnumerable<Product> Products => _context.Product.Include(p => p.Category).Include(p => p.Color).AsNoTracking();
        public IEnumerable<Product> AdminProducts => _context.Product.Include(p => p.Category).Include(p => p.Color);
        public Product GetProduct(int id) => Products.FirstOrDefault(p => p.ProductId == id);
        public IEnumerable<string> GetColor(string name) => Products.Where(p => p.Name == name)
                                                                .Select(p => p.Color.Name);
        public void Detach(Product product)
        {
            _context.Entry(product).State = EntityState.Detached;
            _context.Entry(product.Color).State = EntityState.Detached;
            _context.Entry(product.Category).State = EntityState.Detached;
        }
        public bool DeleteProduct(int id)
        {
            var product = Products.FirstOrDefault(p => p.ProductId == id);
            if (product != null)
            {
                _context.Product.Remove(product);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
