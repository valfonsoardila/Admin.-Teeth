using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Pago
    {
        public string IdPago { get; set; }
        public DateTime Fecha { get; set; }
        public double Total { get; set; }
        public double SubTotal { get; set; }
        public double TotalIva { get; set; }
        public double Iva { get; set; }
        public string IdPaciente { get; set; }
        public string IdCita { get; set; }
        public List<DetallePago> Detalles { get; set; }

        public Pago()
        {

        }

        public Pago(List<Tratamiento> tratamientos, Paciente paciente)
        {
            IdPaciente = paciente.Identificacion;
            Detalles = new List<DetallePago>();
            Fecha = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy"));
            Iva = 19;
            AgregarDetalles(tratamientos);
        }

        public void AgregarDetalles(List<Tratamiento> tratamientos)
        {
            foreach (var tratamiento in tratamientos)
            {
                DetallePago detallePago = new DetallePago(tratamiento);
                detallePago.IdPago = IdPago;
                Detalles.Add(detallePago);
            }
            CalcularTodo();
        }

        public void CalcularTodo()
        {
            SubTotal = Detalles.Sum(d => d.Valor);
            TotalIva = SubTotal * (Iva / 100);
            Total = SubTotal + TotalIva;
        }
    }
}
