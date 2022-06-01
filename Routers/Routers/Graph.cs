using System.Text.RegularExpressions;

namespace Routers;

/// <summary>
/// Graph class with adjacency matrix as a property and dfs, connection checking and parsing methods
/// </summary>
public class Graph : IGraph
{
    public int MaxNodeNumber { get; private set; }

    public int[,] Matrix { get; }
    
    public Dictionary<(int, int), int> Edges { get; set; }

    public Graph(string inputFilePath)
    {
        var size = GetSize(inputFilePath);
        Matrix = new int[size, size];
        Edges = new Dictionary<(int, int), int>();
        Parse(inputFilePath);
        Edges = Edges.OrderBy(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
    }

    private void Parse(string inputFilePath)
    {
        using StreamReader reader = new StreamReader(inputFilePath);
        
        while (true)
        {
            string? line = reader.ReadLine();
            if (line == null)
            {
                return;
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
    public void DeleteEdge(int row, int col) => (Matrix[row, col], Matrix[col, row]) = (0, 0);
    
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