#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

using SPF.Types;

#endregion

namespace SPF.UserControls.Base
{
    public partial class ucMakeFilter : UserControl
    {
        #region Variables
        private string campoClave = "";
        //private int tipoFiltro = -1;
        private bool esCadena = false;
        private List<DateTime> dtList;
        //private string filterString = "";
        #endregion Variables

        #region Propiedades
        public string Nombre
        {
            get { return this.NombreCampo.Text; }
            set { this.NombreCampo.Text = value; }
        }

        public string Valor
        {
            get { return this.TxtValor.Text; }
            set { this.TxtValor.Text = value; }
        }

        public string Clave
        {
            get { return this.campoClave; }
            set { this.campoClave = value; }
        }

        public TextBox TextValor
        {
            get { return this.TxtValor; }
        }

        public List<DateTime> DateTimeParmList
        {
            get { return this.dtList; }
        }

        public bool IsCadena
        {
            get { return this.esCadena; }
            set { this.esCadena = value; }
        }

        #endregion Propiedades

        #region Eventos Delegados
        public delegate void KeyPressEventHandler(object sender, EventArgs e);
        //public event KeyPressEventHandler OnKeyPressed;
        #endregion Eventos Delegados

        public ucMakeFilter()
        {
            InitializeComponent();
        }

        public ucMakeFilter(string campoClave, string campo, bool IsString, DockStyle dock = DockStyle.Top)
        {
            InitializeComponent();
            this.Clave = campoClave;
            this.Nombre = campo;
            this.IsCadena = IsString;
            this.Dock = dock;
        }

        #region Original
        //public string GetFilterString(bool useSQLSyntax = false)
        //{
        //    const string DEFAULT_STRING_PATTERN = "( {0} = {1} )";
        //    const string WILDCARD_STRING_PATTERN = " {0}.Contains(\"{1}\") ";
        //    const string WILDCARD_STRING_PATTERN_SQL = " ({0} LIKE '%{1}%') ";
        //    const string RANGE_STRING_PATTERN = "( {0} >= {1} AND {0} <= {2} )";
            
        //    string filterString = "";

        //    dtList = new List<DateTime>();

        //    if (this.Valor != "")
        //    {
        //        //if (!this.IsCadena)
        //        //{
        //        //    if (this.Valor.ToUpper() == "S")
        //        //        this.Valor = "true";
        //        //    else if (this.Valor.ToUpper() == "N")
        //        //        this.Valor = "false";
        //        //}

        //        //Verificamos si es una lista y el primero de los valores es tipo fecha
        //        bool esFecha = this.IsDate(this.Valor.Split(',')[0]);
        //        //Verificamos si es un rango y el primero de los valores es tipo fecha
        //        if (!esFecha) esFecha = this.IsDate(this.Valor.Split('-')[0]);

        //        #region WildCard
        //        if ((this.IsCadena) && (!esFecha))
        //        {
        //            filterString = String.Format(useSQLSyntax ? WILDCARD_STRING_PATTERN_SQL : WILDCARD_STRING_PATTERN,
        //                                         this.Clave,
        //                                         this.Valor.ToUpper());
        //        }
        //        #endregion WildCard
        //        else
        //        {
        //            #region Default

        //            #region Valores boolean
                    
        //            if (this.Valor.ToUpper() == "S")
        //                filterString = String.Format(DEFAULT_STRING_PATTERN, this.Clave, this.addComillas("true"));
        //            else if (this.Valor.ToUpper() == "N")
        //                filterString = String.Format(DEFAULT_STRING_PATTERN, this.Clave, this.addComillas("false"));
        //            #endregion Valores boolean
        //            #region Otros Valores Numéricos
        //            else
        //                filterString = String.Format(DEFAULT_STRING_PATTERN, this.Clave, this.addComillas(this.Valor));
        //            #endregion Otros Valores Numéricos

        //            #endregion Default

        //            #region ValueList
        //            string[] listaValores = this.Valor.Split(',');

        //            if (listaValores.Length > 1)
        //            {
        //                string gFiltro = "";
        //                foreach (string e in listaValores)
        //                {
        //                    if (gFiltro != "")
        //                        gFiltro += " OR ";

        //                    if (esFecha)
        //                        gFiltro += String.Format(DEFAULT_STRING_PATTERN, this.Clave, this.addComillas(e));
        //                    else
        //                        gFiltro += String.Format(DEFAULT_STRING_PATTERN, this.Clave, this.addComillas(e));
        //                }
        //                filterString = " (" + gFiltro + ") "; 
                        
        //            }
        //            #endregion ValueList
                    
        //            #region Range
        //            string[] rangoValores = this.Valor.Split('-');

        //            if ((rangoValores[0] != "") && (rangoValores.Length == 2))
        //            {
        //                filterString = String.Format(RANGE_STRING_PATTERN, this.Clave, this.addComillas(rangoValores[0]), this.addComillas(rangoValores[1]));
        //            }
        //            #endregion Range
                    
        //        }
        //    }

        //    return filterString;
        //}
        #endregion Original

