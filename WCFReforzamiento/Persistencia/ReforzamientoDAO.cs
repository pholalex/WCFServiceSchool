using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;
using System.Web;
using WCFReforzamiento.Dominio;
using System.Data;

namespace WCFReforzamiento.Persistencia
{
    public class ReforzamientoDAO
    {
        private string CadenaConexion = "DATA SOURCE=xe;PASSWORD=oracle; USER ID=tutor;";

        public Reforzamiento CrearReforzamiento(Reforzamiento refor)
        {
            Reforzamiento reforzamientoCreado = null;
            string sql = "INSERT INTO TUTOR.Reforzamiento (cod_Reforzamiento, COD_PLAN, hor_Inicio, hor_Fin, dia, duracion, fec_inicio, objetivo, observacion, cod_alumno, cod_profesor, cod_curso, fec_grabacion) VALUES(:p_cod_Reforzamiento, :p_COD_PLAN, :p_hor_Inicio, :p_hor_Fin, :p_dia, :p_duracion, TO_DATE(:p_fec_inicio,'DD/MM/YYYY'), :p_objetivo, :p_observacion, :p_cod_alumno, :p_cod_profesor, :p_cod_curso, TO_DATE(:FechaRegistro,'DD/MM/YYYY'))";

            using (OracleConnection conexion = new OracleConnection(CadenaConexion))
            {

                conexion.Open();
                using (OracleCommand comando = new OracleCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue(":p_cod_Reforzamiento", refor.CodReforzamiento);
                    comando.Parameters.AddWithValue(":p_COD_PLAN", refor.CodPlan);
                    comando.Parameters.AddWithValue(":p_hor_Inicio", refor.HorarioInicio);
                    comando.Parameters.AddWithValue(":p_hor_Fin", refor.HorarioFin);
                    comando.Parameters.AddWithValue(":p_dia", refor.Dia);
                    comando.Parameters.AddWithValue(":p_duracion", refor.Duracion);
                    comando.Parameters.AddWithValue(":p_fec_inicio", refor.FechaInicio);
                    comando.Parameters.AddWithValue(":p_objetivo", refor.Objetivo);
                    comando.Parameters.AddWithValue(":p_observacion", refor.Observacion);
                    comando.Parameters.AddWithValue(":p_cod_alumno", refor.CodAlumno);
                    comando.Parameters.AddWithValue(":p_cod_profesor", refor.CodProfesor);
                    comando.Parameters.AddWithValue(":p_cod_curso", refor.CodCurso);
                    comando.Parameters.AddWithValue(":FechaRegistro", DateTime.Now);

                    var executeResult = comando.ExecuteNonQuery();
                    reforzamientoCreado = ObtenerReforzamiento(refor.CodReforzamiento);
                    return reforzamientoCreado;

                }
            }
        }

