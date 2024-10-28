// Controllers/InventarioController.cs
using GestionInventario.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GestionInventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioController : ControllerBase
    {
        private readonly InventarioServicio _inventarioServicio;

        public InventarioController(InventarioServicio inventarioServicio)
        {
            _inventarioServicio = inventarioServicio;
        }


        /// Consultar inventario por nombre y/o categoría.
        
        [HttpGet("Consultar")]
        public ActionResult<List<ProductoInventarioDto>> ConsultarInventario([FromQuery] string? nombre, [FromQuery] string? categoria)
        {
            var inventario = _inventarioServicio.ConsultarInventario(nombre, categoria);
            return Ok(inventario);
        }


        /// Obtener el inventario completo.
        
        [HttpGet("GetAll")]
        public ActionResult<List<ProductoInventarioDto>> GetAll()
        {
            var inventario = _inventarioServicio.ObtenerInventarioCompleto();
            return Ok(inventario);
        }
    }
}
