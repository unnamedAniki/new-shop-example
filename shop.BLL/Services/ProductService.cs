using shop.DAL;
using shop.DAL.Models;
using shop.DAL.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace shop.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork; 
        }
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _unitOfWork.Products.AllProducts();
        }
        public async Task<Product> GetProduct(int id)
        {
            return await _unitOfWork.Products.GetProduct(id);
        }
        public async Task<bool> DeleteProduct(Product product)
        {
            _unitOfWork.Products.Remove(product);
            if (await _unitOfWork.CommitAsync() > 0)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> EditProduct(Product product)
        {
            var temp = _unitOfWork.Products.Find(p => p.ProductId == product.ProductId);
            if (temp != null)
            {
                if(await _unitOfWork.CommitAsync() > 0)
                    return true;
            }
            return false;
        }
    }
}
