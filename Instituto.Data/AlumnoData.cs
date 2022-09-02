using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Instituto.Dominio;

namespace Instituto.Data
{
    public class AlumnoData
    {
        String cadenaConexion = "server=localhost; Database=Instituto; Integrated Security = true";

        public List<Alumnos> Listar()
        {

            var listado = new List<Alumnos>();
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (var comando = new SqlCommand("SELECT * FROM Alumnos", conexion))
                {
                    using (var lector = comando.ExecuteReader())
                    {
                        if (lector != null && lector.HasRows)
                        {
                            Alumnos alumno;
                            while (lector.Read())
                            {
                                alumno = new Alumnos();
                                alumno.ID = int.Parse(lector[0].ToString());
                                alumno.Nombre = lector[1].ToString();
                                alumno.Apellido = lector[2].ToString();
                                alumno.Distrito = lector[3].ToString();
                                alumno.Fecha_Nacimiento = DateTime.Parse(lector[4].ToString());
                                alumno.DNI = int.Parse(lector[5].ToString());
                                alumno.Celular = int.Parse(lector[6].ToString());

                                listado.Add(alumno);
                            }
                        }
                    }
                }
            }
                return listado;
        }
        public Alumnos BuscarPorId(int id)
        {
            var alumno = new Alumnos();
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (var comando = new SqlCommand("SELECT * FROM Alumnos WHERE Id = @ID", conexion))
                {
                    comando.Parameters.AddWithValue("@ID", id);
                    using (var lector = comando.ExecuteReader())
                    {
                        if (lector != null && lector.HasRows)
                        {
                            lector.Read();
                            alumno = new Alumnos();
                            alumno.ID = int.Parse(lector[0].ToString());
                            alumno.Nombre = lector[1].ToString();
                            alumno.Apellido = lector[2].ToString();
                            alumno.Distrito = lector[3].ToString();
                            alumno.Fecha_Nacimiento = DateTime.Parse(lector[4].ToString());
                            alumno.DNI = int.Parse(lector[5].ToString());
                            alumno.Celular = int.Parse(lector[6].ToString());

                        }
                    }
                }
            }
            return alumno;
        }

        public bool Insertar(Alumnos alumno)
        {
            int filasInsertadas = 0;
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                var sql = "INSERT INTO Alumnos ( Nombre, Apellido, Distrito, Fecha_Nacimiento, DNI, Celular)" +
                          "VALUES( @Nombre, @Apellido, @Distrito, @Fecha_Nacimiento, @DNI, @Celular)";
                using(var comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@Id", alumno.Nombre);
                    comando.Parameters.AddWithValue("@Nombre", alumno.Nombre);
                    comando.Parameters.AddWithValue("@Apellido", alumno.Apellido);
                    comando.Parameters.AddWithValue("@Distrito", alumno.Distrito);
                    comando.Parameters.AddWithValue("@Fecha_Nacimiento", alumno.Fecha_Nacimiento);
                    comando.Parameters.AddWithValue("@DNI", alumno.DNI);
                    comando.Parameters.AddWithValue("@Celular", alumno.Celular);

                    filasInsertadas = comando.ExecuteNonQuery();
                }
            }

            return filasInsertadas > 0;
        }

        public bool Actualizar(Alumnos alumno)
        {
            int filasActualizadas = 0;
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                var sql = "UPDATE Alumnos SET  Nombre = @Nombre, Apellido = @Apellido, Distrito = @Distrito, " +
                    "Fecha_Nacimiento = @Fecha_Nacimiento, DNI = @DNI, Celular = @Celular" +
                    " WHERE Id = @ID";
                using (var comando = new SqlCommand(sql, conexion))
                {
                    
                    comando.Parameters.AddWithValue("@Nombre", alumno.Nombre);
                    comando.Parameters.AddWithValue("@Apellido", alumno.Apellido);
                    comando.Parameters.AddWithValue("@Distrito", alumno.Distrito);
                    comando.Parameters.AddWithValue("@Fecha_Nacimiento", alumno.Fecha_Nacimiento);
                    comando.Parameters.AddWithValue("@DNI", alumno.DNI);
                    comando.Parameters.AddWithValue("@Celular", alumno.Celular);
                    comando.Parameters.AddWithValue("@Id", alumno.ID);

                    filasActualizadas = comando.ExecuteNonQuery();
                }
            }
            return filasActualizadas > 0;
        }
        public bool Eliminar(int id)
        {
            int filaEliminadas = 0;
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                var Sql = "DELETE FROM Alumnos WHERE Id = @ID";
                using (var comando = new SqlCommand(Sql, conexion))
                {
                    comando.Parameters.AddWithValue("@ID", id);
                    filaEliminadas = comando.ExecuteNonQuery();

                }
            }
            return filaEliminadas > 0;
        }
    }
}
