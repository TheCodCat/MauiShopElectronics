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

        public AdminController(ICategoriesRepository categoriesRepository, IBrandRepository brandRepository )
        {
            this.categoriesRepository = categoriesRepository;
            this.brandRepository = brandRepository;
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
    }
}
