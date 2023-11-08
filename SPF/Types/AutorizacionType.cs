using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPF.Types
{
    public class AutorizacionType
    {
        public int AutorizacionCabID { get; set;}
        public int TipoDocumentoID { get; set;}
        public int DocumentoID { get; set;}
        public string DocumentoNombre { get; set; }
        public int UsuarioAutorizadorID { get; set;}
        public string UsuarioAutorizadorNombre { get; set; }
        public int UsuarioAutorizadoID { get; set;}
        public string UsuarioAutorizadoNombre { get; set; }
        public string Motivo { get; set;}
        public DateTime FechaDesde { get; set;}
        public DateTime FechaHasta { get; set; }
        public Nullable<int> SistemaID { get; set; }
    }
}