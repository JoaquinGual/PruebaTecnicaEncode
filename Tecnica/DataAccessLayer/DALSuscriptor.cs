using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data;
using System.Data.OleDb;

namespace DataAccessLayer
{
    public class DALSuscriptor
    {

        //Inserta Suscriptor nuevo
        public static bool InsertarSuscriptor(Suscriptor suscriptor)
        {
            Datos oDatos = new Datos();
            try
            {

                
                string proc = "registrarSuscriptor";
                oDatos.Conectar();
                oDatos.Comando.CommandType = CommandType.StoredProcedure;
                oDatos.Comando.CommandText = proc;
                oDatos.Comando.Parameters.AddWithValue("@Nombre", suscriptor.pNombre);
                oDatos.Comando.Parameters.AddWithValue("@Apellido", suscriptor.pApellido);
                oDatos.Comando.Parameters.AddWithValue("@NumeroDocumento", suscriptor.pNumeroDocumento);
                oDatos.Comando.Parameters.AddWithValue("@TipoDocumento", suscriptor.pTipoDocumento);
                oDatos.Comando.Parameters.AddWithValue("@Direccion", suscriptor.pDireccion);
                oDatos.Comando.Parameters.AddWithValue("@Telefono", suscriptor.pTelefono);
                oDatos.Comando.Parameters.AddWithValue("@Email", suscriptor.pEmail);
                oDatos.Comando.Parameters.AddWithValue("@NombreUsuario", suscriptor.pNombreUsuario);
                oDatos.Comando.Parameters.AddWithValue("@Password", suscriptor.pPassword);
                oDatos.transaction = oDatos.conexion.BeginTransaction();
                oDatos.Comando.Transaction = oDatos.transaction;
                oDatos.Comando.ExecuteNonQuery();
                oDatos.Comando.Parameters.Clear();
                oDatos.CommitTransaction();
                return true;
            }
            catch (Exception)
            {
                oDatos.BeginTransaction();
                return false;
                
            }
            
        }

        //Modifica Suscriptor
        public static bool Modificar(Suscriptor suscriptor)
        {
            Datos oDatos = new Datos();
            try
            {
                
                string proc = "ActualizarSuscriptor";
                oDatos.Conectar();
                oDatos.Comando.CommandType = CommandType.StoredProcedure;
                oDatos.Comando.CommandText = proc;
                oDatos.Comando.Parameters.AddWithValue("@Nombre", suscriptor.pNombre);
                oDatos.Comando.Parameters.AddWithValue("@Apellido", suscriptor.pApellido);
                oDatos.Comando.Parameters.AddWithValue("@NumeroDocumento", suscriptor.pNumeroDocumento);
                oDatos.Comando.Parameters.AddWithValue("@TipoDocumento", suscriptor.pTipoDocumento);
                oDatos.Comando.Parameters.AddWithValue("@Direccion", suscriptor.pDireccion);
                oDatos.Comando.Parameters.AddWithValue("@Telefono", suscriptor.pTelefono);
                oDatos.Comando.Parameters.AddWithValue("@Email", suscriptor.pEmail);
                oDatos.Comando.Parameters.AddWithValue("@NombreUsuario", suscriptor.pNombreUsuario);
                oDatos.Comando.Parameters.AddWithValue("@Password",suscriptor.pPassword);
                oDatos.transaction = oDatos.conexion.BeginTransaction();
                oDatos.Comando.Transaction = oDatos.transaction;
                oDatos.Comando.ExecuteNonQuery();
                oDatos.Comando.Parameters.Clear();
                oDatos.CommitTransaction();
                return true;
            }
            catch (Exception)
            {
                oDatos.BeginTransaction();
                return false;
            }
           
            
        }
        //METODO CARGAR OBJETO
        public static Suscriptor CrearObjetoSuscriptor(OleDbDataReader dr)
        {
            var suscriptor = new Suscriptor();

            if (dr["IdSuscriptor"] != null )
            { 
                suscriptor.pId = (int)dr["IdSuscriptor"];
            }
            if (dr["Nombre"].ToString() != null)
            {
                suscriptor.pNombre = dr["Nombre"].ToString();
            }
            if (dr["Apellido"].ToString() != null)
            {
                suscriptor.pApellido = dr["Apellido"].ToString();
            }
            if (dr["NumeroDocumento"] != null)
            {
                suscriptor.pNumeroDocumento = (int)dr["NumeroDocumento"];
            }
            if (dr["TipoDocumento"].ToString() != null)
            {
                suscriptor.pTipoDocumento = dr["TipoDocumento"].ToString();
            }
            if (dr["Direccion"].ToString() != null)
            {
                suscriptor.pDireccion = dr["Direccion"].ToString();
            }
            if (dr["Telefono"].ToString() != null)
            {
                suscriptor.pTelefono = dr["Telefono"].ToString();
            }
            if (dr["Email"].ToString() != null)
            {
                suscriptor.pEmail = dr["Email"].ToString();
            }
            if (dr["NombreUsuario"].ToString() != null)
            {
                suscriptor.pNombreUsuario = dr["NombreUsuario"].ToString();
            }
            if (dr["Password"].ToString() != null)
            {
                suscriptor.pPassword = dr["Password"].ToString();
            }





            return suscriptor;
        }

        //Carga lista con datos de sscriptores
        public static List<Suscriptor> cargarLista(string Tabla)
        {
            try
            {
                List<Suscriptor> LS = new List<Suscriptor>();
                Datos oDatos = new Datos();
                oDatos.LeerTabla(Tabla);
                LS.Clear();
                while (oDatos.Lector.Read())
                {
                    
                    LS.Add(CrearObjetoSuscriptor(oDatos.Lector));
                }
                oDatos.Desconectar();
                return LS;
            }
            catch (Exception)
            {

                throw new Exception("Ha ocurrido un Error");
            }
            
        }
       
    }
}
