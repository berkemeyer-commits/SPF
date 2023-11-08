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
    
    public partial class Expediente
    {
        public Expediente()
        {
            this.Expediente1 = new ObservableListSource<Expediente>();
            this.Marca1 = new ObservableListSource<Marca>();
            this.MarcaRegRen1 = new ObservableListSource<MarcaRegRen>();
            this.ExpedienteCampo = new ObservableListSource<ExpedienteCampo>();
            this.ExpedienteXPoder = new ObservableListSource<ExpedienteXPoder>();
            this.Poder = new ObservableListSource<Poder>();
            this.ExpedienteXPropietario = new ObservableListSource<ExpedienteXPropietario>();
            this.op_oposicion = new ObservableListSource<op_oposicion>();
            this.Merge_Expediente = new ObservableListSource<Merge_Expediente>();
        }
    
        public int ID { get; set; }
        public int TramiteID { get; set; }
        public int TramiteSitID { get; set; }
        public Nullable<int> ActaNro { get; set; }
        public Nullable<int> ActaAnio { get; set; }
        public Nullable<int> OrdenTrabajoID { get; set; }
        public Nullable<int> ClienteID { get; set; }
        public Nullable<int> AgenteLocalID { get; set; }
        public Nullable<int> ExpedienteID { get; set; }
        public Nullable<int> BoletinDetalleID { get; set; }
        public Nullable<int> DiarioID { get; set; }
        public Nullable<int> PublicPag { get; set; }
        public Nullable<int> PublicAnio { get; set; }
        public Nullable<bool> Documento { get; set; }
        public Nullable<int> Bib { get; set; }
        public Nullable<int> Exp { get; set; }
        public bool Nuestra { get; set; }
        public bool Sustituida { get; set; }
        public bool StandBy { get; set; }
        public bool Vigilada { get; set; }
        public bool Concluido { get; set; }
        public Nullable<System.DateTime> VencimientoFecha { get; set; }
        public Nullable<int> MarcaRegRenID { get; set; }
        public Nullable<int> PoderInscID { get; set; }
        public Nullable<int> MarcaID { get; set; }
        public Nullable<System.DateTime> FechaAband { get; set; }
        public string Obs { get; set; }
        public string Acta { get; set; }
        public string Publicacion { get; set; }
        public string Label { get; set; }
        public Nullable<System.DateTime> AltaFecha { get; set; }
        public Nullable<System.DateTime> PresentacionFecha { get; set; }
        public Nullable<System.DateTime> lastUpdated { get; set; }
    
        public virtual ObservableListSource<Expediente> Expediente1 { get; set; }
        public virtual Expediente Expediente2 { get; set; }
        public virtual Marca Marca { get; set; }
        public virtual MarcaRegRen MarcaRegRen { get; set; }
        public virtual Tramite_Sit Tramite_Sit { get; set; }
        public virtual ObservableListSource<Marca> Marca1 { get; set; }
        public virtual ObservableListSource<MarcaRegRen> MarcaRegRen1 { get; set; }
        public virtual OrdenTrabajo OrdenTrabajo { get; set; }
        public virtual ObservableListSource<ExpedienteCampo> ExpedienteCampo { get; set; }
        public virtual ObservableListSource<ExpedienteXPoder> ExpedienteXPoder { get; set; }
        public virtual ObservableListSource<Poder> Poder { get; set; }
        public virtual ObservableListSource<ExpedienteXPropietario> ExpedienteXPropietario { get; set; }
        public virtual ObservableListSource<op_oposicion> op_oposicion { get; set; }
        public virtual CAgenteLocal CAgenteLocal { get; set; }
        public virtual ObservableListSource<Merge_Expediente> Merge_Expediente { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Tramite Tramite { get; set; }
    }
}
