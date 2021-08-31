using Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using Tecnica.DAL;

namespace Tecnica.BLL
{
    public class BLLSuscriptor
    {
       public static void Insertar(Suscriptor s)
       {
            DALSuscriptor.Insertar(s);
       }

       public static void CargarLista(string tabla)
        {
            DALSuscriptor.cargarLista(tabla);
        }
    }
}
