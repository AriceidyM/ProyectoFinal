using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace BLL.Tests
{
    [TestClass()]
    public class VentasBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Ventas venta = new Ventas();
            venta.VentaId = 1;
            venta.Fecha = DateTime.Now;
            venta.TipoVenta = "Credito";
            venta.ClienteId = 1;
            venta.SubTotal = 82;
            venta.ITBIS = 18;
            venta.Total = 100;

            //venta.Detalle.Add(new VentasDetalle(0, 2, 2, 2, 25, 50));
            //venta.Detalle.Add(new VentasDetalle(0, 3, 1, 1, 30, 30));
            bool paso = VentasBLL.Guardar(venta);
            Assert.AreEqual(true, paso);
        }
        [TestMethod()]
        public void BuscarTest()
        {
            int id = 1;
            Ventas venta = new Ventas();
            venta = VentasBLL.Buscar(id);
            Assert.IsNotNull(venta);
        }
    }
}