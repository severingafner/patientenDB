using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patientDB
{
    public class Attribute : IDBObject
    {
        public string value { get; set; }
        
        public int? id { get; set; }

        public Attribute(string value)
        {
            this.value = value;
        }

        public void insert()
        {
            SqlConnection conn = Connection.LocalInstance();
            //Commandobjekt bilden
            SqlCommand insertCommand = new SqlCommand("INSERT INTO Attribute (attributeValue) output INSERTED.ID VALUES (@value)", conn);
            insertCommand.Parameters.Add("@value", System.Data.SqlDbType.VarChar, 300).Value = value;
            try
            {
                //Connection öffnen
                conn.Open();

                //Befehl abschicken
                id = (int)insertCommand.ExecuteScalar();

            }
            catch (Exception ex)
            {
                //Fehlermeldung
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //DB-Connection schliessen
                conn.Close();
            }
        }
    }
}
