using ProyectoFerreteria.UI.Consultas;
using ProyectoFerreteria.UI.Registros;
using ProyectoFerreteria.UI.Reportes;
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
            rClientes.MdiParent = this;
            rClientes.Show();
        }

        private void ProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rProductos rProductos = new rProductos();
            rProductos.MdiParent = this;
            rProductos.Show();
        }

        private void EntradasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rEntradas rEntradas = new rEntradas();
            rEntradas.MdiParent = this;
            rEntradas.Show();
        }

        private void UsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rUsuario rUsuario = new rUsuario();
            rUsuario.MdiParent = this;
            rUsuario.Show();
        }

        private void VentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rVentas rVentas = new rVentas();
            rVentas.MdiParent = this;
            rVentas.Show();
        }

        private void ClientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cClientes cClientes = new cClientes();
            cClientes.MdiParent = this;
            cClientes.Show();
        }

        private void EntradasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cEntradas cEntradas = new cEntradas();
            cEntradas.MdiParent = this;
            cEntradas.Show();
        }

        private void ProductosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cProductos cProductos = new cProductos();
            cProductos.MdiParent = this;
            cProductos.Show();
        }

        private void UsuariosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cUsuarios cUsuarios = new cUsuarios();
            cUsuarios.MdiParent = this;
            cUsuarios.Show();
        }

        private void VentasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cVentas cVentas = new cVentas();
            cVentas.MdiParent = this;
            cVentas.Show();
        }

        private void ClientesToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            reClientes reClientes = new reClientes();
            reClientes.MdiParent = this;
            reClientes.Show();
        }

        private void ProductosToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            reProductos reProductos = new reProductos();
            reProductos.MdiParent = this;
            reProductos.Show();
        }

        private void EntradasToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            reEntradas reEntradas = new reEntradas();
            reEntradas.MdiParent = this;
            reEntradas.Show();
        }

        private void UsuariosToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            reUsuarios reUsuarios = new reUsuarios();
            reUsuarios.MdiParent = this;
            reUsuarios.Show();
        }

        private void VentasToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            reVentas reVentas = new reVentas();
            reVentas.MdiParent = this;
            reVentas.Show();
        }

        private void ConsultasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
