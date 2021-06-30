using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace patientDB
{
    class DBObject: IDBObject
    {
        public int? id { get; set; }
        public string objectValue { get; set; }
        public Dictionary<Attribute, Node> data { get; set; }

        // Vorname Heinz
        // Nachname Günther
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

                if (id == null)
                {
                    id = (int)insertCommand.ExecuteScalar();
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
