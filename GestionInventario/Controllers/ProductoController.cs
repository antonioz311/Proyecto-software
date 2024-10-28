// Controllers/ProductoController.cs
using GestionInventario.Models;
using GestionInventario.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace GestionInventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ProductoServicio _productoServicio;

        public ProductoController(ProductoServicio productoServicio)
        {
            _productoServicio = productoServicio;
        }

        
        /// Obtener todos los productos.
        
        [HttpGet("GetAll")]
        public ActionResult<List<Producto>> GetAll()
        {
            return Ok(_productoServicio.ObtenerProductos());
        }

      
        /// Obtener un producto por su ID.
       
        [HttpGet("GetById/{id}")]
        public ActionResult<Producto> GetById(int id)
        {
            var producto = _productoServicio.ObtenerProductoPorId(id);
            if (producto == null)
                return NotFound(new { Message = $"Producto con ID {id} no encontrado." });

            return Ok(producto);
        }

      
        /// Crear un nuevo producto.
       
        [HttpPost("Create")]
        public ActionResult Create([FromBody] Producto producto)
        {
            try
            {
                _productoServicio.CrearProducto(producto);
                return Ok(new { Message = "Producto creado exitosamente." });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

      
        /// Actualizar un producto existente.
       
        [HttpPut("Update")]
        public ActionResult Update([FromBody] Producto producto)
        {
            try
            {
                _productoServicio.ActualizarProducto(producto);
                return Ok(new { Message = "Producto actualizado exitosamente." });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

      
        /// Eliminar un producto por su ID.
       
        [HttpDelete("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _productoServicio.EliminarProducto(id);
                return Ok(new { Message = "Producto eliminado exitosamente." });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
