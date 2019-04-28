using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFReforzamiento.Dominio;

namespace WCFReforzamiento
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IReforzamientos" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IReforzamientos
    {
        [OperationContract]
        Reforzamiento Registrar(Reforzamiento reforzamientoACrear);

        [OperationContract]
        Reforzamiento Obtener(string p_cod_reforzamiento);


        [OperationContract]
        List<Reforzamiento> ListarReforzamiento();

        [OperationContract]
        NotaExtra RegistrarNota(NotaExtra reforzamientoACrear);
        [OperationContract]
        NotaExtra ObtenerNota(string codreforzamiento);

        [OperationContract]
        NotaExtra ModificarNota(NotaExtra reforzamientoACrear);


        [OperationContract]
        string Secuencial();
        [OperationContract]
        List<NotaExtra> ListarNotas();

    }
}
