using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Cita
    {
        public string IdOdontologo { get; set; }
        public string IdPaciente { get; set; }
        public List<Tratamiento> Tratamientos { get; set; }
        public DateTime Fecha { get; set; }
        public string IdPago { get; set; }
    }
}
