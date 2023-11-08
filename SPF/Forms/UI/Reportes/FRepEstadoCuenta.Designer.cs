using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.Forms.UI.Reportes
{
    partial class FRepEstadoCuenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRepEstadoCuenta));
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.panel4 = new Gizmox.WebGUI.Forms.Panel();
            this.chkObsSistElect = new Gizmox.WebGUI.Forms.CheckBox();
            this.groupBox1 = new Gizmox.WebGUI.Forms.GroupBox();
            this.rbTramitesDesagrupados = new Gizmox.WebGUI.Forms.RadioButton();
            this.rbTramitesAgrupados = new Gizmox.WebGUI.Forms.RadioButton();
            this.chkIncluirNCP = new Gizmox.WebGUI.Forms.CheckBox();
            this.tSBCliente = new SPF.UserControls.Base.ucTextSearchBox();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.txtFechaHasta = new Gizmox.WebGUI.Forms.TextBox();
            this.txtFechaDesde = new Gizmox.WebGUI.Forms.TextBox();
            this.dtpFechaDesde = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.label21 = new Gizmox.WebGUI.Forms.Label();
            this.label18 = new Gizmox.WebGUI.Forms.Label();
            this.dtpFechaHasta = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.panel3 = new Gizmox.WebGUI.Forms.Panel();
            this.btnAceptar = new Gizmox.WebGUI.Forms.Button();
            this.btnCancelar = new Gizmox.WebGUI.Forms.Button();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(525, 345);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.chkObsSistElect);
            this.panel4.Controls.Add(this.groupBox1);
            this.panel4.Controls.Add(this.chkIncluirNCP);
            this.panel4.Controls.Add(this.tSBCliente);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.txtFechaHasta);
            this.panel4.Controls.Add(this.txtFechaDesde);
            this.panel4.Controls.Add(this.dtpFechaDesde);
            this.panel4.Controls.Add(this.label21);
            this.panel4.Controls.Add(this.label18);
            this.panel4.Controls.Add(this.dtpFechaHasta);
            this.panel4.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 46);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(525, 252);
            this.panel4.TabIndex = 2;
            // 
            // chkObsSistElect
            // 
            this.chkObsSistElect.AutoSize = true;
            this.chkObsSistElect.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkObsSistElect.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.chkObsSistElect.ForeColor = System.Drawing.Color.Black;
            this.chkObsSistElect.Location = new System.Drawing.Point(202, 104);
            this.chkObsSistElect.Name = "chkObsSistElect";
            this.chkObsSistElect.Size = new System.Drawing.Size(278, 17);
            this.chkObsSistElect.TabIndex = 4;
            this.chkObsSistElect.Text = "Mostrar observación y sistema electrónico del cliente";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbTramitesDesagrupados);
            this.groupBox1.Controls.Add(this.rbTramitesAgrupados);
            this.groupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(37, 131);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(455, 62);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Formato de Reporte";
            // 
            // rbTramitesDesagrupados
            // 
            this.rbTramitesDesagrupados.AutoSize = true;
            this.rbTramitesDesagrupados.Location = new System.Drawing.Point(184, 29);
            this.rbTramitesDesagrupados.Name = "rbTramitesDesagrupados";
            this.rbTramitesDesagrupados.Size = new System.Drawing.Size(138, 17);
            this.rbTramitesDesagrupados.TabIndex = 0;
            this.rbTramitesDesagrupados.Text = "Trámites Desagrupados";
            // 
            // rbTramitesAgrupados
            // 
            this.rbTramitesAgrupados.AutoSize = true;
            this.rbTramitesAgrupados.Location = new System.Drawing.Point(28, 29);
            this.rbTramitesAgrupados.Name = "rbTramitesAgrupados";
            this.rbTramitesAgrupados.Size = new System.Drawing.Size(121, 17);
            this.rbTramitesAgrupados.TabIndex = 0;
            this.rbTramitesAgrupados.Text = "Trámites Agrupados";
            // 
            // chkIncluirNCP
            // 
            this.chkIncluirNCP.AutoSize = true;
            this.chkIncluirNCP.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIncluirNCP.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.chkIncluirNCP.ForeColor = System.Drawing.Color.Red;
            this.chkIncluirNCP.Location = new System.Drawing.Point(184, 207);
            this.chkIncluirNCP.Name = "chkIncluirNCP";
            this.chkIncluirNCP.Size = new System.Drawing.Size(158, 17);
            this.chkIncluirNCP.TabIndex = 6;
            this.chkIncluirNCP.Text = "Incluir Notas de Crédito";
            // 
            // tSBCliente
            // 
            this.tSBCliente.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBCliente.BackColor = System.Drawing.SystemColors.Control;
            this.tSBCliente.DBContext = null;
            this.tSBCliente.DisplayMember = "";
            this.tSBCliente.KeyMember = "";
            this.tSBCliente.LabelCampoBusqueda = "";
            this.tSBCliente.Location = new System.Drawing.Point(117, 28);
            this.tSBCliente.Name = "tSBCliente";
            this.tSBCliente.NombreCampoDescrip = "";
            this.tSBCliente.NombreCampoID = "";
            this.tSBCliente.Size = new System.Drawing.Size(375, 20);
            this.tSBCliente.SoloLectura = false;
            this.tSBCliente.TabIndex = 5;
            this.tSBCliente.Text = "ucTextSearchBox";
            this.tSBCliente.TituloBuscador = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Cliente";
            // 
            // txtFechaHasta
            // 
            this.txtFechaHasta.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0);
            this.txtFechaHasta.Location = new System.Drawing.Point(394, 67);
            this.txtFechaHasta.Name = "txtFechaHasta";
            this.txtFechaHasta.Size = new System.Drawing.Size(81, 18);
            this.txtFechaHasta.TabIndex = 3;
            // 
            // txtFechaDesde
            // 
            this.txtFechaDesde.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0);
            this.txtFechaDesde.Location = new System.Drawing.Point(118, 67);
            this.txtFechaDesde.Name = "txtFechaDesde";
            this.txtFechaDesde.Size = new System.Drawing.Size(81, 18);
            this.txtFechaDesde.TabIndex = 3;
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.CustomFormat = "dd/mm/yyyy";
            this.dtpFechaDesde.Location = new System.Drawing.Point(117, 66);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(100, 20);
            this.dtpFechaDesde.TabIndex = 3;
            this.dtpFechaDesde.TabStop = false;
            this.dtpFechaDesde.ValueChanged += new System.EventHandler(this.dtpFechaDesde_ValueChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(34, 70);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(43, 13);
            this.label21.TabIndex = 0;
            this.label21.Text = "Fecha Desde";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(316, 70);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(43, 13);
            this.label18.TabIndex = 0;
            this.label18.Text = "Fecha Hasta";
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.CustomFormat = "dd/mm/yyyy";
            this.dtpFechaHasta.Location = new System.Drawing.Point(392, 66);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(100, 20);
            this.dtpFechaHasta.TabIndex = 3;
            this.dtpFechaHasta.TabStop = false;
            this.dtpFechaHasta.ValueChanged += new System.EventHandler(this.dtpFechaHasta_ValueChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel3.Controls.Add(this.btnAceptar);
            this.panel3.Controls.Add(this.btnCancelar);
            this.panel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 298);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(525, 47);
            this.panel3.TabIndex = 1;
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
            this.btnAceptar.Location = new System.Drawing.Point(142, 5);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(85, 36);
            this.btnAceptar.TabIndex = 7;
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
            this.btnCancelar.Location = new System.Drawing.Point(298, 5);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 36);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(525, 46);
            this.panel2.TabIndex = 0;
            // 
            // FRepEstadoCuenta
            // 
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Size = new System.Drawing.Size(525, 345);
            this.Text = "Reporte de Estado de Cuenta";
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Panel panel4;
        private Panel panel3;
        private Panel panel2;
        private TextBox txtFechaHasta;
        private TextBox txtFechaDesde;
        private DateTimePicker dtpFechaDesde;
        private Label label21;
        private Label label18;
        private DateTimePicker dtpFechaHasta;
        private Label label6;
        private UserControls.Base.ucTextSearchBox tSBCliente;
        private Button btnAceptar;
        private Button btnCancelar;
        private CheckBox chkIncluirNCP;
        private GroupBox groupBox1;
        private RadioButton rbTramitesDesagrupados;
        private RadioButton rbTramitesAgrupados;
        private CheckBox chkObsSistElect;


    }
}