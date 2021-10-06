using LaptopStore;
using LaptopStore.DataAccess.Repository;
using LaptopStore.DataAccess.Repository.IRepository;
using LaptopStore.DataAccess.Data;
using LaptopStore.DataAccess.Repository.IRepository;
using LaptopStore.DataAccess.Repository.IRepository;

namespace LaptopStore.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            CoverType = new CoverTypeRepository(_db);
            Product = new ProductRepository(_db);
            SP_Call = new SP_Call(_db);
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public ICategoryRepository Category { get; }
        public ICoverTypeRepository CoverType { get; }
        public IProductRepository Product { get; }
        public ISP_Call SP_Call { get; }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}