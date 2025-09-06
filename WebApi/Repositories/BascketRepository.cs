using Microsoft.EntityFrameworkCore;
using Models.models;
using WebApiDatabase;

namespace WebApi.Repositories
{
	public class BascketRepository : IBascketRepository
	{
		private readonly ApiDatabaseContext _context;

		public BascketRepository(ApiDatabaseContext apiDatabaseContext)
		{
			_context = apiDatabaseContext;
		}

		public async Task<bool> AddBascketProduct(ProductBascket productBascket)
		{
			User user = _context.Users.FirstOrDefault(x => x.Id == productBascket.User.Id);
			if(user == null) return false;

			Product product = _context.Products.FirstOrDefault(x => x.Id == productBascket.Product.Id);

			var toBascket = _context.Bascket.Include(x => x.User).FirstOrDefault(x => x.UserId == user.Id && x.Product.Id == productBascket.Product.Id);
			if(toBascket != null)
			{
				toBascket.Count++;
			}
			else
			{
				ProductBascket newBascket = new ProductBascket();
				newBascket.Product = product;
				newBascket.User = user;
				newBascket.Count = productBascket.Count;

				_context.Bascket.Add(newBascket);
			}
			_context.SaveChanges();

			return true;
		}
	}
}
