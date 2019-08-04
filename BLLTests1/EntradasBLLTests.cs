using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Linq.Expressions;
using DAL;

namespace BLL.Tests
{
    [TestClass()]
    public class EntradasBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Entradas entrada = new Entradas();
            entrada.EntradaId = 1;
            entrada.Fecha = DateTime.Now;
            entrada.ProductoId = 2;
            entrada.Cantidad = 10;
            paso = EntradasBLL.Guardar(entrada);
            Assert.AreEqual(paso, true);
        }
        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Entradas entrada = new Entradas();
            entrada.EntradaId = 1;
            entrada.Fecha = DateTime.Now;
            entrada.ProductoId = 1;
            entrada.Cantidad = 20;
            paso = EntradasBLL.Modificar(entrada);
            Assert.AreEqual(paso, true);
        }
        [TestMethod()]
        public void EliminarTest()
        {
            int id = 1;
            bool paso;
            paso = EntradasBLL.Eliminar(id);
            Assert.AreEqual(paso, true);
        }
        [TestMethod()]
        public void BuscarTest()
        {
            int id = 2;
            Entradas entrada = new Entradas();
            entrada = EntradasBLL.Buscar(id);
            Assert.IsNotNull(entrada);
        }
    }
}