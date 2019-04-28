using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using WCFGenerales.Dominio;

namespace WCFGenerales.Persistencia
{
    public class GeneralDAO
    {
        private string CadenaConexion = "DATA SOURCE=xe;PASSWORD=oracle; USER ID=tutor;";

        public Profesor ObtenerProfesor(string codigo)
        {
            try
            {
                Profesor profesorEncontrado = null;
                string sql = "SELECT * FROM TUTOR.PROFESOR WHERE COD_PROFESOR= :codigo";
                using (OracleConnection conexion = new OracleConnection(CadenaConexion))
                {
                    conexion.Open();
                    using (OracleCommand comando = new OracleCommand(sql, conexion))
                    {
                        comando.Parameters.AddWithValue(":codigo", codigo);
                        using (OracleDataReader resultado = comando.ExecuteReader())
                        {
                            if (resultado.HasRows)
                            {
                                if (resultado.Read())
                                {
                                    profesorEncontrado = new Profesor()
                                    {
                                        Codigo = Convert.ToString(resultado["COD_PROFESOR"]).Trim(),
                                        Nombre = Convert.ToString(resultado["NOM_PROFESOR"]).Trim(),                                       
                                    };
                                }
                            }

                        }
                    }
                    return profesorEncontrado;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<Profesor> ListarProfesor()
        {
            try
            {
                List<Profesor> profesoresEncontrado = new List<Profesor>();
                Profesor profesorEncontrado;
                string sql = "SELECT * FROM TUTOR.PROFESOR";
                using (OracleConnection conexion = new OracleConnection(CadenaConexion))
                {
                    conexion.Open();
                    using (OracleCommand comando = new OracleCommand(sql, conexion))
                    {                        
                        using (OracleDataReader resultado = comando.ExecuteReader())
                        {
                            if (resultado.HasRows)
                            {
                                while (resultado.Read())
                                {
                                    profesorEncontrado = new Profesor()
                                    {
                                        Codigo = Convert.ToString(resultado["COD_PROFESOR"]).Trim(),
                                        Nombre = Convert.ToString(resultado["NOM_PROFESOR"]).Trim(),
                                    };
                                    profesoresEncontrado.Add(profesorEncontrado);
                                }
                            }
                        }
                    }
                    return profesoresEncontrado;
                }
            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
                return null;
            }
        }

        public Seccion ObtenerSeccion(string codigo)
        {
            try
            {
                Seccion seccionEncontrado = null;
                string sql = "SELECT * FROM TUTOR.SECCION WHERE COD_SECCION= :codigo";
                using (OracleConnection conexion = new OracleConnection(CadenaConexion))
                {
                    conexion.Open();
                    using (OracleCommand comando = new OracleCommand(sql, conexion))
                    {
                        comando.Parameters.AddWithValue(":codigo", codigo);
                        using (OracleDataReader resultado = comando.ExecuteReader())
                        {
                            if (resultado.HasRows)
                            {
                                if (resultado.Read())
                                {
                                    seccionEncontrado = new Seccion()
                                    {
                                        Codigo = Convert.ToString(resultado["COD_SECCION"]).Trim(),
                                        Descripcion = Convert.ToString(resultado["NOM_SECCION"]).Trim(),
                                    };
                                }
                            }

                        }
                    }
                    return seccionEncontrado;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<Seccion> ListarSeccion()
        {
            try
            {
                List<Seccion> seccionesEncontrado = new List<Seccion>();
                Seccion seccionEncontrado;
                string sql = "SELECT * FROM TUTOR.SECCION";
                using (OracleConnection conexion = new OracleConnection(CadenaConexion))
                {
                    conexion.Open();
                    using (OracleCommand comando = new OracleCommand(sql, conexion))
                    {
                        using (OracleDataReader resultado = comando.ExecuteReader())
                        {
                            if (resultado.HasRows)
                            {
                                while (resultado.Read())
                                {
                                    seccionEncontrado = new Seccion()
                                    {
                                        Codigo = Convert.ToString(resultado["COD_SECCION"]).Trim(),
                                        Descripcion = Convert.ToString(resultado["NOM_SECCION"]).Trim(),
                                    };
                                    seccionesEncontrado.Add(seccionEncontrado);
                                }
                            }
                        }
                    }
                    return seccionesEncontrado;
                }
            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
                return null;
            }
        }

        public Curso ObtenerCurso(string codigo)
        {
            try
            {
                Curso cursoEncontrado = null;
                string sql = "SELECT * FROM TUTOR.CURSO WHERE COD_CURSO= :codigo";
                using (OracleConnection conexion = new OracleConnection(CadenaConexion))
                {
                    conexion.Open();
                    using (OracleCommand comando = new OracleCommand(sql, conexion))
                    {
                        comando.Parameters.AddWithValue(":codigo", codigo);
                        using (OracleDataReader resultado = comando.ExecuteReader())
                        {
                            if (resultado.HasRows)
                            {
                                if (resultado.Read())
                                {
                                    cursoEncontrado = new Curso()
                                    {
                                        Codigo = Convert.ToString(resultado["COD_CURSO"]).Trim(),
                                        Descripcion = Convert.ToString(resultado["NOM_CURSO"]).Trim(),
                                    };
                                }
                            }

                        }
                    }
                    return cursoEncontrado;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<Curso> ListarCurso()
        {
            try
            {
                List<Curso> cursosEncontrado = new List<Curso>();
                Curso cursoEncontrado;
                string sql = "SELECT * FROM TUTOR.CURSO";
                using (OracleConnection conexion = new OracleConnection(CadenaConexion))
                {
                    conexion.Open();
                    using (OracleCommand comando = new OracleCommand(sql, conexion))
                    {
                        using (OracleDataReader resultado = comando.ExecuteReader())
                        {
                            if (resultado.HasRows)
                            {
                                while (resultado.Read())
                                {
                                    cursoEncontrado = new Curso()
                                    {
                                        Codigo = Convert.ToString(resultado["COD_CURSO"]).Trim(),
                                        Descripcion = Convert.ToString(resultado["NOM_CURSO"]).Trim(),
                                    };
                                    cursosEncontrado.Add(cursoEncontrado);
                                }
                            }
                        }
                    }
                    return cursosEncontrado;
                }
            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
                return null;
            }
        }

        public Alumno ObtenerAlumno(string codigo)
        {
            try
            {
                Alumno cursoEncontrado = null;
                string sql = "SELECT * FROM TUTOR.ALUMNO WHERE COD_ALUMNO= :codigo";
                using (OracleConnection conexion = new OracleConnection(CadenaConexion))
                {
                    conexion.Open();
                    using (OracleCommand comando = new OracleCommand(sql, conexion))
                    {
                        comando.Parameters.AddWithValue(":codigo", codigo);
                        using (OracleDataReader resultado = comando.ExecuteReader())
                        {
                            if (resultado.HasRows)
                            {
                                if (resultado.Read())
                                {
                                    cursoEncontrado = new Alumno()
                                    {
                                        Codigo = Convert.ToString(resultado["COD_ALUMNO"]).Trim(),
                                        Nombre = Convert.ToString(resultado["NOM_ALUMNO"]).Trim() + "  " + Convert.ToString(resultado["APE_ALUMNO"]).Trim(),
                                    };
                                }
                            }

                        }
                    }
                    return cursoEncontrado;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<Alumno> ListarAlumnos()
        {
            try
            {
                List<Alumno> alumnosEncontrado = new List<Alumno>();
                Alumno alumnoEncontrado;
                string sql = "SELECT * FROM TUTOR.ALUMNO";
                using (OracleConnection conexion = new OracleConnection(CadenaConexion))
                {
                    conexion.Open();
                    using (OracleCommand comando = new OracleCommand(sql, conexion))
                    {
                        using (OracleDataReader resultado = comando.ExecuteReader())
                        {
                            if (resultado.HasRows)
                            {
                                while (resultado.Read())
                                {
                                    alumnoEncontrado = new Alumno()
                                    {
                                        Codigo = Convert.ToString(resultado["COD_ALUMNO"]).Trim(),
                                        Nombre = Convert.ToString(resultado["NOM_ALUMNO"]).Trim() + "  " + Convert.ToString(resultado["APE_ALUMNO"]).Trim(),
                                    };
                                    alumnosEncontrado.Add(alumnoEncontrado);
                                }
                            }
                        }
                    }
                    return alumnosEncontrado;
                }
            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
                return null;
            }
        }

    }
}