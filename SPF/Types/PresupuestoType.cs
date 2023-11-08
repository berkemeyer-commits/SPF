using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gizmox.WebGUI.Forms;

using ModelEF6;

namespace SPF.Types
{
    public class PresupuestoTypeAll
    {
        public int PresupuestoCabID { get; set; }
        public Nullable<int> MergeDocID { get; set; }
        public string Serie { get; set; }
        public Nullable<int> NroPresupuesto { get; set; }
        public int ClienteID { get; set; }
        public string ClienteNombre { get; set; }
        public Nullable<int> AtencionID { get; set; }
        public string AtencionNombre { get; set; }
        public int MonedaID { get; set; }
        public string MonedaDescrip { get; set; }
        public string MonedaAbrev { get; set; }
        public Nullable<int> AreaID { get; set; }
        public string AreaDescrip { get; set; }
        public int UsuarioHechoPorID { get; set; }
        public string UsuarioHechoPorNombre { get; set; }
        public int UsuarioAprobPorID { get; set; }
        public string UsuarioAprobPorNombre { get; set; }
        public Nullable<int> UsuarioReempSolicPorID { get; set; }
        public string UsuarioReempSolicPorNombre { get; set; }
        public DateTime FechaGeneracion { get; set; }
        public decimal Total { get; set; }
        public decimal Saldo { get; set; }
        public string ParteNombre { get; set; }
        public string ContraParteNombre { get; set; }
        public string SerieNroPresupuesto { get; set; }
        public bool TieneAutorizacionVigente { get; set; }
        public string Origen { get; set; }
        public Nullable<bool> Reemplazado { get; set; }
        public string FacturaNro { get; set; }
        public string Descripcion { get; set; }
        public string TelefonoFactura { get; set; }
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
        public int TramiteID { get; set; }
        public string TramiteDescripcion { get; set; }
        public string TramiteDF { get; set; }
        public string Timbrado { get; set; }
        public string RazonSocialFactura { get; set; }
        public string RUCFactura { get; set; }
        public Nullable<DateTime> FecDocReemp { get; set; }
        public Nullable<int> UsuarioGeneracionID { get; set; }
        public string UsuarioGeneracionNombre { get; set; }
        public Nullable<int> FormaPagoID { get; set; }
        public string NroCasoPatrix { get; set; }
        public Nullable<decimal> MontoRecargoAT { get; set; }
        public Nullable<int> FacturaCabID { get; set; }
        //Detalle
        public Nullable<int> ActaNro { get; set; }
        public Nullable<int> ActaAnio { get; set; }
        public Nullable<int> HINro { get; set; }
        public Nullable<int> HIAnio { get; set; }
        public string Acta { get; set; }
        public string HI { get; set; }
        public Nullable<int> CotizacionCabID { get; set; }
        public Nullable<int> ExpedienteID { get; set; }
        public Nullable<int> OrdenTrabajoID { get; set; }
        public string PropietarioMarca { get; set; }
        public string DenominacionMarca { get; set; }
        public string PresupCabIDsReemplazo { get; set; }
    }

    public class PresupuestoTypeCab
    {
        public int PresupuestoCabID { get; set; }
        public Nullable<int> MergeDocID { get; set; }
        public string Serie { get; set; }
        public Nullable<int> NroPresupuesto { get; set; }
        public int ClienteID { get; set; }
        public string ClienteNombre { get; set; }
        public Nullable<int> AtencionID { get; set; }
        public string AtencionNombre { get; set; }
        public int MonedaID { get; set; }
        public string MonedaDescrip { get; set; }
        public string MonedaAbrev { get; set; }
        public Nullable<int> AreaID { get; set; }
        public string AreaDescrip { get; set; }
        public int UsuarioHechoPorID { get; set; }
        public string UsuarioHechoPorNombre { get; set; }
        public int UsuarioAprobPorID { get; set; }
        public string UsuarioAprobPorNombre { get; set; }
        public DateTime FechaGeneracion { get; set; }
        public decimal Total { get; set; }
        public decimal Saldo { get; set; }
        public string ParteNombre { get; set; }
        public string ContraParteNombre { get; set; }
        public string SerieNroPresupuesto { get; set; }
        public bool TieneAutorizacionVigente { get; set; }
        public string Origen { get; set; }
        public Nullable<bool> Reemplazado { get; set; }
        public string FacturaNro { get; set; }
        public string Descripcion { get; set; }
        public string TelefonoFactura { get; set; }
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
        public int TramiteID { get; set; }
        public string TramiteDescripcion { get; set; }
        public string TramiteDF { get; set; }
        public string Timbrado { get; set; }
        public string RazonSocialFactura { get; set; }
        public string RUCFactura { get; set; }
        public Nullable<DateTime> FecDocReemp { get; set; }
        public Nullable<int> UsuarioGeneracionID { get; set; }
        public string UsuarioGeneracionNombre { get; set; }
        public Nullable<int> FormaPagoID { get; set; }
        public string NroCasoPatrix { get; set; }
        public Nullable<decimal> MontoRecargoAT { get; set; }
        public Nullable<int> FacturaCabID { get; set; }
        public string PresupCabIDsReemplazo { get; set; }
    }

