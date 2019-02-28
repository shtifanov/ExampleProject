using System;
using AutoMapper;
using ExampleProject.Data.Enums;
using ExampleProject.Dto.Person;

namespace ExampleProject.Core.Infrastructure.Mappings.Configurations
{
    internal static class PersonMappingConfiguration
    {
        public static IMapperConfigurationExpression MapPerson(this IMapperConfigurationExpression config)
        {
            config.CreateMap<Data.Entities.Person, PersonDto>()
                .ForMember(dto => dto.LastName, opt => opt.MapFrom(entity => entity.Surname))
                .ForMember(dto => dto.Name, opt => opt.MapFrom(entity => entity.FirstName))
                .ForMember(dto => dto.ZipCode, opt => opt.MapFrom(entity => entity.Address.PostalCode))
                .ForMember(dto => dto.City, opt => opt.MapFrom(entity => entity.Address.City))
                .ForMember(dto => dto.Color, opt => opt.MapFrom(entity => Enum.GetName(typeof(ColorEnum), entity.FavoriteColor).ToLowerInvariant()));

            return config;
        }
    }
}
