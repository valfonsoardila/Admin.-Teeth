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
        public double Total { get; set; }
        public double SubTotal { get; set; }
        public double Iva { get; set; }
    }
}
