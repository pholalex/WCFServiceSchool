using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFRegistroNotas.Dominio;

namespace WCFRegistroNotas
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "INotas" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface INotas
    {
        [OperationContract]
        Nota Registrar(Nota notaACrear);
        [OperationContract]
        Nota Obtener(string codnota);
        [OperationContract]
        string Secuencial();
        [OperationContract]
        List<Nota> ListaNota();
    }
}