    public class PagoSolPagoTypeAll
    {
        public int PagoProveedorID { get; set; }
        public string Origen { get; set; }
        public Nullable<int> ProveedorID { get; set; }
        public string ProveedorNombre { get; set; }
        public string ProveedorNroFactura { get; set; }
        public Nullable<DateTime> ProveedorFecFactura { get; set; }
        public Nullable<int> MonedaID { get; set; }
        public string MonedaDescrip { get; set; }
        public string MonedaAbrev { get; set; }
        public DateTime FechaPago { get; set; }
        public int FormaPagoID { get; set; }
        public string FormaPagoNombre { get; set; }
        public string DocumentosID { get; set; }
        public string DocumentosInfo { get; set; }
        public int UsuarioGeneracionID { get; set; }
        public string UsuarioGeneracionNombre { get; set; }
        public Nullable<decimal> SaldoTotal { get; set; }
        /*Depósito en Cuenta*/
        public Nullable<DateTime> FechaBoletaDep { get; set; }
        public Nullable<int> BancoDepID { get; set; }
        public string BancoDepNombre { get; set; }
        public Nullable<int> CtaDepID { get; set; }
        public string CtaDepNombre { get; set; }
        /*Cheque*/
        public Nullable<DateTime> FechaCheque { get; set; }
        public Nullable<int> BancoCheqID { get; set; }
        public string BancoCheqNombre { get; set; }
        public Nullable<int> CtaCheqID { get; set; }
        public string CtaCheqNombre { get; set; }
        public string CtaCheqNro { get; set; }
        public string MonedaCtaCheq { get; set; }
        public string ChequeNro { get; set; }
        /*Recibo*/
        public string NroRecibo { get; set; }
        public Nullable<DateTime> FechaRecibo { get; set; }
        /*Nota Crédito*/
        public string NotaCreditoNro { get; set; }
        public Nullable<DateTime> FechaNotaCredito { get; set; }

        public Nullable<int> SolicitudPagoCabID { get; set; }
        public Nullable<decimal> Saldo { get; set; }
        public decimal MontoPago { get; set; }
        public string ReferenciaPago { get; set; }

        public Nullable<bool> TieneAutorizacionVigente { get; set; }
        public string DocOrigen { get; set; }
        public bool Anulado { get; set; }

        public string NroTransaccion { get; set; }
        public string CodReferencia { get; set; }
        public Nullable<DateTime> FechaCarga { get; set; }
    }

