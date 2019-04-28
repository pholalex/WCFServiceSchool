using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFPlanRecuperacion.Dominio;

namespace WCFPlanRecuperacion
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IPlanRecuperaciones" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IPlanRecuperaciones
    {        
        [OperationContract]
        PlanRecuperacion CrearPlan(PlanRecuperacion planACrear);

        [OperationContract]
        PlanRecuperacion ObtenerPlan(string IdPlan);

        [OperationContract]
        PlanRecuperacion ModificarPlan(PlanRecuperacion planAModificar);

        [OperationContract]
        void EliminarPlan(string IdPlan);

        [OperationContract]
        List<PlanRecuperacion> ListarPlanRecuperacion();
    }
}
