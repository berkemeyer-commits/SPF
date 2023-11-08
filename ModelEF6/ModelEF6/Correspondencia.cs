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
    
    public partial class Correspondencia
    {
        public Correspondencia()
        {
            this.OrdenTrabajo = new ObservableListSource<OrdenTrabajo>();
            this.spd_solicitudpagodet = new ObservableListSource<spd_solicitudpagodet>();
        }
    
        public int ID { get; set; }
        public bool Entrante { get; set; }
        public int Nro { get; set; }
        public int Anio { get; set; }
        public System.DateTime FechaAlta { get; set; }
        public Nullable<System.DateTime> FechaCorresp { get; set; }
        public string RefCorresp { get; set; }
        public Nullable<int> Identidad { get; set; }
        public int IdiniRecep { get; set; }
        public int Idvia { get; set; }
        public string RefCliente { get; set; }
        public int PrioridadID { get; set; }
        public string Obs { get; set; }
        public Nullable<int> ClienteID { get; set; }
        public Nullable<int> FuncionarioID { get; set; }
        public Nullable<bool> Estado { get; set; }
        public Nullable<bool> Facturable { get; set; }
        public Nullable<bool> Acusado { get; set; }
        public Nullable<int> idarea { get; set; }
        public Nullable<bool> documento { get; set; }
        public Nullable<bool> renovacion { get; set; }
    
        public virtual ObservableListSource<OrdenTrabajo> OrdenTrabajo { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ObservableListSource<spd_solicitudpagodet> spd_solicitudpagodet { get; set; }
    }
}
