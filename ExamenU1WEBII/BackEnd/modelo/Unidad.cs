using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.modelo
{
    public class Unidad
    {
        public int idUnidad { get; set; }
        public int idMateria { get; set; }
        public int NumeroUnidad { get; set; }
        public int CalificacionUnidad { get; set; }


        public Unidad()
        { }

        public Unidad(int idunidad, int idmateria, int numerounidad, int calificacionunidad)
        {
            idUnidad = idunidad;
            idMateria = idmateria;
            NumeroUnidad = numerounidad;
            CalificacionUnidad = calificacionunidad;


        }
    }
}
