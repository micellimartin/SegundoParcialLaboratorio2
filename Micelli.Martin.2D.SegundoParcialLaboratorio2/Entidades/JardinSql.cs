using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Entidades
{
    public static class JardinSql
    {
        private static SqlCommand comando;
        private static SqlConnection conexion;

        /// <summary>
        /// Establece la conxion a la base de datos contra la cual se haran las consultas
        /// </summary>
        static JardinSql()
        {
            string conexionString = @"Data Source= .\SQLEXPRESS; Initial Catalog= JardinUtnClon; Integrated Security= True";
            conexion = new SqlConnection(conexionString);
            comando = new SqlCommand();
            comando.Connection = conexion;
        }

        #region Docentes

        /// <summary>
        /// Inserta los docentes en la tabla Docentes de la base de datos
        /// </summary>
        /// <param name="listaDocentes">Lista de docentes a insertar</param>
        public static void InsertarDocentes(List<Docente> listaDocentes)
        {
            //Si la tabla de docentes esta vacia entonces inserto en ella los docentes. De esta forma no inserta docentes repetidos
            if(JardinSql.VerificarTablaDocentes())
            {
                try
                {
                    conexion.Open();

                    foreach (Docente d in listaDocentes)
                    {
                        comando.Parameters.Clear();
                        comando.CommandText = "INSERT INTO DOCENTES (Nombre, Apellido, Edad, Sexo, Dni, Direccion, Email) VALUES (@Nombre, @Apellido, @Edad, @Sexo, @Dni, @Direccion, @Email)";

                        comando.Parameters.Add(new SqlParameter("Nombre", d.Nombre));
                        comando.Parameters.Add(new SqlParameter("Apellido", d.Apellido));
                        comando.Parameters.Add(new SqlParameter("Edad", d.Edad));
                        comando.Parameters.Add(new SqlParameter("Sexo", d.Sexo));
                        comando.Parameters.Add(new SqlParameter("Dni", d.Dni));
                        comando.Parameters.Add(new SqlParameter("Direccion", d.Direccion));
                        comando.Parameters.Add(new SqlParameter("Email", d.Email));

                        comando.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conexion.Close();
                }
            }         
        }

        /// <summary>
        /// Verifica si la tabla de docentes esta vacia
        /// </summary>
        /// <returns>true si esta vacia, false caso contrario</returns>
        public static bool VerificarTablaDocentes()
        {
            bool estaVacia = false;

            try
            {
                conexion.Open();
                //Consulto el numero filas en la tabla de docentes
                comando.CommandText = "SELECT COUNT(*) FROM Docentes";
                int numeroFilas = (int)comando.ExecuteScalar();

                if(numeroFilas == 0)
                {
                    estaVacia = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }

            return estaVacia;
        }

        /// <summary>
        /// Obtiene los docentes desde la tabla Docentes de la base de datos y los carga al programa
        /// </summary>
        /// <param name="listadoDocentes">Lista que contendra los docentes de la base de datos</param>
        public static void ObtenerDocentes(List<Docente> listadoDocentes)
        {
            try
            {
                conexion.Open();

                comando.CommandText = "Select * from Docentes";
                SqlDataReader dr = comando.ExecuteReader();

                //Devuelve true si leyo, false caso contrario
                while(dr.Read())
                {
                    listadoDocentes.Add(new Docente(dr[1].ToString(), dr[2].ToString(), int.Parse(dr[3].ToString()), int.Parse(dr[5].ToString()), dr[6].ToString(), int.Parse(dr[0].ToString()), dr[4].ToString(), dr[7].ToString()));
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }

        #endregion

        #region Evaluaciones

        /// <summary>
        /// Inserta 1 evaluacion en la tabla evaluaciones de la base de datos
        /// </summary>
        /// <param name="evaluacion">Evaluacion a insertar</param>
        public static void InsertarEvaluacion(Evaluacion evaluacion)
        {
            try
            {
                conexion.Open();

                comando.Parameters.Clear();
                comando.CommandText = "INSERT INTO Evaluaciones (idAlumno, idDocente, idAula, Nota_1, Nota_2, NotaFinal, Observaciones) VALUES (@idAlumno, @idDocente, @idAula, @Nota_1, @Nota_2, @NotaFinal, @Observaciones)";

                comando.Parameters.Add(new SqlParameter("idAlumno", evaluacion.IdAlumno));
                comando.Parameters.Add(new SqlParameter("idDocente", evaluacion.IdDocente));
                comando.Parameters.Add(new SqlParameter("idAula", evaluacion.IdAula));
                comando.Parameters.Add(new SqlParameter("Nota_1", evaluacion.Nota_1));
                comando.Parameters.Add(new SqlParameter("Nota_2", evaluacion.Nota_2));
                comando.Parameters.Add(new SqlParameter("NotaFinal", evaluacion.NotaFinal));
                comando.Parameters.Add(new SqlParameter("Observaciones", evaluacion.Observaciones));

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }

        /// <summary>
        /// Obtiene las evaculaciones contenidas en la tabla Evaluaciones de la base de datos
        /// </summary>
        /// <returns>DataTable con la informacion de las evaluaciones</returns>
        public static DataTable ObtenerEvaluaciones()
        {
            DataTable retorno = new DataTable(); ;

            try
            {
                conexion.Open();
                comando.CommandText = "Select * from Evaluaciones";
                SqlDataReader dr = comando.ExecuteReader();
                retorno.Load(dr);        
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }

            return retorno;
        }

        #endregion

        #region Alumnos

        /// <summary>
        /// Obtiene los alumnos contenidos en la tabla Alumnos de la base de datos
        /// </summary>
        /// <param name="listadoAlumnos">Lista que contendra a los alumnos obtenidos</param>
        public static void ObtenerAlumnos(List<Alumno> listadoAlumnos)
        {
            try
            {
                conexion.Open();

                comando.CommandText = "Select * from Alumnos";
                SqlDataReader dr = comando.ExecuteReader();

                //Si leyo una linea devuelve true
                while (dr.Read())
                {
                    listadoAlumnos.Add(new Alumno(dr[1].ToString(), dr[2].ToString(), int.Parse(dr[3].ToString()), int.Parse(dr[4].ToString()), dr[5].ToString(), int.Parse(dr[0].ToString()), dr[6].ToString()));
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }

        #endregion

        #region Aulas

        /// <summary>
        /// Obtiene las aulas de la tabla Aulas de la base de datos 
        /// </summary>
        /// <param name="listadoAulas">Lista que contendra las aulas obtenidas</param>
        public static void ObtenerAluas(List<Aula> listadoAulas)
        {
            try
            {
                conexion.Open();

                comando.CommandText = "Select * from Aulas";
                SqlDataReader dr = comando.ExecuteReader();

                //Si leyo una fila devuelve true
                while (dr.Read())
                {
                    listadoAulas.Add(new Aula(int.Parse(dr[0].ToString()), dr[1].ToString()));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }

        #endregion
    }
}
