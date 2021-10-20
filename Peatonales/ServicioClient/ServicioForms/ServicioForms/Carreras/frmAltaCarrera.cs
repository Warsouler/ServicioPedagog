using Exceptions;
using ServicioForms.Controllers;
using ServicioForms.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ServicioForms.Carreras
{
    public partial class frmAltaCarrera : ServicioForms.Carreras.frmBaseCarreras
    {
        private CareersAllController _controller;

        private CareersAllController Controller
        {
            get
            {
                if (_controller == null)
                    _controller = new CareersAllController();
                return _controller;
            }

            set
            {
                _controller = value;
            }
        }
        public frmAltaCarrera()
        {
            InitializeComponent();
        }

        

        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateEmpty(txtname))
                {
                    if (MessageBox.Show("¿Está seguro que desea dar de alta la carrera "+txtname.Text+"?", "Carrera", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;
                    CareersVM model = new CareersVM() { name = txtname.Text.Trim() };
                    Controller.Create(model);
                    MessageBox.Show("La carrera se ha creado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtname.Text = String.Empty;
                    txtname.Focus();
                    this.modified = true;
                }

            }
            catch (Exception ex)
            {
                CompositeFillErrors cfe = HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
                if (cfe != null)
                {
                    MessageBox.Show(cfe.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Control[] errorscontrols= groupBox1.Controls.Find(cfe.Field,false);
                    errorscontrols[0].Focus();
                }

            }
        }
    }
}
