#region Using

using System;
using System.Globalization;
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
using System.Reflection;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms;

using ModelEF6;
using SPF.Forms.Base;
using SPF.Types;
using SPF.Forms;
using SPF.Base;
using Microsoft.Reporting.WebForms;

using OfficeOpenXml;

#endregion

namespace SPF.Forms.UI
{
    public partial class FActualizarSolPagoDesdeArchivo : Form
    {
        #region Variables
        BerkeDBEntities DBContext;
        private string fileName = string.Empty;
        private decimal facturaTotal = 0;
        FShowProgress f;
        Timer timer1;
        Timer timer2;
        frmPickBase fPickProveedor;
        frmPickBase fPickProveedorFiltro;
        FDetalleSolArchivo fDSolArch;
        private List<ListaSolArchivo> lSolArchivo;
        #endregion

        #region Constantes
        private const String UPLOADFILE_URL = @"{0}uploadfile/uploadfile.aspx?folder={1}&filename=Planilla-Factura-{2}&parentElementId=TRG_{3}&action={4}&extension={5}";
        private const String UPLOADFILE_URL_TEST = @"{0}uploadfile.aspx?folder={1}&filename=Planilla-Factura-{2}&parentElementId=TRG_{3}&action={4}&extension={5}";
        private const String ACTION_UPLOAD = "U";
        private const String ACTION_UPLOAD_SAVE = "US";
        private const String EXTENSION = ".xls,.xlsx";
        public const string CAMPO_NROFACTURA = "NroFactura";
        public const string CAMPO_FECHAFACTURA = "FechaFactura";
        public const string CAMPO_SOLPAGOCABID = "SolPagoCabID";
        public const string CAMPO_PROVEEDORID = "ProveedorID";
        public const string CAMPO_PROVEEDORNOMBRE = "ProveedorNombre";
        public const string CAMPO_PRECIOUNITARIO = "PrecioUnitario";
        public const string CAMPO_PRECIOTOTAL = "PrecioTotal";
        public const string CAMPO_CANTIDAD = "Cantidad";
        public const string CAMPO_CLIENTEID = "ClienteID";
        public const string CAMPO_CLIENTENOMBRE = "ClienteNombre";
        public const string CAMPO_TIPOFACTURAID = "TipoFacturaID";
        public const string CAMPO_TIPOFACTURADESCRIP = "TipoFacturaDescrip";

        private const string CAMPO_SOLPAGOARCHCABID = "SolPagoArchCabId";
        private const string CAMPO_SOLPAGOARCHCABPROVEEDORID = "SolPagoArchCabProveedorId";
        private const string CAMPO_SOLPAGOARCHCABTIPOFACTURAID = "SolPagoArchCabTipoFacturaId";
        private const string CAMPO_SOLPAGOARCHCABTIPOFACTURADESCRIP = "SolPagoArchCabTipoFacturaDescrip";
        private const string CAMPO_SOLPAGOARCHCABNROFACTURA = "SolPagoArchCabNroFactura";
        private const string CAMPO_SOLPAGOARCHCABFECHAFACTURA = "SolPagoArchCabFechaFactura";
        private const string CAMPO_SOLPAGOARCHCABMONTOTOTAL = "SolPagoArchCabMontoTotal";
        private const string CAMPO_SOLPAGOARCHCABMONEDAID = "SolPagoArchCabMonedaId";
        private const string CAMPO_SOLPAGOARCHCABMONEDAABREV = "SolPagoArchCabMonedaAbrev";
        private const string CAMPO_SOLPAGOARCHCABACTIVO = "SolPagoArchCabActivo";
        private const string CAMPO_SOLPAGOARCHDETSOLPAGODETID = "SolPagoArchDetSolPagoDetId";
        private const string CAMPO_SOLPAGOARCHDETCANTIDADIVA10 = "SolPagoArchDetCantidadIVA10";
        private const string CAMPO_SOLPAGOARCHDETPRECIOUNITARIOIVA10 = "SolPagoArchDetPrecioUnitarioIVA10";
        private const string CAMPO_SOLPAGOARCHDETSOLPAGODETTOTAL = "SolPagoArchDetSolPagoDetTotal";
        private const string CAMPO_TIENEAUTORIZACIONVIGENTE = "TienAutorizacionVigente";
        private const string CAMPO_SELECCIONAR = "Seleccionar";
        public const string CAMPO_VERDETALLES = "VerDetalles";

        private const int TIPO_DOCUMENTO_TRADUCCIONES = 1;
        private const string TIPO_DOCUMENTO_TRADUCCIONES_DESCRIP = "Traducciones";
        private const int TIPO_DOCUMENTO_ESCRIBANIA = 2;
        private const string TIPO_DOCUMENTO_ESCRIBANIA_DESCRIP = "Escribanía";
        #endregion Constantes

        #region Propiedades
        public string FileName
        {
            set { this.fileName = value; }
            get { return this.fileName; }
        }

        public decimal FacturaTotal
        {
            set { this.facturaTotal = value; }
            get { return this.facturaTotal; }
        }

        public List<ListaSolArchivo> ListaFacturas
        {
            set { this.lSolArchivo = value; }
            get { return this.lSolArchivo; }
        }
        #endregion Propiedades

        public FActualizarSolPagoDesdeArchivo()
        {
            InitializeComponent();
        }

        public FActualizarSolPagoDesdeArchivo(string titulo, BerkeDBEntities context)
        {
            InitializeComponent();
            this.Text = titulo;
            this.DBContext = context;
            ((IObjectContextAdapter)this.DBContext).ObjectContext.CommandTimeout = 180;
            this.dgvPlanilla.DataSource = null;
            this.btnLeer.Enabled = false;
            this.timer1 = new Timer();
            this.timer1.Tick += timer1_Tick;
            this.timer1.Interval = 1000;
            this.timer2 = new Timer();
            this.timer2.Tick += timer2_Tick;
            this.timer2.Interval = 1000;
            //this.btnAceptar.Enabled = false;
            this.CargarTipoFactura();
            this.CargarTipoDocumentos();
            this.btnAceptar.Enabled = false;
            this.btnRevertir.Enabled = false;
            this.CleanFacturaTextBoxes();
            lSolArchivo = new List<ListaSolArchivo>();

            #region TextSearchBoxes
            this.tSBProveedor.KeyMemberWidth = 70;
            this.tSBProveedor.ToolTip = "Elegir Proveedor";
            this.tSBProveedor.Editable = true;
            this.tSBProveedor.AceptarClick += tSBProveedor_AceptarClick;

            this.tSBProveedorFiltro.KeyMemberWidth = 70;
            this.tSBProveedorFiltro.ToolTip = "Elegir Proveedor para filtro";
            this.tSBProveedorFiltro.Editable = true;
            this.tSBProveedorFiltro.AceptarClick += tSBProveedorFiltro_AceptarClick;
            #endregion TextSearchBoxes

            //if (Convert.ToBoolean(VWGContext.Current.Session["TestMode"]))
            //{
            //    this.txtDocPath.Text = @"C:\Users\Gustavo\Documents\Gustavo\Berke\2023\Casos\Teresa\Detalle Factura BERKE 567 corregido - copia.xlsx";
            //    this.FileName = this.txtDocPath.Text;
            //    this.btnLeer.Enabled = true;
            //}
        }



