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
    public class EFColorRepository : IColorRepository
    {
        private ProductContext _context;
        public EFColorRepository(ProductContext context)
        {
            _context = context;
        }
        public IEnumerable<Color> Colors => _context.Color.AsNoTracking();
    }
}
