using System.Collections.Immutable;

namespace Routers;

public class Graph
{
    static readonly int ArrayLength = 7;
    private int _maxNodeNumber = 0;
    
    public int[,] Matrix = new int[ArrayLength, ArrayLength];
    
    private Dictionary<(int, int), int> _edges = new();

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
            if (startNode > _maxNodeNumber)
            {
                _maxNodeNumber = startNode;
            }
            for (var i = 1; i < splitLine.Length; i++)
            {
                string[] splitSplitLine = splitLine[i].Split("(");
                int finishNode = int.Parse(splitSplitLine[0]);
                if (finishNode > _maxNodeNumber)
                {
                    _maxNodeNumber = finishNode;
                }
                int weight = int.Parse(splitSplitLine[1].Split(")")[0]);
                _edges.Add((startNode, finishNode), weight);
                Matrix[startNode, finishNode] = weight;
                Matrix[finishNode, startNode] = weight;
            }
        }
    }

    public void GenerateConfig(string outputFilePath)
    {
        _edges = _edges.OrderBy(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);

        int nodeCounter = 0;
        foreach (var key in _edges.Keys)
        {
            if (nodeCounter == _maxNodeNumber)
            {
                break;
            }
            int firstNode = key.Item1;
            int secondNode = key.Item2;
            Matrix[firstNode, secondNode] = 0;
            Matrix[secondNode, firstNode] = 0;
            if (CheckConnectivity(firstNode, secondNode))
            {
                nodeCounter++;
                continue;
            }
            Matrix[firstNode, secondNode] = _edges[key];
            Matrix[secondNode, firstNode] = _edges[key];
        }

        using var outputStream = new StreamWriter(outputFilePath);
        for (int i = 0; i <= _maxNodeNumber; i++)
        {
            string curNodeConfig = i.ToString() + ":";
            for (int j = i; j <= _maxNodeNumber; j++)
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
        var visited = new bool[_maxNodeNumber + 1];
        return Dfs(searchedNode, currentNode, ref visited);
    }

    private bool Dfs(int currentNode, int searchedNode, ref bool[] visited)
    {
        if (searchedNode == currentNode)
        {
            return true;
        }
        visited[currentNode] = true;
        for (int adj = 0; adj < _maxNodeNumber + 1; adj++)
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