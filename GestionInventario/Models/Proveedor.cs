// Models/Proveedor.cs
using System;

namespace GestionInventario.Models
{
    public class Proveedor
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Direccion { get; set; }
        public required string Telefono { get; set; }
        // Otros atributos adicionales si es necesario
    }
}
