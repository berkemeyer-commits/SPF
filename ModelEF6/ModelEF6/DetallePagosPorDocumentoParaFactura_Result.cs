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
    
    public partial class DetallePagosPorDocumentoParaFactura_Result
    {
        public int ClienteID { get; set; }
        public int PresupuestoCabID { get; set; }
        public string Origen { get; set; }
        public int TramiteID { get; set; }
        public string Descripcion { get; set; }
        public string DocumentoNro { get; set; }
        public string FechaPago { get; set; }
        public Nullable<int> PagoID { get; set; }
        public Nullable<decimal> MontoPago { get; set; }
        public decimal Saldo { get; set; }
        public string ClienteNombre { get; set; }
        public Nullable<int> ClienteIdiomaID { get; set; }
        public string PaísCliente { get; set; }
        public string Correo { get; set; }
        public int MonedadID { get; set; }
        public string MonedaDescrip { get; set; }
        public string MonedaAbrev { get; set; }
        public Nullable<int> FormaPagoID { get; set; }
        public string FormaPagoDescrip { get; set; }
        public string TramiteDescrip { get; set; }
        public Nullable<int> BancoDepositoID { get; set; }
        public string BancoDepositoDescripcion { get; set; }
        public Nullable<System.DateTime> FechaBoletaDeposito { get; set; }
        public string NroBoletaDeposito { get; set; }
    }
}
