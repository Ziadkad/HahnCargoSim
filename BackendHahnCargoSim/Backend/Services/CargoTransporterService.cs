using Backend.Model;
using Backend.Services.Interfaces;

namespace Backend.Services;

public class CargoTransporterService : ICargoTransporterService
{
    public async Task<int> Buy(int positionNodeId)
    {
        throw new NotImplementedException();
    }

    public async Task<CargoTransporter> Get(int transporterId)
    {
        throw new NotImplementedException();
    }

    public async Task Move(int transporterId, int targetNodeId)
    {
        throw new NotImplementedException();
    }
}