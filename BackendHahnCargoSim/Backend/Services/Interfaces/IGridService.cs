namespace Backend.Services.Interfaces;

public interface IGridService
{
    Task<string> Get();
    Task GenerateFile(int numberOfNodes, int numberOfEdges, int numberOfConnectionsPerNode, string filename);
}