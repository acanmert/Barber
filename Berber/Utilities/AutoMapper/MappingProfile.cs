using AutoMapper;
using Entities.Dto;
using Entities.Models;

namespace Berber.Utilities.AutoMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<UserForRegistrationDto, User>();
            CreateMap<BarberDtoForInsertion, Barber>();
            CreateMap<SalonServiceDtoForInsertion, SalonService>();
            CreateMap<ReviewDtoForInsertion,Review>();
            CreateMap<AppointmentDtoForInsertion,Appointment>();
        }
    }
}
