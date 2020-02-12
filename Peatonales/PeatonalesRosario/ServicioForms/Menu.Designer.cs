namespace ServicioForms
{
    partial class frmMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnMaterias = new System.Windows.Forms.Button();
            this.btnCarreras = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAlumnos = new System.Windows.Forms.Button();
            this.btnDiagnostico = new System.Windows.Forms.Button();
            this.btnSeguimiento = new System.Windows.Forms.Button();
            this.gbAdministracion = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnHistorialUso = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.gbAdministracion.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(468, 246);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Académica";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnMaterias);
            this.flowLayoutPanel1.Controls.Add(this.btnCarreras);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 20);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(456, 220);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnMaterias
            // 
            this.btnMaterias.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnMaterias.Image = ((System.Drawing.Image)(resources.GetObject("btnMaterias.Image")));
            this.btnMaterias.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMaterias.Location = new System.Drawing.Point(3, 3);
            this.btnMaterias.Name = "btnMaterias";
            this.btnMaterias.Size = new System.Drawing.Size(219, 101);
            this.btnMaterias.TabIndex = 0;
            this.btnMaterias.Text = "As&ignaturas";
            this.btnMaterias.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMaterias.UseVisualStyleBackColor = true;
            this.btnMaterias.Click += new System.EventHandler(this.btnMaterias_Click);
            // 
            // btnCarreras
            // 
            this.btnCarreras.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnCarreras.Image = ((System.Drawing.Image)(resources.GetObject("btnCarreras.Image")));
            this.btnCarreras.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCarreras.Location = new System.Drawing.Point(228, 3);
            this.btnCarreras.Name = "btnCarreras";
            this.btnCarreras.Size = new System.Drawing.Size(219, 101);
            this.btnCarreras.TabIndex = 1;
            this.btnCarreras.Text = "&Carreras";
            this.btnCarreras.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCarreras.UseVisualStyleBackColor = true;
            this.btnCarreras.Click += new System.EventHandler(this.btnCarreras_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.flowLayoutPanel2);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBox2.Location = new System.Drawing.Point(516, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(468, 246);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Alumnos";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnAlumnos);
            this.flowLayoutPanel2.Controls.Add(this.btnDiagnostico);
            this.flowLayoutPanel2.Controls.Add(this.btnSeguimiento);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(6, 21);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(456, 220);
            this.flowLayoutPanel2.TabIndex = 2;
            // 
            // btnAlumnos
            // 
            this.btnAlumnos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnAlumnos.Image = ((System.Drawing.Image)(resources.GetObject("btnAlumnos.Image")));
            this.btnAlumnos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAlumnos.Location = new System.Drawing.Point(3, 3);
            this.btnAlumnos.Name = "btnAlumnos";
            this.btnAlumnos.Size = new System.Drawing.Size(219, 101);
            this.btnAlumnos.TabIndex = 0;
            this.btnAlumnos.Text = "&Alumnos";
            this.btnAlumnos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAlumnos.UseVisualStyleBackColor = true;
            this.btnAlumnos.Click += new System.EventHandler(this.btnAlumnos_Click);
            // 
            // btnDiagnostico
            // 
            this.btnDiagnostico.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnDiagnostico.Image = ((System.Drawing.Image)(resources.GetObject("btnDiagnostico.Image")));
            this.btnDiagnostico.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDiagnostico.Location = new System.Drawing.Point(228, 3);
            this.btnDiagnostico.Name = "btnDiagnostico";
            this.btnDiagnostico.Size = new System.Drawing.Size(219, 101);
            this.btnDiagnostico.TabIndex = 1;
            this.btnDiagnostico.Text = "&Diagnósticos";
            this.btnDiagnostico.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDiagnostico.UseVisualStyleBackColor = true;
            this.btnDiagnostico.Click += new System.EventHandler(this.btnDiagnostico_Click);
            // 
            // btnSeguimiento
            // 
            this.btnSeguimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnSeguimiento.Image = ((System.Drawing.Image)(resources.GetObject("btnSeguimiento.Image")));
            this.btnSeguimiento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeguimiento.Location = new System.Drawing.Point(3, 110);
            this.btnSeguimiento.Name = "btnSeguimiento";
            this.btnSeguimiento.Size = new System.Drawing.Size(219, 101);
            this.btnSeguimiento.TabIndex = 2;
            this.btnSeguimiento.Text = "&Seguimientos";
            this.btnSeguimiento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSeguimiento.UseVisualStyleBackColor = true;
            this.btnSeguimiento.Click += new System.EventHandler(this.btnSeguimiento_Click);
            // 
            // gbAdministracion
            // 
            this.gbAdministracion.Controls.Add(this.flowLayoutPanel3);
            this.gbAdministracion.Enabled = false;
            this.gbAdministracion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.gbAdministracion.Location = new System.Drawing.Point(12, 277);
            this.gbAdministracion.Name = "gbAdministracion";
            this.gbAdministracion.Size = new System.Drawing.Size(468, 246);
            this.gbAdministracion.TabIndex = 1;
            this.gbAdministracion.TabStop = false;
            this.gbAdministracion.Text = "Administración";
            this.gbAdministracion.Visible = false;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.btnUsuarios);
            this.flowLayoutPanel3.Controls.Add(this.btnHistorialUso);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(6, 20);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(456, 220);
            this.flowLayoutPanel3.TabIndex = 0;
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnUsuarios.Image = ((System.Drawing.Image)(resources.GetObject("btnUsuarios.Image")));
            this.btnUsuarios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsuarios.Location = new System.Drawing.Point(3, 3);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(219, 101);
            this.btnUsuarios.TabIndex = 0;
            this.btnUsuarios.Text = "&Usuarios";
            this.btnUsuarios.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUsuarios.UseVisualStyleBackColor = true;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // btnHistorialUso
            // 
            this.btnHistorialUso.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnHistorialUso.Image = ((System.Drawing.Image)(resources.GetObject("btnHistorialUso.Image")));
            this.btnHistorialUso.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHistorialUso.Location = new System.Drawing.Point(228, 3);
            this.btnHistorialUso.Name = "btnHistorialUso";
            this.btnHistorialUso.Size = new System.Drawing.Size(219, 101);
            this.btnHistorialUso.TabIndex = 1;
            this.btnHistorialUso.Text = "&Historial de uso";
            this.btnHistorialUso.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHistorialUso.UseVisualStyleBackColor = true;
            this.btnHistorialUso.Click += new System.EventHandler(this.btnHistorialUso_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(988, 554);
            this.Controls.Add(this.gbAdministracion);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menú";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Menu_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.gbAdministracion.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnMaterias;
        private System.Windows.Forms.Button btnCarreras;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btnAlumnos;
        private System.Windows.Forms.Button btnDiagnostico;
        private System.Windows.Forms.Button btnSeguimiento;
        private System.Windows.Forms.GroupBox gbAdministracion;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Button btnHistorialUso;
    }
}