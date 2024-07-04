using Backend.Model;
using Backend.Services.Interfaces;

namespace Backend.Services;

public class OrderService : IOrderService
{
    public async Task<List<Order>> GetAllAvailable()
    {
        throw new NotImplementedException();
    }

    public async Task<List<Order>> GetAllAccepted()
    {
        throw new NotImplementedException();
    }

    public async Task Accept(int orderId)
    {
        throw new NotImplementedException();
    }

    public async Task Create()
    {
        throw new NotImplementedException();
    }

    public async Task GenerateFile(int maxTicks, string filename)
    {
        throw new NotImplementedException();
    }
}