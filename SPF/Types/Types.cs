using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gizmox.WebGUI.Forms;
using System.Globalization;

namespace SPF.Types
{
    public class Types
    {
    }

    public class CBIdioma
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
    }

    public class CBTipoFactura
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
    }

    public class CBTipoDocumento
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
    }

    public class ExpeRegistro
    {
        public int ExpedienteID { get; set; }
        public Nullable<int> RegistroNro { get; set; }
    }

    public enum SQLComparisonType
    {
        Default     = 0,
        WildCard    = 1,
        ValueList   = 2,
        Range       = 3
    }

    public class Estado
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
    }

    public class FESerie
    {
        public int TimbradoID { get; set; }
        public string Serie { get; set; }
    }

    public class TipoDE
    {
        public char Tipo { get; set; }
        public string Descripcion { get; set; }
    }

    public class EstadoCotizacion
    {
        public Nullable<bool> Confirmado { get; set; } //Sí, No, Omitir
        public string Nombre { get; set; }
    }

    public class PresupuestoCargaMasivaPagos
    {
        public int PresupuestoID { get; set; }
        public DateTime FechaGeneracion { get; set; }
        public string DocumentoNro { get; set; }
        public int ClienteID { get; set; }
        public int MonedaID { get; set; }
        public string MonedaAbrev { get; set; }
        public decimal Monto { get; set; }
        public decimal Saldo { get; set; }
        public Nullable <decimal> Importe { get; set; }
        public string Estado { get; set; }
    }

    public class NotaCreditoPresupType
    {
        public DateTime FechaNotaCredito { get; set; }
        //public string NroComprobante { get; set; }
        public string FechaNotaCreditoLetras { get; set; }
        public string NombreCliente { get; set; }
        public string Correo { get; set; }
        public string NroNotaCredito { get; set; }
        public string Cuerpo { get; set; }
        public string RefCliente { get; set; }
        public string Presupuestos { get; set; }
        public decimal Monto { get; set; }
        public string Moneda { get; set; }
        public string MontoLetras { get; set; }
        public int ClienteID { get; set; }
        public int IdiomaID { get; set; }
    }

    public class NotaCreditoPresupAll
    {
        //Cabecera
        public int NotaCreditoID { get; set; }
        public int NotaCreditoNro { get; set; }
        public DateTime NotaCreditoFecha { get; set; }
        public int ClienteID { get; set; }
        public Nullable<int> IdiomaID { get; set; }
        public string NombreCliente { get; set; }
        public int MonedaID { get; set; }
        public string MonedaDescrip { get; set; }
        public decimal NotaCreditoMonto { get; set; }
        public string NotaCreditoCuerpo { get; set; }
        public string NotaCreditoReferencia { get; set; }
        public bool NotaCreditoAnulado { get; set; }
        public Nullable<DateTime> FechaAnulacion { get; set; }
        public decimal NotaCreditoSaldo { get; set; }
        public string NotaCreditoPresupuestos { get; set; }
        //Detalle
        public Nullable<int> NotaCreditoDetID { get; set; }
        public Nullable<int> NotaCreditoDetPagoID { get; set; }
        public Nullable<decimal> NotaCreditoDetMonto { get; set; }
        public string NotaCreditoDetMonedaAbrev { get; set; }
        public Nullable<int> NotaCreditoDetPresupuestoCabID { get; set; }
        public string NotaCreditoDetDocumentoNro { get; set; }
        public Nullable<int> NotaCreditoDetTramiteID { get; set; }
        public string NotaCreditoDetTramiteDescrip { get; set; }
        public Nullable<bool> NotaCreditoDetAnulado { get; set; }
        public Nullable<bool> TieneAutorizacionVigente { get; set; }
    }

    public class NotaCreditoPresupCab
    {
        //Cabecera
        public int NotaCreditoID { get; set; }
        public int NotaCreditoNro { get; set; }
        public DateTime NotaCreditoFecha { get; set; }
        public int ClienteID { get; set; }
        public Nullable<int> IdiomaID { get; set; }
        public string NombreCliente { get; set; }
        public int MonedaID { get; set; }
        public string MonedaDescrip { get; set; }
        public decimal NotaCreditoMonto { get; set; }
        public string NotaCreditoCuerpo { get; set; }
        public string NotaCreditoReferencia { get; set; }
        public bool NotaCreditoAnulado { get; set; }
        public Nullable<DateTime> FechaAnulacion { get; set; }
        public decimal NotaCreditoSaldo { get; set; }
        public string NotaCreditoPresupuestos { get; set; }
        public Nullable<Boolean> TieneAutorizacionVigente { get; set; }
    }

    public class SolPagoAll
    {
        //Cabecera
        public int SolPagoCabID { get; set; }
        public Nullable<int> ExpedienteID { get; set; }
        public Nullable<int> OrdenTrabajoID { get; set; }
        public string Origen { get; set; }
        public int MonedaID { get; set; }
        public string MonedaDescrip { get; set; }
        public string MonedaAbrev { get; set; }
        public bool TipoSolicitudPago { get; set; }
        //public string TipoSolicitudPagoDescrip { get; set; }
        public Nullable<int> GastoGeneralID { get; set; }
        public string GastoGeneralDescrip { get; set; }
        public Nullable<int> UnidadNegocioID { get; set; }
        public string UnidadNegocioDescrip { get; set; }
        public Nullable<int> ClienteID { get; set; }
        public string NombreCliente { get; set; }
        public Nullable<int> TramiteID { get; set; }
        public string TramiteDescrip { get; set; }
        public Nullable<int> ActaNro { get; set; }
        public Nullable<int> ActaAnio { get; set; }
        public Nullable<int> HINro { get; set; }
        public Nullable<int> HIAnio { get; set; }
        public Nullable<DateTime> FecSolicitudCab { get; set; }
        public string RefCliente { get; set; }
        public string Observacion { get; set; }
        public decimal Importe { get; set; }
        public Nullable<DateTime> FechaAnulacion { get; set; }
        public decimal Saldo { get; set; }
        public string ActaTexto
        {
            get
            {
                if (this.ActaNro != null)
                    return this.ActaNro.ToString() + "/" + this.ActaAnio.ToString();
                else return "";
            }
        }
        public string HITexto
        {
            get
            {
                if (this.HINro != null)
                    return this.HINro.ToString() + "/" + this.HIAnio.ToString();
                else return "";
            }
        }
        public Nullable<int> AreaID { get; set; }
        public string AreaDescrip { get; set; }
        public string PresupCabIDs { get; set; }
        public bool TipoAsocPresup { get; set; }
        public string Estado { get; set; }
        public string EstadoTexto
        {
            get
            {
                switch (this.Estado)
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
        public Nullable<bool> ExcluirDeListados { get; set; } 

        //Detalle
        public Nullable<int> SolPagoDetID { get; set; }
        public Nullable<int> TarifaID { get; set; }
        public string TarifaDescrip { get; set; }
        public Nullable<decimal> Cantidad { get; set; }
        public Nullable<bool> TipoUnidDescuento { get; set; }
        public Nullable<decimal> DescuentoMonto { get; set; }
        public Nullable<decimal> DescuentoPorc { get; set; }
        public Nullable<bool> TipoUnidImp { get; set; }
        public Nullable<decimal> ImpuestoMonto { get; set; }
        public Nullable<decimal> ImpuestoPorc { get; set; }
        public Nullable<decimal> PrecioVenta { get; set; }
        public Nullable<decimal> PrecioCosto { get; set; }
        public Nullable<decimal> Total { get; set; }
        public Nullable<decimal> SaldoDet { get; set; }
        public Nullable<decimal> RecargoNeto { get; set; }
        public Nullable<decimal> TotalConRecargo { get; set; }
        public Nullable<int> ProveedorID { get; set; }
        public Nullable<bool> ProveedorPublico { get; set; }
        public string NombreProveedor { get; set; }
        public string NroFacturaProv { get; set; }
        public Nullable<bool> Facturable { get; set; }
        public Nullable<bool> Reembolsable { get; set; }
        public Nullable<int> SolicitadoPor { get; set; }
        public string SolicitadoPorNombre { get; set; }
        public Nullable<int> CorrespondenciaID { get; set; }
        public Nullable<int> CorrespondenciaNro { get; set; }
        public Nullable<int> CorrespondenciaAnio { get; set; }
        public string RefCorresp { get; set; }
        public Nullable<DateTime> FecSolicitudDet { get; set; }
        public Nullable<DateTime> FecFactura { get; set; }
        public Nullable<int> TipoFacturaID { get; set; }
        public string TipoFacturaDescrip { get; set; }
        public string CorrespondenciaTexto
        {
            get
            {
                if (this.CorrespondenciaID != null)
                    return this.CorrespondenciaNro.ToString() + "/" + this.CorrespondenciaAnio.ToString();
                else return "";
            }
        }
        public Nullable<decimal> Exentas { get; set; }
        public Nullable<decimal> IVA5 { get; set; }
        public Nullable<decimal> IVA10 { get; set; }
        public Nullable<decimal> CantidadIVA5 { get; set; }
        public Nullable<decimal> CantidadIVA10 { get; set; }
        public Nullable<decimal> PrecUnitIVA5 { get; set; }
        public Nullable<decimal> PrecUnitIVA10 { get; set; }
    }

    public class SolPagoCab
    {
        //Cabecera
        public int SolPagoCabID { get; set; }
        public Nullable<int> ExpedienteID { get; set; }
        public Nullable<int> OrdenTrabajoID { get; set; }
        public string Origen { get; set; }
        public int MonedaID { get; set; }
        public string MonedaDescrip { get; set; }
        public string MonedaAbrev { get; set; }
        public bool TipoSolicitudPago { get; set; }
        //public string TipoSolicitudPagoDescrip { get; set; }
        public Nullable<int> GastoGeneralID { get; set; }
        public string GastoGeneralDescrip { get; set; }
        public Nullable<int> UnidadNegocioID { get; set; }
        public string UnidadNegocioDescrip { get; set; }
        public Nullable<int> ClienteID { get; set; }
        public string NombreCliente { get; set; }
        public Nullable<int> TramiteID { get; set; }
        public string TramiteDescrip { get; set; }
        public Nullable<int> ActaNro { get; set; }
        public Nullable<int> ActaAnio { get; set; }
        public Nullable<int> HINro { get; set; }
        public Nullable<int> HIAnio { get; set; }
        public Nullable<DateTime> FecSolicitudCab { get; set; }
        public string RefCliente { get; set; }
        public string Observacion { get; set; }
        public Nullable<decimal> Importe { get; set; }
        public Nullable<DateTime> FechaAnulacion { get; set; }
        public decimal Saldo { get; set; }
        public string ActaTexto
        {
            get 
            {
                if (this.ActaNro != null)
                    return this.ActaNro.ToString() + "/" + this.ActaAnio.ToString();
                else return "";
            }
        }
        public string HITexto
        {
            get 
            {
                if (this.HINro != null)
                    return this.HINro.ToString() + "/" + this.HIAnio.ToString();
                else return "";
            }
        }
        public string Estado { get; set; }
        public string EstadoTexto
        {
            get
            {
                switch (this.Estado)
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
        public Nullable<int> AreaID { get; set; }
        public string AreaDescrip { get; set; }
        public string PresupCabIDs { get; set; }
        public bool TipoAsocPresup { get; set; }
        public Nullable<bool> ExcluirDeListados { get; set; }
    }

    public class OrigenList
    {
        public string OrigenID { get; set; }
        public string OrigenDescrip { get; set; }
    }

    public class CampoFiltroList
    {
        public string CampoFiltroID { get; set; }
        public string CampoFiltroDescrip { get; set; }
    }

    public class BuscarSolPago
    {
        public int ExpedienteID { get; set;}
        public Nullable<int> ActaNro { get; set; }
        public Nullable<int> ActaAnio { get; set; }
        public Nullable<int> OrdenTrabajoID { get; set;}
        public Nullable<int> HINro { get; set;}
        public Nullable<int> HIAnio { get; set;}
        public int TramiteID { get; set;}
        public string TramiteDescrip { get; set;}
        public Nullable<int> ClienteID { get; set; }
        public string ClienteNombre { get; set; }
    }

    public class CorrespondenciaFilterType
    {
        public int CorrespondenciaID { get; set; }
        public Nullable<int> CorrespondenciaNro { get; set; }
        public Nullable<int> CorrespondenciaAnio { get; set; }
        public string RefCorresp { get; set; }
        public string Descripcion
        {
            get
            {
                if (this.CorrespondenciaNro != null)
                    return this.CorrespondenciaNro.ToString() + "/" + this.CorrespondenciaAnio.ToString() + " - " + this.RefCorresp;
                else return this.RefCorresp;
            }
        }
        //public string Descripcion { get; set; }
    }

    public class SolPagoImpresionDataSet1
    {
        public DateTime FechaSolicitudDet { get; set; }
        public Nullable<int> ProveedorID { get; set; }
        public string NombreProveedor { get; set; }
        public string RUCProveedor { get; set; }
        public string DireccionProveedor { get; set; }
        public int SolPagoCabID { get; set; }
        public decimal Cantidad { get; set; }
        public Nullable<int> CorrespNro { get; set; }
        public Nullable<int> CorrespAnio { get; set; }
        public string Corresp 
        {
            get
            {
                if (this.CorrespNro != null)
                    return this.CorrespNro.ToString() + "/" + this.CorrespAnio.ToString();
                else
                    return "--";
            }
        }
        public Nullable<decimal> Monto { get; set; }
        public Nullable<int> ActaNro { get; set; }
        public Nullable<int> ActaAnio { get; set; }
        public string Acta 
        {
            get
            {
                if (this.ActaNro != null)
                    return this.ActaNro.ToString() + "/" + this.ActaAnio.ToString();
                else
                    return "--";
            }    
        }
        public Nullable<int> HINro { get; set; }
        public Nullable<int> HIAnio { get; set; }
        public string HI 
        {
            get
            {
                if (this.HINro != null)
                    return this.HINro.ToString() + "/" + this.HIAnio.ToString();
                else
                    return "--";
            }
        }
        public string SolicitadoPor { get; set; }
        public string Tramite { get; set; }
        public string TarifaDescrip
        {
            get
            {
                if (this.tramiteDescrip != "")
                    return this.tramiteDescrip;
                else
                    return "Especifique una Descripción en Español para la Tarifa";
            }
            set
            {
                this.tramiteDescrip = value;
            }
        }
        public string Cliente { get; set; }
        public string Observacion { get; set; }
        public string Moneda { get; set; }
        public string Referencia { get; set; }
        public Nullable<bool> Facturable { get; set; }
        public Nullable<bool> Reembolsable { get; set; }
        private string tramiteDescrip = "";
    }

    public class SolPagoImpresionDataSet2
    {
        public string HechoPor { get; set; }
    }

    public class TipoMovimientoList
    {
        public int TipoMovimientoID { get; set; }
        public string TipoMovimientoDescrip { get; set; }
        public string TipoMovimiento { get; set; }
        public string TipoMovimientoTexto
        {
            get
            {
                if (this.TipoMovimiento == "H")
                    return "Crédito";
                else if (this.TipoMovimiento == "D")
                    return "Débito";
                else
                    return "";
            }
        }
    }

    public class MovimientoCuentaListCab
    {
        public int MovimientoID { get; set; }
        public string Estado { get; set; }
        public DateTime FechaMov { get; set; }
        public int CuentaID { get; set; }
        public string CuentaNro { get; set; }
        public string CuentaDescrip { get; set; }
        public string BancoNombre { get; set; }
        public int TipoMovimientoID { get; set; }
        public string TipoMovimientoDescrip { get; set; }
        public string TipoMovimiento { get; set; }
        public decimal Monto { get; set; }
        public string Observacion { get; set; }
        public Nullable<Boolean> TieneAutorizacionVigente { get; set; }
        public Nullable<Boolean> AsociadoACobranza { get; set; }
        public string TipoMovimientoTexto
        {
            get
            {
                if (this.TipoMovimiento == "H")
                    return "Crédito";
                else if (this.TipoMovimiento == "D")
                    return "Débito";
                else
                    return "";
            }
        }
        public string EstadoTexto
        {
            get
            {
                if (this.Estado == "A")
                    return "Activo";
                else if (this.Estado == "N")
                    return "Anulado";
                else
                    return "";
            }
        }
        public bool Anulado //basado en Estado
        {
            get
            {
                if (this.Estado == "A")
                    return false;
                else if (this.Estado == "N")
                    return true;
                else
                    return false;
            }
        }
        public Nullable<int> PagoProveedorID { get; set; }
        public string NroBoletaDep { get; set; }
        public Nullable<DateTime> FechaDeposito { get; set; }
        public Nullable<bool> Cerrado { get; set; }
    }

    public class MovimientoCuentaListAll
    {
        public int MovimientoID { get; set; }
        public string Estado { get; set; }
        public DateTime FechaMov { get; set; }
        public int CuentaID { get; set; }
        public string CuentaNro { get; set; }
        public string CuentaDescrip { get; set; }
        public string BancoNombre { get; set; }
        public int TipoMovimientoID { get; set; }
        public string TipoMovimientoDescrip { get; set; }
        public string TipoMovimiento { get; set; }
        public decimal Monto { get; set; }
        public string Observacion { get; set; }
        public Nullable<Boolean> TieneAutorizacionVigente { get; set; }
        public Nullable<Boolean> AsociadoACobranza { get; set; }
        public string TipoMovimientoTexto
        {
            get
            {
                if (this.TipoMovimiento == "H")
                    return "Crédito";
                else if (this.TipoMovimiento == "D")
                    return "Débito";
                else
                    return "";
            }
        }
        public string EstadoTexto
        {
            get
            {
                if (this.Estado == "A")
                    return "Activo";
                else if (this.Estado == "N")
                    return "Anulado";
                else
                    return "";
            }
        }
        public bool Anulado //basado en Estado
        {
            get
            {
                if (this.Estado == "A")
                    return false;
                else if (this.Estado == "N")
                    return true;
                else
                    return false;
            }
        }
        public Nullable<int> PagoProveedorID { get; set; }
        public string NroBoletaDep { get; set; }
        public Nullable<DateTime> FechaDeposito { get; set; }
        public Nullable<int> CobroID { get; set; }
        public Nullable<int> CobroxMovimientoID { get; set; }
        public Nullable<DateTime> FechaCobro { get; set; }
        public Nullable<int> ClienteID { get; set; }
        public string ClienteNombre { get; set; }
        public string ReciboNro { get; set; }
        public Nullable<DateTime> FechaRecibo { get; set; }
        public Nullable<int> MonedaID { get; set; }
        public string MonedaDescrip { get; set; }
        public string MonedaAbrev { get; set; }
        public Nullable<int> TramiteID { get; set; }
        public string TramiteDescrip { get; set; }
        public Nullable<decimal> MontoCobro { get; set; }
        public Nullable<bool> Cerrado { get; set; }
        public string DocumentoNro { get; set; }
    }

    public class PresupuestoXSolicitudType
    {
        public Nullable<int> PresupuestoCabID { get; set; }
        public string NroDocumento { get; set; }
    }

    public class SeleccionarPresupuestoType
    {
        public int PresupuestoCabID { get; set; }
        public string NroDocumento { get; set; }
        public Nullable<DateTime> FechaDocumento { get; set; }
        public string EstadoDocumento { get; set; }
        public int TramiteID { get; set; }
        public string TramiteDescrip { get; set; }
    }

    public class SeleccionarCobrosType
    {
        public Nullable<int> CobroID { get; set; }
        public Nullable<int> CobroMultipleID { get; set; }
        public Nullable<int> MovimientoID { get; set; }
        public Nullable<int> CobroXMovimientoID { get; set; }
        public Nullable<DateTime> FechaCobro { get; set; }
        public Nullable<int> MonedaID { get; set; }
        public string MonedaAbrev { get; set; }
        public string MonedaDescrip { get; set; }
        public Nullable<int> FormaCobroID { get; set; }
        public string FormaCobroDescrip { get; set; }
        public Nullable<decimal> MontoCobro { get; set; }
        public Nullable<int> ClienteID { get; set; }
        public string ClienteNombre { get; set; }
        public Nullable<int> TramiteID { get; set; }
        public string TramiteDescrip { get; set; }
        public string ReciboNro { get; set; }
        public string ChequeNro { get; set; }
        public Nullable<DateTime> FechaRecibo { get; set; }
        public Nullable<bool> Seleccionar { get; set; }
        public Nullable<bool> Anulado { get; set; }
        public string PresupuestoNro { get; set; }
        public string FacturaNro { get; set; }
        public string DocumentoNro { get; set; }
        public Nullable<DateTime> FechaDeposito { get; set; }
        public string BoletaDepNro { get; set; }
        public string BancoDeposito { get; set; }
        public string CuentaDeposito { get; set; }
        public string MonedaGasto { get; set; }
        public Nullable<decimal> MontoGasto { get; set; }
        public Nullable<int> BancoChequeID { get; set; }
        public string BancoChequeNombre { get; set; }
        public string NroCheque { get; set; }
    }

    public class CambioFormaCobroType
    {
        public int CobroID { get; set; }
        public Nullable<int> CobroMultipleID { get; set; }
        public Nullable<int> FormaCobroID { get; set; }
        public Nullable<DateTime> FechaCobro { get; set; }
        public Nullable<DateTime> FechaDeposito { get; set; }
        public string BoletaDepNro { get; set; }
        public Nullable<int> BancoDepositoID { get; set; }
        public Nullable<int> CtaDepositoID { get; set; }
        public Nullable<int> MonedaGastoID { get; set; }
        public Nullable<decimal> MontoGasto { get; set; }
        public Nullable<int> BancoChequeID { get; set; }
        public string BancoChequeNombre { get; set; }
        public string NroCheque { get; set; }
    }

    public class UnidadNegocioType
    {
        public int UnidadNegocioID { get; set; }
        public string UnidadNegocioDescrip { get; set; }
    }

    public class Dataset1RepCobranzasGcial
    {
        public string Dataset { get; set; }
        public Nullable<int> CobroID { get; set; }
        public string CobroIDStr { get; set; }
        public string Documentos { get; set; }
        public Nullable<DateTime> FechaCobro { get; set; }
        public Nullable<int> ClienteID { get; set; }
        public string ClienteNombre { get; set; }
        public Nullable<int> MonedaID { get; set; }
        public string MonedaAbrev { get; set; }
        public string MonedaDescrip { get; set; }
        public Nullable<int> FormaPagoID { get; set; }
        public string FormaPagoDescrip { get; set; }
        public Nullable<int> BancoChequeID { get; set; }
        public string BancoChequeDescrip { get; set; }
        public string ChequeNro { get; set; }
        public Nullable<decimal> MontoCobro { get; set; }
        public Nullable<int> TramiteID { get; set; }
        public string TramiteDescrip { get; set; }
        public Nullable<int> AreaID { get; set; }
        public string AreaDescrip { get; set; }
        public Nullable<int> UnidadNegocioID { get; set; }
        public string UnidadNegocioDescrip { get; set; }
        public string Rango { get; set; }
    }

    public class Dataset2RepCobranzasGcial
    {
        public string Dataset { get; set; }
        public string DS2_MonedaDescrip { get; set; }
        public Nullable<decimal> DS2_TotalPI { get; set; }
        public Nullable<decimal> DS2_TotalPG { get; set; }
        public Nullable<decimal> DS2_GranTotal { get; set; }
    }

    public class Dataset3RepCobranzasGcial
    {
        public string Dataset { get; set; }
        public string DS3_MonedaDescrip { get; set; }
        public Nullable<int> DS3_TotalPI { get; set; }
        public Nullable<int> DS3_TotalPG { get; set; }
        public Nullable<int> DS3_GranTotal { get; set; }
    }

    public class AnhoType
    {
        public int Anho { get; set; }
        public string AnhoNombre
        {
            get { return this.Anho.ToString(); } 
        }
    }

    public class MesType
    {
        public int Mes { get; set; }
        public string MesNombre
        {
            get
            {
                DateTimeFormatInfo formatoFecha = VWGContext.Current.CurrentUICulture.DateTimeFormat;
                return this.UpperFirst(formatoFecha.GetMonthName(this.Mes));
            }
        }

        private string UpperFirst(string text)
        {
            return char.ToUpper(text[0]) +
                ((text.Length > 1) ? text.Substring(1).ToLower() : string.Empty);
        }
    }

    public class TipoSistemaElectronico
    {
        public int TipoSistemaElectronicoID { get; set; }
        public string TipoSistemaElectronicoDescrip { get; set; }
    }

    public class ConsultaCotizacionesAll
    {
        public Nullable<DateTime> FechaCotizacionDate { get; set; }
        public string FechaCotizacion { get; set; }
        public Nullable<int> CotizacionCabID { get; set; }
        public string UsuarioCotizacion { get; set; }
        public string Confirmado { get; set; }
        public string FechaConfirmacion { get; set; }
        public string UsuarioConfirmacion { get; set; }
        public int ClienteID { get; set; }
        public string ClienteNombre { get; set; }
        public Nullable<int> TramiteID { get; set; }
        public string TramiteDescripcion { get; set; }
        public Nullable<int> MonedaID { get; set; }
        public string MonedaDescrip { get; set; }
        public string MonedaAbrev { get; set; }
        public Nullable<decimal> TotalCotizacion { get; set; }
        public Nullable<bool> ConfirmadoVal { get; set; }
        public Nullable<DateTime> FechaConfirmacionDate { get; set; }
        public Nullable<int> PresupuestoCabID { get; set; }
        public string NroDocumento { get; set; }
        public string OrigenExpediente { get; set; }
        public Nullable<int> ExpedienteID { get; set; }
        public string Acta { get; set; }
        public Nullable<int> ActaNro { get; set; }
        public Nullable<int> ActaAnio { get; set; }
        public string HI { get; set; }
        public Nullable<int> HINro { get; set; }
        public Nullable<int> HIAnio { get; set; }
        public string ObsCotizacion { get; set; }
        public Nullable<int> CotizacionCabIDAntecedente { get; set; }
        public Nullable<int> ClienteIDAntecedente { get; set; }
        public Nullable<DateTime> FechaAntecedente { get; set; }
        public Nullable<int> AntecedenteID { get; set; }
        public Nullable<int> TipoAntecedenteID { get; set; }
        public string TipoAntecedenteNombre { get; set; }
        public Nullable<int> TarifarioID { get; set; }
        public string ObservacionAntecedente { get; set; }
        public string TipoAntecedenteLocal { get; set; }
        public Nullable<int> UsuarioEnviaIDAntecedente { get; set; }
        public string UsuarioEnviaAntecedente { get; set; }
        public Nullable<int> UsuarioAutorizaIDAntecedente { get; set; }
        public string UsuarioAutorizaNombre { get; set; }
        public Nullable<int> TramiteIDAntecedente { get; set; }
        public string TramiteDescripAntecedente { get; set; }
        public Nullable<int> ActaNroAntecedente { get; set; }
        public Nullable<int> ActaAnioAntecedente { get; set; }
        public Nullable<int> RegistroNroAntecedente { get; set; }
    }

    public class ConsultaCotizacionesCab
    {
        public Nullable<DateTime> FechaCotizacionDate { get; set; }
        public string FechaCotizacion { get; set; }
        public Nullable<int> CotizacionCabID { get; set; }
        public string UsuarioCotizacion { get; set; }
        public string Confirmado { get; set; }
        public string FechaConfirmacion { get; set; }
        public string UsuarioConfirmacion { get; set; }
        public int ClienteID { get; set; }
        public string ClienteNombre { get; set; }
        public Nullable<int> TramiteID { get; set; }
        public string TramiteDescripcion { get; set; }
        public Nullable<int> MonedaID { get; set; }
        public string MonedaDescrip { get; set; }
        public string MonedaAbrev { get; set; }
        public Nullable<decimal> TotalCotizacion { get; set; }
        public Nullable<bool> ConfirmadoVal { get; set; }
        public Nullable<DateTime> FechaConfirmacionDate { get; set; }
        public Nullable<int> PresupuestoCabID { get; set; }
        public string NroDocumento { get; set; }
        public string OrigenExpediente { get; set; }
        public Nullable<int> ExpedienteID { get; set; }
        public string Acta { get; set; }
        public Nullable<int> ActaNro { get; set; }
        public Nullable<int> ActaAnio { get; set; }
        public string HI { get; set; }
        public Nullable<int> HINro { get; set; }
        public Nullable<int> HIAnio { get; set; }
        public string ObsCotizacion { get; set; }
    }

    public class SelPresupFactura
    {
        public int PresupuestoCabID { get; set; }
        public Nullable<int> FacturaCabID { get; set; }
        public int ClienteID { get; set; }
        public string ClienteNombre { get; set; }
        public string NroDocumento { get; set; }
        public Nullable<DateTime> FechaDocumento { get; set; }
        public decimal MontoDocumento { get; set; }
        public decimal SaldoDocumento { get; set; }
        public string EstadoDocumento { get; set; }
        public Nullable<DateTime> CobroFechaDeposito { get; set; }
        public Nullable<DateTime> CobroFechaCobro { get; set; }
        public string CobroNroBoletaDeposito { get; set; }
        public string CobroNroCheque { get; set; }
        public Nullable<int> CobroBancoChequeID { get; set; }
        public string CobroBancoChequeNombre { get; set; }
        public Nullable<Boolean> CobroAnulado { get; set; }
        public int MonedaID { get; set; }
        public string MonedaAbrev { get; set; }
        public string MonedaDescrip { get; set; }
        public Nullable<decimal> CobroMonto {
            get
            {
                return this.cobroMonto;
            }
            set
            {
                if (value.HasValue)
                    this.cobroMonto = value.Value;
            }
        }
        public Nullable<decimal> TotalFacturadoSF { get; set; }
        public Nullable<int> CobroID { get; set; }
        public string NroPresupuesto { get; set; }
        public string NroFactura { get; set; }

        private decimal cobroMonto = 0;
    }

    public class CBSerie
    {
        public int TimbradoID { get; set; }
        public string DescripcionTimbrado { get; set; }
        public Nullable<Boolean> Vigente { get; set; }
        public Nullable<int> UsuarioID { get; set; }
        public int TipoDocumentoID { get; set; }
        
    }

    public class CBMotivoEmisionNC
    {
        public int MotivoEmisionID { get; set; }
        public int MotivoEmisionSIFENID { get; set; }
        public string MotivoEmisionSIFENDescrip { get; set; }
        public bool Mostrar { get; set; }
    }

    public class ClienteContinenteCuentaMoneda
    {
        public int CCCMID { get; set; }
        public string TipoRelacion { get; set; }
        public int ConCliID { get; set; }
        public string ConCliDescripcion { get; set; }
        public int CuentaID { get; set; }
        public string CuentaDescripcion { get; set; }
        public string CuentaNumero { get; set; }
        public int BancoID { get; set; }
        public string BancoDescripcion { get; set; }
        public int MonedaID { get; set; }
        public string MonedaDescripcion { get; set; }
        public string MonedaAbrev { get; set; }
    }

    public class PermisoTimbrado
    {
        public int PermisoTimbradoID { get; set; }
        public int TimbradoID { get; set; }
        public int UsuarioID { get; set; }
        public string UsuarioNombre { get; set; }
        public int TipoDocumentoID { get; set; }
    }

    public class PermisoRol
    {
        public int PermisoRolID { get; set; }
        public Nullable<int> RolID { get; set; }
        public Nullable<int> UsuarioID { get; set; }
        public string UsuarioNombre { get; set; }
        public Nullable<Boolean> PuedeVerTodo { get; set; }
    }

    public class AccesosType
    {
        public int MenuID { get; set; }
        public string MenuClave { get; set; }
        public Nullable<int> MenuPadreID { get; set; }
        public string MenuPadreTitulo { get; set; }
        public string MenuTitulo { get; set; }
        public Nullable<int> RolID { get; set; }
        public int MenuNivel { get; set; }
        public Nullable<int> MenuOrden { get; set; }
        public Nullable<Boolean> MenuActivo { get; set; }
        public Nullable<int> SistemaID { get; set; }
    }

    //public class ExclusionFacturas
    //{
    //    private const string ASOCIADO_A_TRAMITE = "Asociado a Trámite";
    //    private const string GASTOS_GENERALES = "Gastos Generales";

    //    public int SolicitudPagoCabeceraId { get; set; }
    //    public int SolicitudPagoCabeceraMonedaId { get; set; }
    //    public int SolicitudPagoDetalleId { get; set; }
    //    public decimal SolicitudPagoDetalleMonto { get; set; }
    //    public decimal SolicitudPagoDetalleSaldo { get; set; }
    //    public string SolicitudPagoCabeceraObs { get; set; }
    //    public string SolicitudPagoCabeceraCliente { get; set; }
    //    public string SolicitudPagoDetalleTarifa { get; set; }
    //    public bool SolicitudPagoCabeceraAsocTramite  
    //    { 
    //        get; 
    //        set; 
    //    }

    //    public string SolicitudPagoCabeceraAsocTramiteStr
    //    {
    //        get
    //        {
    //            return this.SolicitudPagoCabeceraAsocTramite ? ASOCIADO_A_TRAMITE : GASTOS_GENERALES;
    //        }
    //    }
    //}

    public class SolicitudExclusionCabecera
    {
        public int SolExcCabId { get; set; }
        public int SolExcCabProveedorId { get; set; }
        public string SolExcCabProveedorNombre { get; set; }
        public string SolExcCabNroFactura { get; set; }
        public DateTime SolExcCabFechaFactura { get; set; }
        public DateTime SolExcCabFechaExclusion { get; set; }
        public decimal SolExcCabImporte { get; set; }
        public decimal SolExcCabSaldo { get; set; }
        public bool SolExcCabActivo { get; set; }
        public int SolExcCabMonedaId { get; set; }
        public string SolExcCabMonedaDescrip { get; set; }
        public string SolExcCabMonedaAbrev { get; set; }
        public Nullable<int> SolExcCabTipoFacturaId { get; set; }
        public string SolExcCabTipoFacturaDescrip { get; set; }
    }

    public class SolicitudExclusionDetalle
    {
        private const string ASOCIADO_A_TRAMITE = "Asociado a Trámite";
        private const string GASTOS_GENERALES = "Gastos Generales";

        public Nullable<int> SolExcDetCabId { get; set; }
        public int SolicitudPagoCabeceraId { get; set; }
        public int SolicitudPagoCabeceraMonedaId { get; set; }
        public int SolicitudPagoDetalleId { get; set; }
        public decimal SolicitudPagoDetalleMonto { get; set; }
        public decimal SolicitudPagoDetalleSaldo { get; set; }
        public string SolicitudPagoCabeceraObs { get; set; }
        public string SolicitudPagoCabeceraCliente { get; set; }
        public string SolicitudPagoDetalleTarifa { get; set; }
        public bool SolicitudPagoCabeceraAsocTramite
        {
            get;
            set;
        }

        public string SolicitudPagoCabeceraAsocTramiteStr
        {
            get
            {
                return this.SolicitudPagoCabeceraAsocTramite ? ASOCIADO_A_TRAMITE : GASTOS_GENERALES;
            }
        }
    }

    public class SolicitudExclusionAll
    {
        //Cabecera
        public int SolExcCabId { get; set; }
        public int SolExcCabProveedorId { get; set; }
        public string SolExcCabProveedorNombre { get; set; }
        public string SolExcCabNroFactura { get; set; }
        public DateTime SolExcCabFechaFactura { get; set; }
        public DateTime SolExcCabFechaExclusion { get; set; }
        public decimal SolExcCabImporte { get; set; }
        public decimal SolExcCabSaldo { get; set; }
        public bool SolExcCabActivo { get; set; }
        public int SolExcCabMonedaId { get; set; }
        public string SolExcCabMonedaDescrip { get; set; }
        public string SolExcCabMonedaAbrev { get; set; }
        public Nullable<int> SolExcCabTipoFacturaId { get; set; }
        public string SolExcCabTipoFacturaDescrip { get; set; }
        //Detalles
        private const string ASOCIADO_A_TRAMITE = "Asociado a Trámite";
        private const string GASTOS_GENERALES = "Gastos Generales";

        public int SolicitudPagoCabeceraId { get; set; }
        public int SolicitudPagoCabeceraMonedaId { get; set; }
        public int SolicitudPagoDetalleId { get; set; }
        public decimal SolicitudPagoDetalleMonto { get; set; }
        public decimal SolicitudPagoDetalleSaldo { get; set; }
        public string SolicitudPagoCabeceraObs { get; set; }
        public string SolicitudPagoCabeceraCliente { get; set; }
        public string SolicitudPagoDetalleTarifa { get; set; }
        public bool SolicitudPagoCabeceraAsocTramite
        {
            get;
            set;
        }

        public string SolicitudPagoCabeceraAsocTramiteStr
        {
            get
            {
                return this.SolicitudPagoCabeceraAsocTramite ? ASOCIADO_A_TRAMITE : GASTOS_GENERALES;
            }
        }
    }

    public class PresupSelReemp
    {
        public int PresupuestoCabID { get; set; }
        public int ClienteID { get; set; }
        public string ClienteNombre { get; set; }
        public string NroDocumento { get; set; }
        public Nullable<DateTime> FechaDocumento { get; set; }
        public decimal MontoDocumento { get; set; }
        public decimal SaldoDocumento { get; set; }
        public string EstadoDocumento { get; set; }
        public int TramiteID { get; set; }
        public string TramiteDescrip { get; set; }
        public int MonedaID { get; set; }
        public string MonedaAbrev { get; set; }
        public string MonedaDescrip { get; set; }
        public int SolicitadoPorID { get; set; }
        public string SolicitadoPorNombre { get; set; }
        public int AutorizadoPorID { get; set; }
        public string AutorizadoPorNombre { get; set; }
        public string Origen { get; set; }
        public Nullable<int> AtencionID { get; set; }
        public string AtencionNombre { get; set; }
        public string AtencionEmail { get; set; }
        public string ClienteSelloColor { get; set; }
        public string ClienteSelloTexto { get; set; }


        private string selloColor = "";
    }

    public class PatrixRTFType
    {
        public string FileFullName { get; set; }
        public string Description { get; set; }
    }

}