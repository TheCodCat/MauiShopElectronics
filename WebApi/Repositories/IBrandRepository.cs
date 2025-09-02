using Models.DTO;
using Models.models;
using WebApiDatabase;

namespace WebApi.Repositories
{
    public interface IBrandRepository
    {
        public Task<bool> Create(BrandDTO brandDTO);
        public Task<bool> Remote(int id);
        public Task<List<Brand>> GetBrands();
    }
}
