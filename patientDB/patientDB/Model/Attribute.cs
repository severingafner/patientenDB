using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patientDB
{
    public class Attribute : IDBObject
    {
        public string value { get; set; }
        public int? id { get; set; }

        public Attribute(string value)
        {
            this.value = value;
        }
    }
}
