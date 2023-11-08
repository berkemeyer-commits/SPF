using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ModelEF6;

namespace SPF.Types
{
    public class OpoListTypeAll
    {
        public Nullable<int> ExpedienteID { get; set; }
        public Nullable<int> RegistroNro { get; set; }
        public Nullable<int> ActaAnio { get; set; }
        public Nullable<int> ActaNro { get; set; }
        public Nullable<bool> Confirmado { get; set; }
        public Nullable<bool> TieneAutorizacionVigente { get; set; }
        public string Acta 
        { 
            get 
            {
                if ((this.ActaNro.HasValue && this.ActaAnio.HasValue) && (acta == ""))
                    acta = this.ActaNro.ToString() + "/" + this.ActaAnio.ToString();
                
                return acta;
            }
            set
            {
                acta = value;
            }
        }
        public string HI
        {
            get
            {
                if ((this.HINro.HasValue && this.HIAnio.HasValue) && (hi == ""))
                    hi = this.HINro.ToString() + "/" + this.HIAnio.ToString();

                return hi;
            }
            set
            {
                hi = value;
            }
        }

        public int TramiteID { get; set; }
        public string TramiteDescrip { get; set; }
        public string DenominacionMarca { get; set; }
        public Nullable<int> ClienteID { get; set; }
        public string ClienteNombre { get; set; }
        public Nullable<bool> EsEspecial { get; set; }
        public Nullable<int> HINro { get; set; }
        public Nullable<int> HIAnio { get; set; }
        public Nullable<int> CotizacionCabID { get; set; }
        public Nullable<DateTime> FechaCotiCab { get; set; }
        public Nullable<int> AutorizadoPor { get; set; }
        public string AutorizadoPorNombre { get; set; }
        public Nullable<int> EnviadoPor { get; set; }
        public string EnviadoPorNombre { get; set; }
        public Nullable<int> OrdenTrabajoID { get; set; }
        public Nullable<int> ClientePaisID { get; set; }
        public string ClientePaisDescrip { get; set; }
        public Nullable<DateTime> FechaDocumento { get; set; }
        public string NroDocumento { get; set; }
        public string EstadoDocumento { get; set; }
        public string EstadoDocumentoTexto
        {
            get
            {
                switch (this.EstadoDocumento)
                {
                    case "N":
                        return "N = Anulado";
                    case "A":
                        return "A = Pendiente";
                    case "P":
                        return "P = Pagado";
                    default:
                        return "";
                }
            }

        }
        public string Observacion { get; set; }
        public Nullable<decimal> MontoRecargoAT { get; set; }
        public Nullable<int> TarifaID { get; set; }
        public string TarifaDescripcion { get; set; }
        public Nullable<DateTime> TarifaFecha { get; set; }
        public Nullable<int> Tarifa_ClienteID { get; set; }
        public string TarifaClienteNombre { get; set; }
        public Nullable<decimal> TarifaPrecioUnitario { get; set; }
        public Nullable<bool> TarifaTipoUnidadDescuento { get; set; }
        public Nullable<decimal> TarifaMontoDescuento { get; set; }
        public Nullable<decimal> TarifaPorcentajeDescuento { get; set; }
        public Nullable<bool> TarifaTipoUnidadImpuesto { get; set; }
        public Nullable<decimal> TarifaMontoImpuesto { get; set; }
        public Nullable<decimal> TarifaPorcentajeImpuesto { get; set; }
        public Nullable<int> TarifaExpedienteID { get; set; }
        public Nullable<decimal> TarifaCantidad { get; set; }
        public Nullable<decimal> TarifaTotal { get; set; }
        public Nullable<int> TarifaMonedaID { get; set; }
        public string TarifaMonedaDescrip { get; set; }
        public Nullable<decimal> TarifaPrecioVenta { get; set; }
        public Nullable<int> Tarifa_TarifaClienteID { get; set; }
        public Nullable<bool> TarifaEsEspecial { get; set; }
        public Nullable<decimal> TarifaTotalConRecargo { get; set; }
        public Nullable<decimal> TarifaRecargoNeto { get; set; }
        public Nullable<Boolean> EsDuplicado { get; set; }
        public Nullable<DateTime> FechaEntrada { get; set; }
        public Nullable<DateTime> FechaSalida { get; set; }
        public Nullable<bool> EsSustInterv { get; set; }

        private string acta = "";
        private string hi = "";
    }

    public class OpoListTypeCab
    {
        public Nullable<int> ExpedienteID { get; set; }
        public Nullable<int> RegistroNro { get; set; }
        public Nullable<int> ActaAnio { get; set; }
        public Nullable<int> ActaNro { get; set; }
        public Nullable<bool> Confirmado { get; set; }
        public Nullable<bool> TieneAutorizacionVigente { get; set; }
        public string Acta
        {
            get
            {
                if ((this.ActaNro.HasValue && this.ActaAnio.HasValue) && (acta == ""))
                    acta = this.ActaNro.ToString() + "/" + this.ActaAnio.ToString();

                return acta;
            }
            set
            {
                acta = value;
            }
        }
        public string HI
        {
            get
            {
                if ((this.HINro.HasValue && this.HIAnio.HasValue) && (hi == ""))
                    hi = this.HINro.ToString() + "/" + this.HIAnio.ToString();

                return hi;
            }
            set
            {
                hi = value;
            }
        }

        public int TramiteID { get; set; }
        public string TramiteDescrip { get; set; }
        public string DenominacionMarca { get; set; }
        public Nullable<int> ClienteID { get; set; }
        public string ClienteNombre { get; set; }
        public Nullable<bool> EsEspecial { get; set; }
        public Nullable<int> HINro { get; set; }
        public Nullable<int> HIAnio { get; set; }
        public Nullable<int> CotizacionCabID { get; set; }
        public Nullable<DateTime> FechaCotiCab { get; set; }
        public Nullable<int> AutorizadoPor { get; set; }
        public string AutorizadoPorNombre { get; set; }
        public Nullable<int> EnviadoPor { get; set; }
        public string EnviadoPorNombre { get; set; }
        public Nullable<int> OrdenTrabajoID { get; set; }
        public Nullable<int> ClientePaisID { get; set; }
        public string ClientePaisDescrip { get; set; }
        public Nullable<DateTime> FechaDocumento { get; set; }
        public string NroDocumento { get; set; }
        public string EstadoDocumento { get; set; }
        public string EstadoDocumentoTexto
        {
            get
            {
                switch (this.EstadoDocumento)
                {
                    case "N":
                        return "N = Anulado";
                    case "A":
                        return "A = Pendiente";
                    case "P":
                        return "P = Pagado";
                    default:
                        return "";
                }
            }

        }
        public string Observacion { get; set; }
        public Nullable<decimal> MontoRecargoAT { get; set; }
        public Nullable<Boolean> EsDuplicado { get; set; }
        public Nullable<DateTime> FechaEntrada { get; set; }
        public Nullable<DateTime> FechaSalida { get; set; }
        public Nullable<bool> EsSustInterv { get; set; }

        private string acta = "";
        private string hi = "";
    }
}