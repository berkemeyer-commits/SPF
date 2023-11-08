using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.UserControls.Base
{
    partial class ucMakeFilter
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
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.TxtValor = new Gizmox.WebGUI.Forms.TextBox();
            this.panel3 = new Gizmox.WebGUI.Forms.Panel();
            this.NombreCampo = new Gizmox.WebGUI.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(443, 27);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.TxtValor);
            this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(137, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(306, 27);
            this.panel2.TabIndex = 4;
            // 
            // TxtValor
            // 
            this.TxtValor.AllowDrag = false;
            this.TxtValor.Location = new System.Drawing.Point(3, 4);
            this.TxtValor.Name = "TxtValor";
            this.TxtValor.Size = new System.Drawing.Size(300, 20);
            this.TxtValor.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.NombreCampo);
            this.panel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(137, 27);
            this.panel3.TabIndex = 3;
            // 
            // NombreCampo
            // 
            this.NombreCampo.AutoSize = true;
            this.NombreCampo.Location = new System.Drawing.Point(10, 7);
            this.NombreCampo.Name = "NombreCampo";
            this.NombreCampo.Size = new System.Drawing.Size(35, 13);
            this.NombreCampo.TabIndex = 0;
            this.NombreCampo.Text = "NombreCampo";
            // 
            // ucMakeFilter
            // 
            this.Controls.Add(this.panel1);
            this.Size = new System.Drawing.Size(443, 27);
            this.Text = "ucMakeFilter";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private TextBox TxtValor;
        private Panel panel3;
        private Label NombreCampo;
        
        


    }
}