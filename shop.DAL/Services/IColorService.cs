using shop.DAL.Models;

using System;
using System.Collections.Generic;
using System.Text;

namespace shop.DAL.Services
{
    public interface IColorService
    {
        IEnumerable<Color> GetColors(); 
    }
}
