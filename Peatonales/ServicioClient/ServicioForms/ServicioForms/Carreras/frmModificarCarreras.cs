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
    public partial class frmModificarCarreras : ServicioForms.Carreras.frmBaseCarreras
    {
        private CareersAllController _controller;
        private CareersVM _vm;

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
        public frmModificarCarreras(CareersVM vm)
        {
            InitializeComponent();
            _vm = vm;
            this.txtname.Text = _vm.name;
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (ValidateEmpty(txtname))
            {
                if (MessageBox.Show("¿Está seguro que desea modificar la carrera?", "Carrera", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                _vm.name = txtname.Text.Trim();
                Controller.Update(_vm);
                MessageBox.Show("La carrera se ha modificado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.modified = true;
            }
                
        }
    }
}
