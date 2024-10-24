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
    
    public partial class Marca
    {
        public Marca()
        {
            this.Expediente = new ObservableListSource<Expediente>();
        }
    
        public int ID { get; set; }
        public string Denominacion { get; set; }
        public string DenominacionClave { get; set; }
        public string Fonetizada { get; set; }
        public int MarcaTipoID { get; set; }
        public int ClaseID { get; set; }
        public string ClaseDescripEsp { get; set; }
        public Nullable<bool> Limitada { get; set; }
        public Nullable<int> ClienteID { get; set; }
        public Nullable<int> AgenteLocalID { get; set; }
        public bool Nuestra { get; set; }
        public bool Vigilada { get; set; }
        public bool Sustituida { get; set; }
        public bool StandBy { get; set; }
        public Nullable<bool> Vigente { get; set; }
        public Nullable<int> LogotipoID { get; set; }
        public Nullable<int> ExpedienteVigenteID { get; set; }
        public bool OtrosClientes { get; set; }
        public Nullable<int> MarcaRegRenID { get; set; }
        public Nullable<int> MarcaRegRenAnt { get; set; }
        public string Propietario { get; set; }
        public string ProDir { get; set; }
        public string ProPais { get; set; }
        public string Obs { get; set; }
        public Nullable<System.DateTime> lastUpdated { get; set; }
        public Nullable<int> TipoAtencionxMarca { get; set; }
        public Nullable<int> IDTipoAtencionxMarca { get; set; }
    
        public virtual MarcaRegRen MarcaRegRen { get; set; }
        public virtual MarcaTipo MarcaTipo { get; set; }
        public virtual ObservableListSource<Expediente> Expediente { get; set; }
        public virtual Expediente Expediente1 { get; set; }
        public virtual Clase Clase { get; set; }
        public virtual CAgenteLocal CAgenteLocal { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
