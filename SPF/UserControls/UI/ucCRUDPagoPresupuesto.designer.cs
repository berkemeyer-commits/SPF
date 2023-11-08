using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.UserControls.UI
{
    partial class ucCRUDPagoPresupuesto
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucCRUDPagoPresupuesto));
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.txtPagoID = new Gizmox.WebGUI.Forms.TextBox();
            this.txtNroPresupuesto = new Gizmox.WebGUI.Forms.TextBox();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.txtFechaPago = new Gizmox.WebGUI.Forms.TextBox();
            this.dtpFechaPago = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.tSBMoneda = new SPF.UserControls.Base.ucTextSearchBox();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.label9 = new Gizmox.WebGUI.Forms.Label();
            this.tSBFormaPago = new SPF.UserControls.Base.ucTextSearchBox();
            this.txtNroCheque = new Gizmox.WebGUI.Forms.TextBox();
            this.label10 = new Gizmox.WebGUI.Forms.Label();
            this.tSBBancoCheque = new SPF.UserControls.Base.ucTextSearchBox();
            this.label12 = new Gizmox.WebGUI.Forms.Label();
            this.txtFechaDeposito = new Gizmox.WebGUI.Forms.TextBox();
            this.dtpFechaDeposito = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.txtMontoPago = new Gizmox.WebGUI.Forms.TextBox();
            this.label14 = new Gizmox.WebGUI.Forms.Label();
            this.label15 = new Gizmox.WebGUI.Forms.Label();
            this.txtGastoBancario = new Gizmox.WebGUI.Forms.TextBox();
            this.label16 = new Gizmox.WebGUI.Forms.Label();
            this.grpDeposito = new Gizmox.WebGUI.Forms.GroupBox();
            this.label27 = new Gizmox.WebGUI.Forms.Label();
            this.txtBoletaDepNro = new Gizmox.WebGUI.Forms.TextBox();
            this.label13 = new Gizmox.WebGUI.Forms.Label();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.tSBBancoDeposito = new SPF.UserControls.Base.ucTextSearchBox();
            this.tSBCuentaDeposito = new SPF.UserControls.Base.ucTextSearchBox();
            this.label8 = new Gizmox.WebGUI.Forms.Label();
            this.grpCheque = new Gizmox.WebGUI.Forms.GroupBox();
            this.txtReferencia = new Gizmox.WebGUI.Forms.TextBox();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.txtPresupuestoCabID = new Gizmox.WebGUI.Forms.TextBox();
            this.label7 = new Gizmox.WebGUI.Forms.Label();
            this.grpGastoBancario = new Gizmox.WebGUI.Forms.GroupBox();
            this.txtNotaCreditoNro = new Gizmox.WebGUI.Forms.TextBox();
            this.txtMonedaID = new Gizmox.WebGUI.Forms.TextBox();
            this.txtMonedaDescrip = new Gizmox.WebGUI.Forms.TextBox();
            this.label11 = new Gizmox.WebGUI.Forms.Label();
            this.label17 = new Gizmox.WebGUI.Forms.Label();
            this.txtFechaRecibo = new Gizmox.WebGUI.Forms.TextBox();
            this.dtpFechaRecibo = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.grpRecibo = new Gizmox.WebGUI.Forms.GroupBox();
            this.txtNroRecibo = new Gizmox.WebGUI.Forms.TextBox();
            this.label18 = new Gizmox.WebGUI.Forms.Label();
            this.label19 = new Gizmox.WebGUI.Forms.Label();
            this.tSBPresupuesto = new SPF.UserControls.Base.ucTextSearchBox();
            this.label20 = new Gizmox.WebGUI.Forms.Label();
            this.txtClienteNombre = new Gizmox.WebGUI.Forms.TextBox();
            this.txtClienteID = new Gizmox.WebGUI.Forms.TextBox();
            this.tbbAnular = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.Sep6 = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.lblAutorizacionVigente = new Gizmox.WebGUI.Forms.Label();
            this.label21 = new Gizmox.WebGUI.Forms.Label();
            this.txtEstado = new Gizmox.WebGUI.Forms.TextBox();
            this.txtSaldo = new Gizmox.WebGUI.Forms.TextBox();
            this.label22 = new Gizmox.WebGUI.Forms.Label();
            this.label23 = new Gizmox.WebGUI.Forms.Label();
            this.label24 = new Gizmox.WebGUI.Forms.Label();
            this.txtFechaNotaCredito = new Gizmox.WebGUI.Forms.TextBox();
            this.dtpFechaNotaCredito = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.grpNotaCredito = new Gizmox.WebGUI.Forms.GroupBox();
            this.lblNCSaldo = new Gizmox.WebGUI.Forms.Label();
            this.txtNCSaldo = new Gizmox.WebGUI.Forms.TextBox();
            this.txtNCTotal = new Gizmox.WebGUI.Forms.TextBox();
            this.lblNCTotal = new Gizmox.WebGUI.Forms.Label();
            this.tSBNotaCredito = new SPF.UserControls.Base.ucTextSearchBox();
            this.txtNotaCreditoCuerpo = new Gizmox.WebGUI.Forms.TextBox();
            this.label29 = new Gizmox.WebGUI.Forms.Label();
            this.label28 = new Gizmox.WebGUI.Forms.Label();
            this.txtReferenciaNotaCredito = new Gizmox.WebGUI.Forms.TextBox();
            this.lblIDNotaCredito = new Gizmox.WebGUI.Forms.Label();
            this.txtIdNotaCredito = new Gizmox.WebGUI.Forms.TextBox();
            this.label25 = new Gizmox.WebGUI.Forms.Label();
            this.txtNroFactura = new Gizmox.WebGUI.Forms.TextBox();
            this.txtIDPagoMultiple = new Gizmox.WebGUI.Forms.TextBox();
            this.label26 = new Gizmox.WebGUI.Forms.Label();
            this.clientStorage1 = new Gizmox.WebGUI.Forms.Client.ClientStorage();
            this.tSBRespCobroExterior = new SPF.UserControls.Base.ucTextSearchBox();
            this.label30 = new Gizmox.WebGUI.Forms.Label();
            this.label31 = new Gizmox.WebGUI.Forms.Label();
            this.txtGeneradoPorID = new Gizmox.WebGUI.Forms.TextBox();
            this.label32 = new Gizmox.WebGUI.Forms.Label();
            this.txtGeneradoPorNombre = new Gizmox.WebGUI.Forms.TextBox();
            this.ucTextSearchBox1 = new SPF.UserControls.Base.ucTextSearchBox();
            this.label33 = new Gizmox.WebGUI.Forms.Label();
            this.textBox1 = new Gizmox.WebGUI.Forms.TextBox();
            this.label34 = new Gizmox.WebGUI.Forms.Label();
            this.label35 = new Gizmox.WebGUI.Forms.Label();
            this.groupBox1 = new Gizmox.WebGUI.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoABM)).BeginInit();
            this.pnlDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabListaABM)).BeginInit();
            this.pnlListadoContainer.SuspendLayout();
            this.pnlContainer.SuspendLayout();
            this.pnlTabControl.SuspendLayout();
            this.grpDeposito.SuspendLayout();
            this.grpCheque.SuspendLayout();
            this.grpGastoBancario.SuspendLayout();
            this.grpRecibo.SuspendLayout();
            this.grpNotaCredito.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvListadoABM
            // 
            this.dgvListadoABM.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.dgvListadoABM.CellFormatting += new Gizmox.WebGUI.Forms.DataGridViewCellFormattingEventHandler(this.dgvListadoABM_CellFormatting);
            this.dgvListadoABM.RowEnter += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.dgvListadoABM_RowEnter);
            // 
            // tbbEditar
            // 
            this.tbbEditar.Click += new System.EventHandler(this.tbbEditar_Click);
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
            this.pnlDetalle.Controls.Add(this.groupBox1);
            this.pnlDetalle.Controls.Add(this.txtGeneradoPorNombre);
            this.pnlDetalle.Controls.Add(this.label32);
            this.pnlDetalle.Controls.Add(this.txtGeneradoPorID);
            this.pnlDetalle.Controls.Add(this.label30);
            this.pnlDetalle.Controls.Add(this.label31);
            this.pnlDetalle.Controls.Add(this.tSBRespCobroExterior);
            this.pnlDetalle.Controls.Add(this.label26);
            this.pnlDetalle.Controls.Add(this.txtIDPagoMultiple);
            this.pnlDetalle.Controls.Add(this.txtNroFactura);
            this.pnlDetalle.Controls.Add(this.label25);
            this.pnlDetalle.Controls.Add(this.grpNotaCredito);
            this.pnlDetalle.Controls.Add(this.label22);
            this.pnlDetalle.Controls.Add(this.txtSaldo);
            this.pnlDetalle.Controls.Add(this.txtEstado);
            this.pnlDetalle.Controls.Add(this.label21);
            this.pnlDetalle.Controls.Add(this.lblAutorizacionVigente);
            this.pnlDetalle.Controls.Add(this.txtClienteID);
            this.pnlDetalle.Controls.Add(this.txtClienteNombre);
            this.pnlDetalle.Controls.Add(this.label20);
            this.pnlDetalle.Controls.Add(this.tSBPresupuesto);
            this.pnlDetalle.Controls.Add(this.grpRecibo);
            this.pnlDetalle.Controls.Add(this.label19);
            this.pnlDetalle.Controls.Add(this.label11);
            this.pnlDetalle.Controls.Add(this.txtMonedaDescrip);
            this.pnlDetalle.Controls.Add(this.txtMonedaID);
            this.pnlDetalle.Controls.Add(this.grpGastoBancario);
            this.pnlDetalle.Controls.Add(this.label7);
            this.pnlDetalle.Controls.Add(this.txtPresupuestoCabID);
            this.pnlDetalle.Controls.Add(this.label6);
            this.pnlDetalle.Controls.Add(this.txtReferencia);
            this.pnlDetalle.Controls.Add(this.grpCheque);
            this.pnlDetalle.Controls.Add(this.grpDeposito);
            this.pnlDetalle.Controls.Add(this.label14);
            this.pnlDetalle.Controls.Add(this.txtMontoPago);
            this.pnlDetalle.Controls.Add(this.tSBFormaPago);
            this.pnlDetalle.Controls.Add(this.label9);
            this.pnlDetalle.Controls.Add(this.txtFechaPago);
            this.pnlDetalle.Controls.Add(this.dtpFechaPago);
            this.pnlDetalle.Controls.Add(this.label3);
            this.pnlDetalle.Controls.Add(this.label2);
            this.pnlDetalle.Controls.Add(this.txtNroPresupuesto);
            this.pnlDetalle.Controls.Add(this.txtPagoID);
            this.pnlDetalle.Controls.Add(this.label1);
            this.pnlDetalle.Click += new System.EventHandler(this.pnlDetalle_Click);
            // 
            // tBBaseForm
            // 
            this.tBBaseForm.Buttons.AddRange(new Gizmox.WebGUI.Forms.ToolBarButton[] {
            this.tbbAnular,
            this.Sep6});
            // 
            // tbbNuevo
            // 
            this.tbbNuevo.Click += new System.EventHandler(this.tbbNuevo_Click);
            // 
            // tabListaABM
            // 
            this.tabListaABM.Alignment = Gizmox.WebGUI.Forms.TabAlignment.Top;
            this.tabListaABM.SelectedIndexChanged += new System.EventHandler(this.tabListaABM_SelectedIndexChanged);
            this.pnlListadoContainer.Controls.SetChildIndex(this.dgvListadoABM, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID Cobro";
            // 
            // txtPagoID
            // 
            this.txtPagoID.BackColor = System.Drawing.SystemColors.Control;
            this.txtPagoID.Location = new System.Drawing.Point(111, 6);
            this.txtPagoID.Name = "txtPagoID";
            this.txtPagoID.ReadOnly = true;
            this.txtPagoID.Size = new System.Drawing.Size(113, 20);
            this.txtPagoID.TabIndex = 1;
            this.txtPagoID.TabStop = false;
            // 
            // txtNroPresupuesto
            // 
            this.txtNroPresupuesto.BackColor = System.Drawing.SystemColors.Control;
            this.txtNroPresupuesto.Location = new System.Drawing.Point(111, 48);
            this.txtNroPresupuesto.Name = "txtNroPresupuesto";
            this.txtNroPresupuesto.ReadOnly = true;
            this.txtNroPresupuesto.Size = new System.Drawing.Size(113, 20);
            this.txtNroPresupuesto.TabIndex = 1;
            this.txtNroPresupuesto.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "N° Presup.";
            // 
            // txtFechaPago
            // 
            this.txtFechaPago.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0);
            this.txtFechaPago.Location = new System.Drawing.Point(776, 49);
            this.txtFechaPago.Name = "txtFechaPago";
            this.txtFechaPago.Size = new System.Drawing.Size(81, 18);
            this.txtFechaPago.TabIndex = 5;
            // 
            // dtpFechaPago
            // 
            this.dtpFechaPago.CustomFormat = "dd/mm/yyyy";
            this.dtpFechaPago.Location = new System.Drawing.Point(775, 48);
            this.dtpFechaPago.Name = "dtpFechaPago";
            this.dtpFechaPago.Size = new System.Drawing.Size(100, 21);
            this.dtpFechaPago.TabIndex = 3;
            this.dtpFechaPago.TabStop = false;
            this.dtpFechaPago.ValueChanged += new System.EventHandler(this.dtpFechaPago_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(716, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Fec. Cobro";
            // 
            // tSBMoneda
            // 
            this.tSBMoneda.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBMoneda.BackColor = System.Drawing.Color.Transparent;
            this.tSBMoneda.DBContext = null;
            this.tSBMoneda.DisplayMember = "";
            this.tSBMoneda.KeyMember = "";
            this.tSBMoneda.LabelCampoBusqueda = "";
            this.tSBMoneda.Location = new System.Drawing.Point(74, 16);
            this.tSBMoneda.Name = "tSBMoneda";
            this.tSBMoneda.NombreCampoDescrip = "";
            this.tSBMoneda.NombreCampoID = "";
            this.tSBMoneda.Size = new System.Drawing.Size(387, 20);
            this.tSBMoneda.SoloLectura = false;
            this.tSBMoneda.TabIndex = 0;
            this.tSBMoneda.Text = "ucTextSearchBox";
            this.tSBMoneda.TituloBuscador = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Moneda";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(537, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Forma Cobro";
            // 
            // tSBFormaPago
            // 
            this.tSBFormaPago.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBFormaPago.BackColor = System.Drawing.Color.Transparent;
            this.tSBFormaPago.DBContext = null;
            this.tSBFormaPago.DisplayMember = "";
            this.tSBFormaPago.KeyMember = "";
            this.tSBFormaPago.LabelCampoBusqueda = "";
            this.tSBFormaPago.Location = new System.Drawing.Point(611, 6);
            this.tSBFormaPago.Name = "tSBFormaPago";
            this.tSBFormaPago.NombreCampoDescrip = "";
            this.tSBFormaPago.NombreCampoID = "";
            this.tSBFormaPago.Size = new System.Drawing.Size(387, 20);
            this.tSBFormaPago.SoloLectura = false;
            this.tSBFormaPago.TabIndex = 2;
            this.tSBFormaPago.Text = "ucTextSearchBox";
            this.tSBFormaPago.TituloBuscador = "";
            this.tSBFormaPago.Leave += new System.EventHandler(this.tSBFormaPago_Leave);
            // 
            // txtNroCheque
            // 
            this.txtNroCheque.Location = new System.Drawing.Point(75, 46);
            this.txtNroCheque.Name = "txtNroCheque";
            this.txtNroCheque.Size = new System.Drawing.Size(224, 20);
            this.txtNroCheque.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "N°";
            // 
            // tSBBancoCheque
            // 
            this.tSBBancoCheque.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBBancoCheque.BackColor = System.Drawing.Color.Transparent;
            this.tSBBancoCheque.DBContext = null;
            this.tSBBancoCheque.DisplayMember = "";
            this.tSBBancoCheque.KeyMember = "";
            this.tSBBancoCheque.LabelCampoBusqueda = "";
            this.tSBBancoCheque.Location = new System.Drawing.Point(75, 24);
            this.tSBBancoCheque.Name = "tSBBancoCheque";
            this.tSBBancoCheque.NombreCampoDescrip = "";
            this.tSBBancoCheque.NombreCampoID = "";
            this.tSBBancoCheque.Size = new System.Drawing.Size(387, 20);
            this.tSBBancoCheque.SoloLectura = false;
            this.tSBBancoCheque.TabIndex = 0;
            this.tSBBancoCheque.Text = "ucTextSearchBox";
            this.tSBBancoCheque.TituloBuscador = "";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 28);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(36, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Banco";
            // 
            // txtFechaDeposito
            // 
            this.txtFechaDeposito.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0);
            this.txtFechaDeposito.Location = new System.Drawing.Point(75, 18);
            this.txtFechaDeposito.Name = "txtFechaDeposito";
            this.txtFechaDeposito.Size = new System.Drawing.Size(81, 18);
            this.txtFechaDeposito.TabIndex = 0;
            // 
            // dtpFechaDeposito
            // 
            this.dtpFechaDeposito.CustomFormat = "dd/mm/yyyy";
            this.dtpFechaDeposito.Location = new System.Drawing.Point(74, 17);
            this.dtpFechaDeposito.Name = "dtpFechaDeposito";
            this.dtpFechaDeposito.Size = new System.Drawing.Size(100, 21);
            this.dtpFechaDeposito.TabIndex = 3;
            this.dtpFechaDeposito.TabStop = false;
            this.dtpFechaDeposito.ValueChanged += new System.EventHandler(this.dtpFechaDeposito_ValueChanged);
            // 
            // txtMontoPago
            // 
            this.txtMontoPago.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtMontoPago.Location = new System.Drawing.Point(611, 48);
            this.txtMontoPago.Name = "txtMontoPago";
            this.txtMontoPago.Size = new System.Drawing.Size(99, 20);
            this.txtMontoPago.TabIndex = 4;
            this.txtMontoPago.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(537, 52);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "Monto";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(11, 32);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(55, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "Diferencia";
            // 
            // txtGastoBancario
            // 
            this.txtGastoBancario.Location = new System.Drawing.Point(74, 38);
            this.txtGastoBancario.Name = "txtGastoBancario";
            this.txtGastoBancario.Size = new System.Drawing.Size(132, 20);
            this.txtGastoBancario.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(11, 44);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(54, 13);
            this.label16.TabIndex = 0;
            this.label16.Text = "Cambiaria";
            // 
            // grpDeposito
            // 
            this.grpDeposito.Controls.Add(this.label27);
            this.grpDeposito.Controls.Add(this.txtBoletaDepNro);
            this.grpDeposito.Controls.Add(this.label13);
            this.grpDeposito.Controls.Add(this.label5);
            this.grpDeposito.Controls.Add(this.tSBBancoDeposito);
            this.grpDeposito.Controls.Add(this.txtFechaDeposito);
            this.grpDeposito.Controls.Add(this.tSBCuentaDeposito);
            this.grpDeposito.Controls.Add(this.label8);
            this.grpDeposito.Controls.Add(this.dtpFechaDeposito);
            this.grpDeposito.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.grpDeposito.Location = new System.Drawing.Point(36, 137);
            this.grpDeposito.Name = "grpDeposito";
            this.grpDeposito.Size = new System.Drawing.Size(469, 87);
            this.grpDeposito.TabIndex = 7;
            this.grpDeposito.TabStop = false;
            this.grpDeposito.Text = "Datos Depósito";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(198, 21);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(59, 13);
            this.label27.TabIndex = 0;
            this.label27.Text = "Boleta N°";
            // 
            // txtBoletaDepNro
            // 
            this.txtBoletaDepNro.Location = new System.Drawing.Point(252, 17);
            this.txtBoletaDepNro.Name = "txtBoletaDepNro";
            this.txtBoletaDepNro.Size = new System.Drawing.Size(171, 20);
            this.txtBoletaDepNro.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(11, 21);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Fecha";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Banco";
            // 
            // tSBBancoDeposito
            // 
            this.tSBBancoDeposito.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBBancoDeposito.BackColor = System.Drawing.Color.Transparent;
            this.tSBBancoDeposito.DBContext = null;
            this.tSBBancoDeposito.DisplayMember = "";
            this.tSBBancoDeposito.KeyMember = "";
            this.tSBBancoDeposito.LabelCampoBusqueda = "";
            this.tSBBancoDeposito.Location = new System.Drawing.Point(74, 39);
            this.tSBBancoDeposito.Name = "tSBBancoDeposito";
            this.tSBBancoDeposito.NombreCampoDescrip = "";
            this.tSBBancoDeposito.NombreCampoID = "";
            this.tSBBancoDeposito.Size = new System.Drawing.Size(387, 20);
            this.tSBBancoDeposito.SoloLectura = false;
            this.tSBBancoDeposito.TabIndex = 2;
            this.tSBBancoDeposito.Text = "ucTextSearchBox";
            this.tSBBancoDeposito.TituloBuscador = "";
            // 
            // tSBCuentaDeposito
            // 
            this.tSBCuentaDeposito.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBCuentaDeposito.BackColor = System.Drawing.Color.Transparent;
            this.tSBCuentaDeposito.DBContext = null;
            this.tSBCuentaDeposito.DisplayMember = "";
            this.tSBCuentaDeposito.KeyMember = "";
            this.tSBCuentaDeposito.LabelCampoBusqueda = "";
            this.tSBCuentaDeposito.Location = new System.Drawing.Point(74, 60);
            this.tSBCuentaDeposito.Name = "tSBCuentaDeposito";
            this.tSBCuentaDeposito.NombreCampoDescrip = "";
            this.tSBCuentaDeposito.NombreCampoID = "";
            this.tSBCuentaDeposito.Size = new System.Drawing.Size(387, 20);
            this.tSBCuentaDeposito.SoloLectura = false;
            this.tSBCuentaDeposito.TabIndex = 3;
            this.tSBCuentaDeposito.Text = "ucTextSearchBox";
            this.tSBCuentaDeposito.TituloBuscador = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Cuenta";
            // 
            // grpCheque
            // 
            this.grpCheque.Controls.Add(this.label12);
            this.grpCheque.Controls.Add(this.txtNroCheque);
            this.grpCheque.Controls.Add(this.label10);
            this.grpCheque.Controls.Add(this.tSBBancoCheque);
            this.grpCheque.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.grpCheque.Location = new System.Drawing.Point(36, 228);
            this.grpCheque.Name = "grpCheque";
            this.grpCheque.Size = new System.Drawing.Size(469, 78);
            this.grpCheque.TabIndex = 8;
            this.grpCheque.TabStop = false;
            this.grpCheque.Text = "Cheque";
            // 
            // txtReferencia
            // 
            this.txtReferencia.Location = new System.Drawing.Point(611, 69);
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(387, 20);
            this.txtReferencia.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(537, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Referencia";
            // 
            // txtPresupuestoCabID
            // 
            this.txtPresupuestoCabID.BackColor = System.Drawing.SystemColors.Control;
            this.txtPresupuestoCabID.Location = new System.Drawing.Point(288, 6);
            this.txtPresupuestoCabID.Name = "txtPresupuestoCabID";
            this.txtPresupuestoCabID.ReadOnly = true;
            this.txtPresupuestoCabID.Size = new System.Drawing.Size(113, 20);
            this.txtPresupuestoCabID.TabIndex = 1;
            this.txtPresupuestoCabID.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(227, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Presup. ID";
            // 
            // grpGastoBancario
            // 
            this.grpGastoBancario.Controls.Add(this.tSBMoneda);
            this.grpGastoBancario.Controls.Add(this.label4);
            this.grpGastoBancario.Controls.Add(this.txtGastoBancario);
            this.grpGastoBancario.Controls.Add(this.label15);
            this.grpGastoBancario.Controls.Add(this.label16);
            this.grpGastoBancario.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.grpGastoBancario.Location = new System.Drawing.Point(535, 112);
            this.grpGastoBancario.Name = "grpGastoBancario";
            this.grpGastoBancario.Size = new System.Drawing.Size(469, 63);
            this.grpGastoBancario.TabIndex = 10;
            this.grpGastoBancario.TabStop = false;
            this.grpGastoBancario.Text = "Gasto Bancario";
            // 
            // txtNotaCreditoNro
            // 
            this.txtNotaCreditoNro.Location = new System.Drawing.Point(72, 25);
            this.txtNotaCreditoNro.Name = "txtNotaCreditoNro";
            this.txtNotaCreditoNro.Size = new System.Drawing.Size(98, 20);
            this.txtNotaCreditoNro.TabIndex = 0;
            // 
            // txtMonedaID
            // 
            this.txtMonedaID.BackColor = System.Drawing.SystemColors.Control;
            this.txtMonedaID.Location = new System.Drawing.Point(111, 90);
            this.txtMonedaID.Name = "txtMonedaID";
            this.txtMonedaID.ReadOnly = true;
            this.txtMonedaID.Size = new System.Drawing.Size(70, 20);
            this.txtMonedaID.TabIndex = 2;
            this.txtMonedaID.TabStop = false;
            // 
            // txtMonedaDescrip
            // 
            this.txtMonedaDescrip.BackColor = System.Drawing.SystemColors.Control;
            this.txtMonedaDescrip.Location = new System.Drawing.Point(183, 90);
            this.txtMonedaDescrip.Name = "txtMonedaDescrip";
            this.txtMonedaDescrip.ReadOnly = true;
            this.txtMonedaDescrip.Size = new System.Drawing.Size(327, 20);
            this.txtMonedaDescrip.TabIndex = 1;
            this.txtMonedaDescrip.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(39, 94);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Moneda";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(11, 20);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(35, 13);
            this.label17.TabIndex = 0;
            this.label17.Text = "Fecha";
            // 
            // txtFechaRecibo
            // 
            this.txtFechaRecibo.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0);
            this.txtFechaRecibo.Location = new System.Drawing.Point(76, 17);
            this.txtFechaRecibo.Name = "txtFechaRecibo";
            this.txtFechaRecibo.Size = new System.Drawing.Size(81, 18);
            this.txtFechaRecibo.TabIndex = 0;
            // 
            // dtpFechaRecibo
            // 
            this.dtpFechaRecibo.CustomFormat = "dd/mm/yyyy";
            this.dtpFechaRecibo.Location = new System.Drawing.Point(74, 16);
            this.dtpFechaRecibo.Name = "dtpFechaRecibo";
            this.dtpFechaRecibo.Size = new System.Drawing.Size(100, 21);
            this.dtpFechaRecibo.TabIndex = 3;
            this.dtpFechaRecibo.TabStop = false;
            this.dtpFechaRecibo.ValueChanged += new System.EventHandler(this.dtpFechaRecibo_ValueChanged);
            // 
            // grpRecibo
            // 
            this.grpRecibo.Controls.Add(this.txtNroRecibo);
            this.grpRecibo.Controls.Add(this.label18);
            this.grpRecibo.Controls.Add(this.label17);
            this.grpRecibo.Controls.Add(this.txtFechaRecibo);
            this.grpRecibo.Controls.Add(this.dtpFechaRecibo);
            this.grpRecibo.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.grpRecibo.Location = new System.Drawing.Point(36, 308);
            this.grpRecibo.Name = "grpRecibo";
            this.grpRecibo.Size = new System.Drawing.Size(469, 65);
            this.grpRecibo.TabIndex = 9;
            this.grpRecibo.TabStop = false;
            this.grpRecibo.Text = "Recibo";
            // 
            // txtNroRecibo
            // 
            this.txtNroRecibo.Location = new System.Drawing.Point(75, 38);
            this.txtNroRecibo.Name = "txtNroRecibo";
            this.txtNroRecibo.Size = new System.Drawing.Size(224, 20);
            this.txtNroRecibo.TabIndex = 1;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(11, 42);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(59, 13);
            this.label18.TabIndex = 0;
            this.label18.Text = "N°";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(39, 30);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(55, 13);
            this.label19.TabIndex = 0;
            this.label19.Text = "Presupuesto";
            // 
            // tSBPresupuesto
            // 
            this.tSBPresupuesto.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBPresupuesto.BackColor = System.Drawing.Color.Transparent;
            this.tSBPresupuesto.DBContext = null;
            this.tSBPresupuesto.DisplayMember = "";
            this.tSBPresupuesto.KeyMember = "";
            this.tSBPresupuesto.LabelCampoBusqueda = "";
            this.tSBPresupuesto.Location = new System.Drawing.Point(111, 27);
            this.tSBPresupuesto.Name = "tSBPresupuesto";
            this.tSBPresupuesto.NombreCampoDescrip = "";
            this.tSBPresupuesto.NombreCampoID = "";
            this.tSBPresupuesto.Size = new System.Drawing.Size(399, 20);
            this.tSBPresupuesto.SoloLectura = false;
            this.tSBPresupuesto.TabIndex = 0;
            this.tSBPresupuesto.Text = "ucTextSearchBox";
            this.tSBPresupuesto.TituloBuscador = "";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(39, 73);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(55, 13);
            this.label20.TabIndex = 0;
            this.label20.Text = "Cliente";
            // 
            // txtClienteNombre
            // 
            this.txtClienteNombre.BackColor = System.Drawing.SystemColors.Control;
            this.txtClienteNombre.Location = new System.Drawing.Point(183, 69);
            this.txtClienteNombre.Name = "txtClienteNombre";
            this.txtClienteNombre.ReadOnly = true;
            this.txtClienteNombre.Size = new System.Drawing.Size(327, 20);
            this.txtClienteNombre.TabIndex = 1;
            this.txtClienteNombre.TabStop = false;
            // 
            // txtClienteID
            // 
            this.txtClienteID.BackColor = System.Drawing.SystemColors.Control;
            this.txtClienteID.Location = new System.Drawing.Point(111, 69);
            this.txtClienteID.Name = "txtClienteID";
            this.txtClienteID.ReadOnly = true;
            this.txtClienteID.Size = new System.Drawing.Size(70, 20);
            this.txtClienteID.TabIndex = 2;
            this.txtClienteID.TabStop = false;
            // 
            // tbbAnular
            // 
            this.tbbAnular.CustomStyle = "";
            this.tbbAnular.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tbbAnular.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("tbbAnular.Image"));
            this.tbbAnular.Name = "tbbAnular";
            this.tbbAnular.Size = 24;
            this.tbbAnular.Text = "A";
            this.tbbAnular.ToolTipText = "Permite anular el pago";
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
            // lblAutorizacionVigente
            // 
            this.lblAutorizacionVigente.AutoSize = true;
            this.lblAutorizacionVigente.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblAutorizacionVigente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblAutorizacionVigente.Location = new System.Drawing.Point(536, 93);
            this.lblAutorizacionVigente.Name = "lblAutorizacionVigente";
            this.lblAutorizacionVigente.Size = new System.Drawing.Size(41, 13);
            this.lblAutorizacionVigente.TabIndex = 15;
            this.lblAutorizacionVigente.Text = "Autorización para modificación vigente";
            this.lblAutorizacionVigente.Visible = false;
            this.lblAutorizacionVigente.Click += new System.EventHandler(this.lblAutorizacionVigente_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(403, 9);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(35, 13);
            this.label21.TabIndex = 0;
            this.label21.Text = "Estado";
            this.label21.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtEstado
            // 
            this.txtEstado.BackColor = System.Drawing.SystemColors.Control;
            this.txtEstado.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtEstado.ForeColor = System.Drawing.Color.Black;
            this.txtEstado.Location = new System.Drawing.Point(446, 6);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.ReadOnly = true;
            this.txtEstado.Size = new System.Drawing.Size(64, 20);
            this.txtEstado.TabIndex = 1;
            this.txtEstado.TabStop = false;
            // 
            // txtSaldo
            // 
            this.txtSaldo.BackColor = System.Drawing.SystemColors.Control;
            this.txtSaldo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtSaldo.ForeColor = System.Drawing.Color.Red;
            this.txtSaldo.Location = new System.Drawing.Point(446, 48);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.ReadOnly = true;
            this.txtSaldo.Size = new System.Drawing.Size(64, 20);
            this.txtSaldo.TabIndex = 1;
            this.txtSaldo.TabStop = false;
            this.txtSaldo.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(403, 51);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(35, 13);
            this.label22.TabIndex = 0;
            this.label22.Text = "Saldo";
            this.label22.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(11, 29);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(59, 13);
            this.label23.TabIndex = 0;
            this.label23.Text = "N°";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(11, 52);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(35, 13);
            this.label24.TabIndex = 0;
            this.label24.Text = "Fecha";
            // 
            // txtFechaNotaCredito
            // 
            this.txtFechaNotaCredito.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0);
            this.txtFechaNotaCredito.Location = new System.Drawing.Point(74, 49);
            this.txtFechaNotaCredito.Name = "txtFechaNotaCredito";
            this.txtFechaNotaCredito.Size = new System.Drawing.Size(81, 18);
            this.txtFechaNotaCredito.TabIndex = 2;
            this.txtFechaNotaCredito.TextChanged += new System.EventHandler(this.txtFechaNotaCredito_TextChanged);
            // 
            // dtpFechaNotaCredito
            // 
            this.dtpFechaNotaCredito.CustomFormat = "dd/mm/yyyy";
            this.dtpFechaNotaCredito.Location = new System.Drawing.Point(72, 48);
            this.dtpFechaNotaCredito.Name = "dtpFechaNotaCredito";
            this.dtpFechaNotaCredito.Size = new System.Drawing.Size(100, 21);
            this.dtpFechaNotaCredito.TabIndex = 3;
            this.dtpFechaNotaCredito.TabStop = false;
            this.dtpFechaNotaCredito.ValueChanged += new System.EventHandler(this.dtpFechaNotaCredito_ValueChanged);
            this.dtpFechaNotaCredito.Click += new System.EventHandler(this.dtpFechaNotaCredito_Click);
            // 
            // grpNotaCredito
            // 
            this.grpNotaCredito.Controls.Add(this.txtNotaCreditoNro);
            this.grpNotaCredito.Controls.Add(this.lblNCSaldo);
            this.grpNotaCredito.Controls.Add(this.txtNCSaldo);
            this.grpNotaCredito.Controls.Add(this.txtNCTotal);
            this.grpNotaCredito.Controls.Add(this.lblNCTotal);
            this.grpNotaCredito.Controls.Add(this.tSBNotaCredito);
            this.grpNotaCredito.Controls.Add(this.txtNotaCreditoCuerpo);
            this.grpNotaCredito.Controls.Add(this.label29);
            this.grpNotaCredito.Controls.Add(this.label28);
            this.grpNotaCredito.Controls.Add(this.txtReferenciaNotaCredito);
            this.grpNotaCredito.Controls.Add(this.lblIDNotaCredito);
            this.grpNotaCredito.Controls.Add(this.label23);
            this.grpNotaCredito.Controls.Add(this.label24);
            this.grpNotaCredito.Controls.Add(this.txtIdNotaCredito);
            this.grpNotaCredito.Controls.Add(this.txtFechaNotaCredito);
            this.grpNotaCredito.Controls.Add(this.dtpFechaNotaCredito);
            this.grpNotaCredito.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.grpNotaCredito.Location = new System.Drawing.Point(535, 241);
            this.grpNotaCredito.Name = "grpNotaCredito";
            this.grpNotaCredito.Size = new System.Drawing.Size(469, 136);
            this.grpNotaCredito.TabIndex = 11;
            this.grpNotaCredito.TabStop = false;
            this.grpNotaCredito.Text = "Nota Crédito";
            // 
            // lblNCSaldo
            // 
            this.lblNCSaldo.AutoSize = true;
            this.lblNCSaldo.Location = new System.Drawing.Point(360, 52);
            this.lblNCSaldo.Name = "lblNCSaldo";
            this.lblNCSaldo.Size = new System.Drawing.Size(33, 13);
            this.lblNCSaldo.TabIndex = 0;
            this.lblNCSaldo.Text = "Saldo";
            this.lblNCSaldo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtNCSaldo
            // 
            this.txtNCSaldo.BackColor = System.Drawing.SystemColors.Control;
            this.txtNCSaldo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtNCSaldo.ForeColor = System.Drawing.Color.Red;
            this.txtNCSaldo.Location = new System.Drawing.Point(395, 48);
            this.txtNCSaldo.Name = "txtNCSaldo";
            this.txtNCSaldo.ReadOnly = true;
            this.txtNCSaldo.Size = new System.Drawing.Size(64, 20);
            this.txtNCSaldo.TabIndex = 1;
            this.txtNCSaldo.TabStop = false;
            this.txtNCSaldo.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // txtNCTotal
            // 
            this.txtNCTotal.BackColor = System.Drawing.SystemColors.Control;
            this.txtNCTotal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtNCTotal.ForeColor = System.Drawing.Color.Red;
            this.txtNCTotal.Location = new System.Drawing.Point(295, 48);
            this.txtNCTotal.Name = "txtNCTotal";
            this.txtNCTotal.ReadOnly = true;
            this.txtNCTotal.Size = new System.Drawing.Size(64, 20);
            this.txtNCTotal.TabIndex = 1;
            this.txtNCTotal.TabStop = false;
            this.txtNCTotal.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // lblNCTotal
            // 
            this.lblNCTotal.AutoSize = true;
            this.lblNCTotal.Location = new System.Drawing.Point(260, 52);
            this.lblNCTotal.Name = "lblNCTotal";
            this.lblNCTotal.Size = new System.Drawing.Size(33, 13);
            this.lblNCTotal.TabIndex = 0;
            this.lblNCTotal.Text = "Total";
            this.lblNCTotal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tSBNotaCredito
            // 
            this.tSBNotaCredito.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBNotaCredito.BackColor = System.Drawing.Color.Transparent;
            this.tSBNotaCredito.DBContext = null;
            this.tSBNotaCredito.DisplayMember = "";
            this.tSBNotaCredito.KeyMember = "";
            this.tSBNotaCredito.LabelCampoBusqueda = "";
            this.tSBNotaCredito.Location = new System.Drawing.Point(72, 25);
            this.tSBNotaCredito.Name = "tSBNotaCredito";
            this.tSBNotaCredito.NombreCampoDescrip = "";
            this.tSBNotaCredito.NombreCampoID = "";
            this.tSBNotaCredito.Size = new System.Drawing.Size(388, 20);
            this.tSBNotaCredito.SoloLectura = false;
            this.tSBNotaCredito.TabIndex = 1;
            this.tSBNotaCredito.Text = "ucTextSearchBox";
            this.tSBNotaCredito.TituloBuscador = "";
            // 
            // txtNotaCreditoCuerpo
            // 
            this.txtNotaCreditoCuerpo.Location = new System.Drawing.Point(73, 70);
            this.txtNotaCreditoCuerpo.Multiline = true;
            this.txtNotaCreditoCuerpo.Name = "txtNotaCreditoCuerpo";
            this.txtNotaCreditoCuerpo.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.txtNotaCreditoCuerpo.Size = new System.Drawing.Size(388, 30);
            this.txtNotaCreditoCuerpo.TabIndex = 4;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(11, 73);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(59, 13);
            this.label29.TabIndex = 0;
            this.label29.Text = "Cuerpo";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(11, 105);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(59, 13);
            this.label28.TabIndex = 0;
            this.label28.Text = "Referencia";
            // 
            // txtReferenciaNotaCredito
            // 
            this.txtReferenciaNotaCredito.Location = new System.Drawing.Point(73, 102);
            this.txtReferenciaNotaCredito.Multiline = true;
            this.txtReferenciaNotaCredito.Name = "txtReferenciaNotaCredito";
            this.txtReferenciaNotaCredito.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.txtReferenciaNotaCredito.Size = new System.Drawing.Size(388, 30);
            this.txtReferenciaNotaCredito.TabIndex = 5;
            // 
            // lblIDNotaCredito
            // 
            this.lblIDNotaCredito.AutoSize = true;
            this.lblIDNotaCredito.Location = new System.Drawing.Point(174, 53);
            this.lblIDNotaCredito.Name = "lblIDNotaCredito";
            this.lblIDNotaCredito.Size = new System.Drawing.Size(18, 13);
            this.lblIDNotaCredito.TabIndex = 0;
            this.lblIDNotaCredito.Text = "ID";
            // 
            // txtIdNotaCredito
            // 
            this.txtIdNotaCredito.BackColor = System.Drawing.SystemColors.Control;
            this.txtIdNotaCredito.Location = new System.Drawing.Point(192, 49);
            this.txtIdNotaCredito.Name = "txtIdNotaCredito";
            this.txtIdNotaCredito.ReadOnly = true;
            this.txtIdNotaCredito.Size = new System.Drawing.Size(67, 20);
            this.txtIdNotaCredito.TabIndex = 1;
            this.txtIdNotaCredito.TabStop = false;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(227, 51);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(35, 13);
            this.label25.TabIndex = 0;
            this.label25.Text = "N° Factura";
            // 
            // txtNroFactura
            // 
            this.txtNroFactura.BackColor = System.Drawing.SystemColors.Control;
            this.txtNroFactura.Location = new System.Drawing.Point(288, 48);
            this.txtNroFactura.Name = "txtNroFactura";
            this.txtNroFactura.ReadOnly = true;
            this.txtNroFactura.Size = new System.Drawing.Size(113, 20);
            this.txtNroFactura.TabIndex = 1;
            this.txtNroFactura.TabStop = false;
            // 
            // txtIDPagoMultiple
            // 
            this.txtIDPagoMultiple.BackColor = System.Drawing.SystemColors.Control;
            this.txtIDPagoMultiple.Location = new System.Drawing.Point(912, 48);
            this.txtIDPagoMultiple.Name = "txtIDPagoMultiple";
            this.txtIDPagoMultiple.ReadOnly = true;
            this.txtIDPagoMultiple.Size = new System.Drawing.Size(87, 20);
            this.txtIDPagoMultiple.TabIndex = 1;
            this.txtIDPagoMultiple.TabStop = false;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(877, 52);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(35, 13);
            this.label26.TabIndex = 0;
            this.label26.Text = "ID CM";
            // 
            // clientStorage1
            // 
            this.clientStorage1.Description = "";
            this.clientStorage1.MajorVersion = ((ushort)(1));
            this.clientStorage1.MinorVersion = ((ushort)(0));
            // 
            // tSBRespCobroExterior
            // 
            this.tSBRespCobroExterior.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBRespCobroExterior.BackColor = System.Drawing.Color.Transparent;
            this.tSBRespCobroExterior.DBContext = null;
            this.tSBRespCobroExterior.DisplayMember = "";
            this.tSBRespCobroExterior.KeyMember = "";
            this.tSBRespCobroExterior.LabelCampoBusqueda = "";
            this.tSBRespCobroExterior.Location = new System.Drawing.Point(611, 27);
            this.tSBRespCobroExterior.Name = "tSBRespCobroExterior";
            this.tSBRespCobroExterior.NombreCampoDescrip = "";
            this.tSBRespCobroExterior.NombreCampoID = "";
            this.tSBRespCobroExterior.Size = new System.Drawing.Size(387, 20);
            this.tSBRespCobroExterior.SoloLectura = false;
            this.tSBRespCobroExterior.TabIndex = 3;
            this.tSBRespCobroExterior.Text = "ucTextSearchBox";
            this.tSBRespCobroExterior.TituloBuscador = "";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(537, 23);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(35, 13);
            this.label30.TabIndex = 0;
            this.label30.Text = "Resp. Cobro";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(537, 34);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(35, 13);
            this.label31.TabIndex = 0;
            this.label31.Text = "En el Exterior";
            // 
            // txtGeneradoPorID
            // 
            this.txtGeneradoPorID.BackColor = System.Drawing.SystemColors.Control;
            this.txtGeneradoPorID.Location = new System.Drawing.Point(111, 111);
            this.txtGeneradoPorID.Name = "txtGeneradoPorID";
            this.txtGeneradoPorID.ReadOnly = true;
            this.txtGeneradoPorID.Size = new System.Drawing.Size(70, 20);
            this.txtGeneradoPorID.TabIndex = 1;
            this.txtGeneradoPorID.TabStop = false;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(39, 114);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(35, 13);
            this.label32.TabIndex = 0;
            this.label32.Text = "Gen. Por";
            this.label32.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtGeneradoPorNombre
            // 
            this.txtGeneradoPorNombre.BackColor = System.Drawing.SystemColors.Control;
            this.txtGeneradoPorNombre.Location = new System.Drawing.Point(183, 111);
            this.txtGeneradoPorNombre.Name = "txtGeneradoPorNombre";
            this.txtGeneradoPorNombre.ReadOnly = true;
            this.txtGeneradoPorNombre.Size = new System.Drawing.Size(327, 20);
            this.txtGeneradoPorNombre.TabIndex = 1;
            this.txtGeneradoPorNombre.TabStop = false;
            // 
            // ucTextSearchBox1
            // 
            this.ucTextSearchBox1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ucTextSearchBox1.BackColor = System.Drawing.Color.Transparent;
            this.ucTextSearchBox1.DBContext = null;
            this.ucTextSearchBox1.DisplayMember = "";
            this.ucTextSearchBox1.KeyMember = "";
            this.ucTextSearchBox1.LabelCampoBusqueda = "";
            this.ucTextSearchBox1.Location = new System.Drawing.Point(74, 16);
            this.ucTextSearchBox1.Name = "ucTextSearchBox1";
            this.ucTextSearchBox1.NombreCampoDescrip = "";
            this.ucTextSearchBox1.NombreCampoID = "";
            this.ucTextSearchBox1.Size = new System.Drawing.Size(387, 20);
            this.ucTextSearchBox1.SoloLectura = false;
            this.ucTextSearchBox1.TabIndex = 0;
            this.ucTextSearchBox1.Text = "ucTextSearchBox";
            this.ucTextSearchBox1.TituloBuscador = "";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(10, 20);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(45, 13);
            this.label33.TabIndex = 0;
            this.label33.Text = "Moneda";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(74, 38);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(132, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(11, 32);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(55, 13);
            this.label34.TabIndex = 0;
            this.label34.Text = "Diferencia";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(11, 44);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(54, 13);
            this.label35.TabIndex = 0;
            this.label35.Text = "Cambiaria";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ucTextSearchBox1);
            this.groupBox1.Controls.Add(this.label33);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label34);
            this.groupBox1.Controls.Add(this.label35);
            this.groupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(535, 175);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(469, 63);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Retención";
            // 
            // ucCRUDPagoPresupuesto
            // 
            this.VisibleChanged += new System.EventHandler(this.ucCRUDPagoPresupuesto_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoABM)).EndInit();
            this.pnlDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabListaABM)).EndInit();
            this.pnlListadoContainer.ResumeLayout(false);
            this.pnlContainer.ResumeLayout(false);
            this.pnlTabControl.ResumeLayout(false);
            this.grpDeposito.ResumeLayout(false);
            this.grpCheque.ResumeLayout(false);
            this.grpGastoBancario.ResumeLayout(false);
            this.grpRecibo.ResumeLayout(false);
            this.grpNotaCredito.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Label label2;
        private TextBox txtNroPresupuesto;
        private TextBox txtPagoID;
        private Label label1;
        private TextBox txtFechaPago;
        private DateTimePicker dtpFechaPago;
        private Label label3;
        private Label label4;
        private Base.ucTextSearchBox tSBMoneda;
        private Base.ucTextSearchBox tSBFormaPago;
        private Label label9;
        private Label label12;
        private Base.ucTextSearchBox tSBBancoCheque;
        private Label label10;
        private TextBox txtNroCheque;
        private TextBox txtFechaDeposito;
        private Label label14;
        private TextBox txtMontoPago;
        private DateTimePicker dtpFechaDeposito;
        private GroupBox grpDeposito;
        private Label label5;
        private Base.ucTextSearchBox tSBBancoDeposito;
        private Base.ucTextSearchBox tSBCuentaDeposito;
        private Label label8;
        private Label label16;
        private TextBox txtGastoBancario;
        private Label label15;
        private GroupBox grpCheque;
        private Label label13;
        private Label label6;
        private TextBox txtReferencia;
        private TextBox txtPresupuestoCabID;
        private Label label7;
        private GroupBox grpGastoBancario;
        private Label label11;
        private TextBox txtMonedaDescrip;
        private TextBox txtMonedaID;
        private GroupBox grpRecibo;
        private Label label17;
        private TextBox txtFechaRecibo;
        private DateTimePicker dtpFechaRecibo;
        private TextBox txtNroRecibo;
        private Label label18;
        private Base.ucTextSearchBox tSBPresupuesto;
        private Label label19;
        private TextBox txtClienteID;
        private TextBox txtClienteNombre;
        private Label label20;
        private ToolBarButton tbbAnular;
        private ToolBarButton Sep6;
        private Label lblAutorizacionVigente;
        private TextBox txtEstado;
        private Label label21;
        private Label label22;
        private TextBox txtSaldo;
        private GroupBox grpNotaCredito;
        private TextBox txtNotaCreditoNro;
        private Label label23;
        private Label label24;
        private TextBox txtFechaNotaCredito;
        private DateTimePicker dtpFechaNotaCredito;
        private TextBox txtNroFactura;
        private Label label25;
        private Label label26;
        private TextBox txtIDPagoMultiple;
        private Label lblIDNotaCredito;
        private TextBox txtIdNotaCredito;
        private Label label28;
        private TextBox txtReferenciaNotaCredito;
        private Base.ucTextSearchBox tSBNotaCredito;
        private TextBox txtNotaCreditoCuerpo;
        private Label label29;
        private Label lblNCSaldo;
        private TextBox txtNCSaldo;
        private TextBox txtNCTotal;
        private Label lblNCTotal;
        private Label label27;
        private TextBox txtBoletaDepNro;
        private Gizmox.WebGUI.Forms.Client.ClientStorage clientStorage1;
        private Label label30;
        private Label label31;
        private Base.ucTextSearchBox tSBRespCobroExterior;
        private TextBox txtGeneradoPorNombre;
        private Label label32;
        private TextBox txtGeneradoPorID;
        private GroupBox groupBox1;
        private Base.ucTextSearchBox ucTextSearchBox1;
        private Label label33;
        private TextBox textBox1;
        private Label label34;
        private Label label35;
    }
}
