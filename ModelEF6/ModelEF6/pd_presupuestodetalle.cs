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
    
    public partial class pd_presupuestodetalle
    {
        public int pd_presupuestodetalleid { get; set; }
        public int pd_presupuestocabid { get; set; }
        public string pd_detalledescripcion { get; set; }
        public decimal pd_detallemonto { get; set; }
    
        public virtual pc_presupuestocab pc_presupuestocab { get; set; }
    }
}
