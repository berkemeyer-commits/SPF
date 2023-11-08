#region Using

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Linq.Dynamic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.IO;
using System.Globalization;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms;

using ModelEF6;
using SPF.Forms.Base;
using SPF.Types;
using SPF.Forms;
using SPF.Base;
using SPF.Classes;
using Microsoft.Reporting.WebForms;

#endregion

namespace SPF.Forms.UI
{
    public partial class FCierreMensual : FSeleccionarGrilla
    {
        #region Variables
        private BerkeDBEntities DBContext;
        private int AnhoUltimoCierre = 0;
        private int MesUltimoCierre = 0;
        #endregion Variables

        #region Constantes
        public const string CAMPO_CIERREID = "CierreID";
        public const string CAMPO_CUENTAID = "CuentaID";
        public const string CAMPO_ANHOCIERRE = "AnhoCierre";
        public const string CAMPO_MESCIERRE = "MesCierre";
        public const string CAMPO_SALDOCIERRE = "SaldoCierre";
        public const string CAMPO_CERRADO = "Cerrado";
        public const string CAMPO_CUENTANOMBRE = "CuentaNombre";
        public const string CAMPO_BANCOID = "BancoID";
        public const string CAMPO_BANCONOMBRE = "BancoNombre";
        public const string CAMPO_MONEDAID = "MonedaID";
        public const string CAMPO_MONEDAABREV = "MonedaAbrev";
        public const string CAMPO_MONEDANOMBRE= "MonedaNombre";
        public const string CAMPO_SELECCIONAR = "Seleccionar";
        private const string GROUP_TITLE = "Datos del Cierre";
        private const string TITULO_GRILLA_ORIGEN = "Cuentas Disponibles";
        private const string TITULO_GRILLA_DESTINO = "Cuentas Cerradas del Ciclo";
        private const string TITULO_GRILLA_ORIGEN_PH = "Cuentas no cerradas del ciclo - {0} cuentas recuperadas";
        private const string TITULO_GRILLA_DESTINO_PH = "Cuentas cerradas del ciclo - {0} cuentas cerradas";
        private const string TITULO_GRILLA_DESTINO_CUENTAS_A_CERRAR = "{0} - {1} cuentas a procesar";
        private const string ETIQUETA_CICLO_NO_CERRADO = "No hay cierre definido para el ciclo {0}";
        private const string CAMPO_ANHO = "Anho";
        private const string CAMPO_ANHONOMBRE = "AnhoNombre";
        private const string CAMPO_MES = "Mes";
        private const string CAMPO_MESNOMBRE = "MesNombre";
        #endregion Constantes

        public FCierreMensual()
        {
            InitializeComponent();
        }

        public FCierreMensual(string titulo, BerkeDBEntities context)
        {
            InitializeComponent();
            this.Text = titulo;
            this.DBContext = context;
            this.btnEliminarTodo.Visible = false;
            this.SetGroupTitle = GROUP_TITLE;
            this.SetTituloGrillaOrigen = TITULO_GRILLA_ORIGEN;
            this.TituloGrillaDestino = TITULO_GRILLA_DESTINO;
        }

        #region Combo Año
        private void cargarCBAnho()
        {
            int anhoInicial = this.AnhoUltimoCierre;
            List<AnhoType> listaAnho = new List<AnhoType>();
            for (int i = 0; i < 5; i++)
            {
                listaAnho.Add(new AnhoType() { Anho = anhoInicial + i });
            }

            this.cbAnho.DataSource = listaAnho;
            this.cbAnho.DisplayMember = CAMPO_ANHONOMBRE;
            this.cbAnho.ValueMember = CAMPO_ANHO;

            this.cbAnho.SelectedValue = anhoInicial;
        }
        #endregion Combo Año

        #region Combo Mes
        private void cargarCBMes()
        {
            List<MesType> listaMes = new List<MesType>();
            for (int i = 1; i <= 12; i++)
            {
                listaMes.Add(new MesType() { Mes = i });
            }

            this.cbMes.DataSource = listaMes;
            this.cbMes.DisplayMember = CAMPO_MESNOMBRE;
            this.cbMes.ValueMember = CAMPO_MES;

            this.cbMes.SelectedValue = this.MesUltimoCierre;
        }
        #endregion Combo Mes

