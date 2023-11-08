#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Resources;
using System.IO;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Gateways;

using ModelEF6;
using SPF.Forms;
using SPF.Forms.UI;
using Berke.Libs.Base.Helpers;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.ObjectModel;

using System.Globalization;
using System.Text.RegularExpressions;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Style;



#endregion

namespace SPF.UserControls.Base
{
    public partial class ucBaseForm2015 : UserControl
    {
        #region Constantes
        private const string MENU_ITEM_DETALLE = "detalleMenuItem";
        private const string MENU_ITEM_LISTADO = "listadoMenuItem";
        private const string MENU_ITEM_ELEGIR = "elegirMenuItem";
        public const string BROWSE = "BROWSE";
        public const string INSERT = "INSERT";
        public const string EDIT = "EDIT";
        public const string NONE = "NONE";
        private const string IE_BROWSER = "InternetExplorer";
        #endregion Constantes

        #region Propiedades
        public string InsertActionMessage
        {
            get { return this.insertActionMessage; }
            set { this.insertActionMessage = value; }
        }

        public string InsertActionCaption
        {
            get { return this.insertActionCaption; }
            set { this.insertActionCaption = value; }
        }

        public bool IsClosing
        {
            get { return this.closing; }
        }

        public bool IsCancelling
        {
            get { return this.cancelling; }
            set { this.cancelling = value; }
        }

        public bool ValidOK
        {
            get { return this.validOK; }
            set { this.validOK = value; }
        }

        public string TituloTabListado
        {
            get { return this.tpListado.Text; }
            set { this.tpListado.Text = value; }
        }

        public string TituloDetalle
        {
            get { return this.tpDetalle.Text; }
            set { this.tpDetalle.Text = value; }
        }
        public string Titulo
        {
            get { return this.lblTitulo.Text; }
            set { this.lblTitulo.Text = value; }
        }

        public BerkeDBEntities DBContext
        {
            get { return this.dbContext; }
            set { this.dbContext = value; }
        }

        public Object BindingSourceBase
        {
            get { return this.bS; }
            set { this.bS.DataSource = value; }
        }

        public Object GridDataSource
        {
            set { this.dgvListadoABM.DataSource = value; }
        }

        public Object BindingSourceBase_ExportExcelGrid
        {
            get { return this.bS_ExportExcelGrid; }
            set { this.bS_ExportExcelGrid.DataSource = value; }
        }

        public Stack<object[]> StackCampos
        {
            get { return this.campos; }
            //set { this.campos = value; }
        }

        public string TituloBuscador
        {
            get { return this.tituloBuscador; }
            set { this.tituloBuscador = value; }
        }

        public string SQLWhereString
        {
            get { return this.sqlWhereString; }
            set { this.sqlWhereString = value; }
        }

        public List<int> ListaValoresEnteros
        {
            get { return this.listaValoresEnteros; }
            set { this.listaValoresEnteros = value; }
        }

        public TabControl Tab
        {
            get { return this.tabListaABM; }
        }

        public string FormEditStatus
        {
            get { return this.txtFormEditStatus.Text; }
            set { this.txtFormEditStatus.Text = value; }
        }

        public Control ParentControl
        {
            get
            {
                return this.parentControl;
            }
            set
            {
                this.parentControl = value;
            }
        }


        public bool isForm
        {
            get
            {
                return this.esForm;
            }
            set
            {
                this.esForm = value;
            }
        }

        public int LastDGVIndex
        {
            set { this.lastDGVIndex = value; }
            get { return this.lastDGVIndex; }
        }

        public string WhereString
        {
            get 
            {
                if (fBuscar != null)
                    return this.getParseString(fBuscar.SQLWhereString);
                else
                    return "";
            }
        }

        public object[] FilterParam
        {
            get 
            {
                if (this.filterParam != null)
                    return this.filterParam.ToArray();
                else
                    return null;
            }
        }

        public bool UseSQLSyntax
        {
            get
            {
                return this.useSQLSyntax;
            }
            set
            {
                this.useSQLSyntax = value;
            }
        }
        
        #endregion Propiedades

