using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Entities;

namespace BusinessLogicLayer
{
    public class BLLSuscriptor
    {
        
        public static bool InsertarSuscriptor(Suscriptor s)
        {
            return DALSuscriptor.InsertarSuscriptor(s);
        }

        public static List<Suscriptor> CargarLista(string tabla)
        {
            return DALSuscriptor.cargarLista(tabla);
            
        }
        public static bool Modificar(Suscriptor s)
        {
            return DALSuscriptor.Modificar(s);
        }
        
    }
}
