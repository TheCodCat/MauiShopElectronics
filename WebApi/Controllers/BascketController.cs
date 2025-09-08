using Microsoft.AspNetCore.Mvc;
using Models.models;
using WebApi.Repositories.Interface;

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

		[HttpGet("/getBascketProducts/{userId:int}")]
		public async Task<List<ProductBascket>> GetUserBascket(int userId)
		{
			var result = await repository.GetProducts(userId);

			return result;
		}

		[HttpPut("/changeCountProduct")]
		public async Task<bool> ChangeCountBascketProduct([FromBody] ProductBascket productBascket)
		{
			var result = await repository.ChangeProductCount(productBascket);

			return result;
		}

		[HttpDelete("/remoteBascket")]
		public async Task<bool> RemoteBascketProduct([FromBody] ProductBascket productBascket)
		{
			var result = await repository.RemoteBascket(productBascket);

			return result;
		}
	}
}
