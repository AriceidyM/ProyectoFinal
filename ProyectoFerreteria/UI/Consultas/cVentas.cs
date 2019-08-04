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
    public partial class cVentas : Form
    {
        private List<Ventas> usuarios = new List<Ventas>();
        public cVentas()
        {
            InitializeComponent();
        }

        private void Consultarbutton_Click(object sender, EventArgs e)
        {
            Repositorio<Ventas> dbe = new Repositorio<Ventas>(new Contexto());
            Expression<Func<Ventas, bool>> filtro = u => true;
            int id;
            switch (FiltrocomboBox.SelectedIndex)
            {
                case 0://Todo.
                    break;
                case 1://Id de la Venta.
                    id = Convert.ToInt32(CriteriotextBox.Text);
                    filtro = u => u.VentaId == id;
                    break;
                case 2://ClienteId.
                    int idC = Convert.ToInt32(CriteriotextBox.Text);
                    filtro = u => u.ClienteId == idC;
                    break;
            }

            usuarios = dbe.GetList(filtro);
            ConsultadataGridView.DataSource = usuarios;
        }

        private void Imprimirbutton_Click(object sender, EventArgs e)
        {
            reciVentas reciVentas = new reciVentas();
            reciVentas.Show();
        }
    }
}
