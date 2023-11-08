using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPF.Base
{
    public class Libs
    {
        public static string GetFilterString(string valor, string clave, bool escadena)
        {
            const string DEFAULT_STRING_PATTERN = "( {0} = {1} )";
            const string WILDCARD_STRING_PATTERN = " {0}.Contains(\"{1}\") ";
            const string RANGE_STRING_PATTERN = "( {0} >= {1} AND {0} <= {2} )";

            string filterString = "";

            //dtList = new List<DateTime>();

            if (valor != "")
            {
                //Verificamos si es una lista y el primero de los valores es tipo fecha
                //bool esFecha = this.IsDate(this.Valor.Split(',')[0]);
                //Verificamos si es un rango y el primero de los valores es tipo fecha
                //if (!esFecha) esFecha = this.IsDate(this.Valor.Split('-')[0]);

                #region WildCard
                if (escadena)
                {
                    filterString = String.Format(WILDCARD_STRING_PATTERN, clave, valor.ToUpper());
                }
                #endregion WildCard
                else
                {
                    #region Default
                    filterString = String.Format(DEFAULT_STRING_PATTERN, clave, addComillas(valor, escadena));
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

                            //if (esFecha)
                            //  gFiltro += String.Format(DEFAULT_STRING_PATTERN, this.Clave, this.addComillas(e));
                            //else
                            gFiltro += String.Format(DEFAULT_STRING_PATTERN, clave, addComillas(e, escadena));
                        }
                        filterString = " (" + gFiltro + ") ";

                    }
                    #endregion ValueList

                    #region Range
                    string[] rangoValores = valor.Split('-');

                    if ((rangoValores[0] != "") && (rangoValores.Length == 2))
                    {
                        filterString = String.Format(RANGE_STRING_PATTERN, clave, addComillas(rangoValores[0], escadena), addComillas(rangoValores[1]), escadena);
                    }
                    #endregion Range

                }
            }

            return filterString;
        }

        private static string addComillas(string valor, bool esCadena = false)
        {
            if (esCadena)
                return "\"" + valor + "\"";
            else
                return valor;
        }
    }
}