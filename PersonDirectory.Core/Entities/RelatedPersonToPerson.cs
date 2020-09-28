﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PersonDirectory.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace PersonDirectory.Core.Entities
{
    public class RelatedPersonToPerson
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public RelationTypeEnum RelationType { get; set; }
        [JsonIgnore, Required]
        public virtual Person Person { get; set; }
        [Required]
        public virtual Person RelatedPerson { get; set; }
        [JsonIgnore, Required]
        public int PersonId { get; set; }
        [JsonIgnore, Required]
        public int RelatedPersonId { get; set; }
    }
}
