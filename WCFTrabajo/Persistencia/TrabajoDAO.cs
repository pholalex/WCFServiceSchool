using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using WCFTrabajo.Dominio;

namespace WCFTrabajo.Persistencia
{   
    public class TrabajoDAO
    {
        private string CadenaConexion = "DATA SOURCE=xe;PASSWORD=oracle; USER ID=tutor;";

        public List<Trabajo> Listar()
        {
            try
            {
                List<Trabajo> trabajosEncontrados = new List<Trabajo>();
                Trabajo trabajoEncontrado;
                string sql = "SELECT * FROM TUTOR.TRABAJO";
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
                                    trabajoEncontrado = new Trabajo()
                                    {
                                        IdTrabajo = Convert.ToString(resultado["COD_TRABAJO"]),
                                        IdPlan = Convert.ToString(resultado["COD_PLAN"]),
                                        IdProfesor = Convert.ToString(resultado["COD_PROFESOR"]),
                                        IdAlumno = Convert.ToString(resultado["COD_ALUMNO"]),
                                        IdCurso = Convert.ToString(resultado["COD_CURSO"]),
                                        Observacion = Convert.ToString(resultado["OBSERVACION"]),
                                        IdSeccion = Convert.ToString(resultado["COD_SECCION"]),
                                        NotaTrabajo = Convert.ToDecimal(resultado["NOTA_TRABAJO"]),
                                        FechaGrabacion = Convert.ToDateTime(resultado["FEC_GRABACION"])
                                    };
                                    trabajosEncontrados.Add(trabajoEncontrado);
                                }
                            }

                        }
                    }
                }
                return trabajosEncontrados;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Trabajo Obtener(string IdTrabajo) {
            Trabajo trabajoEncontrado = null;
            string sql = "SELECT * FROM TUTOR.TRABAJO WHERE COD_TRABAJO = :IdTrabajo";
            using (OracleConnection conexion = new OracleConnection(CadenaConexion))
            {
                conexion.Open();
                using (OracleCommand comando = new OracleCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue(":IdTrabajo", IdTrabajo);
                    using (OracleDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.HasRows)
                        {
                            if (resultado.Read())
                            {
                                trabajoEncontrado = new Trabajo()
                                {
                                    IdTrabajo = Convert.ToString(resultado["COD_TRABAJO"]),                                   
                                    IdPlan = Convert.ToString(resultado["COD_PLAN"]),
                                    IdProfesor = Convert.ToString(resultado["COD_PROFESOR"]),
                                    IdAlumno = Convert.ToString(resultado["COD_ALUMNO"]),
                                    IdCurso = Convert.ToString(resultado["COD_CURSO"]),
                                    Observacion = Convert.ToString(resultado["OBSERVACION"]),
                                    IdSeccion = Convert.ToString(resultado["COD_SECCION"]),
                                    NotaTrabajo = Convert.ToDecimal(resultado["NOTA_TRABAJO"]),                                    
                                    FechaGrabacion = Convert.ToDateTime(resultado["FEC_GRABACION"])
                                };
                            }
                        }

                    }
                }

            }
             return trabajoEncontrado;
        }

        public Trabajo Crear(Trabajo trabajoACrear) {
            Trabajo trabajoCreado = null;
            string sql = "INSERT INTO TUTOR.TRABAJO VALUES(:IdTrabajo, :IdPlan, :NotaTrabajo, :Observacion, :CodAlumno, :CodProfesor, :CodSeccion, :CodCurso, TO_DATE(:FechaRegistro,'DD/MM/YYYY HH:MI:SS AM'))";
            using (OracleConnection conexion = new OracleConnection(CadenaConexion))
            {

                using (OracleCommand comando = new OracleCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue(":IdTrabajo", trabajoACrear.IdTrabajo);
                    comando.Parameters.AddWithValue(":IdPlan", trabajoACrear.IdPlan);
                    comando.Parameters.AddWithValue(":NotaTrabajo", trabajoACrear.NotaTrabajo);
                    comando.Parameters.AddWithValue(":Observacion", trabajoACrear.Observacion);
                    comando.Parameters.AddWithValue(":CodAlumno", trabajoACrear.IdAlumno);
                    comando.Parameters.AddWithValue(":CodProfesor", trabajoACrear.IdProfesor);
                    comando.Parameters.AddWithValue(":CodSeccion", trabajoACrear.IdSeccion);
                    comando.Parameters.AddWithValue(":CodCurso", trabajoACrear.IdCurso);
                    comando.Parameters.AddWithValue(":FechaRegistro", trabajoACrear.FechaGrabacion);
                    try
                    {
                        conexion.Open();
                        var executeResult = comando.ExecuteNonQuery();
                        trabajoCreado = Obtener(trabajoACrear.IdTrabajo);
                        return trabajoCreado;
                    }
                    catch (Exception eMess)
                    {
                        eMess.Message.ToString();
                        return null;
                    }
                    finally
                    {
                        conexion.Close();
                    }

                }
            }                  
        }


        public Trabajo Modificar(Trabajo trabajoAmodificar)
        {

            Trabajo planModificado = null;
            string sql = "UPDATE TUTOR.TRABAJO SET COD_PROFESOR=:IdProfesor, OBSERVACION = :ObservacionTrabajo, NOTA_TRABAJO=:NotaTrabajo WHERE COD_TRABAJO = :IdTrabajo AND COD_PLAN=:COD_PLAN";
            using (OracleConnection conexion = new OracleConnection(CadenaConexion))
            {
                conexion.Open();
                using (OracleCommand comando = new OracleCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue(":COD_PLAN", trabajoAmodificar.IdPlan);
                    comando.Parameters.AddWithValue(":IdTrabajo", trabajoAmodificar.IdTrabajo);
                    comando.Parameters.AddWithValue(":IdProfesor", trabajoAmodificar.IdProfesor);
                    comando.Parameters.AddWithValue(":ObservacionTrabajo", trabajoAmodificar.Observacion);
                    comando.Parameters.AddWithValue(":NotaTrabajo", trabajoAmodificar.NotaTrabajo);                    
                    var executeResult = comando.ExecuteNonQuery();
                }
            }
            planModificado = Obtener(trabajoAmodificar.IdTrabajo);
            return planModificado;

        }


        public string Eliminar(string idTrabajo)
        {
            string sql = "DELETE FROM TUTOR.TRABAJO WHERE COD_TRABAJO = :IdTrabajo";
            try
            {
                using (OracleConnection conexion = new OracleConnection(CadenaConexion))
                {
                    conexion.Open();
                    using (OracleCommand comando = new OracleCommand(sql, conexion))
                    {
                        comando.Parameters.AddWithValue(":IdTrabajo", idTrabajo);
                        comando.ExecuteNonQuery();
                    }
                }
                return "Se eliminó correctamente";
            }
            catch (Exception ex)
            {

                return ex.StackTrace.ToString();                
            }
        }


        public NotaExtra RegistrarNota(NotaExtra nota)
        {
            NotaExtra NotaCreada = null;
            string sql = "INSERT INTO TUTOR.NOTASREFORZAMIENTO (COD_REFORZAMIENTO, COD_TRABAJO, NOTA_1, NOTA_2, NOTA_3,PROMEDIO_REFORZAMIENTO,TIPO_NOTA,DETALLE_REFORZAMIENTO) VALUES(:COD_REFORZAMIENTO, :COD_TRABAJO, :NOTA_1, :NOTA_2, :NOTA_3,:PROMEDIO_REFORZAMIENTO,:TIPO_NOTA,:DETALLE_REFORZAMIENTO)";
            using (OracleConnection conexion = new OracleConnection(CadenaConexion))
            {

                conexion.Open();
                decimal notaFinal = nota.nota1;
                using (OracleCommand comando = new OracleCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue(":COD_REFORZAMIENTO", "");
                    comando.Parameters.AddWithValue(":COD_TRABAJO", nota.codtrabajo);
                    comando.Parameters.AddWithValue(":NOTA_1", notaFinal);
                    comando.Parameters.AddWithValue(":NOTA_2", 0);
                    comando.Parameters.AddWithValue(":NOTA_3", 0);
                    comando.Parameters.AddWithValue(":PROMEDIO_REFORZAMIENTO", notaFinal);
                    comando.Parameters.AddWithValue(":TIPO_NOTA", nota.tiponota);
                    comando.Parameters.AddWithValue(":DETALLE_REFORZAMIENTO", nota.descripcion);


                    var executeResult = comando.ExecuteNonQuery();
                    NotaCreada = ObtenerNota(nota.codreforzamiento);
                    return NotaCreada;

                }
            }
        }

        public NotaExtra ModificarNota(NotaExtra nota)
        {
            NotaExtra NotaCreada = null;
            string sql = "UPDATE TUTOR.NOTASREFORZAMIENTO SET NOTA_1=:NOTA_1,DETALLE_REFORZAMIENTO=:DETALLE_REFORZAMIENTO, PROMEDIO_REFORZAMIENTO=:PROMEDIO_REFORZAMIENTO WHERE COD_TRABAJO=:COD_TRABAJO AND TIPO_NOTA='2'";
            decimal promedio = nota.nota1;
            using (OracleConnection conexion = new OracleConnection(CadenaConexion))
            {

                conexion.Open();
                using (OracleCommand comando = new OracleCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue(":COD_TRABAJO", nota.codtrabajo);
                    comando.Parameters.AddWithValue(":NOTA_1", nota.nota1);                    
                    comando.Parameters.AddWithValue(":PROMEDIO_REFORZAMIENTO", promedio);
                    comando.Parameters.AddWithValue(":DETALLE_REFORZAMIENTO", nota.descripcion);


                    var executeResult = comando.ExecuteNonQuery();
                    NotaCreada = ObtenerNota(nota.codreforzamiento);
                    return NotaCreada;

                }
            }
        }

        public NotaExtra ObtenerNota(string codtrabajo)
        {

            try
            {
                NotaExtra notaEncontrada = null;
                string sql = "SELECT * FROM TUTOR.notasreforzamiento WHERE COD_TRABAJO= :codtrabajo and TIPO_NOTA=2";
                using (OracleConnection conexion = new OracleConnection(CadenaConexion))
                {
                    conexion.Open();
                    using (OracleCommand comando = new OracleCommand(sql, conexion))
                    {
                        comando.Parameters.AddWithValue(":codtrabajo", codtrabajo);
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
                                        descripcion = Convert.ToString(resultado["DETALLE_REFORZAMIENTO"])

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







    }
}