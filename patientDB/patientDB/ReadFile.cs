using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace patientDB
{
    class ReadFile
    {
        public static List<DBObject> Read(XDocument doc)
        {

            try
            {

                List<DBObject> allObj = new List<DBObject>();

                foreach (XElement el in doc.Root.Elements())
                {

                    DBObject obj = new DBObject(el.Name.ToString())
                    {
                        data = new Dictionary<Attribute, Node>()
                    };

                    foreach (XElement child in el.Elements())
                    {
                        Attribute a = new Attribute(child.Name.ToString());
                        Node n = new Node(child.Value.ToString());
                        obj.data.Add(a, n);
                    }

                    allObj.Add(obj);
                }
                return allObj;
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File could not be parsed:");
                Console.WriteLine(e);
                Console.ReadLine();
            }
            return null;
        }
    }
}
