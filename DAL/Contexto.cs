using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Usuarios> Usuario { get; set; }
        public DbSet<Clientes> Cliente { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Entradas> Entrada { get; set; }
        public DbSet<Ventas> Ventas { get; set; }
        public DbSet<VentasDetalle> VentasDetalle { get; set; }

        public Contexto() : base("ConStr")
        { }
    }
}
