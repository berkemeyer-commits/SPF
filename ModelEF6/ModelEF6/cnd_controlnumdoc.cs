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
    
    public partial class cnd_controlnumdoc
    {
        public int cnd_controlnumdocid { get; set; }
        public int cnd_tipodocumentoid { get; set; }
        public bool cnd_vigente { get; set; }
        public string cnd_serie { get; set; }
        public int cnd_ultnro { get; set; }
        public string cnd_timbrado { get; set; }
        public Nullable<System.DateTime> cnd_fechavigdesde { get; set; }
        public Nullable<System.DateTime> cnd_fechavighasta { get; set; }
    
        public virtual td_tipodocumento td_tipodocumento { get; set; }
    }
}
