using System.Linq;
using LaptopStore.DataAccess.Data;
using LaptopStore.DataAccess.Repository.IRepository;
using LaptopStore.DataAccess.Repository.IRepository;
using LaptopStore.Models;

namespace LaptopStore.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product product)
        {
            var obj = _db.Products.FirstOrDefault(o => o.Id == product.Id);
            if (obj != null)
            {
                {
                    if (obj.ImageUrl != null)
                    {
                        obj.ImageUrl = product.ImageUrl;
                    }
                    {
                        obj.Name = product.Name;
                        obj.Description = product.Description;
                        obj.Price = product.Price;
                        obj.Price50 = product.Price50;
                        obj.Price100 = product.Price100;
                        obj.CategoryId = product.CategoryId;
                        obj.CoverTypeId = product.CoverTypeId;
                    }
                }
            }
        }
       
        
    }
}