using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.Forms.UI
{
    partial class FImprimirDocumentos
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
            this.htmbApplet = new Gizmox.WebGUI.Forms.HtmlBox();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.btnImprimir = new Gizmox.WebGUI.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // htmbApplet
            // 
            this.htmbApplet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.htmbApplet.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(229)))), ((int)(((byte)(245))))));
            this.htmbApplet.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.None;
            this.htmbApplet.ClientId = "printing_page";
            this.htmbApplet.ContentType = "text/html";
            this.htmbApplet.Html = "<HTML>No content.</HTML>";
            this.htmbApplet.Location = new System.Drawing.Point(496, 223);
            this.htmbApplet.Name = "htmbApplet";
            this.htmbApplet.Size = new System.Drawing.Size(68, 55);
            this.htmbApplet.TabIndex = 1;
            this.htmbApplet.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnImprimir);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1113, 500);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(84, 43);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(75, 23);
            this.btnImprimir.TabIndex = 4;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // FImprimirDocumentos
            // 
            this.ClientId = "FImprimirDocumentos";
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.htmbApplet);
            this.Size = new System.Drawing.Size(1113, 500);
            this.Text = "FImprimirDocumentos";
            this.Load += new System.EventHandler(this.FImprimirDocumentos_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private HtmlBox htmbApplet;
        private Panel panel1;
        private Button btnImprimir;
        private Label label1;



    }
}