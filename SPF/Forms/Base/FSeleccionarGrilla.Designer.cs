using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.Forms.Base
{
    partial class FSeleccionarGrilla
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FSeleccionarGrilla));
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.panel6 = new Gizmox.WebGUI.Forms.Panel();
            this.btnAgregarSeleccion = new Gizmox.WebGUI.Forms.Button();
            this.btnEliminarSeleccion = new Gizmox.WebGUI.Forms.Button();
            this.btnEliminarTodo = new Gizmox.WebGUI.Forms.Button();
            this.cbMarcarTodo = new Gizmox.WebGUI.Forms.CheckBox();
            this.panel5 = new Gizmox.WebGUI.Forms.Panel();
            this.panel10 = new Gizmox.WebGUI.Forms.Panel();
            this.dgvDestino = new Gizmox.WebGUI.Forms.DataGridView();
            this.panel9 = new Gizmox.WebGUI.Forms.Panel();
            this.lblGrillaDestino = new Gizmox.WebGUI.Forms.Label();
            this.panel4 = new Gizmox.WebGUI.Forms.Panel();
            this.panel8 = new Gizmox.WebGUI.Forms.Panel();
            this.dgvOrigen = new Gizmox.WebGUI.Forms.DataGridView();
            this.panel7 = new Gizmox.WebGUI.Forms.Panel();
            this.lblGrillaOrigen = new Gizmox.WebGUI.Forms.Label();
            this.panel3 = new Gizmox.WebGUI.Forms.Panel();
            this.grpFiltro = new Gizmox.WebGUI.Forms.GroupBox();
            this.btnFiltrar = new Gizmox.WebGUI.Forms.Button();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.btnCancelar = new Gizmox.WebGUI.Forms.Button();
            this.btnAceptar = new Gizmox.WebGUI.Forms.Button();
            this.contextMenuStrip1 = new Gizmox.WebGUI.Forms.ContextMenuStrip(this.components);
            this.tSMIBorrar = new Gizmox.WebGUI.Forms.ToolStripMenuItem();
            this.toolTip1 = new Gizmox.WebGUI.Forms.ToolTip();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDestino)).BeginInit();
            this.panel9.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrigen)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel3.SuspendLayout();
            this.grpFiltro.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 512);
            this.panel1.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel6.Controls.Add(this.btnAgregarSeleccion);
            this.panel6.Controls.Add(this.btnEliminarSeleccion);
            this.panel6.Controls.Add(this.btnEliminarTodo);
            this.panel6.Controls.Add(this.cbMarcarTodo);
            this.panel6.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 245);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1008, 41);
            this.panel6.TabIndex = 4;
            // 
            // btnAgregarSeleccion
            // 
            this.btnAgregarSeleccion.BackColor = System.Drawing.Color.Transparent;
            this.btnAgregarSeleccion.CustomStyle = "F";
            this.btnAgregarSeleccion.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnAgregarSeleccion.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnAgregarSeleccion.Image"));
            this.btnAgregarSeleccion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarSeleccion.Location = new System.Drawing.Point(119, 1);
            this.btnAgregarSeleccion.Name = "btnAgregarSeleccion";
            this.btnAgregarSeleccion.Size = new System.Drawing.Size(89, 39);
            this.btnAgregarSeleccion.TabIndex = 0;
            this.btnAgregarSeleccion.Text = "Agregar";
            this.btnAgregarSeleccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnAgregarSeleccion, "Agregar Filas Seleccionadas");
            this.btnAgregarSeleccion.Click += new System.EventHandler(this.btnAgregarSeleccion_Click);
            // 
            // btnEliminarSeleccion
            // 
            this.btnEliminarSeleccion.BackColor = System.Drawing.Color.Transparent;
            this.btnEliminarSeleccion.CustomStyle = "F";
            this.btnEliminarSeleccion.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnEliminarSeleccion.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnEliminarSeleccion.Image"));
            this.btnEliminarSeleccion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarSeleccion.Location = new System.Drawing.Point(787, 1);
            this.btnEliminarSeleccion.Name = "btnEliminarSeleccion";
            this.btnEliminarSeleccion.Size = new System.Drawing.Size(89, 39);
            this.btnEliminarSeleccion.TabIndex = 0;
            this.btnEliminarSeleccion.Text = "Eliminar";
            this.btnEliminarSeleccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminarSeleccion.Click += new System.EventHandler(this.btnEliminarSeleccion_Click);
            // 
            // btnEliminarTodo
            // 
            this.btnEliminarTodo.AutoSize = true;
            this.btnEliminarTodo.BackColor = System.Drawing.Color.Transparent;
            this.btnEliminarTodo.CustomStyle = "F";
            this.btnEliminarTodo.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnEliminarTodo.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnEliminarTodo.Image"));
            this.btnEliminarTodo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarTodo.Location = new System.Drawing.Point(880, 0);
            this.btnEliminarTodo.Name = "btnEliminarTodo";
            this.btnEliminarTodo.Size = new System.Drawing.Size(109, 40);
            this.btnEliminarTodo.TabIndex = 1;
            this.btnEliminarTodo.Text = "Eliminar Todo";
            this.btnEliminarTodo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnEliminarTodo, "Eliminar Todas las Filas de Grilla Inferior");
            this.btnEliminarTodo.Click += new System.EventHandler(this.btnEliminarTodo_Click);
            // 
            // cbMarcarTodo
            // 
            this.cbMarcarTodo.AutoSize = true;
            this.cbMarcarTodo.Location = new System.Drawing.Point(9, 11);
            this.cbMarcarTodo.Name = "cbMarcarTodo";
            this.cbMarcarTodo.Size = new System.Drawing.Size(105, 17);
            this.cbMarcarTodo.TabIndex = 6;
            this.cbMarcarTodo.Text = "Seleccionar todo";
            this.cbMarcarTodo.CheckedChanged += new System.EventHandler(this.cbMarcarTodo_CheckedChanged);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel10);
            this.panel5.Controls.Add(this.panel9);
            this.panel5.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 286);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1008, 180);
            this.panel5.TabIndex = 3;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.dgvDestino);
            this.panel10.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(0, 20);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(1008, 160);
            this.panel10.TabIndex = 1;
            // 
            // dgvDestino
            // 
            this.dgvDestino.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.dgvDestino.Location = new System.Drawing.Point(0, 0);
            this.dgvDestino.Name = "dgvDestino";
            this.dgvDestino.Size = new System.Drawing.Size(1008, 160);
            this.dgvDestino.TabIndex = 11;
            // 
            // panel9
            // 
            this.panel9.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.CornflowerBlue);
            this.panel9.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.panel9.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0, 0, 0, 1);
            this.panel9.Controls.Add(this.lblGrillaDestino);
            this.panel9.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1008, 20);
            this.panel9.TabIndex = 0;
            // 
            // lblGrillaDestino
            // 
            this.lblGrillaDestino.AutoSize = true;
            this.lblGrillaDestino.Font = new System.Drawing.Font("Arial", 9.5F);
            this.lblGrillaDestino.Location = new System.Drawing.Point(0, 2);
            this.lblGrillaDestino.Name = "lblGrillaDestino";
            this.lblGrillaDestino.Size = new System.Drawing.Size(80, 16);
            this.lblGrillaDestino.TabIndex = 1;
            this.lblGrillaDestino.Text = "Grilla Destino";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel8);
            this.panel4.Controls.Add(this.panel7);
            this.panel4.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 117);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1008, 128);
            this.panel4.TabIndex = 2;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.dgvOrigen);
            this.panel8.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 20);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1008, 108);
            this.panel8.TabIndex = 2;
            // 
            // dgvOrigen
            // 
            this.dgvOrigen.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.dgvOrigen.Location = new System.Drawing.Point(0, 0);
            this.dgvOrigen.Name = "dgvOrigen";
            this.dgvOrigen.Size = new System.Drawing.Size(1008, 108);
            this.dgvOrigen.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.CornflowerBlue);
            this.panel7.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.panel7.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0, 0, 0, 1);
            this.panel7.Controls.Add(this.lblGrillaOrigen);
            this.panel7.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1008, 20);
            this.panel7.TabIndex = 1;
            // 
            // lblGrillaOrigen
            // 
            this.lblGrillaOrigen.AutoSize = true;
            this.lblGrillaOrigen.Font = new System.Drawing.Font("Arial", 9.5F);
            this.lblGrillaOrigen.Location = new System.Drawing.Point(0, 2);
            this.lblGrillaOrigen.Name = "lblGrillaOrigen";
            this.lblGrillaOrigen.Size = new System.Drawing.Size(80, 16);
            this.lblGrillaOrigen.TabIndex = 1;
            this.lblGrillaOrigen.Text = "Grilla Origen";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel3.Controls.Add(this.grpFiltro);
            this.panel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1008, 117);
            this.panel3.TabIndex = 1;
            // 
            // grpFiltro
            // 
            this.grpFiltro.Controls.Add(this.btnFiltrar);
            this.grpFiltro.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.grpFiltro.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.grpFiltro.ForeColor = System.Drawing.Color.Black;
            this.grpFiltro.Location = new System.Drawing.Point(0, 0);
            this.grpFiltro.Name = "grpFiltro";
            this.grpFiltro.Size = new System.Drawing.Size(1008, 117);
            this.grpFiltro.TabIndex = 0;
            this.grpFiltro.TabStop = false;
            this.grpFiltro.Text = "Filtros";
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnFiltrar.Image"));
            this.btnFiltrar.Location = new System.Drawing.Point(916, 63);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(40, 40);
            this.btnFiltrar.TabIndex = 10;
            this.toolTip1.SetToolTip(this.btnFiltrar, "Aplicar Filtros");
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click_1);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel2.Controls.Add(this.btnCancelar);
            this.panel2.Controls.Add(this.btnAceptar);
            this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 466);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1008, 46);
            this.panel2.TabIndex = 0;
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
            this.btnCancelar.Location = new System.Drawing.Point(540, 5);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 36);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
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
            this.btnAceptar.Location = new System.Drawing.Point(384, 5);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(85, 36);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // FSeleccionarGrilla
            // 
            this.Controls.Add(this.panel1);
            this.Size = new System.Drawing.Size(1008, 512);
            this.Text = "FSeleccionarGrilla";
            this.Load += new System.EventHandler(this.FSeleccionarGrilla_Load);
            this.VisibleChanged += new System.EventHandler(this.FSeleccionarGrilla_VisibleChanged);
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDestino)).EndInit();
            this.panel9.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrigen)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.grpFiltro.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public Panel panel1;
        public Panel panel3;
        public Panel panel2;
        public Panel panel5;
        public Panel panel4;
        public Panel panel6;
        private Label lblGrillaOrigen;
        public Panel panel8;
        public DataGridView dgvOrigen;
        private Label lblGrillaDestino;
        public Button btnFiltrar;
        public GroupBox grpFiltro;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem tSMIBorrar;
        public Panel panel7;
        public Button btnCancelar;
        public Button btnAceptar;
        public CheckBox cbMarcarTodo;
        public Button btnEliminarTodo;
        public Button btnAgregarSeleccion;
        public Button btnEliminarSeleccion;
        protected ToolTip toolTip1;
        public Panel panel9;
        public DataGridView dgvDestino;
        public Panel panel10;


    }
}