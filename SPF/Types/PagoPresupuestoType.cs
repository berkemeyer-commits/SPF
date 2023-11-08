using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPF.Types
{
    public class PagoPresupuestoType
    {
        public int PagoPresupuestoID { get; set; }
        public int PresupuestoCabID { get; set; }
        public DateTime FechaPago { get; set; }
        public int MonedaID { get; set; }
        public string MonedaDescrip { get; set; }
        public string MonedaSimbolo { get; set; }
        public Nullable<int> BancoDepID { get; set; }
        public string BancoNombre { get; set; }
        public Nullable<int> CuentaDepID { get; set; }
        public string CuentaDepNombre { get; set; }
        public int FormaPagoID { get; set; }
        public string FormaPagoDescrip { get; set; }
        public string ChequeNro { get; set; }
        public Nullable<int> BancoChequeID { get; set; }
        public string BancoChequeNombre { get; set; }
        public Nullable<int> MonedaGastoID { get; set; }
        public string MonedaGastoDescrip { get; set; }
        public Nullable<decimal> GastoBancario { get; set; }
        public decimal MontoPago { get; set; }
        public string Referencia { get; set; }
        public Nullable<DateTime> FechaBoletaDep { get; set; }
        public string BoletaDepNro { get; set; }
        public string NroPresupuesto { get; set; }
        public string NroRecibo { get; set; }
        public Nullable<DateTime> FechaRecibo { get; set; }
        public string TramiteDescripcion { get; set; }
        public int ClienteID { get; set; }
        public string ClienteNombre { get; set; }
        public Nullable<Boolean> Anulado { get; set; }
        public decimal Saldo { get; set; }
        public string FacturaNro { get; set; }
        public Nullable<DateTime> FechaNotaCredito { get; set; }
        public string NroNotaCredito { get; set; }
        public Nullable<int> PagoMultipleID { get; set; }
        public Nullable<Boolean> TieneAutorizacionVigente { get; set; }
        public Nullable<int> IDNotaCredito { get; set; }
        public string RefNotaCredito { get; set; }
        public string CuerpoNotaCredito { get; set; }
        public Nullable<int> RespCobroExtID { get; set; }
        public string RespCobroExtNombre { get; set; }
        public Nullable<int> UsuarioCargaID { get; set; }
        public string UsuarioCargaNombre { get; set; }
        public string AuditOperacion { get; set; }
    }

    public class CobrosType
    {
        //public Nullable<Boolean> Seleccionar { get; set; }
        public int CobroID { get; set; }
        public DateTime FechaCobro { get; set; }
        public int ClienteID { get; set; }
        public string ClienteNombre { get; set; }
        public int FormaPagoID { get; set; }
        public string FormaPagoDescrip { get; set; }
        public Nullable<int> BancoChequeID { get; set; }
        public string BancoChequeDescrip { get; set; }
        public string ChequeNro { get; set; }
        public decimal MontoCobro { get; set; }
        public string MonedaAbrev { get; set; }
    }
}