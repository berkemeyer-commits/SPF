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
    using System.Collections.Generic;
    
    public partial class rf_recibofactura
    {
        public int rf_recibofacturaid { get; set; }
        public int rf_facturacabid { get; set; }
        public int rf_reciboid { get; set; }
        public decimal rf_montopagado { get; set; }
    
        public virtual fc_facturacabecera fc_facturacabecera { get; set; }
        public virtual re_recibo re_recibo { get; set; }
    }
}
