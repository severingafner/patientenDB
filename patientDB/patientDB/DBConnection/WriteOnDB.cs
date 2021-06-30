﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;

namespace patientDB
{
    static class WriteOnDB
    {
        public static void write (DBObject dbObjectToWrite, SqlConnection conn)
        {
            try
            {
                conn.Open();

                int dbObjectId = InsertDbObject(dbObjectToWrite, conn);
                foreach (KeyValuePair<Attribute, Node> row in dbObjectToWrite.data)
                {
                    int attributeId = InsertAttribute(row.Key, conn);
                    InsertNode(dbObjectId, attributeId, row.Value, conn);
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
        }
           
        private static int InsertDbObject (DBObject dbObject, SqlConnection conn)
        {
            SqlCommand insertCommand = new SqlCommand("INSERT INTO Object (objectValue) output INSERTED.ID VALUES (@value)", conn);
            insertCommand.Parameters.Add("@value", System.Data.SqlDbType.VarChar, 300).Value = dbObject.value;
            return (int)insertCommand.ExecuteScalar();
        }
        private static int InsertAttribute (Attribute attribute, SqlConnection conn)
        {
            SqlCommand insertCommand = new SqlCommand("INSERT INTO Attribute (attributeValue) output INSERTED.ID VALUES (@value)", conn);
            insertCommand.Parameters.Add("@value", System.Data.SqlDbType.VarChar, 300).Value = attribute.value;
            return (int)insertCommand.ExecuteScalar();
        }

        private static int InsertNode (int dbObjectId, int attributeId, Node node, SqlConnection conn)
        {
            SqlCommand insertCommand = new SqlCommand("INSERT INTO Note (idObject, idAttribute, nodeValue) output INSERTED.ID VALUES (@idObject, @idAttribute, @nodeValue)", conn);
            insertCommand.Parameters.Add("@idObject", System.Data.SqlDbType.VarChar, 300).Value = dbObjectId;
            insertCommand.Parameters.Add("@idAttribute", System.Data.SqlDbType.VarChar, 300).Value = attributeId;
            insertCommand.Parameters.Add("@nodeValue", System.Data.SqlDbType.VarChar, 300).Value = node.value;
            return (int)insertCommand.ExecuteScalar();
        }
    }
}