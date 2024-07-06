using System.Net.Http.Headers;
using Backend.Model;
using Backend.Services.Interfaces;
using Newtonsoft.Json;

namespace Backend.Services;

public class GridService : IGridService
{
    
    private readonly IConfiguration _configuration;

    public GridService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<string> Get(string token)
    {
         using (var httpClient = new HttpClient())
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response =
                await httpClient.GetAsync(_configuration.GetValue<string>("HahnCarGoSim:EndPoint") + "/Grid/Get");
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return responseContent;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<BadRequest>(errorContent);
                throw new HttpRequestException($"Bad Request: {error.Message}");
            }
            else
            {
                return response.EnsureSuccessStatusCode().ToString();
            }
        }
    }

    public async Task GenerateFile(int numberOfNodes, int numberOfEdges, int numberOfConnectionsPerNode, string filename,string token)
    {
        using (var httpClient = new HttpClient())
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Construct the URL based on parameters
            string apiUrl = _configuration.GetValue<string>("HahnCarGoSim:EndPoint")+"/Grid/GenerateFile?" +
                            $"numberOfNodes={numberOfNodes}&" +
                            $"numberOfEdges={numberOfEdges}&" +
                            $"numberOfConnectionsPerNode={numberOfConnectionsPerNode}&" +
                            $"filename={filename}";

            var response = await httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var fileContent = await response.Content.ReadAsStringAsync();
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<BadRequest>(errorContent);
                throw new HttpRequestException($"Bad Request: {error.Message}");
            }
            else
            {
                response.EnsureSuccessStatusCode(); // This will throw an exception if the status code is not success
            }
        }
    }
}