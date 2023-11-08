using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.UserControls.UI
{
    partial class ucAutorizaciones
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

        #region Visual WebGui UserControl Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtAutorizacionID = new Gizmox.WebGUI.Forms.TextBox();
            this.textBox2 = new Gizmox.WebGUI.Forms.TextBox();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.tSBDocumento = new SPF.UserControls.Base.ucTextSearchBox();
            this.textBox1 = new Gizmox.WebGUI.Forms.TextBox();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.textBox3 = new Gizmox.WebGUI.Forms.TextBox();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.tSBUsuarioAutorizado = new SPF.UserControls.Base.ucTextSearchBox();
            this.textBox4 = new Gizmox.WebGUI.Forms.TextBox();
            this.label7 = new Gizmox.WebGUI.Forms.Label();
            this.label8 = new Gizmox.WebGUI.Forms.Label();
            this.txtUsuarioAutorizadorID = new Gizmox.WebGUI.Forms.TextBox();
            this.txtUsuarioAutorizadorNombre = new Gizmox.WebGUI.Forms.TextBox();
            this.textBox7 = new Gizmox.WebGUI.Forms.TextBox();
            this.label9 = new Gizmox.WebGUI.Forms.Label();
            this.label10 = new Gizmox.WebGUI.Forms.Label();
            this.grpValidez = new Gizmox.WebGUI.Forms.GroupBox();
            this.dtpFechaHasta = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.label12 = new Gizmox.WebGUI.Forms.Label();
            this.textBox8 = new Gizmox.WebGUI.Forms.TextBox();
            this.label11 = new Gizmox.WebGUI.Forms.Label();
            this.txtFechaDesde = new Gizmox.WebGUI.Forms.TextBox();
            this.label14 = new Gizmox.WebGUI.Forms.Label();
            this.textBox10 = new Gizmox.WebGUI.Forms.TextBox();
            this.label13 = new Gizmox.WebGUI.Forms.Label();
            this.txtMotivo = new Gizmox.WebGUI.Forms.TextBox();
            this.textBox11 = new Gizmox.WebGUI.Forms.TextBox();
            this.label15 = new Gizmox.WebGUI.Forms.Label();
            this.label16 = new Gizmox.WebGUI.Forms.Label();
            this.textBox5 = new Gizmox.WebGUI.Forms.TextBox();
            this.label17 = new Gizmox.WebGUI.Forms.Label();
            this.label18 = new Gizmox.WebGUI.Forms.Label();
            this.txtDocumentoID = new Gizmox.WebGUI.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoABM)).BeginInit();
            this.pnlDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabListaABM)).BeginInit();
            this.pnlListadoContainer.SuspendLayout();
            this.pnlContainer.SuspendLayout();
            this.pnlTabControl.SuspendLayout();
            this.label1.SuspendLayout();
            this.label4.SuspendLayout();
            this.label6.SuspendLayout();
            this.label8.SuspendLayout();
            this.label10.SuspendLayout();
            this.grpValidez.SuspendLayout();
            this.label12.SuspendLayout();
            this.label14.SuspendLayout();
            this.label16.SuspendLayout();
            this.label18.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvListadoABM
            // 
            this.dgvListadoABM.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.dgvListadoABM.Size = new System.Drawing.Size(912, 418);
            this.dgvListadoABM.RowEnter += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.dgvListadoABM_RowEnter);
            this.dgvListadoABM.VisibleChanged += new System.EventHandler(this.dgvListadoABM_VisibleChanged);
            // 
            // tbbEditar
            // 
            this.tbbEditar.Click += new System.EventHandler(this.tbbEditar_Click);
            // 
            // tbbBorrar
            // 
            this.tbbBorrar.Click += new System.EventHandler(this.tbbBorrar_Click_1);
            // 
            // tbbGuardar
            // 
            this.tbbGuardar.Click += new System.EventHandler(this.tbbGuardar_Click);
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.Controls.Add(this.txtDocumentoID);
            this.pnlDetalle.Controls.Add(this.label18);
            this.pnlDetalle.Controls.Add(this.label16);
            this.pnlDetalle.Controls.Add(this.txtMotivo);
            this.pnlDetalle.Controls.Add(this.grpValidez);
            this.pnlDetalle.Controls.Add(this.label10);
            this.pnlDetalle.Controls.Add(this.txtUsuarioAutorizadorNombre);
            this.pnlDetalle.Controls.Add(this.txtUsuarioAutorizadorID);
            this.pnlDetalle.Controls.Add(this.label8);
            this.pnlDetalle.Controls.Add(this.tSBUsuarioAutorizado);
            this.pnlDetalle.Controls.Add(this.label6);
            this.pnlDetalle.Controls.Add(this.label4);
            this.pnlDetalle.Controls.Add(this.tSBDocumento);
            this.pnlDetalle.Controls.Add(this.label1);
            this.pnlDetalle.Controls.Add(this.txtAutorizacionID);
            this.pnlDetalle.Size = new System.Drawing.Size(932, 438);
            // 
            // tBBaseForm
            // 
            this.tBBaseForm.Size = new System.Drawing.Size(940, 42);
            // 
            // tbbNuevo
            // 
            this.tbbNuevo.Click += new System.EventHandler(this.tbbNuevo_Click);
            // 
            // tabListaABM
            // 
            this.tabListaABM.Alignment = Gizmox.WebGUI.Forms.TabAlignment.Top;
            this.pnlListadoContainer.Controls.SetChildIndex(this.dgvListadoABM, 0);
            // 
            // txtAutorizacionID
            // 
            this.txtAutorizacionID.AllowDrag = false;
            this.txtAutorizacionID.BackColor = System.Drawing.SystemColors.Control;
            this.txtAutorizacionID.Location = new System.Drawing.Point(289, 17);
            this.txtAutorizacionID.Name = "txtAutorizacionID";
            this.txtAutorizacionID.ReadOnly = true;
            this.txtAutorizacionID.Size = new System.Drawing.Size(100, 20);
            this.txtAutorizacionID.TabIndex = 0;
            this.txtAutorizacionID.TabStop = false;
            // 
            // textBox2
            // 
            this.textBox2.AllowDrag = false;
            this.textBox2.Location = new System.Drawing.Point(-184, -4);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(-279, -1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cliente";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Controls.Add(this.textBox2);
            this.label1.Controls.Add(this.label2);
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(191, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Autorización ID";
            // 
            // tSBDocumento
            // 
            this.tSBDocumento.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBDocumento.DBContext = null;
            this.tSBDocumento.DisplayMember = "";
            this.tSBDocumento.KeyMember = "";
            this.tSBDocumento.LabelCampoBusqueda = "";
            this.tSBDocumento.Location = new System.Drawing.Point(289, 48);
            this.tSBDocumento.Name = "tSBDocumento";
            this.tSBDocumento.NombreCampoDescrip = "";
            this.tSBDocumento.NombreCampoID = "";
            this.tSBDocumento.Size = new System.Drawing.Size(438, 20);
            this.tSBDocumento.SoloLectura = false;
            this.tSBDocumento.TabIndex = 0;
            this.tSBDocumento.Text = "ucTextSearchBox";
            this.tSBDocumento.TituloBuscador = "";
            // 
            // textBox1
            // 
            this.textBox1.AllowDrag = false;
            this.textBox1.Location = new System.Drawing.Point(-184, -4);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(-279, -1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Cliente";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Controls.Add(this.textBox1);
            this.label4.Controls.Add(this.label3);
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(208, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Documento";
            // 
            // textBox3
            // 
            this.textBox3.AllowDrag = false;
            this.textBox3.Location = new System.Drawing.Point(-184, -4);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(-279, -1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Cliente";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Controls.Add(this.textBox3);
            this.label6.Controls.Add(this.label5);
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(211, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Autorizado";
            // 
            // tSBUsuarioAutorizado
            // 
            this.tSBUsuarioAutorizado.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBUsuarioAutorizado.DBContext = null;
            this.tSBUsuarioAutorizado.DisplayMember = "";
            this.tSBUsuarioAutorizado.KeyMember = "";
            this.tSBUsuarioAutorizado.LabelCampoBusqueda = "";
            this.tSBUsuarioAutorizado.Location = new System.Drawing.Point(289, 147);
            this.tSBUsuarioAutorizado.Name = "tSBUsuarioAutorizado";
            this.tSBUsuarioAutorizado.NombreCampoDescrip = "";
            this.tSBUsuarioAutorizado.NombreCampoID = "";
            this.tSBUsuarioAutorizado.Size = new System.Drawing.Size(438, 20);
            this.tSBUsuarioAutorizado.SoloLectura = false;
            this.tSBUsuarioAutorizado.TabIndex = 2;
            this.tSBUsuarioAutorizado.Text = "ucTextSearchBox";
            this.tSBUsuarioAutorizado.TituloBuscador = "";
            // 
            // textBox4
            // 
            this.textBox4.AllowDrag = false;
            this.textBox4.Location = new System.Drawing.Point(-184, -4);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(-279, -1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Cliente";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Controls.Add(this.textBox4);
            this.label8.Controls.Add(this.label7);
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(191, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Autorizado por";
            // 
            // txtUsuarioAutorizadorID
            // 
            this.txtUsuarioAutorizadorID.AllowDrag = false;
            this.txtUsuarioAutorizadorID.BackColor = System.Drawing.SystemColors.Control;
            this.txtUsuarioAutorizadorID.Location = new System.Drawing.Point(289, 110);
            this.txtUsuarioAutorizadorID.Name = "txtUsuarioAutorizadorID";
            this.txtUsuarioAutorizadorID.ReadOnly = true;
            this.txtUsuarioAutorizadorID.Size = new System.Drawing.Size(64, 20);
            this.txtUsuarioAutorizadorID.TabIndex = 0;
            this.txtUsuarioAutorizadorID.TabStop = false;
            // 
            // txtUsuarioAutorizadorNombre
            // 
            this.txtUsuarioAutorizadorNombre.AllowDrag = false;
            this.txtUsuarioAutorizadorNombre.BackColor = System.Drawing.SystemColors.Control;
            this.txtUsuarioAutorizadorNombre.Location = new System.Drawing.Point(356, 110);
            this.txtUsuarioAutorizadorNombre.Name = "txtUsuarioAutorizadorNombre";
            this.txtUsuarioAutorizadorNombre.ReadOnly = true;
            this.txtUsuarioAutorizadorNombre.Size = new System.Drawing.Size(371, 20);
            this.txtUsuarioAutorizadorNombre.TabIndex = 0;
            this.txtUsuarioAutorizadorNombre.TabStop = false;
            // 
            // textBox7
            // 
            this.textBox7.AllowDrag = false;
            this.textBox7.Location = new System.Drawing.Point(-184, -4);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(100, 20);
            this.textBox7.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(-279, -1);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Cliente";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Controls.Add(this.textBox7);
            this.label10.Controls.Add(this.label9);
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(189, 147);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Se autoriza a";
            // 
            // grpValidez
            // 
            this.grpValidez.Controls.Add(this.dtpFechaHasta);
            this.grpValidez.Controls.Add(this.label12);
            this.grpValidez.Controls.Add(this.txtFechaDesde);
            this.grpValidez.Controls.Add(this.label14);
            this.grpValidez.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.grpValidez.Location = new System.Drawing.Point(191, 170);
            this.grpValidez.Name = "grpValidez";
            this.grpValidez.Size = new System.Drawing.Size(536, 62);
            this.grpValidez.TabIndex = 9;
            this.grpValidez.TabStop = false;
            this.grpValidez.Text = "Validez";
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.CustomFormat = "dd/mm/yyyy";
            this.dtpFechaHasta.Location = new System.Drawing.Point(398, 23);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(100, 20);
            this.dtpFechaHasta.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Controls.Add(this.textBox8);
            this.label12.Controls.Add(this.label11);
            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(47, 29);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "Desde";
            // 
            // textBox8
            // 
            this.textBox8.AllowDrag = false;
            this.textBox8.Location = new System.Drawing.Point(-184, -4);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(100, 20);
            this.textBox8.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(-279, -1);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Cliente";
            // 
            // txtFechaDesde
            // 
            this.txtFechaDesde.AllowDrag = false;
            this.txtFechaDesde.BackColor = System.Drawing.SystemColors.Control;
            this.txtFechaDesde.Location = new System.Drawing.Point(98, 26);
            this.txtFechaDesde.Name = "txtFechaDesde";
            this.txtFechaDesde.ReadOnly = true;
            this.txtFechaDesde.Size = new System.Drawing.Size(100, 20);
            this.txtFechaDesde.TabIndex = 0;
            this.txtFechaDesde.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Controls.Add(this.textBox10);
            this.label14.Controls.Add(this.label13);
            this.label14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label14.Location = new System.Drawing.Point(337, 29);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 13);
            this.label14.TabIndex = 1;
            this.label14.Text = "Hasta";
            // 
            // textBox10
            // 
            this.textBox10.AllowDrag = false;
            this.textBox10.Location = new System.Drawing.Point(-184, -4);
            this.textBox10.Name = "textBox10";
            this.textBox10.ReadOnly = true;
            this.textBox10.Size = new System.Drawing.Size(100, 20);
            this.textBox10.TabIndex = 0;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(-279, -1);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 13);
            this.label13.TabIndex = 1;
            this.label13.Text = "Cliente";
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new System.Drawing.Point(289, 248);
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.txtMotivo.Size = new System.Drawing.Size(435, 125);
            this.txtMotivo.TabIndex = 4;
            // 
            // textBox11
            // 
            this.textBox11.AllowDrag = false;
            this.textBox11.Location = new System.Drawing.Point(-184, -4);
            this.textBox11.Name = "textBox11";
            this.textBox11.ReadOnly = true;
            this.textBox11.Size = new System.Drawing.Size(100, 20);
            this.textBox11.TabIndex = 0;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label15.Location = new System.Drawing.Point(-279, -1);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 13);
            this.label15.TabIndex = 1;
            this.label15.Text = "Cliente";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Controls.Add(this.textBox11);
            this.label16.Controls.Add(this.label15);
            this.label16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label16.Location = new System.Drawing.Point(199, 250);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 13);
            this.label16.TabIndex = 1;
            this.label16.Text = "Motivo";
            // 
            // textBox5
            // 
            this.textBox5.AllowDrag = false;
            this.textBox5.Location = new System.Drawing.Point(-184, -4);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(100, 20);
            this.textBox5.TabIndex = 0;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label17.Location = new System.Drawing.Point(-279, -1);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(35, 13);
            this.label17.TabIndex = 1;
            this.label17.Text = "Cliente";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Controls.Add(this.textBox5);
            this.label18.Controls.Add(this.label17);
            this.label18.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label18.Location = new System.Drawing.Point(191, 81);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(35, 13);
            this.label18.TabIndex = 1;
            this.label18.Text = "Documento ID";
            // 
            // txtDocumentoID
            // 
            this.txtDocumentoID.AllowDrag = false;
            this.txtDocumentoID.BackColor = System.Drawing.SystemColors.Window;
            this.txtDocumentoID.Location = new System.Drawing.Point(289, 78);
            this.txtDocumentoID.Name = "txtDocumentoID";
            this.txtDocumentoID.Size = new System.Drawing.Size(199, 20);
            this.txtDocumentoID.TabIndex = 1;
            // 
            // ucAutorizaciones
            // 
            this.Size = new System.Drawing.Size(942, 545);
            this.Text = "ucAutorizaciones";
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoABM)).EndInit();
            this.pnlDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabListaABM)).EndInit();
            this.pnlListadoContainer.ResumeLayout(false);
            this.pnlContainer.ResumeLayout(false);
            this.pnlTabControl.ResumeLayout(false);
            this.label1.ResumeLayout(false);
            this.label4.ResumeLayout(false);
            this.label6.ResumeLayout(false);
            this.label8.ResumeLayout(false);
            this.label10.ResumeLayout(false);
            this.grpValidez.ResumeLayout(false);
            this.label12.ResumeLayout(false);
            this.label14.ResumeLayout(false);
            this.label16.ResumeLayout(false);
            this.label18.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Label label1;
        private TextBox textBox2;
        private Label label2;
        private TextBox txtAutorizacionID;
        private Label label6;
        private TextBox textBox3;
        private Label label5;
        private Label label4;
        private TextBox textBox1;
        private Label label3;
        private Base.ucTextSearchBox tSBDocumento;
        private Label label10;
        private TextBox textBox7;
        private Label label9;
        private TextBox txtUsuarioAutorizadorNombre;
        private TextBox txtUsuarioAutorizadorID;
        private Label label8;
        private TextBox textBox4;
        private Label label7;
        private Base.ucTextSearchBox tSBUsuarioAutorizado;
        private GroupBox grpValidez;
        private DateTimePicker dtpFechaHasta;
        private Label label12;
        private TextBox textBox8;
        private Label label11;
        private TextBox txtFechaDesde;
        private Label label14;
        private TextBox textBox10;
        private Label label13;
        private Label label16;
        private TextBox textBox11;
        private Label label15;
        private TextBox txtMotivo;
        private TextBox txtDocumentoID;
        private Label label18;
        private TextBox textBox5;
        private Label label17;


    }
}