        #region Variables
        private BerkeDBEntities dbContext;
        private BindingSource bS;
        private BindingSource bS_ExportExcelGrid;
        private Stack<object []> campos;
        private string tituloBuscador = "";
        private frmBuscadorBase fBuscar;
        private bool closing = false;
        private bool cancelling = false;
        private const int DEFAULT_COMPARISON_TYPE = 0;
        private string sqlWhereString = "";
        private List<int> listaValoresEnteros;
        private List<object> filterParam;
        ResourceManager rm;
        private Control parentControl = null;
        private bool esForm = false;
        private int lastDGVIndex = -1;
        private bool useSQLSyntax = false;
        private bool changePage = false;
        private bool validOK = true;
        private string insertActionMessage = "Se insertará un nuevo registro ¿Desea continuar?";
        private string insertActionCaption = "Inserción de nuevo de registro";
        public object tEntity = null;        
        #endregion Variables

        #region Eventos Delegados
        public delegate void ButtonClickedEventHandler(object sender, EventArgs e);
        public event ButtonClickedEventHandler OnUserControlButtonClicked;
        public event EventHandler ValidarCamposEvent;
        public event EventHandler CRUDEvent;
        #endregion Eventos Delegados

        #region Métodos de inicio
        public ucBaseForm2015()
        {
            InitializeComponent();
            //this.FormatearGrilla();
            this.InicializarBotones();
            campos = new Stack<object[]>();
            bS = new BindingSource();
            bS_ExportExcelGrid = new BindingSource();
            rm = new ResourceManager(typeof(ucBaseForm2015));
        }

        protected virtual void ucBaseForm_Load(object sender, EventArgs e)
        {
            this.dgvListadoABM.DataSource = this.bS;
            this.FormEditStatus = BROWSE;
            this.FormatearGrilla();
            this.lastDGVIndex = -1;

            if (this.dgvListadoABM.Rows.Count > 0)
            {
                this.lastDGVIndex = 0;
            }
            //    this.dgvListadoABM.CurrentCell = this.dgvListadoABM.Rows[this.lastDGVIndex].Cells[0];
            //    this.dgvListadoABM.Focus();                
            //}
            
            
        }

        public void LoadGridExportToExcel()
        {
            //this.dgvExportarExcel.DataSource = this.bS_ExportExcelGrid;
        }

        protected virtual void FormatearGrilla()
        {
            //this.dgvListadoABM.AlternatingRowsDefaultCellStyle.Font = new Font("Arial", 9.5F, GraphicsUnit.Pixel);
            //this.dgvListadoABM.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            //this.dgvListadoABM.DefaultCellStyle.Font = new Font("Arial", 9.5F, GraphicsUnit.Pixel);
            //this.dgvListadoABM.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;
            //this.dgvListadoABM.RowsDefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            //this.dgvListadoABM.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //this.dgvListadoABM.MultiSelect = false;
            //this.dgvListadoABM.ItemsPerPage = 14;

            this.dgvListadoABM.AlternatingRowsDefaultCellStyle.Font = new Font("Arial", 9.5F, GraphicsUnit.Pixel);
            this.dgvListadoABM.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            this.dgvListadoABM.DefaultCellStyle.Font = new Font("Arial", 9.5F, GraphicsUnit.Pixel);
            this.dgvListadoABM.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;
            this.dgvListadoABM.RowsDefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            this.dgvListadoABM.ItemsPerPage = 14;
            this.dgvListadoABM.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvListadoABM.MultiSelect = false;
        }

        private void InicializarBotones()
        {
            //this.btnBusqAvanzada.Text = "Búsqueda" + Environment.NewLine + "Avanzada";
            this.tbbImprimir.Visible = false;
        }

        private string getParseString(string where)
        {
            var regex = new Regex(@"\b\d{2}\/\d{2}/\d{4}\b");
            filterParam = new List<object>();
            int cont = 0;
            foreach (Match m in regex.Matches(where))
            {
                DateTime dt;
                if (DateTime.TryParseExact(m.Value, "dd/MM/yyyy", null, DateTimeStyles.None, out dt))
                {
                    where = where.Replace("\"" + m.Value + "\"", "@" + cont.ToString());
                    filterParam.Add(dt);
                    cont++;
                }
            }
            return where;
        }
        #endregion Métodos de inicio

