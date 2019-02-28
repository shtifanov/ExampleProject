﻿using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ExampleProject.Core.Person.Interfaces;
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

    }
}