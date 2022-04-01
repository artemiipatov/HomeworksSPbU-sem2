namespace Routers;

public interface IGraph
{
    int MaxNodeNumber { get; }

    int[,] Matrix { get; }

    Dictionary<(int, int), int> Edges { get; set; }

    void DeleteEdge(int row, int col);

    bool CheckConnectivity(int searchedNode, int currentNode);
}