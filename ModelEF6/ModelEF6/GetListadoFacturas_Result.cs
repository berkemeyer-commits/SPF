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
    
    public partial class GetListadoFacturas_Result
    {
        public System.DateTime FacturaFecha { get; set; }
        public int FacturaCabeceraID { get; set; }
        public Nullable<int> FacturaTimbradoID { get; set; }
        public bool FacturaTimbradoHojaSuelta { get; set; }
        public string FacturaNro { get; set; }
        public bool Anulado { get; set; }
        public Nullable<int> ClienteID { get; set; }
        public string ClienteNombre { get; set; }
        public Nullable<int> ClienteIdiomaID { get; set; }
        public string Direccion { get; set; }
        public string FacturaTipo { get; set; }
        public string RUC { get; set; }
        public string NroRemision { get; set; }
        public string Telefono { get; set; }
        public int MonedaID { get; set; }
        public string MonedaAbrev { get; set; }
        public string MonedaDescripcion { get; set; }
        public decimal TotalExentas { get; set; }
        public decimal TotalIVA5 { get; set; }
        public decimal TotalIVA10 { get; set; }
        public Nullable<decimal> TotalIVA { get; set; }
        public decimal LiqIVA5 { get; set; }
        public decimal LiqIVA10 { get; set; }
        public decimal TotalLiqIVA { get; set; }
        public decimal TotalFactura { get; set; }
        public string TotalLetras { get; set; }
        public string DocumentosAsociados { get; set; }
        public int UsuarioCargaID { get; set; }
        public string UsuarioCargaNombre { get; set; }
        public string AuditOperacion { get; set; }
        public string CDC { get; set; }
        public Nullable<bool> DE { get; set; }
        public string Lote { get; set; }
        public string EstadoDE { get; set; }
        public Nullable<decimal> TipoCambio { get; set; }
        public Nullable<bool> TieneAutorizacionVigente { get; set; }
        public decimal Cantidad { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Exentas { get; set; }
        public decimal CincoPorCiento { get; set; }
        public decimal DiezPorciento { get; set; }
        public int PresupuestoCabID { get; set; }
        public string BoletaDepositoNro { get; set; }
        public Nullable<int> CobroID { get; set; }
        public string DescripcionFE { get; set; }
    }
}
