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
    
    public partial class Audit_nc_notacreditocabecera
    {
        public int nc_notacreditocabeceraid { get; set; }
        public Nullable<int> nc_timbradoid { get; set; }
        public Nullable<System.DateTime> nc_fechanotacredito { get; set; }
        public string nc_nronotacredito { get; set; }
        public Nullable<bool> nc_anulado { get; set; }
        public Nullable<int> nc_clienteid { get; set; }
        public string nc_clientenombre { get; set; }
        public string nc_direccion { get; set; }
        public string nc_tiponotacredito { get; set; }
        public string nc_ruc { get; set; }
        public string nc_nroremision { get; set; }
        public string nc_telefono { get; set; }
        public Nullable<int> nc_monedaid { get; set; }
        public Nullable<decimal> nc_totalexentas { get; set; }
        public Nullable<decimal> nc_totaliva5 { get; set; }
        public Nullable<decimal> nc_totaliva10 { get; set; }
        public Nullable<decimal> nc_liqiva5 { get; set; }
        public Nullable<decimal> nc_liqiva10 { get; set; }
        public Nullable<decimal> nc_totaliva { get; set; }
        public Nullable<decimal> nc_total { get; set; }
        public string nc_totalletras { get; set; }
        public string nc_documentosasoc { get; set; }
        public Nullable<System.DateTime> nc_fechaanulacion { get; set; }
        public string nc_usuarioanulacion { get; set; }
        public string nc_cdc { get; set; }
        public Nullable<bool> nc_documentoelectronico { get; set; }
        public string nc_lote { get; set; }
        public string nc_estadode { get; set; }
        public Nullable<decimal> nc_tipocambio { get; set; }
        public Nullable<int> nc_motivoemisionid { get; set; }
        public string nc_motivorechazo { get; set; }
        public string Audit_User { get; set; }
        public System.DateTime Audit_Fecha { get; set; }
        public string Audit_Operacion { get; set; }
        public Nullable<int> nc_facturacabid { get; set; }
    }
}
