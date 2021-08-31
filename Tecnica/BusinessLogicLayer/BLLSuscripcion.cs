﻿using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace BusinessLogicLayer
{
    public class BLLSuscripcion
    {
        public static void registrarSuscripcion(Suscripcion sub)
        {
            DALSuscripcion.InsertarSuscripcion(sub);
        }
        public static List<Suscripcion> CargarSuscripciones(string tabla)
        {
            return DALSuscripcion.CargarSuscripciones(tabla);

        }
    }
}