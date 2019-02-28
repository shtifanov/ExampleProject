using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ExampleProject.Core.Person.Interfaces;
using ExampleProject.Data.Enums;
using ExampleProject.DataAccess.Interfaces;
using ExampleProject.Dto.Person;

namespace ExampleProject.Core.Person
{
    internal sealed class PersonManagement : IPersonManagement
    {
        private readonly IDb _db;

        public PersonManagement(IDb db)
        {
            _db = db;
        }

        public IReadOnlyList<PersonDto> GetPersons()
        {
            return Mapper.Instance.ProjectTo<PersonDto>(_db.PersonRepository.Get()).ToList();
        }

        public PersonDto GetPersonById(int id)
        {
            var person = Mapper.Instance.ProjectTo<PersonDto>(_db.PersonRepository.Get().Where(p => p.Id == id)).SingleOrDefault();
            return person;
        }

        public IReadOnlyList<PersonDto> GetPersonsByColor(ColorEnum color)
        {
            var persons = Mapper.Instance.ProjectTo<PersonDto>(_db.PersonRepository.Get().Where(p => p.FavoriteColor == color));
            return Mapper.Map<List<PersonDto>>(persons);
        }
    }
}