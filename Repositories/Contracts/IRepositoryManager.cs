using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        IAppointmentRepository Appointment { get; }
        IBarberRepository Barber { get; }
        IReviewRepository Review { get; }
        ISalonServiceRepository SalonService { get; }
        IUserRepository User { get; }
        Task SaveAsync();

    }
}
