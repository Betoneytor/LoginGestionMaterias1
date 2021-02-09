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
    public class MateriaDAO
    {

        public List<Materia> getAllForUsr(int idUsuario)
        {
            List<Materia> lista = new List<Materia>();

            MySqlCommand sentencia = new MySqlCommand();
            sentencia.CommandText =
                "select * from materias where idUsuario=@IdUsuario order by(nombre) asc;";
            sentencia.Parameters.AddWithValue("@IdUsuario", idUsuario);
            DataTable tabla = Conexion.ejecutarConsulta(sentencia);

            foreach (DataRow fila in tabla.Rows)
            {
                lista.Add(new Materia(int.Parse(fila["idMateria"].ToString()), int.Parse(fila["idUsuario"].ToString()),
                                      fila["nombre"].ToString()
                                     )
                          );
            }

            return lista;
        }

        public int insert(Materia obj)
        {
            try
            {
                MySqlCommand sentencia = new MySqlCommand();
                sentencia.CommandText = "insert into materias(idUsuario,nombre)  values(@IdUsuario, @Nombre); SELECT LAST_INSERT_ID();";

                sentencia.Parameters.AddWithValue("@Nombre", obj.Nombre);
                sentencia.Parameters.AddWithValue("@IdUsuario", obj.idUsuario);


                int idGenerado = Conexion.ejecutarSentencia(sentencia, true);

                return idGenerado;

            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public bool update(Materia obj)
        {
            try
            {
                MySqlCommand sentencia = new MySqlCommand();
                sentencia.CommandText = "UPDATE materias SET nombre=@Nombre WHERE idMateria=@IdMateria";

                sentencia.Parameters.AddWithValue("@Nombre", obj.Nombre);
                sentencia.Parameters.AddWithValue("@IdMateria", obj.idMateria);

                if (Conexion.ejecutarSentencia(sentencia, false) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Materia getOne(int id)
        {
            try
            {
                MySqlCommand sentencia = new MySqlCommand(
                    "SELECT m.IdUsuario, m.nombre FROM materias m WHERE m.IdMateria =" + id);

                DataTable tabla = Conexion.ejecutarConsulta(sentencia);
                Materia m = null;
                if (tabla != null && tabla.Rows.Count > 0)
                {
                    DataRow fila = tabla.Rows[0];
                    m = new Materia(
                    id, int.Parse(fila["idUsuario"].ToString()),
                    fila["nombre"].ToString()
                    );
                }
                return m;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public bool delete(int id)
        {
            try
            {
                MySqlCommand sentencia = new MySqlCommand();
                sentencia.CommandText = "DELETE FROM materias WHERE IdMateria=@IdMateria";

                sentencia.Parameters.AddWithValue("@IdMateria", id);

                if (Conexion.ejecutarSentencia(sentencia, false) > 0)
                    return true;
                else
                    return false;

            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}
