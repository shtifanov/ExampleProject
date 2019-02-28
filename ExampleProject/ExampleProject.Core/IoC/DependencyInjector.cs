using ExampleProject.Core.Person;
using ExampleProject.Core.Person.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ExampleProject.Core.IoC
{
    public static class DependencyInjector
    {
        public static IServiceCollection Inject(this IServiceCollection services)
        {
            return services
                .AddScoped<IPersonManagement, PersonManagement>();
        }
    }
}