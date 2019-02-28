using AutoMapper;
using ExampleProject.Core.Infrastructure.Mappings.Configurations;

namespace ExampleProject.Core.Infrastructure.Mappings
{
    public static class MappingsActivator
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
