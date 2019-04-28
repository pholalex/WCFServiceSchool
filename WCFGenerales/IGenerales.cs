using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFGenerales.Dominio;

namespace WCFGenerales
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IGenerales" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IGenerales
    {
        [OperationContract]
        Curso ObtenerCurso(string codigo);
        [OperationContract]
        List<Curso> ListarCursos();
        [OperationContract]
        Seccion ObtenerSeccion(string codigo);
        [OperationContract]
        List<Seccion> ListarSecciones();
        [OperationContract]
        Profesor ObtenerProfesor(string codigo);
        [OperationContract]
        List<Profesor> ListarProfesores();
        [OperationContract]
        Alumno ObtenerAlumno(string codigo);
        [OperationContract]
        List<Alumno> ListarAlumnos();
    }
}
