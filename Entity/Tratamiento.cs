using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Tratamiento
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public List<Observacion> Observaciones { get; set; }
    }
}
