using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminTeeth
{
    public partial class MenuPrincipal : Form
    {
        int lx, ly;
        int sw, sh;
        int cantidadFormularios = 6;
        private int tolerance = 12;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;
        public MenuPrincipal()
        {
            InitializeComponent();
            Inicializar();
            hideSubMenu();
        }
        private void Inicializar()
        {
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;
            pictureBox3.Visible = false;
        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }

        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnMaximizar_Click(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
            BtnMaximizar.Visible = false;
            pictureBox3.Visible = true;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }

        private void BtnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            BtnMaximizar.Visible = true;
            pictureBox3.Visible = false;
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));
            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);
            region.Exclude(sizeGripRectangle);
            this.PnlContenedor.Region = region;
            this.Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(244, 244, 244));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);
            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
        }

        private void PnlTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void AbrirFormulario<MiForm>() where MiForm : Form, new()
        {
            Form formulario;
            formulario = PnlContenedorInterno.Controls.OfType<MiForm>().FirstOrDefault();
            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                PnlContenedorInterno.Controls.Add(formulario);
                PnlContenedorInterno.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
            }
            else
            {
                formulario.BringToFront();
            }
        }

        private void CerrarFormulario<MiForm>() where MiForm : Form, new()
        {
            Form formulario;
            formulario = PnlContenedorInterno.Controls.OfType<MiForm>().FirstOrDefault();
            if (formulario != null)
            {
                formulario.Close();
            }
        }
        private void CerrarFormularioSwicth(int FormularioCerrar)
        {
            switch (FormularioCerrar)
            {
                case 1:
                    CerrarFormulario<RegistrarPacientes>();
                    break;
                case 2:
                    CerrarFormulario<RegistrarOdontologo>();
                    break;
                case 3:
                    CerrarFormulario<ConsultarCita>();
                    break;
                case 4:
                    CerrarFormulario<ConsultarOdontologo>();
                    break;
                case 5:
                    CerrarFormulario<ConsultarPaciente>();
                    break;

                case 6:
                    CerrarFormulario<RegistrarObservaciones>();
                    break;
            }
        }
        private void CerrarFormulariosCiclo()
        {
            for (int i = 1; i <= cantidadFormularios; i++)
            {
                CerrarFormularioSwicth(i);
            }
        }
        //Propiedades del menu
        private void hideSubMenu()
        {
            panelGestionarPaciente.Visible = false;
            panelGestionarOdontologo.Visible = false;
            panelGestionarCita.Visible = false;
        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }
        //Boton Gestionar Paciente
        private void btnGestionarPacinte_Click(object sender, EventArgs e)
        {
            showSubMenu(panelGestionarPaciente);
            panelSelectorGestionarPaciente.Location = btnGestionarPacinte.Location;
            panelSelectorGestionarPaciente.Visible = true;
            panelSelectorGestionarOdontologo.Visible = false;
            panelSelectorGestionarCita.Visible = false;
        }
        private void btnRegistrarPaciente_Click(object sender, EventArgs e)
        {
            CerrarFormulariosCiclo();
            AbrirFormulario<RegistrarPacientes>();
        }
        private void btnConsultarPaciente_Click_1(object sender, EventArgs e)
        {
            CerrarFormulariosCiclo();
            AbrirFormulario<ConsultarPaciente>();
        }
        private void btnConsutarObservacionesPaciente_Click(object sender, EventArgs e)
        {
            CerrarFormulariosCiclo();
            AbrirFormulario<ConsultarObservaciones>();
        }
        //Boton Gestionar Odontologo
        private void btnGestionarOdontologo_Click(object sender, EventArgs e)
        {
            showSubMenu(panelGestionarOdontologo);
            panelSelectorGestionarOdontologo.Location = btnGestionarOdontologo.Location;
            panelSelectorGestionarOdontologo.Visible = true;
            panelSelectorGestionarPaciente.Visible = false;
            panelSelectorGestionarCita.Visible = false;
        }
        private void btnRegistrarOdontologo_Click(object sender, EventArgs e)
        {
            CerrarFormulariosCiclo();
            AbrirFormulario<RegistrarOdontologo>();
        }
        private void btnConsultarOdontologo_Click(object sender, EventArgs e)
        {
            CerrarFormulariosCiclo();
            AbrirFormulario<ConsultarOdontologo>();
        }
        private void btnRegistrarObservacion_Click(object sender, EventArgs e)
        {
            CerrarFormulariosCiclo();
            AbrirFormulario<RegistrarObservaciones>();
        }
        private void btnConsutarObservacionesOdontologo_Click(object sender, EventArgs e)
        {
            CerrarFormulariosCiclo();
            AbrirFormulario<ConsultarObservaciones>();
        }
        //Boton Gestionar Cita
        private void btnGestionarCita_Click(object sender, EventArgs e)
        {
            showSubMenu(panelGestionarCita);
            panelSelectorGestionarCita.Location = btnGestionarCita.Location;
            panelSelectorGestionarCita.Visible = true;
            panelSelectorGestionarPaciente.Visible = false;
            panelSelectorGestionarOdontologo.Visible = false;
        }
        private void btnAgendarCita_Click(object sender, EventArgs e)
        {
            CerrarFormulariosCiclo();
            AbrirFormulario<AgendarCita>();
        }
        private void btnConsultarCita_Click(object sender, EventArgs e)
        {
            CerrarFormulariosCiclo();
            AbrirFormulario<ConsultarCita>();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
    }
}
