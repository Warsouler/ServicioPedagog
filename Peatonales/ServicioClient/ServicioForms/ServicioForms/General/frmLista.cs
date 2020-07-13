using Exceptions;
using ServicioForms.Controllers;
using ServicioForms.ViewModels;
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
    public partial class frmLista : Form
    {
        protected string myitem { get; set; }

        public frmLista()
        {
            InitializeComponent();
        }

        protected virtual void btnview_Click(object sender, EventArgs e)
        {
            if (dgvitems.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione " + myitem, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.ViewItem();
        }

        protected virtual void ViewItem()
        {
            throw new NotImplementedException();
        }

        protected virtual void btnupdate_Click(object sender, EventArgs e)
        {
            if (dgvitems.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione " + myitem, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.UpdateRow();
        }

       

        protected virtual void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvitems.SelectedRows.Count == 0)
                { 
                    MessageBox.Show("Seleccione " + myitem, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show("¿Está seguro/a que desea eliminar " + myitem + "?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                this.Delete();
                //BaseVM model = ConvertViewModel();
                //Mycontroller.Delete(model);
            }
            catch (Exception ex)
            {
                CompositeFillErrors cfe = HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
                if (cfe != null)
                {
                    MessageBox.Show(cfe.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Control[] errorscontrols = gbDates.Controls.Find(cfe.Field, false);
                    errorscontrols[0].Focus();
                }
            }
            
        }

        

        protected virtual void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        protected virtual void chkfilterdates_CheckedChanged(object sender, EventArgs e)
        {
            if (chkfilterdates.Checked)
            {
                dtpinitialdate.Enabled = true;
                dtpfinaldate.Enabled = true;
            }
            else
            {
                dtpinitialdate.Enabled = false;
                dtpfinaldate.Enabled = false;
            }

        }

      

        protected virtual void btnclearfilters_Click(object sender, EventArgs e)
        {
            txtfilter.Text = String.Empty;
            dtpinitialdate.Value = DateTime.Now;
            dtpfinaldate.Value = DateTime.Now;
            chkfilterdates.Checked = false;
        }

        protected virtual void dtpinitialdate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpinitialdate.Value > dtpfinaldate.Value)
                dtpfinaldate.Value = dtpinitialdate.Value;
        }

        protected virtual void dtpfinaldate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpinitialdate.Value > dtpfinaldate.Value)
                dtpfinaldate.Value = dtpinitialdate.Value;
        }

        protected virtual void CreateGrid()
        {
            throw new NotImplementedException();

        }
        protected virtual void FillItems(string filters)
        {
            throw new NotImplementedException();
        }

        protected virtual void UpdateRow()
        {
            throw new NotImplementedException();
        }

        protected virtual void Delete()
        {
            throw new NotImplementedException();
        }

        protected virtual void Restore()
        {
            throw new NotImplementedException();
        }


        protected virtual void EnableControls() { }

        protected virtual void DisableControls() { }

        protected virtual void VisibleControls() { }

        protected virtual void NotVisibleControls() { }

        protected virtual void dgvitems_SelectionChanged(object sender, EventArgs e)
        {

        }

        protected virtual void dgvitems_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {

        }

        protected virtual void dgvitems_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnrestore_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvitems.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccione " + myitem, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show("¿Está seguro/a que desea restaurar " + myitem + "?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                this.Restore();
                //BaseVM model = ConvertViewModel();
                //Mycontroller.Delete(model);
            }
            catch (Exception ex)
            {
                CompositeFillErrors cfe = HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
                if (cfe != null)
                {
                    MessageBox.Show(cfe.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Control[] errorscontrols = gbDates.Controls.Find(cfe.Field, false);
                    errorscontrols[0].Focus();
                }
            }
        }

        protected virtual void dgvitems_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {

        }
    }
}
