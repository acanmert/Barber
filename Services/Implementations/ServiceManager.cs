﻿using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class ServiceManager : IServiceManager
    {
        private readonly IUserService _userService;
        private readonly IAppointmentService _appointmentService;
        private readonly IReviewService _reviewService;
        private readonly ISalonServiceService _salonServiceService;
        private readonly IBarberService _barberService;
        private readonly IAuthenticationService _authenticationService;

        public ServiceManager(
            IUserService userService,
            IAppointmentService appointmentService,
            IReviewService reviewService,
            ISalonServiceService salonServiceService,
            IBarberService barberService,
            IAuthenticationService authenticatinService)
        {
            _userService = userService;
            _appointmentService = appointmentService;
            _reviewService = reviewService;
            _salonServiceService = salonServiceService;
            _barberService = barberService;
            _authenticationService = authenticatinService;
        }

        public IUserService UserService => _userService;
        public IAppointmentService AppointmentService => _appointmentService;
        public IReviewService ReviewService => _reviewService;
        public ISalonServiceService SalonServiceService => _salonServiceService;
        public IBarberService BarberService => _barberService;

        public IAuthenticationService AuthenticationService => _authenticationService;
    }
}

