using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patientDB
{
    class Node : IDBObject
    {
        public int? id { get; set; }
        public int? idAttribute { set;  get; }
        public int? idObject { set;  get; }
        public string value { get; set; }

        public Node(int id, string value)
        {
            this.id = id;
            this.value = value;
        }
        public Node(string value)
        {
            this.value = value;
        }
    }
}
