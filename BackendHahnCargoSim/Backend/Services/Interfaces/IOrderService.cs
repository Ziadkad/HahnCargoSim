using Backend.Model;

namespace Backend.Services.Interfaces;

public interface IOrderService
{
    Task<List<Order>> GetAllAvailable();
    Task<List<Order>> GetAllAccepted();
    Task Accept(int orderId);
    Task Create();
    Task GenerateFile(int maxTicks, string filename);

}