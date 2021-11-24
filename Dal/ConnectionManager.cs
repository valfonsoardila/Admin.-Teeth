using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class ConnectionManager
    {
        internal SqlConnection _conexion;
        public ConnectionManager(string connectionstring)
        {
            _conexion = new SqlConnection(connectionstring);
        }
        public void Open() 
        {
            _conexion.Open();
        }
        public void Close()
        {
            _conexion.Close();
        }
    }
}
