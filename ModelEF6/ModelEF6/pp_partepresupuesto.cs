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
    
    public partial class pp_partepresupuesto
    {
        public int pp_partepresupuestoid { get; set; }
        public int pp_tramiteid { get; set; }
        public string pp_descripcionserviciosesp { get; set; }
        public string pp_descripciongastosing { get; set; }
        public string pp_descripcionserviciosing { get; set; }
        public string pp_descripciongastosesp { get; set; }
    
        public virtual Tramite Tramite { get; set; }
    }
}