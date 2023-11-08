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
    
    public partial class OrdenTrabajo
    {
        public OrdenTrabajo()
        {
            this.Expediente = new ObservableListSource<Expediente>();
            this.op_oposicion = new ObservableListSource<op_oposicion>();
            this.spc_solicitudpagocab = new ObservableListSource<spc_solicitudpagocab>();
        }
    
        public int ID { get; set; }
        public int ClienteID { get; set; }
        public int FuncionarioID { get; set; }
        public int TrabajoTipoID { get; set; }
        public int Nro { get; set; }
        public int Anio { get; set; }
        public bool Facturable { get; set; }
        public System.DateTime AltaFecha { get; set; }
        public string Obs { get; set; }
        public string OrdenTrabajo1 { get; set; }
        public string RefCliente { get; set; }
        public Nullable<int> AtencionID { get; set; }
        public Nullable<int> CorrespondenciaID { get; set; }
        public Nullable<int> CorrNro { get; set; }
        public Nullable<int> CorrAnio { get; set; }
        public string RefCorr { get; set; }
        public Nullable<int> TipoAtencionxMarca { get; set; }
        public Nullable<int> IDTipoAtencionxMarca { get; set; }
    
        public virtual ObservableListSource<Expediente> Expediente { get; set; }
        public virtual TrabajoTipo TrabajoTipo { get; set; }
        public virtual Atencion Atencion { get; set; }
        public virtual ObservableListSource<op_oposicion> op_oposicion { get; set; }
        public virtual Correspondencia Correspondencia { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual ObservableListSource<spc_solicitudpagocab> spc_solicitudpagocab { get; set; }
    }
}
