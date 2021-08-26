using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data;
using System.Configuration;

namespace Tecnica.clases
{
    public class Datos
    {
        OleDbConnection conexion;
        OleDbCommand comando;
        OleDbDataReader lector;
        string conectionstring = ConfigurationManager.ConnectionStrings["conDB"].ConnectionString;


        //Properties
        public string Conectionstring { get => conectionstring; set => conectionstring = value; }
        public OleDbDataReader Lector { get => lector; set => lector = value; }


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