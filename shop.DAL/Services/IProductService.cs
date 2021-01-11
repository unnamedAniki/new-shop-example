using shop.DAL.Models;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace shop.DAL.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(int id);
        Task<bool> DeleteProduct(Product product);
        Task<bool> EditProduct(Product product);
    }
}
