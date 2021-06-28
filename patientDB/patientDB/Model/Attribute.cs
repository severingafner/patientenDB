using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patientDB
{
    class Attribute
    {
        public int attributeId { get;}
        public string value { get; set; }
        public Attribute(int attributeId, string value)
        {
            this.attributeId = attributeId;
            this.value = value;
        }
    }
}
