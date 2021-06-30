using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;

namespace patientDB
{
    static class WriteOnDB
    {
        public static int Write(DBObject dbObjectToWrite, SqlConnection conn)
        {
            int dbObjectId = -1;
            try
            {
                conn.Open();

                dbObjectId = InsertDbObject(dbObjectToWrite, conn);
                if (dbObjectToWrite.data != null)
                {
                    foreach (KeyValuePair<Attribute, Node> row in dbObjectToWrite.data)
                    {
                        // if the attribute has an id, it was already created.
                        // An improvement would be to check if the value is still the same or otherwise update the attribute
                        if (row.Key.id == null)
                        {
                            row.Key.id = InsertAttribute(row.Key, conn);
                        }
                        // always create a new Node
                        InsertNode(dbObjectId, (int)row.Key.id, row.Value, conn);
                    }
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return dbObjectId;
        }
           
        private static int InsertDbObject (DBObject dbObject, SqlConnection conn)
        {
            SqlCommand insertCommand = new SqlCommand("INSERT INTO Object (objectValue) output INSERTED.objectId VALUES (@value)", conn);
            insertCommand.Parameters.Add("@value", System.Data.SqlDbType.VarChar, 300).Value = dbObject.value;
            return (int)insertCommand.ExecuteScalar();
        }
        private static int InsertAttribute (Attribute attribute, SqlConnection conn)
        {
            SqlCommand insertCommand = new SqlCommand("INSERT INTO Attribute (attributeValue) output INSERTED.attributeId VALUES (@value)", conn);
            insertCommand.Parameters.Add("@value", System.Data.SqlDbType.VarChar, 300).Value = attribute.value;
            return (int)insertCommand.ExecuteScalar();
        }

        private static int InsertNode (int dbObjectId, int attributeId, Node node, SqlConnection conn)
        {
            SqlCommand insertCommand = new SqlCommand("INSERT INTO Note (idObject, idAttribute, nodeValue) output INSERTED.nodeid VALUES (@idObject, @idAttribute, @nodeValue)", conn);
            insertCommand.Parameters.Add("@idObject", System.Data.SqlDbType.VarChar, 300).Value = dbObjectId;
            insertCommand.Parameters.Add("@idAttribute", System.Data.SqlDbType.VarChar, 300).Value = attributeId;
            insertCommand.Parameters.Add("@nodeValue", System.Data.SqlDbType.VarChar, 300).Value = node.value;
            return (int)insertCommand.ExecuteScalar();
        }
    }
}
