using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SCCFCC
{
    partial class RepUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RepUC));
            this.RV = new Gizmox.WebGUI.Reporting.ReportViewer();
            this.SuspendLayout();
            // 
            // RV
            // 
            this.RV.AutoScroll = false;
            this.RV.ControlCode = resources.GetString("RV.ControlCode");
            this.RV.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.RV.Location = new System.Drawing.Point(0, 0);
            this.RV.Name = "RV";
            this.RV.Size = new System.Drawing.Size(490, 391);
            this.RV.TabIndex = 0;
            this.RV.HostedPageLoad += new Gizmox.WebGUI.Forms.Hosts.AspPageEventHandler(this.RV_HostedPageLoad);
            // 
            // RepUC
            // 
            this.Controls.Add(this.RV);
            this.Size = new System.Drawing.Size(490, 391);
            this.Text = "RepUC";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Reporting.ReportViewer RV;


    }
}