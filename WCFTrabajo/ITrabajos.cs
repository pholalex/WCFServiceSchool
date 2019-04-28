using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCFTrabajo.Dominio;

namespace WCFTrabajo
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "ITrabajos" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface ITrabajos
    {
        [OperationContract]        
        Trabajo Crear(Trabajo trabajoACrear);

        [OperationContract]        
        Trabajo Obtener(string IdTrabajo);

        [OperationContract]        
        Trabajo Modificar(Trabajo trabajoAModificar);

        [OperationContract]
        string Eliminar(string IdTrabajo);

        [OperationContract]        
        List<Trabajo> Listar();

        [OperationContract]
        NotaExtra RegistrarNota(NotaExtra trabajoACrear);
        [OperationContract]
        NotaExtra ObtenerNota(string codtrabajo);

        [OperationContract]
        NotaExtra ModificarNota(NotaExtra trabajoACrear);

        [OperationContract]
        List<NotaExtra> ListarNota(string codreforzamiento);

    }
}
