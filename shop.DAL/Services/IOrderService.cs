using shop.DAL.Models;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace shop.DAL.Services
{
    public interface IOrderService
    {
        Task SaveOrder(Order order);
        Task<Order> GetOrder(int orderId);
        IEnumerable<Order> GetOrderByShipped(bool shipped);
    }
}
