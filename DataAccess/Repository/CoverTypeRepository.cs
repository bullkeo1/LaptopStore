using System.Linq;
using LaptopStore.DataAccess.Data;
using LaptopStore.DataAccess.Repository.IRepository;
using LaptopStore.Models;

namespace LaptopStore.DataAccess.Repository
{
    public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
        private readonly ApplicationDbContext _db;
        public CoverTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(CoverType coverType)
        {
            var objDb = _db.CoverTypes.FirstOrDefault(o => o.Id == coverType.Id);
            if (objDb != null)
            {
                objDb.Name = coverType.Name;
                _db.SaveChanges();
            }
        }
    }
}