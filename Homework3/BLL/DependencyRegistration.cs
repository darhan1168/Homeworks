using BLL.Abstractions.Interfaces;
using BLL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BLL
{
    public class DependencyRegistration
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITrainerService, TrainerService>();
            services.AddScoped<ISubscriptionService, SubscriptionService>();
            services.AddScoped<IMemberService, MemberService>();
            services.AddScoped<IClassService, ClassService>();
            services.AddScoped<IBookingService, BookingService>();
            
            DAL.DependencyRegistration.RegisterRepositories(services);
        }
    }
}