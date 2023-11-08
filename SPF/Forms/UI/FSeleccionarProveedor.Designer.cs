using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.Forms.UI
{
    partial class FSeleccionarProveedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FSeleccionarProveedor));
            this.panel5 = new Gizmox.WebGUI.Forms.Panel();
            this.btnCancelar = new Gizmox.WebGUI.Forms.Button();
            this.btnAceptar = new Gizmox.WebGUI.Forms.Button();
            this.panel6 = new Gizmox.WebGUI.Forms.Panel();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.dgvProveedores = new Gizmox.WebGUI.Forms.DataGridView();
            this.grpTipoReporte = new Gizmox.WebGUI.Forms.GroupBox();
            this.rbOTProveedor = new Gizmox.WebGUI.Forms.RadioButton();
            this.rbOTInterno = new Gizmox.WebGUI.Forms.RadioButton();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).BeginInit();
            this.grpTipoReporte.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel5.Controls.Add(this.grpTipoReporte);
            this.panel5.Controls.Add(this.btnCancelar);
            this.panel5.Controls.Add(this.btnAceptar);
            this.panel5.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 267);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(743, 48);
            this.panel5.TabIndex = 0;
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
            this.btnCancelar.Location = new System.Drawing.Point(635, 6);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 36);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
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
            this.btnAceptar.Location = new System.Drawing.Point(540, 6);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(85, 36);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "&Imprimir";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel6.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(743, 33);
            this.panel6.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvProveedores);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(743, 234);
            this.panel1.TabIndex = 1;
            // 
            // dgvProveedores
            // 
            this.dgvProveedores.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.dgvProveedores.Location = new System.Drawing.Point(0, 0);
            this.dgvProveedores.Name = "dgvProveedores";
            this.dgvProveedores.Size = new System.Drawing.Size(743, 234);
            this.dgvProveedores.TabIndex = 0;
            // 
            // grpTipoReporte
            // 
            this.grpTipoReporte.Controls.Add(this.rbOTInterno);
            this.grpTipoReporte.Controls.Add(this.rbOTProveedor);
            this.grpTipoReporte.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.grpTipoReporte.ForeColor = System.Drawing.Color.Black;
            this.grpTipoReporte.Location = new System.Drawing.Point(9, 2);
            this.grpTipoReporte.Name = "grpTipoReporte";
            this.grpTipoReporte.Size = new System.Drawing.Size(310, 40);
            this.grpTipoReporte.TabIndex = 6;
            this.grpTipoReporte.TabStop = false;
            this.grpTipoReporte.Text = "Seleccionar Tipo de Reporte a Imprimir";
            this.grpTipoReporte.Click += new System.EventHandler(this.grpTipoReporte_Click);
            // 
            // rbOTProveedor
            // 
            this.rbOTProveedor.AutoSize = true;
            this.rbOTProveedor.Location = new System.Drawing.Point(202, 17);
            this.rbOTProveedor.Name = "rbOTProveedor";
            this.rbOTProveedor.Size = new System.Drawing.Size(100, 17);
            this.rbOTProveedor.TabIndex = 0;
            this.rbOTProveedor.Text = "Para Proveedor";
            // 
            // rbOTInterno
            // 
            this.rbOTInterno.AutoSize = true;
            this.rbOTInterno.Checked = true;
            this.rbOTInterno.Location = new System.Drawing.Point(17, 17);
            this.rbOTInterno.Name = "rbOTInterno";
            this.rbOTInterno.Size = new System.Drawing.Size(166, 17);
            this.rbOTInterno.TabIndex = 0;
            this.rbOTInterno.Text = "Interno (Para Administración)";
            // 
            // FSeleccionarProveedor
            // 
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel6);
            this.Size = new System.Drawing.Size(743, 315);
            this.Text = "FSeleccionarProveedor";
            this.Load += new System.EventHandler(this.FSeleccionarProveedor_Load);
            this.panel5.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).EndInit();
            this.grpTipoReporte.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel5;
        private Panel panel6;
        private Panel panel1;
        private Button btnCancelar;
        private Button btnAceptar;
        private DataGridView dgvProveedores;
        private GroupBox grpTipoReporte;
        private RadioButton rbOTInterno;
        private RadioButton rbOTProveedor;


    }
}