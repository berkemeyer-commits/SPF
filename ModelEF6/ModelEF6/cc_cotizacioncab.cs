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
    
    public partial class cc_cotizacioncab
    {
        public cc_cotizacioncab()
        {
            this.ca_clienteantecedente = new ObservableListSource<ca_clienteantecedente>();
            this.cp_cotizacionesxpresup = new ObservableListSource<cp_cotizacionesxpresup>();
            this.tc_tarifascliente = new ObservableListSource<tc_tarifascliente>();
        }
    
        public int cc_cotizacioncabid { get; set; }
        public Nullable<int> cc_expedienteid { get; set; }
        public Nullable<System.DateTime> cc_fecha { get; set; }
        public Nullable<int> cc_aprobadopor { get; set; }
        public Nullable<int> cc_solicitadopor { get; set; }
        public Nullable<bool> cc_confirmado { get; set; }
        public string cc_observacion { get; set; }
        public Nullable<bool> cc_esduplicado { get; set; }
        public Nullable<int> cc_recargoatmonedaid { get; set; }
        public Nullable<decimal> cc_recargoatmonto { get; set; }
    
        public virtual ObservableListSource<ca_clienteantecedente> ca_clienteantecedente { get; set; }
        public virtual ObservableListSource<cp_cotizacionesxpresup> cp_cotizacionesxpresup { get; set; }
        public virtual ObservableListSource<tc_tarifascliente> tc_tarifascliente { get; set; }
        public virtual Moneda Moneda { get; set; }
    }
}