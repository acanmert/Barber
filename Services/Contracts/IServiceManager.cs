using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IServiceManager
    {
        IUserService UserService { get; }
        IAppointmentService AppointmentService { get; }
        IReviewService ReviewService { get; }
        ISalonServiceService SalonServiceService { get; }
        IBarberService BarberService { get; }
        IAuthenticationService AuthenticationService{ get; }


    }
}
