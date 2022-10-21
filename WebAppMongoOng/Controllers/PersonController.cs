using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppMongoOng.Models;
using WebAppMongoOng.Service;

namespace WebAppMongoOng.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonService _personService;
        private readonly AnimalService _animalService;

        public PersonController(PersonService personService, AnimalService animalService)
        {
            _personService = personService;
            _animalService = animalService;
        }

        #region Lista Todos
        [HttpGet]
        public ActionResult<List<Person>> GetAll() => _personService.GetAll();
        #endregion

        #region Lista pelo id
        [HttpGet("{id:length(24)}", Name = "GetPerson")]
        public ActionResult<Person> Get(string id)
        {
            var person = _personService.Get(id);

            if (person == null) 
                return NotFound();

            return Ok(person);
        }
        #endregion

        #region Lista pelo nome
        [HttpGet("{name}", Name = "GetName")]
        public ActionResult<Person> GetByName(string n)
        {
            var person = _personService.GetByName(n);

            if (person == null)
                return NotFound();

            return Ok(person);
        }
        #endregion

        #region Busca Animal
        [HttpGet("animal/{id:length(24)}", Name = "GetPersonByAnimal")]
        public ActionResult<Person> GetByAnimal(string id)
        {
            var person = _personService.GetByAnimal(id);
            if (person == null)
                return NotFound();

            return Ok(person);
        }
        #endregion

        #region Insert Person
        [HttpPost]
        public ActionResult<Person> Create(Person person)
        {
            Animal animal = _animalService.Create(person.Animal);
            person.Animal = animal;

            _personService.Create(person);
            return CreatedAtRoute("GetPerson", new { id = person.Id.ToString() }, person);
        }
        #endregion

        #region Update Person
        [HttpPut]
        public ActionResult<Person> Update(string id, Person personIn)
        {
            var person = _personService.Get(id);

            if (person == null)
                return NotFound();

            personIn.Id = id;

            _personService.Update(id, personIn);

            return NoContent();
        }
        #endregion

        #region Delete Person
        [HttpDelete]
        public ActionResult Remove(string id)
        {
            var person = _personService.Get(id);

            if (person == null)
                return NotFound();

            _personService.Remove(person);
            return NoContent();
        }
        #endregion
    }
}
