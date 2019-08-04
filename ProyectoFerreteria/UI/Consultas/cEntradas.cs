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
    public partial class cEntradas : Form
    {
        private List<Entradas> entradas = new List<Entradas>();
        public cEntradas()
        {
            InitializeComponent();
        }

        private void Consultarbutton_Click(object sender, EventArgs e)
        {
            Expression<Func<Entradas, bool>> filtro = ea => true;
            int id;
            switch (FiltrocomboBox.SelectedIndex)
            {
                case 0://Todo.
                    break;
                case 1://Id de la Entrada.
                    id = Convert.ToInt32(CriteriotextBox.Text);
                    filtro = ea => ea.EntradaId == id;
                    break;
                case 2://Fecha de la Entrada.
                    filtro = ea => ea.Fecha >= DesdedateTimePicker.Value.Date && ea.Fecha <= HastadateTimePicker.Value.Date;
                    break;
            }

            entradas = EntradasBLL.GetList(filtro);
            ConsultadataGridView.DataSource = entradas;
        }

        private void Imprimirbutton_Click(object sender, EventArgs e)
        {
            reciEntradas reciEntradas = new reciEntradas();
            reciEntradas.Show();
        }
    }
}
