using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.Forms.UI
{
    partial class FImpresoraIni
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
            this.lblMensaje = new Gizmox.WebGUI.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Location = new System.Drawing.Point(68, 124);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(35, 13);
            this.lblMensaje.TabIndex = 0;
            this.lblMensaje.Text = "label1";
            // 
            // FImpresoraIni
            // 
            this.Controls.Add(this.lblMensaje);
            this.Size = new System.Drawing.Size(474, 276);
            this.Text = "FImpresoraIni";
            this.ResumeLayout(false);

        }

        #endregion

        private Label lblMensaje;


    }
}