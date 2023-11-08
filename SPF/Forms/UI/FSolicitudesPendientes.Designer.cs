using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.Forms.UI
{
    partial class FSolicitudesPendientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FSolicitudesPendientes));
            this.panel5 = new Gizmox.WebGUI.Forms.Panel();
            this.btnCancelar = new Gizmox.WebGUI.Forms.Button();
            this.panel6 = new Gizmox.WebGUI.Forms.Panel();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.dgvSolicitudes = new Gizmox.WebGUI.Forms.DataGridView();
            this.txtInfo = new Gizmox.WebGUI.Forms.TextBox();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolicitudes)).BeginInit();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel5.Controls.Add(this.btnCancelar);
            this.panel5.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 431);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(848, 48);
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
            this.btnCancelar.Location = new System.Drawing.Point(713, 6);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 36);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "&Cerrar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel6.Controls.Add(this.txtInfo);
            this.panel6.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(848, 97);
            this.panel6.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvSolicitudes);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 97);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(848, 334);
            this.panel1.TabIndex = 1;
            // 
            // dgvSolicitudes
            // 
            this.dgvSolicitudes.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.dgvSolicitudes.Location = new System.Drawing.Point(0, 0);
            this.dgvSolicitudes.Name = "dgvSolicitudes";
            this.dgvSolicitudes.Size = new System.Drawing.Size(848, 334);
            this.dgvSolicitudes.TabIndex = 0;
            // 
            // txtInfo
            // 
            this.txtInfo.BackColor = System.Drawing.SystemColors.Control;
            this.txtInfo.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.None;
            this.txtInfo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtInfo.ForeColor = System.Drawing.Color.DarkRed;
            this.txtInfo.Location = new System.Drawing.Point(35, 6);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ReadOnly = true;
            this.txtInfo.Size = new System.Drawing.Size(778, 82);
            this.txtInfo.TabIndex = 0;
            this.txtInfo.TabStop = false;
            // 
            // FSolicitudesPendientes
            // 
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel6);
            this.Size = new System.Drawing.Size(848, 479);
            this.Text = "FSeleccionarProveedor";
            this.Load += new System.EventHandler(this.FSolicitudesPendientes_Load);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolicitudes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel5;
        private Panel panel6;
        private Panel panel1;
        private Button btnCancelar;
        private DataGridView dgvSolicitudes;
        private TextBox txtInfo;


    }
}