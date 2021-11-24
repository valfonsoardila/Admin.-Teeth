using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entity;

namespace Dal
{
    public class PacienteRepository
    {
        private readonly SqlConnection connecion;
        public PacienteRepository(ConnectionManager connection)
        {
            connecion = connection._conexion;
        }

        public void Guardar(Paciente paciente)
        {
            using (var command = connecion.CreateCommand())
            {
                command.CommandText = "insert into Paciente(identificacion,nombres,apellidos,fechaNacimiento) values(@identificacion,@nombres,@apellidos,@fechaNacimiento)";
                command.Parameters.Add(new SqlParameter("@identificacion", paciente.Identificacion));
                command.Parameters.Add(new SqlParameter("@nombres", paciente.Nombres));
                command.Parameters.Add(new SqlParameter("@apellidos", paciente.Apellidos));
                command.Parameters.Add(new SqlParameter("@fechaNacimiento", paciente.FechaNacimiento));
                var filas = command.ExecuteNonQuery();
            }
        }

        private Paciente MapearPacientes(SqlDataReader Reader)
        {
            if (!Reader.HasRows) return null;
            Paciente paciente = new Paciente();
            paciente.Identificacion = Reader.GetString(0);
            paciente.Nombres = Reader.GetString(1);
            paciente.Apellidos = Reader.GetString(2);
            paciente.FechaNacimiento = Reader.GetDateTime(3);
            return paciente;
        }

        public List<Paciente> BuscarPorIdentificacion(string identificacion)
        {
            List<Paciente> pacientes = new List<Paciente>();
            using (var command = connecion.CreateCommand())
            {
                command.CommandText = "select * from Paciente where identificacion=@identificacion";
                command.Parameters.Add(new SqlParameter("@identificacion",identificacion));
                var Reader = command.ExecuteReader();
                while (Reader.Read())
                {
                    Paciente paciente = MapearPacientes(Reader);
                    pacientes.Add(paciente);
                }
                Reader.Close();
            }
            return pacientes;
        }

        public List<Paciente> Consultar()
        {
            List<Paciente> pacientes = new List<Paciente>();
            using (var command = connecion.CreateCommand())
            {
                command.CommandText = "select *from Paciente";
                var Reader = command.ExecuteReader();
                while (Reader.Read())
                {
                    Paciente paciente = new Paciente();
                    paciente.Identificacion = Reader.GetString(0);
                    paciente.Nombres = Reader.GetString(1);
                    paciente.Apellidos = Reader.GetString(2);
                    paciente.FechaNacimiento = Reader.GetDateTime(3);
                    pacientes.Add(paciente);
                }
                Reader.Close();
            }
            return pacientes;
        }

    }
}
