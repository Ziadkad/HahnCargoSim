using Backend.Model;
using Backend.Services.Interfaces;

namespace Backend.Services;

public class OrderService : IOrderService
{
    public List<Order> GetAllAvailable()
    {
        throw new NotImplementedException();
    }

    public List<Order> GetAllAccepted()
    {
        throw new NotImplementedException();
    }

    public void Accept(int orderId)
    {
        throw new NotImplementedException();
    }

    public void Create()
    {
        throw new NotImplementedException();
    }

    public void GenerateFile(int maxTicks, string filename)
    {
        throw new NotImplementedException();
    }
}