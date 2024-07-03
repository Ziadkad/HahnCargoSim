namespace Backend.Services.Interfaces;

public interface IGridService
{
    string Get();
    void GenerateFile(int numberOfNodes, int numberOfEdges, int numberOfConnectionsPerNode, string filename);
}