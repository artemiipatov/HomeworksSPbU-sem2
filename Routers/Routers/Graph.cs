namespace Routers;

public class Graph
{
    static readonly int arrayLength = 7;
    private int maxNodeNumber = 0;
    public int[,] Matrix = new int[arrayLength, arrayLength];
    
    private enum TypeOfValue
    {
        Weight,
        NodeNumber
    }

    public Graph(string inputFilePath)
    {
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
            int startNode = int.Parse(splitLine[0].Split(":")[0]);
            if (startNode > maxNodeNumber)
            {
                maxNodeNumber = startNode;
            }
            for (var i = 1; i < splitLine.Length; i++)
            {
                string[] splitSplitLine = splitLine[i].Split("(");
                int finishNode = int.Parse(splitSplitLine[0]);
                if (finishNode > maxNodeNumber)
                {
                    maxNodeNumber = finishNode;
                }
                int weight = int.Parse(splitSplitLine[1].Split(")")[0]);
                Matrix[startNode, finishNode] = weight;
                Matrix[finishNode, startNode] = weight;
            }
        }
    }

    public void GenerateConfig(string outputFilePath)
    {
        var edges = new SortedDictionary<int, (int, int)>(); // weigth (startingNodeNumber, finalNodeNumber)
        for (int i = 0; i <= maxNodeNumber; i++)
        {
            for (int j = i; j <= maxNodeNumber; j++)
            {
                int weight = Matrix[i, j];
                if (weight != 0)
                {
                    edges.Add(weight, (i, j));
                }
            }
        }

        int nodeCounter = 0;
        foreach (var key in edges.Keys)
        {
            if (nodeCounter == maxNodeNumber)
            {
                break;
            }
            int firstNode = edges[key].Item1;
            int secondNode = edges[key].Item2;
            Matrix[firstNode, secondNode] = 0;
            Matrix[secondNode, firstNode] = 0;
            if (CheckConnectivity(firstNode, secondNode))
            {
                nodeCounter++;
                continue;
            }
            Matrix[firstNode, secondNode] = key;
            Matrix[secondNode, firstNode] = key;
        }

        using var outputStream = new StreamWriter(outputFilePath);
        for (int i = 0; i <= maxNodeNumber; i++)
        {
            string curNodeConfig = i.ToString() + ":";
            for (int j = i; j <= maxNodeNumber; j++)
            {
                int weight = Matrix[i, j];
                if (weight != 0)
                {
                    curNodeConfig += $" {j.ToString()}({weight.ToString()})";
                }
            }
            outputStream.WriteLine(curNodeConfig);
        }
    }

    private bool CheckConnectivity(int searchedNode, int currentNode)
    {
        var visited = new bool[maxNodeNumber + 1];
        return Dfs(searchedNode, currentNode, ref visited);
    }

    private bool Dfs(int currentNode, int searchedNode, ref bool[] visited)
    {
        if (searchedNode == currentNode)
        {
            return true;
        }
        visited[currentNode] = true;
        for (int adj = 0; adj < maxNodeNumber + 1; adj++)
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