using System;
using BLL;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BLLTests
{
    [TestClass]
    public class EntradaBLL
    {
        [TestMethod]
        public void Guardar()
        {
            
            bool paso;
            Entradas entrada = new Entradas();
            entrada.EntradaId = 0;
            entrada.Fecha = DateTime.Now;
            entrada.producto = "Pussy";
            entrada.Cantidad = 10;
            paso = EntradasBLL.Guardar(entrada);
            Assert.AreEqual(paso, true);

        }

        [TestMethod]
        public void Modificar()
        {

            bool paso;
            Entradas entrada = new Entradas();
            entrada.EntradaId =9 ;
            entrada.Fecha = DateTime.Now;
            entrada.producto = "Pussy";
            entrada.Cantidad = 3;
            paso = EntradasBLL.Modificar(entrada);
            Assert.AreEqual(paso, true);

        }
    }
}
