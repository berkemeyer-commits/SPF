using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

using ModelEF6;
using SPF.Types;
using SPF.Forms.Base;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Linq.Dynamic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
using System.Collections.ObjectModel;

namespace SPF.Classes
{
    public static class GenerarNotaCredito
    {
        #region Constantes
        private const int TIPODOCUMENTO_NOTACREDITO = 5;
        private const int IDIOMA_INGLES = 1;
        private const int IDIOMA_ESPANOL = 2;
        private const string DOLLARS = "DOLLARS";
        private const string DOLARES = "DOLARES";
        #endregion Constantes

        public static object [] CrearNotaCredito(BerkeDBEntities context, Hashtable hashPagosCabID, decimal monto, int monedaID, int clienteID, DateTime fechaNotaCredito, string [] Presupuestos, string Referencia, string Cuerpo)
        {
            //Hashtable Result = new Hashtable();
            

            //using (var context = new BerkeDBEntities())
            //{
                //using (var dbContextTransaction = context.Database.BeginTransaction())
                //{

            int nroComprobante = -1;
            int numeracionID = -1;
            int notaCreditoCabID = -1;
            ncp_notacreditopresup ncp = new ncp_notacreditopresup();

                    //try
                    //{
                        GetComprobanteNro_Result datosComprobante = context.GetComprobanteNro(TIPODOCUMENTO_NOTACREDITO, null, null, null).First();
                        nroComprobante = datosComprobante.ComprobanteNro;
                        numeracionID = datosComprobante.NumeracionID;


                        if (nroComprobante > -1)
                        {
                            nroComprobante++;
                            //Cargar Cabecera Nota Crédito
                            ncp = CargarCabNotaCredito(context, monto, monedaID, clienteID, fechaNotaCredito, nroComprobante, Referencia, Cuerpo, ObtenerListaNroDocumento(context, Presupuestos));
                            notaCreditoCabID = ncp.ncp_notacreditoid;
                            //Result.Add(notaCreditoCabID, nroComprobante);
                            //Cargar Detalle Nota Crédito
                            CargarDetNotaCredito(context, hashPagosCabID, notaCreditoCabID);
                            context.cnd_controlnumdoc.First(a => a.cnd_controlnumdocid == numeracionID).cnd_ultnro = nroComprobante;
                            context.SaveChanges();
                            //Result = nroComprobante;
                        }
                        else
                        {
                            throw new Exception("No se encuentra definido un esquema de autonumeración.");

                        }
                    //}
                    //catch (Exception ex)
                    //{
                    //    throw new Exception("Ocurrió un error al generar la nota crédito. "
                    //                        + ex.Message + Environment.NewLine
                    //                        + ex.InnerException);
                    //}
                //}
            //}
            
            //return Result;
            NotaCreditoPresupType ncCuerpo = CrearDataSet(context, ncp);
            return new object[] { nroComprobante, notaCreditoCabID, ncCuerpo};
        }

        private static ncp_notacreditopresup CargarCabNotaCredito(BerkeDBEntities context, decimal monto, int monedaID, int clienteID, DateTime fechaNotaCredito, int NroComprobante, string Referencia, string Cuerpo, string Presupuestos)
        {
            ncp_notacreditopresup ncp = new ncp_notacreditopresup();
            ncp.ncp_fecha = fechaNotaCredito;
            ncp.ncp_nrocomprobante = NroComprobante;
            ncp.ncp_monto = monto;
            ncp.ncp_monedaid = monedaID;
            ncp.ncp_clienteid = clienteID;
            ncp.ncp_referenciacliente = Referencia;
            ncp.ncp_cuerponota = Cuerpo;
            ncp.ncp_presupuestos = Presupuestos;
            context.ncp_notacreditopresup.Add(ncp);
            context.SaveChanges();

            return ncp;
        }

        //La tabla hashPagosCabID tiene como key el PagoID y como value el monto del pago
        private static void CargarDetNotaCredito(BerkeDBEntities context, Hashtable hashPagosCabID, int NotaCreditoCabID)
        {
            foreach (DictionaryEntry entry in hashPagosCabID)
            {
                ncd_notacreditopresupdetalle ncd = new ncd_notacreditopresupdetalle();
                ncd.ncd_notacreditocabid = NotaCreditoCabID;
                ncd.ncd_pagoid = (int)entry.Key;
                ncd.ncd_monto = (decimal)entry.Value;
                context.ncd_notacreditopresupdetalle.Add(ncd);
                context.SaveChanges();
            }
        }

