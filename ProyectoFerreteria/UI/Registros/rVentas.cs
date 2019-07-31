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
    public partial class rVentas : Form
    {
        public rVentas()
        {
            InitializeComponent();
            LlenarComboBox();
        }

        private int ToInt(object valor)
        {
            int retorno = 0;
            int.TryParse(valor.ToString(), out retorno);

            return retorno;
        }

        private decimal ToDecimal(object valor)
        {
            decimal retorno = 0;
            decimal.TryParse(valor.ToString(), out retorno);

            return retorno;
        }

        private void LlenarComboBox()
        {
            Repositorio<Clientes> CliRepositorio = new Repositorio<Clientes>(new Contexto());
            Repositorio<Productos> ProRepositorio = new Repositorio<Productos>(new Contexto());

            ClienteComboBox.DataSource = CliRepositorio.GetList(c => true);
            ClienteComboBox.ValueMember = "ClienteId";
            ClienteComboBox.DisplayMember = "Nombres";
            ProductoComboBox.DataSource = ProRepositorio.GetList(c => true);
            ProductoComboBox.ValueMember = "ProductoId";
            ProductoComboBox.DisplayMember = "Descripcion";
        }

        private Ventas LlenaClase()
        {
            Ventas venta = new Ventas();

            venta.VentaId = Convert.ToInt32(IdNumericUpDown.Value);
            venta.ClienteId = Convert.ToInt32(ClienteComboBox.SelectedValue);
            venta.Fecha = FechaDateTimePicker.Value;
            venta.SubTotal = Convert.ToDecimal(SubTotalTextBox.Text);
            venta.ITBIS = Convert.ToDecimal(ItbisTextBox.Text);
            venta.Total = Convert.ToDecimal(TotalTextBox.Text);

            foreach (DataGridViewRow item in FacturaDetalleDataGridView.Rows)
            {
                venta.AgregarDetalle(
                    ToInt(item.Cells["Id"].Value),
                    ToInt(item.Cells["VentaId"].Value),
                    ToInt(item.Cells["ProductoId"].Value),
                    item.Cells["Descripcion"].Value.ToString(),
                    ToDecimal(item.Cells["Cantidad"].Value),
                    ToDecimal(item.Cells["Precio"].Value),
                    ToDecimal(item.Cells["Importe"].Value)
                );
            }

            FacturaDetalleDataGridView.Columns["Id"].Visible = false;
            FacturaDetalleDataGridView.Columns["VentaId"].Visible = false;

            return venta;
        }

        private void LlenaCampos(Ventas venta)
        {
            IdNumericUpDown.Value = venta.VentaId;
            FechaDateTimePicker.Value = venta.Fecha;
            TipoVentacomboBox.Text = venta.TipoVenta;
            ClienteComboBox.SelectedValue = venta.ClienteId;
            SubTotalTextBox.Text = venta.SubTotal.ToString();
            ItbisTextBox.Text = venta.ITBIS.ToString();
            TotalTextBox.Text = venta.Total.ToString();

            FacturaDetalleDataGridView.DataSource = venta.Detalle;
            FacturaDetalleDataGridView.Columns["Id"].Visible = false;
            FacturaDetalleDataGridView.Columns["VentaId"].Visible = false;
        }

        private void LlenarPrecio()
        {
            Repositorio<Productos> ProRepositorio = new Repositorio<Productos>(new Contexto());
            List<Productos> ListProductos = ProRepositorio.GetList(c => c.Descripcion == ProductoComboBox.Text);
            foreach (var item in ListProductos)
            {
                PrecioTextBox.Text = item.Precio.ToString();
            }
        }

        private void LlenarImporte()
        {
            decimal cantidad, precio;

            cantidad = ToDecimal(CantidadTextBox.Text);
            precio = ToDecimal(PrecioTextBox.Text);
            ImporteTextBox.Text = VentasBLL.Importe(cantidad, precio).ToString();
        }

        private void LlenarValores()
        {
            List<VentasDetalle> detalle = new List<VentasDetalle>();

            if (FacturaDetalleDataGridView.DataSource != null)
            {
                detalle = (List<VentasDetalle>)FacturaDetalleDataGridView.DataSource;
            }
            decimal Total = 0;
            decimal Itbis = 0;
            decimal SubTotal = 0;
            foreach (var item in detalle)
            {
                Total += item.Importe;
            }
            Itbis = Total * 0.18m;
            SubTotal = Total - Itbis;
            SubTotalTextBox.Text = SubTotal.ToString();
            ItbisTextBox.Text = Itbis.ToString();
            TotalTextBox.Text = Total.ToString();
        }

        private void RebajarValores()
        {
            List<VentasDetalle> detalle = new List<VentasDetalle>();

            if (FacturaDetalleDataGridView.DataSource != null)
            {
                detalle = (List<VentasDetalle>)FacturaDetalleDataGridView.DataSource;
            }
            decimal Total = 0;
            decimal Itbis = 0;
            decimal SubTotal = 0;
            foreach (var item in detalle)
            {
                Total -= item.Importe;
            }
            Total *= (-1);
            Itbis = Total * 0.18m;
            SubTotal = Total - Itbis;
            SubTotalTextBox.Text = SubTotal.ToString();
            ItbisTextBox.Text = Itbis.ToString();
            TotalTextBox.Text = Total.ToString();
        }

        private bool Validar()
        {
            bool estado = false;

            if (FacturaDetalleDataGridView.RowCount == 0)
            {
                errorProvider.SetError(FacturaDetalleDataGridView,
                    "Debe Agregar");
                estado = true;
            }

            return estado;
        }

        private void LimpiaObjetos()
        {
            IdNumericUpDown.Value = 0;
            FechaDateTimePicker.Value = DateTime.Now;
            TipoVentacomboBox.SelectedIndex = 0;
            ClienteComboBox.SelectedIndex = 0;
            ProductoComboBox.SelectedIndex = 0;
            CantidadTextBox.Clear();
            PrecioTextBox.Clear();
            ImporteTextBox.Clear();
            FacturaDetalleDataGridView.DataSource = null;
            SubTotalTextBox.Clear();
            ItbisTextBox.Clear();
            TotalTextBox.Clear();
            errorProvider.Clear();
        }

        private void AgregarButtton_Click(object sender, EventArgs e)
        {
            List<VentasDetalle> detalle = new List<VentasDetalle>();

            if (FacturaDetalleDataGridView.DataSource != null)
            {
                detalle = (List<VentasDetalle>)FacturaDetalleDataGridView.DataSource;
            }
            else if (CantidadTextBox.Text == "0")
            {
                MessageBox.Show("Cantidad no puede ser cero!!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                detalle.Add(
                    new VentasDetalle(
                       id: 0,
                       ventaId: (int)IdNumericUpDown.Value,
                       productoId: (int)ProductoComboBox.SelectedValue,
                       descripcion: ProductoComboBox.Text,
                       cantidad: (decimal)Convert.ToDecimal(CantidadTextBox.Text),
                       precio: (decimal)Convert.ToDecimal(PrecioTextBox.Text),
                       importe: (decimal)Convert.ToDecimal(ImporteTextBox.Text)
               )); ;

                FacturaDetalleDataGridView.DataSource = null;
                FacturaDetalleDataGridView.DataSource = detalle;

                LlenarValores();
            }
        }

        private void RemoverButton_Click(object sender, EventArgs e)
        {
            if (FacturaDetalleDataGridView.Rows.Count > 0 && FacturaDetalleDataGridView.CurrentRow != null)
            {
                List<VentasDetalle> detalle = (List<VentasDetalle>)FacturaDetalleDataGridView.DataSource;

                detalle.RemoveAt(FacturaDetalleDataGridView.CurrentRow.Index);

                FacturaDetalleDataGridView.DataSource = null;
                FacturaDetalleDataGridView.DataSource = detalle;

                RebajarValores();
            }
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {

            Repositorio<Ventas> ProRepositorio = new Repositorio<Ventas>(new Contexto());
            int id = Convert.ToInt32(IdNumericUpDown.Value);
            Ventas venta = VentasBLL.Buscar(id);

            if (venta != null)
            {
                LlenaCampos(venta);
            }
            else
                MessageBox.Show("No se encontró!!!", "Falló",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            LimpiaObjetos();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            Repositorio<Ventas> repositorio = new Repositorio<Ventas>(new Contexto());
            Ventas venta;
            bool Paso = false;

            if (Validar())
            {
                MessageBox.Show("Favor revisar todos los campos!!", "Validación!!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            venta = LlenaClase();

            if (IdNumericUpDown.Value == 0)
            {
                Paso = repositorio.Guardar(venta);
                MessageBox.Show("Guardado!!", "Exito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Repositorio<Ventas> repositorioD = new Repositorio<Ventas>(new Contexto());
                int id = Convert.ToInt32(IdNumericUpDown.Value);
                Ventas ven = repositorioD.Buscar(id);

                if (ven != null)
                {
                    Paso = repositorioD.Modificar(venta);
                    MessageBox.Show("Modificado!!", "Exito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Id no existe", "Falló",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (Paso)
            {
                LimpiaObjetos();
            }
            else
                MessageBox.Show("No se pudo guardar!!", "Fallo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdNumericUpDown.Value);
            Repositorio<Ventas> repositorio = new Repositorio<Ventas>(new Contexto());
            Ventas venta = repositorio.Buscar(id);

            if (venta != null)
            {
                if (repositorio.Eliminar(id))
                {
                    MessageBox.Show("Eliminado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiaObjetos();
                }
                else
                    MessageBox.Show("No se pudo eliminar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("No existe!!", "Falló", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ProductoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarPrecio();
            if (CantidadTextBox.Text != "0")
            {
                LlenarImporte();
            }
            LlenarPrecio();
        }

        private void CantidadTextBox_TextChanged(object sender, EventArgs e)
        {
            LlenarPrecio();
            LlenarImporte();
        }
    }
}
