﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Ventas
    {
        [Key]
        public int VentaId { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoVenta { get; set; }
        public int ClienteId { get; set; }
        public decimal SubTotal { get; set; }
        public decimal ITBIS { get; set; }
        public decimal Total { get; set; }
        public virtual ICollection<VentasDetalle> Detalle { get; set; }

        public Ventas()
        {
            VentaId = 0;
            Fecha = DateTime.Now;
            TipoVenta = string.Empty;
            ClienteId = 0;
            SubTotal = 0;
            ITBIS = 0;
            Total = 0;
            this.Detalle = new List<VentasDetalle>();
        }

        public void AgregarDetalle(int ID, int VentaId, int ProductoId, string Descripcion, decimal Precio, decimal Cantidad, decimal Importe)
        {
            this.Detalle.Add(new VentasDetalle(ID, VentaId, ProductoId, Descripcion, Precio, Cantidad, Importe));
        }

    }
}
