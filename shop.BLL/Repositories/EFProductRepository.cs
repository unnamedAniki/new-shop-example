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
    public class EFProductRepository : Repository<Product>, IProductRepository
    {
        public EFProductRepository(ProductContext context) : base(context)
        {
            
        }
        public async Task<IEnumerable<Product>> AllProducts() => await _productContext.Product.Include(p => p.Category).Include(p => p.Color).AsNoTracking().ToListAsync();
        public async Task<IEnumerable<Product>> AllAdminProducts() => await _productContext.Product.Include(p => p.Category).Include(p => p.Color).ToListAsync();
        public async Task<Product> GetProduct(int id) => await _productContext.Product.SingleOrDefaultAsync(p => p.ProductId == id);
        public async Task<Product> GetProductWithColorAndCategoryInfo(int id) => await _productContext.Product.Include(p => p.Category).Include(p => p.Color).SingleOrDefaultAsync(p => p.ProductId == id);
        public async Task<IEnumerable<string>> GetColor(string name) => await _productContext.Product.Where(p => p.Name == name)
                                                                .Select(p => p.Color.Name).ToListAsync();
        private ProductContext _productContext
        {
            get { return _context; }
        }
    }
}
