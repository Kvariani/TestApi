using Newtonsoft.Json;
using System.Collections.Generic;

namespace PersonDirectory.Core.Entities
{
    public class Person : BasePerson
    {
     
        public virtual ICollection<RelatedPersonToPerson> ReladedPersons { get; set; }
        [JsonIgnore]
        public virtual ICollection<RelatedPersonToPerson> ReladedOn { get; set; }

    }
}
