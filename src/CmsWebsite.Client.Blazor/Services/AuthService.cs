using Blazored.LocalStorage;
using CmsWebsite.Share.Models.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace CmsWebsite.Client.Blazor.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        public AuthService(HttpClient httpClient, ILocalStorageService localStorage, AuthenticationStateProvider authenticationStateProvider)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            var loginResponse = await _httpClient.PostAsJsonAsync("api/auth/login", loginRequest);

            if (loginResponse.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                var contentBadRequest = await loginResponse.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<LoginResponse>(contentBadRequest);
            }

            var content = await loginResponse.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<LoginResponse>(content,
                new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });
            //lưu vào local stogared của client
            await _localStorage.SetItemAsync("authToken", result.Token);
            //đánh dấu trang thái authenticated
            ((CustomStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(loginRequest.UserName);
            //gán vào http
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", result.Token);

            return result;

        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((CustomStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }

        public async Task Register(RegisterRequest registerRequest)
        {
            var result = await _httpClient.PostAsJsonAsync("api/auth/register", registerRequest);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            result.EnsureSuccessStatusCode();
        }

    }
}
