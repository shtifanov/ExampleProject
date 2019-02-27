using AutoMapper;
using ExampleProject.Api.Infrastructure.Mappings.Configurations;

namespace ExampleProject.Api.Infrastructure.Mappings
{
    internal static class MappingsActivator
    {
        public static void Configure()
        {
            Mapper.Initialize(config =>
            {
                config.MapPerson();
            });
        }
    }
}
