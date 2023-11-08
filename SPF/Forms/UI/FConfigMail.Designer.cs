using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.Forms.UI
{
    partial class FConfigMail
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
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.panel3 = new Gizmox.WebGUI.Forms.Panel();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.txtCC = new Gizmox.WebGUI.Forms.TextBox();
            this.txtPara = new Gizmox.WebGUI.Forms.TextBox();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.txtDe = new Gizmox.WebGUI.Forms.TextBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(520, 50);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 232);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(520, 67);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.txtDe);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.txtPara);
            this.panel3.Controls.Add(this.txtCC);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 50);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(520, 182);
            this.panel3.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Para:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtCC
            // 
            this.txtCC.Location = new System.Drawing.Point(103, 92);
            this.txtCC.Name = "txtCC";
            this.txtCC.Size = new System.Drawing.Size(309, 20);
            this.txtCC.TabIndex = 3;
            // 
            // txtPara
            // 
            this.txtPara.Location = new System.Drawing.Point(103, 54);
            this.txtPara.Name = "txtPara";
            this.txtPara.Size = new System.Drawing.Size(309, 20);
            this.txtPara.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "CC:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtDe
            // 
            this.txtDe.Location = new System.Drawing.Point(103, 19);
            this.txtDe.Name = "txtDe";
            this.txtDe.Size = new System.Drawing.Size(309, 20);
            this.txtDe.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "De:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // FConfigMail
            // 
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Size = new System.Drawing.Size(520, 299);
            this.Text = "FConfigMail";
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Label label1;
        private TextBox txtDe;
        private Label label2;
        private TextBox txtPara;
        private TextBox txtCC;
        private Label label3;


    }
}