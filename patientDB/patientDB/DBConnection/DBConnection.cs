using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patientDB.DBConnection
{
    class DBConnection
    {
        private DBConnection instance;
        protected DBConnection()
        {

        }
        public DBConnection Instance()
        {
            if (instance == null)
            {
                instance = new DBConnection();
            }
            return instance;
        }
    }
}