        public Reforzamiento ObtenerReforzamiento(string p_cod_reforzamiento)
        {
            try
            {
                Reforzamiento reforzamientoEncontrado = null;
                string sql = "SELECT * FROM TUTOR.REFORZAMIENTO WHERE cod_Reforzamiento= :p_cod_reforzamiento";
                using (OracleConnection conexion = new OracleConnection(CadenaConexion))
                {
                    conexion.Open();
                    using (OracleCommand comando = new OracleCommand(sql, conexion))
                    {
                        comando.Parameters.AddWithValue(":p_cod_reforzamiento", p_cod_reforzamiento);
                        using (OracleDataReader resultado = comando.ExecuteReader())
                        {
                            if (resultado.HasRows)
                            {
                                if (resultado.Read())
                                {
                                    return reforzamientoEncontrado = new Reforzamiento()
                                    {
                                        CodReforzamiento = Convert.ToString(resultado["cod_Reforzamiento"]),
                                        CodPlan = Convert.ToString(resultado["COD_PLAN"]),
                                        HorarioInicio = Convert.ToString(resultado["HOR_INICIO"]),
                                        HorarioFin = Convert.ToString(resultado["HOR_FIN"]),
                                        Dia = Convert.ToInt32(resultado["DIA"]),
                                        FechaInicio = Convert.ToDateTime(resultado["FEC_INICIO"]),
                                        CodAlumno = Convert.ToString(resultado["COD_ALUMNO"]),
                                        CodProfesor = Convert.ToString(resultado["COD_PROFESOR"]),
                                        CodCurso = Convert.ToString(resultado["COD_CURSO"]),
                                        Duracion = Convert.ToInt32(resultado["DURACION"]),
                                        Objetivo = Convert.ToString(resultado["OBJETIVO"]),
                                        Observacion = Convert.ToString(resultado["OBSERVACION"])                                                                                

                                    };
                                }
                            }

                        }
                    }
                    return reforzamientoEncontrado;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public List<Reforzamiento> ListarReforzamiento()
        {
            try
            {
                List<Reforzamiento> reforzamientosEncontrado = new List<Reforzamiento>();
                Reforzamiento reforzamientoEncontrado;
                string sql = "SELECT * FROM TUTOR.REFORZAMIENTO";
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
                                    reforzamientoEncontrado = new Reforzamiento()
                                    {
                                        CodReforzamiento = Convert.ToString(resultado["cod_Reforzamiento"]),
                                        CodPlan = Convert.ToString(resultado["COD_PLAN"]),
                                        HorarioInicio = Convert.ToString(resultado["HOR_INICIO"]),
                                        HorarioFin = Convert.ToString(resultado["HOR_FIN"]),
                                        Dia = Convert.ToInt32(resultado["DIA"]),
                                        FechaInicio = Convert.ToDateTime(resultado["FEC_INICIO"]),
                                        CodAlumno = Convert.ToString(resultado["COD_ALUMNO"]),
                                        CodProfesor = Convert.ToString(resultado["COD_PROFESOR"]),
                                        CodCurso = Convert.ToString(resultado["COD_CURSO"]),
                                        Duracion = Convert.ToInt32(resultado["DURACION"]),
                                        Objetivo = Convert.ToString(resultado["OBJETIVO"]),
                                        Observacion = Convert.ToString(resultado["OBSERVACION"])
                                    };
                                    reforzamientosEncontrado.Add(reforzamientoEncontrado);
                                }
                            }

                        }
                    }
                }
                return reforzamientosEncontrado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public NotaExtra RegistrarNota(NotaExtra nota)
        {
            NotaExtra NotaCreada = null;            
            string sql = "INSERT INTO TUTOR.NOTASREFORZAMIENTO (COD_REFORZAMIENTO, COD_TRABAJO, NOTA_1, NOTA_2, NOTA_3,PROMEDIO_REFORZAMIENTO,TIPO_NOTA,DETALLE_REFORZAMIENTO) VALUES(:COD_REFORZAMIENTO, :COD_TRABAJO, :NOTA_1, :NOTA_2, :NOTA_3,:PROMEDIO_REFORZAMIENTO,:TIPO_NOTA,:DETALLE_REFORZAMIENTO)";            
            using (OracleConnection conexion = new OracleConnection(CadenaConexion))
            {

                conexion.Open();
                using (OracleCommand comando = new OracleCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue(":COD_REFORZAMIENTO", nota.codreforzamiento);
                    comando.Parameters.AddWithValue(":COD_TRABAJO", "");
                    comando.Parameters.AddWithValue(":NOTA_1", nota.nota1);
                    comando.Parameters.AddWithValue(":NOTA_2", nota.nota2);
                    comando.Parameters.AddWithValue(":NOTA_3", nota.nota3);
                    comando.Parameters.AddWithValue(":PROMEDIO_REFORZAMIENTO", (nota.nota1+nota.nota2+nota.nota3)/3);
                    comando.Parameters.AddWithValue(":TIPO_NOTA", nota.tiponota);
                    comando.Parameters.AddWithValue(":DETALLE_REFORZAMIENTO", nota.detallereforzamiento);
                    

                    var executeResult = comando.ExecuteNonQuery();
                    NotaCreada = ObtenerNota(nota.codreforzamiento);
                    return NotaCreada;

                }
            }
        }

