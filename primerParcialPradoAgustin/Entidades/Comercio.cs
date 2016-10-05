using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using spaceArticulo;
using spaceVenta;

namespace spaceComercio
{
    public class Comercio
    {
        private string _dueño;
        private List<Articulo> _misArticulos;
        private List<Venta> _misVentas;

        #region CONSTRUCTORES
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        /// <param name="dueño">Nombre del dueño.</param>
        public Comercio(string dueño)
        {
            this._dueño = dueño;
            this._misArticulos = new List<Articulo>();
            this._misVentas = new List<Venta>();
        }
        #endregion

        #region MÉTODOS

        #region MÉTODOS ESTÁTICOS
        /// <summary>
        /// Recorre la lista de artículos de mi comercio y muestra el nombre y el código de cada artículo. 
        /// </summary>
        /// <param name="ComercioAMostrar">Comercio a mostrar.</param>
        public static void MostrarArticulos(Comercio ComercioAMostrar)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Los productos existentes son");
            foreach (Articulo item in ComercioAMostrar._misArticulos)
            {
                sb.AppendLine(item.NombreYCodigo);
            }

            Console.WriteLine(sb.ToString());
        }

        /// <summary>
        /// Muestra la cantidad total de ganancia que se obtuvo en las ventas realizadas en el comercio.
        /// </summary>
        /// <param name="ComercioParaResumen">Comercio a mostrar.</param>
        public static void MostrarGanancia(Comercio ComercioParaResumen)
        {
            float ganancia = 0;

            foreach (Venta item in ComercioParaResumen._misVentas)
            {
                ganancia += item.RetornarGanancia();
            }

            Console.WriteLine("La ganancia obtenida es de: " + ganancia);
        }

        #endregion

        #region MÉTODOS DE INSTANCIA
        /// <summary>
        /// Si el articulo ya existe en el comercio, solo limitaremos la acción a incrementar el stock el articulo existente, de lo contrario agregaremos este producto que recibimos por parámetro a la lista de artículos.
        /// </summary>
        /// <param name="articuloComprado">Artículo a comprar.</param>
        public void ComprarArticulo(Articulo articuloComprado)
        {
            foreach (Articulo item in this._misArticulos)
            {
                if (item == articuloComprado)
                {
                    item.Stock = item + articuloComprado;
                    return;
                }
            }
            this._misArticulos.Add(articuloComprado);
        }

        /// <summary>
        /// Se recibirá un artículo y una cantidad, si el artículo existe y su Stock es mayor o igual a la cantidad solicitada, esta cantidad será descontada del stock del artículo de nuestra lista, y se deberá registrar la venta en la lista de ventas de mi comercio.
        /// </summary>
        /// <param name="articuloSolicitado">Artículo a vender.</param>
        /// <param name="cantidad">Cantidad a vender.</param>
        public void VenderArticulo(Articulo articuloSolicitado, int cantidad)
        {
            foreach (Articulo item in this._misArticulos)
            {
                if (item == articuloSolicitado)  
                {
                    if (item.HayStock(cantidad))
                    {
                        item.Stock = item - cantidad;
                        this._misVentas.Add(new Venta(articuloSolicitado, cantidad));
                    }
                    else
                    {
                        Console.WriteLine("El siguiente Producto no tiene stock para la venta!!!");
                        Console.WriteLine(articuloSolicitado.NombreYCodigo);
                    }
                    return;
                }
            }

            Console.WriteLine("El siguiente Producto no existe en nuestro comercio!!!");
            Console.WriteLine(articuloSolicitado.NombreYCodigo);
        }
        #endregion

        #endregion
    }
}
