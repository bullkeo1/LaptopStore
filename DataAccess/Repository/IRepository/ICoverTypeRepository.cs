using LaptopStore.DataAccess.Repository.IRepository;
using LaptopStore.Models;

namespace LaptopStore.DataAccess.Repository.IRepository
{
    public interface ICoverTypeRepository : IRepository<CoverType>
    {
        void Update(CoverType coverType);
    }
}