        public NotaExtra ModificarNota(NotaExtra nota)
        {
            NotaExtra NotaCreada = null;
            string sql = "UPDATE TUTOR.NOTASREFORZAMIENTO SET NOTA_1=:NOTA_1, NOTA_2=:NOTA_2, NOTA_3=:NOTA_3, DETALLE_REFORZAMIENTO=:DETALLE_REFORZAMIENTO, PROMEDIO_REFORZAMIENTO=:PROMEDIO_REFORZAMIENTO WHERE COD_REFORZAMIENTO=:COD_REFORZAMIENTO AND TIPO_NOTA='1'";
            decimal promedio = (nota.nota1 + nota.nota2 + nota.nota3) / 3;
            using (OracleConnection conexion = new OracleConnection(CadenaConexion))
            {

                conexion.Open();
                using (OracleCommand comando = new OracleCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue(":COD_REFORZAMIENTO", nota.codreforzamiento);                    
                    comando.Parameters.AddWithValue(":NOTA_1", nota.nota1);
                    comando.Parameters.AddWithValue(":NOTA_2", nota.nota2);
                    comando.Parameters.AddWithValue(":NOTA_3", nota.nota3);
                    comando.Parameters.AddWithValue(":PROMEDIO_REFORZAMIENTO", promedio);
                    comando.Parameters.AddWithValue(":DETALLE_REFORZAMIENTO", nota.detallereforzamiento);


                    var executeResult = comando.ExecuteNonQuery();
                    NotaCreada = ObtenerNota(nota.codreforzamiento);
                    return NotaCreada;

                }
            }
        }

        public NotaExtra ObtenerNota(string codreforzamiento)
        {

            try
            {
                NotaExtra notaEncontrada = null;
                string sql = "SELECT * FROM TUTOR.notasreforzamiento WHERE COD_REFORZAMIENTO= :codreforzamiento and TIPO_NOTA=1";
                using (OracleConnection conexion = new OracleConnection(CadenaConexion))
                {
                    conexion.Open();
                    using (OracleCommand comando = new OracleCommand(sql, conexion))
                    {
                        comando.Parameters.AddWithValue(":codreforzamiento", codreforzamiento);
                        using (OracleDataReader resultado = comando.ExecuteReader())
                        {
                            if (resultado.HasRows)
                            {
                                if (resultado.Read())
                                {
                                    return notaEncontrada = new NotaExtra()
                                    {
                                        codreforzamiento = Convert.ToString(resultado["COD_REFORZAMIENTO"]),
                                        codtrabajo = Convert.ToString(resultado["COD_TRABAJO"]),
                                        nota1 = Convert.ToDecimal(resultado["NOTA_1"]),
                                        nota2 = Convert.ToDecimal(resultado["NOTA_2"]),
                                        nota3 = Convert.ToDecimal(resultado["NOTA_3"]),
                                        promedio = Convert.ToDecimal(resultado["PROMEDIO_REFORZAMIENTO"]),
                                        tiponota = Convert.ToString(resultado["TIPO_NOTA"]),
                                        detallereforzamiento = Convert.ToString(resultado["DETALLE_REFORZAMIENTO"])                                        

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

        public string ObtenerSecuencial()
        {
            try
            {
                string resultCad = "";
                string sql = "SELECT MAX(COD_REFORZAMIENTO) AS SECUENCIAL FROM TUTOR.NOTASREFORZAMIENTO WHERE TIPO_NOTA=1";
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

        public List<NotaExtra> ListarNota()
        {
            try
            {
                List<NotaExtra> notasEncontrado = new List<NotaExtra>();
                NotaExtra notaEncontrada;
                string sql = "SELECT * FROM TUTOR.NOTASREFORZAMIENTO  WHERE TIPO_NOTA=1";
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
                                    notaEncontrada = new NotaExtra()
                                    {
                                        codreforzamiento = Convert.ToString(resultado["COD_REFORZAMIENTO"]),
                                        nota1 = Convert.ToDecimal(resultado["NOTA_1"]),
                                        nota2 = Convert.ToDecimal(resultado["NOTA_2"]),
                                        nota3 = Convert.ToDecimal(resultado["NOTA_3"]),
                                        detallereforzamiento = Convert.ToString(resultado["DETALLE_REFORZAMIENTO"]),                                        
                                        promedio = Convert.ToDecimal(resultado["PROMEDIO_REFORZAMIENTO"])
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

    }
}