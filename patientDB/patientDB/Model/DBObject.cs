using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace patientDB
{
    class DBObject: IDBObject
    {
        public string value { get; set; }
        public Dictionary<Attribute, Node> data { get; set; }
        public int? id { get; set; }
        public DBObject (string value)
        {
            this.value = value;
        }
    }
}
