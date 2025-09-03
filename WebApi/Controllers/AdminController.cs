using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Models.models;
using WebApi.Repositories;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ICategoriesRepository categoriesRepository;
        private readonly IBrandRepository brandRepository;
        private readonly IProductRepository productRepository;

        public AdminController(ICategoriesRepository categoriesRepository, IBrandRepository brandRepository, IProductRepository productRepository )
        {
            this.categoriesRepository = categoriesRepository;
            this.brandRepository = brandRepository;
            this.productRepository = productRepository;
        }

        [HttpPost("/addCategorie")]
        public async Task<bool> CreateCategorie([FromBody] CategorieDTO categorieDTO)
        {
            var result = await categoriesRepository.Create(categorieDTO);

            return result;
        }

        [HttpPost("/remoteCategorie/{id}")]
        public async Task<bool> RemoteCategorie(int id)
        {
            var result = await categoriesRepository.Remote(id);

            return result;
        }

        [HttpGet("/getCategories")]
        public async Task<List<Categorie>> GetCategories()
        {
            return await categoriesRepository.GetCategories();
        }


        [HttpGet("/getBrands")]
        public async Task<List<Brand>> GetBrands()
        {
            return await brandRepository.GetBrands();
        }

        [HttpPost("/createBrand")]
        public async Task<bool> CreateBrand([FromBody] BrandDTO brandDTO)
        {
            return await brandRepository.Create(brandDTO);
        }

        [HttpPost("/remoteBrands/{id:int}")]
        public async Task<bool> RemoteBrands(int id)
        {
            return await brandRepository.Remote(id);
        }

        [HttpGet("/getProducts/{categorie}")]
        public async Task<List<Product>> GetProducts(Categorie categorie)
        {
            return await productRepository.GetProducts(categorie);
        }
        [HttpGet("/getProducts")]
        public async Task<List<Product>> GetProducts()
        {
            return await productRepository.GetProducts();
        }
        [HttpGet("/getProduct/{id:int}")]
        public async Task<Product> GetProduct(int id)
        {
            return await productRepository.GetProduct(id);
        }

        [HttpPost("/addProduct")]
        public async Task<bool> CreateProduct([FromBody] ProductDTO productDTO)
        {
            return await productRepository.Create(productDTO);
        }
        [HttpPost("/remoteProduct/{id:int}")]
        public async Task<bool> RemoteProduct(int id)
        {
            return await productRepository.Remote(id);
        }
    }
}
