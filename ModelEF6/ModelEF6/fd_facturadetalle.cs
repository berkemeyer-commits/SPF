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
    
    public partial class fd_facturadetalle
    {
        public int fd_facturadetalleid { get; set; }
        public int fd_facturacabeceraid { get; set; }
        public decimal fd_cantidad { get; set; }
        public string fd_descripcion { get; set; }
        public decimal fd_preciounitario { get; set; }
        public decimal fd_exentas { get; set; }
        public decimal fd_cincoporciento { get; set; }
        public decimal fd_diezporciento { get; set; }
        public int fd_presupuestocabid { get; set; }
        public string fd_nroboletadeposito { get; set; }
        public Nullable<int> fd_cobroid { get; set; }
        public string fd_descripFE { get; set; }
    
        public virtual fc_facturacabecera fc_facturacabecera { get; set; }
        public virtual pc_presupuestocab pc_presupuestocab { get; set; }
    }
}
