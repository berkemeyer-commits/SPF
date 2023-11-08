using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.Forms
{
    partial class ReportTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportTest));
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.repUC1 = new SPF.RepUC();
            this.RV = new Gizmox.WebGUI.Reporting.ReportViewer();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.repUC1);
            this.panel1.Controls.Add(this.RV);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(823, 466);
            this.panel1.TabIndex = 0;
            // 
            // repUC1
            // 
            this.repUC1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.repUC1.Location = new System.Drawing.Point(476, 122);
            this.repUC1.Name = "repUC1";
            this.repUC1.Size = new System.Drawing.Size(106, 64);
            this.repUC1.TabIndex = 0;
            this.repUC1.Text = "RepUC";
            // 
            // RV
            // 
            this.RV.AutoScroll = false;
            this.RV.ControlCode = resources.GetString("RV.ControlCode");
            this.RV.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.RV.Location = new System.Drawing.Point(0, 0);
            this.RV.Name = "RV";
            this.RV.Size = new System.Drawing.Size(823, 466);
            this.RV.TabIndex = 1;
            // 
            // ReportTest
            // 
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable;
            this.Size = new System.Drawing.Size(823, 466);
            this.Text = "ReportTest";
            this.Load += new System.EventHandler(this.ReportTest_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private RepUC repUC1;
        private Gizmox.WebGUI.Reporting.ReportViewer RV;


    }
}