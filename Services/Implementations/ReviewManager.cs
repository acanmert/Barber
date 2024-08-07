using AutoMapper;
using Entities.Dto;
using Entities.Exceptions;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class ReviewManager : IReviewService
    {
        protected readonly IRepositoryManager _repositoryManager;
        protected readonly IMapper _mapper;

        public ReviewManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Review>> GetAllReviewsAsync()
        {
            return await _repositoryManager.Review.GetAllReviewsAsync(trackChanges: false);
        }

        public async Task<Review> GetReviewByIdAsync(int reviewId)
        {
            return await _repositoryManager.Review.GetReviewByIdAsync(reviewId, trackChanges: false);
        }

        public async Task CreateReviewAsync(ReviewDtoForInsertion reviewDto)
        {
            var entity = _mapper.Map<Review>(reviewDto);
            await _repositoryManager.Review.CreateReviewAsync(entity);
        }

        public async Task UpdateReview (int id,ReviewDtoForInsertion reviewDto,bool trackChanges)
        {
            var entity= await GetOneByReviewIdAndChechExits(id, trackChanges: trackChanges);

            _mapper.Map( reviewDto, entity);
            _repositoryManager.Review.UpdateReview(entity);
        }

        public async Task DeleteReview(int id, bool trackChanges) {
            var entity =await GetOneByReviewIdAndChechExits(id, trackChanges);

            _repositoryManager.Review.DeleteReview(entity);
        }

        public async Task<Review> GetOneByReviewIdAndChechExits(int id, bool trackChanges)
        {
            var entity = await _repositoryManager.Review.GetReviewByIdAsync(id, trackChanges);

            if (entity is null)

                throw new ReviewNotFoundException(id);

            return entity;



        }
    }
}
