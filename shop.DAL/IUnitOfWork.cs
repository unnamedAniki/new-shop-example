using shop.DAL.Interfaces;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace shop.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IColorRepository Colors { get; }
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }
        IOrderRepository Orders { get; }
        Task<int> CommitAsync();
    }
}
