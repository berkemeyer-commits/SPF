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
    
    public partial class AtencionXVia
    {
        public int ID { get; set; }
        public int AtencionID { get; set; }
        public int ViaID { get; set; }
        public string Descrip { get; set; }
    
        public virtual Atencion Atencion { get; set; }
    }
}
