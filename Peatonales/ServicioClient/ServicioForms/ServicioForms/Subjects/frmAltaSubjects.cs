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

namespace ServicioForms.Subjects
{
    public partial class frmAltaSubjects : ServicioForms.Subjects.frmBaseSubjects
    {
        private SubjectsController _controller;

        private SubjectsController Controller
        {
            get
            {
                if (_controller == null)
                    _controller = new SubjectsController();
                return _controller;
            }

            set
            {
                _controller = value;
            }
        }
        public frmAltaSubjects()
        {
            InitializeComponent();
        }

        

        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateEmpty(txtname))
                {
                    if (MessageBox.Show("¿Está seguro que desea dar de alta la asignatura "+txtname.Text+"?", "Asignatura", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;
                    SubjectsVM model = new SubjectsVM() { name = txtname.Text.Trim(), idcycle = 1};
                    Controller.Create(model);
                    MessageBox.Show("La asignatura se ha creado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
