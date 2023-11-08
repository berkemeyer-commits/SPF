using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPF.Types
{
    public class AtencionType
    {
        public int AtencionID { get; set; }
        public string AtencionNombre { get; set; }
        public Nullable<int> ClienteID { get; set; }
    }

    public class CuentaType
    {
        public int CuentaID { get; set; }
        public string CuentaDescripcion { get; set; }
        public string CuentaNumero { get; set; }
        public Nullable<int> BancoID { get; set; }
        public string BancoNombre { get; set; }
        public int MonedaID { get; set; }
        public string MonedaAbrev { get; set; }
        public Nullable<bool> EsCuentaPago { get; set; }
    }

    public class BancoType
    {
        public int BancoID { get; set; }
        public string BancoNombre { get; set; }
        public Nullable<bool> EsCuentaPago { get; set; }
    }

    public class NotaCreditoSelectType
    {
        public int NotaCreditoID { get; set; }
        public string NotaCreditoDescripcion { get; set; }
        public Nullable<bool> Anulado { get; set; }
        public decimal Saldo { get; set; }
        public int ClienteID { get; set; }
        public int MonedaID { get; set; }
    }

    public class PresupuestoFilterType
    {
        public int PresupuestoCabID { get; set; }
        public string TramiteDescripcion { get; set; }
        public string NroPresupuesto { get; set; }
        //public int MonedaID { get; set; }
        //public string MonedaDescrip{ get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        //public string Descripcion 
        //{
        //    get
        //    {
        //        return this.NroPresupuesto + " - " + this.TramiteDescripcion;
        //    }
        //}
    }

    public class PagoProveedorFilterTypeSolicitud
    {
        public string Id { get; set; }
        public string Informacion { get; set; }
        public Nullable<decimal> Saldo { get; set; }
        public Nullable<decimal> Importe { get; set; }
        public string Extra { get; set; }
        public Nullable<bool> Seleccionar { get; set; }
    }

    public class FacturaNotaCreditoFilterType
    {
        private const string INFORMACION_FORMAT = "Fact. N° {0} - {1} (Timb. N° {2}) - {3} {4} - {5}";
        private const string FORMATO_FECHA = "dd/MM/yyyy";
        private const string FORMATO_MONEDA_GUARANIES = "{0:N0}";
        private const string FORMATO_MONEDA_OTROS = "{0:N2}";
        private const string MONEDA_GUARANIES = "G";
        public int FacturaCabID { get; set; }
        public string NroFactura { get; set; }
        public string NroTimbrado { get; set; }
        public string AbrevMoneda { get; set; }
        public string ClienteNombre { get; set; }
        public DateTime FechaFactura { get; set; }
        public decimal MontoFactura { get; set; }
        public Nullable<bool> EsDE { get; set; }
        public string Informacion
        {
            get
            {
                string format = AbrevMoneda == MONEDA_GUARANIES ? FORMATO_MONEDA_GUARANIES : FORMATO_MONEDA_OTROS;

                return String.Format(INFORMACION_FORMAT,
                                        NroFactura,
                                        FechaFactura.ToString(FORMATO_FECHA),
                                        NroTimbrado.ToString(),
                                        AbrevMoneda,
                                        String.Format(format, MontoFactura),
                                        ClienteNombre);
            }
        }
        private string informacion = String.Empty;
    }
}