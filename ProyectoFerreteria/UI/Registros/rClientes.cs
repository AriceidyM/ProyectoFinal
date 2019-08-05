﻿using Entities;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace ProyectoFerreteria.UI.Registros
{
    public partial class rClientes : Form
    {
        public rClientes()
        {
            InitializeComponent();
        }

        private Clientes LlenaClase()
        {
            Clientes clientes = new Clientes();
            clientes.ClienteId = Convert.ToInt32(ClienteIdnumericUpDown.Value);
            clientes.Nombres = NombrestextBox.Text;
            clientes.Email = EmailtextBox.Text;
            clientes.Direccion = DirecciontextBox.Text;
            clientes.Telefono = TelefonotextBox.Text;
            clientes.Celular = CelulartextBox.Text;
            clientes.FechaIngreso = DateTime.Now;
            clientes.Deuda = 0;
            return clientes;
        }
        private void LlenaCampo(Clientes clientes)
        {
            ClienteIdnumericUpDown.Value = clientes.ClienteId;
            NombrestextBox.Text = clientes.Nombres;
            EmailtextBox.Text = clientes.Email;
            DirecciontextBox.Text = clientes.Direccion;
            TelefonotextBox.Text = clientes.Telefono;
            CelulartextBox.Text = clientes.Celular;
            FechadateTimePicker.Value = clientes.FechaIngreso;
            DeudatextBox.Text = clientes.Deuda.ToString();
        }

        public bool Validar()
        {
            bool paso = true;
            errorProvider.Clear();

            if (string.IsNullOrWhiteSpace(NombrestextBox.Text))
            {
                errorProvider.SetError(NombrestextBox, "Este campo no puede estar vacio");
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(EmailtextBox.Text))
            {
                errorProvider.SetError(EmailtextBox, "Este campo no puede estar vacio");
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(DirecciontextBox.Text))
            {
                errorProvider.SetError(DirecciontextBox, "Este campo no puede estar vacio");
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(TelefonotextBox.Text))
            {
                errorProvider.SetError(TelefonotextBox, "Este campo no puede estar vacio");
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(CelulartextBox.Text))
            {
                errorProvider.SetError(CelulartextBox, "Este campo no puede estar vacio");
                paso = false;
            }
            if (FechadateTimePicker.Value > DateTime.Now)
            {
                errorProvider.SetError(FechadateTimePicker, "La fecha no puede ser mayor que la de hoy");
                paso = false;
            }

            return paso;
        }
        public static bool RepetirUser(string descripcion)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Usuario.Any(p => p.Usuario.Equals(descripcion)))
                {
                    paso = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
        public static bool RepetirEmail(string descripcion)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Cliente.Any(p => p.Email.Equals(descripcion)))
                {
                    paso = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
        private bool ValidarRepetir()
        {
            bool paso = true;
            errorProvider.Clear();

            if (RepetirUser(NombrestextBox.Text))
            {
                errorProvider.SetError(NombrestextBox, "No se debe repetir los usuarios.");
                paso = false;
            }
            if (RepetirEmail(EmailtextBox.Text))
            {
                errorProvider.SetError(EmailtextBox, "No se debe usar el mismo email que otro.");
                paso = false;
            }
            return paso;
        }
        private void Limpiar()
        {
            ClienteIdnumericUpDown.Value = 0;
            NombrestextBox.Text = string.Empty;
            EmailtextBox.Text = string.Empty;
            DirecciontextBox.Text = string.Empty;
            TelefonotextBox.Text = string.Empty;
            CelulartextBox.Text = string.Empty;
            FechadateTimePicker.Value = DateTime.Now;
            DeudatextBox.Clear();
            errorProvider.Clear();
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Repositorio<Clientes> dbe = new Repositorio<Clientes>( new Contexto());
            Clientes clientes = dbe.Buscar((int)((int)ClienteIdnumericUpDown.Value));
            return (clientes != null);

        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id;
            Clientes clientes = new Clientes();
            Repositorio<Clientes> dbe = new Repositorio<Clientes>(new Contexto());
            int.TryParse(ClienteIdnumericUpDown.Text, out id);
            Limpiar();
            clientes = dbe.Buscar(id);

            if (clientes != null)
            {
                LlenaCampo(clientes);
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
            Repositorio<Clientes> dbe = new Repositorio<Clientes>(new Contexto());
            Clientes clientes = new Clientes();

            clientes = LlenaClase();


            if (ClienteIdnumericUpDown.Value == 0)
            {
                if (!ValidarRepetir())
                    return;
                paso = dbe.Guardar(clientes);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar un cliente que no existe", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = dbe.Modificar(clientes);
            }

            if (paso)
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Limpiar();
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            Repositorio<Clientes> dbe = new Repositorio<Clientes>(new Contexto());
            if (!ExisteEnLaBaseDeDatos())
            {
                MessageBox.Show("No se puede Eliminar un cliente que no existe", "fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            errorProvider.Clear();
            int id;
            int.TryParse(ClienteIdnumericUpDown.Text, out id);

            Limpiar();

            if (dbe.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                errorProvider.SetError(ClienteIdnumericUpDown, "No se puede eliminar un cliente que no existe");
        }
    }
}
