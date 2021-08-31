using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Suscripcion
    {
       
        int idAsociacion;
        int idSuscriptor;
        DateTime fechaAlta;
        DateTime fechaFin;
        string motivoFin;

        public Suscripcion()
        {
            idAsociacion = 0;
            idSuscriptor = 0;
            fechaAlta = DateTime.Now;
            fechaFin = DateTime.Now;
            motivoFin = "";
        }
        public Suscripcion(int idAso, int idSus, DateTime fechaAl, DateTime fechaFi, string motivo)
        {
            
            idAsociacion = idAso;
            idSuscriptor = idSus;
            fechaAlta = fechaAl;
            fechaFin = fechaFi;
            motivoFin = motivo;
            
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
        public string pMotivoFin
        {
            get { return motivoFin; }
            set { motivoFin = value; }
        }
    }
}
