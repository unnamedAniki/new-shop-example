
using shop.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace shop.DAL.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<IEnumerable<Order>> AllOrders();
        Task<IEnumerable<Order>> GetOrder(Expression<Func<Order, bool>> predicate);
        Task<Order> GetOrderToShipped(int id);
        void AttachRange(IEnumerable<Product> entities);
    }
}
