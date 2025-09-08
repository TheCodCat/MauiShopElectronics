using Microsoft.EntityFrameworkCore;
using Models.models;
using WebApi.Repositories.Interface;
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

		public async Task<bool> ChangeProductCount(ProductBascket productBascket)
		{
			var item = _context.Bascket.Include(x => x.Product.Categorie).Include(x => x.Product.Brand).FirstOrDefault(x => x.Id == productBascket.Id);

			if (item == null) return false;
			item.Count = productBascket.Count;

			_context.SaveChanges();

			return true;
		}

		public async Task<List<ProductBascket>> GetProducts(int userId)
		{
			return _context.Bascket.Include(x => x.Product.Brand).Include(x => x.Product.Categorie).Include(x => x.User).Where(x => x.UserId == userId).ToList();
		}

		public async Task<bool> RemoteBascket(ProductBascket productBascket)
		{
			var item = _context.Bascket.Include(x => x.Product.Categorie).Include(x => x.Product.Brand).FirstOrDefault(x => x.Id == productBascket.Id);

			if (item == null) return false;

			_context.Bascket.Remove(item);
			_context.SaveChanges();
			return true;
		}
	}
}
