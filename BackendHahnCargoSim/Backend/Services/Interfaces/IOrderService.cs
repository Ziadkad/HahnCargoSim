using Backend.Model;

namespace Backend.Services.Interfaces;

public interface IOrderService
{
    List<Order> GetAllAvailable();
    List<Order> GetAllAccepted();
    void Accept(int orderId);
    void Create();
    void GenerateFile(int maxTicks, string filename);

}