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
    
    public partial class GetListaClientes_Result
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public string Documento { get; set; }
        public string RUC { get; set; }
        public string Personeria { get; set; }
        public string Obs { get; set; }
        public Nullable<System.DateTime> FechaAlta { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public Nullable<int> IdiomaID { get; set; }
        public Nullable<int> PaisID { get; set; }
        public bool Multiple { get; set; }
        public Nullable<int> GrupoEmpresarialID { get; set; }
        public Nullable<bool> Activo { get; set; }
        public Nullable<bool> TraduccionAuto { get; set; }
        public Nullable<int> CiudadID { get; set; }
        public Nullable<bool> Inubicable { get; set; }
        public Nullable<int> Ddi { get; set; }
        public Nullable<bool> PGeneral { get; set; }
        public Nullable<bool> PIntelectual { get; set; }
        public Nullable<bool> Distribuidor { get; set; }
        public Nullable<bool> FacturaLocal { get; set; }
        public string ClienteCiudad { get; set; }
        public string ClientePais { get; set; }
        public Nullable<int> TipoSistElectronicoID { get; set; }
        public string TipoSistElectronicoDescrip { get; set; }
        public Nullable<int> BancoID { get; set; }
        public string BancoNombre { get; set; }
    }
}
