using Microsoft.EntityFrameworkCore;
using Models.DTO;
using Models.models;
using WebApiDatabase;

namespace WebApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public readonly ApiDatabaseContext apiDatabaseContext;

        public ProductRepository(ApiDatabaseContext apiDatabaseContext)
        {
            this.apiDatabaseContext = apiDatabaseContext;
        }

		public async Task<bool> Create(ProductDTO productDTO)
        {
            var brand = apiDatabaseContext.Brands.FirstOrDefault(x => x.Id == productDTO.Brand.Id);
            var categories = apiDatabaseContext.Categories.FirstOrDefault(x => x.Id == productDTO.Categorie.Id);
            var newProduct = new Product(productDTO.ProductName, productDTO.ProductDescription, brand, categories, productDTO.ProductRecordsBytes);
            apiDatabaseContext.Products.Add(newProduct);
            apiDatabaseContext.SaveChanges();

            return true;
        }

        public async Task<Product> GetProduct(int id)
        {
            return apiDatabaseContext.Products.Include(x => x.Brand).Include(x => x.Categorie).FirstOrDefault(x => x.Id == id);
        }

        public async Task<List<Product>> GetProducts()
        {
            return apiDatabaseContext.Products.Include(x => x.Brand).Include(x => x.Categorie).ToList();
        }

        public async Task<List<Product>> GetProducts(Categorie categorie)
        {
            var result = apiDatabaseContext.Products.Include(x => x.Categorie).Where(x => x.CategorieId == categorie.Id).ToList();
            return result;
        }

        public async Task<bool> Remote(int id)
        {
            var contains = apiDatabaseContext.Products.FirstOrDefault(x => x.Id == id);
            if (!apiDatabaseContext.Products.Contains(contains))
                return false;

            apiDatabaseContext.Products.Remove(contains);
            apiDatabaseContext.SaveChanges();

            return true;
        }
    }
}
