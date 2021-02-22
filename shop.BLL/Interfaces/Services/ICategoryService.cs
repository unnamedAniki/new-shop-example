using shop.DAL.Models;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace shop.BLL.Interfaces.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories();

    }
}
