﻿using ExampleProject.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExampleProject.DataAccess.Context
{
    public sealed class ExampleDbContext : DbContext
    {
        public ExampleDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Person> Persons { get; set; }
    }
}