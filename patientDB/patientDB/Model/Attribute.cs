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
        public Attribute(int id, string value)
        {
            this.id = id;
            this.value = value;
        }
        public Attribute(string value)
        {
            this.value = value;
        }
    }
}
