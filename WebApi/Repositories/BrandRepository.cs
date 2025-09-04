using Models.DTO;
using Models.models;
using WebApiDatabase;

namespace WebApi.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        public readonly ApiDatabaseContext apiDatabaseContext;

        public BrandRepository(ApiDatabaseContext apiDatabaseContext)
        {
            this.apiDatabaseContext = apiDatabaseContext;
        }

        public async Task<bool> Create(BrandDTO brandDTO)
        {
            var contains = apiDatabaseContext.Brands.FirstOrDefault(x => x.BrandName == brandDTO.BrandName);
            if (apiDatabaseContext.Brands.Contains(contains))
                return false;

            var brand = new Brand(brandDTO.BrandName);
            apiDatabaseContext.Brands.Add(brand);
            await apiDatabaseContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<Brand>> GetBrands()
        {
            return apiDatabaseContext.Brands.ToList();
        }

        public async Task<bool> Remote(int id)
        {
            var contains = apiDatabaseContext.Brands.FirstOrDefault(x => x.Id == id);
            if (!apiDatabaseContext.Brands.Contains(contains))
                return false;


            apiDatabaseContext.Brands.Remove(contains);
            await apiDatabaseContext.SaveChangesAsync();

            return true;
        }
    }
}
