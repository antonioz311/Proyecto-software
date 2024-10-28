// Repositories/ProductoRepositorio.cs
using GestionInventario.Models;
using System.Collections.Generic;
using System.Linq;

namespace GestionInventario.Repositories
{
    public class ProductoRepositorio
    {
        private static List<Producto> _productos = new List<Producto>();

        // Crear producto
        public void CrearProducto(Producto producto)
        {
            _productos.Add(producto);
        }

        // Obtener todos los productos
        public List<Producto> ObtenerProductos()
        {
            return _productos;
        }

        // Obtener producto por ID
        public Producto? ObtenerProductoPorId(int id)
        {
            return _productos.FirstOrDefault(p => p.Id == id);
        }

        // Actualizar producto
        public void ActualizarProducto(Producto productoModificado)
        {
            var producto = _productos.FirstOrDefault(p => p.Id == productoModificado.Id);
            if (producto != null)
            {
                producto.Nombre = productoModificado.Nombre;
                producto.Categoria = productoModificado.Categoria;
                producto.Cantidad = productoModificado.Cantidad;
                producto.PrecioUnitario = productoModificado.PrecioUnitario;
                producto.FechaExpiracion = productoModificado.FechaExpiracion;
                producto.ProveedorId = productoModificado.ProveedorId;
                producto.Proveedor = productoModificado.Proveedor;
            }
            else
            {
                throw new ArgumentException("Producto no encontrado.");
            }
        }

        // Eliminar producto
        public void EliminarProducto(int id)
        {
            var producto = _productos.FirstOrDefault(p => p.Id == id);
            if (producto != null)
            {
                _productos.Remove(producto);
            }
            else
            {
                throw new ArgumentException("Producto no encontrado.");
            }
        }
    }
}
