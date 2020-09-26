using System.ComponentModel.DataAnnotations;

namespace PersonDirectory.Core.Helpers
{
    public class CheckNameValidityAttribute : RegularExpressionAttribute
    {
        public CheckNameValidityAttribute(string propertyName) : base(@"((^[a-zA-Z ]{2,50})*$|(^[ა-ჰ ]{2,50})*$)")
        {
            ErrorMessage = $"{propertyName}{Constants.STR_PropertyShouldNotContainGeoAndLatinSymbols}";
        }
    }
}
