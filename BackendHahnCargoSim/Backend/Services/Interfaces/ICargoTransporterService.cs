using Backend.Model;

namespace Backend.Services.Interfaces;

public interface ICargoTransporterService
{
    Task<int> Buy(int positionNodeId);
    Task<CargoTransporter> Get(int transporterId);
    Task Move(int transporterId, int targetNodeId);
}