using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spaceArticulo
{
    public class Articulo
    {
        private int _codigo;
        private string _nombre;
        private float _precioCosto;
        private float _precioVenta;
        private int _stock;
        
        #region PROPIEDADES
        /// <summary>
        /// Sólo retorna un String que tienen concatenado el nombre y el código del Artículo.
        /// </summary>
		public string NombreYCodigo
        {
            get
            {
                return this._codigo + "--" + this._nombre;
            }
        }
        /// <summary>
        /// Sólo permite asignar un nuevo precio de Costo al artículo y asigna el precio de venta sumándole un 30% al costo. 
        /// </summary>
        public float PrecioCosto
        {
            set
            {
                this._precioCosto = value;
                this._precioVenta = value * 1.3F;
            }
        }
        /// <summary>
        /// Sólo retorna el precio de venta.
        /// </summary>
        public float PrecioVenta
        {
            get
            {
                return this._precioVenta;
            }
        }
        /// <summary>
        /// Sólo permite asignar un nuevo Stock.
        /// </summary>
        public int Stock
        {
            set
            {
                this._stock = value;
            }
        }
	    #endregion

        #region CONSTRUCTORES
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        /// <param name="codigo">Código del artículo.</param>
        /// <param name="nombre">Nombre del artículo.</param>
        /// <param name="precioCosto">Precio del costo del artículo.</param>
        /// <param name="cantidad">Cantidad del artículo.</param>
        public Articulo(int codigo, string nombre, float precioCosto, int cantidad)
        {
            this._codigo = codigo;
            this._nombre = nombre;
            this.PrecioCosto = precioCosto;
            this.Stock = cantidad;
        }
        #endregion

        #region MÉTODOS
        /// <summary>
        /// Retorna un booleano indicando si el Stock de ese Artículo es mayor o igual a la cantidad que recibe por parámetro.
        /// </summary>
        /// <param name="cantidad">Cantidad a verificar.</param>
        /// <returns>true hay stock disponible y false si no lo hay.</returns>
		public bool HayStock(int cantidad)
        {
            return (this._stock >= cantidad);
        }
	    #endregion

        #region SOBRECARGA DE OPERADORES
        /// <summary>
        /// Retornará un booleano informando si el nombre y el código de los artículos coinciden al mismo tiempo. 
        /// </summary>
        /// <param name="articuloUno">Artículo uno.</param>
        /// <param name="articuloDos">Artículo dos.</param>
        /// <returns></returns>
		public static bool operator ==(Articulo articuloUno, Articulo articuloDos)
        {
            return (String.Compare(articuloUno.NombreYCodigo, articuloDos.NombreYCodigo) == 0);
        }

        /// <summary>
        /// Retornará un booleano informando si el nombre y el código de los artículos no coinciden al mismo tiempo. 
        /// </summary>
        /// <param name="articuloUno">Artículo uno.</param>
        /// <param name="articuloDos">Artículo dos.</param>
        /// <returns></returns>
        public static bool operator !=(Articulo articuloUno, Articulo articuloDos)
        {
            return !(articuloUno == articuloDos);
        }

        /// <summary>
        /// Retorna un número entero que es el resultado de la suma del stock de los Artículos que recibe por parámetro.
        /// </summary>
        /// <param name="articuloUno">Artículo uno.</param>
        /// <param name="articuloDos">Artículo dos.</param>
        /// <returns></returns>
        public static int operator +(Articulo articuloUno, Articulo articuloDos)
        {
            return (articuloUno._stock + articuloDos._stock);
        }

        /// <summary>
        /// Retorna un número entero que es el resultado de la resta del stock del Artículo menos la cantidad recibida por parámetro. 
        /// </summary>
        /// <param name="articuloUno">Artículo de donde se restará la cantidad.</param>
        /// <param name="cantidad">Cantidad a restar.</param>
        /// <returns></returns>
        public static int operator -(Articulo articuloUno, int cantidad)
        {
            return (articuloUno._stock - cantidad);
        }
	    #endregion

    }
}
