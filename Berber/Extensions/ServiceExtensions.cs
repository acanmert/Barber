using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EfCore;
using Services.Contracts;
using Services.Implementations;

namespace Berber.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
        }
        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
           services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();

        public static void ConfigureServices(this IServiceCollection services)
        {
            // Servisleri ekleyin
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IAppointmentService, AppointmentManager>();
            services.AddScoped<IReviewService, ReviewManager>();
            services.AddScoped<ISalonServiceService, SalonServiceManager>();
            services.AddScoped<IBarberService, BarberManager>();
            services.AddScoped<IAuthenticationService, AuthenticationManager>();


        }
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentity<User, IdentityRole>(opts =>
            {
                opts.Password.RequireDigit = true;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequiredLength = 6;

                opts.User.RequireUniqueEmail = true;

            })
                .AddEntityFrameworkStores<RepositoryContext>()
                .AddDefaultTokenProviders();

        }
    }
}