    public class PagoSolPagoTypeCab
    {
        public int PagoProveedorID { get; set; }
        public string Origen { get; set; }
        public Nullable<int> ProveedorID { get; set; }
        public string ProveedorNombre { get; set; }
        public string ProveedorNroFactura { get; set; }
        public Nullable<DateTime> ProveedorFecFactura { get; set; }
        public Nullable<int> MonedaID { get; set; }
        public string MonedaDescrip { get; set; }
        public string MonedaAbrev { get; set; }
        public DateTime FechaPago { get; set; }
        public int FormaPagoID { get; set; }
        public string FormaPagoNombre { get; set; }
        public string DocumentosID { get; set; }
        public string DocumentosInfo { get; set; }
        public int UsuarioGeneracionID { get; set; }
        public string UsuarioGeneracionNombre { get; set; }
        public Nullable<decimal> SaldoTotal { get; set; }
        /*Depósito en Cuenta*/
        public Nullable<DateTime> FechaBoletaDep { get; set; }
        public Nullable<int> BancoDepID { get; set; }
        public string BancoDepNombre { get; set; }
        public Nullable<int> CtaDepID { get; set; }
        public string CtaDepNombre { get; set; }
        /*Cheque*/
        public Nullable<DateTime> FechaCheque { get; set; }
        public Nullable<int> BancoCheqID { get; set; }
        public string BancoCheqNombre { get; set; }
        public Nullable<int> CtaCheqID { get; set; }
        public string CtaCheqNombre { get; set; }
        public string CtaCheqNro { get; set; }
        public string MonedaCtaCheq { get; set; }
        public string ChequeNro { get; set; }
        /*Recibo*/
        public string NroRecibo { get; set; }
        public Nullable<DateTime> FechaRecibo { get; set; }
        /*Nota Crédito*/
        public string NotaCreditoNro { get; set; }
        public Nullable<DateTime> FechaNotaCredito { get; set; }

        public decimal MontoPago { get; set; }
        public string ReferenciaPago { get; set; }

        public Nullable<bool> TieneAutorizacionVigente { get; set; }
        public string DocOrigen { get; set; }
        public bool Anulado { get; set; }

        public string NroTransaccion { get; set; }
        public string CodReferencia { get; set; }

        public Nullable<DateTime> FechaCarga { get; set; }
    }

    public class PagoSolPagoRegExtTypeAll
    {
        public int PagoCorresponsalID { get; set; }
        public string Origen { get; set; }
        public Nullable<int> CorresponsalID { get; set; }
        public string CorresponsalNombre { get; set; }
        public string CorresponsalNroFactura { get; set; }
        public Nullable<DateTime> CorresponsalFecFactura { get; set; }
        public Nullable<int> MonedaID { get; set; }
        public string MonedaDescrip { get; set; }
        public string MonedaAbrev { get; set; }
        public DateTime FechaPago { get; set; }
        public int FormaPagoID { get; set; }
        public string FormaPagoNombre { get; set; }
        public string DocumentosID { get; set; }
        public string DocumentosInfo { get; set; }
        public int UsuarioGeneracionID { get; set; }
        public string UsuarioGeneracionNombre { get; set; }
        public Nullable<decimal> SaldoTotal { get; set; }
        /*Depósito en Cuenta*/
        public Nullable<DateTime> FechaBoletaDep { get; set; }
        public Nullable<int> BancoDepID { get; set; }
        public string BancoDepNombre { get; set; }
        public Nullable<int> CtaDepID { get; set; }
        public string CtaDepNombre { get; set; }
        /*Cheque*/
        public Nullable<DateTime> FechaCheque { get; set; }
        public Nullable<int> BancoCheqID { get; set; }
        public string BancoCheqNombre { get; set; }
        public Nullable<int> CtaCheqID { get; set; }
        public string CtaCheqNombre { get; set; }
        public string CtaCheqNro { get; set; }
        public string MonedaCtaCheq { get; set; }
        public string ChequeNro { get; set; }
        /*Recibo*/
        public string NroRecibo { get; set; }
        public Nullable<DateTime> FechaRecibo { get; set; }
        /*Nota Crédito*/
        public string NotaCreditoNro { get; set; }
        public Nullable<DateTime> FechaNotaCredito { get; set; }

        public Nullable<int> SolicitudPagoCabID { get; set; }
        public Nullable<decimal> Saldo { get; set; }
        public decimal MontoPago { get; set; }
        public string ReferenciaPago { get; set; }

        public Nullable<bool> TieneAutorizacionVigente { get; set; }
        public string DocOrigen { get; set; }
        public bool Anulado { get; set; }
    }

