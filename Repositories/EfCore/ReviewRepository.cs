using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EfCore
{
    public class ReviewRepository : RepositoryBase<Review>, IReviewRepository
    {
        public ReviewRepository(RepositoryContext context) : base(context)
        {
        }

        public async Task<Review> GetReviewByIdAsync(int reviewId, bool trackChanges) =>

             await FindByCondition(r => r.Id == reviewId, trackChanges).FirstOrDefaultAsync();


        public async Task<IEnumerable<Review>> GetReviewsByServiceIdAsync(int serviceId, bool trackChanges) =>

            await FindByCondition(r => r.ServiceId == serviceId, trackChanges).ToListAsync();


        public async Task<IEnumerable<Review>> GetReviewsByUserIdAsync(int userId, bool trackChanges) =>

            await FindByCondition(r => r.UserId == userId, trackChanges).ToListAsync();

        public async Task CreateReviewAsync(Review review)
        {
            await CreateAsync(review);
            await SaveChangesAsync();
        }

        public void UpdateReview(Review review)
        {
            Update(review);
            SaveChanges();
        }

        public void DeleteReview(Review review)
        {
            Delete(review);
            SaveChanges();
        }

        public async Task<IEnumerable<Review>> GetAllReviewsAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(d => d.Date).ToListAsync();
        }

        public async Task<IEnumerable<Review>> GetReviewsByBarberIdAsync(int barberId, bool trackChanges)
        
          =>  await FindByCondition(r=>r.BarberId== barberId, trackChanges).ToListAsync();
        
    }
}
