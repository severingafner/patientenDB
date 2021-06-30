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
            DBObject readObject = ReadFromDB.Read(1, Connection.LocalInstance());
            foreach (KeyValuePair<Attribute, Node> row in readObject.data)
            {
                Console.WriteLine(readObject.value + ' ' + row.Key.value + ' ' + row.Value.value);
            }
            Console.ReadLine();
        }
    }
}
