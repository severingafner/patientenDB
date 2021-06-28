using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patientDB
{
    public interface IDBObject
    {
        int? id { get; set; }
        void insert();
    }
}
