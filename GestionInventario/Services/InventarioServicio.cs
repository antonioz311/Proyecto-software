// Services/InventarioServicio.cs
using GestionInventario.Models;
using GestionInventario.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace GestionInventario.Services
{
    public class InventarioServicio
    {
        private readonly ProductoRepositorio _productoRepositorio;
        private readonly MovimientoRepositorio _movimientoRepositorio;

        public InventarioServicio(ProductoRepositorio productoRepositorio, MovimientoRepositorio movimientoRepositorio)
        {
            _productoRepositorio = productoRepositorio;
            _movimientoRepositorio = movimientoRepositorio;
        }

        public List<ProductoInventarioDto> ConsultarInventario(string? nombre = null, string? categoria = null)
        {
            var productos = _productoRepositorio.ObtenerProductos();

            if (!string.IsNullOrEmpty(nombre))
            {
                productos = productos.Where(p => p.Nombre.Contains(nombre, System.StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (!string.IsNullOrEmpty(categoria))
            {
                productos = productos.Where(p => p.Categoria.Contains(categoria, System.StringComparison.OrdinalIgnoreCase)).ToList();
            }

            var inventario = productos.Select(p => new ProductoInventarioDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Categoria = p.Categoria,
                PrecioUnitario = p.PrecioUnitario,
                CantidadDisponible = p.Cantidad
            }).ToList();

            return inventario;
        }

        public List<ProductoInventarioDto> ObtenerInventarioCompleto()
        {
            return ConsultarInventario();
        }
    }

    public class ProductoInventarioDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Categoria { get; set; } = null!;
        public decimal PrecioUnitario { get; set; }
        public int CantidadDisponible { get; set; }
    }
}
