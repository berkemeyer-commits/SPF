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
    
    public partial class ExpedienteXPoder
    {
        public int ID { get; set; }
        public Nullable<int> PoderID { get; set; }
        public Nullable<int> ExpedienteID { get; set; }
    
        public virtual Expediente Expediente { get; set; }
        public virtual Poder Poder { get; set; }
    }
}
