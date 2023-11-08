using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.Forms.UI
{
    partial class FSelecPresupFactura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FSelecPresupFactura));
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.panel4 = new Gizmox.WebGUI.Forms.Panel();
            this.panel6 = new Gizmox.WebGUI.Forms.Panel();
            this.dgvPresupuestos = new Gizmox.WebGUI.Forms.DataGridView();
            this.panel3 = new Gizmox.WebGUI.Forms.Panel();
            this.btnAceptar = new Gizmox.WebGUI.Forms.Button();
            this.btnCancelar = new Gizmox.WebGUI.Forms.Button();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.groupBox4 = new Gizmox.WebGUI.Forms.GroupBox();
            this.txtFechaCobroHasta = new Gizmox.WebGUI.Forms.TextBox();
            this.txtFechaCobroDesde = new Gizmox.WebGUI.Forms.TextBox();
            this.dtpFechaCobroDesde = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.label10 = new Gizmox.WebGUI.Forms.Label();
            this.label11 = new Gizmox.WebGUI.Forms.Label();
            this.dtpFechaCobroHasta = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.groupBox3 = new Gizmox.WebGUI.Forms.GroupBox();
            this.tSBBancoCheque = new SPF.UserControls.Base.ucTextSearchBox();
            this.label8 = new Gizmox.WebGUI.Forms.Label();
            this.txtNroCheque = new Gizmox.WebGUI.Forms.TextBox();
            this.label7 = new Gizmox.WebGUI.Forms.Label();
            this.groupBox2 = new Gizmox.WebGUI.Forms.GroupBox();
            this.txtFechaDepositoHasta = new Gizmox.WebGUI.Forms.TextBox();
            this.txtFechaDepositoDesde = new Gizmox.WebGUI.Forms.TextBox();
            this.txtNroBoletaDeposito = new Gizmox.WebGUI.Forms.TextBox();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.dtpFechaDepositoDesde = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.dtpFechaDepositoHasta = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.groupBox1 = new Gizmox.WebGUI.Forms.GroupBox();
            this.txtIDDocumento = new Gizmox.WebGUI.Forms.TextBox();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.txtFechaHasta = new Gizmox.WebGUI.Forms.TextBox();
            this.txtFechaDesde = new Gizmox.WebGUI.Forms.TextBox();
            this.tSBCliente = new SPF.UserControls.Base.ucTextSearchBox();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.dtpFechaHasta = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.label18 = new Gizmox.WebGUI.Forms.Label();
            this.label21 = new Gizmox.WebGUI.Forms.Label();
            this.dtpFechaDesde = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.txtNroDocumento = new Gizmox.WebGUI.Forms.TextBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.btnLimpiarFiltros = new Gizmox.WebGUI.Forms.Button();
            this.panel5 = new Gizmox.WebGUI.Forms.Panel();
            this.lblEstado = new Gizmox.WebGUI.Forms.Label();
            this.btnFiltrar = new Gizmox.WebGUI.Forms.Button();
            this.toolTip1 = new Gizmox.WebGUI.Forms.ToolTip();
            this.btnMarcarTodo = new Gizmox.WebGUI.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPresupuestos)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel5.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(1004, 504);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 217);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1004, 247);
            this.panel4.TabIndex = 2;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dgvPresupuestos);
            this.panel6.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1004, 247);
            this.panel6.TabIndex = 1;
            // 
            // dgvPresupuestos
            // 
            this.dgvPresupuestos.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.dgvPresupuestos.Location = new System.Drawing.Point(0, 0);
            this.dgvPresupuestos.Name = "dgvPresupuestos";
            this.dgvPresupuestos.Size = new System.Drawing.Size(1004, 247);
            this.dgvPresupuestos.TabIndex = 7;
            this.dgvPresupuestos.CellFormatting += new Gizmox.WebGUI.Forms.DataGridViewCellFormattingEventHandler(this.dgvPresupuestos_CellFormatting);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel3.Controls.Add(this.btnMarcarTodo);
            this.panel3.Controls.Add(this.btnAceptar);
            this.panel3.Controls.Add(this.btnCancelar);
            this.panel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 464);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1004, 40);
            this.panel3.TabIndex = 1;
            // 
            // btnAceptar
            // 
            this.btnAceptar.CustomStyle = "F";
            this.btnAceptar.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnAceptar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnAceptar.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnAceptar.Image"));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.ImageSize = new System.Drawing.Size(32, 32);
            this.btnAceptar.Location = new System.Drawing.Point(815, 2);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(85, 36);
            this.btnAceptar.TabIndex = 5;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.CustomStyle = "F";
            this.btnCancelar.DialogResult = Gizmox.WebGUI.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnCancelar.Image"));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.ImageSize = new System.Drawing.Size(32, 32);
            this.btnCancelar.Location = new System.Drawing.Point(903, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 36);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel2.Controls.Add(this.groupBox4);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.btnLimpiarFiltros);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.btnFiltrar);
            this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1004, 217);
            this.panel2.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtFechaCobroHasta);
            this.groupBox4.Controls.Add(this.txtFechaCobroDesde);
            this.groupBox4.Controls.Add(this.dtpFechaCobroDesde);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.dtpFechaCobroHasta);
            this.groupBox4.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox4.ForeColor = System.Drawing.Color.White;
            this.groupBox4.Location = new System.Drawing.Point(480, 111);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(451, 79);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Cobranza";
            // 
            // txtFechaCobroHasta
            // 
            this.txtFechaCobroHasta.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.None;
            this.txtFechaCobroHasta.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0);
            this.txtFechaCobroHasta.Location = new System.Drawing.Point(299, 32);
            this.txtFechaCobroHasta.Name = "txtFechaCobroHasta";
            this.txtFechaCobroHasta.Size = new System.Drawing.Size(81, 18);
            this.txtFechaCobroHasta.TabIndex = 1;
            // 
            // txtFechaCobroDesde
            // 
            this.txtFechaCobroDesde.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.None;
            this.txtFechaCobroDesde.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0);
            this.txtFechaCobroDesde.Location = new System.Drawing.Point(99, 32);
            this.txtFechaCobroDesde.Name = "txtFechaCobroDesde";
            this.txtFechaCobroDesde.Size = new System.Drawing.Size(81, 18);
            this.txtFechaCobroDesde.TabIndex = 0;
            // 
            // dtpFechaCobroDesde
            // 
            this.dtpFechaCobroDesde.CustomFormat = "dd/mm/yyyy";
            this.dtpFechaCobroDesde.Location = new System.Drawing.Point(98, 31);
            this.dtpFechaCobroDesde.Name = "dtpFechaCobroDesde";
            this.dtpFechaCobroDesde.Size = new System.Drawing.Size(100, 20);
            this.dtpFechaCobroDesde.TabIndex = 3;
            this.dtpFechaCobroDesde.TabStop = false;
            this.dtpFechaCobroDesde.ValueChanged += new System.EventHandler(this.dtpFechaCobroDesde_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Fecha Desde";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(215, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Fecha Hasta";
            // 
            // dtpFechaCobroHasta
            // 
            this.dtpFechaCobroHasta.CustomFormat = "dd/mm/yyyy";
            this.dtpFechaCobroHasta.Location = new System.Drawing.Point(298, 31);
            this.dtpFechaCobroHasta.Name = "dtpFechaCobroHasta";
            this.dtpFechaCobroHasta.Size = new System.Drawing.Size(100, 20);
            this.dtpFechaCobroHasta.TabIndex = 3;
            this.dtpFechaCobroHasta.TabStop = false;
            this.dtpFechaCobroHasta.ValueChanged += new System.EventHandler(this.dtpFechaCobroHasta_ValueChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tSBBancoCheque);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtNroCheque);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(18, 97);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(451, 91);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Cheque";
            // 
            // tSBBancoCheque
            // 
            this.tSBBancoCheque.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBBancoCheque.BackColor = System.Drawing.SystemColors.Control;
            this.tSBBancoCheque.DBContext = null;
            this.tSBBancoCheque.DisplayMember = "";
            this.tSBBancoCheque.KeyMember = "";
            this.tSBBancoCheque.LabelCampoBusqueda = "";
            this.tSBBancoCheque.Location = new System.Drawing.Point(94, 51);
            this.tSBBancoCheque.Name = "tSBBancoCheque";
            this.tSBBancoCheque.NombreCampoDescrip = "";
            this.tSBBancoCheque.NombreCampoID = "";
            this.tSBBancoCheque.Size = new System.Drawing.Size(340, 20);
            this.tSBBancoCheque.SoloLectura = false;
            this.tSBBancoCheque.TabIndex = 4;
            this.tSBBancoCheque.Text = "ucTextSearchBox";
            this.tSBBancoCheque.TituloBuscador = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Banco";
            // 
            // txtNroCheque
            // 
            this.txtNroCheque.Location = new System.Drawing.Point(94, 25);
            this.txtNroCheque.Name = "txtNroCheque";
            this.txtNroCheque.Size = new System.Drawing.Size(100, 20);
            this.txtNroCheque.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "N° Cheque";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtFechaDepositoHasta);
            this.groupBox2.Controls.Add(this.txtFechaDepositoDesde);
            this.groupBox2.Controls.Add(this.txtNroBoletaDeposito);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.dtpFechaDepositoDesde);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.dtpFechaDepositoHasta);
            this.groupBox2.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(18, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(451, 91);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Depósito";
            // 
            // txtFechaDepositoHasta
            // 
            this.txtFechaDepositoHasta.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.None;
            this.txtFechaDepositoHasta.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0);
            this.txtFechaDepositoHasta.Location = new System.Drawing.Point(299, 50);
            this.txtFechaDepositoHasta.Name = "txtFechaDepositoHasta";
            this.txtFechaDepositoHasta.Size = new System.Drawing.Size(81, 18);
            this.txtFechaDepositoHasta.TabIndex = 2;
            // 
            // txtFechaDepositoDesde
            // 
            this.txtFechaDepositoDesde.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.None;
            this.txtFechaDepositoDesde.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0);
            this.txtFechaDepositoDesde.Location = new System.Drawing.Point(99, 50);
            this.txtFechaDepositoDesde.Name = "txtFechaDepositoDesde";
            this.txtFechaDepositoDesde.Size = new System.Drawing.Size(81, 18);
            this.txtFechaDepositoDesde.TabIndex = 1;
            // 
            // txtNroBoletaDeposito
            // 
            this.txtNroBoletaDeposito.Location = new System.Drawing.Point(98, 25);
            this.txtNroBoletaDeposito.Name = "txtNroBoletaDeposito";
            this.txtNroBoletaDeposito.Size = new System.Drawing.Size(100, 20);
            this.txtNroBoletaDeposito.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "N° Boleta";
            // 
            // dtpFechaDepositoDesde
            // 
            this.dtpFechaDepositoDesde.CustomFormat = "dd/mm/yyyy";
            this.dtpFechaDepositoDesde.Location = new System.Drawing.Point(98, 49);
            this.dtpFechaDepositoDesde.Name = "dtpFechaDepositoDesde";
            this.dtpFechaDepositoDesde.Size = new System.Drawing.Size(100, 20);
            this.dtpFechaDepositoDesde.TabIndex = 3;
            this.dtpFechaDepositoDesde.TabStop = false;
            this.dtpFechaDepositoDesde.ValueChanged += new System.EventHandler(this.dtpFechaDepositoDesde_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Fecha Desde";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(215, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Fecha Hasta";
            // 
            // dtpFechaDepositoHasta
            // 
            this.dtpFechaDepositoHasta.CustomFormat = "dd/mm/yyyy";
            this.dtpFechaDepositoHasta.Location = new System.Drawing.Point(298, 49);
            this.dtpFechaDepositoHasta.Name = "dtpFechaDepositoHasta";
            this.dtpFechaDepositoHasta.Size = new System.Drawing.Size(100, 20);
            this.dtpFechaDepositoHasta.TabIndex = 3;
            this.dtpFechaDepositoHasta.TabStop = false;
            this.dtpFechaDepositoHasta.ValueChanged += new System.EventHandler(this.dtpFechaDepositoHasta_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtIDDocumento);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtFechaHasta);
            this.groupBox1.Controls.Add(this.txtFechaDesde);
            this.groupBox1.Controls.Add(this.tSBCliente);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpFechaHasta);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.dtpFechaDesde);
            this.groupBox1.Controls.Add(this.txtNroDocumento);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(480, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(451, 105);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Presupuestos";
            // 
            // txtIDDocumento
            // 
            this.txtIDDocumento.Location = new System.Drawing.Point(298, 25);
            this.txtIDDocumento.Name = "txtIDDocumento";
            this.txtIDDocumento.Size = new System.Drawing.Size(100, 20);
            this.txtIDDocumento.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(215, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "ID Documento";
            // 
            // txtFechaHasta
            // 
            this.txtFechaHasta.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.None;
            this.txtFechaHasta.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0);
            this.txtFechaHasta.Location = new System.Drawing.Point(299, 50);
            this.txtFechaHasta.Name = "txtFechaHasta";
            this.txtFechaHasta.Size = new System.Drawing.Size(81, 18);
            this.txtFechaHasta.TabIndex = 3;
            // 
            // txtFechaDesde
            // 
            this.txtFechaDesde.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.None;
            this.txtFechaDesde.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0);
            this.txtFechaDesde.Location = new System.Drawing.Point(94, 50);
            this.txtFechaDesde.Name = "txtFechaDesde";
            this.txtFechaDesde.Size = new System.Drawing.Size(81, 18);
            this.txtFechaDesde.TabIndex = 2;
            // 
            // tSBCliente
            // 
            this.tSBCliente.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBCliente.BackColor = System.Drawing.SystemColors.Control;
            this.tSBCliente.DBContext = null;
            this.tSBCliente.DisplayMember = "";
            this.tSBCliente.KeyMember = "";
            this.tSBCliente.LabelCampoBusqueda = "";
            this.tSBCliente.Location = new System.Drawing.Point(93, 74);
            this.tSBCliente.Name = "tSBCliente";
            this.tSBCliente.NombreCampoDescrip = "";
            this.tSBCliente.NombreCampoID = "";
            this.tSBCliente.Size = new System.Drawing.Size(340, 20);
            this.tSBCliente.SoloLectura = false;
            this.tSBCliente.TabIndex = 4;
            this.tSBCliente.Text = "ucTextSearchBox";
            this.tSBCliente.TituloBuscador = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "N° Documento";
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.CustomFormat = "dd/mm/yyyy";
            this.dtpFechaHasta.Location = new System.Drawing.Point(298, 49);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(100, 21);
            this.dtpFechaHasta.TabIndex = 3;
            this.dtpFechaHasta.TabStop = false;
            this.dtpFechaHasta.ValueChanged += new System.EventHandler(this.dtpFechaHasta_ValueChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(215, 53);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(67, 13);
            this.label18.TabIndex = 0;
            this.label18.Text = "Fecha Hasta";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(10, 53);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(69, 13);
            this.label21.TabIndex = 0;
            this.label21.Text = "Fecha Desde";
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.CustomFormat = "dd/mm/yyyy";
            this.dtpFechaDesde.Location = new System.Drawing.Point(93, 49);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(100, 21);
            this.dtpFechaDesde.TabIndex = 3;
            this.dtpFechaDesde.TabStop = false;
            this.dtpFechaDesde.ValueChanged += new System.EventHandler(this.dtpFechaDesde_ValueChanged);
            // 
            // txtNroDocumento
            // 
            this.txtNroDocumento.Location = new System.Drawing.Point(93, 25);
            this.txtNroDocumento.Name = "txtNroDocumento";
            this.txtNroDocumento.Size = new System.Drawing.Size(100, 20);
            this.txtNroDocumento.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cliente";
            // 
            // btnLimpiarFiltros
            // 
            this.btnLimpiarFiltros.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnLimpiarFiltros.Image"));
            this.btnLimpiarFiltros.Location = new System.Drawing.Point(948, 122);
            this.btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            this.btnLimpiarFiltros.Size = new System.Drawing.Size(40, 40);
            this.btnLimpiarFiltros.TabIndex = 6;
            this.toolTip1.SetToolTip(this.btnLimpiarFiltros, "Limpiar filtros");
            this.btnLimpiarFiltros.Click += new System.EventHandler(this.btnLimpiarFiltros_Click);
            // 
            // panel5
            // 
            this.panel5.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.lblEstado);
            this.panel5.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 188);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1004, 22);
            this.panel5.TabIndex = 1;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblEstado.ForeColor = System.Drawing.Color.Black;
            this.lblEstado.Location = new System.Drawing.Point(5, 3);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(35, 13);
            this.lblEstado.TabIndex = 0;
            this.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnFiltrar.Image"));
            this.btnFiltrar.Location = new System.Drawing.Point(948, 38);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(40, 40);
            this.btnFiltrar.TabIndex = 5;
            this.toolTip1.SetToolTip(this.btnFiltrar, "Aplicar filtros");
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // btnMarcarTodo
            // 
            this.btnMarcarTodo.CustomStyle = "F";
            this.btnMarcarTodo.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnMarcarTodo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnMarcarTodo.ForeColor = System.Drawing.Color.White;
            this.btnMarcarTodo.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnMarcarTodo.Image"));
            this.btnMarcarTodo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMarcarTodo.ImageSize = new System.Drawing.Size(32, 32);
            this.btnMarcarTodo.Location = new System.Drawing.Point(18, 2);
            this.btnMarcarTodo.Name = "btnMarcarTodo";
            this.btnMarcarTodo.Size = new System.Drawing.Size(125, 36);
            this.btnMarcarTodo.TabIndex = 20;
            this.btnMarcarTodo.Text = "&Marcar Todo";
            this.btnMarcarTodo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMarcarTodo.Click += new System.EventHandler(this.btnMarcarTodo_Click);
            // 
            // FSelecPresupFactura
            // 
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(1004, 504);
            this.Text = "FSeleccionarPresupuestoNC";
            this.Load += new System.EventHandler(this.FSeleccionarPresupuestoNC_Load);
            this.VisibleChanged += new System.EventHandler(this.FSeleccionarPresupuestoNC_VisibleChanged);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPresupuestos)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Panel panel4;
        private Panel panel3;
        private Panel panel2;
        private Panel panel6;
        private Button btnAceptar;
        private Button btnCancelar;
        private Label label1;
        private TextBox txtFechaHasta;
        private TextBox txtFechaDesde;
        private DateTimePicker dtpFechaDesde;
        private Label label21;
        private Label label18;
        private DateTimePicker dtpFechaHasta;
        private Button btnFiltrar;
        private DataGridView dgvPresupuestos;
        private Panel panel5;
        private Label lblEstado;
        private UserControls.Base.ucTextSearchBox tSBCliente;
        private TextBox txtNroDocumento;
        private Label label2;
        private Button btnLimpiarFiltros;
        private ToolTip toolTip1;
        private GroupBox groupBox2;
        private TextBox txtFechaDepositoHasta;
        private TextBox txtFechaDepositoDesde;
        private TextBox txtNroBoletaDeposito;
        private Label label3;
        private DateTimePicker dtpFechaDepositoDesde;
        private Label label4;
        private Label label5;
        private DateTimePicker dtpFechaDepositoHasta;
        private GroupBox groupBox1;
        private TextBox txtIDDocumento;
        private Label label6;
        private GroupBox groupBox3;
        private TextBox txtNroCheque;
        private Label label7;
        private UserControls.Base.ucTextSearchBox tSBBancoCheque;
        private Label label8;
        private GroupBox groupBox4;
        private TextBox txtFechaCobroHasta;
        private TextBox txtFechaCobroDesde;
        private DateTimePicker dtpFechaCobroDesde;
        private Label label10;
        private Label label11;
        private DateTimePicker dtpFechaCobroHasta;
        private Button btnMarcarTodo;


    }
}