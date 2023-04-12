using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using DAL.Abstractions.Interfaces;
using UI.ConsoleManagers;

namespace UI
{
    public class DependencyRegistration
    {
        public static IServiceProvider Register()
        {
            var services = new ServiceCollection();

            services.AddScoped<AppManager>();
            services.AddScoped<BookingConsoleManager>();
            services.AddScoped<ClassConsoleManager>();
            services.AddScoped<MemberConsoleManager>();
            services.AddScoped<SubscriptionConsoleManager>();
            services.AddScoped<TrainerConsoleManager>();
            services.AddScoped<UserConsoleManager>();
                        
            foreach (Type type in typeof(IRepository<>).Assembly.GetTypes()
                         .Where(t => t.IsClass && !t.IsAbstract && t.GetInterfaces()
                             .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRepository<>))))
            {
                Type interfaceType = type.GetInterfaces().First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRepository<>));
                services.AddScoped(interfaceType, type);
            }

            BLL.DependencyRegistration.RegisterServices(services);

            return services.BuildServiceProvider();
        }
    }
}