    public class PagoSolPagoRegExtTypeCab
    {
        public int PagoCorresponsalID { get; set; }
        public string Origen { get; set; }
        public Nullable<int> CorresponsalID { get; set; }
        public string CorresponsalNombre { get; set; }
        public string CorresponsalNroFactura { get; set; }
        public Nullable<DateTime> CorresponsalFecFactura { get; set; }
        public Nullable<int> MonedaID { get; set; }
        public string MonedaDescrip { get; set; }
        public string MonedaAbrev { get; set; }
        public DateTime FechaPago { get; set; }
        public int FormaPagoID { get; set; }
        public string FormaPagoNombre { get; set; }
        public string DocumentosID { get; set; }
        public string DocumentosInfo { get; set; }
        public int UsuarioGeneracionID { get; set; }
        public string UsuarioGeneracionNombre { get; set; }
        public Nullable<decimal> SaldoTotal { get; set; }
        /*Depósito en Cuenta*/
        public Nullable<DateTime> FechaBoletaDep { get; set; }
        public Nullable<int> BancoDepID { get; set; }
        public string BancoDepNombre { get; set; }
        public Nullable<int> CtaDepID { get; set; }
        public string CtaDepNombre { get; set; }
        /*Cheque*/
        public Nullable<DateTime> FechaCheque { get; set; }
        public Nullable<int> BancoCheqID { get; set; }
        public string BancoCheqNombre { get; set; }
        public Nullable<int> CtaCheqID { get; set; }
        public string CtaCheqNombre { get; set; }
        public string CtaCheqNro { get; set; }
        public string MonedaCtaCheq { get; set; }
        public string ChequeNro { get; set; }
        /*Recibo*/
        public string NroRecibo { get; set; }
        public Nullable<DateTime> FechaRecibo { get; set; }
        /*Nota Crédito*/
        public string NotaCreditoNro { get; set; }
        public Nullable<DateTime> FechaNotaCredito { get; set; }

        public decimal MontoPago { get; set; }
        public string ReferenciaPago { get; set; }

        public Nullable<bool> TieneAutorizacionVigente { get; set; }
        public string DocOrigen { get; set; }
        public bool Anulado { get; set; }
    }

    public class ImprimirFacturaType
    {
        public string FechaFactura { get; set; }
        public string ClienteNombre { get; set; }
        public string FacturaContado { get; set; }
        public string FacturaCredito { get; set; }
        public string MonedaAbrev { get; set; }
        public string RUC { get; set; }
        public string NroRemision { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Cantidad { get; set; }
        public string Descripcion { get; set; }
        public string PrecioUnitario { get; set; }
        public string Exentas { get; set; }
        public string CincoPorciento { get; set; }
        public string DiezPorciento { get; set; }
        public string TotalExentas { get; set; } 
        public string TotalCincoPorciento { get; set; } 
        public string TotalDiezPorciento { get; set; }
        public string TotalFactura { get; set; }         
        public string TotalLetras { get; set; }
        public string LiqIVA5 { get; set; }
        public string LiqIVA10 { get; set; }
        public string LiqIVATotal { get; set; }
        //
        public string NroTimbrado { get; set; }
        public string VigenciaInicio { get; set; }
        public string VigenciaFin { get; set; }
        public string NroFactura { get; set; }
        public Nullable<bool> Anulado { get; set; }
    }

    public class DatosTimbrado
    {
        public int FacturaCabID { get; set; }
        public Nullable<long> NroTimbrado { get; set; }
        public Nullable<DateTime> VigenciaInicio { get; set; }
        public Nullable<DateTime> VigenciaFin { get; set; }
        public string NroFactura { get; set; }
        public Boolean Anulado { get; set; }
    }

    public class ClienteFacturaType
    {
        public int ClienteID { get; set; }
        public string ClienteNombre { get; set; }
        public string RUC { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int IdiomaID { get; set; }
    }

