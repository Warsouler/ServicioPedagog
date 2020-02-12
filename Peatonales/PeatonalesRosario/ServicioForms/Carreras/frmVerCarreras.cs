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
    public partial class frmVerCarreras : ServicioForms.Carreras.frmBaseCarreras
    {
        public frmVerCarreras()
        {
            InitializeComponent();
        }

        protected override void frmAlta_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private CareersVM _vm;


        public frmVerCarreras(CareersVM vm)
        {
            InitializeComponent();
            _vm = vm;
            this.txtname.Text = _vm.name;
        }

    }
}
