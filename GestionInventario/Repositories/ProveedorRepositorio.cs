// Repositories/ProveedorRepositorio.cs
using GestionInventario.Models;
using System.Collections.Generic;
using System.Linq;

namespace GestionInventario.Repositories
{
    public class ProveedorRepositorio
    {
        private static List<Proveedor> _proveedores = new List<Proveedor>();

        // Crear proveedor
        public void CrearProveedor(Proveedor proveedor)
        {
            _proveedores.Add(proveedor);
        }

        // Obtener todos los proveedores
        public List<Proveedor> ObtenerProveedores()
        {
            return _proveedores;
        }

        // Obtener proveedor por ID
        public Proveedor? ObtenerProveedorPorId(int id)
        {
            return _proveedores.FirstOrDefault(p => p.Id == id);
        }

        // Actualizar proveedor
        public void ActualizarProveedor(Proveedor proveedorModificado)
        {
            var proveedor = _proveedores.FirstOrDefault(p => p.Id == proveedorModificado.Id);
            if (proveedor != null)
            {
                proveedor.Nombre = proveedorModificado.Nombre;
                proveedor.Direccion = proveedorModificado.Direccion;
                proveedor.Telefono = proveedorModificado.Telefono;
                // Actualizar otros atributos si es necesario
            }
            else
            {
                throw new ArgumentException("Proveedor no encontrado.");
            }
        }

        // Eliminar proveedor
        public void EliminarProveedor(int id)
        {
            var proveedor = _proveedores.FirstOrDefault(p => p.Id == id);
            if (proveedor != null)
            {
                _proveedores.Remove(proveedor);
            }
            else
            {
                throw new ArgumentException("Proveedor no encontrado.");
            }
        }
    }
}
