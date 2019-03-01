using System;
using System.IO;
using System.Linq;
using ExampleProject.Data.Entities;
using ExampleProject.Data.Enums;
using ExampleProject.DataAccess.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace ExampleProject.Api.Infrastructure.Extensions
{
    internal static class StartupExtensions
    {
        public static void AddExceptionHandler(this IApplicationBuilder appBuilder)
        {
            appBuilder.Run(async context =>
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync("An unexpected error occured, we are doing our best to correct it. Please try again later.");
            });
        }

        public static void SeedExampleData(this IDb db)
        {
            //for test purposes the Db is cleared every time
            db.PersonRepository.RemoveRange(db.PersonRepository.Get());
            db.Save();

            var examplePersons = File.ReadAllLines("ExampleData.csv")
                .Select(line => line.Split(",")
                    .Select(part => part.Trim())
                    .ToArray())
                .Select(line => new Person
                {
                    Surname = line[0],
                    FirstName = line[1],
                    Address =
                    {
                        PostalCode = line[2].Substring(0, line[2].IndexOf(" ", StringComparison.InvariantCulture)),
                        City = line[2].Remove(0,  line[2].IndexOf(" ", StringComparison.InvariantCulture) + 1)
                    },
                    FavoriteColor = (ColorEnum)int.Parse(line[3])
                })
                .ToList();
            db.PersonRepository.AddRange(examplePersons);
            db.Save();
        }
    }
}