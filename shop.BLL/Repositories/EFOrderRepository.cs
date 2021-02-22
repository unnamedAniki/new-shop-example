using Microsoft.EntityFrameworkCore;
using shop.DAL.Connect;
using shop.DAL.Interfaces;
using shop.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace shop.BLL.Repositories
{
    public class EFOrderRepository : Repository<Order>, IOrderRepository
    {
        
        public EFOrderRepository(ProductContext context) : base(context)
        {
            
        }
        public async Task<IEnumerable<Order>> AllOrders() => await _orderContext.Order
                                            .Include(p=>p.Lines)
                                            .ThenInclude(p=>p.Product)
                                            .AsNoTracking().ToListAsync();
        public async Task<IEnumerable<Order>> GetOrder(Expression<Func<Order, bool>> predicate) => 
            await _orderContext.Order.Include(p => p.Lines).ThenInclude(p => p.Product).Where(predicate).ToListAsync();
        public async Task<Order> GetOrderToShipped(int id) =>
            await _orderContext.Order.Include(p => p.Lines).ThenInclude(p => p.Product).Where(p => p.OrderId == id).FirstOrDefaultAsync();
        public void AttachRange(IEnumerable<Product> entities)
        {
            _orderContext.AttachRange(entities);
        }
        private ProductContext _orderContext
        {
            get { return _context; }
        }
    }
}
