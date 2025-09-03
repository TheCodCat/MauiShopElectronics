using Models.DTO;
using Models.models;

namespace WebApi.Repositories
{
    public interface IProductRepository
    {
        public Task<bool> Create(ProductDTO productDTO);
        public Task<bool> Remote(int id);
        public Task<List<Product>> GetProducts();
        public Task<Product> GetProduct(int id);
        public Task<List<Product>> GetProducts(Categorie categorie);
    }
}
