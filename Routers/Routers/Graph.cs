namespace Routers;

using UtilityExceptions;

/// <summary>
/// Graph class with adjacency matrix as a property and dfs, connection checking and parsing methods
/// </summary>
public class Graph : IGraph
{
    private int _arrayLength = 10;

    public int MaxNodeNumber { get; private set; }

    public int[,] Matrix { get; private set; }

    public Dictionary<(int, int), int> Edges { get; set; }

    public Graph(string inputFilePath)
    {
        Matrix = new int[_arrayLength, _arrayLength];
        Edges = new Dictionary<(int, int), int>();
        Parse(inputFilePath);
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
            if (startNode >= _arrayLength)
            {
                Resize();
            }
            if (startNode > MaxNodeNumber)
            {
                MaxNodeNumber = startNode;
            }

            for (var i = 1; i < splitLine.Length; i++)
            {
                string[] splitSplitLine = splitLine[i].Split("(");
                
                int finishNode = int.Parse(splitSplitLine[0]);
                while (finishNode >= _arrayLength)
                {
                    Resize();
                }
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

    public void DeleteEdge(int row, int col) => (Matrix[row, col], Matrix[col, row]) = (0, 0);

    private void Resize()
    {
        _arrayLength *= 2;
        int[,] tempMatrix = new int[_arrayLength, _arrayLength];
        for (int i = 0; i <= MaxNodeNumber; i++)
        {
            for (int j = 0; j <= MaxNodeNumber; j++)
            {
                tempMatrix[i, j] = Matrix[i, j];
            }
        }
        
        Matrix = tempMatrix;
    }

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