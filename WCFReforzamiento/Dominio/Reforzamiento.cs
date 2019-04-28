using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFReforzamiento.Dominio
{
    [DataContract]
    public class Reforzamiento
    {

        string _codReforzamiento = "";
        string _horIncio;
        string _horFin;
        int _dia;
        int _duracion;
        DateTime _fecInicio;
        string _objetivo = "";
        string _observacion = "";
        string _codAlumno = "";
        string _codProfesor = "";
        string _codTutor = "";
        string _codCurso = "";
        string _codNivel = "";

        [DataMember]
        public string CodPlan { get; set; }

        [DataMember]
        public string CodReforzamiento
        {
            get { return _codReforzamiento; }
            set { _codReforzamiento = value; }
        }

        [DataMember]
        public string HorarioInicio
        {
            get { return _horIncio; }
            set { _horIncio = value; }
        }

        [DataMember]
        public string HorarioFin
        {
            get { return _horFin; }
            set { _horFin = value; }
        }

        [DataMember]
        public int Dia
        {
            get { return _dia; }
            set { _dia = value; }
        }

        [DataMember]
        public int Duracion
        {
            get { return _duracion; }
            set { _duracion = value; }
        }

        [DataMember]
        public DateTime FechaInicio
        {
            get { return _fecInicio; }
            set { _fecInicio = value; }
        }

        [DataMember]
        public string Objetivo
        {
            get { return _objetivo; }
            set { _objetivo = value; }
        }

        [DataMember]
        public string Observacion
        {
            get { return _observacion; }
            set { _observacion = value; }
        }

        [DataMember]
        public string CodAlumno
        {
            get { return _codAlumno; }
            set { _codAlumno = value; }
        }

        [DataMember]
        public string CodProfesor
        {
            get { return _codProfesor; }
            set { _codProfesor = value; }
        }

        [DataMember]
        public string CodTutor
        {
            get { return _codTutor; }
            set { _codTutor = value; }
        }

        [DataMember]
        public string CodCurso
        {
            get { return _codCurso; }
            set { _codCurso = value; }
        }

        [DataMember]
        public string CodNivel
        {
            get { return _codNivel; }
            set { _codNivel = value; }
        }

        [DataMember]
        public string MensajeRespuesta { get; set; }
        [DataMember]
        public string Error { get; set; }

    }

}