using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.Forms.UI
{
    partial class FCargarDatosRecaudacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCargarDatosRecaudacion));
            this.btnAceptar = new Gizmox.WebGUI.Forms.Button();
            this.btnCancelar = new Gizmox.WebGUI.Forms.Button();
            this.panel3 = new Gizmox.WebGUI.Forms.Panel();
            this.tSBCuentaDeposito = new SPF.UserControls.Base.ucTextSearchBox();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.groupBox2 = new Gizmox.WebGUI.Forms.GroupBox();
            this.txtMoneda = new Gizmox.WebGUI.Forms.TextBox();
            this.label7 = new Gizmox.WebGUI.Forms.Label();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.txtTotalRecibo = new Gizmox.WebGUI.Forms.TextBox();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.txtMontoDepositable = new Gizmox.WebGUI.Forms.TextBox();
            this.txtCliente = new Gizmox.WebGUI.Forms.TextBox();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.txtFechaRecibo = new Gizmox.WebGUI.Forms.TextBox();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.txtNroRecibo = new Gizmox.WebGUI.Forms.TextBox();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.groupBox1 = new Gizmox.WebGUI.Forms.GroupBox();
            this.txtCtaBancariaId = new Gizmox.WebGUI.Forms.TextBox();
            this.txtUsuarioId = new Gizmox.WebGUI.Forms.TextBox();
            this.txtUsuarioNombre = new Gizmox.WebGUI.Forms.TextBox();
            this.label10 = new Gizmox.WebGUI.Forms.Label();
            this.label9 = new Gizmox.WebGUI.Forms.Label();
            this.txtMontoDeposito = new Gizmox.WebGUI.Forms.TextBox();
            this.label8 = new Gizmox.WebGUI.Forms.Label();
            this.txtCuentaDescripcion = new Gizmox.WebGUI.Forms.TextBox();
            this.txtNroCuenta = new Gizmox.WebGUI.Forms.TextBox();
            this.txtNroBoletaDeposito = new Gizmox.WebGUI.Forms.TextBox();
            this.dtpFechaDeposito = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.lblGastosBancarios = new Gizmox.WebGUI.Forms.Label();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.toolTip1 = new Gizmox.WebGUI.Forms.ToolTip();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.btnAceptar.Location = new System.Drawing.Point(375, 6);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(94, 36);
            this.btnAceptar.TabIndex = 4;
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
            this.btnCancelar.Location = new System.Drawing.Point(474, 6);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(94, 36);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel3.Controls.Add(this.btnAceptar);
            this.panel3.Controls.Add(this.btnCancelar);
            this.panel3.Controls.Add(this.tSBCuentaDeposito);
            this.panel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 230);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(590, 47);
            this.panel3.TabIndex = 1;
            // 
            // tSBCuentaDeposito
            // 
            this.tSBCuentaDeposito.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBCuentaDeposito.DBContext = null;
            this.tSBCuentaDeposito.DisplayMember = "";
            this.tSBCuentaDeposito.KeyMember = "";
            this.tSBCuentaDeposito.LabelCampoBusqueda = "";
            this.tSBCuentaDeposito.Location = new System.Drawing.Point(20, 18);
            this.tSBCuentaDeposito.Name = "tSBCuentaDeposito";
            this.tSBCuentaDeposito.NombreCampoDescrip = "";
            this.tSBCuentaDeposito.NombreCampoID = "";
            this.tSBCuentaDeposito.Size = new System.Drawing.Size(298, 20);
            this.tSBCuentaDeposito.SoloLectura = false;
            this.tSBCuentaDeposito.TabIndex = 2;
            this.tSBCuentaDeposito.TabStop = false;
            this.tSBCuentaDeposito.Text = "ucTextSearchBox";
            this.tSBCuentaDeposito.TituloBuscador = "";
            this.tSBCuentaDeposito.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(590, 97);
            this.panel2.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtMoneda);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtTotalRecibo);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtMontoDepositable);
            this.groupBox2.Controls.Add(this.txtCliente);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtFechaRecibo);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtNroRecibo);
            this.groupBox2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.groupBox2.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(590, 97);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos del Recibo";
            // 
            // txtMoneda
            // 
            this.txtMoneda.BackColor = System.Drawing.SystemColors.Control;
            this.txtMoneda.Location = new System.Drawing.Point(440, 17);
            this.txtMoneda.Name = "txtMoneda";
            this.txtMoneda.ReadOnly = true;
            this.txtMoneda.Size = new System.Drawing.Size(88, 20);
            this.txtMoneda.TabIndex = 1;
            this.txtMoneda.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(335, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Moneda";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(335, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Total Recibo";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTotalRecibo
            // 
            this.txtTotalRecibo.BackColor = System.Drawing.SystemColors.Control;
            this.txtTotalRecibo.Location = new System.Drawing.Point(440, 43);
            this.txtTotalRecibo.Name = "txtTotalRecibo";
            this.txtTotalRecibo.ReadOnly = true;
            this.txtTotalRecibo.Size = new System.Drawing.Size(128, 20);
            this.txtTotalRecibo.TabIndex = 1;
            this.txtTotalRecibo.TabStop = false;
            this.txtTotalRecibo.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(335, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Monto Depositable";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMontoDepositable
            // 
            this.txtMontoDepositable.BackColor = System.Drawing.SystemColors.Control;
            this.txtMontoDepositable.Location = new System.Drawing.Point(440, 68);
            this.txtMontoDepositable.Name = "txtMontoDepositable";
            this.txtMontoDepositable.ReadOnly = true;
            this.txtMontoDepositable.Size = new System.Drawing.Size(128, 20);
            this.txtMontoDepositable.TabIndex = 1;
            this.txtMontoDepositable.TabStop = false;
            this.txtMontoDepositable.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // txtCliente
            // 
            this.txtCliente.BackColor = System.Drawing.SystemColors.Control;
            this.txtCliente.Location = new System.Drawing.Point(76, 68);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(241, 20);
            this.txtCliente.TabIndex = 1;
            this.txtCliente.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Cliente";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFechaRecibo
            // 
            this.txtFechaRecibo.BackColor = System.Drawing.SystemColors.Control;
            this.txtFechaRecibo.Location = new System.Drawing.Point(76, 43);
            this.txtFechaRecibo.Name = "txtFechaRecibo";
            this.txtFechaRecibo.ReadOnly = true;
            this.txtFechaRecibo.Size = new System.Drawing.Size(88, 20);
            this.txtFechaRecibo.TabIndex = 1;
            this.txtFechaRecibo.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Fecha";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Número";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNroRecibo
            // 
            this.txtNroRecibo.BackColor = System.Drawing.SystemColors.Control;
            this.txtNroRecibo.Location = new System.Drawing.Point(76, 17);
            this.txtNroRecibo.Name = "txtNroRecibo";
            this.txtNroRecibo.ReadOnly = true;
            this.txtNroRecibo.Size = new System.Drawing.Size(169, 20);
            this.txtNroRecibo.TabIndex = 1;
            this.txtNroRecibo.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 97);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(590, 133);
            this.panel1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCtaBancariaId);
            this.groupBox1.Controls.Add(this.txtUsuarioId);
            this.groupBox1.Controls.Add(this.txtUsuarioNombre);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtMontoDeposito);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtCuentaDescripcion);
            this.groupBox1.Controls.Add(this.txtNroCuenta);
            this.groupBox1.Controls.Add(this.txtNroBoletaDeposito);
            this.groupBox1.Controls.Add(this.dtpFechaDeposito);
            this.groupBox1.Controls.Add(this.lblGastosBancarios);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.groupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(590, 133);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del Depósito";
            // 
            // txtCtaBancariaId
            // 
            this.txtCtaBancariaId.BackColor = System.Drawing.SystemColors.Control;
            this.txtCtaBancariaId.Location = new System.Drawing.Point(375, 107);
            this.txtCtaBancariaId.Name = "txtCtaBancariaId";
            this.txtCtaBancariaId.ReadOnly = true;
            this.txtCtaBancariaId.Size = new System.Drawing.Size(67, 20);
            this.txtCtaBancariaId.TabIndex = 2;
            this.txtCtaBancariaId.TabStop = false;
            this.txtCtaBancariaId.Visible = false;
            // 
            // txtUsuarioId
            // 
            this.txtUsuarioId.BackColor = System.Drawing.SystemColors.Control;
            this.txtUsuarioId.Location = new System.Drawing.Point(461, 107);
            this.txtUsuarioId.Name = "txtUsuarioId";
            this.txtUsuarioId.ReadOnly = true;
            this.txtUsuarioId.Size = new System.Drawing.Size(67, 20);
            this.txtUsuarioId.TabIndex = 2;
            this.txtUsuarioId.TabStop = false;
            this.txtUsuarioId.Visible = false;
            // 
            // txtUsuarioNombre
            // 
            this.txtUsuarioNombre.BackColor = System.Drawing.SystemColors.Control;
            this.txtUsuarioNombre.Location = new System.Drawing.Point(322, 82);
            this.txtUsuarioNombre.Name = "txtUsuarioNombre";
            this.txtUsuarioNombre.ReadOnly = true;
            this.txtUsuarioNombre.Size = new System.Drawing.Size(206, 20);
            this.txtUsuarioNombre.TabIndex = 2;
            this.txtUsuarioNombre.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(277, 86);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Usuario";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(51, 86);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Monto Depósito";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMontoDeposito
            // 
            this.txtMontoDeposito.BackColor = System.Drawing.SystemColors.Control;
            this.txtMontoDeposito.Location = new System.Drawing.Point(134, 82);
            this.txtMontoDeposito.Name = "txtMontoDeposito";
            this.txtMontoDeposito.ReadOnly = true;
            this.txtMontoDeposito.Size = new System.Drawing.Size(131, 20);
            this.txtMontoDeposito.TabIndex = 3;
            this.txtMontoDeposito.TabStop = false;
            this.txtMontoDeposito.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.txtMontoDeposito.Enter += new System.EventHandler(this.txtMontoDeposito_Enter);
            this.txtMontoDeposito.Leave += new System.EventHandler(this.txtMontoDeposito_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(51, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Cuenta";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCuentaDescripcion
            // 
            this.txtCuentaDescripcion.BackColor = System.Drawing.SystemColors.Control;
            this.txtCuentaDescripcion.Location = new System.Drawing.Point(134, 56);
            this.txtCuentaDescripcion.Name = "txtCuentaDescripcion";
            this.txtCuentaDescripcion.ReadOnly = true;
            this.txtCuentaDescripcion.Size = new System.Drawing.Size(267, 20);
            this.txtCuentaDescripcion.TabIndex = 2;
            this.txtCuentaDescripcion.Enter += new System.EventHandler(this.txtCuentaDescripcion_Enter);
            // 
            // txtNroCuenta
            // 
            this.txtNroCuenta.BackColor = System.Drawing.SystemColors.Control;
            this.txtNroCuenta.Location = new System.Drawing.Point(402, 56);
            this.txtNroCuenta.Name = "txtNroCuenta";
            this.txtNroCuenta.ReadOnly = true;
            this.txtNroCuenta.Size = new System.Drawing.Size(127, 20);
            this.txtNroCuenta.TabIndex = 3;
            this.txtNroCuenta.TabStop = false;
            // 
            // txtNroBoletaDeposito
            // 
            this.txtNroBoletaDeposito.Location = new System.Drawing.Point(360, 30);
            this.txtNroBoletaDeposito.Name = "txtNroBoletaDeposito";
            this.txtNroBoletaDeposito.Size = new System.Drawing.Size(169, 20);
            this.txtNroBoletaDeposito.TabIndex = 1;
            // 
            // dtpFechaDeposito
            // 
            this.dtpFechaDeposito.CustomFormat = "";
            this.dtpFechaDeposito.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDeposito.Location = new System.Drawing.Point(134, 30);
            this.dtpFechaDeposito.Name = "dtpFechaDeposito";
            this.dtpFechaDeposito.Size = new System.Drawing.Size(90, 21);
            this.dtpFechaDeposito.TabIndex = 0;
            // 
            // lblGastosBancarios
            // 
            this.lblGastosBancarios.AutoSize = true;
            this.lblGastosBancarios.Location = new System.Drawing.Point(277, 34);
            this.lblGastosBancarios.Name = "lblGastosBancarios";
            this.lblGastosBancarios.Size = new System.Drawing.Size(116, 13);
            this.lblGastosBancarios.TabIndex = 0;
            this.lblGastosBancarios.Text = "N° Boleta Dep.";
            this.lblGastosBancarios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha Depósito";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FCargarDatosRecaudacion
            // 
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Size = new System.Drawing.Size(590, 277);
            this.Text = "FReservarNroPresup";
            this.Load += new System.EventHandler(this.FCargarTransferenciaRecibo_Load);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnAceptar;
        private Button btnCancelar;
        private Panel panel3;
        private Panel panel2;
        private Panel panel1;
        private GroupBox groupBox1;
        private TextBox txtNroBoletaDeposito;
        private DateTimePicker dtpFechaDeposito;
        private Label lblGastosBancarios;
        private Label label1;
        private GroupBox groupBox2;
        private TextBox txtMoneda;
        private Label label7;
        private Label label6;
        private TextBox txtTotalRecibo;
        private Label label5;
        private TextBox txtMontoDepositable;
        private TextBox txtCliente;
        private Label label4;
        private TextBox txtFechaRecibo;
        private Label label3;
        private Label label2;
        private TextBox txtNroRecibo;
        private ToolTip toolTip1;
        private UserControls.Base.ucTextSearchBox tSBCuentaDeposito;
        private Label label8;
        private TextBox txtCuentaDescripcion;
        private TextBox txtNroCuenta;
        private Label label9;
        private TextBox txtMontoDeposito;
        private TextBox txtUsuarioNombre;
        private Label label10;
        private TextBox txtUsuarioId;
        private TextBox txtCtaBancariaId;


    }
}