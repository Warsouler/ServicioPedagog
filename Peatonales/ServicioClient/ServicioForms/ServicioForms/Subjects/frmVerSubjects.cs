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
    public partial class frmVerSubjects : ServicioForms.Subjects.frmBaseSubjects
    {
        public frmVerSubjects()
        {
            InitializeComponent();
        }

        protected override void frmAlta_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private SubjectsVM _vm;


        public frmVerSubjects(SubjectsVM vm)
        {
            InitializeComponent();
            _vm = vm;
            this.txtname.Text = _vm.name;
        }

    }
}
