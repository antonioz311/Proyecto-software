// Services/MovimientoServicio.cs
using GestionInventario.Models;
using GestionInventario.Repositories;
using System;
using System.Collections.Generic;

namespace GestionInventario.Services
{
    public class MovimientoServicio
    {
        private readonly MovimientoRepositorio _movimientoRepositorio;
        private readonly ProductoRepositorio _productoRepositorio;

        public MovimientoServicio(MovimientoRepositorio movimientoRepositorio, ProductoRepositorio productoRepositorio)
        {
            _movimientoRepositorio = movimientoRepositorio;
            _productoRepositorio = productoRepositorio;
        }

        public void AdicionarExistencias(int productoId, int cantidad, string motivo)
        {
            var producto = _productoRepositorio.ObtenerProductoPorId(productoId);
            if (producto == null)
            {
                throw new ArgumentException("Producto no encontrado.");
            }

            var movimiento = new Movimiento
            {
                ProductoId = productoId,
                TipoMovimiento = "Ingreso",
                Cantidad = cantidad,
                Motivo = motivo
            };

            _movimientoRepositorio.CrearMovimiento(movimiento);
            producto.Cantidad += cantidad;
        }

        public void DisminuirExistencias(int productoId, int cantidad, string motivo)
        {
            var producto = _productoRepositorio.ObtenerProductoPorId(productoId);
            if (producto == null)
            {
                throw new ArgumentException("Producto no encontrado.");
            }

            if (producto.Cantidad < cantidad)
            {
                throw new ArgumentException("Cantidad insuficiente en inventario.");
            }

            var movimiento = new Movimiento
            {
                ProductoId = productoId,
                TipoMovimiento = "Salida",
                Cantidad = cantidad,
                Motivo = motivo
            };

            _movimientoRepositorio.CrearMovimiento(movimiento);
            producto.Cantidad -= cantidad;
        }

        public List<Movimiento> ObtenerMovimientosPorProducto(int productoId)
        {
            return _movimientoRepositorio.ObtenerMovimientosPorProducto(productoId);
        }

        public List<Movimiento> ObtenerMovimientos()
        {
            return _movimientoRepositorio.ObtenerMovimientos();
        }
    }
}
