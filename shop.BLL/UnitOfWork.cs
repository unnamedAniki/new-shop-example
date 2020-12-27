using shop.DAL.Connect;
using shop.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using shop.BLL.Repositories;
using shop.DAL.Interfaces;

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
        public int CommitAsync()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
