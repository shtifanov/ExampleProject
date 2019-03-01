using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ExampleProject.Data.Enums;

namespace ExampleProject.Dto.Person
{
    public class PersonToCreateDto : IValidatableObject
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, MaxLength(100)]
        public string LastName { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        [Required]
        public string Color { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var result = new List<ValidationResult>();
            if (!Enum.TryParse<ColorEnum>(Color, true, out _)) 
                result.Add(new ValidationResult("Color could not be parsed.", new[] { nameof(Color) }));
            return result;
        }
    }
}