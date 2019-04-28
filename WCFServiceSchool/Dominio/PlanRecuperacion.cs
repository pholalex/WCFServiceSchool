using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFPlanRecuperacion.Dominio
{
    [DataContract]
    public class PlanRecuperacion
    {
        [DataMember]
        public string IdPlan { get; set; }
        [DataMember]
        public string IdProfesor { get; set; }
        [DataMember]
        public string IdAlumno { get; set; }
        [DataMember]
        public string IdCurso { get; set; }
        [DataMember]
        public string IdSeccion { get; set; }
        [DataMember]
        public string DescripcionPlan { get; set; }
        [DataMember]
        public int ActivarReforzamiento { get; set; }
        [DataMember]
        public int ActivarTrabajo { get; set; }
        [DataMember]
        public DateTime FechaRegistro { get; set; }
    }
}