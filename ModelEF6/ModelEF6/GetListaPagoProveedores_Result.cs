//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ModelEF6
{
    using System;
    
    public partial class GetListaPagoProveedores_Result
    {
        public int PagoProveedorID { get; set; }
        public Nullable<int> SolicitudPagoCabID { get; set; }
        public string Origen { get; set; }
        public Nullable<int> ProveedorID { get; set; }
        public string ProveedorNombre { get; set; }
        public string ProveedorNroFactura { get; set; }
        public Nullable<System.DateTime> ProveedorFecFactura { get; set; }
        public int MonedaID { get; set; }
        public string MonedaDescrip { get; set; }
        public string MonedaAbrev { get; set; }
        public System.DateTime FechaPago { get; set; }
        public int FormaPagoID { get; set; }
        public string FormaPagoNombre { get; set; }
        public Nullable<System.DateTime> FechaBoletaDep { get; set; }
        public Nullable<int> BancoDepID { get; set; }
        public string BancoDepNombre { get; set; }
        public Nullable<int> CtaDepID { get; set; }
        public string CtaDepNombre { get; set; }
        public string NroTransaccion { get; set; }
        public string CodReferencia { get; set; }
        public Nullable<System.DateTime> FechaCheque { get; set; }
        public Nullable<int> BancoCheqID { get; set; }
        public string BancoCheqNombre { get; set; }
        public Nullable<int> CtaCheqID { get; set; }
        public string CtaCheqNombre { get; set; }
        public string CtaCheqNro { get; set; }
        public string MonedaCtaCheq { get; set; }
        public string ChequeNro { get; set; }
        public string NroRecibo { get; set; }
        public Nullable<System.DateTime> FechaRecibo { get; set; }
        public string NotaCreditoNro { get; set; }
        public Nullable<System.DateTime> FechaNotaCredito { get; set; }
        public decimal MontoPago { get; set; }
        public Nullable<decimal> Saldo { get; set; }
        public Nullable<decimal> SaldoTotal { get; set; }
        public string ReferenciaPago { get; set; }
        public Nullable<bool> TieneAutorizacionVigente { get; set; }
        public string DocumentosID { get; set; }
        public string DocumentosInfo { get; set; }
        public int UsuarioGeneracionID { get; set; }
        public string UsuarioGeneracionNombre { get; set; }
        public Nullable<System.DateTime> FechaCarga { get; set; }
        public bool Anulado { get; set; }
    }
}
