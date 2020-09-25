using Newtonsoft.Json.Converters;
using PersonDirectory.Core.Enums;
using System.Text.Json.Serialization;

namespace PersonDirectory.Core.Entities
{
    public class RelatedPersonToPerson
    {
        [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
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
