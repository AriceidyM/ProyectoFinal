using BLL;
using DAL;
using Entities;
using ProyectoFerreteria.UI.Consultas.Recibos;
using System;
using System.Collections.Generic;
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
    public partial class cClientes : Form
    {
        private List<Clientes> clientes = new List<Clientes>();
        public cClientes()
        {
            InitializeComponent();
        }

        private void Consultarbutton_Click(object sender, EventArgs e)
        {
            Repositorio<Clientes> dbe = new Repositorio<Clientes>(new Contexto());
            Expression<Func<Clientes, bool>> filtro = c => true;
            int id;
            switch (FiltrocomboBox.SelectedIndex)
            {
                case 0://Todo.
                    break;
                case 1://Filtrando por ID del cliente.
                    id = Convert.ToInt32(CriteriotextBox.Text);
                    filtro = c => c.ClienteId == id;
                    break;
                case 2://Filtrando por Nombres del cliente.
                    filtro = c => c.Nombres.Contains(CriteriotextBox.Text);
                    break;
                case 3://Filtrando por Email del cliente.
                    filtro = c => c.Email.Contains(CriteriotextBox.Text);
                    break;
                case 4://Filtrando por Direccion del cliente.
                    filtro = c => c.Direccion.Contains(CriteriotextBox.Text);
                    break;
                case 5://Filtrando por Telefono del cliente.
                    filtro = c => c.Telefono.Contains(CriteriotextBox.Text);
                    break;
                case 6://Filtrando por Celular del cliente.
                    filtro = c => c.Celular.Contains(CriteriotextBox.Text);
                    break;
            }

            clientes = dbe.GetList(filtro);
            ConsultadataGridView.DataSource = clientes;
            
        }

        private void Imprimirbutton_Click(object sender, EventArgs e)
        {
            reciClientes reClientes = new reciClientes();
            reClientes.Show();
        }
    }
}
