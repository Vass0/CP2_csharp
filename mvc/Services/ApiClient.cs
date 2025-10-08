using System.Net.Http.Json;

namespace Prova.Mvc.Services;

public class ApiClient
{
    private readonly HttpClient _http;
    public ApiClient(IHttpClientFactory factory) => _http = factory.CreateClient("api");

    public async Task<T?> GetAsync<T>(string path) => await _http.GetFromJsonAsync<T>(path);
    public async Task<HttpResponseMessage> PostAsync<T>(string path, T body) => await _http.PostAsJsonAsync(path, body);
}
