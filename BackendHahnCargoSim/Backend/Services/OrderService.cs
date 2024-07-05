using Backend.Model;
using Backend.Services.Interfaces;

namespace Backend.Services;

public class OrderService : IOrderService
{
    public async Task<List<Order>> GetAllAvailable(string token)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Order>> GetAllAccepted(string token)
    {
        throw new NotImplementedException();
    }

    public async Task Accept(int orderId,string token)
    {
        throw new NotImplementedException();
    }

    public async Task Create(string token)
    {
        throw new NotImplementedException();
    }

    public async Task GenerateFile(int maxTicks, string filename,string token)
    {
        throw new NotImplementedException();
    }
}