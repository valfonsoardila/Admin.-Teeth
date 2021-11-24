using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Bll
{
    public class PacienteService
    {
        private readonly PacienteRepository repository;
        private readonly ConnectionManager connection;
        public PacienteService(string conexion)
        {
            connection = new ConnectionManager(conexion);
            repository = new PacienteRepository(connection);
        }

        public string Guardar(Paciente paciente)
        {
            try
            {
                connection.Open();
                repository.Guardar(paciente);
                return "Se a Guardado con Exito";
            }
            catch (Exception e)
            {
                return $"Error de la Alpicacion {e.Message}";
            }
            finally { connection.Close(); }

        }

        public BuscarPacienteResponse BuscarPorIdentificacion(string identificacion)
        {
            BuscarPacienteResponse response = new BuscarPacienteResponse();
            try
            {
                connection.Open();
                response.Pacientes = repository.BuscarPorIdentificacion(identificacion);
                response.Error = false;
                response.Mensaje = (response.Pacientes.Count > 0) ? "Se consultan los datos" : "No hay datos para consultar";
                return response;
            }
            catch (Exception e)
            {
                response.Mensaje = $"Error de la Aplicacion {e.Message}";
                response.Error = true;
                return response;
            }
            finally { connection.Close(); }
        }

        public ConsultarPacienteRespons Consultar()
        {
            ConsultarPacienteRespons respons = new ConsultarPacienteRespons();
            try
            {
                connection.Open();
                respons.Pacientes = repository.Consultar();
                respons.Error = false;
                respons.Mensaje = (respons.Pacientes.Count > 0) ? "Se consultan los datos" : "No hay datos para consultar";
                return respons;
            }
            catch (Exception e)
            {
                respons.Error = true;
                respons.Mensaje = $"Error de la Aplicacion: {e.Message}";
                return respons;
            }
            finally { connection.Close(); }
        }

    }

    public class ConsultarPacienteRespons{
        public List<Paciente> Pacientes { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }
    }

    public class BuscarPacienteResponse
    {
        public string Mensaje { get; set; }
        public bool Error { get; set; }
        public IList<Paciente> Pacientes { get; set; }
    }

}
