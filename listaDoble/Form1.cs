using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace listaDoble
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        Inventario inventario = new Inventario();



        private void btnAgregar_Click(object sender, EventArgs e)
        {
            bool agregado = inventario.buscarInicio(Convert.ToInt16(txtCodigo.Text));
            Producto producto = new Producto(Convert.ToInt16(txtCodigo.Text), txtNombre.Text, Convert.ToInt16(txtCantidad.Text), Convert.ToInt16(txtPrecio.Text));
            inventario.agregarProducto(producto);

            verificadorCodigo(agregado, producto);
        }


        private void btnAgregarInicio_Click_1(object sender, EventArgs e)
        {
            bool agregado = inventario.buscarInicio(Convert.ToInt16(txtCodigo.Text));
            Producto producto = new Producto(Convert.ToInt16(txtCodigo.Text), txtNombre.Text, Convert.ToInt16(txtCantidad.Text), Convert.ToInt16(txtPrecio.Text));
            inventario.agregarEnInicio(producto);

            verificadorCodigo(agregado, producto);
        }


        private void btnReporte_Click(object sender, EventArgs e)
        {
            txtReporte.Text = inventario.reporte();
        }

        private void btnReporteVolteado_Click_1(object sender, EventArgs e)
        {
            txtReporte.Text = inventario.reporteInverso();
            //txtReporte.Text = inventario.reporteVolteado();
        }
    

        #region             Botones basados en la posición


        private void btnBuscarPos_Click_1(object sender, EventArgs e)
        {
            Producto buscado = inventario.buscarProductoPos(Convert.ToInt16(txtPosiciónConsulta.Text));
            if (buscado != null)
            {
                txtReporte.Text = buscado.ToString();
            }
            else
                MessageBox.Show("Error, producto no encontrado");
        }

        private void btnEliminarPos_Click_1(object sender, EventArgs e)
        {
            bool agregado = inventario.buscarInicioPos(Convert.ToInt16(txtPosiciónConsulta.Text));
            inventario.eliminarProductoPos(Convert.ToInt16(txtPosiciónConsulta.Text));

            if (agregado == true)
            {
                txtReporte.Text = "";
                MessageBox.Show("Producto eliminado");
            }
            else
            {
                MessageBox.Show("Esa posición no existe");
                txtReporte.Text = "";
            }
        }

        private void btnInsertarPos_Click_1(object sender, EventArgs e)
        {
            bool agregado = inventario.buscarInicio(Convert.ToInt16(txtCodigo.Text));
            Producto producto = new Producto(Convert.ToInt16(txtCodigo.Text), txtNombre.Text, Convert.ToInt16(txtCantidad.Text), Convert.ToInt16(txtPrecio.Text));
            inventario.insertarPosicion(producto, Convert.ToInt16(txtPos.Text));

            verificadorCodigo(agregado, producto);
        }

        #endregion



        private void verificadorCodigo(bool agregado, Producto producto)
        {
            if (agregado == false)
            {
                MessageBox.Show("Producto guardado");
                txtReporte.Text = producto.ToString();
            }
            else
            {
                MessageBox.Show("Ese código ya existe");
                txtReporte.Text = "";
            }
        }


        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminarPrimero_Click(object sender, EventArgs e)
        {
            inventario.eliminarPrimero();
            MessageBox.Show("Elemento eliminado");
            btnReporte_Click(sender,e);

        }

        private void btnEliminarUltimo_Click(object sender, EventArgs e)
        {
            inventario.eliminarUltimo();
            MessageBox.Show("Elemento eliminado");
            btnReporte_Click(sender, e);
        }
    }
}
