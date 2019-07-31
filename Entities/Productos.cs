using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Productos
    {
        [Key]
        public int ProductoId { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string Descripcion { get; set; }
        public Decimal Precio { get; set; }
        public int Existencia { get; set; }

        public Productos()
        {
            ProductoId = 0;
            FechaVencimiento = DateTime.Now;
            Descripcion = string.Empty;
            Precio = 0;
            Existencia = 0;
        }
    }
}
