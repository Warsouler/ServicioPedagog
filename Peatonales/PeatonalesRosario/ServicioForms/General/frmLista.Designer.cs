namespace ServicioForms.General
{
    partial class frmLista
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLista));
            this.bgactions = new System.Windows.Forms.GroupBox();
            this.gblist = new System.Windows.Forms.GroupBox();
            this.dgvitems = new System.Windows.Forms.DataGridView();
            this.gbfilters = new System.Windows.Forms.GroupBox();
            this.gbDates = new System.Windows.Forms.GroupBox();
            this.chkfilterdates = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpfinaldate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpinitialdate = new System.Windows.Forms.DateTimePicker();
            this.txtfilter = new System.Windows.Forms.TextBox();
            this.lblsearch = new System.Windows.Forms.Label();
            this.btnclearfilters = new System.Windows.Forms.Button();
            this.btnsearch = new System.Windows.Forms.Button();
            this.btnnew = new System.Windows.Forms.Button();
            this.btnview = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.btnupdate = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnrestore = new System.Windows.Forms.Button();
            this.bgactions.SuspendLayout();
            this.gblist.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvitems)).BeginInit();
            this.gbfilters.SuspendLayout();
            this.gbDates.SuspendLayout();
            this.SuspendLayout();
            // 
            // bgactions
            // 
            this.bgactions.Controls.Add(this.btnrestore);
            this.bgactions.Controls.Add(this.btnnew);
            this.bgactions.Controls.Add(this.btnview);
            this.bgactions.Controls.Add(this.btndelete);
            this.bgactions.Controls.Add(this.btnupdate);
            this.bgactions.Controls.Add(this.btnSalir);
            this.bgactions.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.bgactions.Location = new System.Drawing.Point(815, 7);
            this.bgactions.Name = "bgactions";
            this.bgactions.Size = new System.Drawing.Size(189, 711);
            this.bgactions.TabIndex = 3;
            this.bgactions.TabStop = false;
            this.bgactions.Text = "Acciones";
            // 
            // gblist
            // 
            this.gblist.Controls.Add(this.dgvitems);
            this.gblist.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.gblist.Location = new System.Drawing.Point(278, 7);
            this.gblist.Name = "gblist";
            this.gblist.Size = new System.Drawing.Size(531, 711);
            this.gblist.TabIndex = 2;
            this.gblist.TabStop = false;
            this.gblist.Text = "Listado";
            // 
            // dgvitems
            // 
            this.dgvitems.AllowUserToAddRows = false;
            this.dgvitems.AllowUserToDeleteRows = false;
            this.dgvitems.AllowUserToOrderColumns = true;
            this.dgvitems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvitems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvitems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvitems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvitems.Location = new System.Drawing.Point(3, 19);
            this.dgvitems.MultiSelect = false;
            this.dgvitems.Name = "dgvitems";
            this.dgvitems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvitems.Size = new System.Drawing.Size(525, 689);
            this.dgvitems.TabIndex = 0;
            this.dgvitems.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvitems_RowEnter);
            this.dgvitems.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvitems_RowPrePaint);
            this.dgvitems.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvitems_RowStateChanged);
            this.dgvitems.SelectionChanged += new System.EventHandler(this.dgvitems_SelectionChanged);
            // 
            // gbfilters
            // 
            this.gbfilters.Controls.Add(this.btnclearfilters);
            this.gbfilters.Controls.Add(this.gbDates);
            this.gbfilters.Controls.Add(this.btnsearch);
            this.gbfilters.Controls.Add(this.txtfilter);
            this.gbfilters.Controls.Add(this.lblsearch);
            this.gbfilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.gbfilters.Location = new System.Drawing.Point(12, 7);
            this.gbfilters.Name = "gbfilters";
            this.gbfilters.Size = new System.Drawing.Size(260, 711);
            this.gbfilters.TabIndex = 5;
            this.gbfilters.TabStop = false;
            this.gbfilters.Text = "Filtros";
            // 
            // gbDates
            // 
            this.gbDates.Controls.Add(this.chkfilterdates);
            this.gbDates.Controls.Add(this.label1);
            this.gbDates.Controls.Add(this.dtpfinaldate);
            this.gbDates.Controls.Add(this.label2);
            this.gbDates.Controls.Add(this.dtpinitialdate);
            this.gbDates.Location = new System.Drawing.Point(3, 151);
            this.gbDates.Name = "gbDates";
            this.gbDates.Size = new System.Drawing.Size(254, 205);
            this.gbDates.TabIndex = 8;
            this.gbDates.TabStop = false;
            this.gbDates.Text = "Fechas";
            // 
            // chkfilterdates
            // 
            this.chkfilterdates.AutoSize = true;
            this.chkfilterdates.Checked = true;
            this.chkfilterdates.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkfilterdates.Location = new System.Drawing.Point(6, 27);
            this.chkfilterdates.Name = "chkfilterdates";
            this.chkfilterdates.Size = new System.Drawing.Size(116, 21);
            this.chkfilterdates.TabIndex = 7;
            this.chkfilterdates.Text = "&Utilizar fechas";
            this.chkfilterdates.UseVisualStyleBackColor = true;
            this.chkfilterdates.CheckedChanged += new System.EventHandler(this.chkfilterdates_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Fecha desde";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpfinaldate
            // 
            this.dtpfinaldate.Location = new System.Drawing.Point(3, 164);
            this.dtpfinaldate.Name = "dtpfinaldate";
            this.dtpfinaldate.Size = new System.Drawing.Size(248, 23);
            this.dtpfinaldate.TabIndex = 6;
            this.dtpfinaldate.ValueChanged += new System.EventHandler(this.dtpfinaldate_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Fecha hasta";
            // 
            // dtpinitialdate
            // 
            this.dtpinitialdate.Location = new System.Drawing.Point(3, 103);
            this.dtpinitialdate.Name = "dtpinitialdate";
            this.dtpinitialdate.Size = new System.Drawing.Size(248, 23);
            this.dtpinitialdate.TabIndex = 5;
            this.dtpinitialdate.ValueChanged += new System.EventHandler(this.dtpinitialdate_ValueChanged);
            // 
            // txtfilter
            // 
            this.txtfilter.Location = new System.Drawing.Point(6, 112);
            this.txtfilter.MaxLength = 200;
            this.txtfilter.Name = "txtfilter";
            this.txtfilter.Size = new System.Drawing.Size(248, 23);
            this.txtfilter.TabIndex = 1;
            // 
            // lblsearch
            // 
            this.lblsearch.AutoSize = true;
            this.lblsearch.Location = new System.Drawing.Point(99, 92);
            this.lblsearch.Name = "lblsearch";
            this.lblsearch.Size = new System.Drawing.Size(46, 17);
            this.lblsearch.TabIndex = 0;
            this.lblsearch.Text = "label1";
            // 
            // btnclearfilters
            // 
            this.btnclearfilters.Image = ((System.Drawing.Image)(resources.GetObject("btnclearfilters.Image")));
            this.btnclearfilters.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnclearfilters.Location = new System.Drawing.Point(6, 660);
            this.btnclearfilters.Name = "btnclearfilters";
            this.btnclearfilters.Size = new System.Drawing.Size(248, 45);
            this.btnclearfilters.TabIndex = 9;
            this.btnclearfilters.Text = "&Limpiar Filtros";
            this.btnclearfilters.UseVisualStyleBackColor = true;
            this.btnclearfilters.Click += new System.EventHandler(this.btnclearfilters_Click);
            // 
            // btnsearch
            // 
            this.btnsearch.Image = global::ServicioForms.Properties.Resources.search36;
            this.btnsearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsearch.Location = new System.Drawing.Point(6, 33);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(248, 45);
            this.btnsearch.TabIndex = 2;
            this.btnsearch.Text = "&Buscar";
            this.btnsearch.UseVisualStyleBackColor = true;
            // 
            // btnnew
            // 
            this.btnnew.Font = new System.Drawing.Font("Lucida Sans", 10F);
            this.btnnew.Image = global::ServicioForms.Properties.Resources.add;
            this.btnnew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnnew.Location = new System.Drawing.Point(7, 22);
            this.btnnew.Name = "btnnew";
            this.btnnew.Size = new System.Drawing.Size(172, 72);
            this.btnnew.TabIndex = 4;
            this.btnnew.Text = "&Nuevo";
            this.btnnew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnnew.UseVisualStyleBackColor = true;
            // 
            // btnview
            // 
            this.btnview.Font = new System.Drawing.Font("Lucida Sans", 10F);
            this.btnview.Image = global::ServicioForms.Properties.Resources.icons8_eye_64;
            this.btnview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnview.Location = new System.Drawing.Point(7, 100);
            this.btnview.Name = "btnview";
            this.btnview.Size = new System.Drawing.Size(172, 72);
            this.btnview.TabIndex = 3;
            this.btnview.Text = "&Visualizar";
            this.btnview.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnview.UseVisualStyleBackColor = true;
            this.btnview.Click += new System.EventHandler(this.btnview_Click);
            // 
            // btndelete
            // 
            this.btndelete.Font = new System.Drawing.Font("Lucida Sans", 10F);
            this.btndelete.Image = global::ServicioForms.Properties.Resources.Button_Close_icon;
            this.btndelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndelete.Location = new System.Drawing.Point(7, 256);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(172, 72);
            this.btndelete.TabIndex = 2;
            this.btndelete.Text = "&Eliminar";
            this.btndelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btnupdate
            // 
            this.btnupdate.Font = new System.Drawing.Font("Lucida Sans", 10F);
            this.btnupdate.Image = global::ServicioForms.Properties.Resources.update_icon;
            this.btnupdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnupdate.Location = new System.Drawing.Point(7, 178);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(172, 72);
            this.btnupdate.TabIndex = 1;
            this.btnupdate.Text = "&Modificar";
            this.btnupdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnupdate.UseVisualStyleBackColor = true;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Lucida Sans", 10F);
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(10, 633);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(172, 72);
            this.btnSalir.TabIndex = 0;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnrestore
            // 
            this.btnrestore.Enabled = false;
            this.btnrestore.Font = new System.Drawing.Font("Lucida Sans", 10F);
            this.btnrestore.Image = global::ServicioForms.Properties.Resources.icons8_restart_64;
            this.btnrestore.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnrestore.Location = new System.Drawing.Point(6, 256);
            this.btnrestore.Name = "btnrestore";
            this.btnrestore.Size = new System.Drawing.Size(172, 72);
            this.btnrestore.TabIndex = 5;
            this.btnrestore.Text = "&Restaurar";
            this.btnrestore.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnrestore.UseVisualStyleBackColor = true;
            this.btnrestore.Visible = false;
            this.btnrestore.Click += new System.EventHandler(this.btnrestore_Click);
            // 
            // frmLista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.gbfilters);
            this.Controls.Add(this.bgactions);
            this.Controls.Add(this.gblist);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmLista";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista";
            this.bgactions.ResumeLayout(false);
            this.gblist.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvitems)).EndInit();
            this.gbfilters.ResumeLayout(false);
            this.gbfilters.PerformLayout();
            this.gbDates.ResumeLayout(false);
            this.gbDates.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Button btnSalir;
        public System.Windows.Forms.Button btnview;
        public System.Windows.Forms.Button btndelete;
        public System.Windows.Forms.Button btnupdate;
        protected System.Windows.Forms.GroupBox gbfilters;
        protected System.Windows.Forms.Button btnsearch;
        protected System.Windows.Forms.TextBox txtfilter;
        protected System.Windows.Forms.Label lblsearch;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.DateTimePicker dtpfinaldate;
        protected System.Windows.Forms.DateTimePicker dtpinitialdate;
        private System.Windows.Forms.CheckBox chkfilterdates;
        protected System.Windows.Forms.GroupBox bgactions;
        protected System.Windows.Forms.GroupBox gblist;
        protected System.Windows.Forms.Button btnclearfilters;
        public System.Windows.Forms.Button btnnew;
        protected System.Windows.Forms.GroupBox gbDates;
        public System.Windows.Forms.DataGridView dgvitems;
        protected System.Windows.Forms.Button btnrestore;
    }
}