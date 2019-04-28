using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFTrabajo.Dominio
{
    [DataContract]
    public class Trabajo
    {
        [DataMember]
        public string IdTrabajo { get; set; }
        [DataMember]
        public string IdPlan { get; set; }
        [DataMember]
        public decimal NotaTrabajo { get; set; }
        [DataMember]
        public string Observacion { get; set; }
        [DataMember]
        public string IdAlumno { get; set; }
        [DataMember]
        public string IdProfesor { get; set; }
        [DataMember]
        public string IdSeccion { get; set; }
        [DataMember]
        public string IdCurso { get; set; }
        [DataMember]
        public DateTime FechaGrabacion { get; set; }
    }
}