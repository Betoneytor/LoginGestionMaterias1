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
    public class UnidadDAO

    {
        public List<Unidad> getAllForMat(int idMateria)
        {
            List<Unidad> lista = new List<Unidad>();

            MySqlCommand sentencia = new MySqlCommand();
            sentencia.CommandText =
                "select * from unidades where idMateria=@IdMateria order by(numeroUnidad) asc;";
            sentencia.Parameters.AddWithValue("@IdMateria", idMateria);
            DataTable tabla = Conexion.ejecutarConsulta(sentencia);

            foreach (DataRow fila in tabla.Rows)
            {
                lista.Add(new Unidad(int.Parse(fila["idUnidad"].ToString()), int.Parse(fila["idMateria"].ToString()),
                                      int.Parse(fila["numeroUnidad"].ToString()), int.Parse(fila["calificacionUnidad"].ToString())
                                     )
                          );
            }

            return lista;
        }

        public Unidad getOne(int idunidad)
        {
            try
            {
                MySqlCommand sentencia = new MySqlCommand(
                    "SELECT u.idMateria, u.numeroUnidad, u.calificacionUnidad FROM Unidades u WHERE u.idUnidad =" + idunidad);

                DataTable tabla = Conexion.ejecutarConsulta(sentencia);
                Unidad u = null;
                if (tabla != null && tabla.Rows.Count > 0)
                {
                    DataRow fila = tabla.Rows[0];
                    u = new Unidad(
                    idunidad, int.Parse(fila["idMateria"].ToString()),
                    int.Parse(fila["numeroUnidad"].ToString()), int.Parse(fila["calificacionUnidad"].ToString())
                    );
                }
                return u;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int insert(Unidad obj)
        {
            try
            {
                MySqlCommand sentencia = new MySqlCommand();
                sentencia.CommandText =
                    "insert into Unidades(idMateria,numeroUnidad,calificacionUnidad) values(@IdMateria, @NumeroUnidad, @CalificacionUnidad); SELECT LAST_INSERT_ID();";
                   

                sentencia.Parameters.AddWithValue("@IdMateria", obj.idMateria);
                sentencia.Parameters.AddWithValue("@NumeroUnidad", obj.NumeroUnidad);
                sentencia.Parameters.AddWithValue("@CalificacionUnidad", obj.CalificacionUnidad);

                int idGenerado = Conexion.ejecutarSentencia(sentencia, true);

                return idGenerado;

            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public bool update(Unidad obj)
        {
            try
            {
                MySqlCommand sentencia = new MySqlCommand();
                sentencia.CommandText = 
                    "UPDATE unidades SET numeroUnidad=@NumeroUnidad, calificacionUnidad=@CalificacionUnidad WHERE idUnidad=@IdUnidad";

                sentencia.Parameters.AddWithValue("@NumeroUnidad", obj.NumeroUnidad);
                sentencia.Parameters.AddWithValue("@CalificacionUnidad", obj.CalificacionUnidad);
                sentencia.Parameters.AddWithValue("@IdUnidad", obj.idUnidad);

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
        public bool delete(int id)
        {
            try
            {
                MySqlCommand sentencia = new MySqlCommand();
                sentencia.CommandText = "DELETE FROM unidades WHERE idUnidad=@IdUnidad";

                sentencia.Parameters.AddWithValue("@IdUnidad", id);

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
