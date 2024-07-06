using System.Net.Http.Headers;
using System.Text;
using Backend.Model;
using Backend.Services.Interfaces;
using Newtonsoft.Json;

namespace Backend.Services;

public class SimService : ISimService
{
    
    private readonly IConfiguration _configuration;

    public SimService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public async Task Start(string token)
    {
        using (var httpClient = new HttpClient())
        {           
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var content = new StringContent("{}", Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(_configuration.GetValue<string>("HahnCarGoSim:EndPoint") + "/Sim/Start", content);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
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
            } 
        }
    }

    public async Task Stop(string token)
    {
        using (var httpClient = new HttpClient())
        {           
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var content = new StringContent("{}", Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(_configuration.GetValue<string>("HahnCarGoSim:EndPoint") + "/Sim/Stop", content);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
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
            } 
        }
    }
}