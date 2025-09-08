using Models.models;

namespace WebApi.Repositories.Interface
{
	public interface IBascketRepository
	{

		public Task<bool> AddBascketProduct(ProductBascket productBascket);
		public Task<List<ProductBascket>> GetProducts(int userId);
		public Task<bool> ChangeProductCount(ProductBascket productBascket);
		public Task<bool> RemoteBascket(ProductBascket productBascket);
	}
}
