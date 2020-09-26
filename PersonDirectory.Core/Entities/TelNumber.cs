using PersonDirectory.Core.Enums;
using PersonDirectory.Core.Helpers;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PersonDirectory.Core.Entities
{
    public class TelNumber : EntityBase
    {
        [RegularExpression(@"([+0123456789 ]{4,50})", ErrorMessage = Constants.STR_TelNumberIsNotCurrentFormat)] // TODO რეგექსი არასწორია, შესაძლებელი უნდა იყოს რომ მხოლოდ თავში დაეწეროს + სიმბოლო
        public string Number { get; set; }
        public TelNumberTypeEnum TelNumberType { get; set; }
        [JsonIgnore]
        public Person Person { get; set; }
        [JsonIgnore]
        public int PersonId { get; set; }
    }
}
