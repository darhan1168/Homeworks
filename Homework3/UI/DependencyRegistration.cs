using Microsoft.Extensions.DependencyInjection;
using System;

namespace UI
{
    public class DependencyRegistration
    {
        public static IServiceProvider Register()
        {
            var services = new ServiceCollection();

            BLL.DependencyRegistration.RegisterServices(services);

            return services.BuildServiceProvider();
        }
    }
}