        public static NotaCreditoPresupType CrearDataSet(BerkeDBEntities context, ncp_notacreditopresup ncp)
        {
            int ClienteID = ncp.ncp_clienteid;
            Cliente cli = context.Cliente.First(a => a.ID == ClienteID);

            int MonedaID = ncp.ncp_monedaid;
            Moneda mon = context.Moneda.First(a => a.ID == MonedaID);

            NotaCreditoPresupType nc = new NotaCreditoPresupType();
            nc.FechaNotaCredito = ncp.ncp_fecha;
            nc.FechaNotaCreditoLetras = traducirFecha(context, ncp.ncp_fecha.ToShortDateString(), cli.IdiomaID.Value);
            nc.NombreCliente = cli.Nombre;
            nc.Correo = cli.Correo;
            nc.NroNotaCredito = ncp.ncp_nrocomprobante.ToString();
            nc.RefCliente = ncp.ncp_referenciacliente;
            nc.Cuerpo = ncp.ncp_cuerponota;
            nc.Presupuestos = ncp.ncp_presupuestos;
            nc.Monto = ncp.ncp_monto;
            nc.Moneda = mon.AbrevMoneda;
            nc.MontoLetras = ObtenerMontoEnLetras(cli.IdiomaID.Value, ncp.ncp_monto, mon);
            nc.ClienteID = ClienteID;
            nc.IdiomaID = cli.IdiomaID.Value;
            return nc;
        }

        private static string ObtenerListaNroDocumento(BerkeDBEntities context, string [] Presupuestos)
        {
            string Result = "";

            foreach (string str in Presupuestos)
            {
                if (Result != "")
                    Result += ", ";

                int PresupuestoCabID = Convert.ToInt32(str);
                Result += context.GetDocumentoNro(PresupuestoCabID).FirstOrDefault();
            }


            return Result;
        }

        public static string ObtenerMontoEnLetras(int IdiomaID, decimal total, Moneda moneda)
        {
            string Result = "";
            if (IdiomaID == IDIOMA_ESPANOL)
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

                if (moneda.Descripcion == DOLARES)
                    Result = let.ToCustomCardinal(total) + " " + moneda.Descripcion;
                else
                    Result = moneda.Descripcion + " " + let.ToCustomCardinal(total);

                let = null;
            }
            else
            {
                //totalEnLetras = this.NumberToText(total) + " " + monedaDescrip;

                if (moneda.Descripcion == DOLLARS)
                    Result = NumberToText(total) + " " + moneda.DescripIngles;
                else
                    Result = moneda.DescripIngles + " " + NumberToText(total);
            }
            return Result.ToUpper();
        }


        #region Traducir fecha
        public static string traducirFecha(BerkeDBEntities context, string fecha, int idiomaID)
        {

            string f = "";
            int dd = 0; int mm = 0; int aa = 0;

            DateTime fec = DateTime.Parse(fecha.ToString());

            dd = fec.Day; mm = fec.Month; aa = fec.Year;

            List<Mes> mes = context.Mes.Where(a => a.ididioma == idiomaID && a.Orden == mm).ToList();

            if (idiomaID == IDIOMA_INGLES) /*ingles*/
            {
                f = mes.First().Mes1 + " " + dd.ToString() + ", " + aa.ToString();
            }

            if (idiomaID == IDIOMA_ESPANOL) /*español*/
            {
                f = dd.ToString() + " de " + mes.First().Mes1 + " de " + aa.ToString();
            }

            if (idiomaID == 3) /*aleman*/
            {
                f = dd.ToString() + ". " + mes.First().Mes1 + " " + aa.ToString();
            }

            if (idiomaID == 4) /*frances*/
            {
                f = dd.ToString() + " " + mes.First().Mes1 + " " + aa.ToString();
            }


            return f;
        }

        #endregion

        #region Convertir Números a Texto
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
        #endregion Convertir Números a Texto
    }

    

    
}