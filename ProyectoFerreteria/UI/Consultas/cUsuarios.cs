using BLL;
using DAL;
using Entities;
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
    public partial class cUsuarios : Form
    {
        private List<Usuarios> usuarios = new List<Usuarios>();
        public cUsuarios()
        {
            InitializeComponent();
        }

        private void Consultarbutton_Click(object sender, EventArgs e)
        {
            Repositorio<Usuarios> dbe = new Repositorio<Usuarios>(new Contexto());
            Expression<Func<Usuarios, bool>> filtro = u => true;
            int id;
            switch (FiltrocomboBox.SelectedIndex)
            {
                case 0://Todo.
                    break;
                case 1://Filtrando por ID del Usuario.
                    id = Convert.ToInt32(CriteriotextBox.Text);
                    filtro = u => u.UsuarioId == id;
                    break;
                case 2://Filtrando por Nombres del Usuario.
                    filtro = u => u.Nombres.Contains(CriteriotextBox.Text);
                    break;
            }

            usuarios = dbe.GetList(filtro);
            ConsultadataGridView.DataSource = usuarios;
        }
    }
}
