using NexoAPP.Models;

namespace NexoAPP.Services
{
    public class CarritoService
    {
        public List<Producto> ProductosEnCarrito { get; private set; } = new();

        public event Action? OnChange;

        public void AgregarProducto(Producto producto)
        {
            var productoExistente = ProductosEnCarrito.FirstOrDefault(p => p.IdProducto == producto.IdProducto);
            if (productoExistente != null)
            {
                productoExistente.Cantidad += producto.Cantidad;
            }
            else
            {
                ProductosEnCarrito.Add(producto);
            }
            NotificarCambio();
        }

        public void EliminarProducto(int idProducto)
        {
            var productoAEliminar = ProductosEnCarrito.FirstOrDefault(p => p.IdProducto == idProducto);
            if (productoAEliminar != null)
            {
                ProductosEnCarrito.Remove(productoAEliminar);
                NotificarCambio();
            }
        }

        public void VaciarCarrito()
        {
            ProductosEnCarrito.Clear();
            NotificarCambio();
        }

        public decimal Total => ProductosEnCarrito.Sum(p => p.Precio * p.Cantidad);

        public async Task<List<Producto>> ObtenerProductosAsync()
        {
            await Task.Delay(100);
            return ProductosEnCarrito;
        }

        private void NotificarCambio() => OnChange?.Invoke();
    }
}