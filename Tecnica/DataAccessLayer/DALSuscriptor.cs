using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data;


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
                    Suscriptor s = new Suscriptor();

                    if (!oDatos.Lector.IsDBNull(0))
                    {
                        s.pId = oDatos.Lector.GetInt32(0);
                    }
                    if (!oDatos.Lector.IsDBNull(1))
                    {
                        s.pNombre = oDatos.Lector.GetString(1);
                    }
                    if (!oDatos.Lector.IsDBNull(2))
                    {
                        s.pApellido = oDatos.Lector.GetString(2);
                    }
                    if (!oDatos.Lector.IsDBNull(3))
                    {
                        s.pNumeroDocumento = oDatos.Lector.GetInt32(3);
                    }
                    if (!oDatos.Lector.IsDBNull(4))
                    {
                        s.pTipoDocumento = oDatos.Lector.GetString(4);
                    }
                    if (!oDatos.Lector.IsDBNull(5))
                    {
                        s.pDireccion = oDatos.Lector.GetString(5);
                    }
                    if (!oDatos.Lector.IsDBNull(6))
                    {
                        s.pTelefono = oDatos.Lector.GetString(6);
                    }
                    if (!oDatos.Lector.IsDBNull(7))
                    {
                        s.pEmail = oDatos.Lector.GetString(7);
                    }
                    if (!oDatos.Lector.IsDBNull(8))
                    {
                        s.pNombreUsuario = oDatos.Lector.GetString(8);
                    }
                    if (!oDatos.Lector.IsDBNull(9))
                    {
                        s.pPassword = oDatos.Lector.GetString(9);
                    }
                    LS.Add(s);
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