        #region Obtener mes/año de último cierre
        private void GetMesAnhoUltCierre()
        {
            GetUltimoCierreMesAnho_Result ucma = this.DBContext.GetUltimoCierreMesAnho().FirstOrDefault();

            this.AnhoUltimoCierre = 0;
            this.MesUltimoCierre = 0;
            if (ucma != null)
            {
                this.AnhoUltimoCierre = ucma.cm_anhocierre;
                this.MesUltimoCierre = ucma.cm_mescierre;
            }
        }
        #endregion Obtener mes/año de último cierre

        private void FCierreMensual_Load(object sender, EventArgs e)
        {
            this.TituloOrigenString = TITULO_GRILLA_ORIGEN_PH;
            this.TituloDestinoString = TITULO_GRILLA_DESTINO_PH;
            this.GetMesAnhoUltCierre();
            this.cargarCBAnho();
            this.cargarCBMes();
            this.GetDatosCierre();
            this.cbAnho.Focus();
        }

        private void GetDatosCierre()
        {
            int anho = (int)this.cbAnho.SelectedValue;
            int mes = (int)this.cbMes.SelectedValue;

            var query = this.DBContext.GetListaCuentasPorCierre(mes, anho).ToList();

            var queryCtasDisponibles = query.Where(a => a.Cerrado == false).OrderByDescending(a => a.TieneSaldo).ToList();
            var queryCtasIncluidas = query.Where(a => a.Cerrado == true).ToList();

            this.SetDataSourceOrigen<GetListaCuentasPorCierre_Result>(queryCtasDisponibles);
            this.SetDataSourceDestino<GetListaCuentasPorCierre_Result>(queryCtasIncluidas);

            this.lblEtiquetaCicloNoCerrado.Visible =  queryCtasIncluidas.Count == 0;
            if (this.lblEtiquetaCicloNoCerrado.Visible)
            {
                string ciclo = ((MesType)this.cbMes.SelectedItem).MesNombre + "/" + ((AnhoType)this.cbAnho.SelectedItem).AnhoNombre;
                this.lblEtiquetaCicloNoCerrado.Text = String.Format(ETIQUETA_CICLO_NO_CERRADO, ciclo);
            }
        }

        #region Métodos Sobreescritos heredados del Parent Control
        protected override void FormatearGrillas()
        {
            this.dgvOrigen.AlternatingRowsDefaultCellStyle.Font = new Font("Arial", 9.5F, GraphicsUnit.Pixel);
            this.dgvOrigen.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            this.dgvOrigen.DefaultCellStyle.Font = new Font("Arial", 9.5F, GraphicsUnit.Pixel);
            this.dgvOrigen.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;
            this.dgvOrigen.RowsDefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            this.dgvOrigen.ItemsPerPage = 5;
            this.dgvOrigen.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrigen.MultiSelect = false;
            this.dgvOrigen.AllowUserToAddRows = false;
            this.dgvOrigen.AllowUserToDeleteRows = false;

            this.dgvDestino.AlternatingRowsDefaultCellStyle.Font = new Font("Arial", 9.5F, GraphicsUnit.Pixel);
            this.dgvDestino.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            this.dgvDestino.DefaultCellStyle.Font = new Font("Arial", 9.5F, GraphicsUnit.Pixel);
            this.dgvDestino.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;
            this.dgvDestino.RowsDefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            this.dgvDestino.ItemsPerPage = 5;
            this.dgvDestino.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvDestino.MultiSelect = false;
            this.dgvDestino.AllowUserToAddRows = false;
            this.dgvDestino.AllowUserToDeleteRows = false;

            //if (this.dgvOrigen.Rows.Count > 0)
            //{
            //    this.FormatearGrillaOrigen();
            //    this.SetFirstVisibleColumnOrigen();
            //}

            //if (this.dgvDestino.Rows.Count > 0)
            //{
            //    this.FormatearGrillaDestino();
            //    this.SetFirstVisibleColumnDestino();
            //}
        }

