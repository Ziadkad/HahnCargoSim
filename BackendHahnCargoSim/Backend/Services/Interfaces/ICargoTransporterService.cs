using Backend.Model;

namespace Backend.Services.Interfaces;

public interface ICargoTransporterService
{
    int Buy(int positionNodeId);
    CargoTransporter Get(int transporterId);
    void Move(int transporterId, int targetNodeId);
}