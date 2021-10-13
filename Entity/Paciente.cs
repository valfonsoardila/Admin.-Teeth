using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Paciente: Persona
    {
        public List<Cita> Citas { get; set; }
        public List<Pago> Pagos { get; set; }
    }
}
