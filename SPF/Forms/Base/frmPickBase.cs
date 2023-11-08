#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

using ModelEF6;
using SPF.Forms;
using SPF.Types;
using System.Data.Entity;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Dynamic;

using System.Data.SqlClient;
using System.Collections;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text.RegularExpressions;

#endregion

namespace SPF.Forms.Base
{
    public partial class frmPickBase : Form
    {
        #region Constantes
        private const int WINDOW_WIDTH = 477;
        private const int WINDOW_HEIGHT = 466;
        #endregion Constantes

        #region Variables
        private string campoid = "";
        private string campodescrip = "";
        private string labelcampoid = "";
        private string labelcampodescrip = "";
        private bool permitirFiltroNulo = false;
        private bool useExplicitToolTip = false;
        private int col1Widht = 80;
        private int col2Widht = 250;
        private bool columnIDVisible = true;
        private bool columnDescripVisible = true;
        #endregion Variables

        #region Propiedades
        public bool ColumnIDVisible
        {
            get { return this.columnIDVisible; }
            set { this.columnIDVisible = value; }
        }

        public bool ColumnDescripVisible
        {
            get { return this.columnDescripVisible; }
            set { this.columnDescripVisible = value; }
        }

        public int Col1Width
        {
            set { this.col1Widht = value; }
            get { return this.col1Widht; }
        }

        public int Col2Width
        {
            set { this.col2Widht = value; }
            get { return this.col2Widht; }
        }

        public string GetIDFilter
        {
            get { return this.txtID.Text; }
        }

        public string SetIDFilter
        {
            set { this.txtID.Text = value; }
        }

        public string GetDescripFilter
        {
            get { return this.txtDescrpcion.Text; }
        }

        public string SetDescripFilter
        {
            set { this.txtDescrpcion.Text = value; }
        }

        public bool UseExplicitToolTip
        {
            set { this.useExplicitToolTip = value; }
            get { return this.useExplicitToolTip; }
        }

        public string Titulo
        {
            set { this.Text = value; }
        }

        public string NombreCampo
        {
            set { this.lblCampo.Text = value; }
        }

        public string CampoIDNombre
        {
            set { this.campoid = value; }
            get { return this.campoid; }
        }

        public string LabelCampoID
        {
            set { this.labelcampoid = value; }
            get { return this.labelcampoid; }
        }

        public string CampoDescripNombre
        {
            set { this.campodescrip = value; }
            get { return this.campodescrip; }
        }

        public string LabelCampoDescrip
        {
            set { this.labelcampodescrip = value; }
            get { return this.labelcampodescrip; }
        }

        public string ValorID
        {
            get
            {
                if (this.dgvFiltro.Rows.Count > 0)
                    return dgvFiltro.CurrentRow.Cells[this.CampoIDNombre].Value.ToString();
                else
                    return "";

            }
        }

        public string ValorDescrip
        {
            get
            {
                if (this.dgvFiltro.Rows.Count > 0)
                    return dgvFiltro.CurrentRow.Cells[this.CampoDescripNombre].Value != null
                        ? dgvFiltro.CurrentRow.Cells[this.CampoDescripNombre].Value.ToString()
                        : "";
                else
                    return "";

            }
        }

        public bool PermitirFiltroNulo
        {
            set { this.permitirFiltroNulo = value; }
            get { return this.permitirFiltroNulo; }
        }

        public int RowCount
        {
            get { return this.dgvFiltro.Rows.Count; }
        }

        #endregion Propiedades

        #region Eventos personalizados
        public event EventHandler AceptarFiltrarClick;
        public event EventHandler FiltrarClick;
        #endregion Eventos personalizados

        #region Métodos de Inicio
        //public frmPickBase()
        //{
        //    InitializeComponent();
        //}

        public frmPickBase(int windowWidth = -1)
        {
            InitializeComponent();

            if (windowWidth != -1)
            {
                this.Size = new Size(windowWidth, WINDOW_HEIGHT);
            }
            else
            {
                this.Size = new Size(WINDOW_WIDTH, WINDOW_HEIGHT);
            }
        }

