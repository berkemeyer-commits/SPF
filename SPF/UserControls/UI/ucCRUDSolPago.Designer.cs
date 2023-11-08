using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.UserControls.UI
{
    partial class ucCRUDSolPago
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucCRUDSolPago));
            this.tabDetSolPag = new Gizmox.WebGUI.Forms.TabPage();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.dgvDetalleSolPago = new Gizmox.WebGUI.Forms.DataGridView();
            this.panel6 = new Gizmox.WebGUI.Forms.Panel();
            this.panel5 = new Gizmox.WebGUI.Forms.Panel();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.panel3 = new Gizmox.WebGUI.Forms.Panel();
            this.btnEliminarDetalle = new Gizmox.WebGUI.Forms.Button();
            this.btnAgregarDetalle = new Gizmox.WebGUI.Forms.Button();
            this.txtSolPagoCabID = new Gizmox.WebGUI.Forms.TextBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.textBox5 = new Gizmox.WebGUI.Forms.TextBox();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.cbOrigen = new Gizmox.WebGUI.Forms.ComboBox();
            this.grpAsociadoaTramite = new Gizmox.WebGUI.Forms.GroupBox();
            this.label36 = new Gizmox.WebGUI.Forms.Label();
            this.txtHINro = new Gizmox.WebGUI.Forms.TextBox();
            this.label27 = new Gizmox.WebGUI.Forms.Label();
            this.textBox19 = new Gizmox.WebGUI.Forms.TextBox();
            this.label26 = new Gizmox.WebGUI.Forms.Label();
            this.txtHIAnio = new Gizmox.WebGUI.Forms.TextBox();
            this.txtActaAnio = new Gizmox.WebGUI.Forms.TextBox();
            this.label25 = new Gizmox.WebGUI.Forms.Label();
            this.textBox16 = new Gizmox.WebGUI.Forms.TextBox();
            this.label24 = new Gizmox.WebGUI.Forms.Label();
            this.txtOTID = new Gizmox.WebGUI.Forms.TextBox();
            this.txtTramiteDescrip = new Gizmox.WebGUI.Forms.TextBox();
            this.txtTramiteID = new Gizmox.WebGUI.Forms.TextBox();
            this.label23 = new Gizmox.WebGUI.Forms.Label();
            this.textBox13 = new Gizmox.WebGUI.Forms.TextBox();
            this.label22 = new Gizmox.WebGUI.Forms.Label();
            this.txtActaNro = new Gizmox.WebGUI.Forms.TextBox();
            this.txtExpedienteID = new Gizmox.WebGUI.Forms.TextBox();
            this.grpBuscarExpediente = new Gizmox.WebGUI.Forms.GroupBox();
            this.txtFiltroExpedienteID = new Gizmox.WebGUI.Forms.TextBox();
            this.cbCampoFiltro = new Gizmox.WebGUI.Forms.ComboBox();
            this.btnFiltrar = new Gizmox.WebGUI.Forms.Button();
            this.label21 = new Gizmox.WebGUI.Forms.Label();
            this.textBox11 = new Gizmox.WebGUI.Forms.TextBox();
            this.label20 = new Gizmox.WebGUI.Forms.Label();
            this.label13 = new Gizmox.WebGUI.Forms.Label();
            this.textBox4 = new Gizmox.WebGUI.Forms.TextBox();
            this.label12 = new Gizmox.WebGUI.Forms.Label();
            this.label9 = new Gizmox.WebGUI.Forms.Label();
            this.label7 = new Gizmox.WebGUI.Forms.Label();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.tSBUnidadNegocio = new SPF.UserControls.Base.ucTextSearchBox();
            this.tSBGastosGenerales = new SPF.UserControls.Base.ucTextSearchBox();
            this.grpGastoGeneral = new Gizmox.WebGUI.Forms.GroupBox();
            this.label34 = new Gizmox.WebGUI.Forms.Label();
            this.tSBAreaContab = new SPF.UserControls.Base.ucTextSearchBox();
            this.tSBMoneda = new SPF.UserControls.Base.ucTextSearchBox();
            this.grpTipoSolicitud = new Gizmox.WebGUI.Forms.GroupBox();
            this.rbGastosGrales = new Gizmox.WebGUI.Forms.RadioButton();
            this.rbAsocTramite = new Gizmox.WebGUI.Forms.RadioButton();
            this.tSBCliente = new SPF.UserControls.Base.ucTextSearchBox();
            this.label10 = new Gizmox.WebGUI.Forms.Label();
            this.label11 = new Gizmox.WebGUI.Forms.Label();
            this.textBox6 = new Gizmox.WebGUI.Forms.TextBox();
            this.label14 = new Gizmox.WebGUI.Forms.Label();
            this.textBox7 = new Gizmox.WebGUI.Forms.TextBox();
            this.label15 = new Gizmox.WebGUI.Forms.Label();
            this.txtRefCliente = new Gizmox.WebGUI.Forms.TextBox();
            this.txtObservacion = new Gizmox.WebGUI.Forms.TextBox();
            this.textBox9 = new Gizmox.WebGUI.Forms.TextBox();
            this.label16 = new Gizmox.WebGUI.Forms.Label();
            this.textBox10 = new Gizmox.WebGUI.Forms.TextBox();
            this.label17 = new Gizmox.WebGUI.Forms.Label();
            this.txtFechaSolCab = new Gizmox.WebGUI.Forms.TextBox();
            this.dtpFechaSolCab = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.textBox8 = new Gizmox.WebGUI.Forms.TextBox();
            this.label18 = new Gizmox.WebGUI.Forms.Label();
            this.label19 = new Gizmox.WebGUI.Forms.Label();
            this.textBox12 = new Gizmox.WebGUI.Forms.TextBox();
            this.label28 = new Gizmox.WebGUI.Forms.Label();
            this.label29 = new Gizmox.WebGUI.Forms.Label();
            this.txtImporte = new Gizmox.WebGUI.Forms.TextBox();
            this.txtSaldoCab = new Gizmox.WebGUI.Forms.TextBox();
            this.textBox15 = new Gizmox.WebGUI.Forms.TextBox();
            this.label30 = new Gizmox.WebGUI.Forms.Label();
            this.label31 = new Gizmox.WebGUI.Forms.Label();
            this.txtEstado = new Gizmox.WebGUI.Forms.TextBox();
            this.label32 = new Gizmox.WebGUI.Forms.Label();
            this.grpAsociacionPresup = new Gizmox.WebGUI.Forms.GroupBox();
            this.txtPresupAsoc = new Gizmox.WebGUI.Forms.TextBox();
            this.btnBuscar = new Gizmox.WebGUI.Forms.Button();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.textBox1 = new Gizmox.WebGUI.Forms.TextBox();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.label33 = new Gizmox.WebGUI.Forms.Label();
            this.textBox2 = new Gizmox.WebGUI.Forms.TextBox();
            this.label8 = new Gizmox.WebGUI.Forms.Label();
            this.cbTipoAsocPresup = new Gizmox.WebGUI.Forms.ComboBox();
            this.txtPresupID = new Gizmox.WebGUI.Forms.TextBox();
            this.label37 = new Gizmox.WebGUI.Forms.Label();
            this.textBox3 = new Gizmox.WebGUI.Forms.TextBox();
            this.label35 = new Gizmox.WebGUI.Forms.Label();
            this.label39 = new Gizmox.WebGUI.Forms.Label();
            this.textBox14 = new Gizmox.WebGUI.Forms.TextBox();
            this.label38 = new Gizmox.WebGUI.Forms.Label();
            this.label41 = new Gizmox.WebGUI.Forms.Label();
            this.textBox17 = new Gizmox.WebGUI.Forms.TextBox();
            this.label40 = new Gizmox.WebGUI.Forms.Label();
            this.chkExcluirDeListados = new Gizmox.WebGUI.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoABM)).BeginInit();
            this.pnlDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabListaABM)).BeginInit();
            this.tabListaABM.SuspendLayout();
            this.pnlListadoContainer.SuspendLayout();
            this.pnlContainer.SuspendLayout();
            this.pnlTabControl.SuspendLayout();
            this.tabDetSolPag.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleSolPago)).BeginInit();
            this.panel3.SuspendLayout();
            this.label6.SuspendLayout();
            this.grpAsociadoaTramite.SuspendLayout();
            this.label27.SuspendLayout();
            this.label25.SuspendLayout();
            this.label23.SuspendLayout();
            this.grpBuscarExpediente.SuspendLayout();
            this.label21.SuspendLayout();
            this.label13.SuspendLayout();
            this.grpGastoGeneral.SuspendLayout();
            this.grpTipoSolicitud.SuspendLayout();
            this.label15.SuspendLayout();
            this.label17.SuspendLayout();
            this.label19.SuspendLayout();
            this.label29.SuspendLayout();
            this.label31.SuspendLayout();
            this.grpAsociacionPresup.SuspendLayout();
            this.label4.SuspendLayout();
            this.label33.SuspendLayout();
            this.label37.SuspendLayout();
            this.label39.SuspendLayout();
            this.label41.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvListadoABM
            // 
            this.dgvListadoABM.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.dgvListadoABM.Size = new System.Drawing.Size(1261, 438);
            this.dgvListadoABM.RowEnter += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.dgvListadoABM_RowEnter);
            // 
            // tbbEditar
            // 
            this.tbbEditar.Click += new System.EventHandler(this.tbbEditar_Click_1);
            // 
            // tbbBorrar
            // 
            this.tbbBorrar.Click += new System.EventHandler(this.tbbBorrar_Click_1);
            // 
            // tbbGuardar
            // 
            this.tbbGuardar.Click += new System.EventHandler(this.tbbGuardar_Click_1);
            // 
            // tbbCancelar
            // 
            this.tbbCancelar.Click += new System.EventHandler(this.tbbCancelar_Click);
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.Controls.Add(this.chkExcluirDeListados);
            this.pnlDetalle.Controls.Add(this.grpAsociacionPresup);
            this.pnlDetalle.Controls.Add(this.label32);
            this.pnlDetalle.Controls.Add(this.txtEstado);
            this.pnlDetalle.Controls.Add(this.label31);
            this.pnlDetalle.Controls.Add(this.txtSaldoCab);
            this.pnlDetalle.Controls.Add(this.txtImporte);
            this.pnlDetalle.Controls.Add(this.label29);
            this.pnlDetalle.Controls.Add(this.label19);
            this.pnlDetalle.Controls.Add(this.tSBMoneda);
            this.pnlDetalle.Controls.Add(this.txtFechaSolCab);
            this.pnlDetalle.Controls.Add(this.dtpFechaSolCab);
            this.pnlDetalle.Controls.Add(this.label17);
            this.pnlDetalle.Controls.Add(this.txtObservacion);
            this.pnlDetalle.Controls.Add(this.txtRefCliente);
            this.pnlDetalle.Controls.Add(this.label15);
            this.pnlDetalle.Controls.Add(this.label11);
            this.pnlDetalle.Controls.Add(this.label10);
            this.pnlDetalle.Controls.Add(this.tSBCliente);
            this.pnlDetalle.Controls.Add(this.grpTipoSolicitud);
            this.pnlDetalle.Controls.Add(this.grpGastoGeneral);
            this.pnlDetalle.Controls.Add(this.grpAsociadoaTramite);
            this.pnlDetalle.Controls.Add(this.cbOrigen);
            this.pnlDetalle.Controls.Add(this.label6);
            this.pnlDetalle.Controls.Add(this.label1);
            this.pnlDetalle.Controls.Add(this.txtSolPagoCabID);
            this.pnlDetalle.Size = new System.Drawing.Size(1281, 458);
            // 
            // tBBaseForm
            // 
            this.tBBaseForm.Size = new System.Drawing.Size(1289, 42);
            // 
            // tbbNuevo
            // 
            this.tbbNuevo.Click += new System.EventHandler(this.tbbNuevo_Click);
            // 
            // tabListaABM
            // 
            this.tabListaABM.Alignment = Gizmox.WebGUI.Forms.TabAlignment.Top;
            this.tabListaABM.Controls.Add(this.tabDetSolPag);
            this.tabListaABM.Size = new System.Drawing.Size(1289, 487);
            this.tabListaABM.SelectedIndexChanged += new System.EventHandler(this.tabListaABM_SelectedIndexChanged);
            this.tabListaABM.SelectedIndexChanging += new Gizmox.WebGUI.Forms.TabControlCancelEventHandler(this.tabListaABM_SelectedIndexChanging_1);
            this.pnlListadoContainer.Controls.SetChildIndex(this.dgvListadoABM, 0);
            // 
            // tabDetSolPag
            // 
            this.tabDetSolPag.Controls.Add(this.panel1);
            this.tabDetSolPag.Controls.Add(this.panel3);
            this.tabDetSolPag.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tabDetSolPag.Location = new System.Drawing.Point(0, 0);
            this.tabDetSolPag.Name = "tabDetSolPag";
            this.tabDetSolPag.Size = new System.Drawing.Size(1281, 458);
            this.tabDetSolPag.TabIndex = 2;
            this.tabDetSolPag.Text = "Detalles";
            this.tTBaseForm.SetToolTip(this.tabDetSolPag, "Detalles de la Solicitud de Pago");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvDetalleSolPago);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1281, 410);
            this.panel1.TabIndex = 1;
            // 
            // dgvDetalleSolPago
            // 
            this.dgvDetalleSolPago.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.dgvDetalleSolPago.Location = new System.Drawing.Point(10, 0);
            this.dgvDetalleSolPago.Name = "dgvDetalleSolPago";
            this.dgvDetalleSolPago.Size = new System.Drawing.Size(1261, 400);
            this.dgvDetalleSolPago.TabIndex = 0;
            this.dgvDetalleSolPago.DoubleClick += new System.EventHandler(this.dgvDetalleSolPago_DoubleClick);
            // 
            // panel6
            // 
            this.panel6.Dock = Gizmox.WebGUI.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(1271, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(10, 400);
            this.panel6.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(10, 400);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1271, 10);
            this.panel5.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 410);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnEliminarDetalle);
            this.panel3.Controls.Add(this.btnAgregarDetalle);
            this.panel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1281, 48);
            this.panel3.TabIndex = 0;
            // 
            // btnEliminarDetalle
            // 
            this.btnEliminarDetalle.BackColor = System.Drawing.Color.Transparent;
            this.btnEliminarDetalle.CustomStyle = "F";
            this.btnEliminarDetalle.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnEliminarDetalle.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnEliminarDetalle.Image"));
            this.btnEliminarDetalle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarDetalle.Location = new System.Drawing.Point(150, 4);
            this.btnEliminarDetalle.Name = "btnEliminarDetalle";
            this.btnEliminarDetalle.Size = new System.Drawing.Size(131, 39);
            this.btnEliminarDetalle.TabIndex = 0;
            this.btnEliminarDetalle.Text = "Eliminar Detalle";
            this.btnEliminarDetalle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminarDetalle.Click += new System.EventHandler(this.btnEliminarDetalle_Click);
            // 
            // btnAgregarDetalle
            // 
            this.btnAgregarDetalle.BackColor = System.Drawing.Color.Transparent;
            this.btnAgregarDetalle.CustomStyle = "F";
            this.btnAgregarDetalle.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnAgregarDetalle.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnAgregarDetalle.Image"));
            this.btnAgregarDetalle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarDetalle.Location = new System.Drawing.Point(10, 4);
            this.btnAgregarDetalle.Name = "btnAgregarDetalle";
            this.btnAgregarDetalle.Size = new System.Drawing.Size(131, 39);
            this.btnAgregarDetalle.TabIndex = 0;
            this.btnAgregarDetalle.Text = "Agregar Detalle";
            this.btnAgregarDetalle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarDetalle.Click += new System.EventHandler(this.btnAgregarDetalle_Click);
            // 
            // txtSolPagoCabID
            // 
            this.txtSolPagoCabID.BackColor = System.Drawing.SystemColors.Control;
            this.txtSolPagoCabID.Location = new System.Drawing.Point(143, 11);
            this.txtSolPagoCabID.Name = "txtSolPagoCabID";
            this.txtSolPagoCabID.ReadOnly = true;
            this.txtSolPagoCabID.Size = new System.Drawing.Size(96, 20);
            this.txtSolPagoCabID.TabIndex = 1;
            this.txtSolPagoCabID.TabStop = false;
            this.txtSolPagoCabID.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sol. Pago ID";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
            this.label6.Controls.Add(this.textBox5);
            this.label6.Controls.Add(this.label5);
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label6.Location = new System.Drawing.Point(459, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Origen";
            // 
            // cbOrigen
            // 
            this.cbOrigen.AllowDrag = false;
            this.cbOrigen.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cbOrigen.FormattingEnabled = true;
            this.cbOrigen.Location = new System.Drawing.Point(510, 11);
            this.cbOrigen.Name = "cbOrigen";
            this.cbOrigen.Size = new System.Drawing.Size(136, 21);
            this.cbOrigen.TabIndex = 1;
            // 
            // grpAsociadoaTramite
            // 
            this.grpAsociadoaTramite.Controls.Add(this.label36);
            this.grpAsociadoaTramite.Controls.Add(this.txtHINro);
            this.grpAsociadoaTramite.Controls.Add(this.label27);
            this.grpAsociadoaTramite.Controls.Add(this.txtHIAnio);
            this.grpAsociadoaTramite.Controls.Add(this.txtActaAnio);
            this.grpAsociadoaTramite.Controls.Add(this.label25);
            this.grpAsociadoaTramite.Controls.Add(this.txtOTID);
            this.grpAsociadoaTramite.Controls.Add(this.txtTramiteDescrip);
            this.grpAsociadoaTramite.Controls.Add(this.txtTramiteID);
            this.grpAsociadoaTramite.Controls.Add(this.label23);
            this.grpAsociadoaTramite.Controls.Add(this.txtActaNro);
            this.grpAsociadoaTramite.Controls.Add(this.txtExpedienteID);
            this.grpAsociadoaTramite.Controls.Add(this.grpBuscarExpediente);
            this.grpAsociadoaTramite.Controls.Add(this.label21);
            this.grpAsociadoaTramite.Controls.Add(this.label13);
            this.grpAsociadoaTramite.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.grpAsociadoaTramite.Location = new System.Drawing.Point(53, 164);
            this.grpAsociadoaTramite.Name = "grpAsociadoaTramite";
            this.grpAsociadoaTramite.Size = new System.Drawing.Size(436, 111);
            this.grpAsociadoaTramite.TabIndex = 7;
            this.grpAsociadoaTramite.TabStop = false;
            this.grpAsociadoaTramite.Text = "Asociado a Trámite";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(-112, 102);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(35, 13);
            this.label36.TabIndex = 0;
            this.label36.Text = "Asociados";
            this.label36.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtHINro
            // 
            this.txtHINro.BackColor = System.Drawing.SystemColors.Control;
            this.txtHINro.Location = new System.Drawing.Point(272, 87);
            this.txtHINro.Name = "txtHINro";
            this.txtHINro.ReadOnly = true;
            this.txtHINro.Size = new System.Drawing.Size(77, 18);
            this.txtHINro.TabIndex = 1;
            this.txtHINro.TabStop = false;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Controls.Add(this.textBox19);
            this.label27.Controls.Add(this.label26);
            this.label27.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label27.Location = new System.Drawing.Point(241, 90);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(46, 13);
            this.label27.TabIndex = 1;
            this.label27.Text = "H.I.";
            // 
            // textBox19
            // 
            this.textBox19.AllowDrag = false;
            this.textBox19.Location = new System.Drawing.Point(-184, -4);
            this.textBox19.Name = "textBox19";
            this.textBox19.ReadOnly = true;
            this.textBox19.Size = new System.Drawing.Size(100, 20);
            this.textBox19.TabIndex = 0;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label26.Location = new System.Drawing.Point(-279, -1);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(35, 13);
            this.label26.TabIndex = 1;
            this.label26.Text = "Cliente";
            // 
            // txtHIAnio
            // 
            this.txtHIAnio.BackColor = System.Drawing.SystemColors.Control;
            this.txtHIAnio.Location = new System.Drawing.Point(351, 87);
            this.txtHIAnio.Name = "txtHIAnio";
            this.txtHIAnio.ReadOnly = true;
            this.txtHIAnio.Size = new System.Drawing.Size(77, 18);
            this.txtHIAnio.TabIndex = 1;
            this.txtHIAnio.TabStop = false;
            // 
            // txtActaAnio
            // 
            this.txtActaAnio.BackColor = System.Drawing.SystemColors.Control;
            this.txtActaAnio.Location = new System.Drawing.Point(149, 87);
            this.txtActaAnio.Name = "txtActaAnio";
            this.txtActaAnio.ReadOnly = true;
            this.txtActaAnio.Size = new System.Drawing.Size(77, 18);
            this.txtActaAnio.TabIndex = 1;
            this.txtActaAnio.TabStop = false;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Controls.Add(this.textBox16);
            this.label25.Controls.Add(this.label24);
            this.label25.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label25.Location = new System.Drawing.Point(254, 50);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(46, 13);
            this.label25.TabIndex = 1;
            this.label25.Text = "OT ID";
            // 
            // textBox16
            // 
            this.textBox16.AllowDrag = false;
            this.textBox16.Location = new System.Drawing.Point(-184, -4);
            this.textBox16.Name = "textBox16";
            this.textBox16.ReadOnly = true;
            this.textBox16.Size = new System.Drawing.Size(100, 20);
            this.textBox16.TabIndex = 0;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label24.Location = new System.Drawing.Point(-279, -1);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(35, 13);
            this.label24.TabIndex = 1;
            this.label24.Text = "Cliente";
            // 
            // txtOTID
            // 
            this.txtOTID.BackColor = System.Drawing.SystemColors.Control;
            this.txtOTID.Location = new System.Drawing.Point(331, 47);
            this.txtOTID.Name = "txtOTID";
            this.txtOTID.ReadOnly = true;
            this.txtOTID.Size = new System.Drawing.Size(97, 18);
            this.txtOTID.TabIndex = 1;
            this.txtOTID.TabStop = false;
            // 
            // txtTramiteDescrip
            // 
            this.txtTramiteDescrip.BackColor = System.Drawing.SystemColors.Control;
            this.txtTramiteDescrip.Location = new System.Drawing.Point(117, 68);
            this.txtTramiteDescrip.Name = "txtTramiteDescrip";
            this.txtTramiteDescrip.ReadOnly = true;
            this.txtTramiteDescrip.Size = new System.Drawing.Size(311, 18);
            this.txtTramiteDescrip.TabIndex = 1;
            this.txtTramiteDescrip.TabStop = false;
            // 
            // txtTramiteID
            // 
            this.txtTramiteID.BackColor = System.Drawing.SystemColors.Control;
            this.txtTramiteID.Location = new System.Drawing.Point(70, 68);
            this.txtTramiteID.Name = "txtTramiteID";
            this.txtTramiteID.ReadOnly = true;
            this.txtTramiteID.Size = new System.Drawing.Size(45, 18);
            this.txtTramiteID.TabIndex = 1;
            this.txtTramiteID.TabStop = false;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Controls.Add(this.textBox13);
            this.label23.Controls.Add(this.label22);
            this.label23.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label23.Location = new System.Drawing.Point(6, 90);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(46, 13);
            this.label23.TabIndex = 1;
            this.label23.Text = "Acta";
            // 
            // textBox13
            // 
            this.textBox13.AllowDrag = false;
            this.textBox13.Location = new System.Drawing.Point(-184, -4);
            this.textBox13.Name = "textBox13";
            this.textBox13.ReadOnly = true;
            this.textBox13.Size = new System.Drawing.Size(100, 20);
            this.textBox13.TabIndex = 0;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label22.Location = new System.Drawing.Point(-279, -1);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(35, 13);
            this.label22.TabIndex = 1;
            this.label22.Text = "Cliente";
            // 
            // txtActaNro
            // 
            this.txtActaNro.BackColor = System.Drawing.SystemColors.Control;
            this.txtActaNro.Location = new System.Drawing.Point(70, 87);
            this.txtActaNro.Name = "txtActaNro";
            this.txtActaNro.ReadOnly = true;
            this.txtActaNro.Size = new System.Drawing.Size(77, 18);
            this.txtActaNro.TabIndex = 1;
            this.txtActaNro.TabStop = false;
            // 
            // txtExpedienteID
            // 
            this.txtExpedienteID.BackColor = System.Drawing.SystemColors.Control;
            this.txtExpedienteID.Location = new System.Drawing.Point(331, 25);
            this.txtExpedienteID.Name = "txtExpedienteID";
            this.txtExpedienteID.ReadOnly = true;
            this.txtExpedienteID.Size = new System.Drawing.Size(97, 18);
            this.txtExpedienteID.TabIndex = 1;
            this.txtExpedienteID.TabStop = false;
            // 
            // grpBuscarExpediente
            // 
            this.grpBuscarExpediente.Controls.Add(this.txtFiltroExpedienteID);
            this.grpBuscarExpediente.Controls.Add(this.cbCampoFiltro);
            this.grpBuscarExpediente.Controls.Add(this.btnFiltrar);
            this.grpBuscarExpediente.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.grpBuscarExpediente.Location = new System.Drawing.Point(7, 17);
            this.grpBuscarExpediente.Name = "grpBuscarExpediente";
            this.grpBuscarExpediente.Size = new System.Drawing.Size(243, 49);
            this.grpBuscarExpediente.TabIndex = 0;
            this.grpBuscarExpediente.TabStop = false;
            this.grpBuscarExpediente.Text = "Buscar Expediente";
            // 
            // txtFiltroExpedienteID
            // 
            this.txtFiltroExpedienteID.Location = new System.Drawing.Point(101, 19);
            this.txtFiltroExpedienteID.Name = "txtFiltroExpedienteID";
            this.txtFiltroExpedienteID.Size = new System.Drawing.Size(97, 18);
            this.txtFiltroExpedienteID.TabIndex = 1;
            // 
            // cbCampoFiltro
            // 
            this.cbCampoFiltro.AllowDrag = false;
            this.cbCampoFiltro.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cbCampoFiltro.FormattingEnabled = true;
            this.cbCampoFiltro.Location = new System.Drawing.Point(3, 18);
            this.cbCampoFiltro.Name = "cbCampoFiltro";
            this.cbCampoFiltro.Size = new System.Drawing.Size(95, 21);
            this.cbCampoFiltro.TabIndex = 0;
            this.cbCampoFiltro.SelectedIndexChanged += new System.EventHandler(this.cbCampoFiltro_SelectedIndexChanged);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnFiltrar.Image"));
            this.btnFiltrar.Location = new System.Drawing.Point(201, 8);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(40, 40);
            this.btnFiltrar.TabIndex = 2;
            this.tTBaseForm.SetToolTip(this.btnFiltrar, "Buscar Expediente");
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Controls.Add(this.textBox11);
            this.label21.Controls.Add(this.label20);
            this.label21.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label21.Location = new System.Drawing.Point(254, 28);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(46, 13);
            this.label21.TabIndex = 1;
            this.label21.Text = "N° Expediente";
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
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label20.Location = new System.Drawing.Point(-279, -1);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(35, 13);
            this.label20.TabIndex = 1;
            this.label20.Text = "Cliente";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Controls.Add(this.textBox4);
            this.label13.Controls.Add(this.label12);
            this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label13.Location = new System.Drawing.Point(6, 71);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 13);
            this.label13.TabIndex = 1;
            this.label13.Text = "Trámite";
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
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(-279, -1);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "Cliente";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label9.Location = new System.Drawing.Point(10, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Negocio";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label7.Location = new System.Drawing.Point(10, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Unidad de";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label3.Location = new System.Drawing.Point(10, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Gasto Gral.";
            // 
            // tSBUnidadNegocio
            // 
            this.tSBUnidadNegocio.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBUnidadNegocio.BackColor = System.Drawing.SystemColors.Control;
            this.tSBUnidadNegocio.DBContext = null;
            this.tSBUnidadNegocio.DisplayMember = "";
            this.tSBUnidadNegocio.KeyMember = "";
            this.tSBUnidadNegocio.LabelCampoBusqueda = "";
            this.tSBUnidadNegocio.Location = new System.Drawing.Point(88, 59);
            this.tSBUnidadNegocio.Name = "tSBUnidadNegocio";
            this.tSBUnidadNegocio.NombreCampoDescrip = "";
            this.tSBUnidadNegocio.NombreCampoID = "";
            this.tSBUnidadNegocio.Size = new System.Drawing.Size(333, 20);
            this.tSBUnidadNegocio.SoloLectura = false;
            this.tSBUnidadNegocio.TabIndex = 2;
            this.tSBUnidadNegocio.Text = "ucTextSearchBox";
            this.tSBUnidadNegocio.TituloBuscador = "";
            // 
            // tSBGastosGenerales
            // 
            this.tSBGastosGenerales.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBGastosGenerales.BackColor = System.Drawing.SystemColors.Control;
            this.tSBGastosGenerales.DBContext = null;
            this.tSBGastosGenerales.DisplayMember = "";
            this.tSBGastosGenerales.KeyMember = "";
            this.tSBGastosGenerales.LabelCampoBusqueda = "";
            this.tSBGastosGenerales.Location = new System.Drawing.Point(88, 17);
            this.tSBGastosGenerales.Name = "tSBGastosGenerales";
            this.tSBGastosGenerales.NombreCampoDescrip = "";
            this.tSBGastosGenerales.NombreCampoID = "";
            this.tSBGastosGenerales.Size = new System.Drawing.Size(333, 20);
            this.tSBGastosGenerales.SoloLectura = false;
            this.tSBGastosGenerales.TabIndex = 0;
            this.tSBGastosGenerales.Text = "ucTextSearchBox";
            this.tSBGastosGenerales.TituloBuscador = "";
            // 
            // grpGastoGeneral
            // 
            this.grpGastoGeneral.Controls.Add(this.label34);
            this.grpGastoGeneral.Controls.Add(this.tSBAreaContab);
            this.grpGastoGeneral.Controls.Add(this.tSBGastosGenerales);
            this.grpGastoGeneral.Controls.Add(this.label3);
            this.grpGastoGeneral.Controls.Add(this.label9);
            this.grpGastoGeneral.Controls.Add(this.tSBUnidadNegocio);
            this.grpGastoGeneral.Controls.Add(this.label7);
            this.grpGastoGeneral.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.grpGastoGeneral.Location = new System.Drawing.Point(53, 277);
            this.grpGastoGeneral.Name = "grpGastoGeneral";
            this.grpGastoGeneral.Size = new System.Drawing.Size(436, 86);
            this.grpGastoGeneral.TabIndex = 8;
            this.grpGastoGeneral.TabStop = false;
            this.grpGastoGeneral.Text = "Gasto General";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label34.Location = new System.Drawing.Point(10, 41);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(61, 13);
            this.label34.TabIndex = 1;
            this.label34.Text = "Área";
            // 
            // tSBAreaContab
            // 
            this.tSBAreaContab.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBAreaContab.BackColor = System.Drawing.SystemColors.Control;
            this.tSBAreaContab.DBContext = null;
            this.tSBAreaContab.DisplayMember = "";
            this.tSBAreaContab.KeyMember = "";
            this.tSBAreaContab.LabelCampoBusqueda = "";
            this.tSBAreaContab.Location = new System.Drawing.Point(88, 37);
            this.tSBAreaContab.Name = "tSBAreaContab";
            this.tSBAreaContab.NombreCampoDescrip = "";
            this.tSBAreaContab.NombreCampoID = "";
            this.tSBAreaContab.Size = new System.Drawing.Size(333, 20);
            this.tSBAreaContab.SoloLectura = false;
            this.tSBAreaContab.TabIndex = 1;
            this.tSBAreaContab.Text = "ucTextSearchBox";
            this.tSBAreaContab.TituloBuscador = "";
            // 
            // tSBMoneda
            // 
            this.tSBMoneda.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBMoneda.BackColor = System.Drawing.SystemColors.Control;
            this.tSBMoneda.DBContext = null;
            this.tSBMoneda.DisplayMember = "";
            this.tSBMoneda.KeyMember = "";
            this.tSBMoneda.LabelCampoBusqueda = "";
            this.tSBMoneda.Location = new System.Drawing.Point(143, 78);
            this.tSBMoneda.Name = "tSBMoneda";
            this.tSBMoneda.NombreCampoDescrip = "";
            this.tSBMoneda.NombreCampoID = "";
            this.tSBMoneda.Size = new System.Drawing.Size(467, 20);
            this.tSBMoneda.SoloLectura = false;
            this.tSBMoneda.TabIndex = 3;
            this.tSBMoneda.Text = "ucTextSearchBox";
            this.tSBMoneda.TituloBuscador = "";
            // 
            // grpTipoSolicitud
            // 
            this.grpTipoSolicitud.Controls.Add(this.rbGastosGrales);
            this.grpTipoSolicitud.Controls.Add(this.rbAsocTramite);
            this.grpTipoSolicitud.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.grpTipoSolicitud.Location = new System.Drawing.Point(622, 54);
            this.grpTipoSolicitud.Name = "grpTipoSolicitud";
            this.grpTipoSolicitud.Size = new System.Drawing.Size(333, 40);
            this.grpTipoSolicitud.TabIndex = 4;
            this.grpTipoSolicitud.TabStop = false;
            this.grpTipoSolicitud.Text = "Tipo Solicitud";
            // 
            // rbGastosGrales
            // 
            this.rbGastosGrales.AutoSize = true;
            this.rbGastosGrales.Location = new System.Drawing.Point(154, 16);
            this.rbGastosGrales.Name = "rbGastosGrales";
            this.rbGastosGrales.Size = new System.Drawing.Size(109, 17);
            this.rbGastosGrales.TabIndex = 1;
            this.rbGastosGrales.Text = "Gastos Generales";
            this.rbGastosGrales.CheckedChanged += new System.EventHandler(this.rbGastosGrales_CheckedChanged);
            // 
            // rbAsocTramite
            // 
            this.rbAsocTramite.AutoSize = true;
            this.rbAsocTramite.Location = new System.Drawing.Point(16, 16);
            this.rbAsocTramite.Name = "rbAsocTramite";
            this.rbAsocTramite.Size = new System.Drawing.Size(100, 17);
            this.rbAsocTramite.TabIndex = 0;
            this.rbAsocTramite.Text = "Asoc. a Trámite";
            this.rbAsocTramite.CheckedChanged += new System.EventHandler(this.rbAsocTramite_CheckedChanged);
            // 
            // tSBCliente
            // 
            this.tSBCliente.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBCliente.BackColor = System.Drawing.SystemColors.Control;
            this.tSBCliente.DBContext = null;
            this.tSBCliente.DisplayMember = "";
            this.tSBCliente.KeyMember = "";
            this.tSBCliente.LabelCampoBusqueda = "";
            this.tSBCliente.Location = new System.Drawing.Point(143, 55);
            this.tSBCliente.Name = "tSBCliente";
            this.tSBCliente.NombreCampoDescrip = "";
            this.tSBCliente.NombreCampoID = "";
            this.tSBCliente.Size = new System.Drawing.Size(467, 20);
            this.tSBCliente.SoloLectura = false;
            this.tSBCliente.TabIndex = 2;
            this.tSBCliente.Text = "ucTextSearchBox";
            this.tSBCliente.TituloBuscador = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(53, 59);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Cliente";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(53, 82);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Moneda";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.SystemColors.Control;
            this.textBox6.Location = new System.Drawing.Point(154, 56);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(279, 20);
            this.textBox6.TabIndex = 1;
            this.textBox6.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(-170, -1);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "Area";
            this.label14.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.SystemColors.Control;
            this.textBox7.Location = new System.Drawing.Point(-129, -4);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(50, 20);
            this.textBox7.TabIndex = 1;
            this.textBox7.TabStop = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Controls.Add(this.textBox6);
            this.label15.Controls.Add(this.label14);
            this.label15.Controls.Add(this.textBox7);
            this.label15.Location = new System.Drawing.Point(53, 111);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "Referencia";
            this.label15.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtRefCliente
            // 
            this.txtRefCliente.BackColor = System.Drawing.SystemColors.Window;
            this.txtRefCliente.Location = new System.Drawing.Point(143, 108);
            this.txtRefCliente.Multiline = true;
            this.txtRefCliente.Name = "txtRefCliente";
            this.txtRefCliente.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.txtRefCliente.Size = new System.Drawing.Size(343, 53);
            this.txtRefCliente.TabIndex = 5;
            // 
            // txtObservacion
            // 
            this.txtObservacion.BackColor = System.Drawing.SystemColors.Window;
            this.txtObservacion.Location = new System.Drawing.Point(611, 108);
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.txtObservacion.Size = new System.Drawing.Size(343, 53);
            this.txtObservacion.TabIndex = 6;
            // 
            // textBox9
            // 
            this.textBox9.BackColor = System.Drawing.SystemColors.Control;
            this.textBox9.Location = new System.Drawing.Point(154, 56);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(279, 20);
            this.textBox9.TabIndex = 1;
            this.textBox9.TabStop = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(-170, -1);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 13);
            this.label16.TabIndex = 0;
            this.label16.Text = "Area";
            this.label16.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBox10
            // 
            this.textBox10.BackColor = System.Drawing.SystemColors.Control;
            this.textBox10.Location = new System.Drawing.Point(-129, -4);
            this.textBox10.Name = "textBox10";
            this.textBox10.ReadOnly = true;
            this.textBox10.Size = new System.Drawing.Size(50, 20);
            this.textBox10.TabIndex = 1;
            this.textBox10.TabStop = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Controls.Add(this.textBox9);
            this.label17.Controls.Add(this.label16);
            this.label17.Controls.Add(this.textBox10);
            this.label17.Location = new System.Drawing.Point(514, 108);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(35, 13);
            this.label17.TabIndex = 0;
            this.label17.Text = "Observación";
            this.label17.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtFechaSolCab
            // 
            this.txtFechaSolCab.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0);
            this.txtFechaSolCab.Location = new System.Drawing.Point(349, 13);
            this.txtFechaSolCab.Name = "txtFechaSolCab";
            this.txtFechaSolCab.Size = new System.Drawing.Size(81, 18);
            this.txtFechaSolCab.TabIndex = 0;
            // 
            // dtpFechaSolCab
            // 
            this.dtpFechaSolCab.CustomFormat = "dd/mm/yyyy";
            this.dtpFechaSolCab.Location = new System.Drawing.Point(348, 11);
            this.dtpFechaSolCab.Name = "dtpFechaSolCab";
            this.dtpFechaSolCab.Size = new System.Drawing.Size(100, 21);
            this.dtpFechaSolCab.TabIndex = 3;
            this.dtpFechaSolCab.TabStop = false;
            this.dtpFechaSolCab.ValueChanged += new System.EventHandler(this.dtpFechaSolCab_ValueChanged);
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
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label18.Location = new System.Drawing.Point(-279, -1);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(35, 13);
            this.label18.TabIndex = 1;
            this.label18.Text = "Cliente";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Controls.Add(this.textBox8);
            this.label19.Controls.Add(this.label18);
            this.label19.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label19.Location = new System.Drawing.Point(260, 14);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(46, 13);
            this.label19.TabIndex = 1;
            this.label19.Text = "Fec. Solicitud";
            // 
            // textBox12
            // 
            this.textBox12.AllowDrag = false;
            this.textBox12.Location = new System.Drawing.Point(-184, -4);
            this.textBox12.Name = "textBox12";
            this.textBox12.ReadOnly = true;
            this.textBox12.Size = new System.Drawing.Size(100, 20);
            this.textBox12.TabIndex = 0;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label28.Location = new System.Drawing.Point(-279, -1);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(35, 13);
            this.label28.TabIndex = 1;
            this.label28.Text = "Cliente";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Controls.Add(this.textBox12);
            this.label29.Controls.Add(this.label28);
            this.label29.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label29.ForeColor = System.Drawing.Color.Maroon;
            this.label29.Location = new System.Drawing.Point(53, 37);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(46, 13);
            this.label29.TabIndex = 1;
            this.label29.Text = "Importe";
            // 
            // txtImporte
            // 
            this.txtImporte.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtImporte.ForeColor = System.Drawing.Color.Maroon;
            this.txtImporte.Location = new System.Drawing.Point(143, 34);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(103, 18);
            this.txtImporte.TabIndex = 0;
            this.txtImporte.Text = "0,00";
            this.txtImporte.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.txtImporte.Leave += new System.EventHandler(this.txtImporte_Leave);
            // 
            // txtSaldoCab
            // 
            this.txtSaldoCab.BackColor = System.Drawing.SystemColors.Control;
            this.txtSaldoCab.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtSaldoCab.ForeColor = System.Drawing.Color.Maroon;
            this.txtSaldoCab.Location = new System.Drawing.Point(322, 34);
            this.txtSaldoCab.Name = "txtSaldoCab";
            this.txtSaldoCab.ReadOnly = true;
            this.txtSaldoCab.Size = new System.Drawing.Size(103, 18);
            this.txtSaldoCab.TabIndex = 0;
            this.txtSaldoCab.TabStop = false;
            this.txtSaldoCab.Text = "0,00";
            this.txtSaldoCab.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // textBox15
            // 
            this.textBox15.AllowDrag = false;
            this.textBox15.Location = new System.Drawing.Point(-184, -4);
            this.textBox15.Name = "textBox15";
            this.textBox15.ReadOnly = true;
            this.textBox15.Size = new System.Drawing.Size(100, 20);
            this.textBox15.TabIndex = 0;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label30.Location = new System.Drawing.Point(-279, -1);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(35, 13);
            this.label30.TabIndex = 1;
            this.label30.Text = "Cliente";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Controls.Add(this.textBox15);
            this.label31.Controls.Add(this.label30);
            this.label31.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label31.ForeColor = System.Drawing.Color.Maroon;
            this.label31.Location = new System.Drawing.Point(260, 37);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(46, 13);
            this.label31.TabIndex = 1;
            this.label31.Text = "Saldo";
            // 
            // txtEstado
            // 
            this.txtEstado.BackColor = System.Drawing.SystemColors.Control;
            this.txtEstado.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtEstado.ForeColor = System.Drawing.Color.Black;
            this.txtEstado.Location = new System.Drawing.Point(510, 34);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.ReadOnly = true;
            this.txtEstado.Size = new System.Drawing.Size(136, 20);
            this.txtEstado.TabIndex = 1;
            this.txtEstado.TabStop = false;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(459, 37);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(35, 13);
            this.label32.TabIndex = 0;
            this.label32.Text = "Estado";
            this.label32.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // grpAsociacionPresup
            // 
            this.grpAsociacionPresup.Controls.Add(this.txtPresupAsoc);
            this.grpAsociacionPresup.Controls.Add(this.btnBuscar);
            this.grpAsociacionPresup.Controls.Add(this.label4);
            this.grpAsociacionPresup.Controls.Add(this.label33);
            this.grpAsociacionPresup.Controls.Add(this.cbTipoAsocPresup);
            this.grpAsociacionPresup.Controls.Add(this.txtPresupID);
            this.grpAsociacionPresup.Controls.Add(this.label37);
            this.grpAsociacionPresup.Controls.Add(this.label39);
            this.grpAsociacionPresup.Controls.Add(this.label41);
            this.grpAsociacionPresup.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.grpAsociacionPresup.Location = new System.Drawing.Point(514, 167);
            this.grpAsociacionPresup.Name = "grpAsociacionPresup";
            this.grpAsociacionPresup.Size = new System.Drawing.Size(436, 100);
            this.grpAsociacionPresup.TabIndex = 9;
            this.grpAsociacionPresup.TabStop = false;
            this.grpAsociacionPresup.Text = "Presupuestos Asociados";
            // 
            // txtPresupAsoc
            // 
            this.txtPresupAsoc.BackColor = System.Drawing.SystemColors.Control;
            this.txtPresupAsoc.Location = new System.Drawing.Point(70, 50);
            this.txtPresupAsoc.Name = "txtPresupAsoc";
            this.txtPresupAsoc.ReadOnly = true;
            this.txtPresupAsoc.Size = new System.Drawing.Size(325, 20);
            this.txtPresupAsoc.TabIndex = 1;
            this.txtPresupAsoc.TabStop = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(396, 50);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(34, 20);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "...";
            this.tTBaseForm.SetToolTip(this.btnBuscar, "Seleccionar Presupuestos");
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Controls.Add(this.textBox1);
            this.label4.Controls.Add(this.label2);
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label4.Location = new System.Drawing.Point(6, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Presup.";
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
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Controls.Add(this.textBox2);
            this.label33.Controls.Add(this.label8);
            this.label33.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label33.Location = new System.Drawing.Point(6, 63);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(34, 13);
            this.label33.TabIndex = 1;
            this.label33.Text = "Asoc.";
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(-279, -1);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Cliente";
            // 
            // cbTipoAsocPresup
            // 
            this.cbTipoAsocPresup.AllowDrag = false;
            this.cbTipoAsocPresup.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoAsocPresup.FormattingEnabled = true;
            this.cbTipoAsocPresup.Items.AddRange(new object[] {
            "Automática",
            "Manual"});
            this.cbTipoAsocPresup.Location = new System.Drawing.Point(70, 24);
            this.cbTipoAsocPresup.Name = "cbTipoAsocPresup";
            this.cbTipoAsocPresup.Size = new System.Drawing.Size(95, 21);
            this.cbTipoAsocPresup.TabIndex = 1;
            this.tTBaseForm.SetToolTip(this.cbTipoAsocPresup, "Determina si se buscará automáticamente el presupuesto asociado o si se ingresará" +
        " manualmente");
            this.cbTipoAsocPresup.SelectedIndexChanged += new System.EventHandler(this.cbTipoAsocPresup_SelectedIndexChanged);
            // 
            // txtPresupID
            // 
            this.txtPresupID.BackColor = System.Drawing.SystemColors.Control;
            this.txtPresupID.Location = new System.Drawing.Point(272, 26);
            this.txtPresupID.Name = "txtPresupID";
            this.txtPresupID.ReadOnly = true;
            this.txtPresupID.Size = new System.Drawing.Size(156, 18);
            this.txtPresupID.TabIndex = 1;
            this.txtPresupID.TabStop = false;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Controls.Add(this.textBox3);
            this.label37.Controls.Add(this.label35);
            this.label37.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label37.Location = new System.Drawing.Point(6, 25);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(42, 13);
            this.label37.TabIndex = 1;
            this.label37.Text = "Tipo de";
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
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label35.Location = new System.Drawing.Point(-279, -1);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(35, 13);
            this.label35.TabIndex = 1;
            this.label35.Text = "Cliente";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Controls.Add(this.textBox14);
            this.label39.Controls.Add(this.label38);
            this.label39.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label39.Location = new System.Drawing.Point(7, 37);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(57, 13);
            this.label39.TabIndex = 1;
            this.label39.Text = "Asociación";
            // 
            // textBox14
            // 
            this.textBox14.AllowDrag = false;
            this.textBox14.Location = new System.Drawing.Point(-184, -4);
            this.textBox14.Name = "textBox14";
            this.textBox14.ReadOnly = true;
            this.textBox14.Size = new System.Drawing.Size(100, 20);
            this.textBox14.TabIndex = 0;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label38.Location = new System.Drawing.Point(-279, -1);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(35, 13);
            this.label38.TabIndex = 1;
            this.label38.Text = "Cliente";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Controls.Add(this.textBox17);
            this.label41.Controls.Add(this.label40);
            this.label41.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label41.Location = new System.Drawing.Point(241, 29);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(18, 13);
            this.label41.TabIndex = 1;
            this.label41.Text = "ID";
            // 
            // textBox17
            // 
            this.textBox17.AllowDrag = false;
            this.textBox17.Location = new System.Drawing.Point(-184, -4);
            this.textBox17.Name = "textBox17";
            this.textBox17.ReadOnly = true;
            this.textBox17.Size = new System.Drawing.Size(100, 20);
            this.textBox17.TabIndex = 0;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label40.Location = new System.Drawing.Point(-279, -1);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(35, 13);
            this.label40.TabIndex = 1;
            this.label40.Text = "Cliente";
            // 
            // chkExcluirDeListados
            // 
            this.chkExcluirDeListados.AutoSize = true;
            this.chkExcluirDeListados.Location = new System.Drawing.Point(668, 7);
            this.chkExcluirDeListados.Name = "chkExcluirDeListados";
            this.chkExcluirDeListados.Size = new System.Drawing.Size(114, 17);
            this.chkExcluirDeListados.TabIndex = 10;
            this.chkExcluirDeListados.Text = "Excluir de Listados";
            // 
            // ucCRUDSolPago
            // 
            this.Size = new System.Drawing.Size(1291, 565);
            this.Text = "ucCRUDSolPago";
            this.Load += new System.EventHandler(this.ucCRUDSolPago_Load);
            this.VisibleChanged += new System.EventHandler(this.ucCRUDSolPago_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoABM)).EndInit();
            this.pnlDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabListaABM)).EndInit();
            this.tabListaABM.ResumeLayout(false);
            this.pnlListadoContainer.ResumeLayout(false);
            this.pnlContainer.ResumeLayout(false);
            this.pnlTabControl.ResumeLayout(false);
            this.tabDetSolPag.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleSolPago)).EndInit();
            this.panel3.ResumeLayout(false);
            this.label6.ResumeLayout(false);
            this.grpAsociadoaTramite.ResumeLayout(false);
            this.label27.ResumeLayout(false);
            this.label25.ResumeLayout(false);
            this.label23.ResumeLayout(false);
            this.grpBuscarExpediente.ResumeLayout(false);
            this.label21.ResumeLayout(false);
            this.label13.ResumeLayout(false);
            this.grpGastoGeneral.ResumeLayout(false);
            this.grpTipoSolicitud.ResumeLayout(false);
            this.label15.ResumeLayout(false);
            this.label17.ResumeLayout(false);
            this.label19.ResumeLayout(false);
            this.label29.ResumeLayout(false);
            this.label31.ResumeLayout(false);
            this.grpAsociacionPresup.ResumeLayout(false);
            this.label4.ResumeLayout(false);
            this.label33.ResumeLayout(false);
            this.label37.ResumeLayout(false);
            this.label39.ResumeLayout(false);
            this.label41.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TabPage tabDetSolPag;
        private Label label1;
        private TextBox txtSolPagoCabID;
        private ComboBox cbOrigen;
        private Label label6;
        private TextBox textBox5;
        private Label label5;
        private GroupBox grpGastoGeneral;
        private GroupBox grpAsociadoaTramite;
        private GroupBox grpTipoSolicitud;
        private RadioButton rbGastosGrales;
        private RadioButton rbAsocTramite;
        private Label label7;
        private Label label3;
        private Base.ucTextSearchBox tSBUnidadNegocio;
        private Base.ucTextSearchBox tSBGastosGenerales;
        private Label label9;
        private Label label11;
        private Label label10;
        private Base.ucTextSearchBox tSBCliente;
        private Base.ucTextSearchBox tSBMoneda;
        private Label label13;
        private TextBox textBox4;
        private Label label12;
        private Label label17;
        private TextBox textBox9;
        private Label label16;
        private TextBox textBox10;
        private TextBox txtObservacion;
        private TextBox txtRefCliente;
        private Label label15;
        private TextBox textBox6;
        private Label label14;
        private TextBox textBox7;
        private Label label19;
        private TextBox textBox8;
        private Label label18;
        private TextBox txtFechaSolCab;
        private DateTimePicker dtpFechaSolCab;
        private Label label21;
        private TextBox textBox11;
        private Label label20;
        private GroupBox grpBuscarExpediente;
        private TextBox txtFiltroExpedienteID;
        private ComboBox cbCampoFiltro;
        private Button btnFiltrar;
        private TextBox txtTramiteDescrip;
        private TextBox txtTramiteID;
        private Label label23;
        private TextBox textBox13;
        private Label label22;
        private TextBox txtActaNro;
        private TextBox txtExpedienteID;
        private Label label25;
        private TextBox textBox16;
        private Label label24;
        private TextBox txtOTID;
        private TextBox txtActaAnio;
        private TextBox txtHINro;
        private Label label27;
        private TextBox textBox19;
        private Label label26;
        private TextBox txtHIAnio;
        private TextBox txtImporte;
        private Label label29;
        private TextBox textBox12;
        private Label label28;
        private Panel panel1;
        private Panel panel3;
        private DataGridView dgvDetalleSolPago;
        private Panel panel6;
        private Panel panel5;
        private Panel panel2;
        private Button btnAgregarDetalle;
        private Button btnEliminarDetalle;
        private Label label31;
        private TextBox textBox15;
        private Label label30;
        private TextBox txtSaldoCab;
        private Label label32;
        private TextBox txtEstado;
        private Base.ucTextSearchBox tSBAreaContab;
        private Label label34;
        private Label label36;
        private GroupBox grpAsociacionPresup;
        private TextBox txtPresupAsoc;
        private Button btnBuscar;
        private Label label4;
        private TextBox textBox1;
        private Label label2;
        private Label label33;
        private TextBox textBox2;
        private Label label8;
        private ComboBox cbTipoAsocPresup;
        private TextBox txtPresupID;
        private Label label37;
        private TextBox textBox3;
        private Label label35;
        private Label label39;
        private TextBox textBox14;
        private Label label38;
        private Label label41;
        private TextBox textBox17;
        private Label label40;
        private CheckBox chkExcluirDeListados;


    }
}