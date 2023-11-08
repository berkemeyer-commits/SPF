using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.Forms.Base
{
    partial class FReportViewerBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FReportViewerBase));
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.panel4 = new Gizmox.WebGUI.Forms.Panel();
            this.ucReport1 = new SPF.UserControls.ucReport();
            this.panel3 = new Gizmox.WebGUI.Forms.Panel();
            this.lblRegistros = new Gizmox.WebGUI.Forms.Label();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.btnImprimir = new Gizmox.WebGUI.Forms.Button();
            this.rbEmbebido = new Gizmox.WebGUI.Forms.RadioButton();
            this.btnEnviar = new Gizmox.WebGUI.Forms.Button();
            this.grpEnviar = new Gizmox.WebGUI.Forms.GroupBox();
            this.rbExcel = new Gizmox.WebGUI.Forms.RadioButton();
            this.rbWord = new Gizmox.WebGUI.Forms.RadioButton();
            this.rbPDF = new Gizmox.WebGUI.Forms.RadioButton();
            this.btnCerrar = new Gizmox.WebGUI.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.grpEnviar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(930, 521);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.ucReport1);
            this.panel4.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 30);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(930, 427);
            this.panel4.TabIndex = 2;
            // 
            // ucReport1
            // 
            this.ucReport1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ucReport1.ClientId = "rptViewer";
            this.ucReport1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.ucReport1.ListReportDataSource = null;
            this.ucReport1.Location = new System.Drawing.Point(0, 0);
            this.ucReport1.Name = "ucReport1";
            this.ucReport1.ReportDataSource = null;
            this.ucReport1.ReportDisplayName = "";
            this.ucReport1.ReportFileSource = "";
            this.ucReport1.ScrollerType = Gizmox.WebGUI.Forms.ScrollerType.Arrows;
            this.ucReport1.Size = new System.Drawing.Size(930, 427);
            this.ucReport1.TabIndex = 0;
            this.ucReport1.Text = "ucReportTest";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel3.Controls.Add(this.lblRegistros);
            this.panel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(930, 30);
            this.panel3.TabIndex = 1;
            // 
            // lblRegistros
            // 
            this.lblRegistros.AutoSize = true;
            this.lblRegistros.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblRegistros.ForeColor = System.Drawing.Color.White;
            this.lblRegistros.Location = new System.Drawing.Point(9, 9);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(35, 13);
            this.lblRegistros.TabIndex = 0;
            this.lblRegistros.Text = "Registros recuperados:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel2.Controls.Add(this.btnImprimir);
            this.panel2.Controls.Add(this.rbEmbebido);
            this.panel2.Controls.Add(this.btnEnviar);
            this.panel2.Controls.Add(this.grpEnviar);
            this.panel2.Controls.Add(this.btnCerrar);
            this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 457);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(930, 64);
            this.panel2.TabIndex = 0;
            // 
            // btnImprimir
            // 
            this.btnImprimir.CustomStyle = "F";
            this.btnImprimir.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnImprimir.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnImprimir.ForeColor = System.Drawing.Color.White;
            this.btnImprimir.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnImprimir.Image"));
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.ImageSize = new System.Drawing.Size(32, 32);
            this.btnImprimir.Location = new System.Drawing.Point(742, 17);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(85, 36);
            this.btnImprimir.TabIndex = 21;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            this.btnImprimir.ClientClick += new Gizmox.WebGUI.Forms.Client.ClientEventHandler(this.btnImprimir_ClientClick);
            // 
            // rbEmbebido
            // 
            this.rbEmbebido.AutoSize = true;
            this.rbEmbebido.ClientId = "rbEmbebido";
            this.rbEmbebido.Location = new System.Drawing.Point(222, 27);
            this.rbEmbebido.Name = "rbEmbebido";
            this.rbEmbebido.Size = new System.Drawing.Size(71, 17);
            this.rbEmbebido.TabIndex = 22;
            this.rbEmbebido.Text = "Embebido";
            this.rbEmbebido.Visible = false;
            // 
            // btnEnviar
            // 
            this.btnEnviar.CustomStyle = "F";
            this.btnEnviar.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnEnviar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnEnviar.ForeColor = System.Drawing.Color.White;
            this.btnEnviar.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnEnviar.Image"));
            this.btnEnviar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEnviar.ImageSize = new System.Drawing.Size(32, 32);
            this.btnEnviar.Location = new System.Drawing.Point(645, 17);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(90, 36);
            this.btnEnviar.TabIndex = 20;
            this.btnEnviar.Text = "&Enviar";
            this.btnEnviar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnviar.ClientClick += new Gizmox.WebGUI.Forms.Client.ClientEventHandler(this.btnEnviar_ClientClick);
            // 
            // grpEnviar
            // 
            this.grpEnviar.Controls.Add(this.rbExcel);
            this.grpEnviar.Controls.Add(this.rbWord);
            this.grpEnviar.Controls.Add(this.rbPDF);
            this.grpEnviar.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.grpEnviar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.grpEnviar.Location = new System.Drawing.Point(9, 2);
            this.grpEnviar.Name = "grpEnviar";
            this.grpEnviar.Size = new System.Drawing.Size(213, 58);
            this.grpEnviar.TabIndex = 22;
            this.grpEnviar.TabStop = false;
            this.grpEnviar.Text = "Opciones de Envío";
            // 
            // rbExcel
            // 
            this.rbExcel.AutoSize = true;
            this.rbExcel.Location = new System.Drawing.Point(150, 25);
            this.rbExcel.Name = "rbExcel";
            this.rbExcel.Size = new System.Drawing.Size(50, 17);
            this.rbExcel.TabIndex = 22;
            this.rbExcel.Text = "Excel";
            // 
            // rbWord
            // 
            this.rbWord.AutoSize = true;
            this.rbWord.Location = new System.Drawing.Point(81, 25);
            this.rbWord.Name = "rbWord";
            this.rbWord.Size = new System.Drawing.Size(51, 17);
            this.rbWord.TabIndex = 22;
            this.rbWord.Text = "Word";
            // 
            // rbPDF
            // 
            this.rbPDF.AutoSize = true;
            this.rbPDF.Checked = true;
            this.rbPDF.Location = new System.Drawing.Point(20, 25);
            this.rbPDF.Name = "rbPDF";
            this.rbPDF.Size = new System.Drawing.Size(44, 17);
            this.rbPDF.TabIndex = 22;
            this.rbPDF.Text = "PDF";
            // 
            // btnCerrar
            // 
            this.btnCerrar.CustomStyle = "F";
            this.btnCerrar.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnCerrar.Image"));
            this.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrar.ImageSize = new System.Drawing.Size(32, 32);
            this.btnCerrar.Location = new System.Drawing.Point(834, 17);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(85, 36);
            this.btnCerrar.TabIndex = 22;
            this.btnCerrar.Text = "&Cerrar";
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // FReportViewerBase
            // 
            this.ClientId = "frmReport";
            this.Controls.Add(this.panel1);
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(930, 521);
            this.Text = "FReportViewerBase";
            this.Load += new System.EventHandler(this.FReportViewerBase_Load);
            this.FormClosing += new Gizmox.WebGUI.Forms.Form.FormClosingEventHandler(this.FReportViewerBase_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.grpEnviar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Panel panel4;
        private Panel panel3;
        private Panel panel2;
        private UserControls.ucReport ucReport1;
        private Button btnCerrar;
        private GroupBox grpEnviar;
        private RadioButton rbEmbebido;
        private RadioButton rbExcel;
        private RadioButton rbWord;
        private RadioButton rbPDF;
        private Button btnEnviar;
        private Label lblRegistros;
        private Button btnImprimir;


    }
}