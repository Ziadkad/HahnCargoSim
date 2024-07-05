using Backend.Services.Interfaces;

namespace Backend.Services;

public class GridService : IGridService
{
    public async Task<string> Get(string token)
    {
        throw new NotImplementedException();
    }

    public async Task GenerateFile(int numberOfNodes, int numberOfEdges, int numberOfConnectionsPerNode, string filename,string token)
    {
        throw new NotImplementedException();
    }
}