using System.Text.RegularExpressions;

namespace Routers;

/// <summary>
/// Graph class with adjacency matrix as a property and dfs, connection checking and parsing methods.
/// </summary>
public class Graph
{
    public int MaxNodeNumber { get; private set; }

    private int[,]? Matrix;

    /// <summary>
    /// Parses file into matrix.
    /// </summary>
    /// <returns>Returns dictionary with edges of the graph and their weight.</returns>
    public Dictionary<(int, int), int>? Parse(string inputFilePath)
    {
        var size = GetSize(inputFilePath);
        Matrix = new int[size, size];

        using StreamReader reader = new StreamReader(inputFilePath);

        Dictionary<(int, int), int> Edges = new Dictionary<(int, int), int>();

        while (true)
        {
            string? line = reader.ReadLine();
            if (line == null)
            {
                break;
            }

            string[] splitLine = line.Split(" ");
            if (splitLine.Length <= 1)
            {
                throw new WrongInputException("Wrong input: some routers are disconnected from others from the beginning");
            }
            
            int startNode = int.Parse(splitLine[0].Split(":")[0]);

            if (startNode > MaxNodeNumber)
            {
                MaxNodeNumber = startNode;
            }

            for (var i = 1; i < splitLine.Length; i++)
            {
                string[] splitSplitLine = splitLine[i].Split("(");
                
                int finishNode = int.Parse(splitSplitLine[0]);

                if (finishNode > MaxNodeNumber)
                {
                    MaxNodeNumber = finishNode;
                }

                int weight = int.Parse(splitSplitLine[1].Split(")")[0]);
                Edges.Add((startNode, finishNode), weight);
                Matrix[startNode, finishNode] = weight;
                Matrix[finishNode, startNode] = weight;
            }
        }
        return Edges;
    }

    private int GetSize(string inputFilePath)
    {
        int size = 0;
        
        using var reader = new StreamReader(inputFilePath);
        
        while (!reader.EndOfStream)
        {
            string[] numbers = Regex.Split(reader.ReadLine()!, @"\D+");
            foreach (string value in numbers)
            {
                if (!string.IsNullOrEmpty(value))
                {
                    int i = int.Parse(value);
                    size = i > size ? i : size;
                }
            }
        }

        return size + 1;
    }

    /// <summary>
    /// Sets edge weigth to null
    /// </summary>
    public void DeleteEdgeFromMatrix(int row, int col) => (Matrix![row, col], Matrix[col, row]) = (0, 0);

    public void SetEdge(int row, int col, int value) => (Matrix![row, col], Matrix[col, row]) = (value, value);

    public int GetEdge(int row, int col) => Matrix![row, col];

    /// <summary>
    /// Checks if graph is connected
    /// </summary>
    public bool CheckConnectivity(int searchedNode, int currentNode)
    {
        var visited = new bool[MaxNodeNumber + 1];
        return Dfs(searchedNode, currentNode, ref visited);
    }

    private bool Dfs(int currentNode, int searchedNode, ref bool[] visited)
    {
        if (searchedNode == currentNode)
        {
            return true;
        }

        visited[currentNode] = true;
        for (int adj = 0; adj < MaxNodeNumber + 1; adj++)
        {
            if (Matrix[currentNode, adj] != 0)
            {
                if (!visited[adj] && Dfs(adj, searchedNode, ref visited))
                {
                    return true;
                }
            }
        }

        return false;
    }
}