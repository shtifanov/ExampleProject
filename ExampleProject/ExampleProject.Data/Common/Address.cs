using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ExampleProject.Data.Common
{
    [Owned]
    public sealed class Address
    {
        public string PostalCode { get; set; }
        public string City { get; set; }
    }
}