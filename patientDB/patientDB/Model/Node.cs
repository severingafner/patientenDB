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


    }
}
