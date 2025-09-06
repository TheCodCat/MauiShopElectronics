using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.models;
using WebApi.Repositories;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BascketController : ControllerBase
	{
		private readonly IBascketRepository repository;

		public BascketController(IBascketRepository repository)
		{
			this.repository = repository;
		}


		[HttpPost("/addBasket")]
		public async Task<bool> AddBascketProduct([FromBody] ProductBascket productRecord)
		{
			var result = await repository.AddBascketProduct(productRecord);

			return result;
		}
	}
}
