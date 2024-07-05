using Backend.Model;

namespace Backend.Services.Interfaces;

public interface IOrderService
{
    Task<List<Order>> GetAllAvailable(string token);
    Task<List<Order>> GetAllAccepted(string token);
    Task Accept(int orderId,string token);
    Task Create(string token);
    Task GenerateFile(int maxTicks, string filename, string token);

}