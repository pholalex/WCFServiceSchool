using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFTrabajo.Dominio;
using WCFTrabajo.Persistencia;

namespace WCFTrabajo
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Trabajos" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Trabajos.svc o Trabajos.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Trabajos : ITrabajos
    {
        private TrabajoDAO trabajoDAO = new TrabajoDAO();

        public Trabajo Crear(Trabajo trabajoACrear)
        {
            if (trabajoDAO.Obtener(trabajoACrear.IdTrabajo) != null) //Ya existe Trabajo
            {
                return trabajoDAO.Obtener(trabajoACrear.IdTrabajo);
            }
            return trabajoDAO.Crear(trabajoACrear);
        }
        public Trabajo Obtener(string IdTrabajo)
        {
            return trabajoDAO.Obtener(IdTrabajo);
        }

        public Trabajo Modificar(Trabajo trabajoAModificar)
        {
            return trabajoDAO.Modificar(trabajoAModificar);
        }

        public List<Trabajo> Listar()
        {
            return trabajoDAO.Listar();
        }

        string ITrabajos.Eliminar(string IdTrabajo)
        {
            return trabajoDAO.Eliminar(IdTrabajo);
        }

        public NotaExtra RegistrarNota(NotaExtra trabajoACrear)
        {
            return trabajoDAO.RegistrarNota(trabajoACrear);
        }

        public NotaExtra ObtenerNota(string codtrabajo)
        {
            return trabajoDAO.ObtenerNota(codtrabajo);
        }

        public NotaExtra ModificarNota(NotaExtra trabajoACrear)
        {
            return trabajoDAO.ModificarNota(trabajoACrear);
        }

        public List<NotaExtra> ListarNota(string codreforzamiento)
        {
            throw new NotImplementedException();
        }
    }
}
