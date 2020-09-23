using PersonDirectory.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDirectory.Core.Entities
{
    public class TelNumber
    {
        public int ID { get; set; }
        public string Number { get; set; }
        public TelNumberTypeEnum TelNumberType { get; set; }
    }
}
