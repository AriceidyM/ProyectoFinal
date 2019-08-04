using BLL;
using DAL;
using Entities;
using System;
using System.Collections.Generic;
using ProyectoFerreteria.UI.Consultas.Recibos;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFerreteria.UI.Consultas
{
    public partial class cProductos : Form
    {
        private List<Productos> productos = new List<Productos>();
        public cProductos()
        {
            InitializeComponent();
        }

        private void Consultarbutton_Click(object sender, EventArgs e)
        {
            Repositorio<Productos> repositorio = new Repositorio<Productos>(new Contexto());
            Expression<Func<Productos, bool>> filtro = p => true;
            int id;
            switch (FiltrocomboBox.SelectedIndex)
            {
                case 0://Todo.
                    break;
                case 1://Id del Producto.
                    id = Convert.ToInt32(CriteriotextBox.Text);
                    filtro = p => p.ProductoId == id;
                    break;
                case 2://Descripcion del Producto.
                    filtro = p => p.Descripcion.Contains(CriteriotextBox.Text);
                    break;
                case 3://Filtrando por Cantidad en el Inventario del Producto.
                    filtro = p => p.Existencia.ToString().Contains(CriteriotextBox.Text);
                    break;
            }

            productos = repositorio.GetList(filtro);
            ConsultadataGridView.DataSource = productos;
        }

        private void Imprimirbutton_Click(object sender, EventArgs e)
        {
            reciProductos reciProductos = new reciProductos();
            reciProductos.Show();
        }
    }
}