        protected override void FormatearGrillaOrigen()
        {
            foreach (DataGridViewColumn col in this.dgvOrigen.Columns)
            {
                col.Visible = false;
                col.ReadOnly = true;
            }

            int displayIndex = 0;

            this.dgvOrigen.Columns[CAMPO_CUENTAID].Visible = true;
            this.dgvOrigen.Columns[CAMPO_CUENTAID].DisplayIndex = displayIndex;
            this.dgvOrigen.Columns[CAMPO_CUENTAID].HeaderText = "ID Cuenta";
            this.dgvOrigen.Columns[CAMPO_CUENTAID].Width = 70;
            this.dgvOrigen.Columns[CAMPO_CUENTAID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            displayIndex++;

            this.dgvOrigen.Columns[CAMPO_BANCONOMBRE].Visible = true;
            this.dgvOrigen.Columns[CAMPO_BANCONOMBRE].DisplayIndex = displayIndex;
            this.dgvOrigen.Columns[CAMPO_BANCONOMBRE].HeaderText = "Forma de Pago";
            this.dgvOrigen.Columns[CAMPO_BANCONOMBRE].Width = 120;
            displayIndex++;

            this.dgvOrigen.Columns[CAMPO_CUENTANOMBRE].Visible = true;
            this.dgvOrigen.Columns[CAMPO_CUENTANOMBRE].DisplayIndex = displayIndex;
            this.dgvOrigen.Columns[CAMPO_CUENTANOMBRE].HeaderText = "Nombre Cuenta";
            this.dgvOrigen.Columns[CAMPO_CUENTANOMBRE].Width = 200;
            displayIndex++;

            this.dgvOrigen.Columns[CAMPO_SALDOCIERRE].Visible = true;
            this.dgvOrigen.Columns[CAMPO_SALDOCIERRE].DisplayIndex = displayIndex;
            this.dgvOrigen.Columns[CAMPO_SALDOCIERRE].HeaderText = "Saldo";
            this.dgvOrigen.Columns[CAMPO_SALDOCIERRE].Width = 70;
            this.dgvOrigen.Columns[CAMPO_SALDOCIERRE].ReadOnly = false;
            this.dgvOrigen.Columns[CAMPO_SALDOCIERRE].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvOrigen.Columns[CAMPO_SALDOCIERRE].DefaultCellStyle.Format = "N2";
            this.dgvOrigen.Columns[CAMPO_SALDOCIERRE].ToolTipText = "Ingrese el monto del saldo. Generalmente sólo para el primer cierre de una cuenta.";
            displayIndex++;

            this.dgvOrigen.Columns[CAMPO_MONEDAABREV].Visible = true;
            this.dgvOrigen.Columns[CAMPO_MONEDAABREV].DisplayIndex = displayIndex;
            this.dgvOrigen.Columns[CAMPO_MONEDAABREV].HeaderText = "Moneda";
            this.dgvOrigen.Columns[CAMPO_MONEDAABREV].Width = 60;
            displayIndex++;

            DataGridViewCheckBoxColumn doWork = new DataGridViewCheckBoxColumn();
            doWork.Name = CAMPO_SELECCIONAR;
            doWork.HeaderText = CAMPO_SELECCIONAR;
            doWork.ValueType = typeof(Boolean);
            doWork.FalseValue = false;
            doWork.TrueValue = true;
            doWork.ReadOnly = false;
            doWork.Width = 80;
            this.dgvOrigen.Columns.Insert(0, doWork);
        }

        protected override void FormatearGrillaDestino()
        {
            foreach (DataGridViewColumn col in this.dgvDestino.Columns)
            {
                col.Visible = false;
                col.ReadOnly = true;
            }

            int displayIndex = 0;

            this.dgvDestino.Columns[CAMPO_CUENTAID].Visible = true;
            this.dgvDestino.Columns[CAMPO_CUENTAID].DisplayIndex = displayIndex;
            this.dgvDestino.Columns[CAMPO_CUENTAID].HeaderText = "ID Cuenta";
            this.dgvDestino.Columns[CAMPO_CUENTAID].Width = 70;
            this.dgvDestino.Columns[CAMPO_CUENTAID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            displayIndex++;

            this.dgvDestino.Columns[CAMPO_BANCONOMBRE].Visible = true;
            this.dgvDestino.Columns[CAMPO_BANCONOMBRE].DisplayIndex = displayIndex;
            this.dgvDestino.Columns[CAMPO_BANCONOMBRE].HeaderText = "Forma de Pago";
            this.dgvDestino.Columns[CAMPO_BANCONOMBRE].Width = 120;
            displayIndex++;

            this.dgvDestino.Columns[CAMPO_CUENTANOMBRE].Visible = true;
            this.dgvDestino.Columns[CAMPO_CUENTANOMBRE].DisplayIndex = displayIndex;
            this.dgvDestino.Columns[CAMPO_CUENTANOMBRE].HeaderText = "Nombre Cuenta";
            this.dgvDestino.Columns[CAMPO_CUENTANOMBRE].Width = 200;
            displayIndex++;

            this.dgvDestino.Columns[CAMPO_SALDOCIERRE].Visible = true;
            this.dgvDestino.Columns[CAMPO_SALDOCIERRE].DisplayIndex = displayIndex;
            this.dgvDestino.Columns[CAMPO_SALDOCIERRE].HeaderText = "Saldo";
            this.dgvDestino.Columns[CAMPO_SALDOCIERRE].Width = 70;
            this.dgvDestino.Columns[CAMPO_SALDOCIERRE].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvDestino.Columns[CAMPO_SALDOCIERRE].DefaultCellStyle.Format = "N2";
            displayIndex++;

            this.dgvDestino.Columns[CAMPO_MONEDAABREV].Visible = true;
            this.dgvDestino.Columns[CAMPO_MONEDAABREV].DisplayIndex = displayIndex;
            this.dgvDestino.Columns[CAMPO_MONEDAABREV].HeaderText = "Moneda";
            this.dgvDestino.Columns[CAMPO_MONEDAABREV].Width = 60;
            displayIndex++;
        }

        public override void btnAgregarSeleccion_Click(object sender, EventArgs e)
        {
            this.PrepararDatos<GetListaCuentasPorCierre_Result>(CAMPO_CUENTAID);

            int cantFilasACerrar = ((List<GetListaCuentasPorCierre_Result>)this.GetDataSourceDestino.DataSource).Where( a => a.Cerrado == false).ToList().Count;

            if (cantFilasACerrar > 0)
            {
                string tituloCuentasCerradas = String.Format(TITULO_GRILLA_DESTINO_PH, this.dgvDestino.Rows.Count - cantFilasACerrar);
                this.TituloGrillaDestino = String.Format(TITULO_GRILLA_DESTINO_CUENTAS_A_CERRAR, tituloCuentasCerradas, cantFilasACerrar.ToString());
            }
        }
        #endregion Métodos Sobreescritos heredados del Parent Control

        private void btnFiltrar_Click_1(object sender, EventArgs e)
        {
            this.GetDatosCierre();
        }

        protected override void btnEliminarSeleccion_Click(object sender, EventArgs e)
        {
            if ((this.dgvDestino.CurrentRow != null) && (!(bool)this.dgvDestino.Rows[this.dgvDestino.CurrentRow.Index].Cells[CAMPO_CERRADO].Value))
            {
                this.dgvDestino.Rows.RemoveAt(this.dgvDestino.CurrentRow.Index);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            const string MESSAGE = "Se cerrará el ciclo {0}. {1} ¿Desea continuar?";
            const string CICLO = "{0}/{1}";
            int cantFilasACerrar = ((List<GetListaCuentasPorCierre_Result>)this.GetDataSourceDestino.DataSource).Where(a => a.Cerrado == false).ToList().Count;

            if (cantFilasACerrar != 0)
            {
                AnhoType at = (AnhoType)this.cbAnho.SelectedItem;
                MesType mt = (MesType)this.cbMes.SelectedItem;
                string message = String.Format(MESSAGE, String.Format(CICLO, mt.MesNombre, at.AnhoNombre), Environment.NewLine);
                string caption = "Confirmación";
                
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBox.Show(message, caption, buttons,
                                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                                new EventHandler(DialogHandler));
            }
            else
            {
                MessageBox.Show("No existen cuentas a procesar.",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }
        }

        private void DialogHandler(object sender, EventArgs e)
        {
            Form msgForm = sender as Form;
            if (msgForm != null)
            {
                if (msgForm.DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
                {
                    this.CerrarCuentas();
                }
            }
        }

        private void CerrarCuentas()
        {
            bool success = false;
            //cm_cierremovimiento cm = null;
            using (var context = new BerkeDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        this.GuardarCM(context);
                        //context.SaveChanges();
                        //this.GuardarCuentasCM(cm.cm_cierremovid, context);
                        dbContextTransaction.Commit();
                        success = true;
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();

                        string innerException = String.Empty;

                        if (ex.InnerException != null)
                        {
                            innerException += "Detalle: ";
                            innerException += ex.InnerException.InnerException != null
                                              ? ex.InnerException.InnerException.Message
                                              : ex.InnerException.Message;
                        }

                        MessageBox.Show("Ocurrió un error al procesar el guardado: "
                                        + ex.Message + Environment.NewLine
                                        + innerException,
                                        "Error al guardar los datos",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Stop);
                    }
                    
                }
            }
            if (success)
            {
                this.GetDatosCierre();
                this.GetMesAnhoUltCierre();
                MessageBox.Show("Operación completada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private string UpperFirst(string text)
        {
            return char.ToUpper(text[0]) +
                ((text.Length > 1) ? text.Substring(1).ToLower() : string.Empty);
        }

        private void GuardarCM(BerkeDBEntities context)
        {
            const string ERROR_MSG_INS = "No se puede crear el cierre. El ciclo a cerrar esperado es: {0}/{1}";
            const string ERROR_MSG_UPD = "Sólo se pueden agregar cuentas al último ciclo cerrado: {0}/{1}";

            int cierreID = -1;
            string errMsg = String.Empty;
            DateTimeFormatInfo formatoFecha = VWGContext.Current.CurrentUICulture.DateTimeFormat;

            cm_cierremovimiento cm = null;
            if (((List<GetListaCuentasPorCierre_Result>)this.GetDataSourceDestino.DataSource).Where(a => a.CierreID != null).ToList().Count > 0)
            {
                cierreID = ((List<GetListaCuentasPorCierre_Result>)this.GetDataSourceDestino.DataSource).First().CierreID.Value;
                cm = context.cm_cierremovimiento.First(a => a.cm_cierremovid == cierreID);
            }

            DateTime fechaNvoCierre = new DateTime((int)this.cbAnho.SelectedValue, (int)this.cbMes.SelectedValue, DateTime.DaysInMonth((int)this.cbAnho.SelectedValue, (int)this.cbMes.SelectedValue));
            DateTime fechaUltCierre = new DateTime(this.AnhoUltimoCierre, this.MesUltimoCierre, DateTime.DaysInMonth(this.AnhoUltimoCierre, this.MesUltimoCierre));
            DateTime fechaSigCierre = new DateTime(fechaUltCierre.AddMonths(1).Year, fechaUltCierre.AddMonths(1).Month, DateTime.DaysInMonth(fechaUltCierre.AddMonths(1).Year, fechaUltCierre.AddMonths(1).Month));

            if (cierreID == -1)
            {
                if (fechaNvoCierre != fechaSigCierre)
                {
                    errMsg = String.Format(ERROR_MSG_INS,
                                           this.UpperFirst(formatoFecha.GetMonthName(fechaSigCierre.Month)),
                                           fechaSigCierre.Year.ToString());
                }

                cm = new cm_cierremovimiento();
                cm.cm_anhocierre = (int)this.cbAnho.SelectedValue;
                cm.cm_mescierre = (int)this.cbMes.SelectedValue;
                cm.cm_fechacierre = DateTime.Now.Date;
                context.cm_cierremovimiento.Add(cm);
                context.SaveChanges();
                cierreID = cm.cm_cierremovid;
            }
            else
            {
                DateTime fechaUpdCierre = new DateTime(cm.cm_anhocierre, cm.cm_mescierre, DateTime.DaysInMonth(cm.cm_anhocierre, cm.cm_mescierre));
                if (fechaUpdCierre != fechaUltCierre)
                {
                    errMsg = String.Format(ERROR_MSG_UPD,
                                           this.UpperFirst(formatoFecha.GetMonthName(fechaUltCierre.Month)),
                                           fechaUltCierre.Year.ToString());
                }
            }

            if (errMsg != String.Empty)
            {
                throw new Exception(errMsg);
            }

            foreach (GetListaCuentasPorCierre_Result row in ((List<GetListaCuentasPorCierre_Result>)this.GetDataSourceDestino.DataSource).Where(a => a.Cerrado == false).ToList())
            {
                cct_cierrecuenta cct = new cct_cierrecuenta();
                cct.cct_cierremovimientoid = cierreID;
                cct.cct_cuentabancoid = row.CuentaID;
                cct.cct_saldo = row.SaldoCierre.Value;
                context.cct_cierrecuenta.Add(cct);
            }
            context.SaveChanges();
        }

    }
}