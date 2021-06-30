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
           // DBObject writeObject = new DBObject("test");
            //int newObjectId = WriteOnDB.Write(writeObject, Connection.LocalInstance());
            //DBObject readObject = ReadFromDB.Read(6, Connection.LocalInstance());
            //Console.WriteLine("DBObject aus DB: " + readObject.value);
            //foreach (KeyValuePair<Attribute, Node> row in readObject.data)
            //{
            //    Console.WriteLine(row.Key.value + ' ' + row.Value.value);
            //}
            //Console.ReadLine();
            try
            {
                foreach (DBObject dbObj in ReadFile.Read())
                {
                    WriteOnDB.Write(dbObj, Connection.LocalInstance());
                }
                Console.ReadLine();

            }
            catch (Exception e)
            {
                Console.WriteLine("Error writing on DB");
                Console.WriteLine(e);
                Console.ReadLine();

            }
        }
    }
}
