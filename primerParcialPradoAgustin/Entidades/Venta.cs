using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using spaceArticulo;

namespace spaceVenta
{
    public class Venta
    {
        private Articulo _articuloVendido;
        private int _cantidad;

        #region CONSTRUCTORES
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        /// <param name="articuloVendido">Artículo vendido.</param>
        /// <param name="Cantidad">Cantidad vendida.</param>
        public Venta(Articulo articuloVendido, int Cantidad)
        {
            this._articuloVendido = articuloVendido;
            this._cantidad = Cantidad;
        }
        #endregion

        #region MÉTODOS
        /// <summary>
        /// Retorna el dinero que obtuvimos por la venta de la cantidad del Artículo por el precio del mismo. 
        /// </summary>
        /// <returns>Dinero de la venta.</returns>
        public float RetornarGanancia()
        {
            return _cantidad * _articuloVendido.PrecioVenta;
        }
        #endregion
    }
}
