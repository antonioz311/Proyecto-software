// Models/Producto.cs
using System;

namespace GestionInventario.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Categoria { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public DateTime? FechaExpiracion { get; set; } // Nullable si no aplica
        public int ProveedorId { get; set; }
        public Proveedor Proveedor { get; set; } = null!;
    }
}
