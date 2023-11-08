using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.Forms.UI
{
    partial class FCuentaPorClienteContinente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCuentaPorClienteContinente));
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.btnAceptar = new Gizmox.WebGUI.Forms.Button();
            this.btnCancelar = new Gizmox.WebGUI.Forms.Button();
            this.panel3 = new Gizmox.WebGUI.Forms.Panel();
            this.txtCampoID = new Gizmox.WebGUI.Forms.TextBox();
            this.lblCampo = new Gizmox.WebGUI.Forms.Label();
            this.txtDescripcionCampo = new Gizmox.WebGUI.Forms.TextBox();
            this.tSBCuenta = new SPF.UserControls.Base.ucTextSearchBox();
            this.label8 = new Gizmox.WebGUI.Forms.Label();
            this.tSBMoneda = new SPF.UserControls.Base.ucTextSearchBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.txtBancoNombre = new Gizmox.WebGUI.Forms.TextBox();
            this.txtBancoID = new Gizmox.WebGUI.Forms.TextBox();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.txtID = new Gizmox.WebGUI.Forms.TextBox();
            this.txtNroCuenta = new Gizmox.WebGUI.Forms.TextBox();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(667, 46);
            this.panel2.TabIndex = 0;
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
            this.btnAceptar.Location = new System.Drawing.Point(469, 5);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(90, 36);
            this.btnAceptar.TabIndex = 7;
            this.btnAceptar.Text = "&Guardar";
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
            this.btnCancelar.Location = new System.Drawing.Point(566, 5);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(78, 36);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "&Salir";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel3.Controls.Add(this.btnAceptar);
            this.panel3.Controls.Add(this.btnCancelar);
            this.panel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 273);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(667, 47);
            this.panel3.TabIndex = 1;
            // 
            // txtCampoID
            // 
            this.txtCampoID.BackColor = System.Drawing.SystemColors.Control;
            this.txtCampoID.Location = new System.Drawing.Point(177, 102);
            this.txtCampoID.Name = "txtCampoID";
            this.txtCampoID.ReadOnly = true;
            this.txtCampoID.Size = new System.Drawing.Size(70, 20);
            this.txtCampoID.TabIndex = 0;
            this.txtCampoID.TabStop = false;
            // 
            // lblCampo
            // 
            this.lblCampo.AutoSize = true;
            this.lblCampo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblCampo.Location = new System.Drawing.Point(107, 105);
            this.lblCampo.Name = "lblCampo";
            this.lblCampo.Size = new System.Drawing.Size(35, 13);
            this.lblCampo.TabIndex = 0;
            this.lblCampo.Text = "Campo";
            // 
            // txtDescripcionCampo
            // 
            this.txtDescripcionCampo.BackColor = System.Drawing.SystemColors.Control;
            this.txtDescripcionCampo.Location = new System.Drawing.Point(249, 102);
            this.txtDescripcionCampo.Name = "txtDescripcionCampo";
            this.txtDescripcionCampo.ReadOnly = true;
            this.txtDescripcionCampo.Size = new System.Drawing.Size(310, 20);
            this.txtDescripcionCampo.TabIndex = 1;
            this.txtDescripcionCampo.TabStop = false;
            // 
            // tSBCuenta
            // 
            this.tSBCuenta.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBCuenta.BackColor = System.Drawing.Color.Transparent;
            this.tSBCuenta.DBContext = null;
            this.tSBCuenta.DisplayMember = "";
            this.tSBCuenta.KeyMember = "";
            this.tSBCuenta.LabelCampoBusqueda = "";
            this.tSBCuenta.Location = new System.Drawing.Point(177, 161);
            this.tSBCuenta.Name = "tSBCuenta";
            this.tSBCuenta.NombreCampoDescrip = "";
            this.tSBCuenta.NombreCampoID = "";
            this.tSBCuenta.Size = new System.Drawing.Size(382, 20);
            this.tSBCuenta.SoloLectura = false;
            this.tSBCuenta.TabIndex = 3;
            this.tSBCuenta.Text = "ucTextSearchBox";
            this.tSBCuenta.TituloBuscador = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(107, 165);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Cuenta";
            // 
            // tSBMoneda
            // 
            this.tSBMoneda.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBMoneda.BackColor = System.Drawing.Color.Transparent;
            this.tSBMoneda.DBContext = null;
            this.tSBMoneda.DisplayMember = "";
            this.tSBMoneda.KeyMember = "";
            this.tSBMoneda.LabelCampoBusqueda = "";
            this.tSBMoneda.Location = new System.Drawing.Point(177, 132);
            this.tSBMoneda.Name = "tSBMoneda";
            this.tSBMoneda.NombreCampoDescrip = "";
            this.tSBMoneda.NombreCampoID = "";
            this.tSBMoneda.Size = new System.Drawing.Size(382, 20);
            this.tSBMoneda.SoloLectura = false;
            this.tSBMoneda.TabIndex = 2;
            this.tSBMoneda.Text = "ucTextSearchBox";
            this.tSBMoneda.TituloBuscador = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(107, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Moneda";
            // 
            // txtBancoNombre
            // 
            this.txtBancoNombre.BackColor = System.Drawing.SystemColors.Control;
            this.txtBancoNombre.Location = new System.Drawing.Point(249, 190);
            this.txtBancoNombre.Name = "txtBancoNombre";
            this.txtBancoNombre.ReadOnly = true;
            this.txtBancoNombre.Size = new System.Drawing.Size(310, 20);
            this.txtBancoNombre.TabIndex = 5;
            this.txtBancoNombre.TabStop = false;
            // 
            // txtBancoID
            // 
            this.txtBancoID.BackColor = System.Drawing.SystemColors.Control;
            this.txtBancoID.Location = new System.Drawing.Point(177, 190);
            this.txtBancoID.Name = "txtBancoID";
            this.txtBancoID.ReadOnly = true;
            this.txtBancoID.Size = new System.Drawing.Size(70, 20);
            this.txtBancoID.TabIndex = 4;
            this.txtBancoID.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(107, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Banco";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(107, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "ID";
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.SystemColors.Control;
            this.txtID.Location = new System.Drawing.Point(177, 73);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(70, 20);
            this.txtID.TabIndex = 0;
            this.txtID.TabStop = false;
            // 
            // txtNroCuenta
            // 
            this.txtNroCuenta.BackColor = System.Drawing.SystemColors.Control;
            this.txtNroCuenta.Location = new System.Drawing.Point(177, 217);
            this.txtNroCuenta.Name = "txtNroCuenta";
            this.txtNroCuenta.ReadOnly = true;
            this.txtNroCuenta.Size = new System.Drawing.Size(215, 20);
            this.txtNroCuenta.TabIndex = 6;
            this.txtNroCuenta.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(107, 220);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "N° Cuenta";
            // 
            // FCuentaPorClienteContinente
            // 
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNroCuenta);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBancoID);
            this.Controls.Add(this.txtBancoNombre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tSBMoneda);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tSBCuenta);
            this.Controls.Add(this.txtDescripcionCampo);
            this.Controls.Add(this.lblCampo);
            this.Controls.Add(this.txtCampoID);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Size = new System.Drawing.Size(667, 320);
            this.Text = "FCuentaPorClienteContinente";
            this.Load += new System.EventHandler(this.FCuentaPorClienteContinente_Load);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel2;
        private Button btnAceptar;
        private Button btnCancelar;
        private Panel panel3;
        private TextBox txtCampoID;
        private Label lblCampo;
        private TextBox txtDescripcionCampo;
        private UserControls.Base.ucTextSearchBox tSBCuenta;
        private Label label8;
        private UserControls.Base.ucTextSearchBox tSBMoneda;
        private Label label1;
        private TextBox txtBancoNombre;
        private TextBox txtBancoID;
        private Label label2;
        private Label label3;
        private TextBox txtID;
        private TextBox txtNroCuenta;
        private Label label4;


    }
}