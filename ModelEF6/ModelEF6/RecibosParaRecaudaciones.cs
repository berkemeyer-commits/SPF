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
    
    public partial class RecibosParaRecaudaciones
    {
        public int ReciboId { get; set; }
        public string NroRecibo { get; set; }
        public System.DateTime FechaRecibo { get; set; }
        public string ClienteNombre { get; set; }
        public int MonedaId { get; set; }
        public string MonedaAbrev { get; set; }
        public decimal TotalRecibo { get; set; }
        public decimal TotalEfectivo { get; set; }
        public decimal TotalCheque { get; set; }
        public Nullable<System.DateTime> FechaDeposito { get; set; }
        public string NroBoleta { get; set; }
        public Nullable<int> CtaBancariaId { get; set; }
        public string CtaBancariaDescrip { get; set; }
        public Nullable<decimal> MontoDeposito { get; set; }
        public Nullable<int> UsuarioCargaId { get; set; }
        public string UsuarioCargaNombre { get; set; }
        public Nullable<decimal> MontoDepositable { get; set; }
        public int ClienteId { get; set; }
        public string CtaBancariaNro { get; set; }
        public Nullable<int> DepositoRecaudacionId { get; set; }
    }
}
