using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.UserControls.UI
{
    partial class ucCRUDCuentasBancos
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
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.tSBBanco = new SPF.UserControls.Base.ucTextSearchBox();
            this.tSBMoneda = new SPF.UserControls.Base.ucTextSearchBox();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.txtCuentaBancoID = new Gizmox.WebGUI.Forms.TextBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.txtCuentaBancoDescrip = new Gizmox.WebGUI.Forms.TextBox();
            this.txtNroCuenta = new Gizmox.WebGUI.Forms.TextBox();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.cbEsCuentaPago = new Gizmox.WebGUI.Forms.CheckBox();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.txtSello = new Gizmox.WebGUI.Forms.TextBox();
            this.colorDialog1 = new Gizmox.WebGUI.Forms.ColorDialog();
            this.btnColorDeFondo = new Gizmox.WebGUI.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoABM)).BeginInit();
            this.pnlDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabListaABM)).BeginInit();
            this.pnlListadoContainer.SuspendLayout();
            this.pnlContainer.SuspendLayout();
            this.pnlTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvListadoABM
            // 
            this.dgvListadoABM.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.dgvListadoABM.Size = new System.Drawing.Size(1123, 358);
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
            this.pnlDetalle.Controls.Add(this.btnColorDeFondo);
            this.pnlDetalle.Controls.Add(this.txtSello);
            this.pnlDetalle.Controls.Add(this.label3);
            this.pnlDetalle.Controls.Add(this.cbEsCuentaPago);
            this.pnlDetalle.Controls.Add(this.label2);
            this.pnlDetalle.Controls.Add(this.txtNroCuenta);
            this.pnlDetalle.Controls.Add(this.txtCuentaBancoDescrip);
            this.pnlDetalle.Controls.Add(this.label1);
            this.pnlDetalle.Controls.Add(this.txtCuentaBancoID);
            this.pnlDetalle.Controls.Add(this.label4);
            this.pnlDetalle.Controls.Add(this.tSBMoneda);
            this.pnlDetalle.Controls.Add(this.tSBBanco);
            this.pnlDetalle.Controls.Add(this.label5);
            this.pnlDetalle.Size = new System.Drawing.Size(1143, 378);
            // 
            // tBBaseForm
            // 
            this.tBBaseForm.Size = new System.Drawing.Size(1151, 42);
            // 
            // tbbNuevo
            // 
            this.tbbNuevo.Click += new System.EventHandler(this.tbbNuevo_Click);
            // 
            // tabListaABM
            // 
            this.tabListaABM.Alignment = Gizmox.WebGUI.Forms.TabAlignment.Top;
            this.tabListaABM.Size = new System.Drawing.Size(1151, 407);
            this.pnlListadoContainer.Controls.SetChildIndex(this.dgvListadoABM, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(99, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Banco";
            // 
            // tSBBanco
            // 
            this.tSBBanco.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBBanco.BackColor = System.Drawing.Color.Transparent;
            this.tSBBanco.DBContext = null;
            this.tSBBanco.DisplayMember = "";
            this.tSBBanco.KeyMember = "";
            this.tSBBanco.LabelCampoBusqueda = "";
            this.tSBBanco.Location = new System.Drawing.Point(173, 53);
            this.tSBBanco.Name = "tSBBanco";
            this.tSBBanco.NombreCampoDescrip = "";
            this.tSBBanco.NombreCampoID = "";
            this.tSBBanco.Size = new System.Drawing.Size(469, 20);
            this.tSBBanco.SoloLectura = false;
            this.tSBBanco.TabIndex = 1;
            this.tSBBanco.Text = "ucTextSearchBox";
            this.tSBBanco.TituloBuscador = "";
            // 
            // tSBMoneda
            // 
            this.tSBMoneda.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBMoneda.BackColor = System.Drawing.Color.Transparent;
            this.tSBMoneda.DBContext = null;
            this.tSBMoneda.DisplayMember = "";
            this.tSBMoneda.KeyMember = "";
            this.tSBMoneda.LabelCampoBusqueda = "";
            this.tSBMoneda.Location = new System.Drawing.Point(173, 89);
            this.tSBMoneda.Name = "tSBMoneda";
            this.tSBMoneda.NombreCampoDescrip = "";
            this.tSBMoneda.NombreCampoID = "";
            this.tSBMoneda.Size = new System.Drawing.Size(469, 20);
            this.tSBMoneda.SoloLectura = false;
            this.tSBMoneda.TabIndex = 2;
            this.tSBMoneda.Text = "ucTextSearchBox";
            this.tSBMoneda.TituloBuscador = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(99, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Moneda";
            // 
            // txtCuentaBancoID
            // 
            this.txtCuentaBancoID.BackColor = System.Drawing.SystemColors.Control;
            this.txtCuentaBancoID.Location = new System.Drawing.Point(173, 15);
            this.txtCuentaBancoID.Name = "txtCuentaBancoID";
            this.txtCuentaBancoID.ReadOnly = true;
            this.txtCuentaBancoID.Size = new System.Drawing.Size(70, 20);
            this.txtCuentaBancoID.TabIndex = 1;
            this.txtCuentaBancoID.TabStop = false;
            this.txtCuentaBancoID.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(99, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cuenta";
            // 
            // txtCuentaBancoDescrip
            // 
            this.txtCuentaBancoDescrip.Location = new System.Drawing.Point(245, 15);
            this.txtCuentaBancoDescrip.Name = "txtCuentaBancoDescrip";
            this.txtCuentaBancoDescrip.Size = new System.Drawing.Size(360, 20);
            this.txtCuentaBancoDescrip.TabIndex = 0;
            // 
            // txtNroCuenta
            // 
            this.txtNroCuenta.Location = new System.Drawing.Point(173, 124);
            this.txtNroCuenta.Name = "txtNroCuenta";
            this.txtNroCuenta.Size = new System.Drawing.Size(346, 20);
            this.txtNroCuenta.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(99, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "N° Cuenta";
            // 
            // cbEsCuentaPago
            // 
            this.cbEsCuentaPago.AutoSize = true;
            this.cbEsCuentaPago.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbEsCuentaPago.Location = new System.Drawing.Point(522, 126);
            this.cbEsCuentaPago.Name = "cbEsCuentaPago";
            this.cbEsCuentaPago.Size = new System.Drawing.Size(88, 17);
            this.cbEsCuentaPago.TabIndex = 4;
            this.cbEsCuentaPago.Text = "Cuenta Pago";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(99, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Sello";
            // 
            // txtSello
            // 
            this.txtSello.AcceptsTab = true;
            this.txtSello.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.txtSello.Location = new System.Drawing.Point(173, 160);
            this.txtSello.Multiline = true;
            this.txtSello.Name = "txtSello";
            this.txtSello.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.txtSello.Size = new System.Drawing.Size(432, 158);
            this.txtSello.TabIndex = 5;
            this.txtSello.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Center;
            // 
            // btnColorDeFondo
            // 
            this.btnColorDeFondo.Location = new System.Drawing.Point(173, 321);
            this.btnColorDeFondo.Name = "btnColorDeFondo";
            this.btnColorDeFondo.Size = new System.Drawing.Size(163, 23);
            this.btnColorDeFondo.TabIndex = 6;
            this.btnColorDeFondo.Text = "Seleccionar Color de Fondo";
            this.btnColorDeFondo.Click += new System.EventHandler(this.btnColorDeFondo_Click);
            // 
            // ucCRUDCuentasBancos
            // 
            this.Size = new System.Drawing.Size(1153, 485);
            this.Text = "ucCRUDCuentasBancos";
            this.VisibleChanged += new System.EventHandler(this.ucCRUDCuentasBancos_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoABM)).EndInit();
            this.pnlDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabListaABM)).EndInit();
            this.pnlListadoContainer.ResumeLayout(false);
            this.pnlContainer.ResumeLayout(false);
            this.pnlTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Label label4;
        private Base.ucTextSearchBox tSBMoneda;
        private Base.ucTextSearchBox tSBBanco;
        private Label label5;
        private TextBox txtCuentaBancoDescrip;
        private Label label1;
        private TextBox txtCuentaBancoID;
        private Label label2;
        private TextBox txtNroCuenta;
        private CheckBox cbEsCuentaPago;
        private Button btnColorDeFondo;
        private TextBox txtSello;
        private Label label3;
        private ColorDialog colorDialog1;


    }
}