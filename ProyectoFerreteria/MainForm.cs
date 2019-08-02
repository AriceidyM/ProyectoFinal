using ProyectoFerreteria.UI.Consultas;
using ProyectoFerreteria.UI.Registros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFerreteria
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rClientes rClientes = new rClientes();
            rClientes.Show();
        }

        private void ProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rProductos rProductos = new rProductos();
            rProductos.Show();
        }

        private void EntradasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rEntradas rEntradas = new rEntradas();
            rEntradas.Show();
        }

        private void UsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rUsuario rUsuario = new rUsuario();
            rUsuario.Show();
        }

        private void VentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rVentas rVentas = new rVentas();
            rVentas.Show();
        }

        private void ClientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cClientes cClientes = new cClientes();
            cClientes.Show();
        }

        private void EntradasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cEntradas cEntradas = new cEntradas();
            cEntradas.Show();
        }

        private void ProductosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cProductos cProductos = new cProductos();
            cProductos.Show();
        }

        private void UsuariosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cUsuarios cUsuarios = new cUsuarios();
            cUsuarios.Show();
        }

        private void VentasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cVentas cVentas = new cVentas();
            cVentas.Show();
        }
    }
}
