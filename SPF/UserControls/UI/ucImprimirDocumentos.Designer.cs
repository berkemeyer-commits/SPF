using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.UserControls.UI
{
    partial class ucImprimirDocumentos
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
            this.btnImprimir = new Gizmox.WebGUI.Forms.Button();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.htmbApplet = new Gizmox.WebGUI.Forms.HtmlBox();
            this.tbbDDPrinters = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.tbbImpresoraSelec = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.appletBox1 = new Gizmox.WebGUI.Forms.Hosts.AppletBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoABM)).BeginInit();
            this.pnlDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabListaABM)).BeginInit();
            this.pnlListadoContainer.SuspendLayout();
            this.pnlContainer.SuspendLayout();
            this.pnlTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvListadoABM
            // 
            this.dgvListadoABM.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.dgvListadoABM.Dock = Gizmox.WebGUI.Forms.DockStyle.None;
            this.dgvListadoABM.Size = new System.Drawing.Size(1171, 428);
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.Controls.Add(this.label1);
            this.pnlDetalle.Controls.Add(this.btnImprimir);
            this.pnlDetalle.Size = new System.Drawing.Size(1191, 447);
            // 
            // tBBaseForm
            // 
            this.tBBaseForm.Buttons.AddRange(new Gizmox.WebGUI.Forms.ToolBarButton[] {
            this.tbbDDPrinters,
            this.tbbImpresoraSelec});
            this.tBBaseForm.Size = new System.Drawing.Size(1199, 226);
            // 
            // tabListaABM
            // 
            this.tabListaABM.Alignment = Gizmox.WebGUI.Forms.TabAlignment.Top;
            this.tabListaABM.Size = new System.Drawing.Size(1199, 477);
            // 
            // pnlListadoContainer
            // 
            this.pnlListadoContainer.Controls.Add(this.appletBox1);
            this.pnlListadoContainer.Controls.SetChildIndex(this.dgvListadoABM, 0);
            this.pnlListadoContainer.Controls.SetChildIndex(this.appletBox1, 0);
            // 
            // pnlTabControl
            // 
            this.pnlTabControl.Controls.Add(this.htmbApplet);
            this.pnlTabControl.Controls.SetChildIndex(this.htmbApplet, 0);
            this.pnlTabControl.Controls.SetChildIndex(this.tabListaABM, 0);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(66, 285);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(75, 23);
            this.btnImprimir.TabIndex = 4;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 290);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // htmbApplet
            // 
            this.htmbApplet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.htmbApplet.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(229)))), ((int)(((byte)(245))))));
            this.htmbApplet.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.None;
            this.htmbApplet.ClientId = "printing_page";
            this.htmbApplet.ContentType = "text/html";
            this.htmbApplet.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.htmbApplet.Html = "<HTML>No content.</HTML>";
            this.htmbApplet.Location = new System.Drawing.Point(0, 0);
            this.htmbApplet.Name = "htmbApplet";
            this.htmbApplet.Size = new System.Drawing.Size(1191, 0);
            this.htmbApplet.TabIndex = 1;
            this.htmbApplet.TabStop = false;
            // 
            // tbbDDPrinters
            // 
            this.tbbDDPrinters.CustomStyle = "";
            this.tbbDDPrinters.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tbbDDPrinters.Name = "tbbDDPrinters";
            this.tbbDDPrinters.Size = 24;
            this.tbbDDPrinters.Style = Gizmox.WebGUI.Forms.ToolBarButtonStyle.DropDownButton;
            this.tbbDDPrinters.Text = "Impresora";
            this.tbbDDPrinters.ToolTipText = "Seleccione la impresora";
            this.tbbDDPrinters.Click += new System.EventHandler(this.tbbDDPrinters_Click);
            // 
            // tbbImpresoraSelec
            // 
            this.tbbImpresoraSelec.CustomStyle = "";
            this.tbbImpresoraSelec.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tbbImpresoraSelec.Name = "tbbImpresoraSelec";
            this.tbbImpresoraSelec.Size = 24;
            this.tbbImpresoraSelec.Text = "Impresora Predeterminada";
            this.tbbImpresoraSelec.ToolTipText = "";
            // 
            // appletBox1
            // 
            this.appletBox1.Location = new System.Drawing.Point(487, 145);
            this.appletBox1.Name = "appletBox1";
            this.appletBox1.Parameters.Add("archive", null);
            this.appletBox1.Size = new System.Drawing.Size(100, 100);
            this.appletBox1.TabIndex = 2;
            // 
            // ucImprimirDocumentos
            // 
            this.ClientId = "ucImprimirDocumentos";
            this.Size = new System.Drawing.Size(1201, 555);
            this.Text = "ucImprimirDocumentos";
            this.Load += new System.EventHandler(this.ucImprimirDocumentos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoABM)).EndInit();
            this.pnlDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabListaABM)).EndInit();
            this.pnlListadoContainer.ResumeLayout(false);
            this.pnlContainer.ResumeLayout(false);
            this.pnlTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Label label1;
        private Button btnImprimir;
        private HtmlBox htmbApplet;
        private ToolBarButton tbbDDPrinters;
        private ToolBarButton tbbImpresoraSelec;
        private Gizmox.WebGUI.Forms.Hosts.AppletBox appletBox1;


    }
}