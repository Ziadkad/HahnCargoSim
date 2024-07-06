using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;
using Backend.Model;
using Backend.Services.Interfaces;
using Newtonsoft.Json;

namespace Backend.Services;

public class UserService : IUserService
{
    private readonly IConfiguration _configuration;

    public UserService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<UserToken> Login(UserAuthenticate userAuthenticate)
    {
        using (var httpClient = new HttpClient())
        {
            var json = JsonConvert.SerializeObject(userAuthenticate);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(_configuration.GetValue<string>("HahnCarGoSim:EndPoint")+"/User/Login", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var loginResponse = JsonConvert.DeserializeObject<UserToken>(responseContent);
                return loginResponse;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<BadRequest>(errorContent);
                throw new HttpRequestException($"Bad Request: {error.Message}");
            }
            else
            {
                response.EnsureSuccessStatusCode();
                return null; // This line will never be reached, but is necessary to satisfy the return type.
            }
        }
    }

    public async Task<int> CoinAmount(string token)
    {
        using (var httpClient = new HttpClient())
        {           
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.GetAsync(_configuration.GetValue<string>("HahnCarGoSim:EndPoint") + "/CoinAmount");
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var responseDeserialized = JsonConvert.DeserializeObject<int>(responseContent);
                return responseDeserialized;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<BadRequest>(errorContent);
                throw new HttpRequestException($"Bad Request: {error.Message}");
            }
            else
            {
                response.EnsureSuccessStatusCode();
                return 0; // This line will never be reached, but is necessary to satisfy the return type.
            } 
        }
    }
}