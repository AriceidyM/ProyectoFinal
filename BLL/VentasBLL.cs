using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class VentasBLL
    {
        public static Ventas Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Ventas venta = new Ventas();
            try
            {
                venta = contexto.Ventas.Find(id);

                if (venta != null)
                {
                    venta.Detalle.Count();

                    foreach (var item in venta.Detalle)
                    {
                        string s = item.Producto.Descripcion;
                        string ss = item.VentaId.ToString();
                    }
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return venta;
        }

        public static decimal Importe(decimal cantidad, decimal precio)
        {
            decimal CalImporte = 0;
            CalImporte = cantidad * precio;

            return CalImporte;
        }
    }
}
