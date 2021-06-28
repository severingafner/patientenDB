using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patientDB
{
    class Program
    {
        static void Main(string[] args)
        {
            DBObject obj = null;
            if (obj.id == null)
            {
                obj.insert();
            }
            foreach (KeyValuePair<Attribute, Node> row in data)
            {
                if (row.Key.id == null)
                {
                    row.Key.insert();
                }
                if (row.Value.id == null)
                {
                    row.Value.idObject = id;
                    row.Value.idAttribute = row.Key.id;
                    row.Value.insert();
                }
            }
        }
    }
}
