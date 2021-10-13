using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Odontologo : Persona
    {
        public string IdHorario { get; set; }
        public List<string> Citas { get; set; }
    }
}
