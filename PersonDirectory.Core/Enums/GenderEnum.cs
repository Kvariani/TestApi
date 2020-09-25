using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace PersonDirectory.Core.Enums
{
    public enum GenderEnum
    {
        //[Display(Name = "ქალი")]
        Female = 0,
        //[Display(Name = "კაცი")]
        Male = 1
    }
}
