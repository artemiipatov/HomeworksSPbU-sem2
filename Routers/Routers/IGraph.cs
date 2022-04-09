namespace Routers;

public interface IGraph
{
    /// <summary>
    /// Maximum node number
    /// </summary>
    int MaxNodeNumber { get; }

    /// <summary>
    /// Adjacency matrix of the graph
    /// </summary>
    int[,] Matrix { get; }

    /// <summary>
    /// Dictionary containing edges of the graph. The keys are the coordinates of the edges, the values are the weights of the edges.
    /// </summary>
    Dictionary<(int, int), int> Edges { get; set; }

    /// <summary>
    /// Removes edge
    /// </summary>
    /// <param name="row"></param>
    /// <param name="col"></param>
    void DeleteEdge(int row, int col);

    /// <summary>
    /// Returns true if the path between given nodes exists, false if it doesn't exist
    /// </summary>
    /// <param name="searchedNode"></param>
    /// <param name="currentNode"></param>
    bool CheckConnectivity(int searchedNode, int currentNode);
}