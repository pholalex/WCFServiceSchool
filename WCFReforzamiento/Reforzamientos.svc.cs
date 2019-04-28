using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFReforzamiento.Dominio;
using WCFReforzamiento.Persistencia;

namespace WCFReforzamiento
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Reforzamientos" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Reforzamientos.svc o Reforzamientos.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Reforzamientos : IReforzamientos
    {
        private ReforzamientoDAO reforzamientoDAO = new ReforzamientoDAO();

        public List<NotaExtra> ListarNotas()
        {
            return reforzamientoDAO.ListarNota();
        }

        public List<Reforzamiento> ListarReforzamiento()
        {
            return reforzamientoDAO.ListarReforzamiento();
        }

        public NotaExtra ModificarNota(NotaExtra notaAModificar)
        {
            return reforzamientoDAO.ModificarNota(notaAModificar);
        }

        public Reforzamiento Obtener(string p_cod_reforzamiento)
        {
            return reforzamientoDAO.ObtenerReforzamiento(p_cod_reforzamiento);
        }

        public NotaExtra ObtenerNota(string codreforzamiento)
        {
            return reforzamientoDAO.ObtenerNota(codreforzamiento);
        }

        public Reforzamiento Registrar(Reforzamiento reforzamientoACrear)
        {
            return reforzamientoDAO.CrearReforzamiento(reforzamientoACrear);
        }

        public NotaExtra RegistrarNota(NotaExtra notaACrear)
        {
            return reforzamientoDAO.RegistrarNota(notaACrear);
        }

        public string Secuencial()
        {
            return reforzamientoDAO.ObtenerSecuencial();
        }
    }
}
