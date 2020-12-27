using shop.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace shop.DAL.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
        IEnumerable<Product> AdminProducts { get; }
        IEnumerable<string> GetColor(string name);
        Product GetProduct(int id);
        bool DeleteProduct(int id);
        void Detach(Product product);
    }
}
