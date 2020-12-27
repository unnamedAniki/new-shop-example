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
    public class EFCategoryRepository : ICategoryRepository
    {
        private ProductContext _context;
        public EFCategoryRepository(ProductContext context)
        {
            _context = context;
        }
        public IEnumerable<Category> Categories => _context.Category.AsNoTracking();
    }
}
