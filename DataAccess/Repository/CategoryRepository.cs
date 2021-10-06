using System.Linq;
using LaptopStore;
using LaptopStore.DataAccess.Repository.IRepository;
using LaptopStore.DataAccess.Data;
using LaptopStore.DataAccess.Repository.IRepository;
using LaptopStore.DataAccess.Repository.IRepository;
using LaptopStore.Models;

namespace LaptopStore.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Category category)
        {
            var objFromDb = _db.Categories.FirstOrDefault(o => o.Id == category.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = category.Name;
                _db.SaveChanges();
            }
        }
    }
}