using System;
using BLL;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BLLTests
{
    [TestClass]
    public class Producto
    {
        [TestMethod]


        public void Guardar()
        {
            Repositorio<Productos> ari = new Repositorio<Productos>(new DAL.Contexto());
            bool paso;
            Productos pro = new Productos();
            pro.ProductoId = 0;
            pro.FechaVencimiento = DateTime.Now;
            pro.Descripcion = "Martillo";
            pro.Precio = 100;
            paso = ari.Guardar(pro);
            Assert.AreEqual(paso, true);

        }

    }
}