        private void CleanFacturaTextBoxes()
        {
            this.txtFacturaProveedor.Text = string.Empty;
            this.txtFacturaNro.Text = string.Empty;
            this.txtFacturaFecha.Text = string.Empty;
            this.txtFacturaTipo.Text = string.Empty;
            this.FacturaTotal = 0;
            this.txtFacturaTotal.Text = string.Empty;
        }

        private void CargarTipoFactura()
        {
            List<CBTipoFactura> listaTipoFactura = new List<CBTipoFactura>();
            listaTipoFactura.Add(new CBTipoFactura { ID = -1, Descripcion = String.Empty });

            foreach (tf_tipofactura tp in this.DBContext.tf_tipofactura.ToList())
            {
                listaTipoFactura.Add(new CBTipoFactura { ID = tp.tf_tipofacturaid, Descripcion = tp.tf_descripcion });
            }

            this.cbTipoFactura.DataSource = listaTipoFactura.OrderBy(a => a.ID).ToList();
            this.cbTipoFactura.DisplayMember = "Descripcion";
            this.cbTipoFactura.ValueMember = "ID";
        }

        private void CargarTipoDocumentos()
        {
            List<CBTipoDocumento> listaTipoDocumento = new List<CBTipoDocumento>();
            listaTipoDocumento.Add(new CBTipoDocumento { ID = -1, Descripcion = String.Empty });
            listaTipoDocumento.Add(new CBTipoDocumento { ID = TIPO_DOCUMENTO_TRADUCCIONES, Descripcion = TIPO_DOCUMENTO_TRADUCCIONES_DESCRIP });
            listaTipoDocumento.Add(new CBTipoDocumento { ID = TIPO_DOCUMENTO_ESCRIBANIA, Descripcion = TIPO_DOCUMENTO_ESCRIBANIA_DESCRIP });

            this.cbTipoDocumento.DataSource = listaTipoDocumento.OrderBy(a => a.ID).ToList();
            this.cbTipoDocumento.DisplayMember = "Descripcion";
            this.cbTipoDocumento.ValueMember = "ID";
        }

        #region Proveedor Pick
        #region Proveedor
        private void tSBProveedor_AceptarClick(object sender, EventArgs e)
        {
            if (fPickProveedor == null)
            {
                fPickProveedor = new frmPickBase();
                fPickProveedor.AceptarFiltrarClick += fPickProveedor_AceptarFiltrarClick;
                fPickProveedor.FiltrarClick += fPickProveedor_FiltrarClick;
                fPickProveedor.Titulo = "Elegir Proveedor";
                fPickProveedor.CampoIDNombre = "pr_proveedorid";
                fPickProveedor.CampoDescripNombre = "pr_nombre";
                fPickProveedor.LabelCampoID = "ID";
                fPickProveedor.LabelCampoDescrip = "Nombre o Razón Social";
                fPickProveedor.NombreCampo = "Proveedor";
                fPickProveedor.PermitirFiltroNulo = true;
            }
            fPickProveedor.MostrarFiltro();
            //this.fPickProveedor_FiltrarClick(sender, e);
        }