        #region Métodos de apoyo
        private void SetFocusGrid()
        {
            if (this.dgvListadoABM.Rows.Count > 0)
            {
                this.dgvListadoABM.CurrentCell = this.dgvListadoABM.Rows[this.LastDGVIndex].Cells[0];
                this.dgvListadoABM.CurrentCell.Selected = true;
                this.dgvListadoABM.Focus();
            }
        }

        protected string GetString(string valor)
        {
            return valor.Trim() != "" ? valor : "";

        }

        private void ExportarExcel(List<DataGridViewColumn> colList = null)
        {
            ExcelPackage p = new ExcelPackage();
            p.Workbook.Worksheets.Add("DatosGrilla");
            ExcelWorksheet ws = p.Workbook.Worksheets[1];
            ws.Name = "DatosGrilla"; //Setting Sheet's name
            ws.Cells.Style.Font.Size = 11; //Default font size for whole sheet
            ws.Cells.Style.Font.Name = "Calibri";

            if (colList == null)
                colList = this.VisibleColumnsList().OrderBy(a => a.DisplayIndex).ToList();
                //List<DataGridViewColumn> vcl = this.VisibleColumnsList().OrderBy(a => a.DisplayIndex).ToList();

            this.CrearCabeceraExcel(ws, colList);
            this.CargarDatosExcel(ws, colList);

            Byte[] bin = p.GetAsByteArray();
            string path = VWGContext.Current.Server.MapPath(@"\Resources\UserData\" + VWGContext.Current.Session["WindowsUser"].ToString() + @"\");
            Berke.Libs.Base.Helpers.Files.CreateDirectory(@path);
            string fileName = @path + "Grilla-" + DateTime.Now.Ticks.ToString() + ".xlsx";
            Berke.Libs.Base.Helpers.Files.SaveBytesToFile(bin, @fileName);

            ws.Dispose();
            p.Dispose();

            GC.Collect();

            DownloadGateway download = new DownloadGateway(@fileName);
            download.StartDownload(this);
        }

        private List<DataGridViewColumn> VisibleColumnsList()
        {
            List<DataGridViewColumn> Result = new List<DataGridViewColumn>();
            foreach (DataGridViewColumn col in this.dgvListadoABM.Columns)
            {
                if (col.Visible)
                {
                    if (col.GetType() != typeof(DataGridViewCheckBoxColumn))
                        Result.Add(col);
                    else
                    {
                        DataGridViewTextBoxColumn txtCol = new DataGridViewTextBoxColumn();
                        txtCol.DataPropertyName = col.DataPropertyName;
                        txtCol.Name = col.Name;
                        txtCol.DisplayIndex = col.DisplayIndex;
                        txtCol.HeaderText = col.HeaderText;
                        txtCol.ValueType = col.ValueType;
                        Result.Add(txtCol);
                    }
                }
            }
            return Result;
        }

        private List<DataGridViewColumn> AllColumnsList()
        {
            List<DataGridViewColumn> Result = new List<DataGridViewColumn>();
            foreach (DataGridViewColumn col in this.dgvExportarExcel.Columns)
            {
                Result.Add(col);
            }
            return Result;
        }

        private List<string> ColumnsNamesList()
        {
            List<string> Result = new List<string>();
            foreach (DataGridViewColumn col in this.dgvExportarExcel.Columns)
            {
                Result.Add(col.Name);
            }
            return Result;
        }

        private void CrearCabeceraExcel(ExcelWorksheet ws, List<DataGridViewColumn> vcl)
        {
            int colIndex = 0;
            foreach (DataGridViewColumn col in vcl)
            {
                colIndex++;
                var cell = ws.Cells[1, colIndex];

                //Setting the background color of header cells to Gray
                var fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightBlue);

                //Setting Top/left,right/bottom borders.
                var border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                //Setting Value in cell
                cell.Value = col.HeaderText;
            }

        }

