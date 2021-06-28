using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patientDB.DBConnection
{
    public class DBConnection
    {
        static DBConnection instance;
        public static  DBConnection Instance()
        {
            if (instance == null)
            {
                instance = new DBConnection();
            }
            return instance;
        }
    }
}
