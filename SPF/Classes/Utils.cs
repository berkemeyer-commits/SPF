using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;

namespace SPF.Classes
{
    public class Utils
    {
        #region Constantes
        private const int DOLARES_MONEDA_ID = 2;
        private const int IDIOMA_ESPANOL = 2;
        #endregion Constantes
        /// <summary>
        /// Determines a text file's encoding by analyzing its byte order mark (BOM).
        /// Defaults to ASCII when detection of the text file's endianness fails.
        /// </summary>
        /// <param name="filename">The text file to analyze.</param>
        /// <returns>The detected encoding.</returns>
        public static Encoding GetEncoding(string filename)
        {
            // Read the BOM
            var bom = new byte[4];
            using (var file = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                file.Read(bom, 0, 4);
            }

            // Analyze the BOM
            if (bom[0] == 0x2b && bom[1] == 0x2f && bom[2] == 0x76) return Encoding.UTF7;
            if (bom[0] == 0xef && bom[1] == 0xbb && bom[2] == 0xbf) return Encoding.UTF8;
            if (bom[0] == 0xff && bom[1] == 0xfe) return Encoding.Unicode; //UTF-16LE
            if (bom[0] == 0xfe && bom[1] == 0xff) return Encoding.BigEndianUnicode; //UTF-16BE
            if (bom[0] == 0 && bom[1] == 0 && bom[2] == 0xfe && bom[3] == 0xff) return Encoding.UTF32;
            return Encoding.ASCII;
        }

        public static string ExtractString(string s, string startTag, string endTag)
        {
            string sU = s.ToUpper();

            int startIndex = sU.IndexOf(startTag.ToUpper()) == -1 ? sU.IndexOf(startTag.ToUpper()) : sU.IndexOf(startTag.ToUpper()) + startTag.Length;

            if (startIndex == -1)
                return String.Empty;

            int endIndex = sU.IndexOf(endTag.ToUpper(), startIndex);

            return endIndex == -1 ? String.Empty : s.Substring(startIndex, endIndex - startIndex);
        }

        public static string TruncarTexto(string texto, int longitud = 52, int longitudMax = 55)
        {
            if (texto.Length <= longitud)
                return texto;

            string primeraParte = texto.Substring(0, longitud);
            int i = 0;
            for (i = longitud - 1; i >= 0; i--)
            {
                if (Char.IsWhiteSpace(primeraParte[i]))
                    break;
            }

            int longitudSegundaLinea = texto.Length - i - 1 > longitudMax ? longitudMax : texto.Length - i - 1;

            return texto.Substring(0, i) + "<br><br>" + texto.Substring(i + 1, longitudSegundaLinea);
        }

        public static string ObtenerTotalEnLetras(int idiomaID, int monedaID, string montoTotal, string monedaDescrip, bool mostrarDescripMoneda = true)
        {
            decimal total = Convert.ToDecimal(montoTotal);
            string totalEnLetras = "";

            if (idiomaID == IDIOMA_ESPANOL)
            {
                Numalet let = new Numalet();
                let.ConvertirDecimales = false;
                let.Decimales = 0;

                int number = (int)Math.Truncate(total);
                decimal decimalPart = total - number;
                if (decimalPart > 0)
                {
                    let.ConvertirDecimales = true;
                    let.Decimales = 2;
                }

                if (mostrarDescripMoneda)
                {
                    if (monedaID == DOLARES_MONEDA_ID)
                        totalEnLetras = let.ToCustomCardinal(total) + " " + monedaDescrip;
                    else
                        totalEnLetras = monedaDescrip + " " + let.ToCustomCardinal(total);
                }
                else totalEnLetras = let.ToCustomCardinal(total);

                let = null;
            }
            else
            {
                if (mostrarDescripMoneda)
                {
                    if (monedaID == DOLARES_MONEDA_ID)
                        totalEnLetras = NumberToText(total) + " " + monedaDescrip;
                    else
                        totalEnLetras = monedaDescrip + " " + NumberToText(total);
                }
                else totalEnLetras = NumberToText(total);
            }

            return totalEnLetras.ToUpper();
        }

        public static string NumberToText(decimal inputDecimal, bool isUK = true)
        {
            int number = (int)Math.Truncate(inputDecimal);
            decimal decimalPart = inputDecimal - number;

            string decimalPartString = "";
            if (decimalPart > 0)
                decimalPartString += " WITH " + NumberToText(decimalPart * 100);

            if (number == 0) return "Zero";
            string and = isUK ? "and " : ""; // deals with UK or US numbering
            if (number == -2147483648) return "Minus Two Billion One Hundred " + and +
            "Forty Seven Million Four Hundred " + and + "Eighty Three Thousand " +
            "Six Hundred " + and + "Forty Eight";
            int[] num = new int[4];
            int first = 0;
            int u, h, t;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            if (number < 0)
            {
                sb.Append("Minus ");
                number = -number;
            }

            //string[] words0 = new string[10];


            string[] words0 = { "", "One ", "Two ", "Three ", "Four ", "Five ", "Six ", "Seven ", "Eight ", "Nine " };
            string[] words1 = { "Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ", "Fifteen ", "Sixteen ", "Seventeen ", "Eighteen ", "Nineteen " };
            string[] words2 = { "Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ", "Seventy ", "Eighty ", "Ninety " };
            string[] words3 = { "Thousand ", "Million ", "Billion " };

            num[0] = number % 1000;           // units
            num[1] = number / 1000;
            num[2] = number / 1000000;
            num[1] = num[1] - 1000 * num[2];  // thousands
            num[3] = number / 1000000000;     // billions
            num[2] = num[2] - 1000 * num[3];  // millions
            for (int i = 3; i > 0; i--)
            {
                if (num[i] != 0)
                {
                    first = i;
                    break;
                }
            }
            for (int i = first; i >= 0; i--)
            {
                if (num[i] == 0) continue;
                u = num[i] % 10;              // ones
                t = num[i] / 10;
                h = num[i] / 100;             // hundreds
                t = t - 10 * h;               // tens
                if (h > 0) sb.Append(words0[h] + "Hundred ");
                if (u > 0 || t > 0)
                {
                    if (h > 0 || i < first) sb.Append(and);
                    if (t == 0)
                        sb.Append(words0[u]);
                    else if (t == 1)
                        sb.Append(words1[u]);
                    else
                        sb.Append(words2[t - 2] + words0[u]);
                }
                if (i != 0) sb.Append(words3[i - 1]);
            }
            return sb.ToString().TrimEnd() + decimalPartString;
        }
    }    
}