using Models;
using System.Text.Json;

//Desenvolvido por Laysa Bernardes e Lucas Lopes

namespace WEB_SITE.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly HttpClient _httpClient;
        private const string BaseApiUrl = "api/usuario/Usuario";
        public UsuarioRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Usuario?> GetUsuarioByNome(string nome)
        {
            var url = $"{BaseApiUrl}/{nome}";

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<Usuario>(
                    responseContent,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );
            }

            return null;
        }
    }
}
