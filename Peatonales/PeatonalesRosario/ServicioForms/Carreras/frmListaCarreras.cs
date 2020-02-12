using ServicioForms.Controllers;
using ServicioForms.General;
using ServicioForms.Properties;
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
    public partial class frmListaCarreras : ServicioForms.General.frmLista
    {
        CareersAllController _controller;

        public CareersAllController Controller
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

        public frmListaCarreras()
        {
            InitializeComponent();

            ApplicationsVariables.Token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTM4NCJ9.eyJuYW1laWQiOiJhZWI2OThlYy1hYzlmLTQ2MmMtODBiZi0xYTc1Y2Y3MWYxZmEiLCJ1bmlxdWVfbmFtZSI6IkFtZWxpYSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vYWNjZXNzY29udHJvbHNlcnZpY2UvMjAxMC8wNy9jbGFpbXMvaWRlbnRpdHlwcm92aWRlciI6IkFTUC5ORVQgSWRlbnRpdHkiLCJBc3BOZXQuSWRlbnRpdHkuU2VjdXJpdHlTdGFtcCI6IjA4NWQ2MzkyLWQ5YzYtNDVlOS05ZTFjLWY1ODA3ZmJiNjRlYiIsInJvbGUiOiJBZG1pbiIsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6ODEwNSIsImF1ZCI6IlR3aWNlVGFsZW50IiwiZXhwIjoxNTU4NTU0MzY3LCJuYmYiOjE1Mjc0NTAzNjd9.QQZa_GggOQnK4ZgKS-BenMNCYCS-lTIsGiUuh0PFHqYLgoRdu2_rLPSQ3RTV0tP5";
            this.myitem = "una carrera.";
            this.CreateGrid();
            this.FillItems(String.Empty);
        }


        protected override void CreateGrid()
        {
            // I created these columns at function scope but if you want to access 
            // easily from other parts of your class, just move them to class scope.
            // E.g. Declare them outside of the function...

            this.dgvitems.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.HeaderText = "Nombre";
            col1.Name = "name";
            col1.DataPropertyName = "name";

            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            col2.HeaderText = "Estado";
            col2.Name = "statevalue";
            col2.DataPropertyName = "statevalue";


            this.dgvitems.Columns.AddRange(new DataGridViewColumn[] {col1,col2});

            

        }
        protected override void FillItems(string filters)
        {
           this.dgvitems.DataSource = null;
           this.dgvitems.Rows.Clear();
           this.dgvitems.DataSource=Controller.GetAll(filters);

            //foreach (DataGridViewRow row in this.dgvitems.Rows)
            //{
            //    if (((CareersVM)row.DataBoundItem).state == (Int32)EnumStates.Anulado)
            //    {
            //        row.DefaultCellStyle.BackColor = Color.Red;
            //    }

            //}

        }

        protected override void dgvitems_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (((CareersVM)this.dgvitems.Rows[e.RowIndex].DataBoundItem).state == (Int32)EnumStates.Anulado)
            {
                this.dgvitems.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightCoral;
            }
            
        }






        protected override void EnableControls() { }

        protected override void DisableControls() { }

        protected override void VisibleControls() { }

        protected override void NotVisibleControls() { }

        protected override void UpdateRow()
        {

            frmModificarCarreras frm = new frmModificarCarreras((CareersVM)this.dgvitems.SelectedRows[0].DataBoundItem);
            frm.ShowDialog();
            if (frm.modified)
                this.FillItems(String.Empty);
        }
        protected override void Delete()
        {
            try
            {
                Controller.Delete((CareersVM)this.dgvitems.SelectedRows[0].DataBoundItem);
                MessageBox.Show("La carrera se ha dado de baja correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.FillItems(String.Empty);
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        protected override void Restore()
        {
            try
            {
                CareersVM _vm = (CareersVM)this.dgvitems.SelectedRows[0].DataBoundItem;
                _vm.state = (Int32)EnumStates.Activo;
                Controller.Update(_vm);
                MessageBox.Show("La carrera se ha dado restaurado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.FillItems(String.Empty);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected override void ViewItem()
        {
            frmVerCarreras frm = new frmVerCarreras((CareersVM)this.dgvitems.SelectedRows[0].DataBoundItem);
            frm.ShowDialog();
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            frmAltaCarrera frm = new frmAltaCarrera();
            frm.ShowDialog();
            if (frm.modified)
                this.FillItems(String.Empty);
        }



        private void btnsearch_Click(object sender, EventArgs e)
        {
            this.FillItems(txtfilter.Text.Trim());
        }

        private void txtfilter_TextChanged(object sender, EventArgs e)
        {
                this.FillItems(txtfilter.Text.Trim());
        }
        protected override void dgvitems_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvitems.Rows.Count > 0 && dgvitems.SelectedRows.Count > 0)
            {
                if (((CareersVM)dgvitems.SelectedRows[0].DataBoundItem).state == (Int32)EnumStates.Activo)
                {
                    
                    btnrestore.Enabled = false;
                    btnrestore.Visible = false;
                    btndelete.Enabled = true;
                    btndelete.Visible = true;
                    btndelete.BringToFront();
                    btnrestore.SendToBack();

                }
                else
                {
                   
                    btndelete.Enabled = false;
                    btndelete.Visible = false;
                    btnrestore.Enabled = true;
                    btnrestore.Visible = true;
                    btnrestore.BringToFront();
                    btndelete.SendToBack();

                }
            }
        }



        

    }
}

