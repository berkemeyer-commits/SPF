using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.UserControls.UI
{
    partial class ucCRUDRoles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucCRUDRoles));
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.txtRolID = new Gizmox.WebGUI.Forms.TextBox();
            this.label7 = new Gizmox.WebGUI.Forms.Label();
            this.txtDescripcion = new Gizmox.WebGUI.Forms.TextBox();
            this.chkEsAdministrador = new Gizmox.WebGUI.Forms.CheckBox();
            this.tpPermisos = new Gizmox.WebGUI.Forms.TabPage();
            this.pnlPermisos = new Gizmox.WebGUI.Forms.Panel();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.dgvDetPermisos = new Gizmox.WebGUI.Forms.DataGridView();
            this.panel6 = new Gizmox.WebGUI.Forms.Panel();
            this.panel5 = new Gizmox.WebGUI.Forms.Panel();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.panel3 = new Gizmox.WebGUI.Forms.Panel();
            this.btnAsignarPermisosEspeciales = new Gizmox.WebGUI.Forms.Button();
            this.btnEliminarPermiso = new Gizmox.WebGUI.Forms.Button();
            this.btnAgregarPermiso = new Gizmox.WebGUI.Forms.Button();
            this.tpMenues = new Gizmox.WebGUI.Forms.TabPage();
            this.panel17 = new Gizmox.WebGUI.Forms.Panel();
            this.panel15 = new Gizmox.WebGUI.Forms.Panel();
            this.tvAccesos = new Gizmox.WebGUI.Forms.TreeView();
            this.panel12 = new Gizmox.WebGUI.Forms.Panel();
            this.panel13 = new Gizmox.WebGUI.Forms.Panel();
            this.panel14 = new Gizmox.WebGUI.Forms.Panel();
            this.panel16 = new Gizmox.WebGUI.Forms.Panel();
            this.btnExpandirColapsar = new Gizmox.WebGUI.Forms.Button();
            this.btnEliminarMenu = new Gizmox.WebGUI.Forms.Button();
            this.btnAgregarMenu = new Gizmox.WebGUI.Forms.Button();
            this.dataGridView1 = new Gizmox.WebGUI.Forms.DataGridView();
            this.panel4 = new Gizmox.WebGUI.Forms.Panel();
            this.panel7 = new Gizmox.WebGUI.Forms.Panel();
            this.panel8 = new Gizmox.WebGUI.Forms.Panel();
            this.panel9 = new Gizmox.WebGUI.Forms.Panel();
            this.button1 = new Gizmox.WebGUI.Forms.Button();
            this.button2 = new Gizmox.WebGUI.Forms.Button();
            this.panel10 = new Gizmox.WebGUI.Forms.Panel();
            this.panel11 = new Gizmox.WebGUI.Forms.Panel();
            this.tabPage1 = new Gizmox.WebGUI.Forms.TabPage();
            this.chkRequierePermisosEspeciales = new Gizmox.WebGUI.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoABM)).BeginInit();
            this.pnlDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabListaABM)).BeginInit();
            this.tabListaABM.SuspendLayout();
            this.tpDetalle.SuspendLayout();
            this.tpPermisos.SuspendLayout();
            this.pnlPermisos.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetPermisos)).BeginInit();
            this.panel3.SuspendLayout();
            this.tpMenues.SuspendLayout();
            this.panel17.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel11.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvListadoABM
            // 
            this.dgvListadoABM.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.dgvListadoABM.Size = new System.Drawing.Size(1094, 339);
            // 
            // tbbEditar
            // 
            this.tbbEditar.Click += new System.EventHandler(this.tbbEditar_Click);
            // 
            // tbbCancelar
            // 
            this.tbbCancelar.Click += new System.EventHandler(this.tbbCancelar_Click);
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.Controls.Add(this.chkRequierePermisosEspeciales);
            this.pnlDetalle.Controls.Add(this.chkEsAdministrador);
            this.pnlDetalle.Controls.Add(this.txtDescripcion);
            this.pnlDetalle.Controls.Add(this.label7);
            this.pnlDetalle.Controls.Add(this.txtRolID);
            this.pnlDetalle.Controls.Add(this.label1);
            this.pnlDetalle.Size = new System.Drawing.Size(1114, 359);
            // 
            // tBBaseForm
            // 
            this.tBBaseForm.Size = new System.Drawing.Size(1122, 42);
            // 
            // tbbNuevo
            // 
            this.tbbNuevo.Click += new System.EventHandler(this.tbbNuevo_Click);
            // 
            // tabListaABM
            // 
            this.tabListaABM.Alignment = Gizmox.WebGUI.Forms.TabAlignment.Top;
            this.tabListaABM.Controls.Add(this.tpMenues);
            this.tabListaABM.Controls.Add(this.tpPermisos);
            this.tabListaABM.Size = new System.Drawing.Size(1122, 388);
            this.tabListaABM.SelectedIndexChanged += new System.EventHandler(this.tabListaABM_SelectedIndexChanged);
            this.tabListaABM.Controls.SetChildIndex(this.tpPermisos, 0);
            this.tabListaABM.Controls.SetChildIndex(this.tpMenues, 0);
            this.tabListaABM.Controls.SetChildIndex(this.tpDetalle, 0);
            this.tabListaABM.Controls.SetChildIndex(this.tpListado, 0);
            // 
            // tpDetalle
            // 
            this.tpDetalle.Size = new System.Drawing.Size(1114, 359);
            this.tpDetalle.Text = "Roles - Detalle";
            // 
            // tpListado
            // 
            this.tpListado.Size = new System.Drawing.Size(1114, 359);
            this.tpListado.Text = "Roles - Listado";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "ID Rol";
            // 
            // txtRolID
            // 
            this.txtRolID.BackColor = System.Drawing.SystemColors.Control;
            this.txtRolID.Location = new System.Drawing.Point(159, 26);
            this.txtRolID.Name = "txtRolID";
            this.txtRolID.ReadOnly = true;
            this.txtRolID.Size = new System.Drawing.Size(58, 20);
            this.txtRolID.TabIndex = 1;
            this.txtRolID.TabStop = false;
            this.txtRolID.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(67, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Descripción";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(159, 50);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(294, 20);
            this.txtDescripcion.TabIndex = 0;
            // 
            // chkEsAdministrador
            // 
            this.chkEsAdministrador.AutoSize = true;
            this.chkEsAdministrador.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkEsAdministrador.Location = new System.Drawing.Point(333, 28);
            this.chkEsAdministrador.Name = "chkEsAdministrador";
            this.chkEsAdministrador.Size = new System.Drawing.Size(106, 17);
            this.chkEsAdministrador.TabIndex = 1;
            this.chkEsAdministrador.Text = "Es Administrador";
            // 
            // tpPermisos
            // 
            this.tpPermisos.Controls.Add(this.pnlPermisos);
            this.tpPermisos.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tpPermisos.Location = new System.Drawing.Point(0, 0);
            this.tpPermisos.Name = "tpPermisos";
            this.tpPermisos.Size = new System.Drawing.Size(1114, 359);
            this.tpPermisos.TabIndex = 3;
            this.tpPermisos.Text = "Permisos del Rol";
            // 
            // pnlPermisos
            // 
            this.pnlPermisos.Controls.Add(this.panel1);
            this.pnlPermisos.Controls.Add(this.panel3);
            this.pnlPermisos.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.pnlPermisos.Location = new System.Drawing.Point(0, 0);
            this.pnlPermisos.Name = "pnlPermisos";
            this.pnlPermisos.Size = new System.Drawing.Size(1114, 359);
            this.pnlPermisos.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvDetPermisos);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1114, 311);
            this.panel1.TabIndex = 1;
            // 
            // dgvDetPermisos
            // 
            this.dgvDetPermisos.AllowUserToAddRows = false;
            this.dgvDetPermisos.AllowUserToDeleteRows = false;
            this.dgvDetPermisos.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.dgvDetPermisos.Location = new System.Drawing.Point(10, 0);
            this.dgvDetPermisos.Name = "dgvDetPermisos";
            this.dgvDetPermisos.Size = new System.Drawing.Size(1094, 301);
            this.dgvDetPermisos.TabIndex = 0;
            this.dgvDetPermisos.CurrentCellChanged += new System.EventHandler(this.dgvDetPermisos_CurrentCellChanged);
            // 
            // panel6
            // 
            this.panel6.Dock = Gizmox.WebGUI.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(1104, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(10, 301);
            this.panel6.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(10, 301);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1104, 10);
            this.panel5.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 311);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnAsignarPermisosEspeciales);
            this.panel3.Controls.Add(this.btnEliminarPermiso);
            this.panel3.Controls.Add(this.btnAgregarPermiso);
            this.panel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1114, 48);
            this.panel3.TabIndex = 0;
            // 
            // btnAsignarPermisosEspeciales
            // 
            this.btnAsignarPermisosEspeciales.BackColor = System.Drawing.Color.Transparent;
            this.btnAsignarPermisosEspeciales.CustomStyle = "F";
            this.btnAsignarPermisosEspeciales.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnAsignarPermisosEspeciales.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnAsignarPermisosEspeciales.Image"));
            this.btnAsignarPermisosEspeciales.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAsignarPermisosEspeciales.Location = new System.Drawing.Point(290, 4);
            this.btnAsignarPermisosEspeciales.Name = "btnAsignarPermisosEspeciales";
            this.btnAsignarPermisosEspeciales.Size = new System.Drawing.Size(131, 39);
            this.btnAsignarPermisosEspeciales.TabIndex = 0;
            this.btnAsignarPermisosEspeciales.Text = "Asignar Permisos Especiales";
            this.btnAsignarPermisosEspeciales.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAsignarPermisosEspeciales.Click += new System.EventHandler(this.btnAsignarPermisosEspeciales_Click);
            // 
            // btnEliminarPermiso
            // 
            this.btnEliminarPermiso.BackColor = System.Drawing.Color.Transparent;
            this.btnEliminarPermiso.CustomStyle = "F";
            this.btnEliminarPermiso.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnEliminarPermiso.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnEliminarPermiso.Image"));
            this.btnEliminarPermiso.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarPermiso.Location = new System.Drawing.Point(150, 4);
            this.btnEliminarPermiso.Name = "btnEliminarPermiso";
            this.btnEliminarPermiso.Size = new System.Drawing.Size(131, 39);
            this.btnEliminarPermiso.TabIndex = 0;
            this.btnEliminarPermiso.Text = "Eliminar Permiso";
            this.btnEliminarPermiso.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminarPermiso.Click += new System.EventHandler(this.btnEliminarDetalle_Click);
            // 
            // btnAgregarPermiso
            // 
            this.btnAgregarPermiso.BackColor = System.Drawing.Color.Transparent;
            this.btnAgregarPermiso.CustomStyle = "F";
            this.btnAgregarPermiso.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnAgregarPermiso.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnAgregarPermiso.Image"));
            this.btnAgregarPermiso.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarPermiso.Location = new System.Drawing.Point(10, 4);
            this.btnAgregarPermiso.Name = "btnAgregarPermiso";
            this.btnAgregarPermiso.Size = new System.Drawing.Size(131, 39);
            this.btnAgregarPermiso.TabIndex = 0;
            this.btnAgregarPermiso.Text = "Agregar Permiso";
            this.btnAgregarPermiso.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarPermiso.Click += new System.EventHandler(this.btnAgregarDetalle_Click);
            // 
            // tpMenues
            // 
            this.tpMenues.Controls.Add(this.panel17);
            this.tpMenues.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tpMenues.Location = new System.Drawing.Point(0, 0);
            this.tpMenues.Name = "tpMenues";
            this.tpMenues.Size = new System.Drawing.Size(1114, 359);
            this.tpMenues.TabIndex = 2;
            this.tpMenues.Text = "Accesos del Rol";
            // 
            // panel17
            // 
            this.panel17.Controls.Add(this.panel15);
            this.panel17.Controls.Add(this.panel16);
            this.panel17.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel17.Location = new System.Drawing.Point(0, 0);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(1114, 359);
            this.panel17.TabIndex = 0;
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.tvAccesos);
            this.panel15.Controls.Add(this.panel12);
            this.panel15.Controls.Add(this.panel13);
            this.panel15.Controls.Add(this.panel14);
            this.panel15.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel15.Location = new System.Drawing.Point(0, 48);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(1114, 311);
            this.panel15.TabIndex = 1;
            // 
            // tvAccesos
            // 
            this.tvAccesos.BackColor = System.Drawing.Color.White;
            this.tvAccesos.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tvAccesos.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.tvAccesos.Location = new System.Drawing.Point(10, 0);
            this.tvAccesos.Name = "tvAccesos";
            this.tvAccesos.Size = new System.Drawing.Size(1094, 301);
            this.tvAccesos.TabIndex = 4;
            // 
            // panel12
            // 
            this.panel12.Dock = Gizmox.WebGUI.Forms.DockStyle.Right;
            this.panel12.Location = new System.Drawing.Point(1104, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(10, 301);
            this.panel12.TabIndex = 3;
            // 
            // panel13
            // 
            this.panel13.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.panel13.Location = new System.Drawing.Point(10, 301);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(1104, 10);
            this.panel13.TabIndex = 2;
            // 
            // panel14
            // 
            this.panel14.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.panel14.Location = new System.Drawing.Point(0, 0);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(10, 311);
            this.panel14.TabIndex = 0;
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.btnExpandirColapsar);
            this.panel16.Controls.Add(this.btnEliminarMenu);
            this.panel16.Controls.Add(this.btnAgregarMenu);
            this.panel16.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel16.Location = new System.Drawing.Point(0, 0);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(1114, 48);
            this.panel16.TabIndex = 0;
            // 
            // btnExpandirColapsar
            // 
            this.btnExpandirColapsar.BackColor = System.Drawing.Color.Transparent;
            this.btnExpandirColapsar.CustomStyle = "F";
            this.btnExpandirColapsar.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnExpandirColapsar.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnExpandirColapsar.Image"));
            this.btnExpandirColapsar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExpandirColapsar.Location = new System.Drawing.Point(10, 4);
            this.btnExpandirColapsar.Name = "btnExpandirColapsar";
            this.btnExpandirColapsar.Size = new System.Drawing.Size(115, 39);
            this.btnExpandirColapsar.TabIndex = 0;
            this.btnExpandirColapsar.Text = "Colapsar Todo";
            this.btnExpandirColapsar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExpandirColapsar.Click += new System.EventHandler(this.btnExpandirColapsar_Click);
            // 
            // btnEliminarMenu
            // 
            this.btnEliminarMenu.BackColor = System.Drawing.Color.Transparent;
            this.btnEliminarMenu.CustomStyle = "F";
            this.btnEliminarMenu.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnEliminarMenu.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnEliminarMenu.Image"));
            this.btnEliminarMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarMenu.Location = new System.Drawing.Point(248, 4);
            this.btnEliminarMenu.Name = "btnEliminarMenu";
            this.btnEliminarMenu.Size = new System.Drawing.Size(115, 39);
            this.btnEliminarMenu.TabIndex = 0;
            this.btnEliminarMenu.Text = "Eliminar Menú";
            this.btnEliminarMenu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminarMenu.Click += new System.EventHandler(this.btnEliminarDetalle_Click);
            // 
            // btnAgregarMenu
            // 
            this.btnAgregarMenu.BackColor = System.Drawing.Color.Transparent;
            this.btnAgregarMenu.CustomStyle = "F";
            this.btnAgregarMenu.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnAgregarMenu.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnAgregarMenu.Image"));
            this.btnAgregarMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarMenu.Location = new System.Drawing.Point(129, 4);
            this.btnAgregarMenu.Name = "btnAgregarMenu";
            this.btnAgregarMenu.Size = new System.Drawing.Size(115, 39);
            this.btnAgregarMenu.TabIndex = 0;
            this.btnAgregarMenu.Text = "Agregar Menú";
            this.btnAgregarMenu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarMenu.Click += new System.EventHandler(this.btnAgregarDetalle_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(10, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1094, 301);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.RowEnter += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.dgvDetPermisos_RowEnter);
            // 
            // panel4
            // 
            this.panel4.Dock = Gizmox.WebGUI.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(1104, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(10, 301);
            this.panel4.TabIndex = 3;
            // 
            // panel7
            // 
            this.panel7.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(10, 301);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1104, 10);
            this.panel7.TabIndex = 2;
            // 
            // panel8
            // 
            this.panel8.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(10, 311);
            this.panel8.TabIndex = 0;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.dataGridView1);
            this.panel9.Controls.Add(this.panel4);
            this.panel9.Controls.Add(this.panel7);
            this.panel9.Controls.Add(this.panel8);
            this.panel9.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(0, 48);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1114, 311);
            this.panel9.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.CustomStyle = "F";
            this.button1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.button1.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("button1.Image"));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(150, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 39);
            this.button1.TabIndex = 0;
            this.button1.Text = "Eliminar Permiso";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Click += new System.EventHandler(this.btnEliminarDetalle_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.CustomStyle = "F";
            this.button2.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.button2.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("button2.Image"));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(10, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(131, 39);
            this.button2.TabIndex = 0;
            this.button2.Text = "Agregar Permiso";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.Click += new System.EventHandler(this.btnAgregarDetalle_Click);
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.button1);
            this.panel10.Controls.Add(this.button2);
            this.panel10.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(1114, 48);
            this.panel10.TabIndex = 0;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.panel9);
            this.panel11.Controls.Add(this.panel10);
            this.panel11.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(1114, 359);
            this.panel11.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel11);
            this.tabPage1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1114, 359);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Permisos";
            // 
            // chkRequierePermisosEspeciales
            // 
            this.chkRequierePermisosEspeciales.AutoSize = true;
            this.chkRequierePermisosEspeciales.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkRequierePermisosEspeciales.Location = new System.Drawing.Point(257, 76);
            this.chkRequierePermisosEspeciales.Name = "chkRequierePermisosEspeciales";
            this.chkRequierePermisosEspeciales.Size = new System.Drawing.Size(166, 17);
            this.chkRequierePermisosEspeciales.TabIndex = 1;
            this.chkRequierePermisosEspeciales.Text = "Requiere Permisos Especiales";
            // 
            // ucCRUDRoles
            // 
            this.Size = new System.Drawing.Size(1124, 466);
            this.Text = "ucCRUDBancos";
            this.TituloDetalle = "Roles - Detalle";
            this.TituloTabListado = "Roles - Listado";
            this.VisibleChanged += new System.EventHandler(this.ucCRUDMovimientoCuenta_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoABM)).EndInit();
            this.pnlDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabListaABM)).EndInit();
            this.tabListaABM.ResumeLayout(false);
            this.tpDetalle.ResumeLayout(false);
            this.tpPermisos.ResumeLayout(false);
            this.pnlPermisos.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetPermisos)).EndInit();
            this.panel3.ResumeLayout(false);
            this.tpMenues.ResumeLayout(false);
            this.panel17.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel9.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TextBox txtRolID;
        private Label label1;
        private Label label7;
        private CheckBox chkEsAdministrador;
        private TextBox txtDescripcion;
        private TabPage tpPermisos;
        private Panel pnlPermisos;
        private Panel panel1;
        private DataGridView dgvDetPermisos;
        private Panel panel6;
        private Panel panel5;
        private Panel panel2;
        private Panel panel3;
        private Button btnEliminarPermiso;
        private Button btnAgregarPermiso;
        private TabPage tpMenues;
        private Panel panel17;
        private Panel panel15;
        private Panel panel12;
        private Panel panel13;
        private Panel panel14;
        private Panel panel16;
        private Button btnEliminarMenu;
        private Button btnAgregarMenu;
        private TabPage tabPage1;
        private Panel panel11;
        private Panel panel9;
        private DataGridView dataGridView1;
        private Panel panel4;
        private Panel panel7;
        private Panel panel8;
        private Panel panel10;
        private Button button1;
        private Button button2;
        private TreeView tvAccesos;
        private Button btnExpandirColapsar;
        private CheckBox chkRequierePermisosEspeciales;
        private Button btnAsignarPermisosEspeciales;


    }
}