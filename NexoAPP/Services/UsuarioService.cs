using NexoAPP.Models;
using System.Net.Http.Json;

namespace NexoAPP.Services
{
    public class UsuarioService
    {
        //URL base de la API
        private readonly HttpClient _httpClient;
        private readonly string _url = "http://localhost:5080/api/Usuario" ;

        //Constructor: recibe HttpClient inyectado por Blazor
        public UsuarioService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        //Obtener todos los usuarios
        public async Task<List<Usuario>> GetAllAsync()
        {
            try
            {
                var usuarios = await _httpClient.GetFromJsonAsync<List<Usuario>>(_url);
                return usuarios ?? new List<Usuario>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Error al obtener usuarios: {ex.Message}");
                throw;
            }
        }

        //Crear un nuevo usuario
        public async Task<bool> CreateAsync(Usuario nuevoUsuario)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(_url, nuevoUsuario);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($" Error al crear usuario: {ex.Message}");
                throw;
            }
        }
        // Actualizar usuario
        public async Task<bool> UpdateAsync(Usuario usuarioActualizado)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"{_url}/{usuarioActualizado.Id}", usuarioActualizado);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($" Error al actualizar usuario: {ex.Message}");
                throw;
            }
        }

        // Eliminar usuario
        public async Task<bool> DeleteAsync(int usuarioId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{_url}/{usuarioId}");
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($" Error al eliminar usuario: {ex.Message}");
                throw;
            }
        }


        // 3. Iniciar sesión
        public async Task<Usuario?> LoginAsync(string correo, string contrasena)
        {
            try
            {
                var loginData = new { Correo = correo, Contrasena = contrasena };
                var response = await _httpClient.PostAsJsonAsync($"{_url}/login", loginData);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<Usuario>();
                }
                else
                {
                    
                    var error = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error de login: {error}");
                    return null;
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al iniciar sesión: {ex.Message}");
                throw;
            }
        }

    }
}
