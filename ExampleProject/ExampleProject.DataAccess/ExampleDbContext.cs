using ExampleProject.Data.Entities;
using ExampleProject.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExampleProject.DataAccess
{
    public sealed class ExampleDbContext : DbContext, IDb
    {
        public ExampleDbContext(DbContextOptions options) : base(options)
        {
            PersonRepository = new Repository<Person>(Persons);
        }

        public DbSet<Person> Persons { get; set; }

        public void Save()
        {
            SaveChanges();
        }

        public IRepository<Person> PersonRepository { get; }
    }
}