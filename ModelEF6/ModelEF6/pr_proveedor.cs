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
    
    public partial class pr_proveedor
    {
        public pr_proveedor()
        {
            this.ps_pagosolicitud = new ObservableListSource<ps_pagosolicitud>();
            this.spac_solicitudpagoarchivocab = new ObservableListSource<spac_solicitudpagoarchivocab>();
        }
    
        public int pr_proveedorid { get; set; }
        public string pr_nombre { get; set; }
        public string pr_direccion { get; set; }
        public string pr_ruc { get; set; }
        public string pr_personeria { get; set; }
        public string pr_obs { get; set; }
        public Nullable<int> pr_idiomaid { get; set; }
        public Nullable<int> pr_paisid { get; set; }
        public Nullable<bool> pr_activo { get; set; }
        public Nullable<int> pr_ciudadid { get; set; }
        public string pr_telefono { get; set; }
        public Nullable<int> pr_ddi { get; set; }
        public Nullable<bool> pr_publico { get; set; }
    
        public virtual CCiudad CCiudad { get; set; }
        public virtual CIdioma CIdioma { get; set; }
        public virtual ObservableListSource<ps_pagosolicitud> ps_pagosolicitud { get; set; }
        public virtual ObservableListSource<spac_solicitudpagoarchivocab> spac_solicitudpagoarchivocab { get; set; }
        public virtual CPais CPais { get; set; }
    }
}
