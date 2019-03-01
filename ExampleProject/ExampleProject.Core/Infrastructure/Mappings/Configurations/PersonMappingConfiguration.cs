using AutoMapper;
using ExampleProject.Common.Helpers;
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
                .ForMember(dto => dto.Color, opt => opt.MapFrom(entity => entity.FavoriteColor.GetName().ToLowerInvariant()));

            config.CreateMap<PersonToCreateDto, Data.Entities.Person>()
                .ForMember(entity => entity.Surname, opt => opt.MapFrom(dto => dto.LastName))
                .ForMember(entity => entity.FirstName, opt => opt.MapFrom(dto => dto.Name))
                .ForPath(entity => entity.Address.PostalCode, opt => opt.MapFrom(dto => dto.ZipCode))
                .ForPath(entity => entity.Address.City, opt => opt.MapFrom(dto => dto.City))
                .ForMember(entity => entity.FavoriteColor, opt => opt.MapFrom(dto => dto.Color.GetValue<ColorEnum>()));
            return config;
        }
    }
}
