using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFRegistroNotas.Dominio;
using WCFRegistroNotas.Persistencia;

namespace WCFRegistroNotas
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Notas" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Notas.svc o Notas.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Notas : INotas
    {
        private NotaDAO notaDAO = new NotaDAO();

        public List<Nota> ListaNota()
        {
            return notaDAO.ListarNota();
        }

        public Nota Obtener(string codnota)
        {
            return notaDAO.ObtenerNota(codnota);
        }

        public Nota Registrar(Nota notaACrear)
        {
            return notaDAO.RegistrarNota(notaACrear);
        }

        public string Secuencial()
        {
            return notaDAO.ObtenerSecuencial();
        }
    }
}
