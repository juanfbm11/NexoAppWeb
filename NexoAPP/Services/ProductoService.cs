using NexoAPP.Models;
using System.Net.Http.Json;

namespace NexoAPP.Services
{
    public class ProductoService
    {
        private readonly HttpClient _httpClient;
        private readonly string _url = "http://localhost:5080/api/Productos";

        public ProductoService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        // ✅ Obtener todos los productos
        public async Task<List<Producto>> GetAllAsync()
        {
            try
            {
                var productos = await _httpClient.GetFromJsonAsync<List<Producto>>(_url);
                return productos ?? new List<Producto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al obtener productos: {ex.Message}");
                throw;
            }
        }

        // ✅ Crear un nuevo producto (ahora sí lo guarda realmente)
        public async Task CrearProductoAsync(Producto producto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(_url, producto);

                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"⚠️ Error al crear producto: {response.StatusCode} - {error}");
                    throw new Exception("No se pudo crear el producto.");
                }

                Console.WriteLine("✅ Producto creado correctamente en la API.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al crear producto: {ex.Message}");
                throw;
            }
        }
    }
}