using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EfCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private IAppointmentRepository _appointmentRepository;
        private IBarberRepository _barberRepository;
        private IReviewRepository _reviewRepository;
        private ISalonServiceRepository _salonServiceRepository;
        private IUserRepository _userRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IAppointmentRepository Appointment
        {
            get
            {
                return _appointmentRepository ??= new AppointmentRepository(_repositoryContext);
            }
        }

        public IBarberRepository Barber
        {
            get
            {
                return _barberRepository ??= new BarberRepository(_repositoryContext);
            }
        }

        public IReviewRepository Review
        {
            get
            {
                return _reviewRepository ??= new ReviewRepository(_repositoryContext);
            }
        }

        public ISalonServiceRepository SalonService
        {
            get
            {
                return _salonServiceRepository ??= new SalonServiceRepository(_repositoryContext);
            }
        }

        public IUserRepository User
        {
            get
            {
                return _userRepository ??= new UserRepository(_repositoryContext);
            }
        }

        public async Task SaveAsync()
        {
            await _repositoryContext.SaveChangesAsync();
        }
    }
}