        public void init(string campoid, string campodescrip)
        {
            this.campoid = campoid;
            this.campodescrip = campodescrip;
        }

        private void frmPickBase_Load(object sender, EventArgs e)
        {
            if (!this.UseExplicitToolTip)
                this.SetToolTip();
        }
        #endregion Métodos de Inicio

        #region Métodos sobre Controles
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.AceptarFiltrarClick != null)
            {
                this.AceptarFiltrarClick(sender, e);
                //this.Close();
                //this.Dispose();
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (this.FiltrarClick != null)
            {
                this.FiltrarClick(sender, e);
                if (this.dgvFiltro.Rows.Count > 0)
                {
                    if (this.ColumnIDVisible)
                        this.dgvFiltro.CurrentCell = this.dgvFiltro.Rows[0].Cells[this.CampoIDNombre];
                    else this.dgvFiltro.CurrentCell = this.dgvFiltro.Rows[0].Cells[this.CampoDescripNombre];
                    
                    this.dgvFiltro.Rows[0].Selected = true;
                }
                this.dgvFiltro.Focus();
            }
        }

        private void dgvFiltro_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.btnAceptar.PerformClick();
        }

        private void dgvFiltro_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.Space:
                    this.btnAceptar.PerformClick();
                    break;
            }
        }

        private void frmPickBase_VisibleChanged(object sender, EventArgs e)
        {
            if (this.dgvFiltro.DataSource != null)
                this.FormatearGrilla();
        }
        #endregion Métodos sobre Controles

        #region Métodos de Apoyo
        private void SetToolTip()
        {
            this.toolTip.SetToolTip(this.txtID, "Filtrar por ID " + this.lblCampo.Text);
            this.toolTip.SetToolTip(this.txtDescrpcion, "Filtrar por Descripción " + this.lblCampo.Text);
        }
        #endregion Métodos de Apoyo

        #region Métodos Públicos
        
        public void HideDescriptionTextBox(bool hide = false)
        {
            if (hide)
            {
                this.txtDescrpcion.Visible = false;
                this.txtID.Size = new Size(this.txtID.Size.Width + this.txtDescrpcion.Size.Width, this.txtID.Size.Height);
            }
        }

        public void SetExplicitToolTipIDTextBox(string tt)
        {
            this.toolTip.SetToolTip(this.txtID, "Filtrar por " + tt);
        }

        public void SetExplicitToolTipDescripTextBox(string tt)
        {
            this.toolTip.SetToolTip(this.txtDescrpcion, "Filtrar por " + tt);
        }

        public void LoadData<T>(IQueryable<T> tabla, string predicate = "") where T : class
        {
            if ((predicate == "") && (!this.PermitirFiltroNulo))
            {
                MessageBox.Show("Debe establecer algún criterio de filtro", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtID.Focus();
                return;
            }

            if (predicate != "")
                this.dgvFiltro.DataSource = tabla.Where(predicate).ToList();
            else
            {
                tabla.Load();
                this.dgvFiltro.DataSource = tabla.ToList();
            }

            this.FormatearGrilla();
        }

        public void LoadData<T>(IQueryable<T> tabla) where T : class
        {
            tabla.Load();
            this.dgvFiltro.DataSource = tabla.ToList();
            this.FormatearGrilla();
        }

        public void FormatearGrilla()
        {
            //int displayIndex = 10;
            foreach (DataGridViewColumn col in dgvFiltro.Columns)
            {
                col.Visible = false;
                //col.DisplayIndex = displayIndex;
                //displayIndex++;
            }

            //dgvFiltro.Columns[this.CampoIDNombre].Visible = true;
            dgvFiltro.Columns[this.CampoIDNombre].Visible = this.ColumnIDVisible;
            dgvFiltro.Columns[this.CampoIDNombre].HeaderText = this.LabelCampoID;
            dgvFiltro.Columns[this.CampoIDNombre].Width = this.Col1Width;
            dgvFiltro.Columns[this.CampoIDNombre].DisplayIndex = 0;
            //dgvFiltro.Columns[this.CampoDescripNombre].Visible = true;
            dgvFiltro.Columns[this.CampoDescripNombre].Visible = this.ColumnDescripVisible;
            dgvFiltro.Columns[this.CampoDescripNombre].HeaderText = this.LabelCampoDescrip;
            dgvFiltro.Columns[this.CampoDescripNombre].Width = this.Col2Width;
            dgvFiltro.Columns[this.CampoDescripNombre].DisplayIndex = 1;

            dgvFiltro.ReadOnly = true;
            dgvFiltro.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFiltro.ItemsPerPage = 13;
        }

        public void MostrarFiltro(bool mantenerEstado = false)
        {
            if (!mantenerEstado)
            {
                if (this.dgvFiltro.DataSource != null)
                {
                    this.dgvFiltro.DataSource = null;
                }

                this.txtID.Text = "";
                this.txtDescrpcion.Text = "";
            }
            
            this.ShowDialog();
            
            if (!mantenerEstado)
                this.txtID.Focus();
            else
            {
                if (this.dgvFiltro.RowCount > 0)
                {
                    this.dgvFiltro.CurrentCell = this.dgvFiltro.Rows[this.dgvFiltro.SelectedRows[0].Index].Cells[this.GetFirstVisibleColumn()];
                    this.dgvFiltro.Rows[this.dgvFiltro.SelectedRows[0].Index].Selected = true;
                    this.dgvFiltro.Focus();
                }
                else this.txtID.Focus();
            }
        }

        private int GetFirstVisibleColumn()
        {
            int Result = 0;
            foreach (DataGridViewColumn col in this.dgvFiltro.Columns)
            {
                if (col.Visible)
                    break;

                Result++;
            }
            return Result;
        }

        public string GetWhereString()
        {
            const string DEFAULT_STRING_PATTERN = "( {0} = {1} )";
            const string WILDCARD_STRING_PATTERN = " {0}.Contains(\"{1}\") ";
            string whereString = "";

            if (this.txtID.Text != "")
            {
                whereString = String.Format(DEFAULT_STRING_PATTERN, this.campoid, this.txtID.Text.ToUpper());
            }

            if (this.txtDescrpcion.Text != "")
            {
                if (whereString != "")
                    whereString += " AND ";

                whereString += String.Format(WILDCARD_STRING_PATTERN, this.campodescrip, this.txtDescrpcion.Text.ToUpper());
            }

            return whereString;
        }

        //public string GetValor(string nombreCampo)
        //{
        //    if (this.dgvFiltro.Rows.Count > 0)
        //        return dgvFiltro.CurrentRow.Cells[nombreCampo].Value.ToString();
        //    else
        //        return "";
        //}

        /// <summary>
        /// Devuelve el valor [object] del campo cuyo nombre se ha indicado.
        /// </summary>
        /// <param name="nombreCampo"></param>
        /// <returns></returns>
        public object GetValor(string nombreCampo)
        {
            if (this.dgvFiltro.Rows.Count > 0)
                return dgvFiltro.CurrentRow.Cells[nombreCampo].Value;
            else
                return null;
        }

        /// <summary>
        /// Devuelve el valor [object] del campo cuyo índice se ha indicado.
        /// </summary>
        /// <param name="indexCampo"></param>
        /// <returns></returns>
        public object GetValor(int indexCampo)
        {
            if (this.dgvFiltro.Rows.Count > 0)
                return dgvFiltro.CurrentRow.Cells[indexCampo].Value;
            else
                return null;
        }

        #endregion Métodos Públicos

        private void txtDescrpcion_Leave(object sender, EventArgs e)
        {
            if (this.txtDescrpcion.Text.Trim() != String.Empty)
            {
                this.btnFiltrar.PerformClick();
            }
        }

        private void txtID_Leave(object sender, EventArgs e)
        {
            if ((this.txtID.Text.Trim() != String.Empty) && (!this.txtDescrpcion.Visible))
            {
                this.btnFiltrar.PerformClick();
            }
        }

    }
}