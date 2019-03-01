using System.Collections.Generic;
using ExampleProject.Data.Enums;
using ExampleProject.Dto.Person;

namespace ExampleProject.Core.Person.Interfaces
{
    public interface IPersonManagement
    {
        PersonDto CreatePerson(PersonToCreateDto person);
        IReadOnlyList<PersonDto> GetPersons();
        PersonDto GetPersonById(int id);
        IReadOnlyList<PersonDto> GetPersonsByColor(ColorEnum color);
    }
}
