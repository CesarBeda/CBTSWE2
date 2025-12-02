using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;

//Cesar Beda CB302704X

namespace WINDOWS_FORMS.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUri = "api/usuario/Usuario"; 

        public UsuarioRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Usuario>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync(_baseUri);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<Usuario>>();
        }

        public async Task<Usuario> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{_baseUri}/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Usuario>();
        }

        public async Task AddAsync(Usuario usuario)
        {
            var response = await _httpClient.PostAsJsonAsync(_baseUri, usuario);
            response.EnsureSuccessStatusCode();
        }
        public async Task UpdateAsync(Usuario usuario)
        {
            var response = await _httpClient.PutAsJsonAsync($"{_baseUri}/{usuario.Id}", usuario);
            response.EnsureSuccessStatusCode();
        }
        public async Task DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUri}/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
