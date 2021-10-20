namespace ServicioForms.Subjects
{
    partial class frmListaSubjects
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbfilters.SuspendLayout();
            this.bgactions.SuspendLayout();
            this.gbDates.SuspendLayout();
            this.SuspendLayout();
            // 
            // btndelete
            // 
            this.btndelete.Image = global::ServicioForms.Properties.Resources.Button_Close_icon1;
            // 
            // btnsearch
            // 
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // txtfilter
            // 
            this.txtfilter.TextChanged += new System.EventHandler(this.txtfilter_TextChanged);
            // 
            // lblsearch
            // 
            this.lblsearch.Size = new System.Drawing.Size(58, 17);
            this.lblsearch.Text = "Nombre";
            // 
            // btnnew
            // 
            this.btnnew.Click += new System.EventHandler(this.btnnew_Click);
            // 
            // gbDates
            // 
            this.gbDates.Enabled = false;
            this.gbDates.Visible = false;
            // 
            // frmListaCarreras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Name = "frmListaSubjects";
            this.Text = "Listado de asignaturas";
            this.gbfilters.ResumeLayout(false);
            this.gbfilters.PerformLayout();
            this.bgactions.ResumeLayout(false);
            this.gbDates.ResumeLayout(false);
            this.gbDates.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
