using ExampleProject.DataAccess.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ExampleProject.DataAccess.IoC
{
    public static class DependencyInjector
    {
        public static IServiceCollection Inject(this IServiceCollection services)
        {
            return services
                .AddScoped(typeof(IRepository<>), typeof(Repository<>))
                .AddScoped<IDb, ExampleDbContext>();
        }
    }
}