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
    
    public partial class tc_tarifascliente
    {
        public int tc_id { get; set; }
        public int tc_clienteid { get; set; }
        public System.DateTime tc_fecha { get; set; }
        public int tc_tarifaid { get; set; }
        public decimal tc_monto { get; set; }
        public string tc_observacion { get; set; }
        public Nullable<int> tc_tarifadocid { get; set; }
        public bool tc_tipounidaddesc { get; set; }
        public decimal tc_descuentomonto { get; set; }
        public decimal tc_descuentoporcentaje { get; set; }
        public bool tc_tipounidadimp { get; set; }
        public decimal tc_impuestomonto { get; set; }
        public decimal tc_impuestoporcentaje { get; set; }
        public Nullable<int> tc_expedienteid { get; set; }
        public Nullable<int> tc_tramiteid { get; set; }
        public decimal tc_cantidad { get; set; }
        public decimal tc_total { get; set; }
        public decimal tc_precioventa { get; set; }
        public bool tc_especial { get; set; }
        public Nullable<int> tc_monedaid { get; set; }
        public Nullable<int> tc_cotizacioncabid { get; set; }
        public Nullable<decimal> tc_recargoneto { get; set; }
        public Nullable<decimal> tc_totalconrecargo { get; set; }
    
        public virtual Tarifas Tarifas { get; set; }
        public virtual cc_cotizacioncab cc_cotizacioncab { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Tramite Tramite { get; set; }
        public virtual Moneda Moneda { get; set; }
    }
}
