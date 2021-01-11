using shop.DAL.Models;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace shop.DAL.Interfaces
{
    public interface IColorRepository : IRepository<Color>
    {
        Task<IEnumerable<Color>> GetColors();
    }
}
