using Blazored.LocalStorage;
using IceArena.Data.Models;
using IceArena.Data.Requests;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

public class AuthService
{
    private readonly HttpClient _httpClient;
    private readonly ILocalStorageService _localStorage;

    public AuthService(HttpClient httpClient, ILocalStorageService localStorage)
    {
        _httpClient = httpClient;
        _localStorage = localStorage;
    }

    public async Task<LoginResponse> Login(LoginRequest request)
    {
        Console.WriteLine($"Отправка запроса: Email={request.Email}, Password={request.Password}");
        Console.WriteLine($"Сериализованный JSON: {System.Text.Json.JsonSerializer.Serialize(request)}");

        var response = await _httpClient.PostAsJsonAsync("api/auth/login", request, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Invalid login attempt.");
        }

        var result = await response.Content.ReadFromJsonAsync<LoginResponse>();

        await _localStorage.SetItemAsStringAsync("authToken", result.Token);
        await _localStorage.SetItemAsync("userId", result.UserId);
        await _localStorage.SetItemAsStringAsync("username", result.Username);
        await _localStorage.SetItemAsStringAsync("role", result.Role);

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", result.Token);
        return result;
    }

    public async Task Logout()
    {
        await _localStorage.RemoveItemAsync("authToken");
        _httpClient.DefaultRequestHeaders.Authorization = null;
    }

    public async Task<string> GetToken()
    {
        return await _localStorage.GetItemAsStringAsync("authToken");
    }
}