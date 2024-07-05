using Backend.Model;

namespace Backend.Services.Interfaces;

public interface ICargoTransporterService
{
    Task<int> Buy(int positionNodeId, string token);
    Task<CargoTransporter> Get(int transporterId, string token);
    Task Move(int transporterId, int targetNodeId, string token);
}