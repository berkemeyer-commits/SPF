using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.Forms.UI
{
    partial class FPresupuesto
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FPresupuesto));
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.panel4 = new Gizmox.WebGUI.Forms.Panel();
            this.tbCtrlGenPresup = new Gizmox.WebGUI.Forms.TabControl();
            this.tpFiltros = new Gizmox.WebGUI.Forms.TabPage();
            this.grpFiltros = new Gizmox.WebGUI.Forms.GroupBox();
            this.label13 = new Gizmox.WebGUI.Forms.Label();
            this.textBox8 = new Gizmox.WebGUI.Forms.TextBox();
            this.label12 = new Gizmox.WebGUI.Forms.Label();
            this.txtCotizacionCabID = new Gizmox.WebGUI.Forms.TextBox();
            this.grpAgruparPor = new Gizmox.WebGUI.Forms.GroupBox();
            this.rbHI = new Gizmox.WebGUI.Forms.RadioButton();
            this.rbMarcas = new Gizmox.WebGUI.Forms.RadioButton();
            this.grpGenerados = new Gizmox.WebGUI.Forms.GroupBox();
            this.rbNoGenerados = new Gizmox.WebGUI.Forms.RadioButton();
            this.rbGenerados = new Gizmox.WebGUI.Forms.RadioButton();
            this.rbTodos = new Gizmox.WebGUI.Forms.RadioButton();
            this.txtExpediente = new Gizmox.WebGUI.Forms.TextBox();
            this.label11 = new Gizmox.WebGUI.Forms.Label();
            this.textBox6 = new Gizmox.WebGUI.Forms.TextBox();
            this.label10 = new Gizmox.WebGUI.Forms.Label();
            this.txtFechaHasta = new Gizmox.WebGUI.Forms.TextBox();
            this.txtFechaDesde = new Gizmox.WebGUI.Forms.TextBox();
            this.dtpFechaHasta = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.dtpFechaDesde = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.label9 = new Gizmox.WebGUI.Forms.Label();
            this.textBox5 = new Gizmox.WebGUI.Forms.TextBox();
            this.label8 = new Gizmox.WebGUI.Forms.Label();
            this.label7 = new Gizmox.WebGUI.Forms.Label();
            this.textBox4 = new Gizmox.WebGUI.Forms.TextBox();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.textBox3 = new Gizmox.WebGUI.Forms.TextBox();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.txtActaNro = new Gizmox.WebGUI.Forms.TextBox();
            this.txtActaAnho = new Gizmox.WebGUI.Forms.TextBox();
            this.txtHIAnio = new Gizmox.WebGUI.Forms.TextBox();
            this.txtHINro = new Gizmox.WebGUI.Forms.TextBox();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.textBox1 = new Gizmox.WebGUI.Forms.TextBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.lblCliente = new Gizmox.WebGUI.Forms.Label();
            this.textBox2 = new Gizmox.WebGUI.Forms.TextBox();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.tSBCliente = new SPF.UserControls.Base.ucTextSearchBox();
            this.lblFiltros = new Gizmox.WebGUI.Forms.Label();
            this.groupBox1 = new Gizmox.WebGUI.Forms.GroupBox();
            this.tpTramites = new Gizmox.WebGUI.Forms.TabPage();
            this.grpTramites = new Gizmox.WebGUI.Forms.GroupBox();
            this.btnFiltrar = new Gizmox.WebGUI.Forms.Button();
            this.label15 = new Gizmox.WebGUI.Forms.Label();
            this.textBox9 = new Gizmox.WebGUI.Forms.TextBox();
            this.label14 = new Gizmox.WebGUI.Forms.Label();
            this.txtBuscarTramite = new Gizmox.WebGUI.Forms.TextBox();
            this.listBox1 = new Gizmox.WebGUI.Forms.ListBox();
            this.listBox2 = new Gizmox.WebGUI.Forms.ListBox();
            this.lblTramitesSeleccionados = new Gizmox.WebGUI.Forms.Label();
            this.lblTramitesDisponibles = new Gizmox.WebGUI.Forms.Label();
            this.btnAgregar = new Gizmox.WebGUI.Forms.Button();
            this.btnQuitar = new Gizmox.WebGUI.Forms.Button();
            this.btnAgregarTodos = new Gizmox.WebGUI.Forms.Button();
            this.btnQuitarTodos = new Gizmox.WebGUI.Forms.Button();
            this.lblTramites = new Gizmox.WebGUI.Forms.Label();
            this.groupBox2 = new Gizmox.WebGUI.Forms.GroupBox();
            this.tpSeleccion = new Gizmox.WebGUI.Forms.TabPage();
            this.pbarGeneracion = new Gizmox.WebGUI.Forms.ProgressBar();
            this.lblRegistrosInfo = new Gizmox.WebGUI.Forms.Label();
            this.grpSeleccion = new Gizmox.WebGUI.Forms.GroupBox();
            this.panel6 = new Gizmox.WebGUI.Forms.Panel();
            this.dgvCotizaciones = new Gizmox.WebGUI.Forms.DataGridView();
            this.panel5 = new Gizmox.WebGUI.Forms.Panel();
            this.btnActualizarConBD = new Gizmox.WebGUI.Forms.Button();
            this.btnActualizarGrilla = new Gizmox.WebGUI.Forms.Button();
            this.btnVerDocumentos = new Gizmox.WebGUI.Forms.Button();
            this.btnGenerar = new Gizmox.WebGUI.Forms.Button();
            this.btnMarcarTodo = new Gizmox.WebGUI.Forms.Button();
            this.lblSeleccion = new Gizmox.WebGUI.Forms.Label();
            this.groupBox3 = new Gizmox.WebGUI.Forms.GroupBox();
            this.panel3 = new Gizmox.WebGUI.Forms.Panel();
            this.btnAtras = new Gizmox.WebGUI.Forms.Button();
            this.btnFinalizar = new Gizmox.WebGUI.Forms.Button();
            this.btnCancelar = new Gizmox.WebGUI.Forms.Button();
            this.btnSiguiente = new Gizmox.WebGUI.Forms.Button();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.lblTitulo = new Gizmox.WebGUI.Forms.Label();
            this.toolTip1 = new Gizmox.WebGUI.Forms.ToolTip();
            this.timer1 = new Gizmox.WebGUI.Forms.Timer(this.components);
            this.rbMensuales = new Gizmox.WebGUI.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbCtrlGenPresup)).BeginInit();
            this.tbCtrlGenPresup.SuspendLayout();
            this.tpFiltros.SuspendLayout();
            this.grpFiltros.SuspendLayout();
            this.label13.SuspendLayout();
            this.grpAgruparPor.SuspendLayout();
            this.grpGenerados.SuspendLayout();
            this.label11.SuspendLayout();
            this.label9.SuspendLayout();
            this.label7.SuspendLayout();
            this.label5.SuspendLayout();
            this.label3.SuspendLayout();
            this.lblCliente.SuspendLayout();
            this.tpTramites.SuspendLayout();
            this.grpTramites.SuspendLayout();
            this.label15.SuspendLayout();
            this.tpSeleccion.SuspendLayout();
            this.grpSeleccion.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCotizaciones)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1183, 542);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tbCtrlGenPresup);
            this.panel4.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 35);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1183, 472);
            this.panel4.TabIndex = 2;
            // 
            // tbCtrlGenPresup
            // 
            this.tbCtrlGenPresup.Controls.Add(this.tpFiltros);
            this.tbCtrlGenPresup.Controls.Add(this.tpTramites);
            this.tbCtrlGenPresup.Controls.Add(this.tpSeleccion);
            this.tbCtrlGenPresup.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tbCtrlGenPresup.Location = new System.Drawing.Point(0, 0);
            this.tbCtrlGenPresup.Name = "tbCtrlGenPresup";
            this.tbCtrlGenPresup.SelectedIndex = 0;
            this.tbCtrlGenPresup.Size = new System.Drawing.Size(1183, 472);
            this.tbCtrlGenPresup.TabIndex = 0;
            this.tbCtrlGenPresup.SelectedIndexChanged += new System.EventHandler(this.tbCtrlGenPresup_SelectedIndexChanged);
            // 
            // tpFiltros
            // 
            this.tpFiltros.Controls.Add(this.grpFiltros);
            this.tpFiltros.Controls.Add(this.lblFiltros);
            this.tpFiltros.Controls.Add(this.groupBox1);
            this.tpFiltros.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tpFiltros.Location = new System.Drawing.Point(4, 22);
            this.tpFiltros.Name = "tpFiltros";
            this.tpFiltros.Size = new System.Drawing.Size(1175, 446);
            this.tpFiltros.TabIndex = 0;
            this.tpFiltros.Text = "Filtros";
            // 
            // grpFiltros
            // 
            this.grpFiltros.Controls.Add(this.label13);
            this.grpFiltros.Controls.Add(this.txtCotizacionCabID);
            this.grpFiltros.Controls.Add(this.grpAgruparPor);
            this.grpFiltros.Controls.Add(this.grpGenerados);
            this.grpFiltros.Controls.Add(this.txtExpediente);
            this.grpFiltros.Controls.Add(this.label11);
            this.grpFiltros.Controls.Add(this.txtFechaHasta);
            this.grpFiltros.Controls.Add(this.txtFechaDesde);
            this.grpFiltros.Controls.Add(this.dtpFechaHasta);
            this.grpFiltros.Controls.Add(this.dtpFechaDesde);
            this.grpFiltros.Controls.Add(this.label9);
            this.grpFiltros.Controls.Add(this.label7);
            this.grpFiltros.Controls.Add(this.label5);
            this.grpFiltros.Controls.Add(this.txtActaNro);
            this.grpFiltros.Controls.Add(this.txtActaAnho);
            this.grpFiltros.Controls.Add(this.txtHIAnio);
            this.grpFiltros.Controls.Add(this.txtHINro);
            this.grpFiltros.Controls.Add(this.label3);
            this.grpFiltros.Controls.Add(this.lblCliente);
            this.grpFiltros.Controls.Add(this.tSBCliente);
            this.grpFiltros.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.grpFiltros.Location = new System.Drawing.Point(23, 47);
            this.grpFiltros.Name = "grpFiltros";
            this.grpFiltros.Size = new System.Drawing.Size(1127, 373);
            this.grpFiltros.TabIndex = 2;
            this.grpFiltros.TabStop = false;
            this.grpFiltros.Text = "Especificación de Filtros";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Controls.Add(this.textBox8);
            this.label13.Controls.Add(this.label12);
            this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label13.Location = new System.Drawing.Point(7, 104);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 13);
            this.label13.TabIndex = 1;
            this.label13.Text = "Cotización ID";
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
            // txtCotizacionCabID
            // 
            this.txtCotizacionCabID.Location = new System.Drawing.Point(81, 101);
            this.txtCotizacionCabID.Name = "txtCotizacionCabID";
            this.txtCotizacionCabID.Size = new System.Drawing.Size(93, 20);
            this.txtCotizacionCabID.TabIndex = 5;
            this.toolTip1.SetToolTip(this.txtCotizacionCabID, "Identificador de Cotización");
            // 
            // grpAgruparPor
            // 
            this.grpAgruparPor.Controls.Add(this.rbMensuales);
            this.grpAgruparPor.Controls.Add(this.rbHI);
            this.grpAgruparPor.Controls.Add(this.rbMarcas);
            this.grpAgruparPor.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.grpAgruparPor.Location = new System.Drawing.Point(520, 80);
            this.grpAgruparPor.Name = "grpAgruparPor";
            this.grpAgruparPor.Size = new System.Drawing.Size(364, 41);
            this.grpAgruparPor.TabIndex = 8;
            this.grpAgruparPor.TabStop = false;
            this.grpAgruparPor.Text = "Agrupar Por";
            // 
            // rbHI
            // 
            this.rbHI.AutoSize = true;
            this.rbHI.Location = new System.Drawing.Point(99, 17);
            this.rbHI.Name = "rbHI";
            this.rbHI.Size = new System.Drawing.Size(109, 17);
            this.rbHI.TabIndex = 0;
            this.rbHI.Text = "Por Hoja de Inicio";
            // 
            // rbMarcas
            // 
            this.rbMarcas.AutoSize = true;
            this.rbMarcas.Checked = true;
            this.rbMarcas.Location = new System.Drawing.Point(18, 17);
            this.rbMarcas.Name = "rbMarcas";
            this.rbMarcas.Size = new System.Drawing.Size(73, 17);
            this.rbMarcas.TabIndex = 0;
            this.rbMarcas.Text = "Por Marca";
            // 
            // grpGenerados
            // 
            this.grpGenerados.Controls.Add(this.rbNoGenerados);
            this.grpGenerados.Controls.Add(this.rbGenerados);
            this.grpGenerados.Controls.Add(this.rbTodos);
            this.grpGenerados.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.grpGenerados.Location = new System.Drawing.Point(520, 17);
            this.grpGenerados.Name = "grpGenerados";
            this.grpGenerados.Size = new System.Drawing.Size(364, 41);
            this.grpGenerados.TabIndex = 8;
            this.grpGenerados.TabStop = false;
            this.grpGenerados.Text = "Incluir Presupuestos";
            // 
            // rbNoGenerados
            // 
            this.rbNoGenerados.AutoSize = true;
            this.rbNoGenerados.Location = new System.Drawing.Point(219, 16);
            this.rbNoGenerados.Name = "rbNoGenerados";
            this.rbNoGenerados.Size = new System.Drawing.Size(116, 17);
            this.rbNoGenerados.TabIndex = 0;
            this.rbNoGenerados.Text = "Sólo No Generados";
            // 
            // rbGenerados
            // 
            this.rbGenerados.AutoSize = true;
            this.rbGenerados.Location = new System.Drawing.Point(99, 16);
            this.rbGenerados.Name = "rbGenerados";
            this.rbGenerados.Size = new System.Drawing.Size(100, 17);
            this.rbGenerados.TabIndex = 0;
            this.rbGenerados.Text = "Sólo Generados";
            // 
            // rbTodos
            // 
            this.rbTodos.AutoSize = true;
            this.rbTodos.Checked = true;
            this.rbTodos.Location = new System.Drawing.Point(18, 17);
            this.rbTodos.Name = "rbTodos";
            this.rbTodos.Size = new System.Drawing.Size(54, 17);
            this.rbTodos.TabIndex = 0;
            this.rbTodos.Text = "Todos";
            // 
            // txtExpediente
            // 
            this.txtExpediente.Location = new System.Drawing.Point(325, 101);
            this.txtExpediente.Name = "txtExpediente";
            this.txtExpediente.Size = new System.Drawing.Size(93, 20);
            this.txtExpediente.TabIndex = 5;
            this.toolTip1.SetToolTip(this.txtExpediente, "Número de Expediente");
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Controls.Add(this.textBox6);
            this.label11.Controls.Add(this.label10);
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label11.Location = new System.Drawing.Point(261, 104);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Expediente";
            // 
            // textBox6
            // 
            this.textBox6.AllowDrag = false;
            this.textBox6.Location = new System.Drawing.Point(-184, -4);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(100, 20);
            this.textBox6.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(-279, -1);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Cliente";
            // 
            // txtFechaHasta
            // 
            this.txtFechaHasta.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0);
            this.txtFechaHasta.Location = new System.Drawing.Point(186, 141);
            this.txtFechaHasta.Name = "txtFechaHasta";
            this.txtFechaHasta.Size = new System.Drawing.Size(81, 18);
            this.txtFechaHasta.TabIndex = 7;
            this.toolTip1.SetToolTip(this.txtFechaHasta, "Fecha Hasta");
            // 
            // txtFechaDesde
            // 
            this.txtFechaDesde.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0);
            this.txtFechaDesde.Location = new System.Drawing.Point(83, 141);
            this.txtFechaDesde.Name = "txtFechaDesde";
            this.txtFechaDesde.Size = new System.Drawing.Size(81, 18);
            this.txtFechaDesde.TabIndex = 6;
            this.toolTip1.SetToolTip(this.txtFechaDesde, "Fecha Desde");
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.CustomFormat = "dd/mm/yyyy";
            this.dtpFechaHasta.Location = new System.Drawing.Point(185, 140);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(100, 21);
            this.dtpFechaHasta.TabIndex = 3;
            this.dtpFechaHasta.TabStop = false;
            this.dtpFechaHasta.ValueChanged += new System.EventHandler(this.dtpFechaHasta_ValueChanged);
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.CustomFormat = "dd/mm/yyyy";
            this.dtpFechaDesde.Location = new System.Drawing.Point(82, 140);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(100, 20);
            this.dtpFechaDesde.TabIndex = 3;
            this.dtpFechaDesde.TabStop = false;
            this.dtpFechaDesde.ValueChanged += new System.EventHandler(this.dtpFechaDesde_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Controls.Add(this.textBox5);
            this.label9.Controls.Add(this.label8);
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label9.Location = new System.Drawing.Point(10, 150);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Cotización";
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Controls.Add(this.textBox4);
            this.label7.Controls.Add(this.label6);
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label7.Location = new System.Drawing.Point(28, 137);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Fecha de";
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(-279, -1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Cliente";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Controls.Add(this.textBox3);
            this.label5.Controls.Add(this.label4);
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label5.Location = new System.Drawing.Point(244, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Acta";
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(-279, -1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Cliente";
            // 
            // txtActaNro
            // 
            this.txtActaNro.Location = new System.Drawing.Point(276, 64);
            this.txtActaNro.Name = "txtActaNro";
            this.txtActaNro.Size = new System.Drawing.Size(70, 20);
            this.txtActaNro.TabIndex = 3;
            this.toolTip1.SetToolTip(this.txtActaNro, "Número del Acta");
            // 
            // txtActaAnho
            // 
            this.txtActaAnho.Location = new System.Drawing.Point(348, 64);
            this.txtActaAnho.Name = "txtActaAnho";
            this.txtActaAnho.Size = new System.Drawing.Size(70, 20);
            this.txtActaAnho.TabIndex = 4;
            this.toolTip1.SetToolTip(this.txtActaAnho, "Año del Acta");
            // 
            // txtHIAnio
            // 
            this.txtHIAnio.Location = new System.Drawing.Point(153, 64);
            this.txtHIAnio.Name = "txtHIAnio";
            this.txtHIAnio.Size = new System.Drawing.Size(70, 20);
            this.txtHIAnio.TabIndex = 2;
            this.toolTip1.SetToolTip(this.txtHIAnio, "Año de la Hoja de Inicio");
            // 
            // txtHINro
            // 
            this.txtHINro.Location = new System.Drawing.Point(81, 64);
            this.txtHINro.Name = "txtHINro";
            this.txtHINro.Size = new System.Drawing.Size(70, 20);
            this.txtHINro.TabIndex = 1;
            this.toolTip1.SetToolTip(this.txtHINro, "Número de la Hoja de Inicio");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Controls.Add(this.textBox1);
            this.label3.Controls.Add(this.label1);
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label3.Location = new System.Drawing.Point(51, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "H.I.";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(-279, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cliente";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Controls.Add(this.textBox2);
            this.lblCliente.Controls.Add(this.label2);
            this.lblCliente.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblCliente.Location = new System.Drawing.Point(37, 33);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(35, 13);
            this.lblCliente.TabIndex = 1;
            this.lblCliente.Text = "Cliente";
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
            // tSBCliente
            // 
            this.tSBCliente.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBCliente.BackColor = System.Drawing.Color.Transparent;
            this.tSBCliente.DBContext = null;
            this.tSBCliente.DisplayMember = "";
            this.tSBCliente.KeyMember = "";
            this.tSBCliente.LabelCampoBusqueda = "";
            this.tSBCliente.Location = new System.Drawing.Point(82, 30);
            this.tSBCliente.Name = "tSBCliente";
            this.tSBCliente.NombreCampoDescrip = "";
            this.tSBCliente.NombreCampoID = "";
            this.tSBCliente.Size = new System.Drawing.Size(375, 20);
            this.tSBCliente.SoloLectura = false;
            this.tSBCliente.TabIndex = 0;
            this.tSBCliente.Text = "ucTextSearchBox";
            this.tSBCliente.TituloBuscador = "";
            this.toolTip1.SetToolTip(this.tSBCliente, "Cliente");
            // 
            // lblFiltros
            // 
            this.lblFiltros.AutoSize = true;
            this.lblFiltros.Location = new System.Drawing.Point(33, 20);
            this.lblFiltros.Name = "lblFiltros";
            this.lblFiltros.Size = new System.Drawing.Size(35, 13);
            this.lblFiltros.TabIndex = 0;
            this.lblFiltros.Text = "Filtros";
            // 
            // groupBox1
            // 
            this.groupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(23, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1129, 44);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // tpTramites
            // 
            this.tpTramites.Controls.Add(this.grpTramites);
            this.tpTramites.Controls.Add(this.lblTramites);
            this.tpTramites.Controls.Add(this.groupBox2);
            this.tpTramites.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tpTramites.Location = new System.Drawing.Point(4, 22);
            this.tpTramites.Name = "tpTramites";
            this.tpTramites.Size = new System.Drawing.Size(1175, 394);
            this.tpTramites.TabIndex = 1;
            this.tpTramites.Text = "Trámites";
            // 
            // grpTramites
            // 
            this.grpTramites.Controls.Add(this.btnFiltrar);
            this.grpTramites.Controls.Add(this.label15);
            this.grpTramites.Controls.Add(this.txtBuscarTramite);
            this.grpTramites.Controls.Add(this.listBox1);
            this.grpTramites.Controls.Add(this.listBox2);
            this.grpTramites.Controls.Add(this.lblTramitesSeleccionados);
            this.grpTramites.Controls.Add(this.lblTramitesDisponibles);
            this.grpTramites.Controls.Add(this.btnAgregar);
            this.grpTramites.Controls.Add(this.btnQuitar);
            this.grpTramites.Controls.Add(this.btnAgregarTodos);
            this.grpTramites.Controls.Add(this.btnQuitarTodos);
            this.grpTramites.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.grpTramites.Location = new System.Drawing.Point(23, 47);
            this.grpTramites.Name = "grpTramites";
            this.grpTramites.Size = new System.Drawing.Size(1127, 373);
            this.grpTramites.TabIndex = 2;
            this.grpTramites.TabStop = false;
            this.grpTramites.Text = "Selección de Trámites";
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnFiltrar.Image"));
            this.btnFiltrar.Location = new System.Drawing.Point(492, 37);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(40, 40);
            this.btnFiltrar.TabIndex = 2;
            this.toolTip1.SetToolTip(this.btnFiltrar, "Buscar");
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Controls.Add(this.textBox9);
            this.label15.Controls.Add(this.label14);
            this.label15.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label15.Location = new System.Drawing.Point(52, 51);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 13);
            this.label15.TabIndex = 1;
            this.label15.Text = "Buscar";
            // 
            // textBox9
            // 
            this.textBox9.AllowDrag = false;
            this.textBox9.Location = new System.Drawing.Point(-184, -4);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(100, 20);
            this.textBox9.TabIndex = 0;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label14.Location = new System.Drawing.Point(-279, -1);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 13);
            this.label14.TabIndex = 1;
            this.label14.Text = "Cliente";
            // 
            // txtBuscarTramite
            // 
            this.txtBuscarTramite.Location = new System.Drawing.Point(93, 48);
            this.txtBuscarTramite.Name = "txtBuscarTramite";
            this.txtBuscarTramite.Size = new System.Drawing.Size(396, 20);
            this.txtBuscarTramite.TabIndex = 5;
            this.toolTip1.SetToolTip(this.txtBuscarTramite, "Filtrar por nombre o código de Trámite");
            // 
            // listBox1
            // 
            this.listBox1.Location = new System.Drawing.Point(52, 80);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(480, 277);
            this.listBox1.TabIndex = 0;
            this.listBox1.DoubleClick += new System.EventHandler(this.btnAgregar_Click);
            // 
            // listBox2
            // 
            this.listBox2.Location = new System.Drawing.Point(597, 41);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(480, 316);
            this.listBox2.TabIndex = 0;
            this.listBox2.DoubleClick += new System.EventHandler(this.btnQuitar_Click);
            // 
            // lblTramitesSeleccionados
            // 
            this.lblTramitesSeleccionados.AutoSize = true;
            this.lblTramitesSeleccionados.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblTramitesSeleccionados.Location = new System.Drawing.Point(597, 24);
            this.lblTramitesSeleccionados.Name = "lblTramitesSeleccionados";
            this.lblTramitesSeleccionados.Size = new System.Drawing.Size(35, 13);
            this.lblTramitesSeleccionados.TabIndex = 1;
            this.lblTramitesSeleccionados.Text = "Trámites Seleccionados";
            // 
            // lblTramitesDisponibles
            // 
            this.lblTramitesDisponibles.AutoSize = true;
            this.lblTramitesDisponibles.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblTramitesDisponibles.Location = new System.Drawing.Point(49, 24);
            this.lblTramitesDisponibles.Name = "lblTramitesDisponibles";
            this.lblTramitesDisponibles.Size = new System.Drawing.Size(35, 13);
            this.lblTramitesDisponibles.TabIndex = 1;
            this.lblTramitesDisponibles.Text = "Trámites Disponibles";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnAgregar.Location = new System.Drawing.Point(542, 150);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(45, 36);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = ">";
            this.toolTip1.SetToolTip(this.btnAgregar, "Agregar Seleccionado");
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnQuitar
            // 
            this.btnQuitar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnQuitar.Location = new System.Drawing.Point(542, 199);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(45, 35);
            this.btnQuitar.TabIndex = 2;
            this.btnQuitar.Text = "<";
            this.toolTip1.SetToolTip(this.btnQuitar, "Quitar Seleccionado");
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnAgregarTodos
            // 
            this.btnAgregarTodos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnAgregarTodos.Location = new System.Drawing.Point(542, 100);
            this.btnAgregarTodos.Name = "btnAgregarTodos";
            this.btnAgregarTodos.Size = new System.Drawing.Size(45, 36);
            this.btnAgregarTodos.TabIndex = 2;
            this.btnAgregarTodos.Text = ">>";
            this.toolTip1.SetToolTip(this.btnAgregarTodos, "Agregar Todos");
            this.btnAgregarTodos.Click += new System.EventHandler(this.btnAgregarTodos_Click);
            // 
            // btnQuitarTodos
            // 
            this.btnQuitarTodos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnQuitarTodos.Location = new System.Drawing.Point(542, 248);
            this.btnQuitarTodos.Name = "btnQuitarTodos";
            this.btnQuitarTodos.Size = new System.Drawing.Size(45, 35);
            this.btnQuitarTodos.TabIndex = 2;
            this.btnQuitarTodos.Text = "<<";
            this.toolTip1.SetToolTip(this.btnQuitarTodos, "Quitar Todos");
            this.btnQuitarTodos.Click += new System.EventHandler(this.btnQuitarTodos_Click);
            // 
            // lblTramites
            // 
            this.lblTramites.AutoSize = true;
            this.lblTramites.Location = new System.Drawing.Point(33, 20);
            this.lblTramites.Name = "lblTramites";
            this.lblTramites.Size = new System.Drawing.Size(35, 13);
            this.lblTramites.TabIndex = 0;
            this.lblTramites.Text = "Trámites";
            // 
            // groupBox2
            // 
            this.groupBox2.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(23, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1129, 44);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // tpSeleccion
            // 
            this.tpSeleccion.Controls.Add(this.pbarGeneracion);
            this.tpSeleccion.Controls.Add(this.lblRegistrosInfo);
            this.tpSeleccion.Controls.Add(this.grpSeleccion);
            this.tpSeleccion.Controls.Add(this.lblSeleccion);
            this.tpSeleccion.Controls.Add(this.groupBox3);
            this.tpSeleccion.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tpSeleccion.Location = new System.Drawing.Point(0, 0);
            this.tpSeleccion.Name = "tpSeleccion";
            this.tpSeleccion.Size = new System.Drawing.Size(1175, 446);
            this.tpSeleccion.TabIndex = 2;
            this.tpSeleccion.Text = "Selección";
            // 
            // pbarGeneracion
            // 
            this.pbarGeneracion.Location = new System.Drawing.Point(27, 433);
            this.pbarGeneracion.Name = "pbarGeneracion";
            this.pbarGeneracion.Size = new System.Drawing.Size(1120, 12);
            this.pbarGeneracion.TabIndex = 4;
            this.pbarGeneracion.Visible = false;
            // 
            // lblRegistrosInfo
            // 
            this.lblRegistrosInfo.AutoSize = true;
            this.lblRegistrosInfo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblRegistrosInfo.ForeColor = System.Drawing.Color.Green;
            this.lblRegistrosInfo.Location = new System.Drawing.Point(26, 420);
            this.lblRegistrosInfo.Name = "lblRegistrosInfo";
            this.lblRegistrosInfo.Size = new System.Drawing.Size(41, 13);
            this.lblRegistrosInfo.TabIndex = 3;
            this.lblRegistrosInfo.Text = "lblRegistrosInfo";
            // 
            // grpSeleccion
            // 
            this.grpSeleccion.Controls.Add(this.panel6);
            this.grpSeleccion.Controls.Add(this.panel5);
            this.grpSeleccion.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.grpSeleccion.Location = new System.Drawing.Point(23, 47);
            this.grpSeleccion.Name = "grpSeleccion";
            this.grpSeleccion.Size = new System.Drawing.Size(1127, 373);
            this.grpSeleccion.TabIndex = 2;
            this.grpSeleccion.TabStop = false;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.dgvCotizaciones);
            this.panel6.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 17);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1008, 353);
            this.panel6.TabIndex = 1;
            // 
            // dgvCotizaciones
            // 
            this.dgvCotizaciones.AllowUserToAddRows = false;
            this.dgvCotizaciones.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.dgvCotizaciones.Location = new System.Drawing.Point(0, 0);
            this.dgvCotizaciones.Name = "dgvCotizaciones";
            this.dgvCotizaciones.Size = new System.Drawing.Size(1006, 351);
            this.dgvCotizaciones.TabIndex = 0;
            this.dgvCotizaciones.Text = "Cotizaciones Confirmadas";
            this.dgvCotizaciones.CellContentClick += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.dgvCotizaciones_CellContentClick);
            this.dgvCotizaciones.CellFormatting += new Gizmox.WebGUI.Forms.DataGridViewCellFormattingEventHandler(this.dgvCotizaciones_CellFormatting);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnActualizarConBD);
            this.panel5.Controls.Add(this.btnActualizarGrilla);
            this.panel5.Controls.Add(this.btnVerDocumentos);
            this.panel5.Controls.Add(this.btnGenerar);
            this.panel5.Controls.Add(this.btnMarcarTodo);
            this.panel5.Dock = Gizmox.WebGUI.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(1011, 17);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(113, 353);
            this.panel5.TabIndex = 0;
            // 
            // btnActualizarConBD
            // 
            this.btnActualizarConBD.CustomStyle = "F";
            this.btnActualizarConBD.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnActualizarConBD.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnActualizarConBD.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.btnActualizarConBD.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnActualizarConBD.Image"));
            this.btnActualizarConBD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActualizarConBD.ImageSize = new System.Drawing.Size(32, 32);
            this.btnActualizarConBD.Location = new System.Drawing.Point(8, 210);
            this.btnActualizarConBD.Name = "btnActualizarConBD";
            this.btnActualizarConBD.Size = new System.Drawing.Size(104, 36);
            this.btnActualizarConBD.TabIndex = 20;
            this.btnActualizarConBD.Text = "Actualizar";
            this.btnActualizarConBD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActualizarConBD.Click += new System.EventHandler(this.btnActualizarConBD_Click);
            // 
            // btnActualizarGrilla
            // 
            this.btnActualizarGrilla.CustomStyle = "F";
            this.btnActualizarGrilla.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnActualizarGrilla.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnActualizarGrilla.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.btnActualizarGrilla.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnActualizarGrilla.Image"));
            this.btnActualizarGrilla.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActualizarGrilla.ImageSize = new System.Drawing.Size(32, 32);
            this.btnActualizarGrilla.Location = new System.Drawing.Point(8, 162);
            this.btnActualizarGrilla.Name = "btnActualizarGrilla";
            this.btnActualizarGrilla.Size = new System.Drawing.Size(104, 36);
            this.btnActualizarGrilla.TabIndex = 20;
            this.btnActualizarGrilla.Text = "Actualizar";
            this.btnActualizarGrilla.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActualizarGrilla.Click += new System.EventHandler(this.btnActualizarGrilla_Click);
            // 
            // btnVerDocumentos
            // 
            this.btnVerDocumentos.CustomStyle = "F";
            this.btnVerDocumentos.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnVerDocumentos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnVerDocumentos.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.btnVerDocumentos.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnVerDocumentos.Image"));
            this.btnVerDocumentos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVerDocumentos.ImageSize = new System.Drawing.Size(32, 32);
            this.btnVerDocumentos.Location = new System.Drawing.Point(8, 113);
            this.btnVerDocumentos.Name = "btnVerDocumentos";
            this.btnVerDocumentos.Size = new System.Drawing.Size(104, 36);
            this.btnVerDocumentos.TabIndex = 20;
            this.btnVerDocumentos.Text = "&Ver";
            this.btnVerDocumentos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVerDocumentos.Click += new System.EventHandler(this.btnVerDocumentos_Click);
            // 
            // btnGenerar
            // 
            this.btnGenerar.CustomStyle = "F";
            this.btnGenerar.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnGenerar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnGenerar.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.btnGenerar.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnGenerar.Image"));
            this.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerar.ImageSize = new System.Drawing.Size(32, 32);
            this.btnGenerar.Location = new System.Drawing.Point(8, 64);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(104, 36);
            this.btnGenerar.TabIndex = 20;
            this.btnGenerar.Text = "&Generar";
            this.btnGenerar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // btnMarcarTodo
            // 
            this.btnMarcarTodo.CustomStyle = "F";
            this.btnMarcarTodo.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnMarcarTodo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnMarcarTodo.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.btnMarcarTodo.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnMarcarTodo.Image"));
            this.btnMarcarTodo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMarcarTodo.ImageSize = new System.Drawing.Size(32, 32);
            this.btnMarcarTodo.Location = new System.Drawing.Point(8, 15);
            this.btnMarcarTodo.Name = "btnMarcarTodo";
            this.btnMarcarTodo.Size = new System.Drawing.Size(104, 36);
            this.btnMarcarTodo.TabIndex = 20;
            this.btnMarcarTodo.Text = "&Marcar Todo";
            this.btnMarcarTodo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMarcarTodo.Click += new System.EventHandler(this.btnMarcarTodo_Click);
            // 
            // lblSeleccion
            // 
            this.lblSeleccion.AutoSize = true;
            this.lblSeleccion.Location = new System.Drawing.Point(33, 20);
            this.lblSeleccion.Name = "lblSeleccion";
            this.lblSeleccion.Size = new System.Drawing.Size(35, 13);
            this.lblSeleccion.TabIndex = 0;
            this.lblSeleccion.Text = "Selección";
            // 
            // groupBox3
            // 
            this.groupBox3.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox3.Location = new System.Drawing.Point(23, 1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1129, 44);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel3.Controls.Add(this.btnAtras);
            this.panel3.Controls.Add(this.btnFinalizar);
            this.panel3.Controls.Add(this.btnCancelar);
            this.panel3.Controls.Add(this.btnSiguiente);
            this.panel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 507);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1183, 35);
            this.panel3.TabIndex = 1;
            // 
            // btnAtras
            // 
            this.btnAtras.Location = new System.Drawing.Point(903, 6);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(75, 23);
            this.btnAtras.TabIndex = 1;
            this.btnAtras.Text = "&Atrás";
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.Location = new System.Drawing.Point(1079, 6);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(75, 23);
            this.btnFinalizar.TabIndex = 3;
            this.btnFinalizar.Text = "&Finalizar";
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(813, 6);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 0;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Location = new System.Drawing.Point(991, 6);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(75, 23);
            this.btnSiguiente.TabIndex = 2;
            this.btnSiguiente.Text = "&Siguiente";
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel2.Controls.Add(this.lblTitulo);
            this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1183, 35);
            this.panel2.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(9, 11);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(35, 13);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Especificación de Filtros";
            // 
            // timer1
            // 
            this.timer1.Interval = 1500;
            // 
            // rbMensuales
            // 
            this.rbMensuales.AutoSize = true;
            this.rbMensuales.Location = new System.Drawing.Point(219, 17);
            this.rbMensuales.Name = "rbMensuales";
            this.rbMensuales.Size = new System.Drawing.Size(75, 17);
            this.rbMensuales.TabIndex = 0;
            this.rbMensuales.Text = "Mensuales";
            // 
            // FPresupuesto
            // 
            this.CloseBox = false;
            this.Controls.Add(this.panel1);
            this.Size = new System.Drawing.Size(1183, 542);
            this.Text = "Generación de Presupuestos";
            this.Load += new System.EventHandler(this.FPresupuesto_Load);
            this.RegisteredTimers = new Gizmox.WebGUI.Forms.Timer[] {
        this.timer1};
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbCtrlGenPresup)).EndInit();
            this.tbCtrlGenPresup.ResumeLayout(false);
            this.tpFiltros.ResumeLayout(false);
            this.grpFiltros.ResumeLayout(false);
            this.label13.ResumeLayout(false);
            this.grpAgruparPor.ResumeLayout(false);
            this.grpGenerados.ResumeLayout(false);
            this.label11.ResumeLayout(false);
            this.label9.ResumeLayout(false);
            this.label7.ResumeLayout(false);
            this.label5.ResumeLayout(false);
            this.label3.ResumeLayout(false);
            this.lblCliente.ResumeLayout(false);
            this.tpTramites.ResumeLayout(false);
            this.grpTramites.ResumeLayout(false);
            this.label15.ResumeLayout(false);
            this.tpSeleccion.ResumeLayout(false);
            this.grpSeleccion.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCotizaciones)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Panel panel4;
        private TabControl tbCtrlGenPresup;
        private TabPage tpFiltros;
        private TabPage tpTramites;
        private Panel panel3;
        private Panel panel2;
        private Button btnFinalizar;
        private Button btnCancelar;
        private Button btnSiguiente;
        private Label lblFiltros;
        private Label lblTramites;
        private Button btnAtras;
        private TabPage tpSeleccion;
        private Label lblSeleccion;
        private Label lblTitulo;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox grpFiltros;
        private GroupBox grpTramites;
        private GroupBox grpSeleccion;
        private Label lblCliente;
        private TextBox textBox2;
        private Label label2;
        private UserControls.Base.ucTextSearchBox tSBCliente;
        private Label label3;
        private TextBox textBox1;
        private Label label1;
        private TextBox txtActaNro;
        private TextBox txtActaAnho;
        private TextBox txtHIAnio;
        private TextBox txtHINro;
        private Label label5;
        private TextBox textBox3;
        private Label label4;
        private ToolTip toolTip1;
        private Label label9;
        private TextBox textBox5;
        private Label label8;
        private Label label7;
        private TextBox textBox4;
        private Label label6;
        private DateTimePicker dtpFechaDesde;
        private DateTimePicker dtpFechaHasta;
        private TextBox txtFechaDesde;
        private TextBox txtFechaHasta;
        private TextBox txtExpediente;
        private Label label11;
        private TextBox textBox6;
        private Label label10;
        private ListBox listBox1;
        private ListBox listBox2;
        private Label lblTramitesSeleccionados;
        private Label lblTramitesDisponibles;
        private Button btnAgregar;
        private Button btnQuitar;
        private Button btnAgregarTodos;
        private Button btnQuitarTodos;
        private Label lblRegistrosInfo;
        private Panel panel6;
        private DataGridView dgvCotizaciones;
        private Panel panel5;
        private Button btnMarcarTodo;
        private Button btnGenerar;
        private GroupBox grpGenerados;
        private RadioButton rbNoGenerados;
        private RadioButton rbGenerados;
        private RadioButton rbTodos;
        private GroupBox grpAgruparPor;
        private RadioButton rbHI;
        private RadioButton rbMarcas;
        private ProgressBar pbarGeneracion;
        private Timer timer1;
        private Button btnVerDocumentos;
        private Button btnActualizarGrilla;
        private Button btnActualizarConBD;
        private Label label13;
        private TextBox textBox8;
        private Label label12;
        private TextBox txtCotizacionCabID;
        private Label label15;
        private TextBox textBox9;
        private Label label14;
        private TextBox txtBuscarTramite;
        private Button btnFiltrar;
        private RadioButton rbMensuales;
        

        



    }
}