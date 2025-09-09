using Microsoft.EntityFrameworkCore;
using Models.DTO;
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

        public async Task<bool> AddReviews(ReviewsDTO reviews)
        {
            try
            {
                Reviews newreviews = new Reviews();

                newreviews.User = _context.Users.FirstOrDefault(x => x.Id == reviews.UserId);
                newreviews.Product = _context.Products.FirstOrDefault(x => x.Id == reviews.ProductId);
                newreviews.Description = reviews.Description;
                newreviews.Evaluation = reviews.Evaluation;

                _context.Reviews.Add(newreviews);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<Reviews>> GetReviews(int productId)
        {
            return _context.Reviews.Include(x =>x.User).Where(x => x.ProductId == productId).ToList();
        }
    }
}
