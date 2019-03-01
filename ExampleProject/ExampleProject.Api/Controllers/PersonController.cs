using System;
using ExampleProject.Core.Person.Interfaces;
using ExampleProject.Data.Enums;
using ExampleProject.Dto.Person;
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

        [HttpGet("{id}")]
        public IActionResult GetPerson(int id)
        {
            var person = _personManagement.GetPersonById(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        [HttpGet("color/{color}")]
        public IActionResult GetPersonByColor(string color)
        {
            if (!Enum.TryParse<ColorEnum>(color, true, out var colorEnum))
                return BadRequest(new { Message = $"Color '{color}' could not be parsed." });

            var result = _personManagement.GetPersonsByColor(colorEnum);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreatePerson([FromBody]PersonToCreateDto person)
        {
            if (person == null) return BadRequest(new { Message = "Model could not be parsed." });

            var createdPerson = _personManagement.CreatePerson(person);
            return CreatedAtAction(nameof(GetPerson), new { id = createdPerson.Id }, createdPerson);
        }
    }
}