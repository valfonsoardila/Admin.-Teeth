using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace AdminTeeth
{
    public class ConfigConection
    {
        public static string ConfiguracionDB = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

    }
}
