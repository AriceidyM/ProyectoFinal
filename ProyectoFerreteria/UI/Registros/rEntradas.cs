using BLL;
using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFerreteria.UI.Registros
{
    public partial class rEntradas : Form
    {
        public rEntradas()
        {
            InitializeComponent();
            LlenarComboBox();
        }

        private void LlenarComboBox()
        {
            Repositorio<Productos> ArtRepositorio = new Repositorio<Productos>(new Contexto());

            ProductocomboBox.DataSource = ArtRepositorio.GetList(c => true);
            ProductocomboBox.ValueMember = "ProductoId";
            ProductocomboBox.DisplayMember = "Descripcion";
        }
        private Entradas LlenaClase()
        {
            Entradas inventario = new Entradas();
            inventario.EntradaId = Convert.ToInt32(EntradaInventarioIdnumericUpDown.Value);
            inventario.ProductoId = Convert.ToInt32(ProductocomboBox.SelectedValue);
            //inventario.producto = ProductocomboBox.Text;
            inventario.Cantidad = Convert.ToInt32(CantidadnumericUpDown.Value);
            inventario.Fecha = DateTime.Now;

            return inventario;
        }
        private void LlenaCampo(Entradas inventario)
        {
            EntradaInventarioIdnumericUpDown.Value = inventario.EntradaId;
            ProductocomboBox.SelectedValue = inventario.ProductoId;
            CantidadnumericUpDown.Value = inventario.Cantidad;
            FechadateTimePicker.Value = inventario.Fecha;

        }

        public bool Validar()
        {
            bool paso = true;

            errorProvider.Clear();

            if (CantidadnumericUpDown.Value == 0)
            {
                errorProvider.SetError(CantidadnumericUpDown, "No puede ser Cero");
                paso = false;
            }

            return paso;
        }
        private void Limpiar()
        {
            EntradaInventarioIdnumericUpDown.Value = 0;
            ProductocomboBox.SelectedIndex = 0;
            CantidadnumericUpDown.Value = 0;
            FechadateTimePicker.Value = DateTime.Now;
            errorProvider.Clear();
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            Repositorio<Entradas> dbe = new Repositorio<Entradas>(new Contexto());
            Entradas inventario = dbe.Buscar((int)((int)EntradaInventarioIdnumericUpDown.Value));
            return (inventario != null);

        }
        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id;
            Entradas inventario = new Entradas();
            Repositorio<Entradas> dbe = new Repositorio<Entradas>(new Contexto());
            int.TryParse(EntradaInventarioIdnumericUpDown.Text, out id);
            Limpiar();
            inventario = dbe.Buscar(id);

            if (inventario != null)
            {
                LlenaCampo(inventario);
            }
            else
                MessageBox.Show("Usuario no encontrado");
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            if (!Validar())
                return;
            bool paso = false;
            EntradasBLL dbe = new EntradasBLL();
            Entradas inventario = new Entradas();

            inventario = LlenaClase();
            if (EntradaInventarioIdnumericUpDown.Value == 0)
            {
                paso = dbe.Guardar(inventario);

            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar un producto que no existe", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = dbe.Modificar(inventario); 
            }

            if (paso)
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Limpiar();
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            Repositorio<Entradas> repositorio = new Repositorio<Entradas>(new Contexto());
            EntradasBLL dbe = new EntradasBLL();
            if (!ExisteEnLaBaseDeDatos())
            {
                MessageBox.Show("No se puede Eliminar un producto que no existe", "fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            errorProvider.Clear();
            int id;
            int.TryParse(EntradaInventarioIdnumericUpDown.Text, out id);

            Limpiar();

            if (dbe.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                errorProvider.SetError(EntradaInventarioIdnumericUpDown, "No se puede eliminar un producto que no existe");
        }
    }
}
