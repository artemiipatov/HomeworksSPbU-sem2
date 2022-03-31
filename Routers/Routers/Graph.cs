namespace Routers;

public static class RoutersUtility
{
    public static void GenerateConfig(string inputFilePath, string outputFilePath)
    {
        Graph graph = new Graph(inputFilePath);
        
        graph.Edges = graph.Edges.OrderBy(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);

        int nodeCounter = 0;
        foreach (var key in graph.Edges.Keys)
        {
            if (nodeCounter == graph.MaxNodeNumber)
            {
                break;
            }

            int firstNode = key.Item1;
            int secondNode = key.Item2;
            graph.Matrix[firstNode, secondNode] = 0;
            graph.Matrix[secondNode, firstNode] = 0;
            if (graph.CheckConnectivity(firstNode, secondNode))
            {
                nodeCounter++;
                continue;
            }

            graph.Matrix[firstNode, secondNode] = graph.Edges[key];
            graph.Matrix[secondNode, firstNode] = graph.Edges[key];
        }

        using var outputStream = new StreamWriter(outputFilePath);
        for (int i = 0; i <= graph.MaxNodeNumber; i++)
        {
            string curNodeConfig = i.ToString() + ":";
            for (int j = i; j <= graph.MaxNodeNumber; j++)
            {
                int weight = graph.Matrix[i, j];
                if (weight != 0)
                {
                    curNodeConfig += $" {j.ToString()}({weight.ToString()})";
                }
            }

            outputStream.WriteLine(curNodeConfig);
        }
    }
}