// Controllers/ProveedorController.cs
using GestionInventario.Models;
using GestionInventario.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace GestionInventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly ProveedorServicio _proveedorServicio;

        public ProveedorController(ProveedorServicio proveedorServicio)
        {
            _proveedorServicio = proveedorServicio;
        }

        /// <summary>
        /// Obtener todos los proveedores.
        /// </summary>
        [HttpGet("GetAll")]
        public ActionResult<List<Proveedor>> GetAll()
        {
            return Ok(_proveedorServicio.ObtenerProveedores());
        }

        /// <summary>
        /// Obtener un proveedor por su ID.
        /// </summary>
        [HttpGet("GetById/{id}")]
        public ActionResult<Proveedor> GetById(int id)
        {
            var proveedor = _proveedorServicio.ObtenerProveedorPorId(id);
            if (proveedor == null)
                return NotFound(new { Message = $"Proveedor con ID {id} no encontrado." });

            return Ok(proveedor);
        }

        /// <summary>
        /// Crear un nuevo proveedor.
        /// </summary>
        [HttpPost("Create")]
        public ActionResult Create([FromBody] Proveedor proveedor)
        {
            try
            {
                _proveedorServicio.CrearProveedor(proveedor);
                return Ok(new { Message = "Proveedor creado exitosamente." });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        /// <summary>
        /// Actualizar un proveedor existente.
        /// </summary>
        [HttpPut("Update")]
        public ActionResult Update([FromBody] Proveedor proveedor)
        {
            try
            {
                _proveedorServicio.ActualizarProveedor(proveedor);
                return Ok(new { Message = "Proveedor actualizado exitosamente." });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        /// <summary>
        /// Eliminar un proveedor por su ID.
        /// </summary>
        [HttpDelete("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _proveedorServicio.EliminarProveedor(id);
                return Ok(new { Message = "Proveedor eliminado exitosamente." });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
