using PersonDirectory.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDirectory.Core.Repositories
{
    public interface IPersonRepository
    {
        Person CreatePerson();
    }
}
