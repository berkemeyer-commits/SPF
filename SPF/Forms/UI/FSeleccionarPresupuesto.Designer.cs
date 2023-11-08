using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.Forms.UI
{
    partial class FSeleccionarPresupuesto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FSeleccionarPresupuesto));
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.panel4 = new Gizmox.WebGUI.Forms.Panel();
            this.panel6 = new Gizmox.WebGUI.Forms.Panel();
            this.dgvPresupuestos = new Gizmox.WebGUI.Forms.DataGridView();
            this.contextMenuStrip1 = new Gizmox.WebGUI.Forms.ContextMenuStrip(this.components);
            this.tSMIBorrar = new Gizmox.WebGUI.Forms.ToolStripMenuItem();
            this.panel3 = new Gizmox.WebGUI.Forms.Panel();
            this.btnCerrar = new Gizmox.WebGUI.Forms.Button();
            this.btnAceptar = new Gizmox.WebGUI.Forms.Button();
            this.btnCancelar = new Gizmox.WebGUI.Forms.Button();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.btnEliminarPresupuesto = new Gizmox.WebGUI.Forms.Button();
            this.btnAgregarPresup = new Gizmox.WebGUI.Forms.Button();
            this.tSBPresupuesto = new SPF.UserControls.Base.ucTextSearchBox();
            this.panel5 = new Gizmox.WebGUI.Forms.Panel();
            this.lblEstado = new Gizmox.WebGUI.Forms.Label();
            this.lblPresupuesto = new Gizmox.WebGUI.Forms.Label();
            this.toolTip1 = new Gizmox.WebGUI.Forms.ToolTip();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPresupuestos)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(675, 504);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 84);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(675, 367);
            this.panel4.TabIndex = 2;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dgvPresupuestos);
            this.panel6.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(675, 367);
            this.panel6.TabIndex = 1;
            // 
            // dgvPresupuestos
            // 
            this.dgvPresupuestos.AllowUserToAddRows = false;
            this.dgvPresupuestos.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvPresupuestos.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.dgvPresupuestos.Location = new System.Drawing.Point(0, 0);
            this.dgvPresupuestos.Name = "dgvPresupuestos";
            this.dgvPresupuestos.Size = new System.Drawing.Size(675, 367);
            this.dgvPresupuestos.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
            this.contextMenuStrip1.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207))))));
            this.contextMenuStrip1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.None;
            this.contextMenuStrip1.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(1);
            this.contextMenuStrip1.Items.AddRange(new Gizmox.WebGUI.Forms.ToolStripItem[] {
            this.tSMIBorrar});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(100, 25);
            // 
            // tSMIBorrar
            // 
            this.tSMIBorrar.Name = "tSMIBorrar";
            this.tSMIBorrar.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 0, 0);
            this.tSMIBorrar.ShortcutKeys = Gizmox.WebGUI.Forms.Keys.Delete;
            this.tSMIBorrar.Size = new System.Drawing.Size(104, 20);
            this.tSMIBorrar.Text = "&Borrar";
            this.tSMIBorrar.Click += new System.EventHandler(this.tSMIBorrar_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel3.Controls.Add(this.btnCerrar);
            this.panel3.Controls.Add(this.btnAceptar);
            this.panel3.Controls.Add(this.btnCancelar);
            this.panel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 451);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(675, 53);
            this.panel3.TabIndex = 1;
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
            this.btnCerrar.Location = new System.Drawing.Point(584, 9);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(85, 36);
            this.btnCerrar.TabIndex = 5;
            this.btnCerrar.Text = "&Cerrar";
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
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
            this.btnAceptar.Location = new System.Drawing.Point(217, 9);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(85, 36);
            this.btnAceptar.TabIndex = 3;
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
            this.btnCancelar.Location = new System.Drawing.Point(373, 9);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 36);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel2.Controls.Add(this.btnEliminarPresupuesto);
            this.panel2.Controls.Add(this.btnAgregarPresup);
            this.panel2.Controls.Add(this.tSBPresupuesto);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.lblPresupuesto);
            this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(675, 84);
            this.panel2.TabIndex = 0;
            // 
            // btnEliminarPresupuesto
            // 
            this.btnEliminarPresupuesto.AutoSize = true;
            this.btnEliminarPresupuesto.BackColor = System.Drawing.Color.Transparent;
            this.btnEliminarPresupuesto.CustomStyle = "F";
            this.btnEliminarPresupuesto.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnEliminarPresupuesto.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnEliminarPresupuesto.Image"));
            this.btnEliminarPresupuesto.Location = new System.Drawing.Point(588, 12);
            this.btnEliminarPresupuesto.Name = "btnEliminarPresupuesto";
            this.btnEliminarPresupuesto.Size = new System.Drawing.Size(40, 40);
            this.btnEliminarPresupuesto.TabIndex = 1;
            this.btnEliminarPresupuesto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnEliminarPresupuesto, "Eliminar Presupuesto");
            this.btnEliminarPresupuesto.Click += new System.EventHandler(this.btnEliminarPresupuesto_Click);
            // 
            // btnAgregarPresup
            // 
            this.btnAgregarPresup.AutoSize = true;
            this.btnAgregarPresup.BackColor = System.Drawing.Color.Transparent;
            this.btnAgregarPresup.CustomStyle = "F";
            this.btnAgregarPresup.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnAgregarPresup.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnAgregarPresup.Image"));
            this.btnAgregarPresup.Location = new System.Drawing.Point(548, 12);
            this.btnAgregarPresup.Name = "btnAgregarPresup";
            this.btnAgregarPresup.Size = new System.Drawing.Size(40, 40);
            this.btnAgregarPresup.TabIndex = 1;
            this.btnAgregarPresup.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnAgregarPresup, "Agregar Presupuesto");
            this.btnAgregarPresup.Click += new System.EventHandler(this.btnAgregarPresup_Click);
            // 
            // tSBPresupuesto
            // 
            this.tSBPresupuesto.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBPresupuesto.BackColor = System.Drawing.Color.Transparent;
            this.tSBPresupuesto.DBContext = null;
            this.tSBPresupuesto.DisplayMember = "";
            this.tSBPresupuesto.KeyMember = "";
            this.tSBPresupuesto.LabelCampoBusqueda = "";
            this.tSBPresupuesto.Location = new System.Drawing.Point(138, 21);
            this.tSBPresupuesto.Name = "tSBPresupuesto";
            this.tSBPresupuesto.NombreCampoDescrip = "";
            this.tSBPresupuesto.NombreCampoID = "";
            this.tSBPresupuesto.Size = new System.Drawing.Size(399, 20);
            this.tSBPresupuesto.SoloLectura = false;
            this.tSBPresupuesto.TabIndex = 0;
            this.tSBPresupuesto.Text = "ucTextSearchBox";
            this.tSBPresupuesto.TituloBuscador = "";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.lblEstado);
            this.panel5.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 63);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(675, 21);
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
            // lblPresupuesto
            // 
            this.lblPresupuesto.AutoSize = true;
            this.lblPresupuesto.Location = new System.Drawing.Point(61, 25);
            this.lblPresupuesto.Name = "lblPresupuesto";
            this.lblPresupuesto.Size = new System.Drawing.Size(43, 13);
            this.lblPresupuesto.TabIndex = 0;
            this.lblPresupuesto.Text = "Presupuesto";
            // 
            // FSeleccionarPresupuesto
            // 
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(675, 504);
            this.Text = "FSeleccionarPresupuestoNC";
            this.Load += new System.EventHandler(this.FSeleccionarPresupuesto_Load);
            this.VisibleChanged += new System.EventHandler(this.FSeleccionarPresupuestoNC_VisibleChanged);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPresupuestos)).EndInit();
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
        private Label lblPresupuesto;
        private DataGridView dgvPresupuestos;
        private Panel panel5;
        private Label lblEstado;
        private UserControls.Base.ucTextSearchBox tSBPresupuesto;
        private Button btnCerrar;
        private Button btnAgregarPresup;
        private ToolTip toolTip1;
        private Button btnEliminarPresupuesto;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem tSMIBorrar;


    }
}