using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.modelo
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        public String Email { get; set; }
        public int Contrasena { get; set; }
      
       
        public Usuario()
        { }

        public Usuario(int idusuario, String email, int contrasena)
        {
            idUsuario = idusuario;
            Email = email;
            Contrasena = contrasena;
            
        }
    }
}
