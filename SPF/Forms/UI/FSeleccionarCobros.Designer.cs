using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.Forms.UI
{
    partial class FSeleccionarCobros
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FSeleccionarCobros));
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.panel4 = new Gizmox.WebGUI.Forms.Panel();
            this.panel6 = new Gizmox.WebGUI.Forms.Panel();
            this.dgvCobros = new Gizmox.WebGUI.Forms.DataGridView();
            this.panel3 = new Gizmox.WebGUI.Forms.Panel();
            this.btnAceptar = new Gizmox.WebGUI.Forms.Button();
            this.btnCancelar = new Gizmox.WebGUI.Forms.Button();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.txtFiltroNroCheque = new Gizmox.WebGUI.Forms.TextBox();
            this.cbMarcarTodo = new Gizmox.WebGUI.Forms.CheckBox();
            this.txtFiltroCobroID = new Gizmox.WebGUI.Forms.TextBox();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.btnFiltrar = new Gizmox.WebGUI.Forms.Button();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.txtFitlroNroRecibo = new Gizmox.WebGUI.Forms.TextBox();
            this.label7 = new Gizmox.WebGUI.Forms.Label();
            this.tSBCliente = new SPF.UserControls.Base.ucTextSearchBox();
            this.panel5 = new Gizmox.WebGUI.Forms.Panel();
            this.lblEstado = new Gizmox.WebGUI.Forms.Label();
            this.toolTip1 = new Gizmox.WebGUI.Forms.ToolTip();
            this.txtNroDoc = new Gizmox.WebGUI.Forms.TextBox();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCobros)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(923, 527);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 176);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(923, 298);
            this.panel4.TabIndex = 2;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dgvCobros);
            this.panel6.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(923, 298);
            this.panel6.TabIndex = 1;
            // 
            // dgvCobros
            // 
            this.dgvCobros.AllowUserToAddRows = false;
            this.dgvCobros.AllowUserToDeleteRows = false;
            this.dgvCobros.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.dgvCobros.Location = new System.Drawing.Point(0, 0);
            this.dgvCobros.Name = "dgvCobros";
            this.dgvCobros.Size = new System.Drawing.Size(923, 298);
            this.dgvCobros.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel3.Controls.Add(this.btnAceptar);
            this.panel3.Controls.Add(this.btnCancelar);
            this.panel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 474);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(923, 53);
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
            this.btnAceptar.Location = new System.Drawing.Point(333, 9);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(85, 36);
            this.btnAceptar.TabIndex = 8;
            this.btnAceptar.Text = "&Agregar";
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
            this.btnCancelar.Location = new System.Drawing.Point(489, 9);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 36);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "&Cerrar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtNroDoc);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtFiltroNroCheque);
            this.panel2.Controls.Add(this.cbMarcarTodo);
            this.panel2.Controls.Add(this.txtFiltroCobroID);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.btnFiltrar);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtFitlroNroRecibo);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.tSBCliente);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(923, 176);
            this.panel2.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(434, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "N° Cheque";
            // 
            // txtFiltroNroCheque
            // 
            this.txtFiltroNroCheque.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0);
            this.txtFiltroNroCheque.Location = new System.Drawing.Point(502, 60);
            this.txtFiltroNroCheque.Name = "txtFiltroNroCheque";
            this.txtFiltroNroCheque.Size = new System.Drawing.Size(205, 18);
            this.txtFiltroNroCheque.TabIndex = 3;
            // 
            // cbMarcarTodo
            // 
            this.cbMarcarTodo.AutoSize = true;
            this.cbMarcarTodo.Location = new System.Drawing.Point(28, 127);
            this.cbMarcarTodo.Name = "cbMarcarTodo";
            this.cbMarcarTodo.Size = new System.Drawing.Size(105, 17);
            this.cbMarcarTodo.TabIndex = 6;
            this.cbMarcarTodo.Text = "Seleccionar todo";
            this.cbMarcarTodo.CheckedChanged += new System.EventHandler(this.cbMarcarTodo_CheckedChanged);
            // 
            // txtFiltroCobroID
            // 
            this.txtFiltroCobroID.Location = new System.Drawing.Point(213, 32);
            this.txtFiltroCobroID.Name = "txtFiltroCobroID";
            this.txtFiltroCobroID.Size = new System.Drawing.Size(205, 20);
            this.txtFiltroCobroID.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(145, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Cobro ID";
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnFiltrar.Image"));
            this.btnFiltrar.Location = new System.Drawing.Point(727, 49);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(40, 40);
            this.btnFiltrar.TabIndex = 5;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(145, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "N° Recibo";
            // 
            // txtFitlroNroRecibo
            // 
            this.txtFitlroNroRecibo.Location = new System.Drawing.Point(213, 59);
            this.txtFitlroNroRecibo.Name = "txtFitlroNroRecibo";
            this.txtFitlroNroRecibo.Size = new System.Drawing.Size(205, 20);
            this.txtFitlroNroRecibo.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(145, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Cliente";
            // 
            // tSBCliente
            // 
            this.tSBCliente.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBCliente.DBContext = null;
            this.tSBCliente.DisplayMember = "";
            this.tSBCliente.KeyMember = "";
            this.tSBCliente.LabelCampoBusqueda = "";
            this.tSBCliente.Location = new System.Drawing.Point(213, 86);
            this.tSBCliente.Name = "tSBCliente";
            this.tSBCliente.NombreCampoDescrip = "";
            this.tSBCliente.NombreCampoID = "";
            this.tSBCliente.Size = new System.Drawing.Size(494, 20);
            this.tSBCliente.SoloLectura = false;
            this.tSBCliente.TabIndex = 4;
            this.tSBCliente.Text = "ucTextSearchBox";
            this.tSBCliente.TituloBuscador = "";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.lblEstado);
            this.panel5.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 155);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(923, 21);
            this.panel5.TabIndex = 1;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblEstado.ForeColor = System.Drawing.Color.Black;
            this.lblEstado.Location = new System.Drawing.Point(5, 3);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(35, 13);
            this.lblEstado.TabIndex = 0;
            this.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNroDoc
            // 
            this.txtNroDoc.Location = new System.Drawing.Point(502, 33);
            this.txtNroDoc.Name = "txtNroDoc";
            this.txtNroDoc.Size = new System.Drawing.Size(205, 20);
            this.txtNroDoc.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(434, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "N° Doc.";
            // 
            // FSeleccionarCobros
            // 
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(923, 527);
            this.Text = "FSeleccionarCobros";
            this.Load += new System.EventHandler(this.FSeleccionarCobros_Load);
            this.VisibleChanged += new System.EventHandler(this.FSeleccionarCobros_VisibleChanged);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCobros)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Panel panel4;
        private Panel panel3;
        private Panel panel2;
        private Panel panel6;
        private Button btnAceptar;
        private Button btnCancelar;
        private DataGridView dgvCobros;
        private Panel panel5;
        private Label lblEstado;
        private Label label7;
        private UserControls.Base.ucTextSearchBox tSBCliente;
        private Label label1;
        private TextBox txtFitlroNroRecibo;
        private ToolTip toolTip1;
        private Button btnFiltrar;
        private TextBox txtFiltroCobroID;
        private Label label4;
        private CheckBox cbMarcarTodo;
        private Label label2;
        private TextBox txtFiltroNroCheque;
        private Label label3;
        private TextBox txtNroDoc;


    }
}