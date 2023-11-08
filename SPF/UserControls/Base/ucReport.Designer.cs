using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.UserControls
{
    partial class ucReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucReport));
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.RV = new SPF.Base.ReportWrapper();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.RV);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(830, 511);
            this.panel1.TabIndex = 0;
            // 
            // RV
            // 
            this.RV.AutoScroll = false;
            this.RV.ClientId = "Hola";
            this.RV.ControlCode = resources.GetString("RV.ControlCode");
            this.RV.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.RV.Location = new System.Drawing.Point(0, 0);
            this.RV.Name = "RV";
            this.RV.Size = new System.Drawing.Size(830, 511);
            this.RV.TabIndex = 0;
            this.RV.HostedPageLoad += new Gizmox.WebGUI.Forms.Hosts.AspPageEventHandler(this.RV_HostedPageLoad);
            // 
            // ucReport
            // 
            this.Controls.Add(this.panel1);
            this.Size = new System.Drawing.Size(830, 511);
            this.Text = "ucReportTest";
            this.Load += new System.EventHandler(this.ucReportTest_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private SPF.Base.ReportWrapper RV;


    }
}