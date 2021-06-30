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

            XDocument doc = XDocument.Load(pathToFile);
            try
            {
                foreach (DBObject dbObj in ReadFile.Read(doc))
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
