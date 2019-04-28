using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WCFTestClient
{
    [TestClass]
    public class PlanRecuperacionTest
    {
        [TestMethod]
        public void CrearPlanTest()
        {
            PlanRecuperacionWS.PlanRecuperacionesClient proxy = new PlanRecuperacionWS.PlanRecuperacionesClient();

            try
            {
                PlanRecuperacionWS.PlanRecuperacion planCreado = proxy.CrearPlan(new PlanRecuperacionWS.PlanRecuperacion()
                {
                    IdPlan = "00001",
                    IdProfesor = "00001",
                    IdAlumno = "00001",
                    IdCurso = "00001",
                    ActivarReforzamiento = 1,
                    ActivarTrabajo = 1,
                    FechaRegistro = DateTime.Now
                });
                Assert.AreEqual(3, planCreado.IdPlan);
                Assert.AreEqual(1, planCreado.IdProfesor);
                Assert.AreEqual(3, planCreado.IdAlumno);
                Assert.AreEqual(3, planCreado.IdCurso);
                Assert.AreEqual(1, planCreado.ActivarReforzamiento);
                Assert.AreEqual(1, planCreado.ActivarTrabajo);
            }
            catch (Exception error)
            {

                error.Message.ToString();
            }            

        }
    }
}
