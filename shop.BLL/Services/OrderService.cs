using shop.DAL;
using shop.DAL.Models;
using shop.DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task SaveOrder(Order order)
        {
            var temp = order.Lines.Where(p => p.Product.Color != null && p.Product.Category != null).ToList();
            foreach (var item in temp)
            {
                item.Product.Category = null;
                item.Product.Color = null;
            }
            order.Lines = temp;
            _unitOfWork.Orders.AttachRange(order.Lines.Select(p => p.Product));
            if (order.OrderId == 0)
                await _unitOfWork.Orders.AddAsync(order);
            await _unitOfWork.CommitAsync();
        }
        public async Task<Order> GetOrder(int orderId)
        {
            return await _unitOfWork.Orders.GetByIdAsync(orderId);
        }
        public IEnumerable<Order> GetOrderByShipped(bool shipped)
        {
            return _unitOfWork.Orders.AllOrders().Result.Where(p => p.Shipped == shipped);
        }
    }
}
