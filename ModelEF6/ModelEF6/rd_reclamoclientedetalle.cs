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
    
    public partial class rd_reclamoclientedetalle
    {
        public int rd_reclamoclientedetalle1 { get; set; }
        public int rd_reclamoclientecabid { get; set; }
        public int rd_presupuestocabid { get; set; }
        public decimal rd_saldo { get; set; }
        public Nullable<System.DateTime> rd_fecharereclamo { get; set; }
    
        public virtual rc_reclamocliente rc_reclamocliente { get; set; }
    }
}
