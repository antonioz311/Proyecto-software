// Services/ProductoServicio.cs
using GestionInventario.Models;
using GestionInventario.Repositories;
using System.Collections.Generic;

namespace GestionInventario.Services
{
    public class ProductoServicio
    {
        private readonly ProductoRepositorio _productoRepositorio;
        private readonly ProveedorRepositorio _proveedorRepositorio;

        public ProductoServicio(ProductoRepositorio productoRepositorio, ProveedorRepositorio proveedorRepositorio)
        {
            _productoRepositorio = productoRepositorio;
            _proveedorRepositorio = proveedorRepositorio;
        }

        public void CrearProducto(Producto producto)
        {
            // Verificar que el proveedor exista
            var proveedor = _proveedorRepositorio.ObtenerProveedorPorId(producto.ProveedorId);
            if (proveedor == null)
            {
                throw new ArgumentException("Proveedor no encontrado.");
            }
            producto.Proveedor = proveedor;
            _productoRepositorio.CrearProducto(producto);
        }

        public List<Producto> ObtenerProductos()
        {
            return _productoRepositorio.ObtenerProductos();
        }

        public Producto? ObtenerProductoPorId(int id)
        {
            return _productoRepositorio.ObtenerProductoPorId(id);
        }

        public void ActualizarProducto(Producto producto)
        {
            // Verificar que el proveedor exista
            var proveedor = _proveedorRepositorio.ObtenerProveedorPorId(producto.ProveedorId);
            if (proveedor == null)
            {
                throw new ArgumentException("Proveedor no encontrado.");
            }
            producto.Proveedor = proveedor;
            _productoRepositorio.ActualizarProducto(producto);
        }

        public void EliminarProducto(int id)
        {
            _productoRepositorio.EliminarProducto(id);
        }
    }
}
