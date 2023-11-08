using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.Forms.UI.Reportes
{
    partial class FRepCheqEmitidos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRepCheqEmitidos));
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.panel4 = new Gizmox.WebGUI.Forms.Panel();
            this.tSBProveedor = new SPF.UserControls.Base.ucTextSearchBox();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.txtFechaHasta = new Gizmox.WebGUI.Forms.TextBox();
            this.txtFechaDesde = new Gizmox.WebGUI.Forms.TextBox();
            this.dtpFechaHasta = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.label18 = new Gizmox.WebGUI.Forms.Label();
            this.label21 = new Gizmox.WebGUI.Forms.Label();
            this.dtpFechaDesde = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.grpDatosCuenta = new Gizmox.WebGUI.Forms.GroupBox();
            this.txtMoneda = new Gizmox.WebGUI.Forms.TextBox();
            this.label9 = new Gizmox.WebGUI.Forms.Label();
            this.txtBanco = new Gizmox.WebGUI.Forms.TextBox();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.tSBCuenta = new SPF.UserControls.Base.ucTextSearchBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.txtNroCuenta = new Gizmox.WebGUI.Forms.TextBox();
            this.label8 = new Gizmox.WebGUI.Forms.Label();
            this.tSBMoneda = new SPF.UserControls.Base.ucTextSearchBox();
            this.panel3 = new Gizmox.WebGUI.Forms.Panel();
            this.btnAceptar = new Gizmox.WebGUI.Forms.Button();
            this.btnCancelar = new Gizmox.WebGUI.Forms.Button();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.grpDatosCuenta.SuspendLayout();
            this.panel3.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(525, 323);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tSBProveedor);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.txtFechaHasta);
            this.panel4.Controls.Add(this.txtFechaDesde);
            this.panel4.Controls.Add(this.dtpFechaHasta);
            this.panel4.Controls.Add(this.label18);
            this.panel4.Controls.Add(this.label21);
            this.panel4.Controls.Add(this.dtpFechaDesde);
            this.panel4.Controls.Add(this.grpDatosCuenta);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.tSBMoneda);
            this.panel4.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 46);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(525, 230);
            this.panel4.TabIndex = 2;
            // 
            // tSBProveedor
            // 
            this.tSBProveedor.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBProveedor.BackColor = System.Drawing.Color.Transparent;
            this.tSBProveedor.DBContext = null;
            this.tSBProveedor.DisplayMember = "";
            this.tSBProveedor.KeyMember = "";
            this.tSBProveedor.LabelCampoBusqueda = "";
            this.tSBProveedor.Location = new System.Drawing.Point(102, 48);
            this.tSBProveedor.Name = "tSBProveedor";
            this.tSBProveedor.NombreCampoDescrip = "";
            this.tSBProveedor.NombreCampoID = "";
            this.tSBProveedor.Size = new System.Drawing.Size(387, 20);
            this.tSBProveedor.SoloLectura = false;
            this.tSBProveedor.TabIndex = 2;
            this.tSBProveedor.Text = "ucTextSearchBox";
            this.tSBProveedor.TituloBuscador = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Proveedor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Desde";
            // 
            // txtFechaHasta
            // 
            this.txtFechaHasta.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0);
            this.txtFechaHasta.Location = new System.Drawing.Point(391, 14);
            this.txtFechaHasta.Name = "txtFechaHasta";
            this.txtFechaHasta.Size = new System.Drawing.Size(81, 18);
            this.txtFechaHasta.TabIndex = 1;
            // 
            // txtFechaDesde
            // 
            this.txtFechaDesde.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0);
            this.txtFechaDesde.Location = new System.Drawing.Point(102, 14);
            this.txtFechaDesde.Name = "txtFechaDesde";
            this.txtFechaDesde.Size = new System.Drawing.Size(81, 18);
            this.txtFechaDesde.TabIndex = 0;
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.CustomFormat = "dd/mm/yyyy";
            this.dtpFechaHasta.Location = new System.Drawing.Point(389, 13);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(100, 20);
            this.dtpFechaHasta.TabIndex = 3;
            this.dtpFechaHasta.TabStop = false;
            this.dtpFechaHasta.ValueChanged += new System.EventHandler(this.dtpFechaHasta_ValueChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(300, 17);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(43, 13);
            this.label18.TabIndex = 0;
            this.label18.Text = "Fecha Hasta";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(35, 17);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(43, 13);
            this.label21.TabIndex = 0;
            this.label21.Text = "Fecha";
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.CustomFormat = "dd/mm/yyyy";
            this.dtpFechaDesde.Location = new System.Drawing.Point(101, 13);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(100, 20);
            this.dtpFechaDesde.TabIndex = 3;
            this.dtpFechaDesde.TabStop = false;
            this.dtpFechaDesde.ValueChanged += new System.EventHandler(this.dtpFechaDesde_ValueChanged);
            // 
            // grpDatosCuenta
            // 
            this.grpDatosCuenta.Controls.Add(this.txtMoneda);
            this.grpDatosCuenta.Controls.Add(this.label9);
            this.grpDatosCuenta.Controls.Add(this.txtBanco);
            this.grpDatosCuenta.Controls.Add(this.label5);
            this.grpDatosCuenta.Controls.Add(this.tSBCuenta);
            this.grpDatosCuenta.Controls.Add(this.label1);
            this.grpDatosCuenta.Controls.Add(this.txtNroCuenta);
            this.grpDatosCuenta.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.grpDatosCuenta.ForeColor = System.Drawing.Color.Black;
            this.grpDatosCuenta.Location = new System.Drawing.Point(4, 111);
            this.grpDatosCuenta.Name = "grpDatosCuenta";
            this.grpDatosCuenta.Size = new System.Drawing.Size(516, 101);
            this.grpDatosCuenta.TabIndex = 4;
            this.grpDatosCuenta.TabStop = false;
            // 
            // txtMoneda
            // 
            this.txtMoneda.BackColor = System.Drawing.SystemColors.Control;
            this.txtMoneda.Location = new System.Drawing.Point(227, 43);
            this.txtMoneda.Name = "txtMoneda";
            this.txtMoneda.ReadOnly = true;
            this.txtMoneda.Size = new System.Drawing.Size(258, 20);
            this.txtMoneda.TabIndex = 4;
            this.txtMoneda.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(31, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Banco";
            // 
            // txtBanco
            // 
            this.txtBanco.BackColor = System.Drawing.SystemColors.Control;
            this.txtBanco.Location = new System.Drawing.Point(98, 70);
            this.txtBanco.Name = "txtBanco";
            this.txtBanco.ReadOnly = true;
            this.txtBanco.Size = new System.Drawing.Size(387, 20);
            this.txtBanco.TabIndex = 4;
            this.txtBanco.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "N° Cuenta";
            // 
            // tSBCuenta
            // 
            this.tSBCuenta.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBCuenta.BackColor = System.Drawing.Color.Transparent;
            this.tSBCuenta.DBContext = null;
            this.tSBCuenta.DisplayMember = "";
            this.tSBCuenta.KeyMember = "";
            this.tSBCuenta.LabelCampoBusqueda = "";
            this.tSBCuenta.Location = new System.Drawing.Point(98, 18);
            this.tSBCuenta.Name = "tSBCuenta";
            this.tSBCuenta.NombreCampoDescrip = "";
            this.tSBCuenta.NombreCampoID = "";
            this.tSBCuenta.Size = new System.Drawing.Size(387, 20);
            this.tSBCuenta.SoloLectura = false;
            this.tSBCuenta.TabIndex = 0;
            this.tSBCuenta.Text = "ucTextSearchBox";
            this.tSBCuenta.TituloBuscador = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cuenta";
            // 
            // txtNroCuenta
            // 
            this.txtNroCuenta.BackColor = System.Drawing.SystemColors.Control;
            this.txtNroCuenta.Location = new System.Drawing.Point(98, 43);
            this.txtNroCuenta.Name = "txtNroCuenta";
            this.txtNroCuenta.ReadOnly = true;
            this.txtNroCuenta.Size = new System.Drawing.Size(123, 20);
            this.txtNroCuenta.TabIndex = 4;
            this.txtNroCuenta.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(35, 86);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Moneda";
            // 
            // tSBMoneda
            // 
            this.tSBMoneda.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBMoneda.BackColor = System.Drawing.Color.Transparent;
            this.tSBMoneda.DBContext = null;
            this.tSBMoneda.DisplayMember = "";
            this.tSBMoneda.KeyMember = "";
            this.tSBMoneda.LabelCampoBusqueda = "";
            this.tSBMoneda.Location = new System.Drawing.Point(102, 82);
            this.tSBMoneda.Name = "tSBMoneda";
            this.tSBMoneda.NombreCampoDescrip = "";
            this.tSBMoneda.NombreCampoID = "";
            this.tSBMoneda.Size = new System.Drawing.Size(387, 20);
            this.tSBMoneda.SoloLectura = false;
            this.tSBMoneda.TabIndex = 3;
            this.tSBMoneda.Text = "ucTextSearchBox";
            this.tSBMoneda.TituloBuscador = "";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel3.Controls.Add(this.btnAceptar);
            this.panel3.Controls.Add(this.btnCancelar);
            this.panel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 276);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(525, 47);
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
            this.btnAceptar.Location = new System.Drawing.Point(142, 5);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(85, 36);
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
            this.btnCancelar.Location = new System.Drawing.Point(298, 5);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 36);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(525, 46);
            this.panel2.TabIndex = 0;
            // 
            // FRepCheqEmitidos
            // 
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Size = new System.Drawing.Size(525, 323);
            this.Text = "Reporte de Estado de Cuenta";
            this.Load += new System.EventHandler(this.FRepCheqEmitidos_Load);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.grpDatosCuenta.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Panel panel4;
        private Panel panel3;
        private Panel panel2;
        private Button btnAceptar;
        private Button btnCancelar;
        private Label label8;
        private UserControls.Base.ucTextSearchBox tSBMoneda;
        private TextBox txtFechaHasta;
        private TextBox txtFechaDesde;
        private DateTimePicker dtpFechaHasta;
        private Label label18;
        private Label label21;
        private DateTimePicker dtpFechaDesde;
        private GroupBox grpDatosCuenta;
        private TextBox txtMoneda;
        private Label label9;
        private TextBox txtBanco;
        private Label label5;
        private UserControls.Base.ucTextSearchBox tSBCuenta;
        private Label label1;
        private TextBox txtNroCuenta;
        private Label label2;
        private UserControls.Base.ucTextSearchBox tSBProveedor;
        private Label label3;


    }
}