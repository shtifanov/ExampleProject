using ExampleProject.Core.Person.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExampleProject.Api.Controllers
{
    [Route("api/persons")]
    [ApiController]
    public sealed class PersonController : ControllerBase
    {
        private readonly IPersonManagement _personManagement;

        public PersonController(IPersonManagement personManagement)
        {
            _personManagement = personManagement;
        }

        [HttpGet]
        public IActionResult GetPersons()
        {
            var result = _personManagement.GetPersons();
            return Ok(result);
        }
    }
}