using Microsoft.EntityFrameworkCore;
using shop.DAL.Connect;
using shop.DAL.Interfaces;
using shop.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.BLL.Repositories
{
    public class EFOrderRepository : IOrderRepository
    {
        private ProductContext _context;
        public EFOrderRepository(ProductContext context)
        {
            _context = context;
        }
        public IEnumerable<Order> Orders => _context.Order
                                            .Include(p=>p.Lines)
                                            .ThenInclude(p=>p.Product)
                                            .AsNoTracking();
        public void SaveOrder(Order order)
        {
            DeleteEntities(order);
            _context.AttachRange(order.Lines.Select(p => p.Product));
            if (order.OrderId == 0)
                _context.Order.Add(order);
            else
            {
                _context.Order.Update(order);
            } 
            _context.SaveChanges();
        }
        void DeleteEntities(Order order)
        { 
            var test = order.Lines.ToList();
            foreach (var item in order.Lines)
            {
                item.Product.Color = null;
                item.Product.Category = null;
                test.Add(item);
            }
            order.Lines = test;
        }
    }
}
