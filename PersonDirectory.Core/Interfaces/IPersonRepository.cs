using PersonDirectory.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDirectory.Core.Repositories
{
    public interface IPersonRepository
    {
        Person CreatePerson(BasePerson person);
        Person ModifyPerson(int id, BasePerson person);
        Person AddRelatedPerson(int personId, int relatedPersonID, Enums.RelationTypeEnum relationType);
        bool DeleteRelatedPerson(int personId, int relatedPersonID);
        bool DeletePerson(int personId);

        Person GetPerson(int personId);
        Person[] GetPersons(string searchString, int pageIndex, int pageSize, bool fastSearch);
    }
}
