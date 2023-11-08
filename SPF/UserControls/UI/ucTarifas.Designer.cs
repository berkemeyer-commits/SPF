using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace SPF.UserControls.UI
{
    partial class ucTarifas
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
            this.txtTarifaID = new Gizmox.WebGUI.Forms.TextBox();
            this.txtTarifaDescrip = new Gizmox.WebGUI.Forms.TextBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.cbMoneda = new Gizmox.WebGUI.Forms.ComboBox();
            this.cbTipoTarifa = new Gizmox.WebGUI.Forms.ComboBox();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.txtPrecioUnitario = new Gizmox.WebGUI.Forms.TextBox();
            this.txtPorcDescuento = new Gizmox.WebGUI.Forms.TextBox();
            this.label23 = new Gizmox.WebGUI.Forms.Label();
            this.txtPorcImp = new Gizmox.WebGUI.Forms.TextBox();
            this.label22 = new Gizmox.WebGUI.Forms.Label();
            this.label21 = new Gizmox.WebGUI.Forms.Label();
            this.label20 = new Gizmox.WebGUI.Forms.Label();
            this.label19 = new Gizmox.WebGUI.Forms.Label();
            this.label18 = new Gizmox.WebGUI.Forms.Label();
            this.label17 = new Gizmox.WebGUI.Forms.Label();
            this.txtMontoImp = new Gizmox.WebGUI.Forms.TextBox();
            this.label16 = new Gizmox.WebGUI.Forms.Label();
            this.txtMontoDescuento = new Gizmox.WebGUI.Forms.TextBox();
            this.label15 = new Gizmox.WebGUI.Forms.Label();
            this.cbTipoUnidadImpuesto = new Gizmox.WebGUI.Forms.ComboBox();
            this.label14 = new Gizmox.WebGUI.Forms.Label();
            this.label13 = new Gizmox.WebGUI.Forms.Label();
            this.cbTipoUnidadDescuento = new Gizmox.WebGUI.Forms.ComboBox();
            this.label12 = new Gizmox.WebGUI.Forms.Label();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.label7 = new Gizmox.WebGUI.Forms.Label();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.label8 = new Gizmox.WebGUI.Forms.Label();
            this.txtPrecioVenta = new Gizmox.WebGUI.Forms.TextBox();
            this.tSBTarifaExtID = new SPF.UserControls.Base.ucTextSearchBox();
            this.label10 = new Gizmox.WebGUI.Forms.Label();
            this.label11 = new Gizmox.WebGUI.Forms.Label();
            this.label9 = new Gizmox.WebGUI.Forms.Label();
            this.tSBProveedor = new SPF.UserControls.Base.ucTextSearchBox();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.txtDescripFactura = new Gizmox.WebGUI.Forms.TextBox();
            this.label24 = new Gizmox.WebGUI.Forms.Label();
            this.label25 = new Gizmox.WebGUI.Forms.Label();
            this.btnAsociar = new Gizmox.WebGUI.Forms.Button();
            this.label26 = new Gizmox.WebGUI.Forms.Label();
            this.label27 = new Gizmox.WebGUI.Forms.Label();
            this.tSBTarifaGastoAsoc = new SPF.UserControls.Base.ucTextSearchBox();
            this.label28 = new Gizmox.WebGUI.Forms.Label();
            this.txtGrupo = new Gizmox.WebGUI.Forms.TextBox();
            this.label29 = new Gizmox.WebGUI.Forms.Label();
            this.txtObservaciones = new Gizmox.WebGUI.Forms.TextBox();
            this.label30 = new Gizmox.WebGUI.Forms.Label();
            this.label31 = new Gizmox.WebGUI.Forms.Label();
            this.txtDescripFacturaIngles = new Gizmox.WebGUI.Forms.TextBox();
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
            this.dgvListadoABM.RowEnter += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.dgvListadoABM_RowEnter);
            // 
            // tbbEditar
            // 
            this.tbbEditar.Click += new System.EventHandler(this.tbbEditar_Click);
            // 
            // tbbBorrar
            // 
            this.tbbBorrar.Click += new System.EventHandler(this.tbbBorrar_Click_1);
            // 
            // tbbGuardar
            // 
            this.tbbGuardar.Click += new System.EventHandler(this.tbbGuardar_Click);
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.Controls.Add(this.txtDescripFacturaIngles);
            this.pnlDetalle.Controls.Add(this.label31);
            this.pnlDetalle.Controls.Add(this.label30);
            this.pnlDetalle.Controls.Add(this.txtObservaciones);
            this.pnlDetalle.Controls.Add(this.label29);
            this.pnlDetalle.Controls.Add(this.txtGrupo);
            this.pnlDetalle.Controls.Add(this.label28);
            this.pnlDetalle.Controls.Add(this.tSBTarifaGastoAsoc);
            this.pnlDetalle.Controls.Add(this.label27);
            this.pnlDetalle.Controls.Add(this.label26);
            this.pnlDetalle.Controls.Add(this.btnAsociar);
            this.pnlDetalle.Controls.Add(this.label25);
            this.pnlDetalle.Controls.Add(this.label24);
            this.pnlDetalle.Controls.Add(this.txtDescripFactura);
            this.pnlDetalle.Controls.Add(this.label4);
            this.pnlDetalle.Controls.Add(this.tSBProveedor);
            this.pnlDetalle.Controls.Add(this.label9);
            this.pnlDetalle.Controls.Add(this.label11);
            this.pnlDetalle.Controls.Add(this.label10);
            this.pnlDetalle.Controls.Add(this.tSBTarifaExtID);
            this.pnlDetalle.Controls.Add(this.txtPrecioVenta);
            this.pnlDetalle.Controls.Add(this.label8);
            this.pnlDetalle.Controls.Add(this.label5);
            this.pnlDetalle.Controls.Add(this.label7);
            this.pnlDetalle.Controls.Add(this.label6);
            this.pnlDetalle.Controls.Add(this.label12);
            this.pnlDetalle.Controls.Add(this.cbTipoUnidadDescuento);
            this.pnlDetalle.Controls.Add(this.label13);
            this.pnlDetalle.Controls.Add(this.label14);
            this.pnlDetalle.Controls.Add(this.cbTipoUnidadImpuesto);
            this.pnlDetalle.Controls.Add(this.label15);
            this.pnlDetalle.Controls.Add(this.txtMontoDescuento);
            this.pnlDetalle.Controls.Add(this.label16);
            this.pnlDetalle.Controls.Add(this.txtMontoImp);
            this.pnlDetalle.Controls.Add(this.label17);
            this.pnlDetalle.Controls.Add(this.label18);
            this.pnlDetalle.Controls.Add(this.label19);
            this.pnlDetalle.Controls.Add(this.label20);
            this.pnlDetalle.Controls.Add(this.label21);
            this.pnlDetalle.Controls.Add(this.label22);
            this.pnlDetalle.Controls.Add(this.txtPorcImp);
            this.pnlDetalle.Controls.Add(this.label23);
            this.pnlDetalle.Controls.Add(this.txtPorcDescuento);
            this.pnlDetalle.Controls.Add(this.txtPrecioUnitario);
            this.pnlDetalle.Controls.Add(this.label3);
            this.pnlDetalle.Controls.Add(this.label2);
            this.pnlDetalle.Controls.Add(this.cbTipoTarifa);
            this.pnlDetalle.Controls.Add(this.cbMoneda);
            this.pnlDetalle.Controls.Add(this.label1);
            this.pnlDetalle.Controls.Add(this.txtTarifaDescrip);
            this.pnlDetalle.Controls.Add(this.txtTarifaID);
            this.pnlDetalle.Size = new System.Drawing.Size(1099, 421);
            // 
            // tBBaseForm
            // 
            this.tBBaseForm.Size = new System.Drawing.Size(1107, 42);
            // 
            // tabListaABM
            // 
            this.tabListaABM.Alignment = Gizmox.WebGUI.Forms.TabAlignment.Top;
            this.pnlListadoContainer.Controls.SetChildIndex(this.dgvListadoABM, 0);
            // 
            // txtTarifaID
            // 
            this.txtTarifaID.AllowDrag = false;
            this.txtTarifaID.BackColor = System.Drawing.SystemColors.Control;
            this.txtTarifaID.Location = new System.Drawing.Point(130, 21);
            this.txtTarifaID.Name = "txtTarifaID";
            this.txtTarifaID.ReadOnly = true;
            this.txtTarifaID.Size = new System.Drawing.Size(100, 20);
            this.txtTarifaID.TabIndex = 0;
            this.txtTarifaID.TabStop = false;
            this.txtTarifaID.TextChanged += new System.EventHandler(this.txtTarifaID_TextChanged);
            // 
            // txtTarifaDescrip
            // 
            this.txtTarifaDescrip.AllowDrag = false;
            this.txtTarifaDescrip.Location = new System.Drawing.Point(130, 51);
            this.txtTarifaDescrip.Name = "txtTarifaDescrip";
            this.txtTarifaDescrip.Size = new System.Drawing.Size(387, 20);
            this.txtTarifaDescrip.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tarifa";
            // 
            // cbMoneda
            // 
            this.cbMoneda.AllowDrag = false;
            this.cbMoneda.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cbMoneda.FormattingEnabled = true;
            this.cbMoneda.Location = new System.Drawing.Point(130, 124);
            this.cbMoneda.Name = "cbMoneda";
            this.cbMoneda.Size = new System.Drawing.Size(195, 21);
            this.cbMoneda.TabIndex = 4;
            // 
            // cbTipoTarifa
            // 
            this.cbTipoTarifa.AllowDrag = false;
            this.cbTipoTarifa.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoTarifa.FormattingEnabled = true;
            this.cbTipoTarifa.Location = new System.Drawing.Point(610, 51);
            this.cbTipoTarifa.Name = "cbTipoTarifa";
            this.cbTipoTarifa.Size = new System.Drawing.Size(169, 21);
            this.cbTipoTarifa.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Moneda";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(540, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tipo Tarifa";
            // 
            // txtPrecioUnitario
            // 
            this.txtPrecioUnitario.AllowDrag = false;
            this.txtPrecioUnitario.BackColor = System.Drawing.SystemColors.Window;
            this.txtPrecioUnitario.Location = new System.Drawing.Point(417, 124);
            this.txtPrecioUnitario.Name = "txtPrecioUnitario";
            this.txtPrecioUnitario.Size = new System.Drawing.Size(100, 20);
            this.txtPrecioUnitario.TabIndex = 5;
            this.txtPrecioUnitario.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // txtPorcDescuento
            // 
            this.txtPorcDescuento.AllowDrag = false;
            this.txtPorcDescuento.BackColor = System.Drawing.SystemColors.Control;
            this.txtPorcDescuento.Location = new System.Drawing.Point(543, 168);
            this.txtPorcDescuento.Name = "txtPorcDescuento";
            this.txtPorcDescuento.ReadOnly = true;
            this.txtPorcDescuento.Size = new System.Drawing.Size(91, 20);
            this.txtPorcDescuento.TabIndex = 9;
            this.txtPorcDescuento.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.txtPorcDescuento.Leave += new System.EventHandler(this.txtPorcDescuento_Leave);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(465, 163);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(35, 13);
            this.label23.TabIndex = 0;
            this.label23.Text = "Porcentaje";
            // 
            // txtPorcImp
            // 
            this.txtPorcImp.AllowDrag = false;
            this.txtPorcImp.BackColor = System.Drawing.SystemColors.Control;
            this.txtPorcImp.Location = new System.Drawing.Point(543, 207);
            this.txtPorcImp.Name = "txtPorcImp";
            this.txtPorcImp.ReadOnly = true;
            this.txtPorcImp.Size = new System.Drawing.Size(91, 20);
            this.txtPorcImp.TabIndex = 12;
            this.txtPorcImp.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.txtPorcImp.Leave += new System.EventHandler(this.txtPorcImp_Leave);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(465, 204);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(35, 13);
            this.label22.TabIndex = 0;
            this.label22.Text = "Porcentaje";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(465, 176);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(35, 13);
            this.label21.TabIndex = 0;
            this.label21.Text = "Descuento";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(465, 217);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(35, 13);
            this.label20.TabIndex = 0;
            this.label20.Text = "Impuesto";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(290, 216);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(35, 13);
            this.label19.TabIndex = 0;
            this.label19.Text = "Impuesto";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(290, 175);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(35, 13);
            this.label18.TabIndex = 0;
            this.label18.Text = "Descuento";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(290, 203);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(35, 13);
            this.label17.TabIndex = 0;
            this.label17.Text = "Monto";
            // 
            // txtMontoImp
            // 
            this.txtMontoImp.AllowDrag = false;
            this.txtMontoImp.BackColor = System.Drawing.SystemColors.Control;
            this.txtMontoImp.Location = new System.Drawing.Point(358, 206);
            this.txtMontoImp.Name = "txtMontoImp";
            this.txtMontoImp.ReadOnly = true;
            this.txtMontoImp.Size = new System.Drawing.Size(91, 20);
            this.txtMontoImp.TabIndex = 11;
            this.txtMontoImp.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.txtMontoImp.Leave += new System.EventHandler(this.txtMontoImp_Leave);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(290, 162);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 13);
            this.label16.TabIndex = 0;
            this.label16.Text = "Monto";
            // 
            // txtMontoDescuento
            // 
            this.txtMontoDescuento.AllowDrag = false;
            this.txtMontoDescuento.BackColor = System.Drawing.SystemColors.Control;
            this.txtMontoDescuento.Location = new System.Drawing.Point(358, 167);
            this.txtMontoDescuento.Name = "txtMontoDescuento";
            this.txtMontoDescuento.ReadOnly = true;
            this.txtMontoDescuento.Size = new System.Drawing.Size(91, 20);
            this.txtMontoDescuento.TabIndex = 8;
            this.txtMontoDescuento.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.txtMontoDescuento.Leave += new System.EventHandler(this.txtMontoDescuento_Leave);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(46, 204);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "Tipo";
            // 
            // cbTipoUnidadImpuesto
            // 
            this.cbTipoUnidadImpuesto.BackColor = System.Drawing.SystemColors.Control;
            this.cbTipoUnidadImpuesto.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoUnidadImpuesto.Enabled = false;
            this.cbTipoUnidadImpuesto.FormattingEnabled = true;
            this.cbTipoUnidadImpuesto.Items.AddRange(new object[] {
            "Monto",
            "Porcentaje"});
            this.cbTipoUnidadImpuesto.Location = new System.Drawing.Point(130, 205);
            this.cbTipoUnidadImpuesto.Name = "cbTipoUnidadImpuesto";
            this.cbTipoUnidadImpuesto.Size = new System.Drawing.Size(147, 21);
            this.cbTipoUnidadImpuesto.TabIndex = 10;
            this.cbTipoUnidadImpuesto.SelectedIndexChanged += new System.EventHandler(this.cbTipoUnidadImpuesto_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(46, 217);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "Impuesto";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(46, 176);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Descuento";
            // 
            // cbTipoUnidadDescuento
            // 
            this.cbTipoUnidadDescuento.BackColor = System.Drawing.SystemColors.Control;
            this.cbTipoUnidadDescuento.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoUnidadDescuento.Enabled = false;
            this.cbTipoUnidadDescuento.FormattingEnabled = true;
            this.cbTipoUnidadDescuento.Items.AddRange(new object[] {
            "Monto",
            "Porcentaje"});
            this.cbTipoUnidadDescuento.Location = new System.Drawing.Point(130, 164);
            this.cbTipoUnidadDescuento.Name = "cbTipoUnidadDescuento";
            this.cbTipoUnidadDescuento.Size = new System.Drawing.Size(147, 21);
            this.cbTipoUnidadDescuento.TabIndex = 7;
            this.cbTipoUnidadDescuento.SelectedIndexChanged += new System.EventHandler(this.cbTipoUnidadDescuento_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(46, 163);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Tipo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(355, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Prec. Unit.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(355, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Costo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(540, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Venta";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(540, 123);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Prec. Unit.";
            // 
            // txtPrecioVenta
            // 
            this.txtPrecioVenta.AllowDrag = false;
            this.txtPrecioVenta.BackColor = System.Drawing.SystemColors.Window;
            this.txtPrecioVenta.Location = new System.Drawing.Point(610, 125);
            this.txtPrecioVenta.Name = "txtPrecioVenta";
            this.txtPrecioVenta.Size = new System.Drawing.Size(100, 20);
            this.txtPrecioVenta.TabIndex = 6;
            this.txtPrecioVenta.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // tSBTarifaExtID
            // 
            this.tSBTarifaExtID.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBTarifaExtID.DBContext = null;
            this.tSBTarifaExtID.DisplayMember = "";
            this.tSBTarifaExtID.KeyMember = "";
            this.tSBTarifaExtID.LabelCampoBusqueda = "";
            this.tSBTarifaExtID.Location = new System.Drawing.Point(130, 281);
            this.tSBTarifaExtID.Name = "tSBTarifaExtID";
            this.tSBTarifaExtID.NombreCampoDescrip = "";
            this.tSBTarifaExtID.NombreCampoID = "";
            this.tSBTarifaExtID.Size = new System.Drawing.Size(387, 20);
            this.tSBTarifaExtID.SoloLectura = false;
            this.tSBTarifaExtID.TabIndex = 15;
            this.tSBTarifaExtID.Text = "ucTextSearchBox";
            this.tSBTarifaExtID.TituloBuscador = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(46, 280);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "ID Tarifa";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(46, 293);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Externa";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(46, 317);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Proveedor";
            // 
            // tSBProveedor
            // 
            this.tSBProveedor.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBProveedor.DBContext = null;
            this.tSBProveedor.DisplayMember = "";
            this.tSBProveedor.KeyMember = "";
            this.tSBProveedor.LabelCampoBusqueda = "";
            this.tSBProveedor.Location = new System.Drawing.Point(130, 317);
            this.tSBProveedor.Name = "tSBProveedor";
            this.tSBProveedor.NombreCampoDescrip = "";
            this.tSBProveedor.NombreCampoID = "";
            this.tSBProveedor.Size = new System.Drawing.Size(387, 20);
            this.tSBProveedor.SoloLectura = false;
            this.tSBProveedor.TabIndex = 17;
            this.tSBProveedor.Text = "ucTextSearchBox";
            this.tSBProveedor.TituloBuscador = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Descripción";
            // 
            // txtDescripFactura
            // 
            this.txtDescripFactura.AllowDrag = false;
            this.txtDescripFactura.Location = new System.Drawing.Point(130, 85);
            this.txtDescripFactura.Name = "txtDescripFactura";
            this.txtDescripFactura.Size = new System.Drawing.Size(387, 20);
            this.txtDescripFactura.TabIndex = 2;
            this.tTBaseForm.SetToolTip(this.txtDescripFactura, "Etiqueta que se mostrará en los documentos generados en español en los que se uti" +
        "lice ésta tarifa");
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(46, 81);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(35, 13);
            this.label24.TabIndex = 0;
            this.label24.Text = "Etiqueta";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(46, 94);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(35, 13);
            this.label25.TabIndex = 0;
            this.label25.Text = "En Español";
            // 
            // btnAsociar
            // 
            this.btnAsociar.Location = new System.Drawing.Point(46, 352);
            this.btnAsociar.Name = "btnAsociar";
            this.btnAsociar.Size = new System.Drawing.Size(120, 23);
            this.btnAsociar.TabIndex = 16;
            this.btnAsociar.Text = "Trámites asociados";
            this.btnAsociar.Click += new System.EventHandler(this.btnAsociar_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(46, 254);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(35, 13);
            this.label26.TabIndex = 0;
            this.label26.Text = "Asociada";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(46, 241);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(35, 13);
            this.label27.TabIndex = 0;
            this.label27.Text = "Tarifa Gasto";
            // 
            // tSBTarifaGastoAsoc
            // 
            this.tSBTarifaGastoAsoc.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.tSBTarifaGastoAsoc.DBContext = null;
            this.tSBTarifaGastoAsoc.DisplayMember = "";
            this.tSBTarifaGastoAsoc.KeyMember = "";
            this.tSBTarifaGastoAsoc.LabelCampoBusqueda = "";
            this.tSBTarifaGastoAsoc.Location = new System.Drawing.Point(130, 247);
            this.tSBTarifaGastoAsoc.Name = "tSBTarifaGastoAsoc";
            this.tSBTarifaGastoAsoc.NombreCampoDescrip = "";
            this.tSBTarifaGastoAsoc.NombreCampoID = "";
            this.tSBTarifaGastoAsoc.Size = new System.Drawing.Size(387, 20);
            this.tSBTarifaGastoAsoc.SoloLectura = false;
            this.tSBTarifaGastoAsoc.TabIndex = 13;
            this.tSBTarifaGastoAsoc.Text = "ucTextSearchBox";
            this.tSBTarifaGastoAsoc.TituloBuscador = "";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(564, 254);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(41, 13);
            this.label28.TabIndex = 16;
            this.label28.Text = "Grupo";
            // 
            // txtGrupo
            // 
            this.txtGrupo.Location = new System.Drawing.Point(603, 251);
            this.txtGrupo.Name = "txtGrupo";
            this.txtGrupo.Size = new System.Drawing.Size(100, 20);
            this.txtGrupo.TabIndex = 14;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(522, 281);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(35, 13);
            this.label29.TabIndex = 0;
            this.label29.Text = "Observaciones";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(603, 278);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.txtObservaciones.Size = new System.Drawing.Size(435, 88);
            this.txtObservaciones.TabIndex = 16;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(540, 94);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(35, 13);
            this.label30.TabIndex = 0;
            this.label30.Text = "En Inglés";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(540, 81);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(35, 13);
            this.label31.TabIndex = 0;
            this.label31.Text = "Etiqueta";
            // 
            // txtDescripFacturaIngles
            // 
            this.txtDescripFacturaIngles.AllowDrag = false;
            this.txtDescripFacturaIngles.Location = new System.Drawing.Point(610, 85);
            this.txtDescripFacturaIngles.Name = "txtDescripFacturaIngles";
            this.txtDescripFacturaIngles.Size = new System.Drawing.Size(387, 20);
            this.txtDescripFacturaIngles.TabIndex = 3;
            this.tTBaseForm.SetToolTip(this.txtDescripFacturaIngles, "Etiqueta que se mostrará en los documentos generados en inglés en los que se util" +
        "ice ésta tarifa");
            // 
            // ucTarifas
            // 
            this.Size = new System.Drawing.Size(1109, 528);
            this.Text = "ucTarifas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoABM)).EndInit();
            this.pnlDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabListaABM)).EndInit();
            this.pnlListadoContainer.ResumeLayout(false);
            this.pnlContainer.ResumeLayout(false);
            this.pnlTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Label label3;
        private Label label2;
        private ComboBox cbTipoTarifa;
        private ComboBox cbMoneda;
        private Label label1;
        private TextBox txtTarifaDescrip;
        private TextBox txtTarifaID;
        private TextBox txtPrecioUnitario;
        private Label label12;
        private ComboBox cbTipoUnidadDescuento;
        private Label label13;
        private Label label14;
        private ComboBox cbTipoUnidadImpuesto;
        private Label label15;
        private TextBox txtMontoDescuento;
        private Label label16;
        private TextBox txtMontoImp;
        private Label label17;
        private Label label18;
        private Label label19;
        private Label label20;
        private Label label21;
        private Label label22;
        private TextBox txtPorcImp;
        private Label label23;
        private TextBox txtPorcDescuento;
        private Label label11;
        private Label label10;
        private Base.ucTextSearchBox tSBTarifaExtID;
        private TextBox txtPrecioVenta;
        private Label label8;
        private Label label5;
        private Label label7;
        private Label label6;
        private Base.ucTextSearchBox tSBProveedor;
        private Label label9;
        private Label label25;
        private Label label24;
        private TextBox txtDescripFactura;
        private Label label4;
        private Button btnAsociar;
        private TextBox txtGrupo;
        private Label label28;
        private Base.ucTextSearchBox tSBTarifaGastoAsoc;
        private Label label27;
        private Label label26;
        private TextBox txtObservaciones;
        private Label label29;
        private TextBox txtDescripFacturaIngles;
        private Label label31;
        private Label label30;


    }
}