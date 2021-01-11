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
    public class EFColorRepository : Repository<Color>, IColorRepository
    {
        private ProductContext _colorContext
        {
            get { return _context; }
        }
        public EFColorRepository(ProductContext context) : base(context)
        {
           
        }
        public async Task<IEnumerable<Color>> GetColors() => await _colorContext.Color.AsNoTracking().ToListAsync();
    }
}
