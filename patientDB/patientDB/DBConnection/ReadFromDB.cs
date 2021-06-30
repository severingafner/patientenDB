using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace patientDB
{
    static class ReadFromDB
    {

        private static DataSet GetDataFromDB(int dbObjectId, SqlConnection conn)
        {
            DataSet dataSet = new DataSet();
            string selectObjectQuery = "SELECT objectValue FROM object WHERE objectId = " + dbObjectId;
            SqlDataAdapter dbObjectAdapter = new SqlDataAdapter(selectObjectQuery, conn);
            dbObjectAdapter.Fill(dataSet, "objectValue");


            string selectQuery = "SELECT attributeId, attributeValue, nodeValue FROM object LEFT JOIN Node ON object.objectId = Node.idObject LEFT JOIN Attribute ON Node.idAttribute = Attribute.attributeId WHERE objectId = " + dbObjectId;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(selectQuery, conn);
            dataAdapter.Fill(dataSet, "data");
            return dataSet;
        }

        private static Attribute GetAttributeById (Dictionary<Attribute, Node> data, int id)
        {
            foreach (KeyValuePair<Attribute, Node> row in data)
            {
                if (row.Key.id == id)
                {
                    return row.Key;
                }
            }
            return null;
        }

        private static DBObject ParseDataToDBObject (DataSet dataSet)
        {
            DataTable objectNameTable = dataSet.Tables["objectValue"];
            DataTable dataTable = dataSet.Tables["data"];
            Dictionary <Attribute, Node> data = new Dictionary<Attribute, Node>();
            DBObject readDbObject =  new DBObject(Convert.ToString(objectNameTable.Rows[0]["objectValue"]));
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["attributeId"] != DBNull.Value)
                {
                    int attributeId = Convert.ToInt32(row["attributeId"]);
                    // If we already have that attribute in the dictionary, use it's reference instead of creating a new one
                    Attribute attribute = GetAttributeById(data, attributeId);
                    if (attribute == null)
                    {
                        attribute = new Attribute(attributeId, Convert.ToString(row["attributeValue"]));
                    }

                    Node node = new Node(Convert.ToString(row["nodeValue"]));
                    data.Add(attribute, node);
                }
            }
            readDbObject.data = data;
            return readDbObject;
        }

        public static DBObject Read (int dbObjectId, SqlConnection conn)
        {
            try
            {
                conn.Open();
                DataSet dataSet = GetDataFromDB(dbObjectId, conn);
                return ParseDataToDBObject(dataSet);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return null;
        }
    }
}
