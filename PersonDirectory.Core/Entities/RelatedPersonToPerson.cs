using PersonDirectory.Core.Enums;
using System.Text.Json.Serialization;

namespace PersonDirectory.Core.Entities
{
    public class RelatedPersonToPerson
    {
        public RelationTypeEnum RelationType { get; set; }
        [JsonIgnore]
        public virtual Person Person { get; set; }
        public virtual Person RelatedPerson { get; set; }
        [JsonIgnore]
        public int PersonId { get; set; }
        [JsonIgnore]
        public int RelatedPersonId { get; set; }
    }
}
