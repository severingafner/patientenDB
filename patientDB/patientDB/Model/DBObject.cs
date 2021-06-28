using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using patientDB.DBConnection;

namespace patientDB
{
    class DBObject: IDBObject
    {
        public int? id { get; set; }
        public string objectValue { get; set; }
        public Dictionary<Attribute, Node> data { get; set; }

        public void insert ()
        {
            SqlConnection conn = Connection.LocalInstance();
            //Commandobjekt bilden
            SqlCommand insertCommand = new SqlCommand("INSERT INTO Object (objectValue) output INSERTED.ID VALUES (@value)", conn);
            insertCommand.Parameters.Add("@value", System.Data.SqlDbType.VarChar, 300).Value = objectValue;


            try
            {
                //Connection öffnen
                conn.Open();

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
