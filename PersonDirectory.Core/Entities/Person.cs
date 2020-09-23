using PersonDirectory.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDirectory.Core.Entities
{
    public class Person
    {
        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public GenderEnum Gender { get; set; }
        public string IDNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<TelNumber> TelNumbers { get; set; }
        public ICollection<RelatedPersonToPerson> ReladedPersons { get; set; }
    }
}
