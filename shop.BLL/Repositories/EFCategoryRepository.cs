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
    public class EFCategoryRepository : Repository<Category>, ICategoryRepository
    {
        public EFCategoryRepository(ProductContext context) : base(context)
        {

        }
        public async Task<IEnumerable<Category>> GetCategories() => await _categoryContext.Category.ToListAsync();
        private ProductContext _categoryContext
        {
            get { return _context; }
        }
    }
}
