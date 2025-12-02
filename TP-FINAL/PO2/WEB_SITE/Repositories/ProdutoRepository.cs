using Models;
using System.Text;
using System.Text.Json;

//Desenvolvido por Laysa Bernardes e Lucas Lopes

namespace WEB_SITE.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly HttpClient _httpClient;
        private const string BaseApiUrl = "api/produto/Produto";
        public ProdutoRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Produto?> AddAsync(Produto produto, int usuarioId)
        {
            produto.IdUsuarioCadastro = usuarioId;

            var jsonContent = JsonSerializer.Serialize(produto);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(BaseApiUrl, content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Produto>(responseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }

            return null; 
        }

        public Task<bool> DeleteAsync(int id)
        {
            var response = _httpClient.DeleteAsync($"{BaseApiUrl}/{id}");

            return response.ContinueWith(task => task.Result.IsSuccessStatusCode);
        }

        public async Task<Produto[]> GetAllAsync()
        {
            var response = await _httpClient.GetAsync(BaseApiUrl);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var produtos = JsonSerializer.Deserialize<IEnumerable<Produto>>(
                    responseContent,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

                return produtos?.ToArray();
            }

            return null;
        }

        public async Task<Produto?> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{BaseApiUrl}/{id}");

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Produto>(responseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }

            return null;
        }

        public async Task<Produto?> UpdateAsync(Produto produto, int usuarioId)
        {
            produto.IdUsuarioUpdate = usuarioId;
            
            var jsonContent = JsonSerializer.Serialize(produto);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"{BaseApiUrl}/{produto.Id}?usuarioId={usuarioId}", content);

            if (response.IsSuccessStatusCode)
                 return produto;

            return null;
        }
    }
}
