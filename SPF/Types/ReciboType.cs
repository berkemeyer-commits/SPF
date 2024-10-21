using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ModelEF6;

namespace SPF.Types
{
    public class ReciboFacturasType
    {
        public int ID { get; set; }
        public string NroFactura { get; set; }
        public string Importe { get; set; }
    }

    public class ReciboRetencionesType
    {
        //public string NroRetencion { get; set; }
        public string ImporteRetencion { get; set; }
    }

    public class FormatoNumeroReciboType
    {
        public string General { get; set; }
        public string Grilla { get; set; }
    }

    public class DatosReciboType
    {
        public string AbrevMoneda { get; set; }
        public string TotalRecibo { get; set; }
        public string ClienteNombre { get; set; }
        public string RUC { get; set; }
        public string DescripMoneda { get; set; }
        public string TotalLetras { get; set; }
        public string Concepto { get; set; }
        public string Efectivo { get; set; }
        public bool Cheque { get; set; }
        public string FechaRecibo { get; set; }
        public string ElaboradoPor { get; set; }
        public string NroRecibo { get; set; }
        public Nullable<bool> ImprimirReciboSimple { get; set; }
        public bool Anulado { get; set; }
    }

    public class DatosTransferenciaReciboType
    {
        public string FechaTransferencia { get; set; }
        public int BancoTransferenciaId { get; set; }
        public string BancoTransferenciaDescrip { get; set; }
        public string NumeroTransferencia { get; set; }
        public decimal MontoGastoBancario { get; set; }
        public decimal MontoTransferencia { get; set; }
        public int MonedaTransferenciaId { get; set; }
        public string MonedaTransferenciaAbrev { get; set; }
        public Nullable<int> PaisId { get; set; }
        public Nullable<int> ReciboId { get; set; }
    }

    public class DatosChequeReciboType
    {
        public string FechaCheque { get; set; }
        public int BancoChequeId { get; set; }
        public string BancoChequeDescrip { get; set; }
        public string NumeroCheque { get; set; }
        public decimal MontoCheque { get; set; }
        public int MonedaChequeId { get; set; }
        public string MonedaChequeAbrev { get; set; }
        public Nullable<int> ReciboId { get; set; }
    }

    public class FacturaRetencionConsultaType
    {
        public string NroFactura { get; set; }
        public DateTime FechaFactura { get; set; }
        public decimal TotalFactura { get; set; }
        public decimal MontoPagadoFactura { get; set; }
        public string NumeroRetencion { get; set; }
        public Nullable<DateTime> FechaRetencion { get; set; }
        public Nullable<int> ReciboId { get; set; }
        public Nullable<decimal> MontoRetencionIVA10 { get; set; }
        public Nullable<decimal> MontoRetencionRenta { get; set; }
        public string RUC { get; set; }
        //public string FechaFacturaString
        //{
        //    get { return FechaFactura.ToShortDateString(); }
        //}
        //public string FechaRetencionString
        //{
        //    get { return FechaRetencion.HasValue ? FechaRetencion.Value.ToShortDateString() : string.Empty; }
        //}
    }


    public class DatosCuentaBancaria
    {
        public int CuentaBancariaId { get; set; }
        public string NroCuentaBancaria { get; set; }
        public string CuentaBancariaDescrip { get; set; }
        public int MonedaIdCuentaBancaria { get; set; }
        public string MonedaAbrevCuentaBancaria {get; set;}
        public string MonedaDescripCuentaBancaria { get; set; }
        public int BancoId { get; set; }
        public string BancoDescrip { get; set; }
        public Nullable<bool> MostrarCuenta { get; set; }
        public Nullable<int> PaisId { get; set; }
    }

    public class DatosTransfenciaReciboReporte
    {
        public int ID { get; set; }
        public string FechaTransferencia { get; set;}
        public string BancoTransferencia {get; set; }
        public string NroTransferencia { get; set; }
        public string MontoTransferencia { get; set; }
    }

