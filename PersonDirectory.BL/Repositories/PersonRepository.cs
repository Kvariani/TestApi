using PersonDirectory.Core.Entities;
using PersonDirectory.Infrastructure.DBContexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDirectory.Core.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        readonly PersonContext _context;
        public PersonRepository(PersonContext context) => _context = context;
        public Person CreatePerson()
        {
            throw new NotImplementedException();
        }
    }
}
