using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using Bll;

namespace AdminTeeth
{
    public partial class ConsultarPaciente : Form
    {
        private readonly PacienteService service;
        public List<Paciente> pacientes;
        public ConsultarPaciente()
        {
            InitializeComponent();
            pacientes = new List<Paciente>();
            service = new PacienteService(ConfigConection.ConfiguracionDB);
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LlenarLabel(List<Paciente> paciente)
        {
            foreach(var item in paciente)
            {
                labelNombrePaciente.Text = item.Nombres;
                labelApellidoPaciente.Text = item.Apellidos;
                labelNacimientoPaciente.Text = Convert.ToString(item.FechaNacimiento);
            }
        }

        private void mostrarDatos()
        {
            BuscarPacienteResponse response = new BuscarPacienteResponse();
            string identificacion = textBoxIdentificacion.Text;
            response= service.BuscarPorIdentificacion(identificacion);
            pacientes = response.Pacientes.ToList();
            if (!response.Error)
            {
                LlenarLabel(pacientes);
            }
            else
            {
                MessageBox.Show(response.Mensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            mostrarDatos();
        }
    }
}
