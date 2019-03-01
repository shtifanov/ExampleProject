using ExampleProject.Data.Entities;

namespace ExampleProject.DataAccess.Interfaces
{
    public interface IDb
    {
        void Save();

        IRepository<Person> PersonRepository { get; }
    }
}