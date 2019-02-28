using System.Collections.Generic;
using ExampleProject.Data.Enums;
using ExampleProject.Dto.Person;

namespace ExampleProject.Core.Person.Interfaces
{
    public interface IPersonManagement
    {
        IReadOnlyList<PersonDto> GetPersons();
        PersonDto GetPersonById(int id);
        IReadOnlyList<PersonDto> GetPersonsByColor(ColorEnum color);
    }
}
