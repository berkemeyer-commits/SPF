using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.UserControls.Base
{
    partial class ucBaseForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucBaseForm));
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.pnlTitulo = new Gizmox.WebGUI.Forms.Panel();
            this.pnlTB = new Gizmox.WebGUI.Forms.Panel();
            this.tBBaseForm = new Gizmox.WebGUI.Forms.ToolBar();
            this.Sep0 = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.tbbBuscar = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.Sep1 = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.tbbNuevo = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.tbbEditar = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.tbbBorrar = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.tbbImprimir = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.tbbExportarExcel = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.Sep2 = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.tbbGuardar = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.tbbCancelar = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.Sep3 = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.tbbFirst = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.tbbPrior = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.tbbNext = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.tbbLast = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.Sep4 = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.tbbCerrar = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.Sep5 = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.lblTitulo = new Gizmox.WebGUI.Forms.Label();
            this.txtFormEditStatus = new Gizmox.WebGUI.Forms.TextBox();
            this.dgvListadoABM = new Gizmox.WebGUI.Forms.DataGridView();
            this.pnlListadoContainer = new Gizmox.WebGUI.Forms.Panel();
            this.dgvExportarExcel = new Gizmox.WebGUI.Forms.DataGridView();
            this.pnlContainer = new Gizmox.WebGUI.Forms.Panel();
            this.pnlBottom = new Gizmox.WebGUI.Forms.Panel();
            this.pnlTop = new Gizmox.WebGUI.Forms.Panel();
            this.pnlRight = new Gizmox.WebGUI.Forms.Panel();
            this.pnlLeft = new Gizmox.WebGUI.Forms.Panel();
            this.tpListado = new Gizmox.WebGUI.Forms.TabPage();
            this.tpDetalle = new Gizmox.WebGUI.Forms.TabPage();
            this.pnlDetalle = new Gizmox.WebGUI.Forms.Panel();
            this.tabListaABM = new Gizmox.WebGUI.Forms.TabControl();
            this.pnlTabControl = new Gizmox.WebGUI.Forms.Panel();
            this.pnlBack = new Gizmox.WebGUI.Forms.Panel();
            this.tTBaseForm = new Gizmox.WebGUI.Forms.ToolTip();
            this.panel3 = new Gizmox.WebGUI.Forms.Panel();
            this.clientStorage1 = new Gizmox.WebGUI.Forms.Client.ClientStorage();
            this.iLBaseForm = new Gizmox.WebGUI.Forms.ImageList(this.components);
            this.pnlTitulo.SuspendLayout();
            this.pnlTB.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoABM)).BeginInit();
            this.pnlListadoContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExportarExcel)).BeginInit();
            this.pnlContainer.SuspendLayout();
            this.tpListado.SuspendLayout();
            this.tpDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabListaABM)).BeginInit();
            this.tabListaABM.SuspendLayout();
            this.pnlTabControl.SuspendLayout();
            this.pnlBack.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTitulo
            // 
            this.pnlTitulo.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.CornflowerBlue);
            this.pnlTitulo.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.pnlTitulo.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0, 0, 0, 1);
            this.pnlTitulo.Controls.Add(this.pnlTB);
            this.pnlTitulo.Controls.Add(this.panel2);
            this.pnlTitulo.Controls.Add(this.panel1);
            this.pnlTitulo.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.pnlTitulo.Location = new System.Drawing.Point(0, 0);
            this.pnlTitulo.Name = "pnlTitulo";
            this.pnlTitulo.Size = new System.Drawing.Size(1120, 76);
            this.pnlTitulo.TabIndex = 0;
            // 
            // pnlTB
            // 
            this.pnlTB.BackColor = System.Drawing.Color.CornflowerBlue;
            this.pnlTB.Controls.Add(this.tBBaseForm);
            this.pnlTB.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.pnlTB.Location = new System.Drawing.Point(0, 30);
            this.pnlTB.Name = "pnlTB";
            this.pnlTB.Size = new System.Drawing.Size(1118, 34);
            this.pnlTB.TabIndex = 3;
            // 
            // tBBaseForm
            // 
            this.tBBaseForm.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.CornflowerBlue);
            this.tBBaseForm.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.tBBaseForm.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0, 1, 0, 1);
            this.tBBaseForm.Buttons.AddRange(new Gizmox.WebGUI.Forms.ToolBarButton[] {
            this.Sep0,
            this.tbbBuscar,
            this.Sep1,
            this.tbbNuevo,
            this.tbbEditar,
            this.tbbBorrar,
            this.tbbImprimir,
            this.tbbExportarExcel,
            this.Sep2,
            this.tbbGuardar,
            this.tbbCancelar,
            this.Sep3,
            this.tbbFirst,
            this.tbbPrior,
            this.tbbNext,
            this.tbbLast,
            this.Sep4,
            this.tbbCerrar,
            this.Sep5});
            this.tBBaseForm.ButtonSize = new System.Drawing.Size(32, 32);
            this.tBBaseForm.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tBBaseForm.DragHandle = true;
            this.tBBaseForm.DropDownArrows = true;
            this.tBBaseForm.ImageSize = new System.Drawing.Size(32, 32);
            this.tBBaseForm.Location = new System.Drawing.Point(0, 0);
            this.tBBaseForm.Margin = new Gizmox.WebGUI.Forms.Padding(0);
            this.tBBaseForm.MenuHandle = true;
            this.tBBaseForm.Name = "tBBaseForm";
            this.tBBaseForm.ShowToolTips = true;
            this.tBBaseForm.Size = new System.Drawing.Size(1118, 42);
            this.tBBaseForm.TabIndex = 0;
            this.tBBaseForm.VisualEffect = new Gizmox.WebGUI.Forms.VisualEffects.EmptyVisualEffect();
            this.tBBaseForm.ButtonClick += new Gizmox.WebGUI.Forms.ToolBarButtonClickEventHandler(this.tBBaseForm_ButtonClick);
            // 
            // Sep0
            // 
            this.Sep0.CustomStyle = "";
            this.Sep0.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Sep0.Name = "Sep0";
            this.Sep0.Size = 32;
            this.Sep0.Style = Gizmox.WebGUI.Forms.ToolBarButtonStyle.Separator;
            this.Sep0.ToolTipText = "";
            // 
            // tbbBuscar
            // 
            this.tbbBuscar.CustomStyle = "";
            this.tbbBuscar.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tbbBuscar.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("tbbBuscar.Image"));
            this.tbbBuscar.Name = "tbbBuscar";
            this.tbbBuscar.Size = 32;
            this.tbbBuscar.Style = Gizmox.WebGUI.Forms.ToolBarButtonStyle.ToggleButton;
            this.tbbBuscar.Text = "Buscar";
            this.tbbBuscar.ToolTipText = "Buscar";
            this.tbbBuscar.Click += new System.EventHandler(this.tbbBuscar_Click);
            // 
            // Sep1
            // 
            this.Sep1.CustomStyle = "";
            this.Sep1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Sep1.Name = "Sep1";
            this.Sep1.Size = 32;
            this.Sep1.Style = Gizmox.WebGUI.Forms.ToolBarButtonStyle.Separator;
            this.Sep1.ToolTipText = "";
            // 
            // tbbNuevo
            // 
            this.tbbNuevo.CustomStyle = "";
            this.tbbNuevo.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tbbNuevo.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("tbbNuevo.Image"));
            this.tbbNuevo.Name = "tbbNuevo";
            this.tbbNuevo.Size = 32;
            this.tbbNuevo.Style = Gizmox.WebGUI.Forms.ToolBarButtonStyle.ToggleButton;
            this.tbbNuevo.Text = "Nuevo";
            this.tbbNuevo.ToolTipText = "Nuevo";
            this.tbbNuevo.Click += new System.EventHandler(this.tbbNuevo_Click);
            // 
            // tbbEditar
            // 
            this.tbbEditar.CustomStyle = "";
            this.tbbEditar.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tbbEditar.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("tbbEditar.Image"));
            this.tbbEditar.Name = "tbbEditar";
            this.tbbEditar.Size = 32;
            this.tbbEditar.Style = Gizmox.WebGUI.Forms.ToolBarButtonStyle.ToggleButton;
            this.tbbEditar.Text = "Editar";
            this.tbbEditar.ToolTipText = "Editar";
            this.tbbEditar.Click += new System.EventHandler(this.tbbEditar_Click);
            // 
            // tbbBorrar
            // 
            this.tbbBorrar.CustomStyle = "";
            this.tbbBorrar.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tbbBorrar.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("tbbBorrar.Image"));
            this.tbbBorrar.Name = "tbbBorrar";
            this.tbbBorrar.Size = 32;
            this.tbbBorrar.Style = Gizmox.WebGUI.Forms.ToolBarButtonStyle.ToggleButton;
            this.tbbBorrar.Text = "Borrar";
            this.tbbBorrar.ToolTipText = "Borrar";
            this.tbbBorrar.Click += new System.EventHandler(this.tbbBorrar_Click);
            // 
            // tbbImprimir
            // 
            this.tbbImprimir.CustomStyle = "";
            this.tbbImprimir.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tbbImprimir.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("tbbImprimir.Image"));
            this.tbbImprimir.Name = "tbbImprimir";
            this.tbbImprimir.Size = 32;
            this.tbbImprimir.Style = Gizmox.WebGUI.Forms.ToolBarButtonStyle.ToggleButton;
            this.tbbImprimir.Text = "Imprimir";
            this.tbbImprimir.ToolTipText = "Imprimir";
            this.tbbImprimir.Click += new System.EventHandler(this.tbbImprimir_Click);
            // 
            // tbbExportarExcel
            // 
            this.tbbExportarExcel.CustomStyle = "";
            this.tbbExportarExcel.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tbbExportarExcel.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("tbbExportarExcel.Image"));
            this.tbbExportarExcel.Name = "tbbExportarExcel";
            this.tbbExportarExcel.Size = 24;
            this.tbbExportarExcel.Text = "EE";
            this.tbbExportarExcel.ToolTipText = "Exportar Grilla a Excel";
            this.tbbExportarExcel.Click += new System.EventHandler(this.tbbExportarExcel_Click);
            // 
            // Sep2
            // 
            this.Sep2.CustomStyle = "";
            this.Sep2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Sep2.Name = "Sep2";
            this.Sep2.Size = 32;
            this.Sep2.Style = Gizmox.WebGUI.Forms.ToolBarButtonStyle.Separator;
            this.Sep2.ToolTipText = "";
            // 
            // tbbGuardar
            // 
            this.tbbGuardar.CustomStyle = "";
            this.tbbGuardar.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tbbGuardar.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("tbbGuardar.Image"));
            this.tbbGuardar.Name = "tbbGuardar";
            this.tbbGuardar.Size = 32;
            this.tbbGuardar.Style = Gizmox.WebGUI.Forms.ToolBarButtonStyle.ToggleButton;
            this.tbbGuardar.Text = "Guardar";
            this.tbbGuardar.ToolTipText = "Guardar";
            this.tbbGuardar.Click += new System.EventHandler(this.tbbGuardar_Click);
            // 
            // tbbCancelar
            // 
            this.tbbCancelar.CustomStyle = "";
            this.tbbCancelar.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tbbCancelar.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("tbbCancelar.Image"));
            this.tbbCancelar.Name = "tbbCancelar";
            this.tbbCancelar.Size = 32;
            this.tbbCancelar.Style = Gizmox.WebGUI.Forms.ToolBarButtonStyle.ToggleButton;
            this.tbbCancelar.Tag = "Cancelar";
            this.tbbCancelar.Text = "Cancelar";
            this.tbbCancelar.ToolTipText = "";
            this.tbbCancelar.Click += new System.EventHandler(this.tbbCancelar_Click);
            // 
            // Sep3
            // 
            this.Sep3.CustomStyle = "";
            this.Sep3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Sep3.Name = "Sep3";
            this.Sep3.Size = 32;
            this.Sep3.Style = Gizmox.WebGUI.Forms.ToolBarButtonStyle.Separator;
            this.Sep3.ToolTipText = "";
            // 
            // tbbFirst
            // 
            this.tbbFirst.CustomStyle = "";
            this.tbbFirst.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tbbFirst.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("tbbFirst.Image"));
            this.tbbFirst.Name = "tbbFirst";
            this.tbbFirst.Size = 32;
            this.tbbFirst.Style = Gizmox.WebGUI.Forms.ToolBarButtonStyle.ToggleButton;
            this.tbbFirst.Text = "|<";
            this.tbbFirst.ToolTipText = "Ir al primer registro";
            this.tbbFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // tbbPrior
            // 
            this.tbbPrior.CustomStyle = "";
            this.tbbPrior.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tbbPrior.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("tbbPrior.Image"));
            this.tbbPrior.Name = "tbbPrior";
            this.tbbPrior.Size = 32;
            this.tbbPrior.Text = "<<";
            this.tbbPrior.ToolTipText = "Ir al registro anterior";
            this.tbbPrior.Click += new System.EventHandler(this.btnPrior_Click);
            // 
            // tbbNext
            // 
            this.tbbNext.CustomStyle = "";
            this.tbbNext.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tbbNext.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("tbbNext.Image"));
            this.tbbNext.Name = "tbbNext";
            this.tbbNext.Size = 32;
            this.tbbNext.Style = Gizmox.WebGUI.Forms.ToolBarButtonStyle.ToggleButton;
            this.tbbNext.Text = ">>";
            this.tbbNext.ToolTipText = "Ir al registro siguiente";
            this.tbbNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // tbbLast
            // 
            this.tbbLast.CustomStyle = "";
            this.tbbLast.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tbbLast.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("tbbLast.Image"));
            this.tbbLast.Name = "tbbLast";
            this.tbbLast.Size = 32;
            this.tbbLast.Style = Gizmox.WebGUI.Forms.ToolBarButtonStyle.ToggleButton;
            this.tbbLast.Text = ">|";
            this.tbbLast.ToolTipText = "Ir al último registro";
            this.tbbLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // Sep4
            // 
            this.Sep4.CustomStyle = "";
            this.Sep4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Sep4.Name = "Sep4";
            this.Sep4.Size = 32;
            this.Sep4.Style = Gizmox.WebGUI.Forms.ToolBarButtonStyle.Separator;
            this.Sep4.ToolTipText = "";
            // 
            // tbbCerrar
            // 
            this.tbbCerrar.CustomStyle = "";
            this.tbbCerrar.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tbbCerrar.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("tbbCerrar.Image"));
            this.tbbCerrar.Name = "tbbCerrar";
            this.tbbCerrar.Size = 32;
            this.tbbCerrar.Style = Gizmox.WebGUI.Forms.ToolBarButtonStyle.ToggleButton;
            this.tbbCerrar.Text = "Cerrar";
            this.tbbCerrar.ToolTipText = "Cerrar Formulario";
            this.tbbCerrar.Click += new System.EventHandler(this.tbbCerrar_Click);
            // 
            // Sep5
            // 
            this.Sep5.CustomStyle = "";
            this.Sep5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Sep5.Name = "Sep5";
            this.Sep5.Size = 32;
            this.Sep5.Style = Gizmox.WebGUI.Forms.ToolBarButtonStyle.Separator;
            this.Sep5.ToolTipText = "";
            // 
            // panel2
            // 
            this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 80);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1118, 10);
            this.panel2.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Controls.Add(this.txtFormEditStatus);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1118, 30);
            this.panel1.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.CornflowerBlue);
            this.lblTitulo.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblTitulo.Location = new System.Drawing.Point(1, 5);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(35, 13);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Título";
            // 
            // txtFormEditStatus
            // 
            this.txtFormEditStatus.AllowDrag = false;
            this.txtFormEditStatus.Location = new System.Drawing.Point(543, 5);
            this.txtFormEditStatus.Name = "txtFormEditStatus";
            this.txtFormEditStatus.ReadOnly = true;
            this.txtFormEditStatus.Size = new System.Drawing.Size(100, 20);
            this.txtFormEditStatus.TabIndex = 1;
            this.txtFormEditStatus.TabStop = false;
            this.txtFormEditStatus.Text = "NONE";
            this.txtFormEditStatus.Visible = false;
            this.txtFormEditStatus.TextChanged += new System.EventHandler(this.txtFormEditStatus_TextChanged);
            // 
            // dgvListadoABM
            // 
            this.dgvListadoABM.AllowUserToAddRows = false;
            this.dgvListadoABM.AllowUserToDeleteRows = false;
            this.dgvListadoABM.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.FormatProvider = new System.Globalization.CultureInfo("es-ES");
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvListadoABM.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListadoABM.BackgroundColor = System.Drawing.Color.White;
            this.dgvListadoABM.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.CornflowerBlue);
            this.dgvListadoABM.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListadoABM.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.dgvListadoABM.Location = new System.Drawing.Point(0, 0);
            this.dgvListadoABM.MultiSelect = false;
            this.dgvListadoABM.Name = "dgvListadoABM";
            this.dgvListadoABM.ReadOnly = true;
            this.dgvListadoABM.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListadoABM.Size = new System.Drawing.Size(1090, 410);
            this.dgvListadoABM.TabIndex = 0;
            this.dgvListadoABM.CellDoubleClick += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.dgvListadoABM_CellDoubleClick);
            this.dgvListadoABM.RowEnter += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.dgvListadoABM_RowEnter);
            this.dgvListadoABM.SelectionChanged += new System.EventHandler(this.dgvListadoABM_SelectionChanged);
            this.dgvListadoABM.KeyDown += new Gizmox.WebGUI.Forms.KeyEventHandler(this.dgvListadoABM_KeyDown);
            this.dgvListadoABM.KeyPress += new Gizmox.WebGUI.Forms.KeyPressEventHandler(this.dgvListadoABM_KeyPress);
            // 
            // pnlListadoContainer
            // 
            this.pnlListadoContainer.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.CornflowerBlue);
            this.pnlListadoContainer.Controls.Add(this.dgvExportarExcel);
            this.pnlListadoContainer.Controls.Add(this.dgvListadoABM);
            this.pnlListadoContainer.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.pnlListadoContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlListadoContainer.Name = "pnlListadoContainer";
            this.pnlListadoContainer.Size = new System.Drawing.Size(1090, 410);
            this.pnlListadoContainer.TabIndex = 1;
            // 
            // dgvExportarExcel
            // 
            this.dgvExportarExcel.Location = new System.Drawing.Point(710, 116);
            this.dgvExportarExcel.Name = "dgvExportarExcel";
            this.dgvExportarExcel.Size = new System.Drawing.Size(240, 150);
            this.dgvExportarExcel.TabIndex = 1;
            this.dgvExportarExcel.Visible = false;
            // 
            // pnlContainer
            // 
            this.pnlContainer.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.CornflowerBlue);
            this.pnlContainer.Controls.Add(this.pnlListadoContainer);
            this.pnlContainer.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(10, 10);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(1090, 410);
            this.pnlContainer.TabIndex = 4;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(10, 420);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1090, 10);
            this.pnlBottom.TabIndex = 3;
            // 
            // pnlTop
            // 
            this.pnlTop.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(10, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1090, 10);
            this.pnlTop.TabIndex = 2;
            // 
            // pnlRight
            // 
            this.pnlRight.Dock = Gizmox.WebGUI.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(1100, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(10, 430);
            this.pnlRight.TabIndex = 1;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(10, 430);
            this.pnlLeft.TabIndex = 0;
            // 
            // tpListado
            // 
            this.tpListado.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Transparent);
            this.tpListado.Controls.Add(this.pnlContainer);
            this.tpListado.Controls.Add(this.pnlBottom);
            this.tpListado.Controls.Add(this.pnlTop);
            this.tpListado.Controls.Add(this.pnlRight);
            this.tpListado.Controls.Add(this.pnlLeft);
            this.tpListado.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tpListado.Location = new System.Drawing.Point(0, 0);
            this.tpListado.Name = "tpListado";
            this.tpListado.Size = new System.Drawing.Size(1110, 430);
            this.tpListado.TabIndex = 0;
            this.tpListado.Text = "Listado";
            // 
            // tpDetalle
            // 
            this.tpDetalle.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Transparent);
            this.tpDetalle.Controls.Add(this.pnlDetalle);
            this.tpDetalle.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tpDetalle.Location = new System.Drawing.Point(4, 22);
            this.tpDetalle.Name = "tpDetalle";
            this.tpDetalle.Size = new System.Drawing.Size(1110, 430);
            this.tpDetalle.TabIndex = 1;
            this.tpDetalle.Text = "Detalle";
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.AutoScroll = true;
            this.pnlDetalle.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.pnlDetalle.Location = new System.Drawing.Point(0, 0);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Size = new System.Drawing.Size(1110, 379);
            this.pnlDetalle.TabIndex = 0;
            // 
            // tabListaABM
            // 
            this.tabListaABM.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.CornflowerBlue);
            this.tabListaABM.Controls.Add(this.tpListado);
            this.tabListaABM.Controls.Add(this.tpDetalle);
            this.tabListaABM.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tabListaABM.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.tabListaABM.Location = new System.Drawing.Point(0, 0);
            this.tabListaABM.Name = "tabListaABM";
            this.tabListaABM.SelectedIndex = 0;
            this.tabListaABM.Size = new System.Drawing.Size(1118, 459);
            this.tabListaABM.TabIndex = 0;
            this.tabListaABM.SelectedIndexChanging += new Gizmox.WebGUI.Forms.TabControlCancelEventHandler(this.tabListaABM_SelectedIndexChanging);
            // 
            // pnlTabControl
            // 
            this.pnlTabControl.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.CornflowerBlue);
            this.pnlTabControl.Controls.Add(this.tabListaABM);
            this.pnlTabControl.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.pnlTabControl.Location = new System.Drawing.Point(0, 0);
            this.pnlTabControl.Name = "pnlTabControl";
            this.pnlTabControl.Size = new System.Drawing.Size(1118, 459);
            this.pnlTabControl.TabIndex = 1;
            // 
            // pnlBack
            // 
            this.pnlBack.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.pnlBack.Controls.Add(this.pnlTabControl);
            this.pnlBack.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.pnlBack.Location = new System.Drawing.Point(0, 92);
            this.pnlBack.Name = "pnlBack";
            this.pnlBack.Size = new System.Drawing.Size(1120, 445);
            this.pnlBack.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(129, 32);
            this.panel3.TabIndex = 1;
            // 
            // clientStorage1
            // 
            this.clientStorage1.Description = "";
            this.clientStorage1.MajorVersion = ((ushort)(1));
            this.clientStorage1.MinorVersion = ((ushort)(0));
            // 
            // iLBaseForm
            // 
            this.iLBaseForm.Images.AddRange(new Gizmox.WebGUI.Common.Resources.ResourceHandle[] {
            new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("iLBaseForm.Images")),
            new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("iLBaseForm.Images1")),
            new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("iLBaseForm.Images2")),
            new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("iLBaseForm.Images3"))});
            this.iLBaseForm.ImageSize = new System.Drawing.Size(32, 32);
            this.iLBaseForm.Images.SetKeyName(0, "cancelar32x32.png");
            this.iLBaseForm.Images.SetKeyName(1, "cancelar32x32-inactivo.png");
            this.iLBaseForm.Images.SetKeyName(2, "editar32x32.png");
            this.iLBaseForm.Images.SetKeyName(3, "editar32x32-inactivo.png");
            // 
            // ucBaseForm
            // 
            this.Controls.Add(this.pnlBack);
            this.Controls.Add(this.pnlTitulo);
            this.Size = new System.Drawing.Size(1120, 537);
            this.Text = "ucBaseForm";
            this.Load += new System.EventHandler(this.ucBaseForm_Load);
            this.GotFocus += new System.EventHandler(this.ucBaseForm_GotFocus);
            this.VisibleChanged += new System.EventHandler(this.ucBaseForm_VisibleChanged);
            this.pnlTitulo.ResumeLayout(false);
            this.pnlTB.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoABM)).EndInit();
            this.pnlListadoContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExportarExcel)).EndInit();
            this.pnlContainer.ResumeLayout(false);
            this.tpListado.ResumeLayout(false);
            this.tpDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabListaABM)).EndInit();
            this.tabListaABM.ResumeLayout(false);
            this.pnlTabControl.ResumeLayout(false);
            this.pnlBack.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        //private TabPage tpLista1;
        private Panel pnlTitulo;
        private Panel pnlListadoContainer;
        private Panel pnlContainer;
        private Panel pnlBottom;
        private Panel pnlTop;
        private Panel pnlRight;
        private Panel pnlLeft;
        private TabPage tpListado;
        private TabPage tpDetalle;
        private Panel pnlTabControl;
        private Panel pnlBack;
        private Panel panel3;
        private Gizmox.WebGUI.Forms.Client.ClientStorage clientStorage1;
        public DataGridView dgvListadoABM;
        private ImageList iLBaseForm;
        private Panel panel1;
        private Label lblTitulo;
        private TextBox txtFormEditStatus;
        private Panel panel2;
        private Panel pnlTB;
        private ToolBarButton tbbBuscar;
        private ToolBarButton Sep1;
        private ToolBarButton Sep0;
        private ToolBarButton Sep2;
        private ToolBarButton Sep3;
        private ToolBarButton tbbFirst;
        private ToolBarButton tbbPrior;
        private ToolBarButton tbbNext;
        private ToolBarButton tbbLast;
        protected ToolBarButton tbbEditar;
        protected ToolBarButton tbbBorrar;
        protected ToolBarButton tbbImprimir;
        protected ToolBarButton tbbGuardar;
        protected ToolBarButton tbbCancelar;
        public Panel pnlDetalle;
        public ToolBar tBBaseForm;
        public ToolBarButton tbbNuevo;
        protected ToolTip tTBaseForm;
        public ToolBarButton tbbExportarExcel;
        public ToolBarButton tbbCerrar;
        public ToolBarButton Sep4;
        public ToolBarButton Sep5;
        public TabControl tabListaABM;
        private DataGridView dgvExportarExcel;
     
    }
}