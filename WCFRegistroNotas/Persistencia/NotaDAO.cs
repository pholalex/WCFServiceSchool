using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using WCFRegistroNotas.Dominio;

namespace WCFRegistroNotas.Persistencia
{
    public class NotaDAO
    {
        private string CadenaConexion = "DATA SOURCE=xe;PASSWORD=oracle; USER ID=tutor;";

        public Nota RegistrarNota(Nota nota)
        {
            Nota NotaCreada = null;
            string sql = "INSERT INTO TUTOR.NOTA (COD_NOTA, NOTA1, NOTA2, NOTA3,PROMEDIO,COD_ALUMNO,COD_CURSO) VALUES(:CodNota, :NOTA_1, :NOTA_2, :NOTA_3,:PROMEDIO,:COD_ALUMNO,:COD_CURSO)";
            using (OracleConnection conexion = new OracleConnection(CadenaConexion))
            {

                conexion.Open();
                using (OracleCommand comando = new OracleCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue(":CodNota", nota.CodNota);                    
                    comando.Parameters.AddWithValue(":NOTA_1", nota.Nota1);
                    comando.Parameters.AddWithValue(":NOTA_2", nota.Nota2);
                    comando.Parameters.AddWithValue(":NOTA_3", nota.Nota3);
                    comando.Parameters.AddWithValue(":PROMEDIO", nota.Promedio);
                    comando.Parameters.AddWithValue(":COD_ALUMNO", nota.Alumno);
                    comando.Parameters.AddWithValue(":COD_CURSO", nota.Curso);


                    var executeResult = comando.ExecuteNonQuery();
                    NotaCreada = ObtenerNota(nota.CodNota);
                    return NotaCreada;

                }
            }
        }

        public Nota ObtenerNota(string codnota)
        {

            try
            {
                Nota notaEncontrada = null;
                string sql = "SELECT * FROM TUTOR.NOTA WHERE COD_NOTA= :codnota";
                using (OracleConnection conexion = new OracleConnection(CadenaConexion))
                {
                    conexion.Open();
                    using (OracleCommand comando = new OracleCommand(sql, conexion))
                    {
                        comando.Parameters.AddWithValue(":codnota", codnota);
                        using (OracleDataReader resultado = comando.ExecuteReader())
                        {
                            if (resultado.HasRows)
                            {
                                if (resultado.Read())
                                {
                                    return notaEncontrada = new Nota()
                                    {
                                        CodNota = Convert.ToString(resultado["COD_NOTA"]),                                        
                                        Nota1 = Convert.ToDecimal(resultado["NOTA1"]),
                                        Nota2 = Convert.ToDecimal(resultado["NOTA2"]),
                                        Nota3 = Convert.ToDecimal(resultado["NOTA3"]),
                                        Promedio = Convert.ToDecimal(resultado["PROMEDIO"]),
                                        Alumno = Convert.ToString(resultado["COD_ALUMNO"]),
                                        Curso= Convert.ToString(resultado["COD_CURSO"])

                                    };
                                }
                            }

                        }
                    }
                    return notaEncontrada;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Nota> ListarNota()
        {
            try
            {
                List<Nota> notasEncontrado = new List<Nota>();
                Nota notaEncontrada;
                string sql = "SELECT * FROM TUTOR.NOTA";
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
                                    notaEncontrada = new Nota()
                                    {
                                        CodNota = Convert.ToString(resultado["COD_NOTA"]),
                                        Nota1 = Convert.ToDecimal(resultado["NOTA1"]),
                                        Nota2= Convert.ToDecimal(resultado["NOTA2"]),
                                        Nota3= Convert.ToDecimal(resultado["NOTA3"]),
                                        Alumno = Convert.ToString(resultado["COD_ALUMNO"]),
                                        Curso = Convert.ToString(resultado["COD_CURSO"]),
                                        Promedio = Convert.ToDecimal(resultado["PROMEDIO"])                                        
                                    };
                                    notasEncontrado.Add(notaEncontrada);
                                }
                            }

                        }
                    }
                }
                return notasEncontrado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string ObtenerSecuencial() {
            try
            {
                string resultCad = "";
                string sql = "SELECT MAX(COD_NOTA) AS SECUENCIAL FROM TUTOR.NOTA";
                using (OracleConnection conexion = new OracleConnection(CadenaConexion))
                {
                    conexion.Open();
                    using (OracleCommand comando = new OracleCommand(sql, conexion))
                    {                        
                        using (OracleDataReader resultado = comando.ExecuteReader())
                        {
                            if (resultado.HasRows)
                            {
                                if (resultado.Read())
                                {
                                    resultCad = Convert.ToString(resultado["SECUENCIAL"]);
                               
                                }
                            }

                        }
                    }
                    return resultCad;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}