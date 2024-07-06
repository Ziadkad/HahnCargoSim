using System.Net;
using System.Net.Http.Headers;
using Backend.Model;
using Backend.Services.Interfaces;
using Newtonsoft.Json;

namespace Backend.Services;

public class CargoTransporterService : ICargoTransporterService
{
    
    private readonly IConfiguration _configuration;

    public CargoTransporterService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<int> Buy(int positionNodeId,string token)
    {
          using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Construct the API URL with query parameter
                string apiUrl = _configuration.GetValue<string>("HahnCarGoSim:EndPoint")+"/CargoTransporter/Buy?positionNodeId="+positionNodeId;

                // Send the GET request
                var response = await httpClient.PostAsync(apiUrl, null);

                if (response.IsSuccessStatusCode)
                {
                    // Read the response content
                    var responseContent = await response.Content.ReadAsStringAsync();
                    
                    // Deserialize JSON response to CargoTransporterModel
                    var num = JsonConvert.DeserializeObject<int>(responseContent);
                    
                    return num;
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedAccessException("Unauthorized access to the API.");
                }
                else
                {
                    // Handle other error cases
                    response.EnsureSuccessStatusCode();
                    return 0; // or throw an appropriate exception
                }
            }
    }

    public async Task<CargoTransporter> Get(int transporterId,string token)
    {
        using (var httpClient = new HttpClient())
                    {
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                        // Construct the API URL with query parameter
                        string apiUrl = _configuration.GetValue<string>("HahnCarGoSim:EndPoint")+"/CargoTransporter/Get?transporterId="+transporterId;

                        // Send the GET request
                        var response = await httpClient.GetAsync(apiUrl);

                        if (response.IsSuccessStatusCode)
                        {
                            // Read the response content
                            var responseContent = await response.Content.ReadAsStringAsync();
                            
                            // Deserialize JSON response to CargoTransporterModel
                            var cargoTransporter = JsonConvert.DeserializeObject<CargoTransporter>(responseContent);
                            
                            return cargoTransporter;
                        }
                        else if (response.StatusCode == HttpStatusCode.Unauthorized)
                        {
                            throw new UnauthorizedAccessException("Unauthorized access to the API.");
                        }
                        else
                        {
                            // Handle other error cases
                            response.EnsureSuccessStatusCode();
                            return null; // or throw an appropriate exception
                        }
                    }
    }

    public async Task Move(int transporterId, int targetNodeId, string token)
    {
                using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Construct the API URL
                string apiUrl = _configuration.GetValue<string>("HahnCarGoSim:EndPoint")+"/CargoTransporter/Move?transporterId="+transporterId+"&targetNodeId="+targetNodeId;

                // Send the PUT request (HttpMethod.Put)
                var response = await httpClient.PutAsync(apiUrl, null);

                if (response.IsSuccessStatusCode)
                {
                    // Optional: Handle success scenario if needed
                }
                else if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"Bad Request: {errorContent}");
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedAccessException("Unauthorized access to the API.");
                }
                else
                {
                    // Handle other error cases
                    response.EnsureSuccessStatusCode();
                    // Optional: Throw an appropriate exception or handle the error
                }
            }
    }
}