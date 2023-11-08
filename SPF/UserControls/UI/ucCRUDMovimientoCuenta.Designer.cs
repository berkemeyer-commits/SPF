using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.UserControls.UI
{
    partial class ucCRUDMovimientoCuenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucCRUDMovimientoCuenta));
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.txtObservacion = new Gizmox.WebGUI.Forms.TextBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.txtMovimientoID = new Gizmox.WebGUI.Forms.TextBox();
            this.label13 = new Gizmox.WebGUI.Forms.Label();
            this.txtFechaMov = new Gizmox.WebGUI.Forms.TextBox();
            this.dtpFechaMov = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.tSBTipoMovimiento = new SPF.UserControls.Base.ucTextSearchBox();
            this.txtNroCuenta = new Gizmox.WebGUI.Forms.TextBox();
            this.txtMonto = new Gizmox.WebGUI.Forms.TextBox();
            this.grpDatosCuenta = new Gizmox.WebGUI.Forms.GroupBox();
            this.cbAsociarCobranzas = new Gizmox.WebGUI.Forms.CheckBox();
            this.txtFecBolDep = new Gizmox.WebGUI.Forms.TextBox();
            this.label12 = new Gizmox.WebGUI.Forms.Label();
            this.dtpFecBolDep = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.txtNroBolDep = new Gizmox.WebGUI.Forms.TextBox();
            this.label11 = new Gizmox.WebGUI.Forms.Label();
            this.txtMoneda = new Gizmox.WebGUI.Forms.TextBox();
            this.label9 = new Gizmox.WebGUI.Forms.Label();
            this.txtBanco = new Gizmox.WebGUI.Forms.TextBox();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.tSBCuenta = new SPF.UserControls.Base.ucTextSearchBox();
            this.label8 = new Gizmox.WebGUI.Forms.Label();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.txtEstado = new Gizmox.WebGUI.Forms.TextBox();
            this.label7 = new Gizmox.WebGUI.Forms.Label();
            this.txtTipo = new Gizmox.WebGUI.Forms.TextBox();
            this.lblAutorizacionVigente = new Gizmox.WebGUI.Forms.Label();
            this.tbbAnular = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.Sep6 = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.txtPagoProveedorID = new Gizmox.WebGUI.Forms.TextBox();
            this.label10 = new Gizmox.WebGUI.Forms.Label();
            this.tpCobAsoc = new Gizmox.WebGUI.Forms.TabPage();
            this.pnlCobranzasAsoc = new Gizmox.WebGUI.Forms.Panel();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.dgvDetCobranzas = new Gizmox.WebGUI.Forms.DataGridView();
            this.panel6 = new Gizmox.WebGUI.Forms.Panel();
            this.panel5 = new Gizmox.WebGUI.Forms.Panel();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.panel3 = new Gizmox.WebGUI.Forms.Panel();
            this.btnEliminarCobro = new Gizmox.WebGUI.Forms.Button();
            this.btnAgregarCobro = new Gizmox.WebGUI.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoABM)).BeginInit();
            this.pnlDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabListaABM)).BeginInit();
            this.tabListaABM.SuspendLayout();
            this.label4.SuspendLayout();
            this.grpDatosCuenta.SuspendLayout();
            this.tpCobAsoc.SuspendLayout();
            this.pnlCobranzasAsoc.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetCobranzas)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvListadoABM
            // 
            this.dgvListadoABM.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.dgvListadoABM.Size = new System.Drawing.Size(1094, 339);
            this.dgvListadoABM.CellFormatting += new Gizmox.WebGUI.Forms.DataGridViewCellFormattingEventHandler(this.dgvListadoABM_CellFormatting);
            this.dgvListadoABM.RowEnter += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.dgvListadoABM_RowEnter);
            // 
            // tbbEditar
            // 
            this.tbbEditar.Click += new System.EventHandler(this.tbbEditar_Click);
            // 
            // tbbBorrar
            // 
            this.tbbBorrar.Click += new System.EventHandler(this.tbbBorrar_Click_1);
            // 
            // tbbCancelar
            // 
            this.tbbCancelar.Click += new System.EventHandler(this.tbbCancelar_Click);
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.Controls.Add(this.label10);
            this.pnlDetalle.Controls.Add(this.txtPagoProveedorID);
            this.pnlDetalle.Controls.Add(this.lblAutorizacionVigente);
            this.pnlDetalle.Controls.Add(this.txtTipo);
            this.pnlDetalle.Controls.Add(this.label7);
            this.pnlDetalle.Controls.Add(this.txtEstado);
            this.pnlDetalle.Controls.Add(this.label6);
            this.pnlDetalle.Controls.Add(this.grpDatosCuenta);
            this.pnlDetalle.Controls.Add(this.txtMonto);
            this.pnlDetalle.Controls.Add(this.tSBTipoMovimiento);
            this.pnlDetalle.Controls.Add(this.label3);
            this.pnlDetalle.Controls.Add(this.txtFechaMov);
            this.pnlDetalle.Controls.Add(this.dtpFechaMov);
            this.pnlDetalle.Controls.Add(this.label13);
            this.pnlDetalle.Controls.Add(this.txtMovimientoID);
            this.pnlDetalle.Controls.Add(this.label1);
            this.pnlDetalle.Controls.Add(this.txtObservacion);
            this.pnlDetalle.Controls.Add(this.label4);
            this.pnlDetalle.Size = new System.Drawing.Size(1114, 359);
            // 
            // tBBaseForm
            // 
            this.tBBaseForm.Buttons.AddRange(new Gizmox.WebGUI.Forms.ToolBarButton[] {
            this.tbbAnular,
            this.Sep6});
            this.tBBaseForm.Size = new System.Drawing.Size(1122, 42);
            // 
            // tbbNuevo
            // 
            this.tbbNuevo.Click += new System.EventHandler(this.tbbNuevo_Click);
            // 
            // tabListaABM
            // 
            this.tabListaABM.Alignment = Gizmox.WebGUI.Forms.TabAlignment.Top;
            this.tabListaABM.Controls.Add(this.tpCobAsoc);
            this.tabListaABM.Size = new System.Drawing.Size(1122, 388);
            this.tabListaABM.SelectedIndexChanged += new System.EventHandler(this.tabListaABM_SelectedIndexChanged);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Controls.Add(this.label2);
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label4.Location = new System.Drawing.Point(84, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Descripción";
            // 
            // txtObservacion
            // 
            this.txtObservacion.Location = new System.Drawing.Point(154, 135);
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(367, 71);
            this.txtObservacion.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "ID Mov.";
            // 
            // txtMovimientoID
            // 
            this.txtMovimientoID.BackColor = System.Drawing.SystemColors.Control;
            this.txtMovimientoID.Location = new System.Drawing.Point(154, 26);
            this.txtMovimientoID.Name = "txtMovimientoID";
            this.txtMovimientoID.ReadOnly = true;
            this.txtMovimientoID.Size = new System.Drawing.Size(79, 20);
            this.txtMovimientoID.TabIndex = 1;
            this.txtMovimientoID.TabStop = false;
            this.txtMovimientoID.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(421, 30);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Fecha";
            // 
            // txtFechaMov
            // 
            this.txtFechaMov.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0);
            this.txtFechaMov.Location = new System.Drawing.Point(479, 27);
            this.txtFechaMov.Name = "txtFechaMov";
            this.txtFechaMov.Size = new System.Drawing.Size(81, 18);
            this.txtFechaMov.TabIndex = 0;
            // 
            // dtpFechaMov
            // 
            this.dtpFechaMov.CustomFormat = "dd/mm/yyyy";
            this.dtpFechaMov.Location = new System.Drawing.Point(477, 26);
            this.dtpFechaMov.Name = "dtpFechaMov";
            this.dtpFechaMov.Size = new System.Drawing.Size(100, 21);
            this.dtpFechaMov.TabIndex = 3;
            this.dtpFechaMov.TabStop = false;
            this.dtpFechaMov.ValueChanged += new System.EventHandler(this.dtpFechaMov_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tipo";
            // 
            // tSBTipoMovimiento
            // 
            this.tSBTipoMovimiento.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBTipoMovimiento.BackColor = System.Drawing.Color.Transparent;
            this.tSBTipoMovimiento.DBContext = null;
            this.tSBTipoMovimiento.DisplayMember = "";
            this.tSBTipoMovimiento.KeyMember = "";
            this.tSBTipoMovimiento.LabelCampoBusqueda = "";
            this.tSBTipoMovimiento.Location = new System.Drawing.Point(154, 64);
            this.tSBTipoMovimiento.Name = "tSBTipoMovimiento";
            this.tSBTipoMovimiento.NombreCampoDescrip = "";
            this.tSBTipoMovimiento.NombreCampoID = "";
            this.tSBTipoMovimiento.Size = new System.Drawing.Size(387, 20);
            this.tSBTipoMovimiento.SoloLectura = false;
            this.tSBTipoMovimiento.TabIndex = 2;
            this.tSBTipoMovimiento.Text = "ucTextSearchBox";
            this.tSBTipoMovimiento.TituloBuscador = "";
            // 
            // txtNroCuenta
            // 
            this.txtNroCuenta.BackColor = System.Drawing.SystemColors.Control;
            this.txtNroCuenta.Location = new System.Drawing.Point(88, 43);
            this.txtNroCuenta.Name = "txtNroCuenta";
            this.txtNroCuenta.ReadOnly = true;
            this.txtNroCuenta.Size = new System.Drawing.Size(123, 20);
            this.txtNroCuenta.TabIndex = 4;
            this.txtNroCuenta.TabStop = false;
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(154, 95);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(100, 20);
            this.txtMonto.TabIndex = 3;
            this.txtMonto.Enter += new System.EventHandler(this.txtMonto_Enter);
            this.txtMonto.Leave += new System.EventHandler(this.txtMonto_Leave);
            // 
            // grpDatosCuenta
            // 
            this.grpDatosCuenta.Controls.Add(this.cbAsociarCobranzas);
            this.grpDatosCuenta.Controls.Add(this.txtFecBolDep);
            this.grpDatosCuenta.Controls.Add(this.label12);
            this.grpDatosCuenta.Controls.Add(this.dtpFecBolDep);
            this.grpDatosCuenta.Controls.Add(this.txtNroBolDep);
            this.grpDatosCuenta.Controls.Add(this.label11);
            this.grpDatosCuenta.Controls.Add(this.txtMoneda);
            this.grpDatosCuenta.Controls.Add(this.label9);
            this.grpDatosCuenta.Controls.Add(this.txtBanco);
            this.grpDatosCuenta.Controls.Add(this.label5);
            this.grpDatosCuenta.Controls.Add(this.tSBCuenta);
            this.grpDatosCuenta.Controls.Add(this.label8);
            this.grpDatosCuenta.Controls.Add(this.txtNroCuenta);
            this.grpDatosCuenta.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.grpDatosCuenta.ForeColor = System.Drawing.Color.Black;
            this.grpDatosCuenta.Location = new System.Drawing.Point(66, 209);
            this.grpDatosCuenta.Name = "grpDatosCuenta";
            this.grpDatosCuenta.Size = new System.Drawing.Size(516, 136);
            this.grpDatosCuenta.TabIndex = 5;
            this.grpDatosCuenta.TabStop = false;
            this.grpDatosCuenta.Text = "Cuenta";
            // 
            // cbAsociarCobranzas
            // 
            this.cbAsociarCobranzas.AutoSize = true;
            this.cbAsociarCobranzas.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbAsociarCobranzas.Location = new System.Drawing.Point(402, 95);
            this.cbAsociarCobranzas.Name = "cbAsociarCobranzas";
            this.cbAsociarCobranzas.Size = new System.Drawing.Size(73, 17);
            this.cbAsociarCobranzas.TabIndex = 3;
            this.cbAsociarCobranzas.Text = "Asociar a ";
            this.cbAsociarCobranzas.CheckedChanged += new System.EventHandler(this.cbAsociarCobranzas_CheckedChanged);
            // 
            // txtFecBolDep
            // 
            this.txtFecBolDep.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0);
            this.txtFecBolDep.Location = new System.Drawing.Point(285, 97);
            this.txtFecBolDep.Name = "txtFecBolDep";
            this.txtFecBolDep.Size = new System.Drawing.Size(81, 18);
            this.txtFecBolDep.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(218, 99);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Fecha Dep.";
            // 
            // dtpFecBolDep
            // 
            this.dtpFecBolDep.CustomFormat = "dd/mm/yyyy";
            this.dtpFecBolDep.Location = new System.Drawing.Point(284, 95);
            this.dtpFecBolDep.Name = "dtpFecBolDep";
            this.dtpFecBolDep.Size = new System.Drawing.Size(100, 21);
            this.dtpFecBolDep.TabIndex = 3;
            this.dtpFecBolDep.TabStop = false;
            this.dtpFecBolDep.ValueChanged += new System.EventHandler(this.dtpFecBolDep_ValueChanged);
            // 
            // txtNroBolDep
            // 
            this.txtNroBolDep.BackColor = System.Drawing.SystemColors.Window;
            this.txtNroBolDep.Location = new System.Drawing.Point(88, 96);
            this.txtNroBolDep.Name = "txtNroBolDep";
            this.txtNroBolDep.Size = new System.Drawing.Size(123, 20);
            this.txtNroBolDep.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(21, 100);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "N° Bol. Dep.";
            // 
            // txtMoneda
            // 
            this.txtMoneda.BackColor = System.Drawing.SystemColors.Control;
            this.txtMoneda.Location = new System.Drawing.Point(217, 43);
            this.txtMoneda.Name = "txtMoneda";
            this.txtMoneda.ReadOnly = true;
            this.txtMoneda.Size = new System.Drawing.Size(258, 20);
            this.txtMoneda.TabIndex = 4;
            this.txtMoneda.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Banco";
            // 
            // txtBanco
            // 
            this.txtBanco.BackColor = System.Drawing.SystemColors.Control;
            this.txtBanco.Location = new System.Drawing.Point(88, 70);
            this.txtBanco.Name = "txtBanco";
            this.txtBanco.ReadOnly = true;
            this.txtBanco.Size = new System.Drawing.Size(387, 20);
            this.txtBanco.TabIndex = 4;
            this.txtBanco.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "N° Cuenta";
            // 
            // tSBCuenta
            // 
            this.tSBCuenta.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBCuenta.BackColor = System.Drawing.Color.Transparent;
            this.tSBCuenta.DBContext = null;
            this.tSBCuenta.DisplayMember = "";
            this.tSBCuenta.KeyMember = "";
            this.tSBCuenta.LabelCampoBusqueda = "";
            this.tSBCuenta.Location = new System.Drawing.Point(88, 18);
            this.tSBCuenta.Name = "tSBCuenta";
            this.tSBCuenta.NombreCampoDescrip = "";
            this.tSBCuenta.NombreCampoID = "";
            this.tSBCuenta.Size = new System.Drawing.Size(387, 20);
            this.tSBCuenta.SoloLectura = false;
            this.tSBCuenta.TabIndex = 0;
            this.tSBCuenta.Text = "ucTextSearchBox";
            this.tSBCuenta.TituloBuscador = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Cuenta";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(84, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Monto";
            // 
            // txtEstado
            // 
            this.txtEstado.BackColor = System.Drawing.SystemColors.Control;
            this.txtEstado.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtEstado.Location = new System.Drawing.Point(297, 26);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.ReadOnly = true;
            this.txtEstado.Size = new System.Drawing.Size(100, 20);
            this.txtEstado.TabIndex = 1;
            this.txtEstado.TabStop = false;
            this.txtEstado.TextChanged += new System.EventHandler(this.txtEstado_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(248, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Estado";
            // 
            // txtTipo
            // 
            this.txtTipo.BackColor = System.Drawing.SystemColors.Control;
            this.txtTipo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTipo.Location = new System.Drawing.Point(260, 95);
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.ReadOnly = true;
            this.txtTipo.Size = new System.Drawing.Size(79, 20);
            this.txtTipo.TabIndex = 1;
            this.txtTipo.TabStop = false;
            // 
            // lblAutorizacionVigente
            // 
            this.lblAutorizacionVigente.AutoSize = true;
            this.lblAutorizacionVigente.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblAutorizacionVigente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblAutorizacionVigente.Location = new System.Drawing.Point(84, 10);
            this.lblAutorizacionVigente.Name = "lblAutorizacionVigente";
            this.lblAutorizacionVigente.Size = new System.Drawing.Size(227, 13);
            this.lblAutorizacionVigente.TabIndex = 15;
            this.lblAutorizacionVigente.Text = "Autorización para modificación vigente";
            this.lblAutorizacionVigente.Visible = false;
            // 
            // tbbAnular
            // 
            this.tbbAnular.CustomStyle = "";
            this.tbbAnular.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tbbAnular.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("tbbAnular.Image"));
            this.tbbAnular.Name = "tbbAnular";
            this.tbbAnular.Size = 24;
            this.tbbAnular.Text = "Anular";
            this.tbbAnular.ToolTipText = "Anula el movimiento";
            this.tbbAnular.Click += new System.EventHandler(this.tbbAnular_Click);
            // 
            // Sep6
            // 
            this.Sep6.CustomStyle = "";
            this.Sep6.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Sep6.Name = "Sep6";
            this.Sep6.Size = 24;
            this.Sep6.Style = Gizmox.WebGUI.Forms.ToolBarButtonStyle.Separator;
            this.Sep6.ToolTipText = "";
            // 
            // txtPagoProveedorID
            // 
            this.txtPagoProveedorID.BackColor = System.Drawing.SystemColors.Control;
            this.txtPagoProveedorID.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtPagoProveedorID.Location = new System.Drawing.Point(446, 95);
            this.txtPagoProveedorID.Name = "txtPagoProveedorID";
            this.txtPagoProveedorID.ReadOnly = true;
            this.txtPagoProveedorID.Size = new System.Drawing.Size(95, 20);
            this.txtPagoProveedorID.TabIndex = 1;
            this.txtPagoProveedorID.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(367, 99);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Pago Prov. ID";
            // 
            // tpCobAsoc
            // 
            this.tpCobAsoc.Controls.Add(this.pnlCobranzasAsoc);
            this.tpCobAsoc.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tpCobAsoc.Location = new System.Drawing.Point(0, 0);
            this.tpCobAsoc.Name = "tpCobAsoc";
            this.tpCobAsoc.Size = new System.Drawing.Size(1114, 359);
            this.tpCobAsoc.TabIndex = 2;
            this.tpCobAsoc.Text = "Cobranzas Asociadas";
            // 
            // pnlCobranzasAsoc
            // 
            this.pnlCobranzasAsoc.Controls.Add(this.panel1);
            this.pnlCobranzasAsoc.Controls.Add(this.panel3);
            this.pnlCobranzasAsoc.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.pnlCobranzasAsoc.Location = new System.Drawing.Point(0, 0);
            this.pnlCobranzasAsoc.Name = "pnlCobranzasAsoc";
            this.pnlCobranzasAsoc.Size = new System.Drawing.Size(1114, 359);
            this.pnlCobranzasAsoc.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvDetCobranzas);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1114, 311);
            this.panel1.TabIndex = 1;
            // 
            // dgvDetCobranzas
            // 
            this.dgvDetCobranzas.AllowUserToAddRows = false;
            this.dgvDetCobranzas.AllowUserToDeleteRows = false;
            this.dgvDetCobranzas.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.dgvDetCobranzas.Location = new System.Drawing.Point(10, 0);
            this.dgvDetCobranzas.Name = "dgvDetCobranzas";
            this.dgvDetCobranzas.Size = new System.Drawing.Size(1094, 301);
            this.dgvDetCobranzas.TabIndex = 0;
            this.dgvDetCobranzas.RowEnter += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.dgvDetCobranzas_RowEnter);
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
            this.panel3.Controls.Add(this.btnEliminarCobro);
            this.panel3.Controls.Add(this.btnAgregarCobro);
            this.panel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1114, 48);
            this.panel3.TabIndex = 0;
            // 
            // btnEliminarCobro
            // 
            this.btnEliminarCobro.BackColor = System.Drawing.Color.Transparent;
            this.btnEliminarCobro.CustomStyle = "F";
            this.btnEliminarCobro.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnEliminarCobro.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnEliminarCobro.Image"));
            this.btnEliminarCobro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarCobro.Location = new System.Drawing.Point(150, 4);
            this.btnEliminarCobro.Name = "btnEliminarCobro";
            this.btnEliminarCobro.Size = new System.Drawing.Size(131, 39);
            this.btnEliminarCobro.TabIndex = 0;
            this.btnEliminarCobro.Text = "Eliminar Cobro";
            this.btnEliminarCobro.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminarCobro.Click += new System.EventHandler(this.btnEliminarDetalle_Click);
            // 
            // btnAgregarCobro
            // 
            this.btnAgregarCobro.BackColor = System.Drawing.Color.Transparent;
            this.btnAgregarCobro.CustomStyle = "F";
            this.btnAgregarCobro.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnAgregarCobro.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnAgregarCobro.Image"));
            this.btnAgregarCobro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarCobro.Location = new System.Drawing.Point(10, 4);
            this.btnAgregarCobro.Name = "btnAgregarCobro";
            this.btnAgregarCobro.Size = new System.Drawing.Size(131, 39);
            this.btnAgregarCobro.TabIndex = 0;
            this.btnAgregarCobro.Text = "Agregar Cobro";
            this.btnAgregarCobro.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarCobro.Click += new System.EventHandler(this.btnAgregarDetalle_Click);
            // 
            // ucCRUDMovimientoCuenta
            // 
            this.Size = new System.Drawing.Size(1124, 466);
            this.Text = "ucCRUDBancos";
            this.VisibleChanged += new System.EventHandler(this.ucCRUDMovimientoCuenta_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoABM)).EndInit();
            this.pnlDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabListaABM)).EndInit();
            this.tabListaABM.ResumeLayout(false);
            this.label4.ResumeLayout(false);
            this.grpDatosCuenta.ResumeLayout(false);
            this.tpCobAsoc.ResumeLayout(false);
            this.pnlCobranzasAsoc.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetCobranzas)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Label label4;
        private Label label2;
        private TextBox txtMovimientoID;
        private Label label1;
        private TextBox txtObservacion;
        private Label label6;
        private GroupBox grpDatosCuenta;
        private TextBox txtBanco;
        private Label label5;
        private Base.ucTextSearchBox tSBCuenta;
        private Label label8;
        private TextBox txtNroCuenta;
        private TextBox txtMonto;
        private Base.ucTextSearchBox tSBTipoMovimiento;
        private Label label3;
        private TextBox txtFechaMov;
        private DateTimePicker dtpFechaMov;
        private Label label13;
        private Label label7;
        private TextBox txtEstado;
        private TextBox txtTipo;
        private TextBox txtMoneda;
        private Label label9;
        private Label lblAutorizacionVigente;
        private ToolBarButton tbbAnular;
        private ToolBarButton Sep6;
        private Label label10;
        private TextBox txtPagoProveedorID;
        private TextBox txtNroBolDep;
        private Label label11;
        private TextBox txtFecBolDep;
        private Label label12;
        private DateTimePicker dtpFecBolDep;
        private CheckBox cbAsociarCobranzas;
        private TabPage tpCobAsoc;
        private Panel pnlCobranzasAsoc;
        private Panel panel3;
        private Button btnEliminarCobro;
        private Button btnAgregarCobro;
        private Panel panel1;
        private DataGridView dgvDetCobranzas;
        private Panel panel6;
        private Panel panel5;
        private Panel panel2;


    }
}