using Models.DTO;
using Models.models;

namespace WebApi.Repositories.Interface
{
    public interface ICategoriesRepository
    {
        public Task<bool> Create(CategorieDTO categorieDTO);
        public Task<bool> Remote(int id);
        public Task<List<Categorie>> GetCategories();

    }
}
