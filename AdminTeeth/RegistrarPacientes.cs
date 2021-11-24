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
    public partial class RegistrarPacientes : Form
    {
        private readonly PacienteService service;
        public RegistrarPacientes()
        {
            InitializeComponent();
            service = new PacienteService(ConfigConection.ConfiguracionDB);
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private Paciente GuardarCampos()
        {
            Paciente paciente = new Paciente();
            paciente.Identificacion = textBoxIdentifiacion.Text;
            paciente.Nombres = textBoxNombres.Text;
            paciente.Apellidos = textBoxApellidos.Text;
            paciente.FechaNacimiento = dateTimePickerFechaNacimiento.Value;
            return paciente;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxIdentifiacion.Text.Equals(""))
            {
                MessageBox.Show("El campo esta vacio", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Paciente paciente = GuardarCampos();
                string mensaje = service.Guardar(paciente);
                MessageBox.Show(mensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            

        }
    }
}
