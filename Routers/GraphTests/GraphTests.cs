namespace GraphTests;

using System.IO;
using NUnit.Framework;
using Routers;

public class Tests
{
    private string inputFilePath = "../../../TestInput.txt";
    
    [Test]
    public void DataFromFileShouldBeParsedCorrectly()
    {
        using var inputFile = new StreamWriter(File.Open(inputFilePath, FileMode.Create));
        inputFile.WriteLine("0: 1(10) 3(40) 5(10) 6(15)");
        inputFile.WriteLine("1: 2(16) 4(20) 6(11)");
        inputFile.WriteLine("2: 5(1)");
        inputFile.WriteLine("3: 4(8) 5(17)");
        inputFile.WriteLine("4: 5(9)");
        inputFile.Close();

        int[,] correctMatrix = new int[7, 7] {{ 0, 10, 0, 40, 0, 10, 15 },
            { 10, 0, 16, 0, 20, 0, 11 },
            { 0, 16, 0, 0, 0, 1, 0 },
            { 40, 0, 0, 0, 8, 17, 0},
            { 0, 20, 0, 8, 0, 9, 0 },
            { 10, 0, 1, 17, 9, 0, 0 },
            { 15, 11, 0, 0, 0, 0, 0 }};
        IGraph graph = new Graph(inputFilePath);

        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                Assert.AreEqual(correctMatrix[i, j], graph.Matrix[i, j]);
            }
        }
        File.Delete(inputFilePath);
    }

    [Test]
    public void CheckConnectivityMethodShouldReturnTrue()
    {
        using var inputFile = new StreamWriter(File.Open(inputFilePath, FileMode.Create));
        inputFile.WriteLine("0: 1(10) 3(40) 6(15)");
        inputFile.WriteLine("1: 2(16) 4(20) 6(11)");
        inputFile.WriteLine("2: 5(1), 4(15)");
        inputFile.WriteLine("3: 4(8) 5(17)");
        inputFile.WriteLine("4: 5(9)");
        inputFile.WriteLine("5: 6(14)");
        inputFile.Close();

        IGraph graph = new Graph(inputFilePath);
        Assert.IsTrue(graph.CheckConnectivity(0, 0));
        Assert.IsTrue(graph.CheckConnectivity(0, 1));
        Assert.IsTrue(graph.CheckConnectivity(0, 2));
        Assert.IsTrue(graph.CheckConnectivity(0, 3));
        Assert.IsTrue(graph.CheckConnectivity(0, 4));
        Assert.IsTrue(graph.CheckConnectivity(0, 5));
        Assert.IsTrue(graph.CheckConnectivity(0, 6));
        File.Delete(inputFilePath);
    }

    [Test]
    public void CheckConnectivityMethodShouldReturnFalse()
    {
        using var inputFile = new StreamWriter(File.Open(inputFilePath, FileMode.Create));
        inputFile.WriteLine("0: 1(10) 3(40) 6(15)");
        inputFile.WriteLine("1: 2(16) 4(20) 6(11)");
        inputFile.WriteLine("2: 5(1), 4(15)");
        inputFile.WriteLine("3: 4(8) 5(17)");
        inputFile.WriteLine("4: 5(9)");
        inputFile.WriteLine("5: 6(14)");
        inputFile.Close();

        IGraph graph = new Graph(inputFilePath);

        graph.DeleteEdge(3, 0);
        graph.DeleteEdge(3, 4);
        graph.DeleteEdge(3, 5);

        Assert.IsFalse(graph.CheckConnectivity(3, 0));
        Assert.IsFalse(graph.CheckConnectivity(3, 1));
        Assert.IsFalse(graph.CheckConnectivity(3, 2));
        Assert.IsFalse(graph.CheckConnectivity(3, 4));
        Assert.IsFalse(graph.CheckConnectivity(3, 5));
        Assert.IsFalse(graph.CheckConnectivity(3, 6));
        File.Delete(inputFilePath);
    }

    [Test]
    public void DictionaryShouldContainAllEdges()
    {
        using var inputFile = new StreamWriter(File.Open(inputFilePath, FileMode.Create));
        inputFile.WriteLine("0: 1(10) 3(20) 5(9)");
        inputFile.WriteLine("1: 2(16) 4(20) 5(4) 6(11)");
        inputFile.WriteLine("2: 5(1), 3(2) 4(5)");
        inputFile.WriteLine("3: 4(8)");
        inputFile.WriteLine("4: 5(9) 6(3)");
        inputFile.WriteLine("5: 6(14)");
        inputFile.Close();

        IGraph graph = new Graph(inputFilePath);

        for (int i = 0; i <= graph.MaxNodeNumber; i++)
        {
            for (int j = 0; j <= graph.MaxNodeNumber; j++)
            {
                if (graph.Matrix[i, j] != 0)
                {
                    Assert.IsTrue((graph.Edges.TryGetValue((i, j), out var weight)
                                   || graph.Edges.TryGetValue((j, i), out weight))
                                  && weight == graph.Matrix[i, j]);
                }
            }
        }

        File.Delete(inputFilePath);
    }
}