using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using BLL.Abstractions.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using UI.ConsoleManagers;
using UI.Interfaces;

namespace UI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serviceProvider = DependencyRegistration.Register();

            using (var scope = serviceProvider.CreateScope())
            {
                var appManager = scope.ServiceProvider.GetService<AppManager>();
                appManager.StartAsync().Wait();
            }
        }   
    }
}