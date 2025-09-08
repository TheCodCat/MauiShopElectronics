using Models.models;

namespace WebApi.Repositories.Interface
{
    public interface IReviewsRepository
    {
        public Task<List<Reviews>> GetReviews(int productId);
        public Task<bool> AddReviews(Reviews reviews);
    }
}
