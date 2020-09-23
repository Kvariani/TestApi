using PersonDirectory.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDirectory.Core.Entities
{
    public class RelatedPersonToPerson
    {
        public int ID { get; set; }
        public RelationTypeEnum RelationType { get; set; }
        public Person Person { get; set; }
        public Person RelatedPerson { get; set; }
    }
}
