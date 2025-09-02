using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Models.models;
using WebApi.Repositories;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesRepository categoriesRepository;

        public CategoriesController(ICategoriesRepository categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
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
    }
}