        public string GetFilterString(bool useSQLSyntax = false)
        {
            const string DEFAULT_STRING_PATTERN = "( {0} {1} {2})";
            const string WILDCARD_STRING_PATTERN = " {0}.Contains(\"{1}\") ";
            const string WILDCARD_STRING_PATTERN_SQL = " ({0} LIKE '%{1}%') ";
            const string RANGE_STRING_PATTERN = "( {0} >= {1} AND {0} <= {2} )";
            const string EQUAL = "=";
            const string LESS_THAN = "<";
            const string LESS_OR_EQUAL_THAN = "<=";
            const string GREATER_THAN = ">";
            const string GREATER_OR_EQUAL_THAN = ">=";

            string filterString = "";

            dtList = new List<DateTime>();

            if (this.Valor != "")
            {
                //if (!this.IsCadena)
                //{
                //    if (this.Valor.ToUpper() == "S")
                //        this.Valor = "true";
                //    else if (this.Valor.ToUpper() == "N")
                //        this.Valor = "false";
                //}

                //Verificamos si es una lista y el primero de los valores es tipo fecha
                bool esFecha = this.IsDate(this.Valor.Replace(LESS_OR_EQUAL_THAN, String.Empty).Replace(LESS_THAN, String.Empty).Replace(GREATER_OR_EQUAL_THAN, String.Empty).Replace(GREATER_THAN, String.Empty).Split(',')[0]);
                //Verificamos si es un rango y el primero de los valores es tipo fecha
                if (!esFecha) esFecha = this.IsDate(this.Valor.Split('-')[0]);

                #region WildCard
                if ((this.IsCadena) && (!esFecha))
                {
                    filterString = String.Format(useSQLSyntax ? WILDCARD_STRING_PATTERN_SQL : WILDCARD_STRING_PATTERN,
                                                 this.Clave,
                                                 this.Valor.ToUpper());
                }
                #endregion WildCard
                else
                {
                    #region Default

                    #region Valores boolean

                    if (this.Valor.ToUpper() == "S")
                    {
                        if (useSQLSyntax)
                            filterString = String.Format(DEFAULT_STRING_PATTERN, this.Clave, EQUAL, this.addComillas("1"));
                        else
                            filterString = String.Format(DEFAULT_STRING_PATTERN, this.Clave, EQUAL, this.addComillas("true"));
                    }
                    else if (this.Valor.ToUpper() == "N")
                    {
                        if (useSQLSyntax)
                            filterString = String.Format(DEFAULT_STRING_PATTERN, this.Clave, EQUAL, this.addComillas("0"));
                        else
                            filterString = String.Format(DEFAULT_STRING_PATTERN, this.Clave, EQUAL, this.addComillas("false"));
                    }
                    #endregion Valores boolean
                    #region Otros Valores Numéricos
                    else
                    {
                        if (this.Valor.IndexOf(LESS_OR_EQUAL_THAN) > -1)
                            filterString = String.Format(DEFAULT_STRING_PATTERN, this.Clave, LESS_OR_EQUAL_THAN, this.addComillas(this.Valor.Replace(LESS_OR_EQUAL_THAN, String.Empty)));
                        else if (this.Valor.IndexOf(LESS_THAN) > -1)
                            filterString = String.Format(DEFAULT_STRING_PATTERN, this.Clave, LESS_THAN, this.addComillas(this.Valor.Replace(LESS_THAN, String.Empty)));
                        else if (this.Valor.IndexOf(GREATER_OR_EQUAL_THAN) > -1)
                            filterString = String.Format(DEFAULT_STRING_PATTERN, this.Clave, GREATER_OR_EQUAL_THAN, this.addComillas(this.Valor.Replace(GREATER_OR_EQUAL_THAN, String.Empty)));
                        else if (this.Valor.IndexOf(GREATER_THAN) > -1)
                            filterString = String.Format(DEFAULT_STRING_PATTERN, this.Clave, GREATER_THAN, this.addComillas(this.Valor.Replace(GREATER_THAN, String.Empty)));
                        else
                            filterString = String.Format(DEFAULT_STRING_PATTERN, this.Clave, EQUAL, this.addComillas(this.Valor));
                    }
                    #endregion Otros Valores Numéricos

                    #endregion Default

                    #region ValueList
                    string[] listaValores = this.Valor.Split(',');

                    if (listaValores.Length > 1)
                    {
                        string gFiltro = "";
                        foreach (string e in listaValores)
                        {
                            if (gFiltro != "")
                                gFiltro += " OR ";

                            if (esFecha)
                                gFiltro += String.Format(DEFAULT_STRING_PATTERN, this.Clave, EQUAL, this.addComillas(e));
                            else
                                gFiltro += String.Format(DEFAULT_STRING_PATTERN, this.Clave, EQUAL, this.addComillas(e));
                        }
                        filterString = " (" + gFiltro + ") ";

                    }
                    #endregion ValueList

                    #region Range
                    string[] rangoValores = this.Valor.Split('-');

                    if ((rangoValores[0] != "") && (rangoValores.Length == 2))
                    {
                        filterString = String.Format(RANGE_STRING_PATTERN, this.Clave, this.addComillas(rangoValores[0]), this.addComillas(rangoValores[1]));
                    }
                    #endregion Range

                }
            }

            return filterString;
        }

        private bool IsDate(string valor)
        {
            string[] format = new string[] { "dd-MM-yyyy", "dd/MM/yyyy", "dd-MM-yyyy HH:mm:ss", "dd-MM-yyyy hh:mm:ss", "dd/MM/yyyy HH:mm:ss", "dd/MM/yyyy hh:mm:ss" };
            DateTime datetime;
            return DateTime.TryParseExact(valor, format, System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.NoCurrentDateDefault, out datetime);
        }

        private string addComillas(string valor)
        {
            if (this.IsCadena)
                return "\"" + valor + "\"";
            else
                return valor;
        }

       
    }
}