    public class FacturaAllType
    {
        public DateTime FacturaFecha { get; set; }
        public int FacturaCabeceraID { get; set; }
        public Nullable<int> FacturaTimbradoID { get; set; }
        public Nullable<bool> FacturaTimbradoHojaSuelta { get; set; }
        public string FacturaNro { get; set; }
        public Nullable<bool> Anulado { get; set; }
        public string AnuladoDescripcion
        {
            get
            {
                switch (this.Anulado)
                {
                    case true:
                        return "Anulado";
                    default:
                        return "Activo";
                }
            }
        }
        public Nullable<int> ClienteID { get; set; }
        public string ClienteNombre { get; set; }
        public Nullable<int> ClienteIdiomaID { get; set; }
        public string Direccion { get; set; }
        public string FacturaTipo { get; set; }
        public string FacturaTipoDescripcion
        {
            get
            {
                switch (this.FacturaTipo)
                {
                    case "C": 
                        return "Contado";
                    case "R": 
                        return "Crédito";
                    default:
                        return string.Empty;
                }

            }
        }
        public string RUC { get; set; }
        public string NroRemision { get; set; }
        public string Telefono { get; set; }
        public int MonedaID { get; set; }
        public string MonedaAbrev { get; set; }
        public string MonedaDescripcion { get; set; }
        public decimal TotalExentas { get; set; }
        public decimal TotalIVA5 { get; set; }
        public decimal TotalIVA10 { get; set; }
        public decimal TotalIVA { get; set; }
        public decimal LiqIVA5 { get; set; }
        public decimal LiqIVA10 { get; set; }
        public decimal TotalLiqIVA { get; set; }
        public decimal TotalFactura { get; set; }
        public string TotalLetras { get; set; }
        public string DocumentosAsociados { get; set; }
        public Nullable<int> UsuarioCargaID { get; set; }
        public string UsuarioCargaNombre { get; set; }
        public string AuditOperacion { get; set; }
        public Nullable<bool> TieneAutorizacionVigente { get; set; }
        public string CDC { get; set; }
        public Nullable<bool> DE { get; set; }
        public string Lote { get; set; }
        public string EstadoDE { get; set; }
        public Nullable<decimal> TipoCambio { get; set; }
        //Detalles
        public Nullable<decimal> Cantidad { get; set; }
        public string Descripcion { get; set; }
        public Nullable<decimal> PrecioUnitario { get; set; }
        public Nullable<decimal> Exentas { get; set; }
        public Nullable<decimal> CincoPorciento { get; set; }
        public Nullable<decimal> DiezPorciento { get; set; }
        public Nullable<int> PresupuestoCabID { get; set; }
        public string BoletaDepositoNro { get; set; }
        public Nullable<bool> CobroAnulado { get; set; }
        public Nullable<int> CobroID { get; set; }
        public string DescripcionFE { get; set; }
        //public Nullable<bool> CobroAnulado 
        //{ 
        //    get;
        //    set
        //    {
        //        if (value == null)
        //            this.CobroAnulado = false;
        //        else
        //            this.CobroAnulado = value;
        //    }
        //}
        //public bool CobroAnuladoProc
        //{
        //    get
        //    {
        //        if (!this.CobroAnulado.HasValue)
        //        {
        //            return false;
        //        }
        //        else
        //            return this.CobroAnulado.Value;
        //    }
        //}
    }

    public class FacturaCabType
    {
        public DateTime FacturaFecha { get; set; }
        public int FacturaCabeceraID { get; set; }
        public Nullable<int> FacturaTimbradoID { get; set; }
        public Nullable<bool> FacturaTimbradoHojaSuelta { get; set; }
        public string FacturaNro { get; set; }
        public Nullable<bool> Anulado { get; set; }
        public string AnuladoDescripcion
        {
            get
            {
                switch (this.Anulado)
                {
                    case true:
                        return "Anulado";
                    default:
                        return "Activo";
                }
            }
        }
        public Nullable<int> ClienteID { get; set; }
        public string ClienteNombre { get; set; }
        public Nullable<int> ClienteIdiomaID { get; set; }
        public string Direccion { get; set; }
        public string FacturaTipo { get; set; }
        public string FacturaTipoDescripcion
        {
            get
            {
                switch (this.FacturaTipo)
                {
                    case "C":
                        return "Contado";
                    case "R":
                        return "Crédito";
                    default:
                        return string.Empty;
                }

            }
        }
        public string RUC { get; set; }
        public string NroRemision { get; set; }
        public string Telefono { get; set; }
        public int MonedaID { get; set; }
        public string MonedaAbrev { get; set; }
        public string MonedaDescripcion { get; set; }
        public decimal TotalExentas { get; set; }
        public decimal TotalIVA5 { get; set; }
        public decimal TotalIVA10 { get; set; }
        public decimal TotalIVA { get; set; }
        public decimal LiqIVA5 { get; set; }
        public decimal LiqIVA10 { get; set; }
        public decimal TotalLiqIVA { get; set; }
        public decimal TotalFactura { get; set; }
        public string TotalLetras { get; set; }
        public string DocumentosAsociados { get; set; }
        public Nullable<int> UsuarioCargaID { get; set; }
        public string UsuarioCargaNombre { get; set; }
        public string AuditOperacion { get; set; }
        public string CDC { get; set; }
        public Nullable<bool> DE { get; set; }
        public string Lote { get; set; }
        public string EstadoDE { get; set; }
        public Nullable<decimal> TipoCambio { get; set; }
        public Nullable<bool> TieneAutorizacionVigente { get; set; }        
    }

