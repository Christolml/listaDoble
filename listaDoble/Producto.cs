using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace listaDoble
{
    class Producto
    {

        public int codigo { get; set; }
        public int cantidad { get; set; }
        public float precio { get; set; }
        public string nombre { get; set; }

        public Producto Siguiente { get; set; }
        public Producto Anterior { get; set; }


        public Producto(int codigo, string nombre, int cantidad, int precio)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.cantidad = cantidad;
            this.precio = precio;

        }


        public override string ToString()
        {

            string mostrar = "";
            mostrar = " Código del producto: " + codigo + "\r\n Nombre del producto: " + nombre + "\r\n Cantidad del producto: "
                + cantidad + "\r\n Precio del producto: " + precio + "\r\n";

            return mostrar;
        }
    }
}
