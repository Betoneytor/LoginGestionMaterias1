using BackEnd.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using BackEnd.modelo;


namespace BackEnd.datos
{
    public class UsuarioDAO
    {
       

        

        public int existeUsuario(String txtEmail, String txtContrasena)
        {
            try
            {
                MySqlCommand sentencia = new MySqlCommand(
                    "select u.idUsuario from usuarios u where u.email =@Email and u.contrasena = @Contrasena"); 
                   
                sentencia.CommandType = CommandType.Text;

                sentencia.Parameters.AddWithValue("@Email", txtEmail);

                sentencia.Parameters.AddWithValue("@Contrasena", txtContrasena);

                DataTable tabla = Conexion.ejecutarConsulta(sentencia);
                int id = 0;
                
                if (tabla != null && tabla.Rows.Count > 0)
                {
                    DataRow fila = tabla.Rows[0];
                    id =Int32.Parse( fila["idUsuario"].ToString());
                }
                
                return id;
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                Conexion.desconectar();
            }
        }

        public int registrarUsuario(String txtEmail, String txtContrasena)
        {
            try
            {
                MySqlCommand sentencia = new MySqlCommand(
                    "insert into usuarios(email,contrasena) values(@Email,@Contrasena); SELECT LAST_INSERT_ID();");

                sentencia.CommandType = CommandType.Text;

                sentencia.Parameters.AddWithValue("@Email", txtEmail);

                sentencia.Parameters.AddWithValue("@Contrasena", txtContrasena);

                int idGenerado = Conexion.ejecutarSentencia(sentencia, true);

                return idGenerado;
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                Conexion.desconectar();
            }
        }

        

        public Usuario getEmailById(int id)
        {
            try
            {
                MySqlCommand sentencia = new MySqlCommand(
                    "select u.email,u.contrasena from usuarios u where u.idUsuario =@idUsuario");
                     sentencia.CommandType = CommandType.Text;

                sentencia.Parameters.AddWithValue("@idUsuario", id);

                DataTable tabla = Conexion.ejecutarConsulta(sentencia);
                Usuario u = null;
                if (tabla != null && tabla.Rows.Count > 0)
                {
                    DataRow fila = tabla.Rows[0];
                    u = new Usuario(
                    id, 
                    fila["email"].ToString(),
                    int.Parse(fila["contrasena"].ToString())
                    );
                }
                return u;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                Conexion.desconectar();
            }
        }

    }

}