        private void CargarDatosExcel(ExcelWorksheet ws, List<DataGridViewColumn> vcl)
        {
            int colIndex = 0;
            for (int i = 0; i < this.dgvExportarExcel.RowCount; i++)
            //for (int i = 0; i < this.dgvExportarExcel.RowCount; i++)
            {
                colIndex = 0;
                foreach (DataGridViewColumn col in vcl)
                {
                    colIndex++;
                    var cell = ws.Cells[i + 2, colIndex];
                    var border = cell.Style.Border;
                    border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                    if (col.ValueType.FullName.IndexOf(typeof(DateTime).FullName) > -1)
                    {
                        cell.Style.Numberformat.Format = "dd/mm/yyyy";
                        cell.Value = this.dgvExportarExcel.Rows[i].Cells[col.Name].Value != null ?
                                this.dgvExportarExcel.Rows[i].Cells[col.Name].Value :
                                null;
                    }
                    else if (col.ValueType.FullName.IndexOf(typeof(decimal).FullName) > -1)
                    {
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        cell.Style.Numberformat.Format = "#,##0.00";
                        cell.Value = this.dgvExportarExcel.Rows[i].Cells[col.Name].Value != null ?
                            this.dgvExportarExcel.Rows[i].Cells[col.Name].Value :
                            null;
                    }
                    else if (col.ValueType.FullName.IndexOf(typeof(Boolean).FullName) > -1)
                    {
                        if (this.dgvExportarExcel.Rows[i].Cells[col.Name].Value != null)
                        {
                            string valStr = this.dgvExportarExcel.Rows[i].Cells[col.Name].Value.ToString();
                            bool valBool = false;
                            if ((valStr == "1" ) || (valStr.ToUpper() == "TRUE"))
                                valBool = true;

                            cell.Value =  valBool ? "Si" : "No";
                        }
                        else
                            cell.Value = "No";
                    }
                    else if (col.ValueType.FullName.IndexOf(typeof(int).FullName) > -1)
                    {
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        cell.Style.Numberformat.Format = "0";
                        cell.Value = this.dgvExportarExcel.Rows[i].Cells[col.Name].Value != null ?
                            this.dgvExportarExcel.Rows[i].Cells[col.Name].Value :
                            null;
                    }
                    else
                        cell.Value = this.dgvExportarExcel.Rows[i].Cells[col.Name].Value != null ?
                            this.dgvExportarExcel.Rows[i].Cells[col.Name].Value :
                            null;

                }
            }

            for (int j = 1; j <= colIndex; j++)
            {
                ws.Column(j).AutoFit();
            }
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Ocurrió un error al liberar el objeto." + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        protected virtual void FilterEntity(string where = "", object[] filterParams = null)
        {
            //Se debe implementar en el UserControl heredado

        }

        public void SetFilter(string claveCampo, string campoDescripcion, bool IsString = true)
        {
            campos.Push(new object[] { claveCampo, campoDescripcion, IsString });
        }

        protected virtual void Editable(bool editar)
        {
            //
        }

        protected virtual void GuadarRegistro(object sender, EventArgs e)
        {
            Form msgForm = sender as Form;
            if (msgForm != null)
            {
                if (msgForm.DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
                {
                    MessageBox.Show("Yes was chosen");
                }
                else
                {
                    MessageBox.Show("No was chosen");
                }
            }

            //if (((MessageBoxWindow)sender).DialogResult == DialogResult.Yes)
            //    this.ProcesarGuardado();

            //((MessageBoxWindow)sender).Close();
        }

        
        #endregion Métodos de apoyo

        #region Métodos sobre Controles
        private void ucBaseForm_GotFocus(object sender, EventArgs e)
        {
            this.SetFocusGrid();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            // Delegate the event to the caller
            if (OnUserControlButtonClicked != null)
            {
                this.closing = true;
                OnUserControlButtonClicked(this, e);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (fBuscar == null)
            {
                fBuscar = new frmBuscadorBase(this.StackCampos, this.UseSQLSyntax);
                fBuscar.Text = this.TituloBuscador;
                //fBuscar.FormClosed += fBuscar_FormClosed;
                fBuscar.AceptarClick += fBuscar_AceptarClick;
                fBuscar.MostrarFiltro();
                }
            else fBuscar.MostrarFiltro(true);

            //MessageBox.Show(fBuscar.SQLWhereString);
        }

        private void fBuscar_AceptarClick(object sender, EventArgs e)
        {
            if (this.FormEditStatus != BROWSE)
            {
                MessageBox.Show("Operaciones pendientes, favor guarde o cancele la edición actual.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string whereStr = fBuscar != null ? fBuscar.SQLWhereString : String.Empty;
            if (this.UseSQLSyntax)
            {
                this.FilterEntity(whereStr.Replace('\"', '\''), null);
                //this.FilterEntity(fBuscar.SQLWhereString.Replace('\"', '\''), null);
            }
            else
            {

                this.FilterEntity(this.getParseString(whereStr), this.filterParam.ToArray());
                //this.FilterEntity(this.getParseString(fBuscar.SQLWhereString), this.filterParam.ToArray());
            }

            this.SetFocusGrid();
        }

        #region Deprecated
        private void fBuscar_FormClosed(object sender, FormClosedEventArgs e)
        {

            if (this.FormEditStatus != BROWSE)
            {
                MessageBox.Show("Operaciones pendientes, favor guarde o cancele la edición actual.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (fBuscar.SQLWhereString != "")
            {
                this.FilterEntity(this.getParseString(fBuscar.SQLWhereString), this.filterParam.ToArray());
            }
            
        }
        #endregion Deprecated

        protected virtual void dgvListadoABM_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            
            //if (((((DataGridView)sender).Focused) && (this.Parent.Parent != null)))//== typeof(Inicio))))
            
            if ((sender.GetType() == typeof(DataGridView)) && (this.Parent != null))
            {
                int index = e.RowIndex + 1;

                if (!this.isForm)
                {
                    if (Context.HttpContext.Request.Browser.Browser != IE_BROWSER)
                    {
                        ((Inicio)Parent.Parent).Estado = "Registro " + (index).ToString().Trim()
                                                         + " de " + ((DataGridView)sender).RowCount.ToString();
                    }
                    else
                    {
                        ((Inicio)Parent.Parent).SetStatusBarText("Registro " + (index).ToString().Trim()
                                                         + " de " + ((DataGridView)sender).RowCount.ToString());
                    }
                }

                if (index % this.dgvListadoABM.ItemsPerPage == 0)
                    changePage = true;
                else
                    changePage = false;

                this.LastDGVIndex = e.RowIndex; // this.dgvListadoABM.CurrentRow.Index;
            
            }

            //((Inicio)Parent.Parent).Estado = e.RowIndex.ToString();
             
        }

        private void dgvListadoABM_SelectionChanged(object sender, EventArgs e)
        {
            if ((sender.GetType() == typeof(DataGridView)) && (this.Parent != null))
            {
                if ((!this.closing) && (((DataGridView)sender).SelectedRows.Count > 0))
                {
                    int index = ((DataGridView)sender).SelectedRows[0].Index + 1;

                    if (!this.isForm)
                    {
                        if (Context.HttpContext.Request.Browser.Browser != IE_BROWSER)
                        {
                            ((Inicio)Parent.Parent).Estado = "Registro " + (index).ToString().Trim()
                                                             + " de " + ((DataGridView)sender).RowCount.ToString();
                        }
                        else
                        {
                            ((Inicio)Parent.Parent).SetStatusBarText("Registro " + (index).ToString().Trim()
                                                             + " de " + ((DataGridView)sender).RowCount.ToString());
                        }
                        //((Inicio)Parent.Parent).Estado = "Registro " + (index).ToString().Trim()
                        //                                 + " de " + ((DataGridView)sender).RowCount.ToString();
                        //((Inicio)Parent.Parent).SetStatusBarText("Registro " + (index).ToString().Trim()
                        //                                 + " de " + ((DataGridView)sender).RowCount.ToString());
                    }
                }
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            int index = this.dgvListadoABM.Rows.GetFirstRow(DataGridViewElementStates.None);
            this.dgvListadoABM.CurrentCell = this.dgvListadoABM.Rows[index].Cells[0];
            this.dgvListadoABM.Focus();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int index = this.dgvListadoABM.Rows.GetNextRow(this.dgvListadoABM.SelectedRows[0].Index, DataGridViewElementStates.None);
            if (index > -1)
            {
                this.dgvListadoABM.CurrentCell = this.dgvListadoABM.Rows[index].Cells[0];
                this.dgvListadoABM.Focus();
            }
        }

        private void btnPrior_Click(object sender, EventArgs e)
        {
            int index = this.dgvListadoABM.Rows.GetPreviousRow(this.dgvListadoABM.SelectedRows[0].Index, DataGridViewElementStates.None);

            if (index > -1)
            {
                this.dgvListadoABM.CurrentCell = this.dgvListadoABM.Rows[index].Cells[0];
                this.dgvListadoABM.Focus();
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            int index = this.dgvListadoABM.Rows.GetLastRow(DataGridViewElementStates.None);
            this.dgvListadoABM.CurrentCell = this.dgvListadoABM.Rows[index].Cells[0];
            this.dgvListadoABM.Focus();
        }

        private void dgvListadoABM_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.Down:
                    int indexAnterior = this.dgvListadoABM.CurrentRow.Index;
                    int indexActual = this.dgvListadoABM.CurrentRow.Index + 1;

                    if ((indexActual + 1) % this.dgvListadoABM.ItemsPerPage == 0)
                    {
                        indexAnterior++;
                        indexActual++;
                    }

                    //int page = (indexAnterior / this.dgvListadoABM.ItemsPerPage) + 1;

                    //if (indexActual > this.dgvListadoABM.ItemsPerPage)
                    //{
                    //    this.btnNext.PerformClick();
                    //}


                    //MessageBox.Show("Índice Anterior: " + indexAnterior.ToString() + Environment.NewLine +
                    //                "Índice Actual: " + indexActual.ToString());
                    break;
                case (char)Keys.Up:

                    break;
            }
        }

        private void dgvListadoABM_KeyDown(object objSender, KeyEventArgs objArgs)
        {
            
            
        }

        protected virtual void txtFormEditStatus_TextChanged(object sender, EventArgs e)
        {
            if (this.FormEditStatus == BROWSE)
            {
                tbbBuscar.Enabled = true;
                tbbNuevo.Enabled = true;

                if (this.dgvListadoABM.RowCount > 0)
                {
                    tbbEditar.Enabled = true;
                    tbbBorrar.Enabled = true;
                    
                }
                else
                {
                    tbbEditar.Enabled = false;
                    tbbBorrar.Enabled = false;
                }
                tbbImprimir.Enabled = true;
                tbbGuardar.Enabled = false;
                tbbCancelar.Enabled = false;
                tbbCerrar.Enabled = true;
                tbbFirst.Enabled = true;
                tbbPrior.Enabled = true;
                tbbNext.Enabled = true;
                tbbLast.Enabled = true;
                tbbExportarExcel.Enabled = true;

                this.Editable(true);
            }
            else if (this.FormEditStatus == INSERT)
            {
                tbbBuscar.Enabled = false;
                tbbNuevo.Enabled = false;
                tbbEditar.Enabled = false;
                tbbBorrar.Enabled = false;
                tbbImprimir.Enabled = false;
                tbbGuardar.Enabled = true;
                tbbCancelar.Enabled = true;
                tbbCerrar.Enabled = false;
                tbbFirst.Enabled = false;
                tbbPrior.Enabled = false;
                tbbNext.Enabled = false;
                tbbLast.Enabled = false;
                tbbExportarExcel.Enabled = false;

                this.Editable(false);

                //if (this.dgvListadoABM.CurrentRow != null)
                //    this.LastDGVIndex = this.dgvListadoABM.CurrentRow.Index;
            }
            else if (this.FormEditStatus == EDIT)
            {
                tbbBuscar.Enabled = false;
                tbbBuscar.Enabled = false;
                tbbNuevo.Enabled = false;
                tbbEditar.Enabled = false;
                tbbBorrar.Enabled = false;
                tbbImprimir.Enabled = false;
                tbbGuardar.Enabled = true;
                tbbCancelar.Enabled = true;
                tbbCerrar.Enabled = false;
                tbbFirst.Enabled = false;
                tbbPrior.Enabled = false;
                tbbNext.Enabled = false;
                tbbLast.Enabled = false;
                tbbExportarExcel.Enabled = false;

                this.Editable(false);

                //if (this.dgvListadoABM.CurrentRow != null)
                //    this.LastDGVIndex = this.dgvListadoABM.CurrentRow.Index;
            }
        }

        protected virtual void tbbBuscar_Click(object sender, EventArgs e)
        {
            if (fBuscar == null)
            {
                fBuscar = new frmBuscadorBase(this.StackCampos, this.UseSQLSyntax);
                fBuscar.Text = this.TituloBuscador;
                //fBuscar.FormClosed += fBuscar_FormClosed;
                fBuscar.AceptarClick += fBuscar_AceptarClick;
                fBuscar.MostrarFiltro();
            }
            else fBuscar.MostrarFiltro(true);
        }

        protected virtual void tbbNuevo_Click(object sender, EventArgs e)
        {
            this.tabListaABM.SelectedIndex = 1;
            this.FormEditStatus = INSERT;
        }

        protected virtual void tbbEditar_Click(object sender, EventArgs e)
        {
            this.tabListaABM.SelectedIndex = 1;
            this.FormEditStatus = EDIT;
        }

        protected virtual void tbbBorrar_Click(object sender, EventArgs e)
        {
            string caption = "Eliminación de registro";
            string message = "Se eliminará el presente registro ¿Desea continuar?";

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBox.Show(message, caption, buttons,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                            new EventHandler(DialogHandler));
        }

        protected virtual void tbbImprimir_Click(object sender, EventArgs e)
        {
            //
        }

        protected virtual void tbbCancelar_Click(object sender, EventArgs e)
        {
            this.FormEditStatus = BROWSE;
            this.cancelling = true;
            if (this.LastDGVIndex > -1)
                this.dgvListadoABM.CurrentCell = this.dgvListadoABM.Rows[this.LastDGVIndex].Cells[0];

        }

        private void tbbCerrar_Click(object sender, EventArgs e)
        {
            // Delegate the event to the caller
            if (OnUserControlButtonClicked != null)
            {
                this.closing = true;
                OnUserControlButtonClicked(this, e);
            }
        }

        protected virtual void tabListaABM_SelectedIndexChanging(object sender, TabControlCancelEventArgs e)
        {
            if (this.FormEditStatus != BROWSE)
                e.Cancel = true;
        }

        private void dgvListadoABM_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.tabListaABM.SelectedIndex = 1;
        }

        private void tBBaseForm_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {

        }

        protected virtual void ucBaseForm_VisibleChanged(object sender, EventArgs e)
        {
            if (this.tabListaABM.SelectedIndex == 0)
                this.FormatearGrilla();
        }

        private void tbbExportarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.bS_ExportExcelGrid.DataSource != null)
                    this.dgvExportarExcel.DataSource = this.bS_ExportExcelGrid;
                else
                    this.dgvExportarExcel.DataSource = this.bS;
                //this.dgvExportarExcel = this.dgvExportarExcel == null ? this.dgvListadoABM : this.dgvExportarExcel;
                FSelColExportExcel f = new FSelColExportExcel(this.ColumnsNamesList());
                f.AceptarClick += f_AceptarClick;
                f.FormClosed += delegate { f = null; };
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al exportar la grilla." + ex.ToString());
            }

        }

        private void f_AceptarClick(object sender, AceptarClickEventArgs e)
        {
            List<DataGridViewColumn> colList = new List<DataGridViewColumn>();
            if (e.TipoSeleccion == AceptarClickEventArgs.TODAS)
            {
                //this.dgvExportarExcel.DataSource = this.bS;
                colList = this.AllColumnsList();
            }
            else if (e.TipoSeleccion == AceptarClickEventArgs.VISIBLES)
            {
                this.dgvExportarExcel.DataSource = this.bS;
                colList = null;
            }
            else
            {
                foreach (string colName in e.ListaColumnasSeleccionadas)
                {
                    foreach (DataGridViewColumn col in this.dgvExportarExcel.Columns)
                    {
                        if (col.Name == colName)
                            colList.Add(col);
                    }
                }

            }
            this.ExportarExcel(colList);
        }

        protected virtual void tbbGuardar_Click(object sender, EventArgs e)
        {
            this.ValidOK = true;
            if (this.ValidarCamposEvent != null)
            {
                this.ValidOK = false;
                this.ValidarCamposEvent(sender, e);
            }

            if (this.ValidOK)
            {
                string message = "";
                string caption = "";
                if (this.FormEditStatus == EDIT)
                {
                    caption = "Actualización de registro";
                    message = "Se modificará el presente registro ¿Desea continuar?";
                }
                else if (this.FormEditStatus == INSERT)
                {
                    caption = this.InsertActionCaption;//"Inserción de nuevo de registro";
                    message = this.InsertActionMessage;//"Se insertará un nuevo registro ¿Desea continuar?";
                }

                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBox.Show(message, caption, buttons,
                                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                                new EventHandler(DialogHandler));
            }
        }

        private void DialogHandler(object sender, EventArgs e)
        {
            Form msgForm = sender as Form;
            if (msgForm != null)
            {
                if (msgForm.DialogResult == Gizmox.WebGUI.Forms.DialogResult.Yes)
                {
                    if (this.CRUDEvent != null)
                        this.CRUDEvent(sender, e);
                }
            }
        }

        private void tbbActualizar_Click(object sender, EventArgs e)
        {
            this.fBuscar_AceptarClick(sender, e);
        }

        
        #endregion Métodos sobre Controles

        #region CRUD
        public TEntidad GuardarRegistro<TEntidad>(TEntidad registro) where TEntidad : class
        {
            TEntidad Result = null;
            //string connString = StringCipher.Decrypt(VWGContext.Current.Session["ConnString"].ToString(), "Nant3s2015*");

            using (var r = new Repositorio<TEntidad>())
            {
                using (var dbContextTransaction = r.Context.Database.BeginTransaction())
                {
                    try
                    {
                        if (this.FormEditStatus == INSERT)
                            Result = r.Insertar(registro);
                        else if (this.FormEditStatus == EDIT)
                            Result = r.Actualizar(registro);

                        dbContextTransaction.Commit();
                    }
                    catch (DbEntityValidationException e)
                    {
                        Result = null;
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
                        MessageBox.Show("Ocurrió un error al procesar el guardado: " + Environment.NewLine
                                        + error + Environment.NewLine
                                        + sError,
                                        "Error al guardar los datos",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Stop);
                    }
                    catch (Exception ex)
                    {
                        Result = null;
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
            
            return Result;
        }

        /// <summary>
        /// Guarda tablas de estructura cabecera/detalle
        /// </summary>
        /// <typeparam name="TEntidadCab">Entidad Cabecera</typeparam>
        /// <typeparam name="TEntidadDet">Entidad Detalle</typeparam>
        /// <param name="cab">Entidad Cabecera</param>
        /// <param name="listDet">Lista de detalles (Entidad Detalle)</param>
        /// <param name="pkName">Clave Primaria de la entidad cabecera</param>
        /// <param name="fkName">Clave Foránea en la entidad detalle</param>
        /// <returns></returns>
        public TEntidadCab GuardarRegistro<TEntidadCab, TEntidadDet>(TEntidadCab cab, List<TEntidadDet> listDet, string pkName, string fkName) 
            where TEntidadCab : class
            where TEntidadDet : class
        {
            TEntidadCab Result = null;

            using (var r = new Repositorio<TEntidadCab>())
            {
                using (var dbContextTransaction = r.Context.Database.BeginTransaction())
                {
                    try
                    {
                        if (this.FormEditStatus == INSERT)
                        {
                            Result = r.Insertar(cab);
                            r.Insertar<TEntidadDet>(Result, listDet, pkName, fkName);
                        }
                        else if (this.FormEditStatus == EDIT)
                        {
                            Result = r.Actualizar(cab);
                            //Falta implementación en Repositorio para casos de actualización
                            //r.Actualizar<TEntidadDet>(Result, listDet);
                        }

                        dbContextTransaction.Commit();
                    }
                    catch (DbEntityValidationException e)
                    {
                        Result = null;
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
                        MessageBox.Show("Ocurrió un error al procesar el guardado: " + Environment.NewLine
                                        + error + Environment.NewLine
                                        + sError,
                                        "Error al guardar los datos",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Stop);
                    }
                    catch (Exception ex)
                    {
                        Result = null;
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

            return Result;
        }

        public bool EliminarRegistro<TEntidad>(TEntidad registro) where TEntidad : class
        {
            bool Result = false;
            //string connString = StringCipher.Decrypt(VWGContext.Current.Session["ConnString"].ToString(), "Nant3s2015*");

            using (var r = new Repositorio<TEntidad>())
            {
                using (var dbContextTransaction = r.Context.Database.BeginTransaction())
                {
                    try
                    {
                        r.Eliminar(registro);
                        dbContextTransaction.Commit();
                        Result = true;
                    }
                    catch (DbEntityValidationException e)
                    {
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
                        MessageBox.Show("Ocurrió un error al procesar el guardado: " + Environment.NewLine
                                        + error + Environment.NewLine
                                        + sError,
                                        "Error al guardar los datos",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Stop);
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

            return Result;
        }
        #endregion CRUD

    }
}