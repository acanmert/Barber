using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IReviewRepository:IRepositoryBase<Review>
    {
        Task<IEnumerable<Review>> GetAllReviewsAsync(bool trackChanges);
        Task<IEnumerable<Review>> GetReviewsByUserIdAsync(int userId, bool trackChanges);
        Task<IEnumerable<Review>> GetReviewsByServiceIdAsync(int serviceId, bool trackChanges);
        Task<Review> GetReviewByIdAsync(int reviewId, bool trackChanges);
        Task CreateReviewAsync(Review review);
        void UpdateReview(Review review);
        void DeleteReview(Review review);
    }
}
