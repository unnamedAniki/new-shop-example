using shop.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace shop.DAL.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> AllProducts();
        Task<IEnumerable<Product>> AllAdminProducts();
        Task<Product> GetProduct(int id);
        Task<Product> GetProductWithColorAndCategoryInfo(int id);
        Task<IEnumerable<string>> GetColor(string name);
    }
}
