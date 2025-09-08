using Microsoft.EntityFrameworkCore;
using Models.models;
using WebApi.Repositories.Interface;
using WebApiDatabase;

namespace WebApi.Repositories
{
    public class ReviewsRepository : IReviewsRepository
    {
        private readonly ApiDatabaseContext _context;

        public ReviewsRepository(ApiDatabaseContext apiDatabaseContext)
        {
            _context = apiDatabaseContext;
        }

        public async Task<bool> AddReviews(Reviews reviews)
        {
            _context.Add(reviews);
            _context.SaveChanges();

            return true;
        }

        public async Task<List<Reviews>> GetReviews(int productId)
        {
            return _context.Reviews.Include(x =>x.User).Where(x => x.ProductId == productId).ToList();
        }
    }
}
