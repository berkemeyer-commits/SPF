using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.Forms.UI
{
    partial class FShowProgress
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.timer1 = new Gizmox.WebGUI.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(29, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Procesando... Favor aguarde.";
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            // 
            // FShowProgress
            // 
            this.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.CornflowerBlue);
            this.CloseBox = false;
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(273, 44);
            this.RegisteredTimers = new Gizmox.WebGUI.Forms.Timer[] {
        this.timer1};
            this.ResumeLayout(false);

        }

        #endregion

        private Label label1;
        private Timer timer1;


    }
}