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
    public class DALSuscripcion
    {
        //Carga lista con datos de suscripciones
        public static List<Suscripcion> CargarSuscripciones(string tabla)
        {
            try
            {
                List<Suscripcion> LS = new List<Suscripcion>();
                Datos oDatos = new Datos();
                oDatos.LeerTabla(tabla);
                LS.Clear();
                while (oDatos.Lector.Read())
                {
                    Suscripcion s = new Suscripcion();

                    if (!oDatos.Lector.IsDBNull(0))
                    {
                        s.pidAsociacion = oDatos.Lector.GetInt32(0);
                    }
                    if (!oDatos.Lector.IsDBNull(1))
                    {
                        s.pidSuscriptor = oDatos.Lector.GetInt32(1);
                    }
                    LS.Add(s);
                }
                oDatos.Desconectar();
                return LS;
            }
            catch (Exception)
            {

                throw;
            }
        }

            
        //Inserta nueva suscripcion
        public static bool InsertarSuscripcion(Suscripcion suscripcion)
        {
            Datos oDatos = new Datos();
            try
            {
                
                string proc = "registrarSuscripcion";
                oDatos.Conectar();
                oDatos.Comando.CommandType = CommandType.StoredProcedure;
                oDatos.Comando.CommandText = proc;
                oDatos.Comando.Parameters.AddWithValue("@idSuscriptor", suscripcion.pidSuscriptor);
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
    }
}
