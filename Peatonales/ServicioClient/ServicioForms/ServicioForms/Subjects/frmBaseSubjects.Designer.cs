namespace ServicioForms.Subjects
{
    partial class frmBaseSubjects
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtname = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtname);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Size = new System.Drawing.Size(761, 226);
            this.groupBox1.Controls.SetChildIndex(this.btnCrear, 0);
            this.groupBox1.Controls.SetChildIndex(this.btnCancelar, 0);
            this.groupBox1.Controls.SetChildIndex(this.label1, 0);
            this.groupBox1.Controls.SetChildIndex(this.txtname, 0);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(6, 142);
            // 
            // btnCrear
            // 
            this.btnCrear.Location = new System.Drawing.Point(550, 142);
            // 
            // groupBox2
            // 
            this.groupBox2.Size = new System.Drawing.Size(225, 226);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(12, 142);
            // 
            // btnclean
            // 
            this.btnclean.Location = new System.Drawing.Point(12, 52);
            this.btnclean.Click += new System.EventHandler(this.btnclean_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre de la asignatura :";
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(177, 52);
            this.txtname.MaxLength = 100;
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(381, 23);
            this.txtname.TabIndex = 3;
            this.txtname.Tag = "el nombre de la asignatura";
            // 
            // frmBaseCarreras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1008, 245);
            this.Name = "frmBaseSubjects";
            this.Text = "frmBaseSubjects";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtname;
    }
}
