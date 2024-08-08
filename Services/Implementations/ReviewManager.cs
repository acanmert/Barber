using AutoMapper;
using Entities.Dto;
using Entities.Exceptions;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

public class ReviewManager : IReviewService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;
    private readonly IUserService _userService;
    private readonly IBarberService _barberService;

    public ReviewManager(IRepositoryManager repositoryManager, IMapper mapper, IUserService userService, IBarberService barberService)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
        _userService = userService;
        _barberService = barberService;
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

    public async Task UpdateReview(int id, ReviewDtoForInsertion reviewDto, bool trackChanges)
    {
        var entity = await GetOneByReviewIdAndChechExits(id, trackChanges);
        _mapper.Map(reviewDto, entity);
        _repositoryManager.Review.UpdateReview(entity);
    }

    public async Task DeleteReview(int id, bool trackChanges)
    {
        var entity = await GetOneByReviewIdAndChechExits(id, trackChanges);
        _repositoryManager.Review.DeleteReview(entity);
    }

    public async Task<Review> GetOneByReviewIdAndChechExits(int reviewId, bool trackChanges)
    {
        var entity = await _repositoryManager.Review.GetReviewByIdAsync(reviewId, trackChanges);
        if (entity is null)
            throw new ReviewNotFoundException(reviewId);
        return entity;
    }

    public async Task<IEnumerable<Review>> GetReviewByUserIdAsync(int userId, bool trackChanges)
    {
        var user = await _userService.GetOneUserByIdAndChechExits(userId, trackChanges);
        var reviews = await _repositoryManager.Review.GetReviewsByUserIdAsync(userId, trackChanges);
        if (reviews is null)
        {
            throw new NotFoundObject("Empty");
        }
        return reviews;

    }

    public async Task<IEnumerable<Review>> GetReviewsByBarberIdAsync(int barberId, bool trackChanges)
    {
        var barber = await _barberService.GetBarberByIdAsync(barberId);
        var reviews = await _repositoryManager.Review.GetReviewsByBarberIdAsync(barberId, trackChanges);
        if (reviews is null)
        {
            throw new NotFoundObject("Empty");
        }
        return reviews;
         
    }
}
