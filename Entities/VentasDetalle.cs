﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class VentasDetalle
    {
        [Key]
        public int Id { get; set; }
        public int VentaId { get; set; }
        public int ClienteId { get; set; }
        public int ProductoId { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Importe { get; set; }

        [ForeignKey("ProductoId")]
        public virtual Productos Producto { get; set; }
        [ForeignKey("VentaId")]
        public virtual Ventas Venta { get; set; }

        public VentasDetalle()
        {
            Id = 0;
            VentaId = 0;
            ClienteId = 0;
            ProductoId = 0;
            Descripcion = string.Empty;
            Precio = 0;
            Cantidad = 0;
            Importe = 0;
        }

        public VentasDetalle(int id, int ventaId, int productoId, string descripcion, decimal precio, decimal cantidad, decimal importe)
        {
            this.Id = id;
            this.VentaId = ventaId;
            this.ProductoId = productoId;
            Descripcion = descripcion;
            this.Precio = precio;
            this.Cantidad = cantidad;
            this.Importe = importe;
        }
    }
}
