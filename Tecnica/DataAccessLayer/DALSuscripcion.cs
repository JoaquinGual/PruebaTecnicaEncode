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

            

        public static void InsertarSuscripcion(Suscripcion suscripcion)
        {
            try
            {
                Datos oDatos = new Datos();
                //string proc = "registrarSuscripcion";
                
                //oDatos.Comando.CommandType = CommandType.StoredProcedure;
                //oDatos.Comando.CommandText = proc;
                //oDatos.Comando.Parameters.AddWithValue("@idSuscriptor", suscripcion.pidSuscriptor);
                //oDatos.Comando.Parameters.AddWithValue("@FechaAlta", suscripcion.pfechaAlta);
                //oDatos.Comando.ExecuteNonQuery();
                //oDatos.Desconectar();
                using (OleDbConnection con = new OleDbConnection(oDatos.Conectionstring))
                {
                    con.Open();
                    using (OleDbCommand cmd = new OleDbCommand(@"registrarSuscripcion", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idSuscriptor", suscripcion.pidSuscriptor);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
