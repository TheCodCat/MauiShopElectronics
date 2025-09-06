using Models.models;

namespace WebApi.Repositories
{
	public interface IBascketRepository
	{

		public Task<bool> AddBascketProduct(ProductBascket productBascket);
	}
}
