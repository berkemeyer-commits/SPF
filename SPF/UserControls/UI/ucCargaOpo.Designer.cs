using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.UserControls.UI
{
    partial class ucCargaOpo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucCargaOpo));
            this.grpBoxBuscarExpediente = new Gizmox.WebGUI.Forms.GroupBox();
            this.btnFiltrar = new Gizmox.WebGUI.Forms.Button();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.txtRegistroNro = new Gizmox.WebGUI.Forms.TextBox();
            this.txtActaAnio = new Gizmox.WebGUI.Forms.TextBox();
            this.txtActaNro = new Gizmox.WebGUI.Forms.TextBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.txtEdRegistroNro = new Gizmox.WebGUI.Forms.TextBox();
            this.txtEdActaAnio = new Gizmox.WebGUI.Forms.TextBox();
            this.txtEdActaNro = new Gizmox.WebGUI.Forms.TextBox();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.txtDenominacion = new Gizmox.WebGUI.Forms.TextBox();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.txtTramite = new Gizmox.WebGUI.Forms.TextBox();
            this.label7 = new Gizmox.WebGUI.Forms.Label();
            this.label8 = new Gizmox.WebGUI.Forms.Label();
            this.txtExpeOpoID = new Gizmox.WebGUI.Forms.TextBox();
            this.txtExpeID = new Gizmox.WebGUI.Forms.TextBox();
            this.tSBCliente = new SPF.UserControls.Base.ucTextSearchBox();
            this.label9 = new Gizmox.WebGUI.Forms.Label();
            this.label10 = new Gizmox.WebGUI.Forms.Label();
            this.tSBTramite = new SPF.UserControls.Base.ucTextSearchBox();
            this.txtHITexto = new Gizmox.WebGUI.Forms.TextBox();
            this.label11 = new Gizmox.WebGUI.Forms.Label();
            this.txtOTID = new Gizmox.WebGUI.Forms.TextBox();
            this.chkCopiarHI = new Gizmox.WebGUI.Forms.CheckBox();
            this.txtFechaPresentacion = new Gizmox.WebGUI.Forms.TextBox();
            this.dtpFechaPresentacion = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.label12 = new Gizmox.WebGUI.Forms.Label();
            this.label13 = new Gizmox.WebGUI.Forms.Label();
            this.txtParteNombre = new Gizmox.WebGUI.Forms.TextBox();
            this.label14 = new Gizmox.WebGUI.Forms.Label();
            this.label15 = new Gizmox.WebGUI.Forms.Label();
            this.txtContraparteNombre = new Gizmox.WebGUI.Forms.TextBox();
            this.label16 = new Gizmox.WebGUI.Forms.Label();
            this.label17 = new Gizmox.WebGUI.Forms.Label();
            this.tSBAtencion = new SPF.UserControls.Base.ucTextSearchBox();
            this.txtFechaEntrada = new Gizmox.WebGUI.Forms.TextBox();
            this.dtpFechaEntrada = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.label20 = new Gizmox.WebGUI.Forms.Label();
            this.label21 = new Gizmox.WebGUI.Forms.Label();
            this.label18 = new Gizmox.WebGUI.Forms.Label();
            this.label19 = new Gizmox.WebGUI.Forms.Label();
            this.dtpFechaSalida = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.txtFechaSalida = new Gizmox.WebGUI.Forms.TextBox();
            this.txtUsuarioCargaNombre = new Gizmox.WebGUI.Forms.TextBox();
            this.txtUsuarioCargaID = new Gizmox.WebGUI.Forms.TextBox();
            this.label22 = new Gizmox.WebGUI.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoABM)).BeginInit();
            this.pnlDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabListaABM)).BeginInit();
            this.pnlListadoContainer.SuspendLayout();
            this.pnlContainer.SuspendLayout();
            this.pnlTabControl.SuspendLayout();
            this.grpBoxBuscarExpediente.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvListadoABM
            // 
            this.dgvListadoABM.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.dgvListadoABM.RowEnter += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.dgvListadoABM_RowEnter);
            this.dgvListadoABM.SelectionChanged += new System.EventHandler(this.dgvListadoABM_SelectionChanged);
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
            // pnlDetalle
            // 
            this.pnlDetalle.Controls.Add(this.label22);
            this.pnlDetalle.Controls.Add(this.txtUsuarioCargaID);
            this.pnlDetalle.Controls.Add(this.txtUsuarioCargaNombre);
            this.pnlDetalle.Controls.Add(this.txtFechaSalida);
            this.pnlDetalle.Controls.Add(this.dtpFechaSalida);
            this.pnlDetalle.Controls.Add(this.label19);
            this.pnlDetalle.Controls.Add(this.label18);
            this.pnlDetalle.Controls.Add(this.label21);
            this.pnlDetalle.Controls.Add(this.label20);
            this.pnlDetalle.Controls.Add(this.txtFechaEntrada);
            this.pnlDetalle.Controls.Add(this.dtpFechaEntrada);
            this.pnlDetalle.Controls.Add(this.tSBAtencion);
            this.pnlDetalle.Controls.Add(this.label17);
            this.pnlDetalle.Controls.Add(this.label16);
            this.pnlDetalle.Controls.Add(this.txtContraparteNombre);
            this.pnlDetalle.Controls.Add(this.label15);
            this.pnlDetalle.Controls.Add(this.label14);
            this.pnlDetalle.Controls.Add(this.txtParteNombre);
            this.pnlDetalle.Controls.Add(this.label13);
            this.pnlDetalle.Controls.Add(this.label12);
            this.pnlDetalle.Controls.Add(this.txtFechaPresentacion);
            this.pnlDetalle.Controls.Add(this.dtpFechaPresentacion);
            this.pnlDetalle.Controls.Add(this.chkCopiarHI);
            this.pnlDetalle.Controls.Add(this.txtOTID);
            this.pnlDetalle.Controls.Add(this.label11);
            this.pnlDetalle.Controls.Add(this.txtHITexto);
            this.pnlDetalle.Controls.Add(this.tSBTramite);
            this.pnlDetalle.Controls.Add(this.label10);
            this.pnlDetalle.Controls.Add(this.label9);
            this.pnlDetalle.Controls.Add(this.tSBCliente);
            this.pnlDetalle.Controls.Add(this.txtExpeID);
            this.pnlDetalle.Controls.Add(this.txtExpeOpoID);
            this.pnlDetalle.Controls.Add(this.label8);
            this.pnlDetalle.Controls.Add(this.label7);
            this.pnlDetalle.Controls.Add(this.txtTramite);
            this.pnlDetalle.Controls.Add(this.label6);
            this.pnlDetalle.Controls.Add(this.txtDenominacion);
            this.pnlDetalle.Controls.Add(this.label5);
            this.pnlDetalle.Controls.Add(this.label4);
            this.pnlDetalle.Controls.Add(this.txtEdActaNro);
            this.pnlDetalle.Controls.Add(this.txtEdActaAnio);
            this.pnlDetalle.Controls.Add(this.txtEdRegistroNro);
            this.pnlDetalle.Controls.Add(this.label3);
            this.pnlDetalle.Controls.Add(this.grpBoxBuscarExpediente);
            this.pnlDetalle.Size = new System.Drawing.Size(901, 419);
            // 
            // tBBaseForm
            // 
            this.tBBaseForm.Size = new System.Drawing.Size(909, 42);
            // 
            // tabListaABM
            // 
            this.tabListaABM.Alignment = Gizmox.WebGUI.Forms.TabAlignment.Top;
            this.pnlListadoContainer.Controls.SetChildIndex(this.dgvListadoABM, 0);
            // 
            // grpBoxBuscarExpediente
            // 
            this.grpBoxBuscarExpediente.Controls.Add(this.btnFiltrar);
            this.grpBoxBuscarExpediente.Controls.Add(this.label2);
            this.grpBoxBuscarExpediente.Controls.Add(this.txtRegistroNro);
            this.grpBoxBuscarExpediente.Controls.Add(this.txtActaAnio);
            this.grpBoxBuscarExpediente.Controls.Add(this.txtActaNro);
            this.grpBoxBuscarExpediente.Controls.Add(this.label1);
            this.grpBoxBuscarExpediente.Enabled = false;
            this.grpBoxBuscarExpediente.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.grpBoxBuscarExpediente.Location = new System.Drawing.Point(26, 9);
            this.grpBoxBuscarExpediente.Name = "grpBoxBuscarExpediente";
            this.grpBoxBuscarExpediente.Size = new System.Drawing.Size(558, 73);
            this.grpBoxBuscarExpediente.TabIndex = 0;
            this.grpBoxBuscarExpediente.TabStop = false;
            this.grpBoxBuscarExpediente.Text = "Buscar Expediente";
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnFiltrar.Image"));
            this.btnFiltrar.Location = new System.Drawing.Point(488, 18);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(40, 40);
            this.btnFiltrar.TabIndex = 2;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(315, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Registro";
            // 
            // txtRegistroNro
            // 
            this.txtRegistroNro.AllowDrag = false;
            this.txtRegistroNro.Location = new System.Drawing.Point(368, 29);
            this.txtRegistroNro.Name = "txtRegistroNro";
            this.txtRegistroNro.Size = new System.Drawing.Size(100, 20);
            this.txtRegistroNro.TabIndex = 2;
            // 
            // txtActaAnio
            // 
            this.txtActaAnio.AllowDrag = false;
            this.txtActaAnio.Location = new System.Drawing.Point(182, 29);
            this.txtActaAnio.Name = "txtActaAnio";
            this.txtActaAnio.Size = new System.Drawing.Size(100, 20);
            this.txtActaAnio.TabIndex = 1;
            // 
            // txtActaNro
            // 
            this.txtActaNro.AllowDrag = false;
            this.txtActaNro.Location = new System.Drawing.Point(76, 29);
            this.txtActaNro.Name = "txtActaNro";
            this.txtActaNro.Size = new System.Drawing.Size(100, 20);
            this.txtActaNro.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Acta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(356, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Registro";
            // 
            // txtEdRegistroNro
            // 
            this.txtEdRegistroNro.AllowDrag = false;
            this.txtEdRegistroNro.BackColor = System.Drawing.SystemColors.Control;
            this.txtEdRegistroNro.Location = new System.Drawing.Point(404, 171);
            this.txtEdRegistroNro.Name = "txtEdRegistroNro";
            this.txtEdRegistroNro.ReadOnly = true;
            this.txtEdRegistroNro.Size = new System.Drawing.Size(100, 20);
            this.txtEdRegistroNro.TabIndex = 2;
            this.txtEdRegistroNro.TabStop = false;
            // 
            // txtEdActaAnio
            // 
            this.txtEdActaAnio.AllowDrag = false;
            this.txtEdActaAnio.BackColor = System.Drawing.SystemColors.Window;
            this.txtEdActaAnio.Location = new System.Drawing.Point(218, 171);
            this.txtEdActaAnio.Name = "txtEdActaAnio";
            this.txtEdActaAnio.ReadOnly = true;
            this.txtEdActaAnio.Size = new System.Drawing.Size(100, 20);
            this.txtEdActaAnio.TabIndex = 2;
            // 
            // txtEdActaNro
            // 
            this.txtEdActaNro.AllowDrag = false;
            this.txtEdActaNro.BackColor = System.Drawing.SystemColors.Window;
            this.txtEdActaNro.Location = new System.Drawing.Point(112, 171);
            this.txtEdActaNro.Name = "txtEdActaNro";
            this.txtEdActaNro.ReadOnly = true;
            this.txtEdActaNro.Size = new System.Drawing.Size(100, 20);
            this.txtEdActaNro.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Acta";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 227);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Denominación";
            // 
            // txtDenominacion
            // 
            this.txtDenominacion.AllowDrag = false;
            this.txtDenominacion.BackColor = System.Drawing.SystemColors.Window;
            this.txtDenominacion.Location = new System.Drawing.Point(112, 223);
            this.txtDenominacion.Name = "txtDenominacion";
            this.txtDenominacion.ReadOnly = true;
            this.txtDenominacion.Size = new System.Drawing.Size(392, 20);
            this.txtDenominacion.TabIndex = 4;
            this.txtDenominacion.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 254);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Cliente";
            // 
            // txtTramite
            // 
            this.txtTramite.AllowDrag = false;
            this.txtTramite.BackColor = System.Drawing.SystemColors.Control;
            this.txtTramite.Location = new System.Drawing.Point(112, 197);
            this.txtTramite.Name = "txtTramite";
            this.txtTramite.ReadOnly = true;
            this.txtTramite.Size = new System.Drawing.Size(392, 20);
            this.txtTramite.TabIndex = 0;
            this.txtTramite.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Trámite";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 149);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Expediente";
            // 
            // txtExpeOpoID
            // 
            this.txtExpeOpoID.AllowDrag = false;
            this.txtExpeOpoID.BackColor = System.Drawing.SystemColors.Control;
            this.txtExpeOpoID.Location = new System.Drawing.Point(112, 145);
            this.txtExpeOpoID.Name = "txtExpeOpoID";
            this.txtExpeOpoID.ReadOnly = true;
            this.txtExpeOpoID.Size = new System.Drawing.Size(100, 20);
            this.txtExpeOpoID.TabIndex = 0;
            this.txtExpeOpoID.TabStop = false;
            // 
            // txtExpeID
            // 
            this.txtExpeID.AllowDrag = false;
            this.txtExpeID.BackColor = System.Drawing.SystemColors.Control;
            this.txtExpeID.Location = new System.Drawing.Point(218, 145);
            this.txtExpeID.Name = "txtExpeID";
            this.txtExpeID.ReadOnly = true;
            this.txtExpeID.Size = new System.Drawing.Size(100, 20);
            this.txtExpeID.TabIndex = 0;
            this.txtExpeID.TabStop = false;
            // 
            // tSBCliente
            // 
            this.tSBCliente.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBCliente.BackColor = System.Drawing.SystemColors.Control;
            this.tSBCliente.DBContext = null;
            this.tSBCliente.DisplayMember = "";
            this.tSBCliente.KeyMember = "";
            this.tSBCliente.LabelCampoBusqueda = "";
            this.tSBCliente.Location = new System.Drawing.Point(112, 250);
            this.tSBCliente.Name = "tSBCliente";
            this.tSBCliente.NombreCampoDescrip = "";
            this.tSBCliente.NombreCampoID = "";
            this.tSBCliente.Size = new System.Drawing.Size(479, 20);
            this.tSBCliente.SoloLectura = false;
            this.tSBCliente.TabIndex = 5;
            this.tSBCliente.Text = "ucTextSearchBox";
            this.tSBCliente.TituloBuscador = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 205);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Padre";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(28, 119);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Trámite";
            // 
            // tSBTramite
            // 
            this.tSBTramite.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBTramite.DBContext = null;
            this.tSBTramite.DisplayMember = "";
            this.tSBTramite.KeyMember = "";
            this.tSBTramite.LabelCampoBusqueda = "";
            this.tSBTramite.Location = new System.Drawing.Point(112, 119);
            this.tSBTramite.Name = "tSBTramite";
            this.tSBTramite.NombreCampoDescrip = "";
            this.tSBTramite.NombreCampoID = "";
            this.tSBTramite.Size = new System.Drawing.Size(479, 20);
            this.tSBTramite.SoloLectura = false;
            this.tSBTramite.TabIndex = 0;
            this.tSBTramite.Text = "ucTextSearchBox";
            this.tSBTramite.TituloBuscador = "";
            // 
            // txtHITexto
            // 
            this.txtHITexto.AllowDrag = false;
            this.txtHITexto.BackColor = System.Drawing.SystemColors.Control;
            this.txtHITexto.Location = new System.Drawing.Point(404, 145);
            this.txtHITexto.Name = "txtHITexto";
            this.txtHITexto.ReadOnly = true;
            this.txtHITexto.Size = new System.Drawing.Size(100, 20);
            this.txtHITexto.TabIndex = 2;
            this.txtHITexto.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(356, 149);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "H.I. Nro.";
            // 
            // txtOTID
            // 
            this.txtOTID.AllowDrag = false;
            this.txtOTID.BackColor = System.Drawing.SystemColors.Control;
            this.txtOTID.Location = new System.Drawing.Point(606, 124);
            this.txtOTID.Name = "txtOTID";
            this.txtOTID.ReadOnly = true;
            this.txtOTID.Size = new System.Drawing.Size(100, 20);
            this.txtOTID.TabIndex = 2;
            this.txtOTID.TabStop = false;
            this.txtOTID.Visible = false;
            // 
            // chkCopiarHI
            // 
            this.chkCopiarHI.AutoSize = true;
            this.chkCopiarHI.Location = new System.Drawing.Point(507, 147);
            this.chkCopiarHI.Name = "chkCopiarHI";
            this.chkCopiarHI.Size = new System.Drawing.Size(189, 17);
            this.chkCopiarHI.TabIndex = 6;
            this.chkCopiarHI.Text = "Crear para todos los exp. de la HI";
            // 
            // txtFechaPresentacion
            // 
            this.txtFechaPresentacion.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0);
            this.txtFechaPresentacion.Location = new System.Drawing.Point(559, 198);
            this.txtFechaPresentacion.Name = "txtFechaPresentacion";
            this.txtFechaPresentacion.Size = new System.Drawing.Size(81, 18);
            this.txtFechaPresentacion.TabIndex = 3;
            // 
            // dtpFechaPresentacion
            // 
            this.dtpFechaPresentacion.CustomFormat = "dd/mm/yyyy";
            this.dtpFechaPresentacion.Location = new System.Drawing.Point(558, 197);
            this.dtpFechaPresentacion.Name = "dtpFechaPresentacion";
            this.dtpFechaPresentacion.Size = new System.Drawing.Size(100, 20);
            this.dtpFechaPresentacion.TabIndex = 3;
            this.dtpFechaPresentacion.TabStop = false;
            this.dtpFechaPresentacion.ValueChanged += new System.EventHandler(this.dtpFechaPresentacion_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(511, 205);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Pres.";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(511, 192);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Fecha";
            // 
            // txtParteNombre
            // 
            this.txtParteNombre.AllowDrag = false;
            this.txtParteNombre.BackColor = System.Drawing.SystemColors.Window;
            this.txtParteNombre.Location = new System.Drawing.Point(112, 306);
            this.txtParteNombre.Name = "txtParteNombre";
            this.txtParteNombre.ReadOnly = true;
            this.txtParteNombre.Size = new System.Drawing.Size(392, 20);
            this.txtParteNombre.TabIndex = 7;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(28, 310);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "Nombre Parte";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(28, 331);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "Nombre";
            // 
            // txtContraparteNombre
            // 
            this.txtContraparteNombre.AllowDrag = false;
            this.txtContraparteNombre.BackColor = System.Drawing.SystemColors.Window;
            this.txtContraparteNombre.Location = new System.Drawing.Point(112, 334);
            this.txtContraparteNombre.Name = "txtContraparteNombre";
            this.txtContraparteNombre.ReadOnly = true;
            this.txtContraparteNombre.Size = new System.Drawing.Size(392, 20);
            this.txtContraparteNombre.TabIndex = 8;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(28, 344);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(44, 13);
            this.label16.TabIndex = 0;
            this.label16.Text = "Contraparte";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(28, 282);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(35, 13);
            this.label17.TabIndex = 0;
            this.label17.Text = "Atención";
            // 
            // tSBAtencion
            // 
            this.tSBAtencion.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBAtencion.BackColor = System.Drawing.SystemColors.Control;
            this.tSBAtencion.DBContext = null;
            this.tSBAtencion.DisplayMember = "";
            this.tSBAtencion.KeyMember = "";
            this.tSBAtencion.LabelCampoBusqueda = "";
            this.tSBAtencion.Location = new System.Drawing.Point(112, 278);
            this.tSBAtencion.Name = "tSBAtencion";
            this.tSBAtencion.NombreCampoDescrip = "";
            this.tSBAtencion.NombreCampoID = "";
            this.tSBAtencion.Size = new System.Drawing.Size(479, 20);
            this.tSBAtencion.SoloLectura = false;
            this.tSBAtencion.TabIndex = 6;
            this.tSBAtencion.Text = "ucTextSearchBox";
            this.tSBAtencion.TituloBuscador = "";
            // 
            // txtFechaEntrada
            // 
            this.txtFechaEntrada.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0);
            this.txtFechaEntrada.Location = new System.Drawing.Point(113, 365);
            this.txtFechaEntrada.Name = "txtFechaEntrada";
            this.txtFechaEntrada.Size = new System.Drawing.Size(81, 18);
            this.txtFechaEntrada.TabIndex = 3;
            // 
            // dtpFechaEntrada
            // 
            this.dtpFechaEntrada.CustomFormat = "dd/mm/yyyy";
            this.dtpFechaEntrada.Location = new System.Drawing.Point(112, 364);
            this.dtpFechaEntrada.Name = "dtpFechaEntrada";
            this.dtpFechaEntrada.Size = new System.Drawing.Size(100, 20);
            this.dtpFechaEntrada.TabIndex = 3;
            this.dtpFechaEntrada.TabStop = false;
            this.dtpFechaEntrada.ValueChanged += new System.EventHandler(this.dtpFechaEntrada_ValueChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(28, 360);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(35, 13);
            this.label20.TabIndex = 0;
            this.label20.Text = "Fecha";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(28, 373);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(43, 13);
            this.label21.TabIndex = 0;
            this.label21.Text = "Entrada";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(241, 373);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(43, 13);
            this.label18.TabIndex = 0;
            this.label18.Text = "Salida";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(241, 360);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(35, 13);
            this.label19.TabIndex = 0;
            this.label19.Text = "Fecha";
            // 
            // dtpFechaSalida
            // 
            this.dtpFechaSalida.CustomFormat = "dd/mm/yyyy";
            this.dtpFechaSalida.Location = new System.Drawing.Point(288, 364);
            this.dtpFechaSalida.Name = "dtpFechaSalida";
            this.dtpFechaSalida.Size = new System.Drawing.Size(100, 20);
            this.dtpFechaSalida.TabIndex = 3;
            this.dtpFechaSalida.TabStop = false;
            this.dtpFechaSalida.ValueChanged += new System.EventHandler(this.dtpFechaSalida_ValueChanged);
            // 
            // txtFechaSalida
            // 
            this.txtFechaSalida.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0);
            this.txtFechaSalida.Location = new System.Drawing.Point(290, 365);
            this.txtFechaSalida.Name = "txtFechaSalida";
            this.txtFechaSalida.Size = new System.Drawing.Size(81, 18);
            this.txtFechaSalida.TabIndex = 3;
            // 
            // txtUsuarioCargaNombre
            // 
            this.txtUsuarioCargaNombre.AllowDrag = false;
            this.txtUsuarioCargaNombre.BackColor = System.Drawing.SystemColors.Control;
            this.txtUsuarioCargaNombre.Location = new System.Drawing.Point(184, 91);
            this.txtUsuarioCargaNombre.Name = "txtUsuarioCargaNombre";
            this.txtUsuarioCargaNombre.ReadOnly = true;
            this.txtUsuarioCargaNombre.Size = new System.Drawing.Size(300, 20);
            this.txtUsuarioCargaNombre.TabIndex = 0;
            this.txtUsuarioCargaNombre.TabStop = false;
            // 
            // txtUsuarioCargaID
            // 
            this.txtUsuarioCargaID.AllowDrag = false;
            this.txtUsuarioCargaID.BackColor = System.Drawing.SystemColors.Control;
            this.txtUsuarioCargaID.Location = new System.Drawing.Point(112, 91);
            this.txtUsuarioCargaID.Name = "txtUsuarioCargaID";
            this.txtUsuarioCargaID.ReadOnly = true;
            this.txtUsuarioCargaID.Size = new System.Drawing.Size(70, 20);
            this.txtUsuarioCargaID.TabIndex = 0;
            this.txtUsuarioCargaID.TabStop = false;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(28, 95);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(35, 13);
            this.label22.TabIndex = 0;
            this.label22.Text = "Cargado Por";
            // 
            // ucCargaOpo
            // 
            this.Size = new System.Drawing.Size(911, 526);
            this.Text = "ucCargaOpo";
            this.VisibleChanged += new System.EventHandler(this.ucCargaOpo_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoABM)).EndInit();
            this.pnlDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabListaABM)).EndInit();
            this.pnlListadoContainer.ResumeLayout(false);
            this.pnlContainer.ResumeLayout(false);
            this.pnlTabControl.ResumeLayout(false);
            this.grpBoxBuscarExpediente.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox grpBoxBuscarExpediente;
        private Label label2;
        private TextBox txtRegistroNro;
        private TextBox txtActaAnio;
        private TextBox txtActaNro;
        private Label label1;
        private Button btnFiltrar;
        private Label label6;
        private TextBox txtDenominacion;
        private Label label5;
        private Label label4;
        private TextBox txtEdActaNro;
        private TextBox txtEdActaAnio;
        private TextBox txtEdRegistroNro;
        private Label label3;
        private Label label7;
        private TextBox txtTramite;
        private TextBox txtExpeID;
        private TextBox txtExpeOpoID;
        private Label label8;
        private Base.ucTextSearchBox tSBCliente;
        private Base.ucTextSearchBox tSBTramite;
        private Label label10;
        private Label label9;
        private CheckBox chkCopiarHI;
        private TextBox txtOTID;
        private Label label11;
        private TextBox txtHITexto;
        private Label label13;
        private Label label12;
        private TextBox txtFechaPresentacion;
        private DateTimePicker dtpFechaPresentacion;
        private Label label16;
        private TextBox txtContraparteNombre;
        private Label label15;
        private Label label14;
        private TextBox txtParteNombre;
        private Base.ucTextSearchBox tSBAtencion;
        private Label label17;
        private Label label21;
        private Label label20;
        private TextBox txtFechaEntrada;
        private DateTimePicker dtpFechaEntrada;
        private DateTimePicker dtpFechaSalida;
        private Label label19;
        private Label label18;
        private TextBox txtFechaSalida;
        private Label label22;
        private TextBox txtUsuarioCargaID;
        private TextBox txtUsuarioCargaNombre;


    }
}