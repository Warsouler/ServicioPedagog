using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServicioForms.General
{
    public partial class frmAlta : Form
    {
        public frmAlta()
        {
            InitializeComponent();
            HandlerActitivy(this.Controls);
        }

        protected virtual void HandlerActitivy(Control.ControlCollection controls)
        {
            //foreach (Control ctrl in controls)
            //{
            //    if (ctrl is TextBox)
            //    {
            //        TextBox txt = ctrl as TextBox;
            //        //txt.TextChanged += new EventHandler(txt_TextChanged);
            //    }
            //    if (ctrl is ComboBox)
            //    {
            //        ComboBox cmb = ctrl as ComboBox;
            //        //cmb.SelectedIndexChanged += new EventHandler(cmb_SelectedIndexChanged);
            //    }
            //    if (ctrl is CheckBox)
            //    {
            //        CheckBox chk = ctrl as CheckBox;
            //        //chk.CheckedChanged += new EventHandler(chk_CheckedChanged);
            //    }
            //    if (ctrl is GroupBox)
            //    {
            //        if (ctrl.HasChildren)
            //        {
            //            HandlerActitivy(ctrl.Controls);
            //        }
            //    }
            //}
        }




        protected virtual void EnableControls() { }




        protected virtual void DisableControls() { }


        protected virtual void CleanForm() { }

        protected virtual void DisableControls(Control.ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                ctrl.Enabled = false;
            }

        }


        protected virtual void EnableControls(Control.ControlCollection controls)
        {

            foreach (Control ctrl in controls)
            {
                ctrl.Enabled = true;
            }
        }



        protected virtual bool ValidateEmpty(Control.ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox txt = ctrl as TextBox;
                    if (String.IsNullOrEmpty(txt.Text))
                    { 
                        MessageBox.Show("Debe ingresar " + txt.Tag, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt.Focus();
                        return false;
                    }
                }
                if (ctrl is ComboBox)
                {
                    ComboBox cmb = ctrl as ComboBox;
                    if (String.IsNullOrEmpty(cmb.Text) || cmb.SelectedIndex == -1)
                    {
                        MessageBox.Show("Debe seleccionar una opción en el campo " + cmb.Tag, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cmb.Focus();
                        return false;
                    }
                }
                if (ctrl is CheckBox)
                {
                    CheckBox chk = ctrl as CheckBox;
                    if (chk.Checked == false)
                    {
                        MessageBox.Show("Debe checkear el campo " + chk.Tag, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        chk.Focus();
                        return false;
                    }
                }
                if (ctrl is GroupBox)
                {
                    if (ctrl.HasChildren)
                    {
                        ValidateEmpty(ctrl.Controls);
                    }
                }
               
            }
            return true;
        }

        protected virtual void CleanForm(Control.ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox txt = ctrl as TextBox;
                    txt.Text = String.Empty;
                    continue;
                }
                if (ctrl is ComboBox)
                {
                    ComboBox cmb = ctrl as ComboBox;
                    cmb.SelectedIndex = -1;
                    cmb.SelectedText = String.Empty;
                    cmb.SelectedValue = -1;
                    continue;
                }
                if (ctrl is CheckBox)
                {
                    CheckBox chk = ctrl as CheckBox;
                    chk.Checked = false;
                    continue;
                }
                if (ctrl is GroupBox)
                {
                    if (ctrl.HasChildren)
                    {
                        CleanForm(ctrl.Controls);
                    }
                }
            }
        }

        

        protected virtual bool ValidateEmpty(Control ctrl)
        {
           
                if (ctrl is TextBox)
                {
                    TextBox txt = ctrl as TextBox;
                    if (String.IsNullOrEmpty(txt.Text))
                    {
                        MessageBox.Show("Debe ingresar " + txt.Tag, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt.Focus();
                        return false;
                    }
                
                }
                if (ctrl is ComboBox)
                {
                    ComboBox cmb = ctrl as ComboBox;
                    if (String.IsNullOrEmpty(cmb.Text) || cmb.SelectedIndex == -1)
                    {
                        MessageBox.Show("Debe seleccionar una opción en el campo " + cmb.Tag, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cmb.Focus();
                        return false;
                    }
                }
                if (ctrl is CheckBox)
                {
                    CheckBox chk = ctrl as CheckBox;
                    if (chk.Checked == false)
                    {
                        MessageBox.Show("Debe checkear el campo " + chk.Tag, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        chk.Focus();
                        return false;
                    }
                }
                if (ctrl is GroupBox)
                {
                    if (ctrl.HasChildren)
                    {
                        ValidateEmpty(ctrl.Controls);
                    }
                }
            return true;

        }

        protected virtual void btnSalir_Click(object sender, EventArgs e)
        {
                this.Close();
        }

        protected virtual void frmAlta_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea volver?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;

        }

        protected virtual void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
