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
    
    public partial class CArea
    {
        public CArea()
        {
            this.ac_areacontabilidad = new ObservableListSource<ac_areacontabilidad>();
            this.Usuario = new ObservableListSource<Usuario>();
        }
    
        public int idarea { get; set; }
        public int idestado { get; set; }
        public string descrip { get; set; }
        public string abrev { get; set; }
        public Nullable<bool> nuestra { get; set; }
        public string patharea { get; set; }
        public string portal { get; set; }
        public string emaildistrib { get; set; }
    
        public virtual ObservableListSource<ac_areacontabilidad> ac_areacontabilidad { get; set; }
        public virtual ObservableListSource<Usuario> Usuario { get; set; }
    }
}
