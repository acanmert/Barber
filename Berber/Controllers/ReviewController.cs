using Entities.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Berber.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IServiceManager _services;

        public ReviewController(IServiceManager services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReviews()
        {
            var reviews = await _services.ReviewService.GetAllReviewsAsync();
            return Ok(reviews);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetReviewById([FromRoute] int id)
        {
            var review = await _services.ReviewService.GetReviewByIdAsync(id);

            return Ok(review);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview([FromBody] ReviewDtoForInsertion reviewDto)
        {
             await _services.ReviewService.CreateReviewAsync(reviewDto);
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateReview([FromRoute] int id, [FromBody] ReviewDtoForInsertion reviewDto)
        {
            await _services.ReviewService.UpdateReview(id, reviewDto, false);
            return Ok(reviewDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteReview([FromRoute] int id)
        {
            await _services.ReviewService.DeleteReview(id, false);
            return NoContent(); // 204 No Content döner, çünkü başarıyla silindiğinde içeriğe gerek yok.
        }

        [HttpGet("user/{userId:int}")]
        public async Task<IActionResult> GetReviewByUserId([FromRoute]int userId)
        {
            var reviews = await _services.ReviewService.GetReviewByUserIdAsync(userId, false);
            return Ok(reviews);
        }
        [HttpGet("barber/{barberId:int}")]
        public async Task<IActionResult> GetReviewByBarberId([FromRoute]int barberId)
        {
            var reviews = await _services.ReviewService.GetReviewsByBarberIdAsync(barberId, false);
            return Ok(reviews);
        }
    }
}
