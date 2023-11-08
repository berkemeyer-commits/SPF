using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPF.Types
{
    public class TExpedienteCab
    {
        public string OrdenTrabajoID;
        public string ClienteNombre;
        public string ClienteCorreo;
        public string ClienteAtencion;
        public string ClienteIdioma;
        public string FechaCorresp;
        public string TramiteID;
        public string EnTramite;
        public string ClienteFax;
        public string ClienteMail;

        public string AtencionMail;

        public string ReferenciaCliente;
        public string ReferenciaCorresp;
        public string aniocorresp;
        public string nrocorresp;

        public string Obs;
        public string MarcasPend;
        public int ClienteID;
        public int AtencionID;
        public int AreaID;
        public int EnviadoPorID;
        public int AprobadoPorID;

        public string InicialesAprob;
        public string InicialesHecho;
        public string AbrevPresupDoc;

        public string ParteNombre;
        public string ContraparteNombre;


        public TExpedienteCab()
        {
        }

    }

    public class TExpedienteDet
	{
		public int ClienteID;
		public int ExpePadreActaNro;
		public int ExpePadreActaAnio;
		public string ExpePadrePresentacionfecha;

		public int ActaNro;
		public int ActaAnio;

		public int MarcaID;
		public int MarcaRegRenID;
		public int MarcaRegRenIDPadre;

		public string propietarioAnterior;
		public string propietarioActual;
		public string propietarioActDireccion;
		public string propietarioAntDireccion;

		public string propietarioPais;

		public string  nombreotrospropietarios;

		public int RegistroNro ;
		public int RegistroAnio ;

		public int ExpePadreRegistroNro ;
		public int ExpePadreRegistroAnio ;

		public string	PresentacionFecha;
		public string	FechaConcesion;
		public int ClaseNro;
		public string ClaseTipo;
		public string VencimientoFecha;

        public string ParteNombre;
        public string ContraparteNombre;

		public string marcaDenominacion;
		public string Label;

		public TExpedienteDet() 
		{
			
		}
		 
	}
}