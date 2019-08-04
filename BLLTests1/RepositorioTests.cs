using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;

namespace BLL.Tests
{
    [TestClass()]
    public class RepositorioTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Repositorio<Usuarios> db = new Repositorio<Usuarios>(new Contexto());


            Usuarios us = new Usuarios()
            {
                UsuarioId = 0,
                FechaIngreso = DateTime.Now,
                Nombres = "Annelys",
                Email = "an@gmail.com",
                NivelUsuario = "Administrador",
                Usuario = "a123",
                Clave = "1234"


            };
            Assert.IsTrue(db.Guardar(us));
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Repositorio<Usuarios> db = new Repositorio<Usuarios>(new Contexto());

            Usuarios us = new Usuarios()
            {
                UsuarioId = 1,
                FechaIngreso = DateTime.Now,
                Nombres = "Annelys",
                Email = "an@gmail.com",
                NivelUsuario = "Administrador",
                Usuario = "a123",
                Clave = "1234"

            };

            Assert.IsTrue(db.Modificar(us));
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Repositorio<Usuarios> db = new Repositorio<Usuarios>(new Contexto());

            Assert.IsNotNull(db.Buscar(2));
        }

        [TestMethod()]
        public void GetListTest()
        {
            Repositorio<Usuarios> db = new Repositorio<Usuarios>(new Contexto());

            Assert.IsNotNull(db.GetList(t => true));
        }


        [TestMethod()]
        public void EliminarTest()
        {
            Repositorio<Usuarios> db = new Repositorio<Usuarios>(new Contexto());

            Assert.IsTrue(db.Eliminar(1));
        }

        //Clientes

        [TestMethod()]
        public void GuardarClientesTest()
        {
            Repositorio<Clientes> db = new Repositorio<Clientes>(new Contexto());


            Clientes cl = new Clientes()
            {
                ClienteId = 0,
                FechaIngreso = DateTime.Now,
                Nombres = "Annelys",
                Email = "an@gmail.com",
                Direccion = "ggas",
                Telefono = "1111111111",
                Celular = "2222222222",
                Deuda = 0

            };
            Assert.IsTrue(db.Guardar(cl));
        }

        [TestMethod()]
        public void ModificarClientesTest()
        {
            Repositorio<Clientes> db = new Repositorio<Clientes>(new Contexto());


            Clientes cl = new Clientes()
            {
                ClienteId = 0,
                FechaIngreso = DateTime.Now,
                Nombres = "Annelys",
                Email = "an@gmail.com",
                Direccion = "ggas",
                Telefono = "3333333333",
                Celular = "2222222222",
                Deuda = 0

            };
            Assert.IsTrue(db.Guardar(cl));
        }

        [TestMethod()]
        public void BuscarClientesTest()
        {
            Repositorio<Clientes> db = new Repositorio<Clientes>(new Contexto());

            Assert.IsNotNull(db.Buscar(1));
        }

        [TestMethod()]
        public void GetListClientesTest()
        {
            Repositorio<Clientes> db = new Repositorio<Clientes>(new Contexto());

            Assert.IsNotNull(db.GetList(t => true));
        }


        [TestMethod()]
        public void EliminarClientesTest()
        {
            Repositorio<Clientes> db = new Repositorio<Clientes>(new Contexto());

            Assert.IsTrue(db.Eliminar(1));
        }

        //Productos
        [TestMethod()]
        public void GuardarProductosTest()
        {
            Repositorio<Productos> db = new Repositorio<Productos>(new Contexto());


            Productos pro = new Productos()
            {
                ProductoId = 0,
                FechaVencimiento = DateTime.Now,
                Descripcion = "Annelys",
                Precio = 20,
                Existencia = 3

            };
            Assert.IsTrue(db.Guardar(pro));
        }

        [TestMethod()]
        public void ModificarProductosTest()
        {
            Repositorio<Productos> db = new Repositorio<Productos>(new Contexto());


            Productos pro = new Productos()
            {
                ProductoId = 0,
                FechaVencimiento = DateTime.Now,
                Descripcion = "Annelys",
                Precio = 20,
                Existencia = 30

            };
            Assert.IsTrue(db.Guardar(pro));
        }

       [TestMethod()]
        public void BuscarProductosTest()
        {
            Repositorio<Productos> db = new Repositorio<Productos>(new Contexto());

            Assert.IsNotNull(db.Buscar(1));
        }

        [TestMethod()]
        public void GetListProductosTest()
        {
            Repositorio<Productos> db = new Repositorio<Productos>(new Contexto());

            Assert.IsNotNull(db.GetList(t => true));
        }


        [TestMethod()]
        public void EliminarProductosTest()
        {
            Repositorio<Productos> db = new Repositorio<Productos>(new Contexto());

            Assert.IsTrue(db.Eliminar(1));
        }
    }
}