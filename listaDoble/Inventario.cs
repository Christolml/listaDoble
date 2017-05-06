using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace listaDoble
{
    class Inventario
    {

        private Producto Primero;
        private Producto Ultimo;
        int contador = 0;

        public Inventario()
        {
            Primero = null;
            Ultimo = null;
        }


        public void agregarProducto(Producto nuevo)
        {
            if (buscarInicio(nuevo.codigo) == false)     //cuando es false quiere decir que no hay aun ese codigo y lo deja agregar a la lista
            {
                if (Primero == null)
                {
                    Primero = nuevo;
                    Ultimo = nuevo;
                }
                else
                    agregarProducto(Primero, nuevo);
                contador++;

            }

        }


        private void agregarProducto(Producto ultimo, Producto nuevo)
        {
            if (ultimo.Siguiente == null)
            {
                Ultimo = nuevo;
                ultimo.Siguiente = nuevo;
                Ultimo.Anterior = ultimo;
            }
            else
                agregarProducto(ultimo.Siguiente, nuevo);

        }

        /// <summary>
        /// Recibe un producto y lo coloca al inicio de la lista
        /// </summary>
        /// <param name="nuevo"></param>
        public void agregarEnInicio(Producto nuevo)
        {
            if (buscarInicio(nuevo.codigo) == false)     //cuando es false quiere decir que no hay aun ese codigo y lo deja agregar a la lista
            {
                Producto Actual = Primero;
                if(Primero == null)
                {
                    Primero = nuevo;
                    contador++;
                }
                else
                {
                    Primero = nuevo;
                    Actual.Anterior = Primero;
                    Primero.Siguiente = Actual;
                    contador++;
                }
            }

        }

        /// <summary>
        /// Método con el cual nos sirve verificar si ya existe un código y 
        /// este método lo maneja en gran parte el form 
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public bool buscarInicio(int codigo)
        {
            bool mostrar = false;
            Producto Actual = Primero;
            bool encontrado = false;

            while (Actual != null && encontrado != true)
            {
                if (Actual.codigo == codigo)
                {
                    mostrar = true;
                    encontrado = true;
                }
                Actual = Actual.Siguiente;
            }

            return mostrar;
        }

        /// <summary>
        /// Método con el cual nos sirve verificar si una posición podría existir y 
        /// este método lo maneja sobretodo el form
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public bool buscarInicioPos(int pos)
        {
            bool mostrar = false;
            if (pos <= contador)
                mostrar = true;
            return mostrar;
        }


        #region          métodos con posición del producto

        public void insertarPosicion(Producto nuevo, int posicion)
        {
            Producto Actual = Primero;
            Producto temporal = null;

            if (buscarInicio(nuevo.codigo) == false)     //cuando es false quiere decir que no hay aun ese codigo y lo deja agregar a la lista
            {

                if (Primero != null)
                {
                    if (posicion == 1)
                    {
                        agregarEnInicio(nuevo);
                    }
                    else
                    {
                        for (int i = 1; i < (posicion - 1); i++)
                        {
                            Actual = Actual.Siguiente;
                        }
                        temporal = Actual.Siguiente;
                        Actual.Siguiente = nuevo;
                        nuevo.Anterior = Actual;       
                        nuevo.Siguiente = temporal;
                        temporal.Anterior = nuevo;
                        contador++;
                    }
                }
                else
                    MessageBox.Show("Error, lista vacia");
            }
        }


        public void eliminarProductoPos(int posicion)
        {
            Producto Actual = Primero;
            Producto temporal = null;

            if (Primero != null)
            {
                if (posicion <= contador && posicion > 0)
                {
                    if (posicion == 1)
                    {
                        eliminarPrimero();
                    }
                    else if(posicion == contador)
                    {
                        eliminarUltimo();
                    }
                    else
                    {
                        for (int i = 1; i < (posicion -  1); i++)
                        {
                            Actual = Actual.Siguiente;
                        }
                        temporal = Actual.Siguiente;
                        Actual.Siguiente = temporal.Siguiente;
                        temporal.Siguiente.Anterior = Actual;
                        contador--; 
                    }
                }

            }
            else
                MessageBox.Show("Error, lista vacia");

        }


        public Producto buscarProductoPos(int posicion)
        {
            Producto mostrar = null;
            Producto Actual = Primero;

            if (Primero != null)
            {
                if (posicion <= contador && posicion > 0)
                {
                    if (posicion == 1)
                        mostrar = Primero;

                    else
                    {
                        for (int i = 1; i < posicion; i++)
                        {
                            Actual = Actual.Siguiente;
                        }
                        mostrar = Actual;
                    }
                }

            }
            else
                MessageBox.Show("Error, lista vacia");

            return mostrar;
        }



        #endregion

        public void eliminarPrimero()
        {
            try
            {
                Primero = Primero.Siguiente;
                Primero.Anterior = null;
                contador--;
            }
            catch
            {
                Primero = null;
                Ultimo = null;
            }
        }

        public void eliminarUltimo()
        {
            try
            {
                Ultimo = Ultimo.Anterior;
                Ultimo.Siguiente = null;
                contador--;
            }
            catch
            {
                Primero = null;
                Ultimo = null;
            }
        }


        public string reporteInverso()
        {
            string mostrar = "";
            Producto Final = Ultimo;

            if (Final != null)
            {
                while (Final != null)
                {
                    mostrar += Final.ToString() + "\r\n";
                    Final = Final.Anterior;
                }
            }
            else
                mostrar = "La lista no contiene elementos";


            return mostrar;
        }

        public string reporte()
        {
            string mostrar = "";
            Producto Actual = Primero;

            if (Actual != null)
            {
                while (Actual != null)
                {
                    mostrar += Actual.ToString() + "\r\n";
                    Actual = Actual.Siguiente;
                }
            }
            else
                mostrar = "La lista no contiene elementos disponibles";

            return mostrar;
        }

    }
}
