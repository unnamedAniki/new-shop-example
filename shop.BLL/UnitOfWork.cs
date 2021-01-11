using shop.DAL.Connect;
using shop.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using shop.BLL.Repositories;
using shop.DAL.Interfaces;
using System.Threading.Tasks;

namespace shop.BLL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProductContext _context;
        private EFProductRepository _productRepository;
        private EFCategoryRepository _categoryRepository;
        private EFColorRepository _colorRepository;
        private EFOrderRepository _orderRepository;
        public UnitOfWork(ProductContext context)
        {
            _context = context;
        }
        public IProductRepository Products => _productRepository = _productRepository ?? new EFProductRepository(_context);
        public ICategoryRepository Categories => _categoryRepository = _categoryRepository ?? new EFCategoryRepository(_context);
        public IColorRepository Colors => _colorRepository = _colorRepository ?? new EFColorRepository(_context);
        public IOrderRepository Orders => _orderRepository = _orderRepository ?? new EFOrderRepository(_context);
        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
