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
        public int? idAttribute { set;  get; }
        public int? idObject { set;  get; }
        public string value { get; set; }

        public int? id { get; set; }

        public Node(string value)
        {
            this.value = value;
        }

        public void insert()
        {
            SqlConnection conn = Connection.LocalInstance();
            //Commandobjekt bilden
            SqlCommand insertCommand = new SqlCommand("INSERT INTO Note (idObject, idAttribute, nodeValue) output INSERTED.ID VALUES (@idObject, @idAttribute, @nodeValue)", conn);
            insertCommand.Parameters.Add("@idObject", System.Data.SqlDbType.VarChar, 300).Value = idObject;
            insertCommand.Parameters.Add("@idAttribute", System.Data.SqlDbType.VarChar, 300).Value = idAttribute;
            insertCommand.Parameters.Add("@nodeValue", System.Data.SqlDbType.VarChar, 300).Value = value;
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
