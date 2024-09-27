using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.Forms.UI
{
    partial class FCargarChequeRecibo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCargarChequeRecibo));
            this.btnAceptar = new Gizmox.WebGUI.Forms.Button();
            this.btnCancelar = new Gizmox.WebGUI.Forms.Button();
            this.panel3 = new Gizmox.WebGUI.Forms.Panel();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.tSBBancoCheque = new SPF.UserControls.Base.ucTextSearchBox();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.txtCuentaId = new Gizmox.WebGUI.Forms.TextBox();
            this.txtAbrevMonedaMonto = new Gizmox.WebGUI.Forms.TextBox();
            this.txtNroCuenta = new Gizmox.WebGUI.Forms.TextBox();
            this.txtBancoDescripcion = new Gizmox.WebGUI.Forms.TextBox();
            this.chkMostrarTodasLasCuentas = new Gizmox.WebGUI.Forms.CheckBox();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.lblGastosBancarios = new Gizmox.WebGUI.Forms.Label();
            this.dtpFechaCheque = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.txtNumeroCheque = new Gizmox.WebGUI.Forms.TextBox();
            this.txtMontoCheque = new Gizmox.WebGUI.Forms.TextBox();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.btnAceptar.Location = new System.Drawing.Point(170, 5);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(94, 36);
            this.btnAceptar.TabIndex = 6;
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
            this.btnCancelar.Location = new System.Drawing.Point(283, 5);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(94, 36);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel3.Controls.Add(this.btnAceptar);
            this.panel3.Controls.Add(this.btnCancelar);
            this.panel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 198);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(557, 47);
            this.panel3.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel2.Controls.Add(this.tSBBancoCheque);
            this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(557, 46);
            this.panel2.TabIndex = 0;
            // 
            // tSBBancoCheque
            // 
            this.tSBBancoCheque.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBBancoCheque.DBContext = null;
            this.tSBBancoCheque.DisplayMember = "";
            this.tSBBancoCheque.KeyMember = "";
            this.tSBBancoCheque.LabelCampoBusqueda = "";
            this.tSBBancoCheque.Location = new System.Drawing.Point(99, 9);
            this.tSBBancoCheque.Name = "tSBBancoCheque";
            this.tSBBancoCheque.NombreCampoDescrip = "";
            this.tSBBancoCheque.NombreCampoID = "";
            this.tSBBancoCheque.Size = new System.Drawing.Size(298, 20);
            this.tSBBancoCheque.SoloLectura = false;
            this.tSBBancoCheque.TabIndex = 2;
            this.tSBBancoCheque.TabStop = false;
            this.tSBBancoCheque.Text = "ucTextSearchBox";
            this.tSBBancoCheque.TituloBuscador = "";
            this.tSBBancoCheque.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtCuentaId);
            this.panel1.Controls.Add(this.txtAbrevMonedaMonto);
            this.panel1.Controls.Add(this.txtNroCuenta);
            this.panel1.Controls.Add(this.txtBancoDescripcion);
            this.panel1.Controls.Add(this.chkMostrarTodasLasCuentas);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblGastosBancarios);
            this.panel1.Controls.Add(this.dtpFechaCheque);
            this.panel1.Controls.Add(this.txtNumeroCheque);
            this.panel1.Controls.Add(this.txtMontoCheque);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(557, 152);
            this.panel1.TabIndex = 2;
            // 
            // txtCuentaId
            // 
            this.txtCuentaId.BackColor = System.Drawing.SystemColors.Control;
            this.txtCuentaId.Location = new System.Drawing.Point(272, 25);
            this.txtCuentaId.Name = "txtCuentaId";
            this.txtCuentaId.ReadOnly = true;
            this.txtCuentaId.Size = new System.Drawing.Size(42, 20);
            this.txtCuentaId.TabIndex = 3;
            this.txtCuentaId.Visible = false;
            // 
            // txtAbrevMonedaMonto
            // 
            this.txtAbrevMonedaMonto.BackColor = System.Drawing.SystemColors.Control;
            this.txtAbrevMonedaMonto.Location = new System.Drawing.Point(132, 101);
            this.txtAbrevMonedaMonto.Name = "txtAbrevMonedaMonto";
            this.txtAbrevMonedaMonto.ReadOnly = true;
            this.txtAbrevMonedaMonto.Size = new System.Drawing.Size(42, 20);
            this.txtAbrevMonedaMonto.TabIndex = 3;
            this.txtAbrevMonedaMonto.TabStop = false;
            // 
            // txtNroCuenta
            // 
            this.txtNroCuenta.BackColor = System.Drawing.SystemColors.Control;
            this.txtNroCuenta.Location = new System.Drawing.Point(398, 49);
            this.txtNroCuenta.Name = "txtNroCuenta";
            this.txtNroCuenta.ReadOnly = true;
            this.txtNroCuenta.Size = new System.Drawing.Size(127, 20);
            this.txtNroCuenta.TabIndex = 3;
            this.txtNroCuenta.TabStop = false;
            this.txtNroCuenta.Visible = false;
            // 
            // txtBancoDescripcion
            // 
            this.txtBancoDescripcion.BackColor = System.Drawing.SystemColors.Control;
            this.txtBancoDescripcion.Location = new System.Drawing.Point(130, 49);
            this.txtBancoDescripcion.Name = "txtBancoDescripcion";
            this.txtBancoDescripcion.ReadOnly = true;
            this.txtBancoDescripcion.Size = new System.Drawing.Size(267, 20);
            this.txtBancoDescripcion.TabIndex = 2;
            this.txtBancoDescripcion.Enter += new System.EventHandler(this.txtCuentaDescripcion_Enter);
            // 
            // chkMostrarTodasLasCuentas
            // 
            this.chkMostrarTodasLasCuentas.AutoSize = true;
            this.chkMostrarTodasLasCuentas.Location = new System.Drawing.Point(338, 25);
            this.chkMostrarTodasLasCuentas.Name = "chkMostrarTodasLasCuentas";
            this.chkMostrarTodasLasCuentas.Size = new System.Drawing.Size(150, 17);
            this.chkMostrarTodasLasCuentas.TabIndex = 1;
            this.chkMostrarTodasLasCuentas.Text = "Mostrar todas las cuentas";
            this.chkMostrarTodasLasCuentas.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Monto";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Cuenta";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGastosBancarios
            // 
            this.lblGastosBancarios.AutoSize = true;
            this.lblGastosBancarios.Location = new System.Drawing.Point(26, 78);
            this.lblGastosBancarios.Name = "lblGastosBancarios";
            this.lblGastosBancarios.Size = new System.Drawing.Size(116, 13);
            this.lblGastosBancarios.TabIndex = 0;
            this.lblGastosBancarios.Text = "Número";
            this.lblGastosBancarios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpFechaCheque
            // 
            this.dtpFechaCheque.CustomFormat = "";
            this.dtpFechaCheque.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Short;
            this.dtpFechaCheque.Location = new System.Drawing.Point(130, 21);
            this.dtpFechaCheque.Name = "dtpFechaCheque";
            this.dtpFechaCheque.Size = new System.Drawing.Size(90, 21);
            this.dtpFechaCheque.TabIndex = 0;
            // 
            // txtNumeroCheque
            // 
            this.txtNumeroCheque.Location = new System.Drawing.Point(130, 74);
            this.txtNumeroCheque.Name = "txtNumeroCheque";
            this.txtNumeroCheque.Size = new System.Drawing.Size(169, 20);
            this.txtNumeroCheque.TabIndex = 3;
            // 
            // txtMontoCheque
            // 
            this.txtMontoCheque.Location = new System.Drawing.Point(175, 101);
            this.txtMontoCheque.Name = "txtMontoCheque";
            this.txtMontoCheque.Size = new System.Drawing.Size(124, 20);
            this.txtMontoCheque.TabIndex = 5;
            this.txtMontoCheque.Text = "0,00";
            this.txtMontoCheque.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.txtMontoCheque.Enter += new System.EventHandler(this.txtMontoTransferencia_Enter);
            this.txtMontoCheque.Leave += new System.EventHandler(this.txtMontoCheque_Leave);
            // 
            // FCargarChequeRecibo
            // 
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Size = new System.Drawing.Size(557, 245);
            this.Text = "FReservarNroPresup";
            this.Load += new System.EventHandler(this.FCargarTransferenciaRecibo_Load);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnAceptar;
        private Button btnCancelar;
        private Panel panel3;
        private Panel panel2;
        private Panel panel1;
        private UserControls.Base.ucTextSearchBox tSBBancoCheque;
        private DateTimePicker dtpFechaCheque;
        private TextBox txtNumeroCheque;
        private TextBox txtMontoCheque;
        private Label label4;
        private Label label2;
        private Label label1;
        private Label lblGastosBancarios;
        private CheckBox chkMostrarTodasLasCuentas;
        private TextBox txtAbrevMonedaMonto;
        private TextBox txtNroCuenta;
        private TextBox txtBancoDescripcion;
        private TextBox txtCuentaId;


    }
}