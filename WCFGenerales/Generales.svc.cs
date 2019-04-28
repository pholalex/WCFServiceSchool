using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFGenerales.Dominio;
using WCFGenerales.Persistencia;

namespace WCFGenerales
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Generales" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Generales.svc o Generales.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Generales : IGenerales
    {
        private GeneralDAO generalDAO = new GeneralDAO();

        public List<Alumno> ListarAlumnos()
        {
            return generalDAO.ListarAlumnos();
        }

        public List<Curso> ListarCursos()
        {
            return generalDAO.ListarCurso();
        }

        public List<Profesor> ListarProfesores()
        {
            return generalDAO.ListarProfesor();
        }

        public List<Seccion> ListarSecciones()
        {
            return generalDAO.ListarSeccion();
        }

        public Alumno ObtenerAlumno(string codigo)
        {
            return generalDAO.ObtenerAlumno(codigo);
        }

        public Curso ObtenerCurso(string codigo)
        {
            return generalDAO.ObtenerCurso(codigo);
        }

        public Profesor ObtenerProfesor(string codigo)
        {
            return generalDAO.ObtenerProfesor(codigo);
        }

        public Seccion ObtenerSeccion(string codigo)
        {
            return generalDAO.ObtenerSeccion(codigo);
        }
    }
}
