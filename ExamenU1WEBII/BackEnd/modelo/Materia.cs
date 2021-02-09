using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.modelo
{
    public class Materia
    {
        public int idMateria { get; set; }
        public int idUsuario { get; set; }
        public String Nombre { get; set; }
        


        public Materia()
        { }

        public Materia(int idmateria, int idusuario,String nombre)
        {
            idMateria = idmateria;
            idUsuario = idusuario;
            Nombre = nombre;
            

        }
    }
}
