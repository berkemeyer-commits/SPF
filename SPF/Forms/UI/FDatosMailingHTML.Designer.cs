using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.Forms.UI
{
    partial class FDatosMailingHTML
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FDatosMailingHTML));
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.tabControl1 = new Gizmox.WebGUI.Forms.TabControl();
            this.tpEnviar = new Gizmox.WebGUI.Forms.TabPage();
            this.panel4 = new Gizmox.WebGUI.Forms.Panel();
            this.htmlText = new Gizmox.WebGUI.Forms.HtmlBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.txtDe = new Gizmox.WebGUI.Forms.TextBox();
            this.txtBCC = new Gizmox.WebGUI.Forms.TextBox();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.txtPara = new Gizmox.WebGUI.Forms.TextBox();
            this.txtCC = new Gizmox.WebGUI.Forms.TextBox();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.btnPara = new Gizmox.WebGUI.Forms.Button();
            this.btnCC = new Gizmox.WebGUI.Forms.Button();
            this.btnBCC = new Gizmox.WebGUI.Forms.Button();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.txtAsunto = new Gizmox.WebGUI.Forms.TextBox();
            this.label7 = new Gizmox.WebGUI.Forms.Label();
            this.tpConfigurar = new Gizmox.WebGUI.Forms.TabPage();
            this.btnGuardar = new Gizmox.WebGUI.Forms.Button();
            this.label9 = new Gizmox.WebGUI.Forms.Label();
            this.txtPassword = new Gizmox.WebGUI.Forms.TextBox();
            this.txtUsuario = new Gizmox.WebGUI.Forms.TextBox();
            this.label8 = new Gizmox.WebGUI.Forms.Label();
            this.panel3 = new Gizmox.WebGUI.Forms.Panel();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.btnAceptar = new Gizmox.WebGUI.Forms.Button();
            this.btnCancelar = new Gizmox.WebGUI.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tpEnviar.SuspendLayout();
            this.panel4.SuspendLayout();
            this.txtBCC.SuspendLayout();
            this.tpConfigurar.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(875, 584);
            this.panel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0);
            this.tabControl1.Controls.Add(this.tpEnviar);
            this.tabControl1.Controls.Add(this.tpConfigurar);
            this.tabControl1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 41);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(875, 497);
            this.tabControl1.TabIndex = 2;
            // 
            // tpEnviar
            // 
            this.tpEnviar.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0);
            this.tpEnviar.Controls.Add(this.panel4);
            this.tpEnviar.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tpEnviar.Location = new System.Drawing.Point(4, 22);
            this.tpEnviar.Name = "tpEnviar";
            this.tpEnviar.Size = new System.Drawing.Size(867, 471);
            this.tpEnviar.TabIndex = 0;
            this.tpEnviar.Text = "Enviar";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0);
            this.panel4.Controls.Add(this.htmlText);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.txtDe);
            this.panel4.Controls.Add(this.txtBCC);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.txtPara);
            this.panel4.Controls.Add(this.txtCC);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.btnPara);
            this.panel4.Controls.Add(this.btnCC);
            this.panel4.Controls.Add(this.btnBCC);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.txtAsunto);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(867, 471);
            this.panel4.TabIndex = 0;
            // 
            // htmlText
            // 
            this.htmlText.ContentType = "text/html";
            this.htmlText.Html = "<HTML>No content.</HTML>";
            this.htmlText.Location = new System.Drawing.Point(89, 177);
            this.htmlText.Name = "htmlText";
            this.htmlText.Size = new System.Drawing.Size(718, 278);
            this.htmlText.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "De:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtDe
            // 
            this.txtDe.Location = new System.Drawing.Point(89, 10);
            this.txtDe.Name = "txtDe";
            this.txtDe.Size = new System.Drawing.Size(718, 20);
            this.txtDe.TabIndex = 3;
            // 
            // txtBCC
            // 
            this.txtBCC.Controls.Add(this.label4);
            this.txtBCC.Location = new System.Drawing.Point(89, 91);
            this.txtBCC.Name = "txtBCC";
            this.txtBCC.Size = new System.Drawing.Size(718, 20);
            this.txtBCC.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-38, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "De";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "CC:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtPara
            // 
            this.txtPara.Location = new System.Drawing.Point(89, 36);
            this.txtPara.Name = "txtPara";
            this.txtPara.Size = new System.Drawing.Size(718, 20);
            this.txtPara.TabIndex = 3;
            // 
            // txtCC
            // 
            this.txtCC.Location = new System.Drawing.Point(89, 63);
            this.txtCC.Name = "txtCC";
            this.txtCC.Size = new System.Drawing.Size(718, 20);
            this.txtCC.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Para:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(55, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "BCC:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnPara
            // 
            this.btnPara.Location = new System.Drawing.Point(818, 34);
            this.btnPara.Name = "btnPara";
            this.btnPara.Size = new System.Drawing.Size(33, 26);
            this.btnPara.TabIndex = 4;
            this.btnPara.Text = "...";
            this.btnPara.Click += new System.EventHandler(this.btnPara_Click);
            // 
            // btnCC
            // 
            this.btnCC.Location = new System.Drawing.Point(818, 59);
            this.btnCC.Name = "btnCC";
            this.btnCC.Size = new System.Drawing.Size(33, 26);
            this.btnCC.TabIndex = 4;
            this.btnCC.Text = "...";
            this.btnCC.Click += new System.EventHandler(this.btnCC_Click);
            // 
            // btnBCC
            // 
            this.btnBCC.Location = new System.Drawing.Point(818, 87);
            this.btnBCC.Name = "btnBCC";
            this.btnBCC.Size = new System.Drawing.Size(33, 26);
            this.btnBCC.TabIndex = 4;
            this.btnBCC.Text = "...";
            this.btnBCC.Click += new System.EventHandler(this.btnBCC_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Cuerpo:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtAsunto
            // 
            this.txtAsunto.Location = new System.Drawing.Point(89, 119);
            this.txtAsunto.Multiline = true;
            this.txtAsunto.Name = "txtAsunto";
            this.txtAsunto.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.txtAsunto.Size = new System.Drawing.Size(718, 47);
            this.txtAsunto.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(41, 122);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Asunto:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tpConfigurar
            // 
            this.tpConfigurar.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0);
            this.tpConfigurar.Controls.Add(this.btnGuardar);
            this.tpConfigurar.Controls.Add(this.label9);
            this.tpConfigurar.Controls.Add(this.txtPassword);
            this.tpConfigurar.Controls.Add(this.txtUsuario);
            this.tpConfigurar.Controls.Add(this.label8);
            this.tpConfigurar.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tpConfigurar.Location = new System.Drawing.Point(4, 22);
            this.tpConfigurar.Name = "tpConfigurar";
            this.tpConfigurar.Size = new System.Drawing.Size(867, 471);
            this.tpConfigurar.TabIndex = 1;
            this.tpConfigurar.Text = "Configurar";
            // 
            // btnGuardar
            // 
            this.btnGuardar.CustomStyle = "F";
            this.btnGuardar.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.Black;
            this.btnGuardar.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnGuardar.Image"));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.ImageSize = new System.Drawing.Size(32, 32);
            this.btnGuardar.Location = new System.Drawing.Point(459, 41);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(85, 36);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "&Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(87, 65);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Contraseña:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(169, 62);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(269, 20);
            this.txtPassword.TabIndex = 1;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(169, 36);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(269, 20);
            this.txtUsuario.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(87, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Usuario:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(875, 41);
            this.panel3.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel2.Controls.Add(this.btnAceptar);
            this.panel2.Controls.Add(this.btnCancelar);
            this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 538);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(875, 46);
            this.panel2.TabIndex = 0;
            // 
            // btnAceptar
            // 
            this.btnAceptar.CustomStyle = "F";
            this.btnAceptar.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnAceptar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnAceptar.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnAceptar.Image"));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.ImageSize = new System.Drawing.Size(32, 32);
            this.btnAceptar.Location = new System.Drawing.Point(635, 5);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(85, 36);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.CustomStyle = "F";
            this.btnCancelar.DialogResult = Gizmox.WebGUI.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnCancelar.Image"));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.ImageSize = new System.Drawing.Size(32, 32);
            this.btnCancelar.Location = new System.Drawing.Point(726, 5);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 36);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FDatosMailingHTML
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel1);
            this.Size = new System.Drawing.Size(875, 584);
            this.Text = "Destinatarios";
            this.Load += new System.EventHandler(this.FDatosMailing_Load);
            this.GotFocus += new System.EventHandler(this.FDatosMailingHTML_GotFocus);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tpEnviar.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.txtBCC.ResumeLayout(false);
            this.tpConfigurar.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Panel panel3;
        private Panel panel2;
        private Button btnAceptar;
        private Button btnCancelar;
        private TabControl tabControl1;
        private TabPage tpEnviar;
        private Panel panel4;
        private Label label1;
        private TextBox txtDe;
        private TextBox txtBCC;
        private Label label4;
        private Label label2;
        private TextBox txtPara;
        private TextBox txtCC;
        private Label label3;
        private Label label5;
        private Button btnPara;
        private Button btnCC;
        private Button btnBCC;
        private Label label6;
        private TextBox txtAsunto;
        private Label label7;
        private TabPage tpConfigurar;
        private Label label9;
        private TextBox txtPassword;
        private TextBox txtUsuario;
        private Label label8;
        private Button btnGuardar;
        private HtmlBox htmlText;


    }
}