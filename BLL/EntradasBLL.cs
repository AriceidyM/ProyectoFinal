using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EntradasBLL
    {
        public bool Guardar(Entradas entrada)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Entrada.Add(entrada) != null)
                {
                    contexto.Productos.Find(entrada.ProductoId).Existencia += entrada.Cantidad;

                    contexto.SaveChanges();
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }


        public bool Modificar(Entradas entrada)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                Entradas EntrAnt = Buscar(entrada.EntradaId);

                if (EntrAnt.ProductoId != entrada.ProductoId)
                {
                    ModificarBien(entrada, EntrAnt);
                }

                int modificado = entrada.Cantidad - EntrAnt.Cantidad;
                Repositorio<Productos> repositorio = new Repositorio<Productos>(new Contexto());
                var Producto = contexto.Productos.Find(entrada.ProductoId);
                Producto.Existencia += modificado;
                repositorio.Modificar(Producto);

                contexto.Entry(entrada).State = EntityState.Modified;
                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }


        public bool Eliminar(int id)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                Entradas entrada = contexto.Entrada.Find(id);

                contexto.Productos.Find(entrada.ProductoId).Existencia -= entrada.Cantidad;

                contexto.Entrada.Remove(entrada);

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }


        public Entradas Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Entradas entrada = new Entradas();

            try
            {
                entrada = contexto.Entrada.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return entrada;
        }


        public List<Entradas> GetList(Expression<Func<Entradas, bool>> expression)
        {
            List<Entradas> entradas = new List<Entradas>();
            Contexto contexto = new Contexto();
            try
            {
                entradas = contexto.Entrada.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }

            return entradas;
        }

        public static void ModificarBien(Entradas entradas, Entradas EntradasAnteriores)
        {
            Repositorio<Productos> repositorio = new Repositorio<Productos>(new Contexto());
            Repositorio<Productos> repositorioC = new Repositorio<Productos>(new Contexto());
            Contexto contexto = new Contexto();
            var Producto = contexto.Productos.Find(entradas.ProductoId);
            var ProductosAnteriores = contexto.Productos.Find(EntradasAnteriores.ProductoId);

            Producto.Existencia += entradas.Cantidad;
            ProductosAnteriores.Existencia -= EntradasAnteriores.Cantidad;
            repositorio.Modificar(Producto);
            repositorioC.Modificar(ProductosAnteriores);
        }
    }
}
