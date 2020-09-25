using PersonDirectory.Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PersonDirectory.Core.Entities
{
    public class TelNumber : EntityBase
    {
        [RegularExpression(@"([+0123456789 ]{4,50})", ErrorMessage = "ტელეფონის ნომერი არასწორ ფორმატშია")]
        public string Number { get; set; }
        public TelNumberTypeEnum TelNumberType { get; set; }
        [JsonIgnore]
        public Person Person { get; set; }
        [JsonIgnore]
        public int PersonId { get; set; }
    }
}
