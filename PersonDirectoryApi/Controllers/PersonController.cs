using Microsoft.AspNetCore.Mvc;
using PersonDirectory.Core.Entities;
using PersonDirectory.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonDirectory.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        readonly IPersonRepository _repository;

        public PersonController(IPersonRepository repository)
        {
            _repository = repository;
        }


        [HttpPost(Name = nameof(CreatePerson))]
        public async Task<ActionResult<Person>> CreatePerson(Person person)
        {
            _repository.CreatePerson();
            return null;
        }

        //[HttpPut(Name = nameof(ModifyPerson))]
        //public async Task<ActionResult<Person>> ModifyPerson(Person person)
        //{
        //    throw new NotImplementedException();
        //}

        //[HttpPost(Name = nameof(AddRelatedPerson))]
        //public async Task<ActionResult<Person>> AddRelatedPerson(Person person)
        //{
        //    throw new NotImplementedException();
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Person>> DeleteRelatedPerson(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Person>> DeletePerson(int id)
        //{
        //    //var todoItem = await _context.TodoItems.FindAsync(id);
        //    //if (todoItem == null)
        //    //{
        //    //    return NotFound();
        //    //}

        //    //_context.TodoItems.Remove(todoItem);
        //    //await _context.SaveChangesAsync();

        //    //return todoItem;
        //    throw new NotImplementedException();
        //}

        //[HttpGet("{id}")]
        //public async Task<ActionResult<Person>> GetPerson(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //[HttpGet(Name = nameof(GetPersons))]
        //public async Task<ActionResult<Person[]>> GetPersons(string searchString)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