        private void fPickProveedor_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickProveedor != null)
            {
                fPickProveedor.LoadData<pr_proveedor>(this.DBContext.pr_proveedor, fPickProveedor.GetWhereString());
            }
        }

        private void fPickProveedor_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBProveedor.DisplayMember = fPickProveedor.ValorDescrip;
            this.tSBProveedor.KeyMember = fPickProveedor.ValorID;

            fPickProveedor.Close();
            fPickProveedor.Dispose();
        }
        #endregion Proveedor

        #region Proveedor Filtro
        private void tSBProveedorFiltro_AceptarClick(object sender, EventArgs e)
        {
            if (fPickProveedorFiltro == null)
            {
                fPickProveedorFiltro = new frmPickBase();
                fPickProveedorFiltro.AceptarFiltrarClick += fPickProveedorFiltro_AceptarFiltrarClick;
                fPickProveedorFiltro.FiltrarClick += fPickProveedorFiltro_FiltrarClick;
                fPickProveedorFiltro.Titulo = "Elegir Proveedor para filtro";
                fPickProveedorFiltro.CampoIDNombre = "pr_proveedorid";
                fPickProveedorFiltro.CampoDescripNombre = "pr_nombre";
                fPickProveedorFiltro.LabelCampoID = "ID";
                fPickProveedorFiltro.LabelCampoDescrip = "Nombre o Razón Social";
                fPickProveedorFiltro.NombreCampo = "Proveedor";
                fPickProveedorFiltro.PermitirFiltroNulo = true;
            }
            fPickProveedorFiltro.MostrarFiltro();
            //this.fPickProveedor_FiltrarClick(sender, e);
        }

        private void fPickProveedorFiltro_FiltrarClick(object sender, EventArgs e)
        {
            if (fPickProveedorFiltro != null)
            {
                fPickProveedorFiltro.LoadData<pr_proveedor>(this.DBContext.pr_proveedor, fPickProveedorFiltro.GetWhereString());
            }
        }

        private void fPickProveedorFiltro_AceptarFiltrarClick(object sender, EventArgs e)
        {
            this.tSBProveedorFiltro.DisplayMember = fPickProveedorFiltro.ValorDescrip;
            this.tSBProveedorFiltro.KeyMember = fPickProveedorFiltro.ValorID;

            fPickProveedorFiltro.Close();
            fPickProveedorFiltro.Dispose();
        }
        #endregion Proveedor Filtro
        #endregion Proveedor Pick

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubir_Click(object sender, EventArgs e)
        {
            //this.OpenDialogFileUpload();
            this.OpenPopup(ACTION_UPLOAD);
        }

        private void OpenPopup(String action)
        {
            string baseUrl = this.GetBaseURL(VWGContext.Current.HttpContext);
            //string baseUrl = @"http://localhost:49744/";

            object[] jsParams = new object[6];
            //jsParams[0] = String.Format(UPLOADFILE_URL, VWGContext.Current.Session["UserName"], DateTime.Now.Ticks.ToString(), this.txtDocPath.ID.ToString(), action);
            jsParams[0] = String.Format(UPLOADFILE_URL, baseUrl, VWGContext.Current.Session["UserName"], DateTime.Now.Ticks.ToString(), this.txtDocPath.ID.ToString(), action, EXTENSION);
            jsParams[1] = "";
            jsParams[2] = 500;
            jsParams[3] = 200;
            jsParams[4] = this.ID.ToString();
            jsParams[5] = this.txtDocPath.ID.ToString();

            VWGClientContext.Current.Invoke("PopupCenterCustom", jsParams);
            return;
        }

        private string GetBaseURL(System.Web.HttpContext context)
        {
            string baseUrl = context.Request.Url.Scheme + "://" + context.Request.Url.Authority + '/'; // + context.Request.ApplicationPath.TrimEnd('/') + '/';
            return baseUrl;
        }

        private void getDocPath()
        {
            object[] jsParams = new object[2];
            jsParams[0] = this.ID.ToString();
            jsParams[1] = this.txtDocPath.ID.ToString();
            VWGClientContext.Current.Invoke("getDocPath", jsParams);
            return;
        }

        protected override void FireEvent(Gizmox.WebGUI.Common.Interfaces.IEvent objEvent)
        {
            if (objEvent.Type == "docPathEvent")
            {
                string[] fN = objEvent["docPathValue"].Split(new string[] { "_#_" }, StringSplitOptions.None);
                this.FileName = fN[0];
                this.txtDocPath.Text = fN[1];
                //this.readExcelFile(this.FileName);
            }
            //else if (objEvent.Type == "doNothing")
            //{
            //    f.Close();
            //}
            else
            {
                base.FireEvent(objEvent);
            }

        }

        private void readExcelFileTraducciones(string filePath)
        {
            string ERRORMSG = "Planilla con formato incorrecto." + Environment.NewLine +
                              "Campo: {0} no encontrado.";
            string nroFactura = string.Empty;
            string fechaFacturaStr = string.Empty;
            DateTime fechaFactura = new DateTime();
            List<PlanillaTraduccionesType> list = new List<PlanillaTraduccionesType>();

            try
            {
                var existingFile = new FileInfo(filePath);

                using (var package = new ExcelPackage(existingFile))
                {
                    var workBook = package.Workbook;
                    if (workBook != null)
                    {
                        if (workBook.Worksheets.Count > 0)
                        {
                            var currentWorksheet = workBook.Worksheets.First();

                            nroFactura = currentWorksheet.Cells[8, 2].Text;
                            if (nroFactura == string.Empty)
                                throw new Exception(string.Format(ERRORMSG, "Nro. Factura"));

                            fechaFacturaStr = currentWorksheet.Cells[9, 2].Text;

                            if (fechaFacturaStr == string.Empty)
                                throw new Exception(string.Format(ERRORMSG, "Fecha Factura"));
                            else
                            {
                                if (fechaFacturaStr.Length == 9)
                                {
                                    string[] d = fechaFacturaStr.Split('/');
                                    fechaFacturaStr = d[0] + "/0" + d[1] + "/" + d[2];
                                }

                                if (!DateTime.TryParseExact(fechaFacturaStr,
                                                            "dd/MM/yyyy",
                                                            VWGContext.Current.CurrentUICulture,
                                                            DateTimeStyles.None,
                                                            out fechaFactura))
                                {
                                    throw new Exception(string.Format(ERRORMSG, "Fecha Factura"));
                                }
                            }

                            var start = currentWorksheet.Dimension.Start;
                            var end = currentWorksheet.Dimension.End;
                            for (int row = 12; row <= end.Row; row++)
                            {
                                if (currentWorksheet.Cells[row, 4].Text == string.Empty)
                                    break;

                                PlanillaTraduccionesType fila = new PlanillaTraduccionesType();
                                fila.NroFactura = nroFactura;
                                fila.FechaFactura = fechaFactura;
                                fila.SolPagoCabID = Convert.ToInt32(currentWorksheet.Cells[row, 4].Value);
                                fila.ProveedorID = Convert.ToInt32(this.tSBProveedor.KeyMember);
                                fila.ProveedorNombre = this.tSBProveedor.DisplayMember;
                                fila.PrecioUnitario = Convert.ToDecimal(currentWorksheet.Cells[row, 12].Value);
                                fila.PrecioTotal = Convert.ToDecimal(currentWorksheet.Cells[row, 13].Value);
                                fila.Cantidad = Convert.ToInt32(fila.PrecioTotal / fila.PrecioUnitario);
                                fila.ClienteID = -1;//Convert.ToInt32(currentWorksheet.Cells[row, 7].Value);
                                fila.ClienteNombre = "Cliente Nombre";
                                fila.TipoFacturaID = Convert.ToInt32(this.cbTipoFactura.SelectedValue.ToString());
                                fila.TipoFacturaDescrip = this.cbTipoFactura.Text;
                                list.Add(fila);
                            }
                        }
                    }
                }

                //this.ExportToCsv<PlanillaTraduccionesType>(list, this.FileName.Replace("xlsx", "csv"));

                using (BerkeDBEntities context = new BerkeDBEntities())
                {
                    var data = (from fila in list
                                join s in context.spc_solicitudpagocab
                                     on fila.SolPagoCabID equals s.spc_solicitudpagocabid
                                join c in context.Cliente
                                     on s.spc_clienteid equals c.ID into c_s
                                from c in c_s.DefaultIfEmpty()
                                join m in context.Moneda
                                     on s.spc_monedaid equals m.ID
                                select new PlanillaTraduccionesType
                                {
                                    NroFactura = fila.NroFactura,
                                    FechaFactura = fila.FechaFactura,
                                    SolPagoCabID = fila.SolPagoCabID,
                                    ProveedorID = fila.ProveedorID,
                                    ProveedorNombre = fila.ProveedorNombre,// p.pr_nombre,
                                    PrecioUnitario = fila.PrecioUnitario,
                                    PrecioTotal = fila.PrecioTotal,
                                    Cantidad = fila.Cantidad,
                                    ClienteID = s.spc_clienteid.Value,
                                    ClienteNombre = c.Nombre,
                                    TipoFacturaID = fila.TipoFacturaID,
                                    TipoFacturaDescrip = fila.TipoFacturaDescrip,
                                    MonedaAbrev = m.AbrevMoneda
                                }).ToList();

                    if (data.First().ProveedorNombre == string.Empty)
                    {
                        int proveedorId = data.First().ProveedorID;
                        string proveedorNombre = context.pr_proveedor.First(a => a.pr_proveedorid == proveedorId).pr_nombre;
                        this.tSBProveedor.DisplayMember = proveedorNombre;

                        foreach (var row in data)
                        {
                            row.ProveedorNombre = proveedorNombre;
                        }
                    }

                    this.dgvPlanilla.DataSource = data;

                    this.txtFacturaProveedor.Text = data.First().ProveedorNombre + " (" + data.First().ProveedorID.ToString() + ")";
                    this.txtFacturaNro.Text = data.First().NroFactura;
                    this.txtFacturaFecha.Text = data.First().FechaFactura.ToShortDateString();
                    this.txtFacturaTipo.Text = data.First().TipoFacturaDescrip;
                    this.FacturaTotal = data.Sum(x => x.PrecioTotal);
                    this.txtFacturaTotal.Text = data.First().MonedaAbrev + " " + String.Format("{0:n0}", this.FacturaTotal); ;

                    this.FormatearGrilla();
                }

                f.Close();
                //this.timer1.Stop();
                //this.dgvPlanilla.DataSource = list;
            }
            catch (Exception ex)
            {
                f.Close();
                //this.timer1.Stop();
                //this.firstTime = true;

                string innerException = String.Empty;

                if (ex.InnerException != null)
                {
                    innerException += "Detalle: ";
                    innerException += ex.InnerException.InnerException != null
                                      ? ex.InnerException.InnerException.Message
                                      : ex.InnerException.Message;
                }

                MessageBox.Show("Se produjeron errores al procesar la planilla: "
                                + ex.Message + Environment.NewLine
                                + innerException,
                                "Error:",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);
            }
        }

        private void readExcelFileEscribania(string filePath)
        {
            string ERRORMSG = "Planilla con formato incorrecto." + Environment.NewLine +
                              "Campo: {0} no encontrado.";
            string nroFactura = string.Empty;
            string fechaFacturaStr = string.Empty;
            DateTime fechaFactura = new DateTime();
            List<PlanillaTraduccionesType> list = new List<PlanillaTraduccionesType>();

            int lastSolPagoCabID = -1;

            try
            {
                var existingFile = new FileInfo(filePath);

                using (var package = new ExcelPackage(existingFile))
                {
                    var workBook = package.Workbook;
                    if (workBook != null)
                    {
                        if (workBook.Worksheets.Count > 0)
                        {
                            var currentWorksheet = workBook.Worksheets.First();

                            nroFactura = currentWorksheet.Cells[3, 2].Text;
                            if (nroFactura == string.Empty)
                                throw new Exception(string.Format(ERRORMSG, "Nro. Factura"));

                            fechaFacturaStr = currentWorksheet.Cells[3, 4].Text.Substring(0, 10);

                            if (fechaFacturaStr == string.Empty)
                                throw new Exception(string.Format(ERRORMSG, "Fecha Factura"));
                            else
                            {
                                if (!DateTime.TryParseExact(fechaFacturaStr,
                                                            "dd/MM/yyyy",
                                                            VWGContext.Current.CurrentUICulture,
                                                            DateTimeStyles.None,
                                                            out fechaFactura))
                                {
                                    throw new Exception(string.Format(ERRORMSG, "Fecha Factura"));
                                }
                            }

                            var start = currentWorksheet.Dimension.Start;
                            var end = currentWorksheet.Dimension.End;
                            for (int row = 5; row <= end.Row; row++)
                            {
                                if (currentWorksheet.Cells[row, 11].Text == string.Empty)
                                    break;

                                lastSolPagoCabID = Convert.ToInt32(currentWorksheet.Cells[row, 11].Value);

                                PlanillaTraduccionesType fila = new PlanillaTraduccionesType();
                                fila.NroFactura = nroFactura;
                                fila.FechaFactura = fechaFactura;
                                fila.SolPagoCabID = Convert.ToInt32(currentWorksheet.Cells[row, 11].Value);
                                fila.ProveedorID = Convert.ToInt32(this.tSBProveedor.KeyMember);
                                fila.ProveedorNombre = this.tSBProveedor.DisplayMember;
                                fila.PrecioUnitario = Convert.ToDecimal(currentWorksheet.Cells[row, 9].Value);
                                fila.PrecioTotal = Convert.ToDecimal(currentWorksheet.Cells[row, 10].Value);
                                fila.Cantidad = Convert.ToInt32(fila.PrecioTotal / fila.PrecioUnitario);
                                fila.ClienteID = -1;//Convert.ToInt32(currentWorksheet.Cells[row, 7].Value);
                                fila.ClienteNombre = "Cliente Nombre";
                                fila.TipoFacturaID = Convert.ToInt32(this.cbTipoFactura.SelectedValue.ToString());
                                fila.TipoFacturaDescrip = this.cbTipoFactura.Text;
                                list.Add(fila);
                            }
                        }
                    }
                }


                using (BerkeDBEntities context = new BerkeDBEntities())
                {
                    var data = (from fila in list
                                join s in context.spc_solicitudpagocab
                                     on fila.SolPagoCabID equals s.spc_solicitudpagocabid
                                join c in context.Cliente
                                     on s.spc_clienteid equals c.ID into c_s
                                from c in c_s.DefaultIfEmpty()
                                join m in context.Moneda
                                     on s.spc_monedaid equals m.ID
                                select new PlanillaTraduccionesType
                                {
                                    NroFactura = fila.NroFactura,
                                    FechaFactura = fila.FechaFactura,
                                    SolPagoCabID = fila.SolPagoCabID,
                                    ProveedorID = fila.ProveedorID,
                                    ProveedorNombre = fila.ProveedorNombre,// p.pr_nombre,
                                    PrecioUnitario = fila.PrecioUnitario,
                                    PrecioTotal = fila.PrecioTotal,
                                    Cantidad = fila.Cantidad,
                                    ClienteID = s.spc_clienteid.Value,
                                    ClienteNombre = c.Nombre,
                                    TipoFacturaID = fila.TipoFacturaID,
                                    TipoFacturaDescrip = fila.TipoFacturaDescrip,
                                    MonedaAbrev = m.AbrevMoneda
                                }).ToList();

                    if (data.First().ProveedorNombre == string.Empty)
                    {
                        int proveedorId = data.First().ProveedorID;
                        string proveedorNombre = context.pr_proveedor.First(a => a.pr_proveedorid == proveedorId).pr_nombre;
                        this.tSBProveedor.DisplayMember = proveedorNombre;

                        foreach (var row in data)
                        {
                            row.ProveedorNombre = proveedorNombre;
                        }
                    }

                    this.dgvPlanilla.DataSource = data;

                    this.txtFacturaProveedor.Text = data.First().ProveedorNombre + " (" + data.First().ProveedorID.ToString() + ")";
                    this.txtFacturaNro.Text = data.First().NroFactura;
                    this.txtFacturaFecha.Text = data.First().FechaFactura.ToShortDateString();
                    this.txtFacturaTipo.Text = data.First().TipoFacturaDescrip;
                    this.FacturaTotal = data.Sum(x => x.PrecioTotal);
                    this.txtFacturaTotal.Text = data.First().MonedaAbrev + " " + String.Format("{0:n0}", this.FacturaTotal); ;

                    this.FormatearGrilla();
                }

                f.Close();
                //this.timer1.Stop();
                //this.dgvPlanilla.DataSource = list;
            }
            catch (Exception ex)
            {
                f.Close();
                //this.timer1.Stop();
                //this.firstTime = true;

                string innerException = String.Empty;

                if (ex.InnerException != null)
                {
                    innerException += "Detalle: ";
                    innerException += ex.InnerException.InnerException != null
                                      ? ex.InnerException.InnerException.Message
                                      : ex.InnerException.Message;
                }

                MessageBox.Show("Se produjeron errores al procesar la planilla: "
                                + ex.Message + Environment.NewLine
                                + innerException + " (" + lastSolPagoCabID.ToString() + ")",
                                "Error:",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);
            }
        }

        private void txtDocPath_TextChanged(object sender, EventArgs e)
        {
            this.btnLeer.Enabled = this.txtDocPath.Text.Trim() != string.Empty;
        }

        private void btnLeer_Click(object sender, EventArgs e)
        {
            if (cbTipoDocumento.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Debe seleccionar el tipo de documento.",
                               "Información",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return;
            }

            if (tSBProveedor.KeyMember.Trim() == string.Empty)
            {
                MessageBox.Show("Debe seleccionar un proveedor.",
                               "Información",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return;
            }

            if (cbTipoFactura.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Debe seleccionar el tipo de factura.",
                               "Información",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return;
            }


            this.dgvPlanilla.DataSource = null;
            this.CleanFacturaTextBoxes();

            if (f == null)
                f = new FShowProgress();

            f.ShowDialog();

            this.timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.cbTipoDocumento.SelectedValue.ToString()) == TIPO_DOCUMENTO_TRADUCCIONES)
                this.readExcelFileTraducciones(this.FileName);
            else this.readExcelFileEscribania(this.fileName);
            this.timer1.Stop();
        }

        private void FormatearGrilla()
        {
            this.dgvPlanilla.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Pixel);
            this.dgvPlanilla.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvPlanilla.AlternatingRowsDefaultCellStyle.Font = new Font("Arial", 9.5F, GraphicsUnit.Pixel);
            this.dgvPlanilla.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            this.dgvPlanilla.DefaultCellStyle.Font = new Font("Arial", 9.5F, GraphicsUnit.Pixel);
            this.dgvPlanilla.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;
            this.dgvPlanilla.RowsDefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            this.dgvPlanilla.ItemsPerPage = 13;
            this.dgvPlanilla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlanilla.MultiSelect = false;

            foreach (DataGridViewColumn col in this.dgvPlanilla.Columns)
            {
                col.Visible = false;
                col.ReadOnly = true;
            }

            int displayIndex = 0;

            this.dgvPlanilla.Columns[CAMPO_SOLPAGOCABID].HeaderText = "Id. Sol. Pago";
            this.dgvPlanilla.Columns[CAMPO_SOLPAGOCABID].Width = 70;
            this.dgvPlanilla.Columns[CAMPO_SOLPAGOCABID].DisplayIndex = displayIndex;
            this.dgvPlanilla.Columns[CAMPO_SOLPAGOCABID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvPlanilla.Columns[CAMPO_SOLPAGOCABID].Visible = true;
            displayIndex++;

            this.dgvPlanilla.Columns[CAMPO_NROFACTURA].HeaderText = "N° Factura";
            this.dgvPlanilla.Columns[CAMPO_NROFACTURA].Width = 85;
            this.dgvPlanilla.Columns[CAMPO_NROFACTURA].DisplayIndex = displayIndex;
            this.dgvPlanilla.Columns[CAMPO_NROFACTURA].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvPlanilla.Columns[CAMPO_NROFACTURA].Visible = true;
            displayIndex++;

            this.dgvPlanilla.Columns[CAMPO_FECHAFACTURA].HeaderText = "Fec. Factura";
            this.dgvPlanilla.Columns[CAMPO_FECHAFACTURA].Width = 70;
            this.dgvPlanilla.Columns[CAMPO_FECHAFACTURA].DisplayIndex = displayIndex;
            this.dgvPlanilla.Columns[CAMPO_FECHAFACTURA].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvPlanilla.Columns[CAMPO_FECHAFACTURA].Visible = true;
            displayIndex++;

            this.dgvPlanilla.Columns[CAMPO_TIPOFACTURADESCRIP].HeaderText = "Tipo Factura";
            this.dgvPlanilla.Columns[CAMPO_TIPOFACTURADESCRIP].Width = 85;
            this.dgvPlanilla.Columns[CAMPO_TIPOFACTURADESCRIP].DisplayIndex = displayIndex;
            this.dgvPlanilla.Columns[CAMPO_TIPOFACTURADESCRIP].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvPlanilla.Columns[CAMPO_TIPOFACTURADESCRIP].Visible = true;
            displayIndex++;

            this.dgvPlanilla.Columns[CAMPO_PROVEEDORNOMBRE].HeaderText = "Proveedor";
            this.dgvPlanilla.Columns[CAMPO_PROVEEDORNOMBRE].Width = 150;
            this.dgvPlanilla.Columns[CAMPO_PROVEEDORNOMBRE].DisplayIndex = displayIndex;
            this.dgvPlanilla.Columns[CAMPO_PROVEEDORNOMBRE].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvPlanilla.Columns[CAMPO_PROVEEDORNOMBRE].Visible = true;
            displayIndex++;

            this.dgvPlanilla.Columns[CAMPO_CLIENTENOMBRE].HeaderText = "Cliente";
            this.dgvPlanilla.Columns[CAMPO_CLIENTENOMBRE].Width = 170;
            this.dgvPlanilla.Columns[CAMPO_CLIENTENOMBRE].DisplayIndex = displayIndex;
            this.dgvPlanilla.Columns[CAMPO_CLIENTENOMBRE].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvPlanilla.Columns[CAMPO_CLIENTENOMBRE].Visible = true;
            displayIndex++;

            this.dgvPlanilla.Columns[CAMPO_CANTIDAD].HeaderText = "Cant. Pág.";
            this.dgvPlanilla.Columns[CAMPO_CANTIDAD].Width = 60;
            this.dgvPlanilla.Columns[CAMPO_CANTIDAD].DisplayIndex = displayIndex;
            this.dgvPlanilla.Columns[CAMPO_CANTIDAD].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvPlanilla.Columns[CAMPO_CANTIDAD].DefaultCellStyle.Format = "N0";
            this.dgvPlanilla.Columns[CAMPO_CANTIDAD].Visible = true;
            displayIndex++;

            this.dgvPlanilla.Columns[CAMPO_PRECIOUNITARIO].HeaderText = "Prec. Unitario";
            this.dgvPlanilla.Columns[CAMPO_PRECIOUNITARIO].Width = 70;
            this.dgvPlanilla.Columns[CAMPO_PRECIOUNITARIO].DisplayIndex = displayIndex;
            this.dgvPlanilla.Columns[CAMPO_PRECIOUNITARIO].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvPlanilla.Columns[CAMPO_PRECIOUNITARIO].DefaultCellStyle.Format = "N0";
            this.dgvPlanilla.Columns[CAMPO_PRECIOUNITARIO].Visible = true;
            displayIndex++;

            this.dgvPlanilla.Columns[CAMPO_PRECIOTOTAL].HeaderText = "Prec. Total";
            this.dgvPlanilla.Columns[CAMPO_PRECIOTOTAL].Width = 70;
            this.dgvPlanilla.Columns[CAMPO_PRECIOTOTAL].DisplayIndex = displayIndex;
            this.dgvPlanilla.Columns[CAMPO_PRECIOTOTAL].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvPlanilla.Columns[CAMPO_PRECIOTOTAL].DefaultCellStyle.Format = "N0";
            this.dgvPlanilla.Columns[CAMPO_PRECIOTOTAL].Visible = true;
            displayIndex++;
        }

        private void FormatearGrillaRevertir()
        {
            this.dgvRevertir.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Pixel);
            this.dgvRevertir.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvRevertir.AlternatingRowsDefaultCellStyle.Font = new Font("Arial", 9.5F, GraphicsUnit.Pixel);
            this.dgvRevertir.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            this.dgvRevertir.DefaultCellStyle.Font = new Font("Arial", 9.5F, GraphicsUnit.Pixel);
            this.dgvRevertir.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;
            this.dgvRevertir.RowsDefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            this.dgvRevertir.ItemsPerPage = 13;
            this.dgvRevertir.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvRevertir.MultiSelect = false;

            foreach (DataGridViewColumn col in this.dgvRevertir.Columns)
            {
                col.Visible = false;
                col.ReadOnly = true;
            }

            int displayIndex = 0;

            this.dgvRevertir.Columns[CAMPO_SOLPAGOARCHCABNROFACTURA].HeaderText = "N° Factura";
            this.dgvRevertir.Columns[CAMPO_SOLPAGOARCHCABNROFACTURA].Width = 85;
            this.dgvRevertir.Columns[CAMPO_SOLPAGOARCHCABNROFACTURA].DisplayIndex = displayIndex;
            this.dgvRevertir.Columns[CAMPO_SOLPAGOARCHCABNROFACTURA].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvRevertir.Columns[CAMPO_SOLPAGOARCHCABNROFACTURA].Visible = true;
            displayIndex++;

            this.dgvRevertir.Columns[CAMPO_SOLPAGOARCHCABFECHAFACTURA].HeaderText = "Fec. Factura";
            this.dgvRevertir.Columns[CAMPO_SOLPAGOARCHCABFECHAFACTURA].Width = 70;
            this.dgvRevertir.Columns[CAMPO_SOLPAGOARCHCABFECHAFACTURA].DisplayIndex = displayIndex;
            this.dgvRevertir.Columns[CAMPO_SOLPAGOARCHCABFECHAFACTURA].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvRevertir.Columns[CAMPO_SOLPAGOARCHCABFECHAFACTURA].Visible = true;
            displayIndex++;

            this.dgvRevertir.Columns[CAMPO_SOLPAGOARCHCABTIPOFACTURADESCRIP].HeaderText = "Tipo Factura";
            this.dgvRevertir.Columns[CAMPO_SOLPAGOARCHCABTIPOFACTURADESCRIP].Width = 85;
            this.dgvRevertir.Columns[CAMPO_SOLPAGOARCHCABTIPOFACTURADESCRIP].DisplayIndex = displayIndex;
            this.dgvRevertir.Columns[CAMPO_SOLPAGOARCHCABTIPOFACTURADESCRIP].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvRevertir.Columns[CAMPO_SOLPAGOARCHCABTIPOFACTURADESCRIP].Visible = true;
            displayIndex++;

            this.dgvRevertir.Columns[CAMPO_SOLPAGOARCHCABMONEDAABREV].HeaderText = "Moneda";
            this.dgvRevertir.Columns[CAMPO_SOLPAGOARCHCABMONEDAABREV].Width = 50;
            this.dgvRevertir.Columns[CAMPO_SOLPAGOARCHCABMONEDAABREV].DisplayIndex = displayIndex;
            this.dgvRevertir.Columns[CAMPO_SOLPAGOARCHCABMONEDAABREV].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvRevertir.Columns[CAMPO_SOLPAGOARCHCABMONEDAABREV].Visible = true;
            displayIndex++;

            this.dgvRevertir.Columns[CAMPO_SOLPAGOARCHCABMONTOTOTAL].HeaderText = "Total Factura";
            this.dgvRevertir.Columns[CAMPO_SOLPAGOARCHCABMONTOTOTAL].Width = 70;
            this.dgvRevertir.Columns[CAMPO_SOLPAGOARCHCABMONTOTOTAL].DisplayIndex = displayIndex;
            this.dgvRevertir.Columns[CAMPO_SOLPAGOARCHCABMONTOTOTAL].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvRevertir.Columns[CAMPO_SOLPAGOARCHCABMONTOTOTAL].DefaultCellStyle.Format = "N0";
            this.dgvRevertir.Columns[CAMPO_SOLPAGOARCHCABMONTOTOTAL].Visible = true;
            displayIndex++;

            this.dgvRevertir.Columns[CAMPO_SOLPAGOARCHCABID].HeaderText = "Id Documento";
            this.dgvRevertir.Columns[CAMPO_SOLPAGOARCHCABID].Width = 85;
            this.dgvRevertir.Columns[CAMPO_SOLPAGOARCHCABID].DisplayIndex = displayIndex;
            this.dgvRevertir.Columns[CAMPO_SOLPAGOARCHCABID].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvRevertir.Columns[CAMPO_SOLPAGOARCHCABID].Visible = true;
            displayIndex++;

            #region Columna Ver Detalles
            DataGridViewCellStyle cStyle = new DataGridViewCellStyle();
            cStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            cStyle.ForeColor = Color.Green;
            cStyle.Font = new Font("Arial", 9.5F, FontStyle.Bold, GraphicsUnit.Pixel);

            DataGridViewButtonColumn showDetails = new DataGridViewButtonColumn();
            showDetails.HeaderText = "Detalles";
            showDetails.Text = "Ver";
            showDetails.UseColumnTextForButtonValue = true;
            showDetails.DefaultCellStyle = cStyle;
            showDetails.ToolTipText = "Presione para ver los detalles de la factura";
            showDetails.Width = 60;
            showDetails.Name = CAMPO_VERDETALLES;
            this.dgvRevertir.Columns.Insert(displayIndex, showDetails);
            #endregion Columna Ver Detalles

            DataGridViewCheckBoxColumn doWork = new DataGridViewCheckBoxColumn();
            doWork.HeaderText = CAMPO_SELECCIONAR;
            doWork.Name = CAMPO_SELECCIONAR;
            doWork.FalseValue = false;
            doWork.TrueValue = true;
            doWork.ReadOnly = false;
            doWork.Width = 80;
            this.dgvRevertir.Columns.Insert(0, doWork);
        }

        private bool ValidarProcesamientoAnterior(int proveedorId, int tipoFacturaId,
                                                    DateTime fechaFactura, string nroFactura,
                                                    BerkeDBEntities context)
        {
            List<spac_solicitudpagoarchivocab> lSpac = context.spac_solicitudpagoarchivocab.Where(a => a.spac_proveedorid == proveedorId
                                                                                                && a.spac_tipofacturaid == tipoFacturaId
                                                                                                && a.spac_fechafactura == fechaFactura
                                                                                                && a.spac_activo == true).ToList();

            return lSpac.Count == 0;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string message = "Se actualizarán todas las solicitudes de pago contenidas en la grilla ¿Desea continuar?";
            string caption = "Actualización de Solicitudes de Pago";

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBox.Show(message, caption, buttons,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                            new EventHandler(ProcessHandler));
        }

        private void ProcessHandler(object sender, EventArgs e)
        {
            Form msgForm = sender as Form;
            if (msgForm != null)
            {
                if (msgForm.DialogResult == Gizmox.WebGUI.Forms.DialogResult.No)
                {
                    return;
                }
                else
                {
                    if (f == null)
                        f = new FShowProgress();

                    f.ShowDialog();
                    this.timer2.Start();
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.UpdateSolCab();
            this.timer2.Stop();
        }

        private void UpdateSolCab()
        {

            bool success = false;
            string errMsg = string.Empty;
            using (var context = new BerkeDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        spac_solicitudpagoarchivocab spac = new spac_solicitudpagoarchivocab();
                        spac.spac_proveedorid = Convert.ToInt32(this.tSBProveedor.KeyMember);
                        spac.spac_tipofacturaid = Convert.ToInt32(this.cbTipoFactura.SelectedValue);
                        spac.spac_fechafactura = Convert.ToDateTime(this.txtFacturaFecha.Text);
                        spac.spac_nrofactura = this.txtFacturaNro.Text;
                        spac.spac_montototal = this.FacturaTotal;
                        spac.spac_activo = true;

                        if (!this.ValidarProcesamientoAnterior(spac.spac_proveedorid, spac.spac_tipofacturaid,
                                                                spac.spac_fechafactura, spac.spac_nrofactura, context))
                        {
                            //MessageBox.Show("Esta factura ya sido procesada con anterioridad",
                            //               "Información",
                            //               MessageBoxButtons.OK,
                            //               MessageBoxIcon.Information);
                            //return;
                            throw new Exception("Esta factura ha sido procesada con anterioridad, debe revertir dicha operación para volver a procesar.");
                        }

                        context.spac_solicitudpagoarchivocab.Add(spac);

                        foreach (DataGridViewRow row in this.dgvPlanilla.Rows)
                        {
                            int solPagoCabId = Convert.ToInt32(row.Cells[CAMPO_SOLPAGOCABID].Value);
                            spd_solicitudpagodet spd = context.spd_solicitudpagodet.FirstOrDefault(a => a.spd_solicitudpagocabid == solPagoCabId);

                            if (spd == null)
                            {
                                errMsg += (errMsg != string.Empty ? ", " : string.Empty) + solPagoCabId.ToString();
                            }
                            else
                            {
                                spd.spd_nrofactura = row.Cells[CAMPO_NROFACTURA].Value.ToString();
                                spd.spd_fechafactura = Convert.ToDateTime(row.Cells[CAMPO_FECHAFACTURA].Value);
                                spd.spd_proveedorid = Convert.ToInt32(row.Cells[CAMPO_PROVEEDORID].Value);
                                spd.spd_cantidadiva10 = Convert.ToInt32(row.Cells[CAMPO_CANTIDAD].Value);
                                spd.spd_precunitiva10 = Convert.ToDecimal(row.Cells[CAMPO_PRECIOUNITARIO].Value);
                                spd.spd_iva10 = Convert.ToDecimal(row.Cells[CAMPO_PRECIOTOTAL].Value);
                                spd.spd_total = Convert.ToDecimal(row.Cells[CAMPO_PRECIOTOTAL].Value);
                                spd.spd_saldo = Convert.ToDecimal(row.Cells[CAMPO_PRECIOTOTAL].Value);
                                spd.spd_tipofacturaid = Convert.ToInt32(row.Cells[CAMPO_TIPOFACTURAID].Value);

                                spad_solicitudpagoarchivodet spad = new spad_solicitudpagoarchivodet();
                                spad.spad_solicitudpagocabid = solPagoCabId;
                                spad.spad_solicitudpagoarchivocabid = spac.spac_solicitudpagoarchivocabid;
                                context.spad_solicitudpagoarchivodet.Add(spad);

                                context.SaveChanges();
                            }
                        }

                        if (errMsg != string.Empty)
                        {
                            if (errMsg.IndexOf(',') > -1)
                                throw new Exception("Las solicitudes de pago " + errMsg + " no tienen detalles cargados.");
                            else throw new Exception("La solicitud de pago " + errMsg + " no tiene detalle cargado.");
                        }

                        dbContextTransaction.Commit();
                        success = true;
                        f.Close();
                    }
                    catch (DbEntityValidationException e)
                    {
                        f.Close();
                        string error = "";
                        string sError = "";
                        foreach (var eve in e.EntityValidationErrors)
                        {
                            error = String.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                                eve.Entry.Entity.GetType().Name, eve.Entry.State);

                            foreach (var ve in eve.ValidationErrors)
                            {
                                sError = String.Format("Property: \"{0}\", Error: \"{1}\"",
                                    ve.PropertyName, ve.ErrorMessage);
                            }
                        }
                        dbContextTransaction.Rollback();
                        MessageBox.Show("Ocurrió un error al procesar la actualización: " + Environment.NewLine
                                        + error + Environment.NewLine
                                        + sError,
                                        "Error al guardar los datos",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Stop);
                    }
                    catch (Exception ex)
                    {
                        f.Close();
                        dbContextTransaction.Rollback();

                        string innerException = String.Empty;

                        if (ex.InnerException != null)
                        {
                            innerException += "Detalle: ";
                            innerException += ex.InnerException.InnerException != null
                                              ? ex.InnerException.InnerException.Message
                                              : ex.InnerException.Message;
                        }

                        MessageBox.Show("Ocurrió un error al procesar la actualización: "
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
                MessageBox.Show("Operación terminada con éxito.", "Información");
                return;
            }
        }

        private void dgvPlanilla_DataSourceChanged(object sender, EventArgs e)
        {
            this.btnAceptar.Enabled = this.dgvPlanilla.DataSource != null;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (tSBProveedorFiltro.KeyMember.Trim() == string.Empty)
            {
                MessageBox.Show("Debe seleccionar un proveedor para realizar la búsqueda.",
                               "Información",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return;
            }


            using (BerkeDBEntities context = new BerkeDBEntities())
            {
                int proveedorId = Convert.ToInt32(this.tSBProveedorFiltro.KeyMember);
                string nroFactura = this.txtNroFacturaFiltro.Text;
                int usuarioId = Convert.ToInt32(VWGContext.Current.Session["UsuarioID"].ToString());

                this.ListaFacturas = context.GetListaSolArchivo(proveedorId, nroFactura, usuarioId).ToList();
            }
            var qry = this.ListaFacturas
                        .GroupBy(x => new { x.SolPagoArchCabId }).Select(g => g.First()).ToList();
            this.dgvRevertir.DataSource = qry;
            this.FormatearGrillaRevertir();
        }

        private void dgvRevertir_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvRevertir.Columns[e.ColumnIndex].Name == CAMPO_VERDETALLES)
            {
                int solArchCabId = Convert.ToInt32(this.dgvRevertir.Rows[e.RowIndex].Cells[CAMPO_SOLPAGOARCHCABID].Value);
                var qry = this.ListaFacturas.Where(a => a.SolPagoArchCabId == solArchCabId).ToList();
                fDSolArch = new FDetalleSolArchivo(qry);
                fDSolArch.FormClosed += delegate { f = null; };
                fDSolArch.ShowDialog();
            }
        }

        private void dgvRevertir_DataSourceChanged(object sender, EventArgs e)
        {
            this.btnRevertir.Enabled = this.dgvRevertir.DataSource != null;
        }

        private void btnRevertir_Click(object sender, EventArgs e)
        {
            if (this.GetCantidadSeleccionados() == 0)
            {
                MessageBox.Show("Debe seleccionar alguna factura para revertir.",
                               "Información",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return;
            }

            string message = "Se revertirá el procesamiento de todas las facturas seleccionadas ¿Desea continuar?";
            string caption = "Reversión de Procesamiento";

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBox.Show(message, caption, buttons,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                            new EventHandler(ProcessHandlerRevertir));
        }

        private void ProcessHandlerRevertir(object sender, EventArgs e)
        {
            Form msgForm = sender as Form;
            if (msgForm != null)
            {
                if (msgForm.DialogResult == Gizmox.WebGUI.Forms.DialogResult.No)
                {
                    return;
                }
                else
                {
                    this.Revertir();
                }
            }
        }

        private bool ExistenPagosAsociados(int solicitudPagoCabID, BerkeDBEntities context)
        {
            var query = (from sxp in context.sxp_solicitudesxpago
                         join pProv in context.ps_pagosolicitud
                             on sxp.sxp_pagosolicitudid equals pProv.ps_pagosolicitudid
                         select new
                         {
                             PagoProveedorID = pProv.ps_pagosolicitudid,
                             SolicitudPagoCabID = sxp.sxp_solicitudpagocabid,
                             Anulado = pProv.ps_anulado
                         }).Where(a => a.SolicitudPagoCabID == solicitudPagoCabID && !a.Anulado)
                        .ToList();

            return query.Count > 0 ? true : false;
        }

        private void Revertir()
        {
            string facturas = string.Empty;
            List<ListaSolArchivo> procList = new List<ListaSolArchivo>();
            foreach (DataGridViewRow row in this.dgvRevertir.Rows)
            {
                if ((row.Cells[CAMPO_SELECCIONAR].Value != null) && (Convert.ToBoolean(row.Cells[CAMPO_SELECCIONAR].Value)))
                {
                    if ((row.Cells[CAMPO_TIENEAUTORIZACIONVIGENTE].Value != null) && (!Convert.ToBoolean(row.Cells[CAMPO_TIENEAUTORIZACIONVIGENTE].Value)))
                    {
                        facturas += (facturas != string.Empty ? ", " : string.Empty) + row.Cells[CAMPO_SOLPAGOARCHCABNROFACTURA].Value.ToString();
                    }
                    else
                    {
                        procList.Add((ListaSolArchivo)row.DataBoundItem);
                    }

                    if (facturas != string.Empty)
                    {
                        string msg = "La factura {0} no tiene autorización para el proceso de reversión. Debe generar una autorización.";
                        if (facturas.Split(',').Count() > 1)
                            msg = "Las facturas {0} no tienen autorización para el proceso de reversión. Debe generar una autorización.";

                        MessageBox.Show(string.Format(msg, facturas),
                               "Información",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                        return;
                    }
                }
            }

            string facturasErr = string.Empty;
            string errorMsgs = string.Empty;
            facturas = string.Empty;

            using (var context = new BerkeDBEntities())
            {
                foreach (ListaSolArchivo row in procList)
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var qry = this.ListaFacturas.Where(a => a.SolPagoArchCabId == row.SolPagoArchCabId).ToList();

                            foreach (var d in qry)
                            {
                                spd_solicitudpagodet spd = new spd_solicitudpagodet();
                                spd = context.spd_solicitudpagodet.FirstOrDefault(a => a.spd_solicitudpagodetid == d.SolPagoArchDetSolPagoDetId);
                                spd.spd_nrofactura = null;
                                spd.spd_fechafactura = null;
                                //spd.spd_proveedorid = Convert.ToInt32(row.Cells[CAMPO_PROVEEDORID].Value);
                                spd.spd_cantidadiva10 = 0;
                                spd.spd_precunitiva10 = 0;
                                spd.spd_iva10 = 0;
                                spd.spd_total = 0;
                                spd.spd_saldo = 0;
                                spd.spd_tipofacturaid = null;

                                if (this.ExistenPagosAsociados(d.SolPagoArchCabSolPagoCabId, context))
                                {
                                    throw new Exception("No se puede revertir, la solicitud " + d.SolPagoArchCabSolPagoCabId.ToString() +
                                                         " tiene pagos asociados.");
                                }

                                spc_solicitudpagocab spc = new spc_solicitudpagocab();
                                spc = context.spc_solicitudpagocab.FirstOrDefault(a => a.spc_solicitudpagocabid == d.SolPagoArchCabSolPagoCabId);
                                spc.spc_importe = 0;
                                spc.spc_saldo = 0;
                            }

                            spac_solicitudpagoarchivocab spac = new spac_solicitudpagoarchivocab();
                            spac = context.spac_solicitudpagoarchivocab.FirstOrDefault(a => a.spac_solicitudpagoarchivocabid == row.SolPagoArchCabId);
                            spac.spac_activo = false;
                            context.SaveChanges();
                            dbContextTransaction.Commit();

                            facturas += (facturas != string.Empty ? ", " : string.Empty) + row.SolPagoArchCabNroFactura;
                        }
                        catch (Exception ex)
                        {
                            dbContextTransaction.Rollback();
                            facturasErr += (facturasErr != string.Empty ? ", " : string.Empty) + row.SolPagoArchCabNroFactura;

                            string innerException = String.Empty;

                            if (ex.InnerException != null)
                            {
                                innerException += "Detalle: ";
                                innerException += ex.InnerException.InnerException != null
                                                  ? ex.InnerException.InnerException.Message
                                                  : ex.InnerException.Message;
                            }

                            errorMsgs += ex.Message + Environment.NewLine + innerException;
                        }
                    }

                }
            }

            string resume = string.Empty;

            if (facturasErr == string.Empty)
            {
                MessageBox.Show("Reversión exitosa", "Información");
                return;
            }
            else
            {
                string successMsg = "La reversión de las facturas {0} fue exitosa.";
                string errMsg = "La reversión de las facturas {0} no pudo completarse debido los siguientes errores: " +
                                    Environment.NewLine + "{1}";
                if (facturas != string.Empty)
                {
                    resume += string.Format(successMsg, facturas);
                }

                if (facturasErr != string.Empty)
                {
                    resume += string.Format(errMsg, facturasErr, errorMsgs);
                }
            }
            MessageBox.Show(resume, "Información");
        }

        private int GetCantidadSeleccionados()
        {
            int Result = 0;
            foreach (DataGridViewRow row in this.dgvRevertir.Rows)
            {
                if ((row.Cells[CAMPO_SELECCIONAR].Value != null) && ((bool)row.Cells[CAMPO_SELECCIONAR].Value))
                    Result++;
            }

            return Result;
        }

        private void dgvRevertir_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.RowIndex > -1) &&
                (this.dgvRevertir.Rows[e.RowIndex].Cells[CAMPO_TIENEAUTORIZACIONVIGENTE].Value != null) &&
                ((bool)(this.dgvRevertir.Rows[e.RowIndex].Cells[CAMPO_TIENEAUTORIZACIONVIGENTE].Value)))
            {
                ((DataGridView)sender).Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
            }
        }

        private void ExportToCsv<T>(List<T> data, string filePath)
        {
            // Obtiene las propiedades públicas de la clase T
            PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            // Crea un StringBuilder para escribir los datos en formato CSV
            StringBuilder sb = new StringBuilder();

            // Agrega el encabezado al archivo CSV
            sb.AppendLine(string.Join(",", properties.Select(p => p.Name)));

            // Agrega los datos al archivo CSV
            foreach (T item in data)
            {
                sb.AppendLine(string.Join(",", properties.Select(p => p.GetValue(item, null))));
            }

            // Escribe los datos en un archivo CSV
            File.WriteAllText(filePath, sb.ToString());
        }
    }

    public class PlanillaTraduccionesType
    {
        public string NroFactura { get; set; }
        public DateTime FechaFactura { get; set; }
        public int SolPagoCabID { get; set; }
        public int ProveedorID { get; set; }
        public string ProveedorNombre { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal PrecioTotal { get; set; }
        public int Cantidad { get; set; }
        public Nullable<int> ClienteID { get; set; }
        public string ClienteNombre { get; set; }
        public int TipoFacturaID { get; set; }
        public string TipoFacturaDescrip { get; set; }
        public string MonedaAbrev { get; set; }
    }
}