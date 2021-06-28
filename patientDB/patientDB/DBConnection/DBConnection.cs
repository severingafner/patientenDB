using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patientDB.DBConnection
{
    public static class DBConnection
    {
        static string globalDatabaseConnection = "Data Source = DESKTOP-8K0P1B4\\SQLEXPRESS;" + "Initial Catalog = PatientenDB;" + "Integrated Security=SSPI;";
        
        static string localDatabaseConnection = "Data Source = DESKTOP-8K0P1B4\\SQLEXPRESS;" + "Initial Catalog = HausarztDB;" + "Integrated Security=SSPI;";

        static SqlConnection globalInstance;

        static SqlConnection localInstance;

        public static SqlConnection GlobalInstance()
        {
            if (globalInstance == null)
            {
                globalInstance = new SqlConnection(globalDatabaseConnection);
            }
            return globalInstance;
        }
        public static SqlConnection LocalInstance()
        {
            if (localInstance == null)
            {
                localInstance = new SqlConnection(localDatabaseConnection);
            }
            return localInstance;
        }
    }
}
