using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WCFPlanRecuperacion.Dominio;

namespace WCFPlanRecuperacion.Persistencia
{
    public class PlanRecuperacionDAO
    {
        private string CadenaConexion = "DATA SOURCE=xe;PASSWORD=oracle; USER ID=tutor;";

        public PlanRecuperacion Crear(PlanRecuperacion planAcrear)
        {
            PlanRecuperacion planCreado = null;
            string sql = "INSERT INTO TUTOR.PLANRECUPERACION VALUES(:IdPlan, :IdProfesor, :IdAlumno, :IdCurso, :IdSeccion, :DescripcionPlan, :ActivarReforzamiento, :ActivarTrabajo, TO_DATE(:FechaRegistro,'DD/MM/YYYY'))";            
            using (OracleConnection conexion = new OracleConnection(CadenaConexion))
            {

                conexion.Open();
                using (OracleCommand comando = new OracleCommand(sql, conexion))
                {                    
                    comando.Parameters.AddWithValue(":IdPlan", planAcrear.IdPlan);
                    comando.Parameters.AddWithValue(":IdProfesor", planAcrear.IdProfesor);
                    comando.Parameters.AddWithValue(":IdAlumno", planAcrear.IdAlumno);
                    comando.Parameters.AddWithValue(":IdCurso", planAcrear.IdCurso);
                    comando.Parameters.AddWithValue(":IdSeccion", planAcrear.IdSeccion);
                    comando.Parameters.AddWithValue(":DescripcionPlan", planAcrear.DescripcionPlan);
                    comando.Parameters.AddWithValue(":ActivarReforzamiento", planAcrear.ActivarReforzamiento);
                    comando.Parameters.AddWithValue(":ActivarTrabajo", planAcrear.ActivarTrabajo);
                    comando.Parameters.AddWithValue(":FechaRegistro", DateTime.Now);
                        
                    var executeResult = comando.ExecuteNonQuery();
                    planCreado = Obtener(planAcrear.IdPlan);
                    return planCreado;
                                          
                }
            }
        }

        public PlanRecuperacion Obtener(string idPlan)
        {
            try
            {
                PlanRecuperacion planEncontrado = null;
                string sql = "SELECT * FROM TUTOR.PLANRECUPERACION WHERE COD_PLAN= :IdPlan";
                using (OracleConnection conexion = new OracleConnection(CadenaConexion))
                {
                    conexion.Open();
                    using (OracleCommand comando = new OracleCommand(sql, conexion))
                    {
                        comando.Parameters.AddWithValue(":IdPlan", idPlan);
                        using (OracleDataReader resultado = comando.ExecuteReader())
                        {
                            if (resultado.HasRows)
                            {
                                if (resultado.Read())
                                {
                                    planEncontrado = new PlanRecuperacion()
                                    {
                                        IdPlan = Convert.ToString(resultado["COD_PLAN"]),
                                        IdProfesor = Convert.ToString(resultado["COD_PROFESOR"]),
                                        IdAlumno = Convert.ToString(resultado["COD_ALUMNO"]),
                                        IdCurso = Convert.ToString(resultado["COD_CURSO"]),
                                        DescripcionPlan = Convert.ToString(resultado["DESCRIPCION"]),
                                        IdSeccion = Convert.ToString(resultado["COD_SECCION"]),
                                        ActivarReforzamiento = Convert.ToInt32(resultado["CHK_REFORZAMIENTO"]),
                                        ActivarTrabajo = Convert.ToInt32(resultado["CHK_TRABAJO"]),
                                        FechaRegistro = Convert.ToDateTime(resultado["FEC_REGISTRO"]) 
                                    };
                                }
                            }
                            
                        }
                    }
                    return planEncontrado;
                }
            }
            catch (Exception ex)
            {                        
                throw ex;
            }           

        }

        public PlanRecuperacion Modificar(PlanRecuperacion planAmodificar)
        {

            PlanRecuperacion planModificado = null;
            string sql = "UPDATE TUTOR.PLANRECUPERACION SET COD_Curso=:IdCurso, DESCRIPCION = :DescripcionPlan, CHK_REFORZAMIENTO=:ActivarReforzamiento, CHK_TRABAJO=:ActivarTrabajo WHERE COD_PLAN = :IdPlan";
            using (OracleConnection conexion = new OracleConnection(CadenaConexion))
            {
                conexion.Open();
                using (OracleCommand comando = new OracleCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue(":IdPlan", planAmodificar.IdPlan);
                    comando.Parameters.AddWithValue(":IdCurso", planAmodificar.IdCurso);                    
                    comando.Parameters.AddWithValue(":DescripcionPlan", planAmodificar.DescripcionPlan);
                    comando.Parameters.AddWithValue(":ActivarReforzamiento", planAmodificar.ActivarReforzamiento);
                    comando.Parameters.AddWithValue(":ActivarTrabajo", planAmodificar.ActivarTrabajo);                  
                    var executeResult = comando.ExecuteNonQuery();
                }
            }
            planModificado = Obtener(planAmodificar.IdPlan);
            return planModificado;

        }

        public void Eliminar(string idPlan)
        {
            string sql = "DELETE FROM TUTOR.PLANRECUPERACION WHERE COD_PLAN = :IdPlan";
            using (OracleConnection conexion = new OracleConnection(CadenaConexion))
            {
                conexion.Open();
                using (OracleCommand comando = new OracleCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue(":IdPlan", idPlan);
                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<PlanRecuperacion> ListarPlanRecuperacion()
        {
            try
            {
                List<PlanRecuperacion> planesEncontrados = new List<PlanRecuperacion>();
                PlanRecuperacion planEncontrado;
                string sql = "SELECT * FROM TUTOR.PLANRECUPERACION";
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
                                    planEncontrado = new PlanRecuperacion()
                                    {
                                        IdPlan = Convert.ToString(resultado["COD_PLAN"]),
                                        IdProfesor = Convert.ToString(resultado["COD_PROFESOR"]),
                                        IdAlumno = Convert.ToString(resultado["COD_ALUMNO"]),
                                        IdCurso = Convert.ToString(resultado["COD_CURSO"]),
                                        DescripcionPlan = Convert.ToString(resultado["DESCRIPCION"]),
                                        ActivarReforzamiento = Convert.ToInt32(resultado["CHK_REFORZAMIENTO"]),
                                        ActivarTrabajo = Convert.ToInt32(resultado["CHK_TRABAJO"]),
                                        FechaRegistro = Convert.ToDateTime(resultado["FEC_REGISTRO"])
                                    };
                                    planesEncontrados.Add(planEncontrado);
                                }
                            }

                        }
                    }                    
                }
                return planesEncontrados;
            }
            catch (Exception ex)
            {
                throw ex;
            }        
        }
    }
}