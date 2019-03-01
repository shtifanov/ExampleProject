using System.ComponentModel.DataAnnotations;
using ExampleProject.Data.Common;
using ExampleProject.Data.Enums;

namespace ExampleProject.Data.Entities
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Surname { get; set; }
        [Required, MaxLength(100)]
        public string FirstName { get; set; }
        public Address Address { get; set; } = new Address();
        [Required]
        public ColorEnum FavoriteColor { get; set; }
    }
}