    public class DetalleFacturaType
    {
        public Nullable<int> PresupuestoCabID { get; set; }
        public Nullable<int> FacturaCabID { get; set; }
        public string Descripcion { get; set; }
        public Nullable<decimal> Cantidad { get; set; }
        public Nullable<decimal> PrecioUnitario { get; set; }
        public Nullable<decimal> Exentas { get; set; }
        public Nullable<decimal> CincoPorciento { get; set; }
        public Nullable<decimal> DiezPorciento { get; set; }
        public string BoletaDepositoNro { get; set; }
        public Nullable<int> CobroID { get; set; }
        public string DescripcionFE { get; set; }
    }

    public class NotaCreditoAllType
    {
        public DateTime NotaCreditoFecha { get; set; }
        public int NotaCreditoCabeceraID { get; set; }
        public Nullable<int> NotaCreditoTimbradoID { get; set; }
        public Nullable<bool> NotaCreditoTimbradoHojaSuelta { get; set; }
        public string NotaCreditoNro { get; set; }
        public Nullable<bool> Anulado { get; set; }
        public string AnuladoDescripcion
        {
            get
            {
                switch (this.Anulado)
                {
                    case true:
                        return "Anulado";
                    default:
                        return "Activo";
                }
            }
        }
        public Nullable<int> ClienteID { get; set; }
        public string ClienteNombre { get; set; }
        public Nullable<int> ClienteIdiomaID { get; set; }
        public string Direccion { get; set; }
        public string NotaCreditoTipo { get; set; }
        public string NotaCreditoTipoDescripcion
        {
            get
            {
                switch (this.NotaCreditoTipo)
                {
                    case "C":
                        return "Contado";
                    case "R":
                        return "Crédito";
                    default:
                        return string.Empty;
                }

            }
        }
        public string RUC { get; set; }
        public string NroRemision { get; set; }
        public string Telefono { get; set; }
        public int MonedaID { get; set; }
        public string MonedaAbrev { get; set; }
        public string MonedaDescripcion { get; set; }
        public decimal TotalExentas { get; set; }
        public decimal TotalIVA5 { get; set; }
        public decimal TotalIVA10 { get; set; }
        public decimal TotalIVA { get; set; }
        public decimal LiqIVA5 { get; set; }
        public decimal LiqIVA10 { get; set; }
        public decimal TotalLiqIVA { get; set; }
        public decimal TotalNotaCredito { get; set; }
        public string TotalLetras { get; set; }
        public string DocumentosAsociados { get; set; }
        public Nullable<int> UsuarioCargaID { get; set; }
        public string UsuarioCargaNombre { get; set; }
        public string AuditOperacion { get; set; }
        public Nullable<bool> TieneAutorizacionVigente { get; set; }
        public string CDC { get; set; }
        public Nullable<bool> DE { get; set; }
        public string Lote { get; set; }
        public string EstadoDE { get; set; }
        public Nullable<decimal> TipoCambio { get; set; }
        public Nullable<int> FacturaCabId { get; set; }
        //Detalles
        public Nullable<decimal> Cantidad { get; set; }
        public string Descripcion { get; set; }
        public Nullable<decimal> PrecioUnitario { get; set; }
        public Nullable<decimal> Exentas { get; set; }
        public Nullable<decimal> CincoPorciento { get; set; }
        public Nullable<decimal> DiezPorciento { get; set; }
        public Nullable<int> PresupuestoCabID { get; set; }
        public string BoletaDepositoNro { get; set; }
        public Nullable<bool> CobroAnulado { get; set; }
        public Nullable<int> CobroID { get; set; }
        public string DescripcionFE { get; set; }
        public int MotivoEmisionID { get; set; }
        public string MotivoEmisionDescrip { get; set; }
        public string FacturaCDC { get; set; }
        public DateTime FacturaFecha { get; set; }
        public Nullable<long> FacturaNroTimbrado { get; set; }
        public bool? FacturaDE
        {
            set { facturaDE = value; }
            get { return facturaDE ?? false; }
        }

