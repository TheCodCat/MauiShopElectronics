using Models.DTO;
using Models.models;
using WebApi.Repositories.Interface;
using WebApiDatabase;

namespace WebApi.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly ApiDatabaseContext apiDatabaseContext;

        public CategoriesRepository(ApiDatabaseContext apiDatabaseContext)
        {
            this.apiDatabaseContext = apiDatabaseContext;
        }

        public async Task<bool> Create(CategorieDTO categorieDTO)
        {
            if (apiDatabaseContext.Categories.Contains(apiDatabaseContext.Categories.FirstOrDefault(x => x.Title == categorieDTO.CategorieTitle)))
                return false;

            var categorie = new Categorie(categorieDTO.CategorieTitle);

            apiDatabaseContext.Categories.Add(categorie);

            await apiDatabaseContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<Categorie>> GetCategories()
        {
            var result = apiDatabaseContext.Categories.ToList();
            return result;
        }

        public async Task<bool> Remote(int id)
        {
            if (!apiDatabaseContext.Categories.Contains(apiDatabaseContext.Categories.FirstOrDefault(x => x.Id == id)))
                return false;

            var categorie = apiDatabaseContext.Categories.FirstOrDefault(x => x.Id == id);

            apiDatabaseContext.Categories.Remove(categorie);
            await apiDatabaseContext.SaveChangesAsync();

            return true;
        }
    }
}
