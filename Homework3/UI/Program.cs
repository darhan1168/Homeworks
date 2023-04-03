using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using BLL.Abstractions.Interfaces;
using UI.ConsoleManagers;
using UI.Interfaces;

namespace UI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serviceProvider = DependencyRegistration.Register();
            
            var consoleManagerTypes = new List<Type>
            {
                typeof(BookingConsoleManager),
                typeof(ClassConsoleManager),
                typeof(MemberConsoleManager),
                typeof(SubscriptionConsoleManager),
                typeof(TrainerConsoleManager),
                typeof(UserConsoleManager)
            };

            foreach (var consoleManagerType in consoleManagerTypes)
            {
                var method = typeof(Program).GetMethod(nameof(CreateConsoleManagerInstance), BindingFlags.NonPublic | BindingFlags.Static);
                var genericMethod = method.MakeGenericMethod(consoleManagerType);
                dynamic consoleManagerInstance = genericMethod.Invoke(null, new object[] { serviceProvider });

                await consoleManagerInstance.PerformOperationsAsync();
            }
        }
        
        private static TConsoleManager CreateConsoleManagerInstance<TConsoleManager>(IServiceProvider serviceProvider)
        {
            var constructor = typeof(TConsoleManager).GetConstructors().First();
            var constructorParameters = constructor.GetParameters();
            var resolvedParameters = constructorParameters.Select(p => serviceProvider.GetService(p.ParameterType)).ToArray();

            return (TConsoleManager)Activator.CreateInstance(typeof(TConsoleManager), resolvedParameters);
        }
    }
}