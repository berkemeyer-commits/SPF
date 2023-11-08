using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.Forms.Base
{
    partial class FVisorBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FVisorBase));
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.panel4 = new Gizmox.WebGUI.Forms.Panel();
            this.panel3 = new Gizmox.WebGUI.Forms.Panel();
            this.panel6 = new Gizmox.WebGUI.Forms.Panel();
            this.panel5 = new Gizmox.WebGUI.Forms.Panel();
            this.btnCancelar = new Gizmox.WebGUI.Forms.Button();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.rtxtData = new Gizmox.WebGUI.Forms.RichTextBox();
            this.txtSearhbox = new Gizmox.WebGUI.Forms.TextBox();
            this.btnBuscar = new Gizmox.WebGUI.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(646, 494);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.rtxtData);
            this.panel4.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(10, 10);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(626, 430);
            this.panel4.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(10, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(626, 10);
            this.panel3.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(10, 440);
            this.panel6.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel5.Controls.Add(this.btnBuscar);
            this.panel5.Controls.Add(this.txtSearhbox);
            this.panel5.Controls.Add(this.btnCancelar);
            this.panel5.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 440);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(636, 54);
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
            this.btnCancelar.Location = new System.Drawing.Point(515, 9);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 36);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // panel2
            // 
            this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(636, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 494);
            this.panel2.TabIndex = 0;
            // 
            // rtxtData
            // 
            this.rtxtData.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.rtxtData.Location = new System.Drawing.Point(0, 0);
            this.rtxtData.Name = "rtxtData";
            this.rtxtData.ReadOnly = true;
            this.rtxtData.Size = new System.Drawing.Size(626, 430);
            this.rtxtData.TabIndex = 0;
            // 
            // txtSearhbox
            // 
            this.txtSearhbox.Location = new System.Drawing.Point(12, 18);
            this.txtSearhbox.Name = "txtSearhbox";
            this.txtSearhbox.Size = new System.Drawing.Size(394, 20);
            this.txtSearhbox.TabIndex = 6;
            // 
            // btnBuscar
            // 
            this.btnBuscar.CustomStyle = "F";
            this.btnBuscar.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnBuscar.Image"));
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.ImageSize = new System.Drawing.Size(32, 32);
            this.btnBuscar.Location = new System.Drawing.Point(419, 9);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(85, 36);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // FVisorBase
            // 
            this.Controls.Add(this.panel1);
            this.Size = new System.Drawing.Size(646, 494);
            this.Text = "FVisorBase";
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Panel panel4;
        private Panel panel3;
        private Panel panel6;
        private Panel panel5;
        private Panel panel2;
        private Button btnCancelar;
        private RichTextBox rtxtData;
        private Button btnBuscar;
        private TextBox txtSearhbox;


    }
}