using PersonDirectory.Core.Entities;
using PersonDirectory.Infrastructure.DBContexts;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Threading.Tasks;

namespace PersonDirectory.Core.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        // TODO მეთოდის დაბრუნებული მნიშვნელობები ის მინდა რაც ეხლა აქვს? დუბლირებული კოდი, ნალზე შემოწმება და ერორები

        readonly ApplicationDbContext _context;
        readonly IMapper _mapper;
        public PersonRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddRelatedPerson(int personId, int relatedPersonID, Enums.RelationTypeEnum relationType)
        {
            var person = _context.Find<Person>(personId);
            var relatedPerson = _context.Find<Person>(relatedPersonID);
            var relation = new RelatedPersonToPerson() { Person = person, RelatedPerson = relatedPerson, RelationType = relationType };
            //person.ReladedPersons.Add();
            _context.Add(relation);
            await _context.SaveChangesAsync();
        }

        public async Task<int> CreatePerson(BasePerson person)
        {
            var newPerson = _mapper.Map<Person>(person);
            _context.Add(newPerson);
            await _context.SaveChangesAsync();
            return newPerson.ID;
        }

        public async Task DeletePerson(int personId)
        {
            var person = _context.Find<Person>(personId);
            _context.Remove(person);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRelatedPerson(int personId, int relatedPersonId)
        {
            var relation = _context.Find<RelatedPersonToPerson>(personId, relatedPersonId);
            _context.Remove(relation);
            await _context.SaveChangesAsync();
        }

        public async Task<Person> GetPerson(int personId) => await Task.FromResult(GetPersons().FirstOrDefault(x => x.ID == personId));

        //TODO სერჩი უნდა შევცვალო
        public async Task<IEnumerable<Person>> GetPersons(string searchString, int pageIndex, int pageSize, bool fastSearch = false)
        {
            var splitedSearchString = searchString.Split(' ');

            if (fastSearch)
                return await Task.FromResult(GetPersons().Where(x => splitedSearchString.Any(a => $"{x.Firstname}_{x.Lastname}_{x.IDNumber}".ToLower().Contains(a.ToLower()))).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToArray());

            return await Task.FromResult(GetPersons().Where(x => splitedSearchString.Any(a => $"{x.Firstname}_{x.Lastname}_{x.IDNumber}_{string.Join("_", x.TelNumbers.Select(s => s.Number))}".ToLower().Contains(a.ToLower()))).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToArray());
        }

        IEnumerable<Person> GetPersons() => _context.Persons.Include(x => x.ReladedPersons).ThenInclude(x => x.RelatedPerson).Include(x => x.TelNumbers).AsEnumerable();

        public async Task ModifyPerson(int id, BasePerson person)
        {
            var p = _context.Find<Person>(id);
            _mapper.Map(person, p);
            await _context.SaveChangesAsync();
        }
    }
}
