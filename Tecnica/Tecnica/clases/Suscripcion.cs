using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tecnica.clases
{
    public class Suscripcion
    {
        Suscriptor sub;
        int idAsociacion;
        int idSuscriptor;
        DateTime fechaAlta;
        DateTime fechaFin;
        string motivoFin;

        public Suscripcion()
        {
            sub = null;
            idAsociacion = 0;
            idSuscriptor = 0;
            fechaAlta = DateTime.Now;
            fechaFin = DateTime.Now;
        }
        public Suscripcion(int idAso, int idSus,DateTime fechaAl,DateTime fechaFi,Suscriptor s)
        {
            sub = s;
            idAsociacion = idAso;
            idSuscriptor = idSus;
            fechaAlta = fechaAl;
            fechaFin = fechaFi;
        }

        public int pidAsociacion
        {
            get { return idAsociacion; }
            set { idAsociacion = value; }
        }
        public int pidSuscriptor
        {
            get { return idSuscriptor; }
            set { idSuscriptor = value; }
        }
        public DateTime pfechaAlta
        {
            get { return fechaAlta; }
            set { fechaAlta = value; }
        }
        public DateTime pfechaFin
        {
            get { return fechaFin; }
            set { fechaFin = value; }
        }


    }

    
}