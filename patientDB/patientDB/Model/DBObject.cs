using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using patientDB.DBConnection;

namespace patientDB
{
    class DBObject
    {
        public KeyValuePair<Attribute, Node>[] data { get; set; }

        public void insert ()
        {
            SqlConnection conn = DBConnection.LocalInstance();
            //Commandobjekt bilden
            SqlCommand insertCommand = new SqlCommand(my_sql, conn);

            try
            {
                //Connection öffnen
                conn.Open();

                //Befehl abschicken
                insertCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Fehlermeldung
            }
            finally
            {
                //DB-Connection schliessen
                conn.Close();
            }
        }
    }
}
