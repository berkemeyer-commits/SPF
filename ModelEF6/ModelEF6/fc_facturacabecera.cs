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
    
    public partial class fc_facturacabecera
    {
        public fc_facturacabecera()
        {
            this.fpc_facturapresupuestocab = new ObservableListSource<fpc_facturapresupuestocab>();
            this.pc_presupuestocab = new ObservableListSource<pc_presupuestocab>();
            this.fd_facturadetalle = new ObservableListSource<fd_facturadetalle>();
            this.nc_notacreditocabecera = new ObservableListSource<nc_notacreditocabecera>();
            this.rf_recibofactura = new ObservableListSource<rf_recibofactura>();
            this.rr_reciboretencion = new ObservableListSource<rr_reciboretencion>();
        }
    
        public int fc_facturacabeceraid { get; set; }
        public Nullable<int> fc_timbradoid { get; set; }
        public System.DateTime fc_fechafactura { get; set; }
        public string fc_nrofactura { get; set; }
        public bool fc_anulado { get; set; }
        public Nullable<int> fc_clienteid { get; set; }
        public string fc_clientenombre { get; set; }
        public string fc_direccion { get; set; }
        public string fc_tipofactura { get; set; }
        public string fc_ruc { get; set; }
        public string fc_nroremision { get; set; }
        public string fc_telefono { get; set; }
        public int fc_monedaid { get; set; }
        public decimal fc_totalexentas { get; set; }
        public decimal fc_totaliva5 { get; set; }
        public decimal fc_totaliva10 { get; set; }
        public decimal fc_liqiva5 { get; set; }
        public decimal fc_liqiva10 { get; set; }
        public decimal fc_totaliva { get; set; }
        public decimal fc_total { get; set; }
        public string fc_totalletras { get; set; }
        public string fc_documentosasoc { get; set; }
        public Nullable<System.DateTime> fc_fechaanulacion { get; set; }
        public string fc_usuarioanulacion { get; set; }
        public string fc_cdc { get; set; }
        public Nullable<bool> fc_documentoelectronico { get; set; }
        public string fc_lote { get; set; }
        public string fc_estadode { get; set; }
        public Nullable<decimal> fc_tipocambio { get; set; }
        public string fc_motivorechazo { get; set; }
    
        public virtual ObservableListSource<fpc_facturapresupuestocab> fpc_facturapresupuestocab { get; set; }
        public virtual ObservableListSource<pc_presupuestocab> pc_presupuestocab { get; set; }
        public virtual ObservableListSource<fd_facturadetalle> fd_facturadetalle { get; set; }
        public virtual ObservableListSource<nc_notacreditocabecera> nc_notacreditocabecera { get; set; }
        public virtual ObservableListSource<rf_recibofactura> rf_recibofactura { get; set; }
        public virtual ObservableListSource<rr_reciboretencion> rr_reciboretencion { get; set; }
    }
}
