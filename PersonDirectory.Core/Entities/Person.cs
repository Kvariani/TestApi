using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PersonDirectory.Core.Entities
{
    public class Person : BasePerson
    {
     
        public virtual ICollection<RelatedPersonToPerson> ReladedPersons { get; set; }
        [JsonIgnore]
        public virtual ICollection<RelatedPersonToPerson> ReladedOn { get; set; }

    }
}
