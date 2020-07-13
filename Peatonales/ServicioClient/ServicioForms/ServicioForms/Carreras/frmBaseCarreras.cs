using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ServicioForms.Carreras
{
    public partial class frmBaseCarreras : ServicioForms.General.frmAlta
    {
        public bool modified = false;
        public frmBaseCarreras()
        {
            InitializeComponent();
            txtname.Focus();
        }

        protected virtual void btnclean_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro/a que desea limpiar el formulario?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            this.CleanForm(groupBox1.Controls);
        }
    }
}
