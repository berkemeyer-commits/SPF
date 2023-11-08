using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.UserControls.UI
{
    partial class ucConsultaCotizacionesPorTramite
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucConsultaCotizacionesPorTramite));
            this.tbbAnular = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.Sep6 = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.tbbVerDocumento = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.tbbUpdDocs = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.pnlCabPresup = new Gizmox.WebGUI.Forms.Panel();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.dgvCotizaciones = new Gizmox.WebGUI.Forms.DataGridView();
            this.panel5 = new Gizmox.WebGUI.Forms.Panel();
            this.panel4 = new Gizmox.WebGUI.Forms.Panel();
            this.panel3 = new Gizmox.WebGUI.Forms.Panel();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.pnlTop = new Gizmox.WebGUI.Forms.Panel();
            this.txtFechaCotizacion = new Gizmox.WebGUI.Forms.TextBox();
            this.txtClienteNombre = new Gizmox.WebGUI.Forms.TextBox();
            this.txtClienteID = new Gizmox.WebGUI.Forms.TextBox();
            this.txtTramiteID = new Gizmox.WebGUI.Forms.TextBox();
            this.txtTramiteDescripcion = new Gizmox.WebGUI.Forms.TextBox();
            this.txtMonedaAbrev = new Gizmox.WebGUI.Forms.TextBox();
            this.txtTotal = new Gizmox.WebGUI.Forms.TextBox();
            this.txtNroDocumento = new Gizmox.WebGUI.Forms.TextBox();
            this.txtObservacion = new Gizmox.WebGUI.Forms.TextBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.label7 = new Gizmox.WebGUI.Forms.Label();
            this.txtCotizacionID = new Gizmox.WebGUI.Forms.TextBox();
            this.grpConfirmado = new Gizmox.WebGUI.Forms.GroupBox();
            this.rbConfirmadoNo = new Gizmox.WebGUI.Forms.RadioButton();
            this.rbConfirmadoSi = new Gizmox.WebGUI.Forms.RadioButton();
            this.label8 = new Gizmox.WebGUI.Forms.Label();
            this.tpAntecedentes = new Gizmox.WebGUI.Forms.TabPage();
            this.pnlExpedientes = new Gizmox.WebGUI.Forms.Panel();
            this.splCAntecedentes = new Gizmox.WebGUI.Forms.SplitContainer();
            this.grpAntecXCoti = new Gizmox.WebGUI.Forms.GroupBox();
            this.dgvAntecXCoti = new Gizmox.WebGUI.Forms.DataGridView();
            this.grpAntecXCliente = new Gizmox.WebGUI.Forms.GroupBox();
            this.dgvAntecXCliente = new Gizmox.WebGUI.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoABM)).BeginInit();
            this.pnlDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabListaABM)).BeginInit();
            this.tabListaABM.SuspendLayout();
            this.pnlListadoContainer.SuspendLayout();
            this.pnlContainer.SuspendLayout();
            this.pnlTabControl.SuspendLayout();
            this.pnlCabPresup.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCotizaciones)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.grpConfirmado.SuspendLayout();
            this.tpAntecedentes.SuspendLayout();
            this.pnlExpedientes.SuspendLayout();
            this.grpAntecXCoti.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAntecXCoti)).BeginInit();
            this.grpAntecXCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAntecXCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListadoABM
            // 
            this.dgvListadoABM.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.dgvListadoABM.Size = new System.Drawing.Size(1084, 395);
            this.dgvListadoABM.RowEnter += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.dgvListadoABM_RowEnter);
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.Controls.Add(this.pnlCabPresup);
            this.pnlDetalle.Size = new System.Drawing.Size(1104, 415);
            // 
            // tBBaseForm
            // 
            this.tBBaseForm.Buttons.AddRange(new Gizmox.WebGUI.Forms.ToolBarButton[] {
            this.tbbAnular,
            this.tbbVerDocumento,
            this.tbbUpdDocs,
            this.Sep6});
            this.tBBaseForm.Size = new System.Drawing.Size(1112, 42);
            // 
            // tabListaABM
            // 
            this.tabListaABM.Alignment = Gizmox.WebGUI.Forms.TabAlignment.Top;
            this.tabListaABM.Controls.Add(this.tpAntecedentes);
            this.pnlListadoContainer.Controls.SetChildIndex(this.dgvListadoABM, 0);
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
            // pnlCabPresup
            // 
            this.pnlCabPresup.Controls.Add(this.panel1);
            this.pnlCabPresup.Controls.Add(this.pnlTop);
            this.pnlCabPresup.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.pnlCabPresup.Location = new System.Drawing.Point(0, 0);
            this.pnlCabPresup.Name = "pnlCabPresup";
            this.pnlCabPresup.Size = new System.Drawing.Size(1104, 415);
            this.pnlCabPresup.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvCotizaciones);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 182);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1104, 233);
            this.panel1.TabIndex = 1;
            // 
            // dgvCotizaciones
            // 
            this.dgvCotizaciones.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.dgvCotizaciones.Location = new System.Drawing.Point(35, 10);
            this.dgvCotizaciones.Name = "dgvCotizaciones";
            this.dgvCotizaciones.Size = new System.Drawing.Size(1034, 213);
            this.dgvCotizaciones.TabIndex = 4;
            // 
            // panel5
            // 
            this.panel5.Dock = Gizmox.WebGUI.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(1069, 10);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(35, 213);
            this.panel5.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 10);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(35, 213);
            this.panel4.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 223);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1104, 10);
            this.panel3.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1104, 10);
            this.panel2.TabIndex = 0;
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.txtFechaCotizacion);
            this.pnlTop.Controls.Add(this.txtClienteNombre);
            this.pnlTop.Controls.Add(this.txtClienteID);
            this.pnlTop.Controls.Add(this.txtTramiteID);
            this.pnlTop.Controls.Add(this.txtTramiteDescripcion);
            this.pnlTop.Controls.Add(this.txtMonedaAbrev);
            this.pnlTop.Controls.Add(this.txtTotal);
            this.pnlTop.Controls.Add(this.txtNroDocumento);
            this.pnlTop.Controls.Add(this.txtObservacion);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Controls.Add(this.label2);
            this.pnlTop.Controls.Add(this.label3);
            this.pnlTop.Controls.Add(this.label4);
            this.pnlTop.Controls.Add(this.label5);
            this.pnlTop.Controls.Add(this.label6);
            this.pnlTop.Controls.Add(this.label7);
            this.pnlTop.Controls.Add(this.txtCotizacionID);
            this.pnlTop.Controls.Add(this.grpConfirmado);
            this.pnlTop.Controls.Add(this.label8);
            this.pnlTop.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1104, 182);
            this.pnlTop.TabIndex = 0;
            // 
            // txtFechaCotizacion
            // 
            this.txtFechaCotizacion.BackColor = System.Drawing.SystemColors.Control;
            this.txtFechaCotizacion.Location = new System.Drawing.Point(107, 22);
            this.txtFechaCotizacion.Name = "txtFechaCotizacion";
            this.txtFechaCotizacion.ReadOnly = true;
            this.txtFechaCotizacion.Size = new System.Drawing.Size(70, 20);
            this.txtFechaCotizacion.TabIndex = 0;
            this.txtFechaCotizacion.TabStop = false;
            // 
            // txtClienteNombre
            // 
            this.txtClienteNombre.BackColor = System.Drawing.SystemColors.Control;
            this.txtClienteNombre.Location = new System.Drawing.Point(179, 75);
            this.txtClienteNombre.Name = "txtClienteNombre";
            this.txtClienteNombre.ReadOnly = true;
            this.txtClienteNombre.Size = new System.Drawing.Size(309, 20);
            this.txtClienteNombre.TabIndex = 0;
            this.txtClienteNombre.TabStop = false;
            // 
            // txtClienteID
            // 
            this.txtClienteID.BackColor = System.Drawing.SystemColors.Control;
            this.txtClienteID.Location = new System.Drawing.Point(107, 75);
            this.txtClienteID.Name = "txtClienteID";
            this.txtClienteID.ReadOnly = true;
            this.txtClienteID.Size = new System.Drawing.Size(70, 20);
            this.txtClienteID.TabIndex = 0;
            this.txtClienteID.TabStop = false;
            // 
            // txtTramiteID
            // 
            this.txtTramiteID.BackColor = System.Drawing.SystemColors.Control;
            this.txtTramiteID.Location = new System.Drawing.Point(107, 100);
            this.txtTramiteID.Name = "txtTramiteID";
            this.txtTramiteID.ReadOnly = true;
            this.txtTramiteID.Size = new System.Drawing.Size(70, 20);
            this.txtTramiteID.TabIndex = 0;
            this.txtTramiteID.TabStop = false;
            // 
            // txtTramiteDescripcion
            // 
            this.txtTramiteDescripcion.BackColor = System.Drawing.SystemColors.Control;
            this.txtTramiteDescripcion.Location = new System.Drawing.Point(179, 100);
            this.txtTramiteDescripcion.Name = "txtTramiteDescripcion";
            this.txtTramiteDescripcion.ReadOnly = true;
            this.txtTramiteDescripcion.Size = new System.Drawing.Size(309, 20);
            this.txtTramiteDescripcion.TabIndex = 0;
            this.txtTramiteDescripcion.TabStop = false;
            // 
            // txtMonedaAbrev
            // 
            this.txtMonedaAbrev.BackColor = System.Drawing.SystemColors.Control;
            this.txtMonedaAbrev.Location = new System.Drawing.Point(179, 127);
            this.txtMonedaAbrev.Name = "txtMonedaAbrev";
            this.txtMonedaAbrev.ReadOnly = true;
            this.txtMonedaAbrev.Size = new System.Drawing.Size(61, 20);
            this.txtMonedaAbrev.TabIndex = 0;
            this.txtMonedaAbrev.TabStop = false;
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.SystemColors.Control;
            this.txtTotal.Location = new System.Drawing.Point(107, 127);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(70, 20);
            this.txtTotal.TabIndex = 0;
            this.txtTotal.TabStop = false;
            this.txtTotal.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // txtNroDocumento
            // 
            this.txtNroDocumento.BackColor = System.Drawing.SystemColors.Control;
            this.txtNroDocumento.Location = new System.Drawing.Point(304, 48);
            this.txtNroDocumento.Name = "txtNroDocumento";
            this.txtNroDocumento.ReadOnly = true;
            this.txtNroDocumento.Size = new System.Drawing.Size(70, 20);
            this.txtNroDocumento.TabIndex = 0;
            this.txtNroDocumento.TabStop = false;
            // 
            // txtObservacion
            // 
            this.txtObservacion.BackColor = System.Drawing.SystemColors.Control;
            this.txtObservacion.Location = new System.Drawing.Point(569, 23);
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.ReadOnly = true;
            this.txtObservacion.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.txtObservacion.Size = new System.Drawing.Size(381, 148);
            this.txtObservacion.TabIndex = 0;
            this.txtObservacion.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fec. Cotiz.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cliente";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Trámite";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Monto";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(216, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "N° Documento";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(497, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Observación";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "ID Cotización";
            // 
            // txtCotizacionID
            // 
            this.txtCotizacionID.BackColor = System.Drawing.SystemColors.Control;
            this.txtCotizacionID.Location = new System.Drawing.Point(107, 48);
            this.txtCotizacionID.Name = "txtCotizacionID";
            this.txtCotizacionID.ReadOnly = true;
            this.txtCotizacionID.Size = new System.Drawing.Size(102, 20);
            this.txtCotizacionID.TabIndex = 0;
            this.txtCotizacionID.TabStop = false;
            // 
            // grpConfirmado
            // 
            this.grpConfirmado.Controls.Add(this.rbConfirmadoNo);
            this.grpConfirmado.Controls.Add(this.rbConfirmadoSi);
            this.grpConfirmado.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.grpConfirmado.ForeColor = System.Drawing.Color.Black;
            this.grpConfirmado.Location = new System.Drawing.Point(304, 12);
            this.grpConfirmado.Name = "grpConfirmado";
            this.grpConfirmado.Size = new System.Drawing.Size(104, 35);
            this.grpConfirmado.TabIndex = 3;
            this.grpConfirmado.TabStop = false;
            // 
            // rbConfirmadoNo
            // 
            this.rbConfirmadoNo.AutoSize = true;
            this.rbConfirmadoNo.Enabled = false;
            this.rbConfirmadoNo.Location = new System.Drawing.Point(57, 12);
            this.rbConfirmadoNo.Name = "rbConfirmadoNo";
            this.rbConfirmadoNo.Size = new System.Drawing.Size(38, 17);
            this.rbConfirmadoNo.TabIndex = 2;
            this.rbConfirmadoNo.Text = "No";
            // 
            // rbConfirmadoSi
            // 
            this.rbConfirmadoSi.AutoSize = true;
            this.rbConfirmadoSi.Enabled = false;
            this.rbConfirmadoSi.Location = new System.Drawing.Point(5, 12);
            this.rbConfirmadoSi.Name = "rbConfirmadoSi";
            this.rbConfirmadoSi.Size = new System.Drawing.Size(33, 17);
            this.rbConfirmadoSi.TabIndex = 2;
            this.rbConfirmadoSi.Text = "Sí";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(216, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Confirmado";
            // 
            // tpAntecedentes
            // 
            this.tpAntecedentes.Controls.Add(this.pnlExpedientes);
            this.tpAntecedentes.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tpAntecedentes.Location = new System.Drawing.Point(0, 0);
            this.tpAntecedentes.Name = "tpAntecedentes";
            this.tpAntecedentes.Size = new System.Drawing.Size(1104, 415);
            this.tpAntecedentes.TabIndex = 2;
            this.tpAntecedentes.Text = "Antecedentes";
            // 
            // pnlExpedientes
            // 
            this.pnlExpedientes.Controls.Add(this.splCAntecedentes);
            this.pnlExpedientes.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.pnlExpedientes.Location = new System.Drawing.Point(0, 0);
            this.pnlExpedientes.Name = "pnlExpedientes";
            this.pnlExpedientes.Size = new System.Drawing.Size(1104, 415);
            this.pnlExpedientes.TabIndex = 0;
            // 
            // splCAntecedentes
            // 
            this.splCAntecedentes.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.splCAntecedentes.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.splCAntecedentes.Location = new System.Drawing.Point(0, 0);
            this.splCAntecedentes.Name = "splCAntecedentes";
            this.splCAntecedentes.Orientation = Gizmox.WebGUI.Forms.Orientation.Horizontal;
            // 
            // splCAntecedentes.Panel1
            // 
            this.splCAntecedentes.Panel1.Controls.Add(this.grpAntecXCoti);
            // 
            // splCAntecedentes.Panel2
            // 
            this.splCAntecedentes.Panel2.Controls.Add(this.grpAntecXCliente);
            this.splCAntecedentes.Size = new System.Drawing.Size(1104, 415);
            this.splCAntecedentes.SplitterDistance = 149;
            this.splCAntecedentes.TabIndex = 0;
            // 
            // grpAntecXCoti
            // 
            this.grpAntecXCoti.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0);
            this.grpAntecXCoti.Controls.Add(this.dgvAntecXCoti);
            this.grpAntecXCoti.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.grpAntecXCoti.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.grpAntecXCoti.Location = new System.Drawing.Point(0, 0);
            this.grpAntecXCoti.Name = "grpAntecXCoti";
            this.grpAntecXCoti.Size = new System.Drawing.Size(1104, 149);
            this.grpAntecXCoti.TabIndex = 0;
            this.grpAntecXCoti.TabStop = false;
            this.grpAntecXCoti.Text = "Por Cotización";
            // 
            // dgvAntecXCoti
            // 
            this.dgvAntecXCoti.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.dgvAntecXCoti.Location = new System.Drawing.Point(3, 17);
            this.dgvAntecXCoti.Name = "dgvAntecXCoti";
            this.dgvAntecXCoti.Size = new System.Drawing.Size(1098, 129);
            this.dgvAntecXCoti.TabIndex = 0;
            this.dgvAntecXCoti.CellFormatting += new Gizmox.WebGUI.Forms.DataGridViewCellFormattingEventHandler(this.dgvAntecXCoti_CellFormatting);
            // 
            // grpAntecXCliente
            // 
            this.grpAntecXCliente.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0);
            this.grpAntecXCliente.Controls.Add(this.dgvAntecXCliente);
            this.grpAntecXCliente.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.grpAntecXCliente.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.grpAntecXCliente.Location = new System.Drawing.Point(0, 0);
            this.grpAntecXCliente.Name = "grpAntecXCliente";
            this.grpAntecXCliente.Size = new System.Drawing.Size(1104, 262);
            this.grpAntecXCliente.TabIndex = 0;
            this.grpAntecXCliente.TabStop = false;
            this.grpAntecXCliente.Text = "Por Cliente";
            // 
            // dgvAntecXCliente
            // 
            this.dgvAntecXCliente.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.dgvAntecXCliente.Location = new System.Drawing.Point(3, 17);
            this.dgvAntecXCliente.Name = "dgvAntecXCliente";
            this.dgvAntecXCliente.Size = new System.Drawing.Size(1098, 242);
            this.dgvAntecXCliente.TabIndex = 0;
            // 
            // ucConsultaCotizacionesPorTramite
            // 
            this.Size = new System.Drawing.Size(1114, 522);
            this.Text = "ucCRUDPresupuesto";
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoABM)).EndInit();
            this.pnlDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabListaABM)).EndInit();
            this.tabListaABM.ResumeLayout(false);
            this.pnlListadoContainer.ResumeLayout(false);
            this.pnlContainer.ResumeLayout(false);
            this.pnlTabControl.ResumeLayout(false);
            this.pnlCabPresup.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCotizaciones)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.grpConfirmado.ResumeLayout(false);
            this.tpAntecedentes.ResumeLayout(false);
            this.pnlExpedientes.ResumeLayout(false);
            this.grpAntecXCoti.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAntecXCoti)).EndInit();
            this.grpAntecXCliente.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAntecXCliente)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ToolBarButton tbbAnular;
        private ToolBarButton Sep6;
        private ToolBarButton tbbVerDocumento;
        private ToolBarButton tbbUpdDocs;
        private Panel pnlCabPresup;
        private Panel panel1;
        private Panel panel5;
        private Panel panel4;
        private Panel panel3;
        private Panel panel2;
        private Panel pnlTop;
        private TextBox txtFechaCotizacion;
        private TextBox txtClienteNombre;
        private TextBox txtClienteID;
        private TextBox txtTramiteID;
        private TextBox txtTramiteDescripcion;
        private TextBox txtMonedaAbrev;
        private TextBox txtTotal;
        private TextBox txtNroDocumento;
        private TextBox txtObservacion;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox txtCotizacionID;
        private GroupBox grpConfirmado;
        private RadioButton rbConfirmadoNo;
        private RadioButton rbConfirmadoSi;
        private Label label8;
        private DataGridView dgvCotizaciones;
        private TabPage tpAntecedentes;
        private Panel pnlExpedientes;
        private SplitContainer splCAntecedentes;
        private GroupBox grpAntecXCoti;
        private DataGridView dgvAntecXCoti;
        private GroupBox grpAntecXCliente;
        private DataGridView dgvAntecXCliente;


    }
}