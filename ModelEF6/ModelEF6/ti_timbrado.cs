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
    
    public partial class ti_timbrado
    {
        public ti_timbrado()
        {
            this.nf_numeracionfactura = new ObservableListSource<nf_numeracionfactura>();
            this.su_serieusuario = new ObservableListSource<su_serieusuario>();
        }
    
        public int ti_timbradoid { get; set; }
        public System.DateTime ti_vigenciadesde { get; set; }
        public System.DateTime ti_vigenciahasta { get; set; }
        public long ti_numerodesde { get; set; }
        public long ti_numerohasta { get; set; }
        public bool ti_vigente { get; set; }
        public string ti_serie { get; set; }
        public string ti_sucursal { get; set; }
        public string ti_descripcion { get; set; }
        public Nullable<long> ti_nrotimbrado { get; set; }
        public bool ti_facthojasuelta { get; set; }
        public int ti_tipodocumentoid { get; set; }
    
        public virtual ObservableListSource<nf_numeracionfactura> nf_numeracionfactura { get; set; }
        public virtual ObservableListSource<su_serieusuario> su_serieusuario { get; set; }
        public virtual td_tipodocumento td_tipodocumento { get; set; }
    }
}