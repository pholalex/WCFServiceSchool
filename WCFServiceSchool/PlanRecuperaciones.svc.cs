using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFPlanRecuperacion.Dominio;
using WCFPlanRecuperacion.Persistencia;

namespace WCFPlanRecuperacion
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "PlanRecuperaciones" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione PlanRecuperaciones.svc o PlanRecuperaciones.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class PlanRecuperaciones : IPlanRecuperaciones
    {
        private PlanRecuperacionDAO planRecuperacionDAO = new PlanRecuperacionDAO();
        public PlanRecuperacion CrearPlan(PlanRecuperacion planACrear)
        {
            return planRecuperacionDAO.Crear(planACrear);
        }

        public void EliminarPlan(string IdPlan)
        {
            planRecuperacionDAO.Eliminar(IdPlan);
        }

        public List<PlanRecuperacion> ListarPlanRecuperacion()
        {
            return planRecuperacionDAO.ListarPlanRecuperacion();
        }

        public PlanRecuperacion ModificarPlan(PlanRecuperacion planAModificar)
        {
            return planRecuperacionDAO.Modificar(planAModificar);
        }

        public PlanRecuperacion ObtenerPlan(string IdPlan)
        {
            return planRecuperacionDAO.Obtener(IdPlan);
        }
    }
}
