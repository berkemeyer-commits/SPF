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
    
    public partial class GetListaPagosPendientes_Result
    {
        public Nullable<int> ProveedorID { get; set; }
        public string ProveedorNombre { get; set; }
        public string NroFactura { get; set; }
        public Nullable<System.DateTime> FechaFactura { get; set; }
        public int MonedaID { get; set; }
        public string MonedaAbrev { get; set; }
        public string MonedaDescrip { get; set; }
        public Nullable<decimal> TotalFactura { get; set; }
        public string Rango { get; set; }
    }
}
