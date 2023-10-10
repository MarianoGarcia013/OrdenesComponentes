using Parcial2023.Datos.Implementaciones;
using Parcial2023.Dominio;
using Parcial2023.Servicio;
using Produccion.Datos;
using Produccion.Domino;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//COMPLETAR --> Curso:1W3      Legajo:114063         Apellido y Nombre: Chaname Alexis

//CadenaDeConexion: "Data Source=172.16.10.196;Initial Catalog=Produccion;User ID=alumno1w1;Password=alumno1w1"

namespace Produccion.Presentacion
{
    public partial class FrmAlta : Form
    {
        private GestorComponente gestorC;
        private OrdenProduccion orden;
        private GestorOrden gestorO;
        public FrmAlta()
        {
            InitializeComponent();
            orden = new OrdenProduccion(); 
            gestorC = new GestorComponente(new DaoComponente());
            gestorO = new GestorOrden(new DaoOrden());
            CargarCombo();
        }

        private void CargarCombo()
        {
            cboComponente.DataSource = gestorC.ObtenerComponentes();
            cboComponente.DisplayMember= "Nombre";
            cboComponente.ValueMember= "Codigo";
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea cancelar?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Dispose();
            }
        }
        private void FrmAlta_Load(object sender, EventArgs e)
        {            
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Componente comp = (Componente)cboComponente.SelectedItem;
            int cant = Convert.ToInt32(numericUpDown1.Value);
            int subtotal = cant*(int)nudCantidad.Value;
            DetalleOrden detalle = new DetalleOrden(comp,cant);
            dgvDetalles.Rows.Add(new object[] { comp.Nombre, cant, subtotal,"(-) Quitar" });
            orden.AgregarDetalle(detalle);
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {

            if (dgvDetalles.Rows.Count < 2)
            {
                MessageBox.Show("Debe agregar por lo menos 2 componentes", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (string.IsNullOrEmpty(txtDT.Text))
            {
                MessageBox.Show("Debe ingresar un Modelo", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            orden.Modelo = txtDT.Text;
            orden.Cantidad = (int)nudCantidad.Value;
            orden.Fecha = dtpFecha.Value;
            int nro_salida = gestorO.Crear(orden);
            MessageBox.Show("Se creo la orden " +nro_salida.ToString(), "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return;
        }
        private void dgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalles.CurrentCell.ColumnIndex == 4)
            {
                orden.QuitarDetalle(dgvDetalles.CurrentRow.Index);
                dgvDetalles.Rows.RemoveAt(dgvDetalles.CurrentRow.Index);
            }
        }
    }
}
