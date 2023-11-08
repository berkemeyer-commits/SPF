#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

using SPF.UserControls.Base;
using SPF.Types;

#endregion

namespace SPF.Forms
{
    public partial class frmBuscadorBase : Form
    {
        #region Campos
        private const string CAMPO_CLAVECAMPO   = "colClaveCampo";
        private const string CAMPO_CAMPO        = "colCampo";
        private const string CAMPO_VALOR        = "colValor";
        #endregion Campos

        #region Propiedades
        public string SQLWhereString
        {
            get { return this.sqlWhereString; }
        }
        #endregion Propiedades

        #region Constantes
        private const string AND = " AND ";
        #endregion Constantes

        #region Variables
        private int contador = 0;
        private string sqlWhereString = "";
        private int cantidadFiltros = 0;
        private bool useSQLSyntax = false;
        #endregion Variables

        #region Eventos personalizados
        public event EventHandler AceptarClick;
        #endregion Eventos personalizados

        public frmBuscadorBase(Stack<object []> campos = null, bool useSQLSyntax = false)
        {
            InitializeComponent();
            this.useSQLSyntax = useSQLSyntax;
            if (campos != null)
            {
                this.CrearCamposFiltro(campos);
                //this.setFocus();
            }
        }

        public void MostrarFiltro(bool exists = false)
        {
            if (exists)
            {
                this.ShowDialog();
            }
            else
            {
                this.ShowDialog();
                this.setFocus();
            }
        }

        private void FormatearGrilla()
        {
            
        }
        
        private void frmBuscadorBase_Load(object sender, EventArgs e)
        {
            this.FormatearGrilla();
            //this.setFocus();
            
        }

        private void CrearCamposFiltro(Stack<object []> campos)
        {
            //contador = 0;
            foreach (object [] campo in campos)
            {
                ucMakeFilter mf = new ucMakeFilter((string)campo[0], (string)campo[1], (bool)campo[2]);
                mf.KeyPress += mf_KeyPress;
                this.pnlFiltros.Controls.Add(mf);
                contador++;
            }
            cantidadFiltros = campos.Count;
        }

        void mf_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.Enter:

                    Control c = this.pnlFiltros.GetNextControl(((ucMakeFilter)sender), true);

                    if (c != null)
                    {
                        ((ucMakeFilter)c).TextValor.Focus();
                    }
                    else
                    {
                        ((ucMakeFilter)this.pnlFiltros.Controls[cantidadFiltros - 1]).TextValor.Focus();
                    }
                    break;
            }
        }

        private void buscar()
        {
            this.sqlWhereString = "";
            foreach (Control c in pnlFiltros.Controls)
            {
                //c.Focus();
                if (c.GetType() == typeof(ucMakeFilter) && (((ucMakeFilter)c).Valor != ""))
                {
                    if (sqlWhereString != "") sqlWhereString += AND;

                    sqlWhereString += ((ucMakeFilter)c).GetFilterString(this.useSQLSyntax) + " ";
                }
            }
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.AceptarClick != null)
            {
                this.buscar();
                this.AceptarClick(this, e);
            }
            //this.buscar();
        }

        public void setFocus()
        {
            object o = null;
            contador--;
            foreach (Control c in pnlFiltros.Controls)
            {
                if (c.GetType() == typeof(ucMakeFilter))
                {
                    o = c;
                    c.TabIndex = contador;
                    contador--;
                }
            }
            ((ucMakeFilter)o).TextValor.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            contador = 0;
            foreach (Control c in pnlFiltros.Controls)
            {
                if (c.GetType() == typeof(ucMakeFilter))
                {
                    ((ucMakeFilter)c).Valor = "";
                    contador++;
                }
            }
            this.setFocus();
        }

        private void frmBuscadorBase_Activated(object sender, EventArgs e)
        {
            contador = 0;
            foreach (Control c in pnlFiltros.Controls)
            {
                if (c.GetType() == typeof(ucMakeFilter))
                {
                    contador++;
                }
            }
            this.setFocus();
        }
    }
}