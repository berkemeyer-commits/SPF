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
    
    public partial class Audit_op_oposicion
    {
        public int AuditID { get; set; }
        public int ID { get; set; }
        public Nullable<int> ActaNro { get; set; }
        public Nullable<int> ActaAnio { get; set; }
        public Nullable<int> RegistroNro { get; set; }
        public Nullable<int> ExpedienteID { get; set; }
        public Nullable<int> ClienteID { get; set; }
        public Nullable<int> AtencionID { get; set; }
        public string Denominacion { get; set; }
        public Nullable<int> TramiteID { get; set; }
        public Nullable<int> UsuarioID { get; set; }
        public Nullable<System.DateTime> FechaEnvio { get; set; }
        public Nullable<int> OrdenTrabajoID { get; set; }
        public Nullable<System.DateTime> PresentacionFecha { get; set; }
        public string ParteNombre { get; set; }
        public string ContraparteNombre { get; set; }
        public Nullable<System.DateTime> FechaSalida { get; set; }
        public string Audit_User { get; set; }
        public Nullable<System.DateTime> Audit_Fecha { get; set; }
        public string Audit_Operacion { get; set; }
    }
}
