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
    
    public partial class CPais
    {
        public CPais()
        {
            this.ba_banco = new ObservableListSource<ba_banco>();
            this.CCiudad = new ObservableListSource<CCiudad>();
            this.pr_proveedor = new ObservableListSource<pr_proveedor>();
            this.Propietario = new ObservableListSource<Propietario>();
            this.Moneda = new ObservableListSource<Moneda>();
        }
    
        public int idpais { get; set; }
        public string paisalfa { get; set; }
        public string descrip { get; set; }
        public string paistel { get; set; }
        public string idbanco { get; set; }
        public string abrev { get; set; }
        public Nullable<int> continenteid { get; set; }
        public string paisalfa3 { get; set; }
        public string descripFE { get; set; }
    
        public virtual ObservableListSource<ba_banco> ba_banco { get; set; }
        public virtual ObservableListSource<CCiudad> CCiudad { get; set; }
        public virtual co_continente co_continente { get; set; }
        public virtual ObservableListSource<pr_proveedor> pr_proveedor { get; set; }
        public virtual ObservableListSource<Propietario> Propietario { get; set; }
        public virtual ObservableListSource<Moneda> Moneda { get; set; }
    }
}
