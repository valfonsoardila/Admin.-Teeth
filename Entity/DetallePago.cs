using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class DetallePago
    {
        public string Id { get; set; }
        public string IdPago { get; set; }
        public string IdTratamiento { get; set; }
        public double Valor { get; set; }

        public DetallePago()
        {

        }

        public DetallePago(Tratamiento tratamiento)
        {
            IdTratamiento = tratamiento.Id;
            Valor = tratamiento.Valor;
        }
    }
}
