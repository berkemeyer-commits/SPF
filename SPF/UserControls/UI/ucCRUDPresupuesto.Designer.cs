using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.UserControls.UI
{
    partial class ucCRUDPresupuesto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucCRUDPresupuesto));
            this.tbbAnular = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.Sep6 = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.tbbVerDocumento = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.tbbUpdDocs = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.tpExpedientes = new Gizmox.WebGUI.Forms.TabPage();
            this.pnlExpedientes = new Gizmox.WebGUI.Forms.Panel();
            this.splCExpedientes = new Gizmox.WebGUI.Forms.SplitContainer();
            this.grpExpedientes = new Gizmox.WebGUI.Forms.GroupBox();
            this.dgvExpedientes = new Gizmox.WebGUI.Forms.DataGridView();
            this.grpCotizaciones = new Gizmox.WebGUI.Forms.GroupBox();
            this.dgvCotizaciones = new Gizmox.WebGUI.Forms.DataGridView();
            this.tbbVerFactura = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.Sep7 = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.txtFacturaCabID = new Gizmox.WebGUI.Forms.TextBox();
            this.lblBaja = new Gizmox.WebGUI.Forms.Label();
            this.textBox3 = new Gizmox.WebGUI.Forms.TextBox();
            this.label26 = new Gizmox.WebGUI.Forms.Label();
            this.textBox8 = new Gizmox.WebGUI.Forms.TextBox();
            this.label27 = new Gizmox.WebGUI.Forms.Label();
            this.txtDescripcion = new Gizmox.WebGUI.Forms.TextBox();
            this.txtTramiteDF = new Gizmox.WebGUI.Forms.TextBox();
            this.label25 = new Gizmox.WebGUI.Forms.Label();
            this.txtGeneradoPorNombre = new Gizmox.WebGUI.Forms.TextBox();
            this.label24 = new Gizmox.WebGUI.Forms.Label();
            this.txtGeneradoPorID = new Gizmox.WebGUI.Forms.TextBox();
            this.txtFacturaNro = new Gizmox.WebGUI.Forms.TextBox();
            this.label23 = new Gizmox.WebGUI.Forms.Label();
            this.txtTramiteDescrip = new Gizmox.WebGUI.Forms.TextBox();
            this.textBox6 = new Gizmox.WebGUI.Forms.TextBox();
            this.label21 = new Gizmox.WebGUI.Forms.Label();
            this.textBox7 = new Gizmox.WebGUI.Forms.TextBox();
            this.label22 = new Gizmox.WebGUI.Forms.Label();
            this.txtTramiteID = new Gizmox.WebGUI.Forms.TextBox();
            this.lblAutorizacionVigente = new Gizmox.WebGUI.Forms.Label();
            this.label20 = new Gizmox.WebGUI.Forms.Label();
            this.txtEstado = new Gizmox.WebGUI.Forms.TextBox();
            this.txtMonedaDescrip = new Gizmox.WebGUI.Forms.TextBox();
            this.textBox4 = new Gizmox.WebGUI.Forms.TextBox();
            this.label18 = new Gizmox.WebGUI.Forms.Label();
            this.textBox5 = new Gizmox.WebGUI.Forms.TextBox();
            this.label19 = new Gizmox.WebGUI.Forms.Label();
            this.txtMonedaAbrev = new Gizmox.WebGUI.Forms.TextBox();
            this.label16 = new Gizmox.WebGUI.Forms.Label();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.txtPresupID = new Gizmox.WebGUI.Forms.TextBox();
            this.txtMergeDocID = new Gizmox.WebGUI.Forms.TextBox();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.txtNroPresupuesto = new Gizmox.WebGUI.Forms.TextBox();
            this.txtClienteID = new Gizmox.WebGUI.Forms.TextBox();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.txtClienteNombre = new Gizmox.WebGUI.Forms.TextBox();
            this.txtAtencionNombre = new Gizmox.WebGUI.Forms.TextBox();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.txtAtencionID = new Gizmox.WebGUI.Forms.TextBox();
            this.txtAreaID = new Gizmox.WebGUI.Forms.TextBox();
            this.textBox2 = new Gizmox.WebGUI.Forms.TextBox();
            this.label17 = new Gizmox.WebGUI.Forms.Label();
            this.textBox1 = new Gizmox.WebGUI.Forms.TextBox();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.txtAreaDescripcion = new Gizmox.WebGUI.Forms.TextBox();
            this.txtHechoPorNombre = new Gizmox.WebGUI.Forms.TextBox();
            this.label7 = new Gizmox.WebGUI.Forms.Label();
            this.txtHechoPorID = new Gizmox.WebGUI.Forms.TextBox();
            this.txtAprobPorID = new Gizmox.WebGUI.Forms.TextBox();
            this.label8 = new Gizmox.WebGUI.Forms.Label();
            this.txtAprobPorNombre = new Gizmox.WebGUI.Forms.TextBox();
            this.txtSaldo = new Gizmox.WebGUI.Forms.TextBox();
            this.label9 = new Gizmox.WebGUI.Forms.Label();
            this.label10 = new Gizmox.WebGUI.Forms.Label();
            this.txtTotal = new Gizmox.WebGUI.Forms.TextBox();
            this.txtFecGeneracion = new Gizmox.WebGUI.Forms.TextBox();
            this.label11 = new Gizmox.WebGUI.Forms.Label();
            this.label12 = new Gizmox.WebGUI.Forms.Label();
            this.label13 = new Gizmox.WebGUI.Forms.Label();
            this.txtParteNombre = new Gizmox.WebGUI.Forms.TextBox();
            this.label14 = new Gizmox.WebGUI.Forms.Label();
            this.label15 = new Gizmox.WebGUI.Forms.Label();
            this.txtContraParteNombre = new Gizmox.WebGUI.Forms.TextBox();
            this.pnlCabPresup = new Gizmox.WebGUI.Forms.Panel();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.panel3 = new Gizmox.WebGUI.Forms.Panel();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.panel4 = new Gizmox.WebGUI.Forms.Panel();
            this.dgvDetPresup = new Gizmox.WebGUI.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoABM)).BeginInit();
            this.pnlDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabListaABM)).BeginInit();
            this.tabListaABM.SuspendLayout();
            this.pnlListadoContainer.SuspendLayout();
            this.pnlContainer.SuspendLayout();
            this.pnlTabControl.SuspendLayout();
            this.tpExpedientes.SuspendLayout();
            this.pnlExpedientes.SuspendLayout();
            this.grpExpedientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpedientes)).BeginInit();
            this.grpCotizaciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCotizaciones)).BeginInit();
            this.label27.SuspendLayout();
            this.label22.SuspendLayout();
            this.label19.SuspendLayout();
            this.label6.SuspendLayout();
            this.pnlCabPresup.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetPresup)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListadoABM
            // 
            this.dgvListadoABM.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.dgvListadoABM.Size = new System.Drawing.Size(1084, 395);
            this.dgvListadoABM.CellFormatting += new Gizmox.WebGUI.Forms.DataGridViewCellFormattingEventHandler(this.dgvListadoABM_CellFormatting);
            this.dgvListadoABM.RowEnter += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.dgvListadoABM_RowEnter);
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.Controls.Add(this.panel1);
            this.pnlDetalle.Controls.Add(this.pnlCabPresup);
            this.pnlDetalle.Size = new System.Drawing.Size(1104, 469);
            // 
            // tBBaseForm
            // 
            this.tBBaseForm.Buttons.AddRange(new Gizmox.WebGUI.Forms.ToolBarButton[] {
            this.tbbAnular,
            this.tbbVerDocumento,
            this.tbbUpdDocs,
            this.Sep6,
            this.tbbVerFactura,
            this.Sep7});
            this.tBBaseForm.Size = new System.Drawing.Size(1112, 42);
            // 
            // tabListaABM
            // 
            this.tabListaABM.Alignment = Gizmox.WebGUI.Forms.TabAlignment.Top;
            this.tabListaABM.Controls.Add(this.tpExpedientes);
            this.tabListaABM.Size = new System.Drawing.Size(1112, 498);
            this.tabListaABM.SelectedIndexChanged += new System.EventHandler(this.tabListaABM_SelectedIndexChanged);
            this.pnlListadoContainer.Controls.SetChildIndex(this.dgvListadoABM, 0);
            // 
            // pnlTabControl
            // 
            this.pnlTabControl.Size = new System.Drawing.Size(1112, 498);
            // 
            // tbbAnular
            // 
            this.tbbAnular.CustomStyle = "";
            this.tbbAnular.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tbbAnular.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("tbbAnular.Image"));
            this.tbbAnular.Name = "tbbAnular";
            this.tbbAnular.Size = 24;
            this.tbbAnular.Text = "A";
            this.tbbAnular.ToolTipText = "Permite anular un presupuesto generado si aún no tiene pagos asociados";
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
            // tbbVerDocumento
            // 
            this.tbbVerDocumento.CustomStyle = "";
            this.tbbVerDocumento.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tbbVerDocumento.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("tbbVerDocumento.Image"));
            this.tbbVerDocumento.Name = "tbbVerDocumento";
            this.tbbVerDocumento.Size = 24;
            this.tbbVerDocumento.Text = "VD";
            this.tbbVerDocumento.ToolTipText = "Descarga el documento a una ubicación local";
            this.tbbVerDocumento.Click += new System.EventHandler(this.tbbVerDocumento_Click);
            // 
            // tbbUpdDocs
            // 
            this.tbbUpdDocs.CustomStyle = "";
            this.tbbUpdDocs.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tbbUpdDocs.Name = "tbbUpdDocs";
            this.tbbUpdDocs.Size = 24;
            this.tbbUpdDocs.Text = "Actualizar";
            this.tbbUpdDocs.ToolTipText = "Actualiza los documentos editados localmente a la base de datos";
            // 
            // tpExpedientes
            // 
            this.tpExpedientes.Controls.Add(this.pnlExpedientes);
            this.tpExpedientes.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tpExpedientes.Location = new System.Drawing.Point(0, 0);
            this.tpExpedientes.Name = "tpExpedientes";
            this.tpExpedientes.Size = new System.Drawing.Size(1110, 430);
            this.tpExpedientes.TabIndex = 2;
            this.tpExpedientes.Text = "Expedientes";
            // 
            // pnlExpedientes
            // 
            this.pnlExpedientes.Controls.Add(this.splCExpedientes);
            this.pnlExpedientes.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.pnlExpedientes.Location = new System.Drawing.Point(0, 0);
            this.pnlExpedientes.Name = "pnlExpedientes";
            this.pnlExpedientes.Size = new System.Drawing.Size(1104, 415);
            this.pnlExpedientes.TabIndex = 0;
            // 
            // splCExpedientes
            // 
            this.splCExpedientes.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.splCExpedientes.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.splCExpedientes.Location = new System.Drawing.Point(0, 0);
            this.splCExpedientes.Name = "splCExpedientes";
            this.splCExpedientes.Orientation = Gizmox.WebGUI.Forms.Orientation.Horizontal;
            // 
            // splCExpedientes.Panel1
            // 
            this.splCExpedientes.Panel1.Controls.Add(this.grpExpedientes);
            // 
            // splCExpedientes.Panel2
            // 
            this.splCExpedientes.Panel2.Controls.Add(this.grpCotizaciones);
            this.splCExpedientes.Size = new System.Drawing.Size(1104, 415);
            this.splCExpedientes.SplitterDistance = 216;
            this.splCExpedientes.TabIndex = 0;
            // 
            // grpExpedientes
            // 
            this.grpExpedientes.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0);
            this.grpExpedientes.Controls.Add(this.dgvExpedientes);
            this.grpExpedientes.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.grpExpedientes.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.grpExpedientes.Location = new System.Drawing.Point(0, 0);
            this.grpExpedientes.Name = "grpExpedientes";
            this.grpExpedientes.Size = new System.Drawing.Size(1104, 216);
            this.grpExpedientes.TabIndex = 0;
            this.grpExpedientes.TabStop = false;
            this.grpExpedientes.Text = "Expedientes";
            // 
            // dgvExpedientes
            // 
            this.dgvExpedientes.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.dgvExpedientes.Location = new System.Drawing.Point(3, 17);
            this.dgvExpedientes.Name = "dgvExpedientes";
            this.dgvExpedientes.Size = new System.Drawing.Size(1098, 196);
            this.dgvExpedientes.TabIndex = 0;
            this.dgvExpedientes.CurrentCellChanged += new System.EventHandler(this.dgvExpedientes_CurrentCellChanged);
            // 
            // grpCotizaciones
            // 
            this.grpCotizaciones.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0);
            this.grpCotizaciones.Controls.Add(this.dgvCotizaciones);
            this.grpCotizaciones.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.grpCotizaciones.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.grpCotizaciones.Location = new System.Drawing.Point(0, 0);
            this.grpCotizaciones.Name = "grpCotizaciones";
            this.grpCotizaciones.Size = new System.Drawing.Size(1104, 195);
            this.grpCotizaciones.TabIndex = 0;
            this.grpCotizaciones.TabStop = false;
            this.grpCotizaciones.Text = "Cotizaciones";
            // 
            // dgvCotizaciones
            // 
            this.dgvCotizaciones.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.dgvCotizaciones.Location = new System.Drawing.Point(3, 17);
            this.dgvCotizaciones.Name = "dgvCotizaciones";
            this.dgvCotizaciones.Size = new System.Drawing.Size(1098, 175);
            this.dgvCotizaciones.TabIndex = 0;
            // 
            // tbbVerFactura
            // 
            this.tbbVerFactura.CustomStyle = "";
            this.tbbVerFactura.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tbbVerFactura.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("tbbVerFactura.Image"));
            this.tbbVerFactura.Name = "tbbVerFactura";
            this.tbbVerFactura.Size = 24;
            this.tbbVerFactura.Text = "VF";
            this.tbbVerFactura.ToolTipText = "Ver Factura Asociada";
            this.tbbVerFactura.Click += new System.EventHandler(this.tbbVerFactura_Click);
            // 
            // Sep7
            // 
            this.Sep7.CustomStyle = "";
            this.Sep7.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Sep7.Name = "Sep7";
            this.Sep7.Size = 24;
            this.Sep7.Style = Gizmox.WebGUI.Forms.ToolBarButtonStyle.Separator;
            this.Sep7.ToolTipText = "";
            // 
            // txtFacturaCabID
            // 
            this.txtFacturaCabID.BackColor = System.Drawing.SystemColors.Control;
            this.txtFacturaCabID.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtFacturaCabID.ForeColor = System.Drawing.Color.Black;
            this.txtFacturaCabID.Location = new System.Drawing.Point(904, 66);
            this.txtFacturaCabID.Name = "txtFacturaCabID";
            this.txtFacturaCabID.ReadOnly = true;
            this.txtFacturaCabID.Size = new System.Drawing.Size(100, 20);
            this.txtFacturaCabID.TabIndex = 1;
            this.txtFacturaCabID.TabStop = false;
            this.txtFacturaCabID.Visible = false;
            // 
            // lblBaja
            // 
            this.lblBaja.AutoSize = true;
            this.lblBaja.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblBaja.ForeColor = System.Drawing.Color.Red;
            this.lblBaja.Location = new System.Drawing.Point(796, 31);
            this.lblBaja.Name = "lblBaja";
            this.lblBaja.Size = new System.Drawing.Size(41, 13);
            this.lblBaja.TabIndex = 15;
            this.lblBaja.Text = "Baja para posterior cobro";
            this.lblBaja.Visible = false;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Control;
            this.textBox3.Location = new System.Drawing.Point(154, 56);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(279, 20);
            this.textBox3.TabIndex = 1;
            this.textBox3.TabStop = false;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(-170, -1);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(35, 13);
            this.label26.TabIndex = 0;
            this.label26.Text = "Area";
            this.label26.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBox8
            // 
            this.textBox8.BackColor = System.Drawing.SystemColors.Control;
            this.textBox8.Location = new System.Drawing.Point(-129, -4);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(50, 20);
            this.textBox8.TabIndex = 1;
            this.textBox8.TabStop = false;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Controls.Add(this.textBox3);
            this.label27.Controls.Add(this.label26);
            this.label27.Controls.Add(this.textBox8);
            this.label27.Location = new System.Drawing.Point(463, 138);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(35, 13);
            this.label27.TabIndex = 0;
            this.label27.Text = "Descripción";
            this.label27.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BackColor = System.Drawing.SystemColors.Control;
            this.txtDescripcion.Location = new System.Drawing.Point(541, 135);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ReadOnly = true;
            this.txtDescripcion.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.txtDescripcion.Size = new System.Drawing.Size(329, 51);
            this.txtDescripcion.TabIndex = 13;
            // 
            // txtTramiteDF
            // 
            this.txtTramiteDF.BackColor = System.Drawing.SystemColors.Control;
            this.txtTramiteDF.Location = new System.Drawing.Point(123, 135);
            this.txtTramiteDF.Multiline = true;
            this.txtTramiteDF.Name = "txtTramiteDF";
            this.txtTramiteDF.ReadOnly = true;
            this.txtTramiteDF.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.txtTramiteDF.Size = new System.Drawing.Size(329, 51);
            this.txtTramiteDF.TabIndex = 1;
            this.txtTramiteDF.TabStop = false;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(33, 138);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(35, 13);
            this.label25.TabIndex = 0;
            this.label25.Text = "Trámite DF";
            this.label25.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtGeneradoPorNombre
            // 
            this.txtGeneradoPorNombre.BackColor = System.Drawing.SystemColors.Control;
            this.txtGeneradoPorNombre.Location = new System.Drawing.Point(591, 187);
            this.txtGeneradoPorNombre.Name = "txtGeneradoPorNombre";
            this.txtGeneradoPorNombre.ReadOnly = true;
            this.txtGeneradoPorNombre.Size = new System.Drawing.Size(279, 20);
            this.txtGeneradoPorNombre.TabIndex = 1;
            this.txtGeneradoPorNombre.TabStop = false;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(463, 191);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(35, 13);
            this.label24.TabIndex = 0;
            this.label24.Text = "Gen. Por";
            this.label24.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtGeneradoPorID
            // 
            this.txtGeneradoPorID.BackColor = System.Drawing.SystemColors.Control;
            this.txtGeneradoPorID.Location = new System.Drawing.Point(541, 187);
            this.txtGeneradoPorID.Name = "txtGeneradoPorID";
            this.txtGeneradoPorID.ReadOnly = true;
            this.txtGeneradoPorID.Size = new System.Drawing.Size(50, 20);
            this.txtGeneradoPorID.TabIndex = 1;
            this.txtGeneradoPorID.TabStop = false;
            // 
            // txtFacturaNro
            // 
            this.txtFacturaNro.BackColor = System.Drawing.SystemColors.Control;
            this.txtFacturaNro.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtFacturaNro.ForeColor = System.Drawing.Color.Black;
            this.txtFacturaNro.Location = new System.Drawing.Point(524, 4);
            this.txtFacturaNro.Name = "txtFacturaNro";
            this.txtFacturaNro.ReadOnly = true;
            this.txtFacturaNro.Size = new System.Drawing.Size(117, 20);
            this.txtFacturaNro.TabIndex = 1;
            this.txtFacturaNro.TabStop = false;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(463, 6);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(35, 13);
            this.label23.TabIndex = 0;
            this.label23.Text = "N° Fact.";
            this.label23.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtTramiteDescrip
            // 
            this.txtTramiteDescrip.BackColor = System.Drawing.SystemColors.Control;
            this.txtTramiteDescrip.Location = new System.Drawing.Point(173, 49);
            this.txtTramiteDescrip.Name = "txtTramiteDescrip";
            this.txtTramiteDescrip.ReadOnly = true;
            this.txtTramiteDescrip.Size = new System.Drawing.Size(279, 20);
            this.txtTramiteDescrip.TabIndex = 1;
            this.txtTramiteDescrip.TabStop = false;
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
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(-170, -1);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(35, 13);
            this.label21.TabIndex = 0;
            this.label21.Text = "Area";
            this.label21.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Controls.Add(this.textBox6);
            this.label22.Controls.Add(this.label21);
            this.label22.Controls.Add(this.textBox7);
            this.label22.Location = new System.Drawing.Point(33, 53);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(35, 13);
            this.label22.TabIndex = 0;
            this.label22.Text = "Trámite";
            this.label22.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtTramiteID
            // 
            this.txtTramiteID.BackColor = System.Drawing.SystemColors.Control;
            this.txtTramiteID.Location = new System.Drawing.Point(123, 49);
            this.txtTramiteID.Name = "txtTramiteID";
            this.txtTramiteID.ReadOnly = true;
            this.txtTramiteID.Size = new System.Drawing.Size(50, 20);
            this.txtTramiteID.TabIndex = 1;
            this.txtTramiteID.TabStop = false;
            // 
            // lblAutorizacionVigente
            // 
            this.lblAutorizacionVigente.AutoSize = true;
            this.lblAutorizacionVigente.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblAutorizacionVigente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblAutorizacionVigente.Location = new System.Drawing.Point(33, 191);
            this.lblAutorizacionVigente.Name = "lblAutorizacionVigente";
            this.lblAutorizacionVigente.Size = new System.Drawing.Size(41, 13);
            this.lblAutorizacionVigente.TabIndex = 15;
            this.lblAutorizacionVigente.Text = "Autorización para modificación vigente";
            this.lblAutorizacionVigente.Visible = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(796, 8);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(35, 13);
            this.label20.TabIndex = 0;
            this.label20.Text = "Estado";
            this.label20.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtEstado
            // 
            this.txtEstado.BackColor = System.Drawing.SystemColors.Control;
            this.txtEstado.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtEstado.ForeColor = System.Drawing.Color.Black;
            this.txtEstado.Location = new System.Drawing.Point(841, 5);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.ReadOnly = true;
            this.txtEstado.Size = new System.Drawing.Size(100, 20);
            this.txtEstado.TabIndex = 1;
            this.txtEstado.TabStop = false;
            // 
            // txtMonedaDescrip
            // 
            this.txtMonedaDescrip.BackColor = System.Drawing.SystemColors.Control;
            this.txtMonedaDescrip.Location = new System.Drawing.Point(173, 27);
            this.txtMonedaDescrip.Name = "txtMonedaDescrip";
            this.txtMonedaDescrip.ReadOnly = true;
            this.txtMonedaDescrip.Size = new System.Drawing.Size(279, 20);
            this.txtMonedaDescrip.TabIndex = 1;
            this.txtMonedaDescrip.TabStop = false;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.Control;
            this.textBox4.Location = new System.Drawing.Point(154, 56);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(279, 20);
            this.textBox4.TabIndex = 1;
            this.textBox4.TabStop = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(-170, -1);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(35, 13);
            this.label18.TabIndex = 0;
            this.label18.Text = "Area";
            this.label18.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.SystemColors.Control;
            this.textBox5.Location = new System.Drawing.Point(-129, -4);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(50, 20);
            this.textBox5.TabIndex = 1;
            this.textBox5.TabStop = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Controls.Add(this.textBox4);
            this.label19.Controls.Add(this.label18);
            this.label19.Controls.Add(this.textBox5);
            this.label19.Location = new System.Drawing.Point(33, 30);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(35, 13);
            this.label19.TabIndex = 0;
            this.label19.Text = "Moneda";
            this.label19.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtMonedaAbrev
            // 
            this.txtMonedaAbrev.BackColor = System.Drawing.SystemColors.Control;
            this.txtMonedaAbrev.Location = new System.Drawing.Point(123, 27);
            this.txtMonedaAbrev.Name = "txtMonedaAbrev";
            this.txtMonedaAbrev.ReadOnly = true;
            this.txtMonedaAbrev.Size = new System.Drawing.Size(50, 20);
            this.txtMonedaAbrev.TabIndex = 1;
            this.txtMonedaAbrev.TabStop = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label16.Location = new System.Drawing.Point(33, 213);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 13);
            this.label16.TabIndex = 2;
            this.label16.Text = "Detalle del Presupuesto";
            this.label16.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Presup. ID";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtPresupID
            // 
            this.txtPresupID.BackColor = System.Drawing.SystemColors.Control;
            this.txtPresupID.Location = new System.Drawing.Point(123, 4);
            this.txtPresupID.Name = "txtPresupID";
            this.txtPresupID.ReadOnly = true;
            this.txtPresupID.Size = new System.Drawing.Size(64, 20);
            this.txtPresupID.TabIndex = 1;
            this.txtPresupID.TabStop = false;
            this.txtPresupID.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // txtMergeDocID
            // 
            this.txtMergeDocID.BackColor = System.Drawing.SystemColors.Control;
            this.txtMergeDocID.Location = new System.Drawing.Point(244, 4);
            this.txtMergeDocID.Name = "txtMergeDocID";
            this.txtMergeDocID.ReadOnly = true;
            this.txtMergeDocID.Size = new System.Drawing.Size(64, 20);
            this.txtMergeDocID.TabIndex = 1;
            this.txtMergeDocID.TabStop = false;
            this.txtMergeDocID.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(190, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Doc. ID";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(317, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "N° Presup.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtNroPresupuesto
            // 
            this.txtNroPresupuesto.BackColor = System.Drawing.SystemColors.Control;
            this.txtNroPresupuesto.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtNroPresupuesto.ForeColor = System.Drawing.Color.Black;
            this.txtNroPresupuesto.Location = new System.Drawing.Point(388, 4);
            this.txtNroPresupuesto.Name = "txtNroPresupuesto";
            this.txtNroPresupuesto.ReadOnly = true;
            this.txtNroPresupuesto.Size = new System.Drawing.Size(64, 20);
            this.txtNroPresupuesto.TabIndex = 1;
            this.txtNroPresupuesto.TabStop = false;
            // 
            // txtClienteID
            // 
            this.txtClienteID.BackColor = System.Drawing.SystemColors.Control;
            this.txtClienteID.Location = new System.Drawing.Point(123, 70);
            this.txtClienteID.Name = "txtClienteID";
            this.txtClienteID.ReadOnly = true;
            this.txtClienteID.Size = new System.Drawing.Size(50, 20);
            this.txtClienteID.TabIndex = 1;
            this.txtClienteID.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Cliente";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtClienteNombre
            // 
            this.txtClienteNombre.BackColor = System.Drawing.SystemColors.Control;
            this.txtClienteNombre.Location = new System.Drawing.Point(173, 70);
            this.txtClienteNombre.Name = "txtClienteNombre";
            this.txtClienteNombre.ReadOnly = true;
            this.txtClienteNombre.Size = new System.Drawing.Size(279, 20);
            this.txtClienteNombre.TabIndex = 1;
            this.txtClienteNombre.TabStop = false;
            // 
            // txtAtencionNombre
            // 
            this.txtAtencionNombre.BackColor = System.Drawing.SystemColors.Control;
            this.txtAtencionNombre.Location = new System.Drawing.Point(591, 70);
            this.txtAtencionNombre.Name = "txtAtencionNombre";
            this.txtAtencionNombre.ReadOnly = true;
            this.txtAtencionNombre.Size = new System.Drawing.Size(279, 20);
            this.txtAtencionNombre.TabIndex = 1;
            this.txtAtencionNombre.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(463, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Atención";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtAtencionID
            // 
            this.txtAtencionID.BackColor = System.Drawing.SystemColors.Control;
            this.txtAtencionID.Location = new System.Drawing.Point(541, 70);
            this.txtAtencionID.Name = "txtAtencionID";
            this.txtAtencionID.ReadOnly = true;
            this.txtAtencionID.Size = new System.Drawing.Size(50, 20);
            this.txtAtencionID.TabIndex = 1;
            this.txtAtencionID.TabStop = false;
            // 
            // txtAreaID
            // 
            this.txtAreaID.BackColor = System.Drawing.SystemColors.Control;
            this.txtAreaID.Location = new System.Drawing.Point(541, 48);
            this.txtAreaID.Name = "txtAreaID";
            this.txtAreaID.ReadOnly = true;
            this.txtAreaID.Size = new System.Drawing.Size(50, 20);
            this.txtAreaID.TabIndex = 1;
            this.txtAreaID.TabStop = false;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.Location = new System.Drawing.Point(154, 56);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(279, 20);
            this.textBox2.TabIndex = 1;
            this.textBox2.TabStop = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(-170, -1);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(35, 13);
            this.label17.TabIndex = 0;
            this.label17.Text = "Area";
            this.label17.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.Location = new System.Drawing.Point(-129, -4);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(50, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Controls.Add(this.textBox2);
            this.label6.Controls.Add(this.label17);
            this.label6.Controls.Add(this.textBox1);
            this.label6.Location = new System.Drawing.Point(463, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Area";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtAreaDescripcion
            // 
            this.txtAreaDescripcion.BackColor = System.Drawing.SystemColors.Control;
            this.txtAreaDescripcion.Location = new System.Drawing.Point(591, 48);
            this.txtAreaDescripcion.Name = "txtAreaDescripcion";
            this.txtAreaDescripcion.ReadOnly = true;
            this.txtAreaDescripcion.Size = new System.Drawing.Size(279, 20);
            this.txtAreaDescripcion.TabIndex = 1;
            this.txtAreaDescripcion.TabStop = false;
            // 
            // txtHechoPorNombre
            // 
            this.txtHechoPorNombre.BackColor = System.Drawing.SystemColors.Control;
            this.txtHechoPorNombre.Location = new System.Drawing.Point(173, 92);
            this.txtHechoPorNombre.Name = "txtHechoPorNombre";
            this.txtHechoPorNombre.ReadOnly = true;
            this.txtHechoPorNombre.Size = new System.Drawing.Size(279, 20);
            this.txtHechoPorNombre.TabIndex = 1;
            this.txtHechoPorNombre.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(33, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Responsable";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtHechoPorID
            // 
            this.txtHechoPorID.BackColor = System.Drawing.SystemColors.Control;
            this.txtHechoPorID.Location = new System.Drawing.Point(123, 92);
            this.txtHechoPorID.Name = "txtHechoPorID";
            this.txtHechoPorID.ReadOnly = true;
            this.txtHechoPorID.Size = new System.Drawing.Size(50, 20);
            this.txtHechoPorID.TabIndex = 1;
            this.txtHechoPorID.TabStop = false;
            // 
            // txtAprobPorID
            // 
            this.txtAprobPorID.BackColor = System.Drawing.SystemColors.Control;
            this.txtAprobPorID.Location = new System.Drawing.Point(541, 92);
            this.txtAprobPorID.Name = "txtAprobPorID";
            this.txtAprobPorID.ReadOnly = true;
            this.txtAprobPorID.Size = new System.Drawing.Size(50, 20);
            this.txtAprobPorID.TabIndex = 1;
            this.txtAprobPorID.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(463, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Aprob. Por";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtAprobPorNombre
            // 
            this.txtAprobPorNombre.BackColor = System.Drawing.SystemColors.Control;
            this.txtAprobPorNombre.Location = new System.Drawing.Point(591, 92);
            this.txtAprobPorNombre.Name = "txtAprobPorNombre";
            this.txtAprobPorNombre.ReadOnly = true;
            this.txtAprobPorNombre.Size = new System.Drawing.Size(279, 20);
            this.txtAprobPorNombre.TabIndex = 1;
            this.txtAprobPorNombre.TabStop = false;
            // 
            // txtSaldo
            // 
            this.txtSaldo.BackColor = System.Drawing.SystemColors.Control;
            this.txtSaldo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtSaldo.ForeColor = System.Drawing.Color.Red;
            this.txtSaldo.Location = new System.Drawing.Point(692, 27);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.ReadOnly = true;
            this.txtSaldo.Size = new System.Drawing.Size(100, 20);
            this.txtSaldo.TabIndex = 1;
            this.txtSaldo.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(645, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Saldo";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(463, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Total";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.SystemColors.Control;
            this.txtTotal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTotal.ForeColor = System.Drawing.Color.Black;
            this.txtTotal.Location = new System.Drawing.Point(541, 27);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(100, 20);
            this.txtTotal.TabIndex = 1;
            this.txtTotal.TabStop = false;
            // 
            // txtFecGeneracion
            // 
            this.txtFecGeneracion.BackColor = System.Drawing.SystemColors.Control;
            this.txtFecGeneracion.Location = new System.Drawing.Point(692, 5);
            this.txtFecGeneracion.Name = "txtFecGeneracion";
            this.txtFecGeneracion.ReadOnly = true;
            this.txtFecGeneracion.Size = new System.Drawing.Size(100, 20);
            this.txtFecGeneracion.TabIndex = 1;
            this.txtFecGeneracion.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(651, 5);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Fec.";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(651, 15);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Gen.";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(33, 117);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Parte Nombre";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtParteNombre
            // 
            this.txtParteNombre.BackColor = System.Drawing.SystemColors.Control;
            this.txtParteNombre.Location = new System.Drawing.Point(123, 114);
            this.txtParteNombre.Name = "txtParteNombre";
            this.txtParteNombre.ReadOnly = true;
            this.txtParteNombre.Size = new System.Drawing.Size(329, 20);
            this.txtParteNombre.TabIndex = 1;
            this.txtParteNombre.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(463, 121);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "Nombre";
            this.label14.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(463, 108);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "Contraparte";
            this.label15.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtContraParteNombre
            // 
            this.txtContraParteNombre.BackColor = System.Drawing.SystemColors.Control;
            this.txtContraParteNombre.Location = new System.Drawing.Point(541, 114);
            this.txtContraParteNombre.Name = "txtContraParteNombre";
            this.txtContraParteNombre.ReadOnly = true;
            this.txtContraParteNombre.Size = new System.Drawing.Size(329, 20);
            this.txtContraParteNombre.TabIndex = 1;
            this.txtContraParteNombre.TabStop = false;
            // 
            // pnlCabPresup
            // 
            this.pnlCabPresup.Controls.Add(this.txtFacturaCabID);
            this.pnlCabPresup.Controls.Add(this.lblBaja);
            this.pnlCabPresup.Controls.Add(this.label27);
            this.pnlCabPresup.Controls.Add(this.txtDescripcion);
            this.pnlCabPresup.Controls.Add(this.txtTramiteDF);
            this.pnlCabPresup.Controls.Add(this.label25);
            this.pnlCabPresup.Controls.Add(this.txtGeneradoPorNombre);
            this.pnlCabPresup.Controls.Add(this.label24);
            this.pnlCabPresup.Controls.Add(this.txtGeneradoPorID);
            this.pnlCabPresup.Controls.Add(this.txtFacturaNro);
            this.pnlCabPresup.Controls.Add(this.label23);
            this.pnlCabPresup.Controls.Add(this.txtTramiteDescrip);
            this.pnlCabPresup.Controls.Add(this.label22);
            this.pnlCabPresup.Controls.Add(this.txtTramiteID);
            this.pnlCabPresup.Controls.Add(this.lblAutorizacionVigente);
            this.pnlCabPresup.Controls.Add(this.label20);
            this.pnlCabPresup.Controls.Add(this.txtEstado);
            this.pnlCabPresup.Controls.Add(this.txtMonedaDescrip);
            this.pnlCabPresup.Controls.Add(this.label19);
            this.pnlCabPresup.Controls.Add(this.txtMonedaAbrev);
            this.pnlCabPresup.Controls.Add(this.label16);
            this.pnlCabPresup.Controls.Add(this.label1);
            this.pnlCabPresup.Controls.Add(this.txtPresupID);
            this.pnlCabPresup.Controls.Add(this.txtMergeDocID);
            this.pnlCabPresup.Controls.Add(this.label2);
            this.pnlCabPresup.Controls.Add(this.label3);
            this.pnlCabPresup.Controls.Add(this.txtNroPresupuesto);
            this.pnlCabPresup.Controls.Add(this.txtClienteID);
            this.pnlCabPresup.Controls.Add(this.label4);
            this.pnlCabPresup.Controls.Add(this.txtClienteNombre);
            this.pnlCabPresup.Controls.Add(this.txtAtencionNombre);
            this.pnlCabPresup.Controls.Add(this.label5);
            this.pnlCabPresup.Controls.Add(this.txtAtencionID);
            this.pnlCabPresup.Controls.Add(this.txtAreaID);
            this.pnlCabPresup.Controls.Add(this.label6);
            this.pnlCabPresup.Controls.Add(this.txtAreaDescripcion);
            this.pnlCabPresup.Controls.Add(this.txtHechoPorNombre);
            this.pnlCabPresup.Controls.Add(this.label7);
            this.pnlCabPresup.Controls.Add(this.txtHechoPorID);
            this.pnlCabPresup.Controls.Add(this.txtAprobPorID);
            this.pnlCabPresup.Controls.Add(this.label8);
            this.pnlCabPresup.Controls.Add(this.txtAprobPorNombre);
            this.pnlCabPresup.Controls.Add(this.txtSaldo);
            this.pnlCabPresup.Controls.Add(this.label9);
            this.pnlCabPresup.Controls.Add(this.label10);
            this.pnlCabPresup.Controls.Add(this.txtTotal);
            this.pnlCabPresup.Controls.Add(this.txtFecGeneracion);
            this.pnlCabPresup.Controls.Add(this.label11);
            this.pnlCabPresup.Controls.Add(this.label12);
            this.pnlCabPresup.Controls.Add(this.label13);
            this.pnlCabPresup.Controls.Add(this.txtParteNombre);
            this.pnlCabPresup.Controls.Add(this.label14);
            this.pnlCabPresup.Controls.Add(this.label15);
            this.pnlCabPresup.Controls.Add(this.txtContraParteNombre);
            this.pnlCabPresup.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.pnlCabPresup.Location = new System.Drawing.Point(0, 0);
            this.pnlCabPresup.Name = "pnlCabPresup";
            this.pnlCabPresup.Size = new System.Drawing.Size(1104, 231);
            this.pnlCabPresup.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvDetPresup);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 231);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1104, 238);
            this.panel1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(857, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(247, 238);
            this.panel3.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(35, 238);
            this.panel2.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(35, 228);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(822, 10);
            this.panel4.TabIndex = 2;
            // 
            // dgvDetPresup
            // 
            this.dgvDetPresup.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.dgvDetPresup.Location = new System.Drawing.Point(35, 0);
            this.dgvDetPresup.Name = "dgvDetPresup";
            this.dgvDetPresup.Size = new System.Drawing.Size(822, 228);
            this.dgvDetPresup.TabIndex = 2;
            // 
            // ucCRUDPresupuesto
            // 
            this.Size = new System.Drawing.Size(1114, 576);
            this.Text = "ucCRUDPresupuesto";
            this.Load += new System.EventHandler(this.ucCRUDPresupuesto_Load);
            this.VisibleChanged += new System.EventHandler(this.ucCRUDPresupuesto_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoABM)).EndInit();
            this.pnlDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabListaABM)).EndInit();
            this.tabListaABM.ResumeLayout(false);
            this.pnlListadoContainer.ResumeLayout(false);
            this.pnlContainer.ResumeLayout(false);
            this.pnlTabControl.ResumeLayout(false);
            this.tpExpedientes.ResumeLayout(false);
            this.pnlExpedientes.ResumeLayout(false);
            this.grpExpedientes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpedientes)).EndInit();
            this.grpCotizaciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCotizaciones)).EndInit();
            this.label27.ResumeLayout(false);
            this.label22.ResumeLayout(false);
            this.label19.ResumeLayout(false);
            this.label6.ResumeLayout(false);
            this.pnlCabPresup.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetPresup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ToolBarButton tbbAnular;
        private ToolBarButton Sep6;
        private ToolBarButton tbbVerDocumento;
        private ToolBarButton tbbUpdDocs;
        private TabPage tpExpedientes;
        private Panel pnlExpedientes;
        private SplitContainer splCExpedientes;
        private GroupBox grpExpedientes;
        private GroupBox grpCotizaciones;
        private DataGridView dgvExpedientes;
        private DataGridView dgvCotizaciones;
        private ToolBarButton tbbVerFactura;
        private ToolBarButton Sep7;
        private Panel panel1;
        private Panel pnlCabPresup;
        private TextBox txtFacturaCabID;
        private Label lblBaja;
        private Label label27;
        private TextBox textBox3;
        private Label label26;
        private TextBox textBox8;
        private TextBox txtDescripcion;
        private TextBox txtTramiteDF;
        private Label label25;
        private TextBox txtGeneradoPorNombre;
        private Label label24;
        private TextBox txtGeneradoPorID;
        private TextBox txtFacturaNro;
        private Label label23;
        private TextBox txtTramiteDescrip;
        private Label label22;
        private TextBox textBox6;
        private Label label21;
        private TextBox textBox7;
        private TextBox txtTramiteID;
        private Label lblAutorizacionVigente;
        private Label label20;
        private TextBox txtEstado;
        private TextBox txtMonedaDescrip;
        private Label label19;
        private TextBox textBox4;
        private Label label18;
        private TextBox textBox5;
        private TextBox txtMonedaAbrev;
        private Label label16;
        private Label label1;
        private TextBox txtPresupID;
        private TextBox txtMergeDocID;
        private Label label2;
        private Label label3;
        private TextBox txtNroPresupuesto;
        private TextBox txtClienteID;
        private Label label4;
        private TextBox txtClienteNombre;
        private TextBox txtAtencionNombre;
        private Label label5;
        private TextBox txtAtencionID;
        private TextBox txtAreaID;
        private Label label6;
        private TextBox textBox2;
        private Label label17;
        private TextBox textBox1;
        private TextBox txtAreaDescripcion;
        private TextBox txtHechoPorNombre;
        private Label label7;
        private TextBox txtHechoPorID;
        private TextBox txtAprobPorID;
        private Label label8;
        private TextBox txtAprobPorNombre;
        private TextBox txtSaldo;
        private Label label9;
        private Label label10;
        private TextBox txtTotal;
        private TextBox txtFecGeneracion;
        private Label label11;
        private Label label12;
        private Label label13;
        private TextBox txtParteNombre;
        private Label label14;
        private Label label15;
        private TextBox txtContraParteNombre;
        private Panel panel3;
        private Panel panel2;
        private DataGridView dgvDetPresup;
        private Panel panel4;


    }
}