using shop.DAL.Models;

using System;
using System.Collections.Generic;
using System.Text;

namespace shop.BLL.Interfaces.Services
{
    public interface IColorService
    {
        IEnumerable<Color> GetColors(); 
    }
}
