namespace Backend.Services.Interfaces;

public interface IGridService
{
    Task<string> Get(string token);
    Task GenerateFile(int numberOfNodes, int numberOfEdges, int numberOfConnectionsPerNode, string filename, string token);
}