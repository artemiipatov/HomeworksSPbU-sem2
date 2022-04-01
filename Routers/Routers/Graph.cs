namespace Routers;
public class Graph
{
    static readonly int ArrayLength = 7;

    public int MaxNodeNumber { get; set; }

    public int[,] Matrix { get; }

    public Dictionary<(int, int), int> Edges { get; set; }

    public Graph(string inputFilePath)
    {
        Matrix = new int[ArrayLength, ArrayLength];
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