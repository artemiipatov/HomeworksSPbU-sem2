namespace Routers;

public static class RoutersUtility
{
    public static void GenerateConfig(string inputFilePath, string outputFilePath)
    {
        IGraph graph = new Graph(inputFilePath);
        
        graph.Edges = graph.Edges.OrderBy(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);

        int edgeCounter = 0;
        foreach (var key in graph.Edges.Keys)
        {
            if (graph.Edges.Count - edgeCounter == graph.MaxNodeNumber)
            {
                break;
            }

            int firstNode = key.Item1;
            int secondNode = key.Item2;
            graph.DeleteEdge(firstNode, secondNode);
            if (graph.CheckConnectivity(firstNode, secondNode))
            {
                edgeCounter++;
                continue;
            }

            graph.Matrix[firstNode, secondNode] = graph.Edges[key];
            graph.Matrix[secondNode, firstNode] = graph.Edges[key];
        }

        using var outputStream = new StreamWriter(outputFilePath);
        for (int i = 0; i <= graph.MaxNodeNumber; i++)
        {
            bool weightIsNotZeroForTheFirstTime = true;
            string curNodeConfig = "";
            for (int j = i; j <= graph.MaxNodeNumber; j++)
            {
                int weight = graph.Matrix[i, j];
                if (weight != 0)
                {
                    if (weightIsNotZeroForTheFirstTime)
                    {
                        curNodeConfig = i.ToString() + ":";
                        weightIsNotZeroForTheFirstTime = false;
                    }
                    curNodeConfig += $" {j.ToString()}({weight.ToString()})";
                }
            }

            if (!curNodeConfig.Equals(""))
            {
                outputStream.WriteLine(curNodeConfig);
            }
        }
    }
}