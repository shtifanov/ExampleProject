using System.Collections.Generic;
using ExampleProject.Dto.Person;

namespace ExampleProject.Core.Person.Interfaces
{
    public interface IPersonManagement
    {
        IReadOnlyList<PersonDto> GetPersons();
        PersonDto GetPersonById(int id);
    }
}
