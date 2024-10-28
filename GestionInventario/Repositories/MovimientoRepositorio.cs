// Repositories/MovimientoRepositorio.cs
using GestionInventario.Models;
using System.Collections.Generic;
using System.Linq;

namespace GestionInventario.Repositories
{
    public class MovimientoRepositorio
    {
        private static List<Movimiento> _movimientos = new List<Movimiento>();

        // Crear movimiento
        public void CrearMovimiento(Movimiento movimiento)
        {
            _movimientos.Add(movimiento);
        }

        // Obtener movimientos por producto
        public List<Movimiento> ObtenerMovimientosPorProducto(int productoId)
        {
            return _movimientos.Where(m => m.ProductoId == productoId).ToList();
        }

        // Obtener todos los movimientos
        public List<Movimiento> ObtenerMovimientos()
        {
            return _movimientos;
        }
    }
}
