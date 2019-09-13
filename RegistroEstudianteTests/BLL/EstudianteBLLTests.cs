using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistroEstudiante.BLL;
using RegistroEstudiante.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroEstudiante.BLL.Tests
{
    [TestClass()]
    public class EstudianteBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
                 
        {
            bool paso;
            Estudiante estudiante = new Estudiante();
            estudiante.ID = 0;
            estudiante.matricula = "201-0286";
            estudiante.nombre = "emminton";
            estudiante.apellido = "urena";
            estudiante.nacimiento = DateTime.Now;
            estudiante.Cedula = "056-0163152-9";
            estudiante.telefono = "8097583641";
            estudiante.celular = "8059998";
            estudiante.email = "emminto@ngmail";
            estudiante.sexo = "masculino";
            estudiante.balance = 0;
            paso = EstudianteBLL.Guardar(estudiante);
            Assert.AreEqual(paso, true);   

            //Assert.Fail();
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EliminarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetListTest()
        {
            Assert.Fail();
        }
    }
}