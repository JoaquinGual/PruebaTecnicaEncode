using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Threading;

namespace DataAccessLayer
{
    public class Datos
    {
        public OleDbConnection conexion;
        OleDbCommand comando;
        public OleDbTransaction transaction;
        OleDbDataReader lector;
        string conectionstring = ConfigurationManager.ConnectionStrings["conDB"].ConnectionString;


        //Properties
        public string Conectionstring { get => conectionstring; set => conectionstring = value; }
        public OleDbDataReader Lector { get => lector; set => lector = value; }

        public OleDbCommand Comando { get => comando; set => comando = value; }


        //Constructores

        public Datos()
        {
            conexion = new OleDbConnection();
            conexion.ConnectionString = conectionstring;
            comando = new OleDbCommand();

        }
        public Datos(string conectionstring)
        {
            conexion = new OleDbConnection(conectionstring);
            comando = new OleDbCommand();
        }

        //Metodos

            //Transacciones
        public void BeginTransaction()
        {
            int TimeOut = 36;
            while (conexion != null)
            {
                Thread.Sleep(250);
                TimeOut--;

                if (TimeOut == 0)
                {
                    RollbackTransaction();
                }
            }

        }
            //Commit

        public void CommitTransaction()
        {
            transaction.Commit();
            transaction.Dispose();
            conexion.Dispose();
            conexion = null;
        }

            //Rollback
        public void RollbackTransaction()
        {
            transaction.Rollback();
            transaction.Dispose();
            conexion.Dispose();
            conexion = null;
        }
        public void Conectar()
        {
            conexion.ConnectionString = conectionstring;
            conexion.Open();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
        }

        public void Desconectar()
        {
            conexion.Close();
        }

        public void LeerTabla(string nombreTabla)
        {
            Conectar();
            comando.CommandText = "Select * from " + nombreTabla;
            Lector = comando.ExecuteReader();
        }

        public DataTable ConsultarTabla(string nombreTabla)
        {
            Conectar();
            comando.CommandText = "select * from " + nombreTabla;
            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());
            Desconectar();
            return tabla;
        }
        public void Actualizar(string consultaSQL)
        {
            Conectar();
            comando.CommandText = consultaSQL;
            comando.ExecuteNonQuery();
            Desconectar();

        }
    }
}
