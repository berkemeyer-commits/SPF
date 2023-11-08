using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.Forms.UI
{
    partial class FDetalleSolArchivo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FDetalleSolArchivo));
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.panel4 = new Gizmox.WebGUI.Forms.Panel();
            this.dgvDetSolArchivo = new Gizmox.WebGUI.Forms.DataGridView();
            this.panel3 = new Gizmox.WebGUI.Forms.Panel();
            this.groupBox3 = new Gizmox.WebGUI.Forms.GroupBox();
            this.label15 = new Gizmox.WebGUI.Forms.Label();
            this.textBox3 = new Gizmox.WebGUI.Forms.TextBox();
            this.label14 = new Gizmox.WebGUI.Forms.Label();
            this.textBox4 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtTotal = new Gizmox.WebGUI.Forms.TextBox();
            this.label17 = new Gizmox.WebGUI.Forms.Label();
            this.textBox10 = new Gizmox.WebGUI.Forms.TextBox();
            this.label16 = new Gizmox.WebGUI.Forms.Label();
            this.textBox13 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtTipoFactura = new Gizmox.WebGUI.Forms.TextBox();
            this.label19 = new Gizmox.WebGUI.Forms.Label();
            this.textBox21 = new Gizmox.WebGUI.Forms.TextBox();
            this.label18 = new Gizmox.WebGUI.Forms.Label();
            this.textBox22 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtFechaFactura = new Gizmox.WebGUI.Forms.TextBox();
            this.label21 = new Gizmox.WebGUI.Forms.Label();
            this.textBox24 = new Gizmox.WebGUI.Forms.TextBox();
            this.label20 = new Gizmox.WebGUI.Forms.Label();
            this.textBox25 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtProveedor = new Gizmox.WebGUI.Forms.TextBox();
            this.txtNroFactura = new Gizmox.WebGUI.Forms.TextBox();
            this.label23 = new Gizmox.WebGUI.Forms.Label();
            this.textBox28 = new Gizmox.WebGUI.Forms.TextBox();
            this.label22 = new Gizmox.WebGUI.Forms.Label();
            this.textBox29 = new Gizmox.WebGUI.Forms.TextBox();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.btnCerrar = new Gizmox.WebGUI.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetSolArchivo)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.label15.SuspendLayout();
            this.label17.SuspendLayout();
            this.label19.SuspendLayout();
            this.label21.SuspendLayout();
            this.label23.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(700, 499);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgvDetSolArchivo);
            this.panel4.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 111);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(700, 341);
            this.panel4.TabIndex = 2;
            // 
            // dgvDetSolArchivo
            // 
            this.dgvDetSolArchivo.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.dgvDetSolArchivo.Location = new System.Drawing.Point(0, 0);
            this.dgvDetSolArchivo.Name = "dgvDetSolArchivo";
            this.dgvDetSolArchivo.Size = new System.Drawing.Size(700, 341);
            this.dgvDetSolArchivo.TabIndex = 0;
            this.dgvDetSolArchivo.CellFormatting += new Gizmox.WebGUI.Forms.DataGridViewCellFormattingEventHandler(this.dgvDetalleClienteDeuda_CellFormatting);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel3.Controls.Add(this.groupBox3);
            this.panel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(700, 111);
            this.panel3.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.txtTotal);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.txtTipoFactura);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.txtFechaFactura);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.txtProveedor);
            this.groupBox3.Controls.Add(this.txtNroFactura);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(9, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(680, 98);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datos Factura";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Controls.Add(this.textBox3);
            this.label15.Controls.Add(this.label14);
            this.label15.Controls.Add(this.textBox4);
            this.label15.Location = new System.Drawing.Point(366, 72);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "Total";
            this.label15.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Control;
            this.textBox3.Location = new System.Drawing.Point(154, 56);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(279, 20);
            this.textBox3.TabIndex = 1;
            this.textBox3.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(-170, -1);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "Area";
            this.label14.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.Control;
            this.textBox4.Location = new System.Drawing.Point(-129, -4);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(50, 20);
            this.textBox4.TabIndex = 1;
            this.textBox4.TabStop = false;
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.SystemColors.Control;
            this.txtTotal.ClientId = "txtDocPathClientID";
            this.txtTotal.Location = new System.Drawing.Point(415, 68);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(231, 20);
            this.txtTotal.TabIndex = 1;
            this.txtTotal.TabStop = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Controls.Add(this.textBox10);
            this.label17.Controls.Add(this.label16);
            this.label17.Controls.Add(this.textBox13);
            this.label17.Location = new System.Drawing.Point(40, 76);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(35, 13);
            this.label17.TabIndex = 0;
            this.label17.Text = "Tipo";
            this.label17.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBox10
            // 
            this.textBox10.BackColor = System.Drawing.SystemColors.Control;
            this.textBox10.Location = new System.Drawing.Point(154, 56);
            this.textBox10.Name = "textBox10";
            this.textBox10.ReadOnly = true;
            this.textBox10.Size = new System.Drawing.Size(279, 20);
            this.textBox10.TabIndex = 1;
            this.textBox10.TabStop = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(-170, -1);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 13);
            this.label16.TabIndex = 0;
            this.label16.Text = "Area";
            this.label16.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBox13
            // 
            this.textBox13.BackColor = System.Drawing.SystemColors.Control;
            this.textBox13.Location = new System.Drawing.Point(-129, -4);
            this.textBox13.Name = "textBox13";
            this.textBox13.ReadOnly = true;
            this.textBox13.Size = new System.Drawing.Size(50, 20);
            this.textBox13.TabIndex = 1;
            this.textBox13.TabStop = false;
            // 
            // txtTipoFactura
            // 
            this.txtTipoFactura.BackColor = System.Drawing.SystemColors.Control;
            this.txtTipoFactura.ClientId = "txtDocPathClientID";
            this.txtTipoFactura.Location = new System.Drawing.Point(109, 72);
            this.txtTipoFactura.Name = "txtTipoFactura";
            this.txtTipoFactura.ReadOnly = true;
            this.txtTipoFactura.Size = new System.Drawing.Size(231, 20);
            this.txtTipoFactura.TabIndex = 1;
            this.txtTipoFactura.TabStop = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Controls.Add(this.textBox21);
            this.label19.Controls.Add(this.label18);
            this.label19.Controls.Add(this.textBox22);
            this.label19.Location = new System.Drawing.Point(366, 46);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(35, 13);
            this.label19.TabIndex = 0;
            this.label19.Text = "Fecha";
            this.label19.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBox21
            // 
            this.textBox21.BackColor = System.Drawing.SystemColors.Control;
            this.textBox21.Location = new System.Drawing.Point(154, 56);
            this.textBox21.Name = "textBox21";
            this.textBox21.ReadOnly = true;
            this.textBox21.Size = new System.Drawing.Size(279, 20);
            this.textBox21.TabIndex = 1;
            this.textBox21.TabStop = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(-170, -1);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(35, 13);
            this.label18.TabIndex = 0;
            this.label18.Text = "Area";
            this.label18.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBox22
            // 
            this.textBox22.BackColor = System.Drawing.SystemColors.Control;
            this.textBox22.Location = new System.Drawing.Point(-129, -4);
            this.textBox22.Name = "textBox22";
            this.textBox22.ReadOnly = true;
            this.textBox22.Size = new System.Drawing.Size(50, 20);
            this.textBox22.TabIndex = 1;
            this.textBox22.TabStop = false;
            // 
            // txtFechaFactura
            // 
            this.txtFechaFactura.BackColor = System.Drawing.SystemColors.Control;
            this.txtFechaFactura.ClientId = "txtDocPathClientID";
            this.txtFechaFactura.Location = new System.Drawing.Point(415, 42);
            this.txtFechaFactura.Name = "txtFechaFactura";
            this.txtFechaFactura.ReadOnly = true;
            this.txtFechaFactura.Size = new System.Drawing.Size(231, 20);
            this.txtFechaFactura.TabIndex = 1;
            this.txtFechaFactura.TabStop = false;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Controls.Add(this.textBox24);
            this.label21.Controls.Add(this.label20);
            this.label21.Controls.Add(this.textBox25);
            this.label21.Location = new System.Drawing.Point(40, 20);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(35, 13);
            this.label21.TabIndex = 0;
            this.label21.Text = "Proveedor";
            this.label21.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBox24
            // 
            this.textBox24.BackColor = System.Drawing.SystemColors.Control;
            this.textBox24.Location = new System.Drawing.Point(154, 56);
            this.textBox24.Name = "textBox24";
            this.textBox24.ReadOnly = true;
            this.textBox24.Size = new System.Drawing.Size(279, 20);
            this.textBox24.TabIndex = 1;
            this.textBox24.TabStop = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(-170, -1);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(35, 13);
            this.label20.TabIndex = 0;
            this.label20.Text = "Area";
            this.label20.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBox25
            // 
            this.textBox25.BackColor = System.Drawing.SystemColors.Control;
            this.textBox25.Location = new System.Drawing.Point(-129, -4);
            this.textBox25.Name = "textBox25";
            this.textBox25.ReadOnly = true;
            this.textBox25.Size = new System.Drawing.Size(50, 20);
            this.textBox25.TabIndex = 1;
            this.textBox25.TabStop = false;
            // 
            // txtProveedor
            // 
            this.txtProveedor.BackColor = System.Drawing.SystemColors.Control;
            this.txtProveedor.ClientId = "txtDocPathClientID";
            this.txtProveedor.Location = new System.Drawing.Point(109, 16);
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.ReadOnly = true;
            this.txtProveedor.Size = new System.Drawing.Size(537, 20);
            this.txtProveedor.TabIndex = 1;
            this.txtProveedor.TabStop = false;
            // 
            // txtNroFactura
            // 
            this.txtNroFactura.BackColor = System.Drawing.SystemColors.Control;
            this.txtNroFactura.ClientId = "txtDocPathClientID";
            this.txtNroFactura.Location = new System.Drawing.Point(109, 42);
            this.txtNroFactura.Name = "txtNroFactura";
            this.txtNroFactura.ReadOnly = true;
            this.txtNroFactura.Size = new System.Drawing.Size(231, 20);
            this.txtNroFactura.TabIndex = 1;
            this.txtNroFactura.TabStop = false;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Controls.Add(this.textBox28);
            this.label23.Controls.Add(this.label22);
            this.label23.Controls.Add(this.textBox29);
            this.label23.Location = new System.Drawing.Point(40, 46);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(35, 13);
            this.label23.TabIndex = 0;
            this.label23.Text = "Número";
            this.label23.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBox28
            // 
            this.textBox28.BackColor = System.Drawing.SystemColors.Control;
            this.textBox28.Location = new System.Drawing.Point(154, 56);
            this.textBox28.Name = "textBox28";
            this.textBox28.ReadOnly = true;
            this.textBox28.Size = new System.Drawing.Size(279, 20);
            this.textBox28.TabIndex = 1;
            this.textBox28.TabStop = false;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(-170, -1);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(35, 13);
            this.label22.TabIndex = 0;
            this.label22.Text = "Area";
            this.label22.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBox29
            // 
            this.textBox29.BackColor = System.Drawing.SystemColors.Control;
            this.textBox29.Location = new System.Drawing.Point(-129, -4);
            this.textBox29.Name = "textBox29";
            this.textBox29.ReadOnly = true;
            this.textBox29.Size = new System.Drawing.Size(50, 20);
            this.textBox29.TabIndex = 1;
            this.textBox29.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel2.Controls.Add(this.btnCerrar);
            this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 452);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(700, 47);
            this.panel2.TabIndex = 0;
            // 
            // btnCerrar
            // 
            this.btnCerrar.CustomStyle = "F";
            this.btnCerrar.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnCerrar.Image"));
            this.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrar.ImageSize = new System.Drawing.Size(32, 32);
            this.btnCerrar.Location = new System.Drawing.Point(307, 4);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(85, 36);
            this.btnCerrar.TabIndex = 20;
            this.btnCerrar.Text = "&Cerrar";
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // FDetalleSolArchivo
            // 
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(700, 499);
            this.Text = "FDetallePresupuestoMerge";
            this.VisibleChanged += new System.EventHandler(this.FDetallePresupuestoMerge_VisibleChanged);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetSolArchivo)).EndInit();
            this.panel3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.label15.ResumeLayout(false);
            this.label17.ResumeLayout(false);
            this.label19.ResumeLayout(false);
            this.label21.ResumeLayout(false);
            this.label23.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Panel panel4;
        private DataGridView dgvDetSolArchivo;
        private Panel panel3;
        private Panel panel2;
        private Button btnCerrar;
        private GroupBox groupBox3;
        private Label label15;
        private TextBox textBox3;
        private Label label14;
        private TextBox textBox4;
        private TextBox txtTotal;
        private Label label17;
        private TextBox textBox10;
        private Label label16;
        private TextBox textBox13;
        private TextBox txtTipoFactura;
        private Label label19;
        private TextBox textBox21;
        private Label label18;
        private TextBox textBox22;
        private TextBox txtFechaFactura;
        private Label label21;
        private TextBox textBox24;
        private Label label20;
        private TextBox textBox25;
        private TextBox txtProveedor;
        private TextBox txtNroFactura;
        private Label label23;
        private TextBox textBox28;
        private Label label22;
        private TextBox textBox29;


    }
}