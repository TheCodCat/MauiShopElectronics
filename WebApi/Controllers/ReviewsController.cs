using Microsoft.AspNetCore.Mvc;
using Models.models;
using WebApi.Repositories.Interface;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewsRepository _reviewRepository;

        public ReviewsController(IReviewsRepository reviewsRepository)
        {
            _reviewRepository = reviewsRepository;
        }

        [HttpGet("/getReviews/{productId:int}")]
        public async Task<List<Reviews>> GetReviews(int productId)
        {
            return await _reviewRepository.GetReviews(productId);
        }

        [HttpPost("/addReviews")]
        public async Task<bool> AddReviews([FromBody] Reviews reviews)
        {
            return await _reviewRepository.AddReviews(reviews);
        }
    }
}
