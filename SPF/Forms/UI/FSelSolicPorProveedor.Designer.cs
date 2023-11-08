using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.Forms.UI
{
    partial class FSelSolicPorProveedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FSelSolicPorProveedor));
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.panel4 = new Gizmox.WebGUI.Forms.Panel();
            this.panel6 = new Gizmox.WebGUI.Forms.Panel();
            this.dgvFacturas = new Gizmox.WebGUI.Forms.DataGridView();
            this.panel3 = new Gizmox.WebGUI.Forms.Panel();
            this.btnAceptar = new Gizmox.WebGUI.Forms.Button();
            this.btnCancelar = new Gizmox.WebGUI.Forms.Button();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.btnFiltrar = new Gizmox.WebGUI.Forms.Button();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.txtFiltroFactura = new Gizmox.WebGUI.Forms.TextBox();
            this.lblProvCorresp = new Gizmox.WebGUI.Forms.Label();
            this.tSBProveedor = new SPF.UserControls.Base.ucTextSearchBox();
            this.panel5 = new Gizmox.WebGUI.Forms.Panel();
            this.lblEstado = new Gizmox.WebGUI.Forms.Label();
            this.toolTip1 = new Gizmox.WebGUI.Forms.ToolTip();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(675, 504);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 141);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(675, 310);
            this.panel4.TabIndex = 2;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dgvFacturas);
            this.panel6.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(675, 310);
            this.panel6.TabIndex = 1;
            // 
            // dgvFacturas
            // 
            this.dgvFacturas.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.dgvFacturas.Location = new System.Drawing.Point(0, 0);
            this.dgvFacturas.Name = "dgvFacturas";
            this.dgvFacturas.Size = new System.Drawing.Size(675, 310);
            this.dgvFacturas.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel3.Controls.Add(this.btnAceptar);
            this.panel3.Controls.Add(this.btnCancelar);
            this.panel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 451);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(675, 53);
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
            this.btnAceptar.Location = new System.Drawing.Point(217, 9);
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
            this.btnCancelar.Location = new System.Drawing.Point(373, 9);
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
            this.panel2.Controls.Add(this.btnFiltrar);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtFiltroFactura);
            this.panel2.Controls.Add(this.lblProvCorresp);
            this.panel2.Controls.Add(this.tSBProveedor);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(675, 141);
            this.panel2.TabIndex = 0;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnFiltrar.Image"));
            this.btnFiltrar.Location = new System.Drawing.Point(568, 65);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(40, 40);
            this.btnFiltrar.TabIndex = 2;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Factura";
            // 
            // txtFiltroFactura
            // 
            this.txtFiltroFactura.Location = new System.Drawing.Point(114, 75);
            this.txtFiltroFactura.Name = "txtFiltroFactura";
            this.txtFiltroFactura.Size = new System.Drawing.Size(447, 20);
            this.txtFiltroFactura.TabIndex = 2;
            // 
            // lblProvCorresp
            // 
            this.lblProvCorresp.AutoSize = true;
            this.lblProvCorresp.Location = new System.Drawing.Point(36, 35);
            this.lblProvCorresp.Name = "lblProvCorresp";
            this.lblProvCorresp.Size = new System.Drawing.Size(35, 13);
            this.lblProvCorresp.TabIndex = 0;
            this.lblProvCorresp.Text = "Proveedor";
            // 
            // tSBProveedor
            // 
            this.tSBProveedor.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBProveedor.DBContext = null;
            this.tSBProveedor.DisplayMember = "";
            this.tSBProveedor.KeyMember = "";
            this.tSBProveedor.LabelCampoBusqueda = "";
            this.tSBProveedor.Location = new System.Drawing.Point(114, 31);
            this.tSBProveedor.Name = "tSBProveedor";
            this.tSBProveedor.NombreCampoDescrip = "";
            this.tSBProveedor.NombreCampoID = "";
            this.tSBProveedor.Size = new System.Drawing.Size(494, 20);
            this.tSBProveedor.SoloLectura = false;
            this.tSBProveedor.TabIndex = 0;
            this.tSBProveedor.Text = "ucTextSearchBox";
            this.tSBProveedor.TituloBuscador = "";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.lblEstado);
            this.panel5.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 120);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(675, 21);
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
            // FSelSolicPorProveedor
            // 
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(675, 504);
            this.Text = "FSelSolicPorProveedor";
            this.Load += new System.EventHandler(this.FSelSolicPorProveedor_Load);
            this.VisibleChanged += new System.EventHandler(this.FSelSolicPorProveedor_VisibleChanged);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
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
        private DataGridView dgvFacturas;
        private Panel panel5;
        private Label lblEstado;
        private Label lblProvCorresp;
        private UserControls.Base.ucTextSearchBox tSBProveedor;
        private Label label1;
        private TextBox txtFiltroFactura;
        private ToolTip toolTip1;
        private Button btnFiltrar;


    }
}