        private bool? facturaDE;
    }

    public class NotaCreditoCabType
    {
        public DateTime NotaCreditoFecha { get; set; }
        public int NotaCreditoCabeceraID { get; set; }
        public Nullable<int> NotaCreditoTimbradoID { get; set; }
        public Nullable<bool> NotaCreditoTimbradoHojaSuelta { get; set; }
        public string NotaCreditoNro { get; set; }
        public Nullable<bool> Anulado { get; set; }
        public string AnuladoDescripcion
        {
            get
            {
                switch (this.Anulado)
                {
                    case true:
                        return "Anulado";
                    default:
                        return "Activo";
                }
            }
        }
        public Nullable<int> ClienteID { get; set; }
        public string ClienteNombre { get; set; }
        public Nullable<int> ClienteIdiomaID { get; set; }
        public string Direccion { get; set; }
        public string NotaCreditoTipo { get; set; }
        public string NotaCreditoTipoDescripcion
        {
            get
            {
                switch (this.NotaCreditoTipo)
                {
                    case "C":
                        return "Contado";
                    case "R":
                        return "Crédito";
                    default:
                        return string.Empty;
                }

            }
        }
        public string RUC { get; set; }
        public string NroRemision { get; set; }
        public string Telefono { get; set; }
        public int MonedaID { get; set; }
        public string MonedaAbrev { get; set; }
        public string MonedaDescripcion { get; set; }
        public decimal TotalExentas { get; set; }
        public decimal TotalIVA5 { get; set; }
        public decimal TotalIVA10 { get; set; }
        public decimal TotalIVA { get; set; }
        public decimal LiqIVA5 { get; set; }
        public decimal LiqIVA10 { get; set; }
        public decimal TotalLiqIVA { get; set; }
        public decimal TotalNotaCredito { get; set; }
        public string TotalLetras { get; set; }
        public string DocumentosAsociados { get; set; }
        public Nullable<int> UsuarioCargaID { get; set; }
        public string UsuarioCargaNombre { get; set; }
        public string AuditOperacion { get; set; }
        public string CDC { get; set; }
        public Nullable<bool> DE { get; set; }
        public string Lote { get; set; }
        public string EstadoDE { get; set; }
        public Nullable<decimal> TipoCambio { get; set; }
        public Nullable<bool> TieneAutorizacionVigente { get; set; }
        public int MotivoEmisionID { get; set; }
        public string MotivoEmisionDescrip { get; set; }
        public Nullable<int> FacturaCabID { get; set; }
        public string FacturaCDC { get; set; }
        public DateTime FacturaFecha { get; set; }
        public Nullable<long> FacturaNroTimbrado { get; set; }
        public bool? FacturaDE
        {
            set { facturaDE = value; }
            get { return facturaDE ?? false; }
        }

        private bool? facturaDE;
    }

    public class DetalleNotaCreditoType
    {
        //public Nullable<int> PresupuestoCabID { get; set; }
        public Nullable<int> NotaCreditoCabID { get; set; }
        public string Descripcion { get; set; }
        public Nullable<decimal> Cantidad { get; set; }
        public Nullable<decimal> PrecioUnitario { get; set; }
        public Nullable<decimal> Exentas { get; set; }
        public Nullable<decimal> CincoPorciento { get; set; }
        public Nullable<decimal> DiezPorciento { get; set; }
        //public string BoletaDepositoNro { get; set; }
        //public Nullable<int> CobroID { get; set; }
        public string DescripcionFE { get; set; }
    }

    public class FacturaPatrixType
    {
        public string CaseNumber { get; set; }
        public int CaseID { get; set; }
        public int InvoiceID { get; set; }
        public decimal Monto { get; set; }
        public string MonedaAbrev { get; set; }
        public string ClienteNombre { get; set; }
        public DateTime FechaFactura { get; set; }
        public string FacturaFN { get; set; }
        public string FacturaPath { get; set; }
        public string Responsable { get; set; }
    }
}