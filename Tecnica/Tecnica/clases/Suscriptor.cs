using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tecnica.clases
{
    public class Suscriptor
    {
		private string nombre;
		private string apellido;
		private int numeroDocumento;
		private string tipoDocumento;
		private string direccion;
		private string telefono;
		private string email;
		private string nombreUsuario;
		private string password;


		public Suscriptor()
		{
			nombre = "";
			apellido = "";
			numeroDocumento = 0;
			tipoDocumento = "";
			direccion = "";
			telefono = "";
			email = "";
			nombreUsuario = "";
			password = "";
		}
		public Suscriptor(string nom, string ape,int numDoc,string tipoDoc,string dire,string tel,string mail,string nomUsu,string pass)
		{
			nombre = nom;
			apellido = ape;
			numeroDocumento = numDoc;
			tipoDocumento = tipoDoc;
			direccion = dire;
			telefono = tel;
			email = mail;
			nombreUsuario = nomUsu;
			password = pass;
		}

		public string pPassword
		{
			get { return password; }
			set { password = value; }
		}


		public string pNombreUsuario
		{
			get { return nombreUsuario; }
			set { nombreUsuario = value; }
		}


		public string pEmail
		{
			get { return email; }
			set { email = value; }
		}


		public string pTelefono
		{
			get { return telefono; }
			set { telefono = value; }
		}


		public string pDireccion
		{
			get { return direccion; }
			set { direccion = value; }
		}



		public string pTipoDocumento
		{
			get { return tipoDocumento; }
			set { tipoDocumento = value; }
		}


		public int pNumeroDocumento
		{
			get { return numeroDocumento; }
			set { numeroDocumento = value; }
		}


		public string pApellido
		{
			get { return apellido; }
			set { apellido = value; }
		}


		public string pNombre
		{
			get { return nombre; }
			set { nombre = value; }
		}

	}
}