using ServicioForms.Controllers;
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
    public partial class Login : Form
    {
        DialogResult result;
        LoginController _controller;
        public Login()
        {
            InitializeComponent();
            this.txtUser.Focus();
        }

        public LoginController Controller
        {
            get
            {
                if (_controller == null)
                    _controller = new LoginController();
                return _controller;
            }

            set
            {
                _controller = value;
            }
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtUser.Text.Trim()))
            { 
                MessageBox.Show("Ingrese su nombre de usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUser.Focus();
                return;
            }
            if ( String.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                MessageBox.Show("Ingrese su contraseña", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return;
            }
            else
            {
                string result= Controller.Login(txtUser.Text.Trim(), txtPassword.Text.Trim()).Result;
                if (result == "")
                {
                    frmMenu menu = new frmMenu();
                    menu.ShowDialog();
                }
                else
                {
                    MessageBox.Show(result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                    
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
           result = MessageBox.Show("¿Desea salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                ApplicationsVariables.Token = null;
                Application.Exit();
            }
                
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea salir del sistema?", "Aplicación",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                return;
            else
                e.Cancel = true;
        }
    }
}
