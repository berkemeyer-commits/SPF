using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.UserControls.UI
{
    partial class ucCRUDTimbrados
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

        #region Visual WebGui Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucCRUDTimbrados));
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.txtTimbradoID = new Gizmox.WebGUI.Forms.TextBox();
            this.label13 = new Gizmox.WebGUI.Forms.Label();
            this.txtFechaDesde = new Gizmox.WebGUI.Forms.TextBox();
            this.dtpFechaDesde = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.label7 = new Gizmox.WebGUI.Forms.Label();
            this.txtNroTimbrado = new Gizmox.WebGUI.Forms.TextBox();
            this.txtDescripcion = new Gizmox.WebGUI.Forms.TextBox();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.chkVigente = new Gizmox.WebGUI.Forms.CheckBox();
            this.txtFechaHasta = new Gizmox.WebGUI.Forms.TextBox();
            this.dtpFechaHasta = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.label8 = new Gizmox.WebGUI.Forms.Label();
            this.label9 = new Gizmox.WebGUI.Forms.Label();
            this.txtNroDesde = new Gizmox.WebGUI.Forms.TextBox();
            this.txtNroHasta = new Gizmox.WebGUI.Forms.TextBox();
            this.label11 = new Gizmox.WebGUI.Forms.Label();
            this.label12 = new Gizmox.WebGUI.Forms.Label();
            this.txtSucursal = new Gizmox.WebGUI.Forms.TextBox();
            this.txtSerie = new Gizmox.WebGUI.Forms.TextBox();
            this.label14 = new Gizmox.WebGUI.Forms.Label();
            this.tpPermisos = new Gizmox.WebGUI.Forms.TabPage();
            this.pnlPermisos = new Gizmox.WebGUI.Forms.Panel();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.dgvDetPermisos = new Gizmox.WebGUI.Forms.DataGridView();
            this.panel6 = new Gizmox.WebGUI.Forms.Panel();
            this.panel5 = new Gizmox.WebGUI.Forms.Panel();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.panel3 = new Gizmox.WebGUI.Forms.Panel();
            this.btnEliminarPermiso = new Gizmox.WebGUI.Forms.Button();
            this.btnAgregarPermiso = new Gizmox.WebGUI.Forms.Button();
            this.chkFactHojaSuelta = new Gizmox.WebGUI.Forms.CheckBox();
            this.tSBDocumento = new SPF.UserControls.Base.ucTextSearchBox();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoABM)).BeginInit();
            this.pnlDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabListaABM)).BeginInit();
            this.tabListaABM.SuspendLayout();
            this.tpDetalle.SuspendLayout();
            this.tpPermisos.SuspendLayout();
            this.pnlPermisos.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetPermisos)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvListadoABM
            // 
            this.dgvListadoABM.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.dgvListadoABM.Size = new System.Drawing.Size(1094, 339);
            // 
            // tbbEditar
            // 
            this.tbbEditar.Click += new System.EventHandler(this.tbbEditar_Click);
            // 
            // tbbCancelar
            // 
            this.tbbCancelar.Click += new System.EventHandler(this.tbbCancelar_Click);
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.Controls.Add(this.label2);
            this.pnlDetalle.Controls.Add(this.tSBDocumento);
            this.pnlDetalle.Controls.Add(this.chkFactHojaSuelta);
            this.pnlDetalle.Controls.Add(this.label14);
            this.pnlDetalle.Controls.Add(this.txtSerie);
            this.pnlDetalle.Controls.Add(this.txtSucursal);
            this.pnlDetalle.Controls.Add(this.label12);
            this.pnlDetalle.Controls.Add(this.label11);
            this.pnlDetalle.Controls.Add(this.txtNroHasta);
            this.pnlDetalle.Controls.Add(this.txtNroDesde);
            this.pnlDetalle.Controls.Add(this.label9);
            this.pnlDetalle.Controls.Add(this.txtFechaHasta);
            this.pnlDetalle.Controls.Add(this.label8);
            this.pnlDetalle.Controls.Add(this.dtpFechaHasta);
            this.pnlDetalle.Controls.Add(this.chkVigente);
            this.pnlDetalle.Controls.Add(this.label5);
            this.pnlDetalle.Controls.Add(this.txtDescripcion);
            this.pnlDetalle.Controls.Add(this.txtNroTimbrado);
            this.pnlDetalle.Controls.Add(this.label7);
            this.pnlDetalle.Controls.Add(this.txtFechaDesde);
            this.pnlDetalle.Controls.Add(this.dtpFechaDesde);
            this.pnlDetalle.Controls.Add(this.label13);
            this.pnlDetalle.Controls.Add(this.txtTimbradoID);
            this.pnlDetalle.Controls.Add(this.label1);
            this.pnlDetalle.Size = new System.Drawing.Size(1114, 359);
            // 
            // tBBaseForm
            // 
            this.tBBaseForm.Size = new System.Drawing.Size(1122, 42);
            // 
            // tbbNuevo
            // 
            this.tbbNuevo.Click += new System.EventHandler(this.tbbNuevo_Click);
            // 
            // tabListaABM
            // 
            this.tabListaABM.Alignment = Gizmox.WebGUI.Forms.TabAlignment.Top;
            this.tabListaABM.Controls.Add(this.tpPermisos);
            this.tabListaABM.Size = new System.Drawing.Size(1122, 388);
            this.tabListaABM.SelectedIndexChanged += new System.EventHandler(this.tabListaABM_SelectedIndexChanged);
            this.tabListaABM.Controls.SetChildIndex(this.tpPermisos, 0);
            this.tabListaABM.Controls.SetChildIndex(this.tpDetalle, 0);
            this.tabListaABM.Controls.SetChildIndex(this.tpListado, 0);
            // 
            // tpDetalle
            // 
            this.tpDetalle.Size = new System.Drawing.Size(1114, 359);
            // 
            // tpListado
            // 
            this.tpListado.Size = new System.Drawing.Size(1114, 359);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "ID Timbrado";
            // 
            // txtTimbradoID
            // 
            this.txtTimbradoID.BackColor = System.Drawing.SystemColors.Control;
            this.txtTimbradoID.Location = new System.Drawing.Point(159, 26);
            this.txtTimbradoID.Name = "txtTimbradoID";
            this.txtTimbradoID.ReadOnly = true;
            this.txtTimbradoID.Size = new System.Drawing.Size(79, 20);
            this.txtTimbradoID.TabIndex = 1;
            this.txtTimbradoID.TabStop = false;
            this.txtTimbradoID.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(67, 102);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Vigente Desde";
            // 
            // txtFechaDesde
            // 
            this.txtFechaDesde.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0);
            this.txtFechaDesde.Location = new System.Drawing.Point(159, 100);
            this.txtFechaDesde.Name = "txtFechaDesde";
            this.txtFechaDesde.Size = new System.Drawing.Size(81, 18);
            this.txtFechaDesde.TabIndex = 5;
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.CustomFormat = "dd/mm/yyyy";
            this.dtpFechaDesde.Location = new System.Drawing.Point(158, 98);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(100, 21);
            this.dtpFechaDesde.TabIndex = 4;
            this.dtpFechaDesde.TabStop = false;
            this.dtpFechaDesde.ValueChanged += new System.EventHandler(this.dtpFechaDesde_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(67, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "N° Timbrado";
            // 
            // txtNroTimbrado
            // 
            this.txtNroTimbrado.Location = new System.Drawing.Point(159, 74);
            this.txtNroTimbrado.Name = "txtNroTimbrado";
            this.txtNroTimbrado.Size = new System.Drawing.Size(171, 20);
            this.txtNroTimbrado.TabIndex = 3;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(431, 74);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(171, 20);
            this.txtDescripcion.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(347, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Descripción";
            // 
            // chkVigente
            // 
            this.chkVigente.AutoSize = true;
            this.chkVigente.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkVigente.Location = new System.Drawing.Point(347, 25);
            this.chkVigente.Name = "chkVigente";
            this.chkVigente.Size = new System.Drawing.Size(62, 17);
            this.chkVigente.TabIndex = 0;
            this.chkVigente.Text = "Vigente";
            // 
            // txtFechaHasta
            // 
            this.txtFechaHasta.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0);
            this.txtFechaHasta.Location = new System.Drawing.Point(432, 100);
            this.txtFechaHasta.Name = "txtFechaHasta";
            this.txtFechaHasta.Size = new System.Drawing.Size(81, 18);
            this.txtFechaHasta.TabIndex = 6;
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.CustomFormat = "dd/mm/yyyy";
            this.dtpFechaHasta.Location = new System.Drawing.Point(431, 98);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(100, 21);
            this.dtpFechaHasta.TabIndex = 5;
            this.dtpFechaHasta.TabStop = false;
            this.dtpFechaHasta.ValueChanged += new System.EventHandler(this.dtpFechaHasta_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(347, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Vigente Hasta";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(67, 127);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "N° Desde";
            // 
            // txtNroDesde
            // 
            this.txtNroDesde.Location = new System.Drawing.Point(159, 123);
            this.txtNroDesde.Name = "txtNroDesde";
            this.txtNroDesde.Size = new System.Drawing.Size(100, 20);
            this.txtNroDesde.TabIndex = 7;
            // 
            // txtNroHasta
            // 
            this.txtNroHasta.Location = new System.Drawing.Point(431, 123);
            this.txtNroHasta.Name = "txtNroHasta";
            this.txtNroHasta.Size = new System.Drawing.Size(100, 20);
            this.txtNroHasta.TabIndex = 8;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(347, 128);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "N° Hasta";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(347, 154);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Serie";
            // 
            // txtSucursal
            // 
            this.txtSucursal.Location = new System.Drawing.Point(431, 149);
            this.txtSucursal.Name = "txtSucursal";
            this.txtSucursal.Size = new System.Drawing.Size(100, 20);
            this.txtSucursal.TabIndex = 10;
            // 
            // txtSerie
            // 
            this.txtSerie.Location = new System.Drawing.Point(159, 149);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(100, 20);
            this.txtSerie.TabIndex = 9;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(67, 153);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "Sucursal";
            // 
            // tpPermisos
            // 
            this.tpPermisos.Controls.Add(this.pnlPermisos);
            this.tpPermisos.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tpPermisos.Location = new System.Drawing.Point(0, 0);
            this.tpPermisos.Name = "tpPermisos";
            this.tpPermisos.Size = new System.Drawing.Size(1114, 359);
            this.tpPermisos.TabIndex = 2;
            this.tpPermisos.Text = "Permisos";
            // 
            // pnlPermisos
            // 
            this.pnlPermisos.Controls.Add(this.panel1);
            this.pnlPermisos.Controls.Add(this.panel3);
            this.pnlPermisos.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.pnlPermisos.Location = new System.Drawing.Point(0, 0);
            this.pnlPermisos.Name = "pnlPermisos";
            this.pnlPermisos.Size = new System.Drawing.Size(1114, 359);
            this.pnlPermisos.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvDetPermisos);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1114, 311);
            this.panel1.TabIndex = 1;
            // 
            // dgvDetPermisos
            // 
            this.dgvDetPermisos.AllowUserToAddRows = false;
            this.dgvDetPermisos.AllowUserToDeleteRows = false;
            this.dgvDetPermisos.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.dgvDetPermisos.Location = new System.Drawing.Point(10, 0);
            this.dgvDetPermisos.Name = "dgvDetPermisos";
            this.dgvDetPermisos.Size = new System.Drawing.Size(1094, 301);
            this.dgvDetPermisos.TabIndex = 0;
            this.dgvDetPermisos.RowEnter += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.dgvDetPermisos_RowEnter);
            // 
            // panel6
            // 
            this.panel6.Dock = Gizmox.WebGUI.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(1104, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(10, 301);
            this.panel6.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(10, 301);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1104, 10);
            this.panel5.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 311);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnEliminarPermiso);
            this.panel3.Controls.Add(this.btnAgregarPermiso);
            this.panel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1114, 48);
            this.panel3.TabIndex = 0;
            // 
            // btnEliminarPermiso
            // 
            this.btnEliminarPermiso.BackColor = System.Drawing.Color.Transparent;
            this.btnEliminarPermiso.CustomStyle = "F";
            this.btnEliminarPermiso.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnEliminarPermiso.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnEliminarPermiso.Image"));
            this.btnEliminarPermiso.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarPermiso.Location = new System.Drawing.Point(150, 4);
            this.btnEliminarPermiso.Name = "btnEliminarPermiso";
            this.btnEliminarPermiso.Size = new System.Drawing.Size(131, 39);
            this.btnEliminarPermiso.TabIndex = 0;
            this.btnEliminarPermiso.Text = "Eliminar Permiso";
            this.btnEliminarPermiso.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminarPermiso.Click += new System.EventHandler(this.btnEliminarDetalle_Click);
            // 
            // btnAgregarPermiso
            // 
            this.btnAgregarPermiso.BackColor = System.Drawing.Color.Transparent;
            this.btnAgregarPermiso.CustomStyle = "F";
            this.btnAgregarPermiso.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnAgregarPermiso.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnAgregarPermiso.Image"));
            this.btnAgregarPermiso.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarPermiso.Location = new System.Drawing.Point(10, 4);
            this.btnAgregarPermiso.Name = "btnAgregarPermiso";
            this.btnAgregarPermiso.Size = new System.Drawing.Size(131, 39);
            this.btnAgregarPermiso.TabIndex = 0;
            this.btnAgregarPermiso.Text = "Agregar Permiso";
            this.btnAgregarPermiso.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarPermiso.Click += new System.EventHandler(this.btnAgregarDetalle_Click);
            // 
            // chkFactHojaSuelta
            // 
            this.chkFactHojaSuelta.AutoSize = true;
            this.chkFactHojaSuelta.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFactHojaSuelta.Location = new System.Drawing.Point(431, 25);
            this.chkFactHojaSuelta.Name = "chkFactHojaSuelta";
            this.chkFactHojaSuelta.Size = new System.Drawing.Size(211, 17);
            this.chkFactHojaSuelta.TabIndex = 1;
            this.chkFactHojaSuelta.Text = "Impresión de Factura en Hojas Sueltas";
            // 
            // tSBDocumento
            // 
            this.tSBDocumento.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBDocumento.DBContext = null;
            this.tSBDocumento.DisplayMember = "";
            this.tSBDocumento.KeyMember = "";
            this.tSBDocumento.LabelCampoBusqueda = "";
            this.tSBDocumento.Location = new System.Drawing.Point(159, 50);
            this.tSBDocumento.Name = "tSBDocumento";
            this.tSBDocumento.NombreCampoDescrip = "";
            this.tSBDocumento.NombreCampoID = "";
            this.tSBDocumento.Size = new System.Drawing.Size(438, 20);
            this.tSBDocumento.SoloLectura = false;
            this.tSBDocumento.TabIndex = 2;
            this.tSBDocumento.Text = "ucTextSearchBox";
            this.tSBDocumento.TituloBuscador = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tipo Documento";
            // 
            // ucCRUDTimbrados
            // 
            this.Size = new System.Drawing.Size(1124, 466);
            this.Text = "ucCRUDBancos";
            this.VisibleChanged += new System.EventHandler(this.ucCRUDMovimientoCuenta_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoABM)).EndInit();
            this.pnlDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabListaABM)).EndInit();
            this.tabListaABM.ResumeLayout(false);
            this.tpDetalle.ResumeLayout(false);
            this.tpPermisos.ResumeLayout(false);
            this.pnlPermisos.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetPermisos)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TextBox txtTimbradoID;
        private Label label1;
        private TextBox txtFechaDesde;
        private DateTimePicker dtpFechaDesde;
        private Label label13;
        private Label label7;
        private CheckBox chkVigente;
        private Label label5;
        private TextBox txtDescripcion;
        private TextBox txtNroTimbrado;
        private Label label11;
        private TextBox txtNroHasta;
        private TextBox txtNroDesde;
        private Label label9;
        private TextBox txtFechaHasta;
        private Label label8;
        private DateTimePicker dtpFechaHasta;
        private Label label14;
        private TextBox txtSerie;
        private TextBox txtSucursal;
        private Label label12;
        private TabPage tpPermisos;
        private Panel pnlPermisos;
        private Panel panel1;
        private DataGridView dgvDetPermisos;
        private Panel panel6;
        private Panel panel5;
        private Panel panel2;
        private Panel panel3;
        private Button btnEliminarPermiso;
        private Button btnAgregarPermiso;
        private CheckBox chkFactHojaSuelta;
        private Label label2;
        private Base.ucTextSearchBox tSBDocumento;


    }
}