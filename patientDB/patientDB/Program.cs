using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace patientDB
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Enter Path to file:");
            string pathToFile = Console.ReadLine();

            Console.WriteLine("\n\nLoad DBObjects from XML");
            XDocument doc = XDocument.Load(pathToFile);
            foreach (DBObject dbObj in ReadFile.Read(doc))
            {
                Console.WriteLine("Loaded DBObject from XML:\n");
                logDBObject(dbObj);
                Console.WriteLine("Write DBObject to DB");
                int newObjectId = WriteOnDB.Write(dbObj, Connection.LocalInstance());
                Console.WriteLine("Read DBObject from DB");
                DBObject readObject = ReadFromDB.Read(newObjectId, Connection.LocalInstance());
                Console.WriteLine("DBObject from DB:\n");
                logDBObject(readObject);
            }
            Console.ReadLine();
        }

        static void logDBObject (DBObject dbObject)
        {
            Console.WriteLine(dbObject.value);
            foreach (KeyValuePair<Attribute, Node> row in dbObject.data)
            {
                Console.Write(row.Key.value + ' ' + row.Value.value + '\t');
            }
            Console.WriteLine('\n');
        }
    }
}
