
using shop.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace shop.DAL.Interfaces
{
    public interface IOrderRepository
    {
        IEnumerable<Order> Orders { get; }
        void SaveOrder(Order order);
    }
}
