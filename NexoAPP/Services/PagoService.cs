using NexoAPP.Models;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace NexoAPP.Services
{
    public class PagoService
    {
        private readonly HttpClient _http;
        private const string Url = "https://localhost:5080/api/Pago";

        public PagoService(HttpClient http)
        {
            _http = http ?? throw new ArgumentNullException(nameof(http));
        }

        public async Task<bool> CrearPago(Pago pago)
        {
            var response = await _http.PostAsJsonAsync("https://localhost:5080/api/Pago", pago);

            return response.IsSuccessStatusCode;
        }

        public async Task<List<Pago>> ObtenerPagos()
        {
            return await _http.GetFromJsonAsync<List<Pago>>("api/pago");
        }

        public async Task<bool> EliminarPago(int idPago)
        {
            var response = await _http.DeleteAsync($"api/pago/{idPago}");
            return response.IsSuccessStatusCode;
        }

    }
}
