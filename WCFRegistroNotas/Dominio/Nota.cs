using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFRegistroNotas.Dominio
{
    [DataContract]
    public class Nota
    {
        [DataMember]
        public string CodNota { get; set; }

        [DataMember]
        public decimal Nota1 { get; set; }
        [DataMember]
        public decimal Nota2 { get; set; }
        [DataMember]
        public decimal Nota3 { get; set; }
        [DataMember]
        public decimal Promedio { get; set; }
        [DataMember]
        public string Alumno { get; set; }
        [DataMember]
        public string Curso { get; set; }

    }
}