    public class DatosChequeReciboReporte
    {
        public int ID { get; set; }
        public string FechaCheque { get; set; }
        public string CargoBancoCheque { get; set; }
        public string NroCheque { get; set; }
        public string MontoCheque { get; set; }
    }

    public class MontosTransferencia
    {
        public decimal TotalTransferencia { get; set; }
        public decimal TotalGastosBancarios { get; set; }
    }

    public class BancoCheque
    {
        public int BancoID { get; set; }
        public string BancoDescripcion { get; set; }
        public Nullable<bool> Mostrar { get; set; }
    }

    public class FacturasParaRetenciones
    {
        public int FacturaCabId { get; set; }
        public Nullable<int> TimbradoId { get; set; }
        public System.DateTime FechaFactura { get; set; }
        public string NroFactura { get; set; }
        public Nullable<int> ClienteId { get; set; }
        public string ClienteNombre { get; set; }
        public string TipoFacturaDescrip { get; set; }
        public string RUC { get; set; }
        public Nullable<bool> EsDocumentoElectronico { get; set; }
        public int MonedaId { get; set; }
        public string MonedaAbrev { get; set; }
        public decimal TotalExentas { get; set; }
        public decimal TotalIVA5 { get; set; }
        public decimal TotalIVA10 { get; set; }
        public decimal LiqIVA5 { get; set; }
        public decimal LiqIVA10 { get; set; }
        public decimal TotalIVA { get; set; }
        public decimal Total { get; set; }
        public string DocumentosAsociados { get; set; }
        public Nullable<decimal> Saldo { get; set; }
        public Nullable<decimal> ImporteCobrado { get; set; }
        public string CDC { get; set; }
        public string TipoDocumento { get; set; }
        public string EstadoDE { get; set; }
        public int IdParaOrden { get; set; }
        public Nullable<int> FacturaCabIdRel { get; set; }
        public string MonedaDescrip { get; set; }
        public int FacturaPresupuestoCabId { get; set; }

        public string NroRetencion { get; set; }
        public string FechaRetencion { get; set; }
        public decimal NCLiqIVA5 { get; set; }
        public decimal NCLiqIVA10 { get; set; }
        public decimal RetencionIVA5 { get; set; }
        public decimal RetencionIVA10 { get; set; }
        public decimal RetencionRenta { get; set; }
    }

    public class FacturasSeleeccionadasRetencion
    {
        public int Ix { get; set; }
        public string FechaRetencion { get; set; }
        public string NumeroRetencion { get; set; }
    }

    public class DocumentosAsociadosType
    {
        public string NroDocumento { get; set; }
        public Nullable<DateTime> FechaDocumento { get; set; }
        public string Servicios { get; set; }
        public decimal TotalDocumento { get; set; }
        public decimal SaldoDocumento { get; set; }
        public string TramiteDescrip { get; set; }
        public string AreaDescrip { get; set; }
        public Nullable<int> ReciboId { get; set; }
    }

    public class DatosRecaudacionesType
    {
        public int ReciboId { get; set; }
        public string NroRecibo { get; set; }
        public DateTime FechaRecibo { get; set; }
        public int ClienteId { get; set; }
        public string ClienteNombre { get; set; }
        public int MonedaId { get; set; }
        public string MonedaAbrev { get; set; }
        public decimal TotalRecibo { get; set; }
        public decimal TotalEfectivo { get; set; }
        public decimal TotalCheque { get; set; }
        public Nullable<int> DepositoRecaudacionId { get; set; }
        public Nullable<DateTime> FechaDeposito { get; set; }
        public string NroBoleta { get; set; }
        public Nullable<int> CtaBancariaId { get; set; }
        public string CtaBancariaDescrip { get; set; }
        public string CtaBancariaNro { get; set; }
        public Nullable<decimal> MontoDeposito { get; set; }
        public Nullable<int> UsuarioCargaId { get; set; }
        public string UsuarioCargaNombre { get; set; }
        public Nullable<decimal> MontoDepositable { get; set; } 
    }
}