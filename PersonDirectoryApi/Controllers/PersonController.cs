using Microsoft.AspNetCore.Mvc;
using PersonDirectory.Core.Entities;
using PersonDirectory.Core.Enums;
using PersonDirectory.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonDirectory.Api.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        readonly IPersonRepository _repository;

        public PersonController(IPersonRepository repository)
        {
            _repository = repository;
        }


        [HttpPost]
        public ActionResult<Person> CreatePerson([FromBody] BasePerson person)
        {
            return _repository.CreatePerson(person);
        }

        [HttpPut]
        public async Task<ActionResult<Person>> ModifyPerson(int id, [FromBody] BasePerson person)
        {
            return _repository.ModifyPerson(id, person);
        }

        [HttpPost]
        public async Task<ActionResult<Person>> AddRelatedPerson(int personId, int relatedPersonID, RelationTypeEnum relationType)
        {
            return _repository.AddRelatedPerson(personId, relatedPersonID, relationType);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteRelatedPerson(int personId, int relatedPersonID)
        {
            return _repository.DeleteRelatedPerson(personId, relatedPersonID);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeletePerson(int id)
        {
            return _repository.DeletePerson(id);
            //var todoItem = await _context.TodoItems.FindAsync(id);
            //if (todoItem == null)
            //{
            //    return NotFound();
            //}

            //    //_context.TodoItems.Remove(todoItem);
            //    //await _context.SaveChangesAsync();

            //    //return todoItem;
            //    throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            return _repository.GetPerson(id);
        }

        [HttpGet]
        public async Task<ActionResult<Person[]>> GetPersons(string searchString, int pageIndex, int pageSize, bool fastSearch)
        {
            return _repository.GetPersons(searchString, pageIndex, pageSize, fastSearch);
        }
    }
}
