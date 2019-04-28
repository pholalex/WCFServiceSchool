using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFReforzamiento.Dominio
{
    [DataContract]
    public class NotaExtra
    {
        [DataMember]
        public string codreforzamiento { get; set; }
        [DataMember]
        public string codtrabajo { get; set; }
        [DataMember]
        public decimal nota1 { get; set; }
        [DataMember]
        public decimal nota2 { get; set; }
        [DataMember]
        public decimal nota3 { get; set; }
        [DataMember]
        public decimal promedio { get; set; }
        [DataMember]
        public string tiponota { get; set; }
        [DataMember]
        public string detallereforzamiento { get; set; }

    }
}