using shop.DAL.Interfaces;

using System;
using System.Collections.Generic;
using System.Text;

namespace shop.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IColorRepository Colors { get; }
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }
        IOrderRepository Orders { get; }
        int CommitAsync();
    }
}
