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
    
    public partial class RepOrdenPagoxID_Result
    {
        public int PagoProveedorID { get; set; }
        public System.DateTime FechaPago { get; set; }
        public string NombreProveedor { get; set; }
        public string MonedaDescrip { get; set; }
        public string CuentaCheqNro { get; set; }
        public string BancoCheque { get; set; }
        public string NroCheque { get; set; }
        public decimal MontoPago { get; set; }
        public string MontoLetras { get; set; }
        public string NroFactura { get; set; }
        public string UsuarioGeneracionNombre { get; set; }
        public string Concepto { get; set; }
        public Nullable<System.DateTime> FechaTransferencia { get; set; }
        public Nullable<int> BancoIdTransferencia { get; set; }
        public string BancoDescripTransferencia { get; set; }
        public Nullable<int> CuentaBancoIdTransferencia { get; set; }
        public string CuentaBancoDesripTransferencia { get; set; }
        public string CuentaNroTransferencia { get; set; }
        public string NroTransaccionTransferencia { get; set; }
        public string CodReferenciaTransferencia { get; set; }
        public Nullable<System.DateTime> FechaRecibo { get; set; }
        public string NroRecibo { get; set; }
    }
}
