using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Text.RegularExpressions;
using System.Globalization;

namespace SPF.Classes
{
    public class GenerarCadenasFiltro
    {
        #region Variables
        private List<object> filterParam;
        public List<object> FilterParam
        {
            get { return this.filterParam; }
        }
        #endregion Variables

        #region Constantes
        private const string DEFAULT_STRING_PATTERN = "( {0} = {1} )";
        private const string WILDCARD_STRING_PATTERN = " {0}.Contains(\"{1}\") ";
        private const string WILDCARD_STRING_PATTERN_SQL = " ({0} LIKE '%{1}%') ";
        private const string RANGE_STRING_PATTERN = "( {0} >= {1} AND {0} <= {2} )";
        private const string S = "S";
        private const string N = "N";
        private const string TRUE = "true";
        private const string FALSE = "false";
        #endregion Constantes

        public GenerarCadenasFiltro()
        {
            filterParam = new List<object>();
        }

        public string GetFilterString(string valor, string clave, bool escadena = false, bool useSQLSyntax = false)
        {
            string filterString = "";

            if (valor != "")
            {
                //Verificamos si es una lista y el primero de los valores es tipo fecha
                bool esFecha = this.IsDate(valor.Split(',')[0]);
                //Verificamos si es un rango y el primero de los valores es tipo fecha
                if (!esFecha) esFecha = this.IsDate(valor.Split('-')[0]);

                #region WildCard
                if ((escadena) && (!esFecha))
                {
                    filterString = String.Format(useSQLSyntax ? WILDCARD_STRING_PATTERN_SQL : WILDCARD_STRING_PATTERN,
                                                 clave,
                                                 valor.ToUpper());
                }
                #endregion WildCard
                else
                {
                    #region Default

                    #region Valores boolean

                    if (valor.ToUpper() == S)
                        filterString = String.Format(DEFAULT_STRING_PATTERN, clave, this.addComillas(TRUE, escadena));
                    else if (valor.ToUpper() == N)
                        filterString = String.Format(DEFAULT_STRING_PATTERN, clave, this.addComillas(FALSE, escadena));
                    #endregion Valores boolean
                    #region Otros Valores Numéricos
                    else
                        filterString = String.Format(DEFAULT_STRING_PATTERN, clave, this.addComillas(valor, escadena));
                    #endregion Otros Valores Numéricos

                    #endregion Default

                    #region ValueList
                    string[] listaValores = valor.Split(',');

                    if (listaValores.Length > 1)
                    {
                        string gFiltro = "";
                        foreach (string e in listaValores)
                        {
                            if (gFiltro != "")
                                gFiltro += " OR ";

                            if (esFecha)
                                gFiltro += String.Format(DEFAULT_STRING_PATTERN, clave, this.addComillas(e, escadena));
                            else
                                gFiltro += String.Format(DEFAULT_STRING_PATTERN, clave, this.addComillas(e, escadena));
                        }
                        filterString = " (" + gFiltro + ") ";

                    }
                    #endregion ValueList

                    #region Range
                    string[] rangoValores = valor.Split('-');

                    if ((rangoValores[0] != "") && (rangoValores.Length == 2))
                    {
                        filterString = String.Format(RANGE_STRING_PATTERN, clave, this.addComillas(rangoValores[0], escadena), this.addComillas(rangoValores[1], escadena));
                    }
                    #endregion Range

                }
            }

            return filterString;//
        }

        private bool IsDate(string valor)
        {
            string[] format = new string[] { "dd-MM-yyyy", "dd/MM/yyyy", "dd-MM-yyyy HH:mm:ss", "dd-MM-yyyy hh:mm:ss", "dd/MM/yyyy HH:mm:ss", "dd/MM/yyyy hh:mm:ss" };
            DateTime datetime;
            return DateTime.TryParseExact(valor, format, System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.NoCurrentDateDefault, out datetime);
        }

        private string addComillas(string valor, bool esCadena = false)
        {
            if (esCadena)
               return "\"" + valor + "\"";
            else
                return valor;
        }

        public string GetParseString(string where)
        {
            var regex = new Regex(@"\b\d{2}\/\d{2}/\d{4}\b");
            //filterParam = new List<object>();
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

    }
}