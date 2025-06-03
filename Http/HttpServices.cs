using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
namespace SIMRS25.Http
{
    public class HttpServices
    {
        private readonly HttpClient _httpClient;

        public string? AuthToken { get; set; } // Sanctum token

        public HttpServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        private void AddAuthorizationHeaderIfNeeded()
        {
            _httpClient.DefaultRequestHeaders.Authorization = null;

            if (!string.IsNullOrWhiteSpace(AuthToken))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", AuthToken);
            }
        }

        public async Task<TResponse?> GetAsync<TResponse>(string url, bool withAuth = true)
        {
            if (withAuth) AddAuthorizationHeaderIfNeeded();

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<TResponse>();
        }

        public async Task<TResponse?> PostAsync<TRequest, TResponse>(string url, TRequest data, bool withAuth = true)
        {
            if (withAuth) AddAuthorizationHeaderIfNeeded();

            var response = await _httpClient.PostAsJsonAsync(url, data);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<TResponse>();
        }

        public async Task<TResponse?> PutAsync<TRequest, TResponse>(string url, TRequest data, bool withAuth = true)
        {
            if (withAuth) AddAuthorizationHeaderIfNeeded();

            var response = await _httpClient.PutAsJsonAsync(url, data);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<TResponse>();
        }

        public async Task<TResponse?> DeleteAsync<TResponse>(string url, bool withAuth = true)
        {
            if (withAuth) AddAuthorizationHeaderIfNeeded();

            var response = await _httpClient.DeleteAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<TResponse>();
        }
    }
}
