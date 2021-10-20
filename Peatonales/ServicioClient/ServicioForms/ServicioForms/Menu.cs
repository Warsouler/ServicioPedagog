using ServicioForms.Carreras;
using ServicioForms.Subjects;
using ServicioForms.General;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServicioForms
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
            if (ApplicationsVariables.Datavalues.Roles.Contains("Admin"))
            { 
                gbAdministracion.Enabled = true;
                gbAdministracion.Visible = true;
            }
        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {

            ApplicationsVariables.Token = null;
            ApplicationsVariables.Username = null;
            ApplicationsVariables.Datavalues = null;
            
        }

        private void btnCarreras_Click(object sender, EventArgs e)
        {
            frmListaCarreras lc = new frmListaCarreras();
            lc.ShowDialog();
        }

        private void btnMaterias_Click(object sender, EventArgs e)
        {

            frmListaSubjects lc = new frmListaSubjects();
            lc.ShowDialog();

        }

        private void btnAlumnos_Click(object sender, EventArgs e)
        {

        }

        private void btnDiagnostico_Click(object sender, EventArgs e)
        {

        }

        private void btnSeguimiento_Click(object sender, EventArgs e)
        {

        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {

        }

        private void btnHistorialUso_Click(object sender, EventArgs e)
        {

        }
    }
}
