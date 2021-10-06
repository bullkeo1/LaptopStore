using System;
using LaptopStore.DataAccess.Repository.IRepository;
using LaptopStore.Models;

namespace LaptopStore.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Category { get; }
        ICoverTypeRepository CoverType { get; }
        IProductRepository Product { get; }
        
        ISP_Call SP_Call { get; }
        void Save();

    }
}