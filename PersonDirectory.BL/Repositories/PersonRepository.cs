using PersonDirectory.Core.Entities;
using PersonDirectory.Infrastructure.DBContexts;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

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

        public Person AddRelatedPerson(int personId, int relatedPersonID, Enums.RelationTypeEnum relationType)
        {
            var person = _context.Find<Person>(personId);
            var relatedPerson = _context.Find<Person>(relatedPersonID);
            var relation = new RelatedPersonToPerson() { Person = person, RelatedPerson = relatedPerson, RelationType = relationType };
            //person.ReladedPersons.Add();
            _context.Add(relation);
            _context.SaveChanges();
            return person;
        }

        public Person CreatePerson(BasePerson person)
        {
            var newPerson = _mapper.Map<Person>(person);
            _context.Add(newPerson);
            _context.SaveChanges();
            return newPerson;
        }

        public bool DeletePerson(int personId)
        {
            var person = _context.Find<Person>(personId);
            _context.Remove(person);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteRelatedPerson(int personId, int relationId)
        {
            var person = _context.Find<Person>(personId); // << TODO???????????
            var relation = _context.Find<RelatedPersonToPerson>(relationId);
            _context.Remove(relation);
            _context.SaveChanges();
            return true;
        }

        public Person GetPerson(int personId)
        {
            return _context.Persons.Include(x => x.ReladedPersons).ThenInclude(x => x.RelatedPerson).Include(x => x.TelNumbers).FirstOrDefault(x => x.ID == personId);
            //var c = _context.Find<Person>(personId);
            //return _context.Find<Person>(personId);
        }

        public Person[] GetPersons(string searchString, int pageIndex, int pageSize, bool fastSearch = false)
        {
            var splitedSearchString = searchString.Split(' ');

            if (fastSearch)
                return GetPersons().Where(x => splitedSearchString.Any(a => $"{x.Firstname}_{x.Lastname}_{x.IDNumber}".ToLower().Contains(a.ToLower()))).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToArray();

            return GetPersons().Where(x => splitedSearchString.Any(a => $"{x.Firstname}_{x.Lastname}_{x.IDNumber}_{string.Join("_", x.TelNumbers.Select(s => s.Number))}".ToLower().Contains(a.ToLower()))).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToArray();
        }

        IEnumerable<Person> GetPersons() => _context.Persons.Include(x => x.ReladedPersons).ThenInclude(x => x.RelatedPerson).Include(x => x.TelNumbers).AsEnumerable();

        // TODO დასამატებელია ლოგიკა ტელეფონის ნომრებისთვისაც (ავტომეფერიც?)
        public Person ModifyPerson(int id, BasePerson person)
        {
            var p = _context.Find<Person>(id);
            _mapper.Map(person, p);
            _context.SaveChanges();
            return p;
        }
    }
}
