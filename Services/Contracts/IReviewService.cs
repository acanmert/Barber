using Entities.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IReviewService
    {
        Task<IEnumerable<Review>> GetAllReviewsAsync();
        Task<Review> GetReviewByIdAsync(int reviewId);
        Task<Review> GetOneByReviewIdAndChechExits(int reviewId, bool trackChanges);
        Task<IEnumerable<Review>> GetReviewByUserIdAsync(int userId, bool trackChanges);
        Task<IEnumerable<Review>> GetReviewsByBarberIdAsync(int barberId, bool trackChanges);
        Task CreateReviewAsync(ReviewDtoForInsertion reviewDto);

        Task UpdateReview(int id,ReviewDtoForInsertion reviewDto,bool trackChanges);
        Task DeleteReview(int id,bool trackChanges);
    }
}
