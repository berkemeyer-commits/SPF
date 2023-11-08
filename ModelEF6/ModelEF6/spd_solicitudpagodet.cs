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
    
    public partial class spd_solicitudpagodet
    {
        public spd_solicitudpagodet()
        {
            this.sed_solexclusiondet = new ObservableListSource<sed_solexclusiondet>();
        }
    
        public int spd_solicitudpagodetid { get; set; }
        public int spd_solicitudpagocabid { get; set; }
        public int spd_tarifaid { get; set; }
        public decimal spd_cantidad { get; set; }
        public bool spd_tipounidaddesc { get; set; }
        public decimal spd_descuentomonto { get; set; }
        public decimal spd_descuentoporcentaje { get; set; }
        public bool spd_tipounidadimp { get; set; }
        public decimal spd_impuestomonto { get; set; }
        public decimal spd_impuestoporcentaje { get; set; }
        public decimal spd_precioventa { get; set; }
        public decimal spd_preciocosto { get; set; }
        public decimal spd_exentas { get; set; }
        public decimal spd_iva5 { get; set; }
        public decimal spd_iva10 { get; set; }
        public decimal spd_total { get; set; }
        public Nullable<decimal> spd_recargoneto { get; set; }
        public Nullable<decimal> spd_totalconrecargo { get; set; }
        public Nullable<int> spd_proveedorid { get; set; }
        public string spd_nrofactura { get; set; }
        public bool spd_facturable { get; set; }
        public bool spd_reembolsable { get; set; }
        public int spd_solicitadopor { get; set; }
        public Nullable<int> spd_correspondenciaid { get; set; }
        public System.DateTime spd_fechasol { get; set; }
        public decimal spd_saldo { get; set; }
        public Nullable<System.DateTime> spd_fechafactura { get; set; }
        public decimal spd_cantidadiva10 { get; set; }
        public decimal spd_precunitiva10 { get; set; }
        public decimal spd_cantidadiva5 { get; set; }
        public decimal spd_precunitiva5 { get; set; }
        public Nullable<int> spd_tipofacturaid { get; set; }
        public Nullable<bool> spd_excluir { get; set; }
    
        public virtual Correspondencia Correspondencia { get; set; }
        public virtual ObservableListSource<sed_solexclusiondet> sed_solexclusiondet { get; set; }
        public virtual spc_solicitudpagocab spc_solicitudpagocab { get; set; }
        public virtual spd_solicitudpagodet spd_solicitudpagodet1 { get; set; }
        public virtual spd_solicitudpagodet spd_solicitudpagodet2 { get; set; }
        public virtual spd_solicitudpagodet spd_solicitudpagodet11 { get; set; }
        public virtual spd_solicitudpagodet spd_solicitudpagodet3 { get; set; }
        public virtual spd_solicitudpagodet spd_solicitudpagodet12 { get; set; }
        public virtual spd_solicitudpagodet spd_solicitudpagodet4 { get; set; }
        public virtual Tarifas Tarifas { get; set; }
        public virtual tf_tipofactura tf_tipofactura { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}