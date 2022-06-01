namespace UtilityTests;

using System.IO;
using NUnit.Framework;
using Routers;

public class Tests
{
    private readonly string inputFilePath = "../../../TestInput.txt";
    private readonly string outputFilePath = "../../../TestOutput.txt";
    
    [Test]
    public void UtilityShouldMakeCorrectConfigurationsForDifferentSystems()
    {
        var inputFile = new StreamWriter(File.Open(inputFilePath, FileMode.Create));
        inputFile.WriteLine("0: 1(10) 3(40) 5(10) 6(15)");
        inputFile.WriteLine("1: 2(16) 4(20) 6(11)");
        inputFile.WriteLine("2: 5(1)");
        inputFile.WriteLine("3: 4(8) 5(17)");
        inputFile.WriteLine("4: 5(9)");
        inputFile.Close();
        
        RoutersUtility.GenerateConfig(inputFilePath, outputFilePath);

        var outputFile = new StreamReader(outputFilePath);
        Assert.AreEqual(outputFile.ReadLine(), "0: 3(40) 6(15)");
        Assert.AreEqual(outputFile.ReadLine(), "1: 2(16) 4(20) 6(11)");
        Assert.AreEqual(outputFile.ReadLine(), "3: 5(17)");
        outputFile.Close();

        inputFile = new StreamWriter(File.Open(inputFilePath, FileMode.Create));
        inputFile.WriteLine("0: 1(7) 2(15) 3(40) 6(3) 7(1)");
        inputFile.WriteLine("1: 2(8) 3(17) 7(9)");
        inputFile.WriteLine("2: 3(9)");
        inputFile.WriteLine("3: 4(20) 5(3) 6(7)");
        inputFile.WriteLine("4: 5(8) 7(5)");
        inputFile.WriteLine("5: 6(4) 7(10)");
        inputFile.WriteLine("6: 7(2)");
        inputFile.Close();
        
        RoutersUtility.GenerateConfig(inputFilePath, outputFilePath);

        outputFile = new StreamReader(outputFilePath);
        Assert.AreEqual("0: 2(15) 3(40)", outputFile.ReadLine());
        Assert.AreEqual("1: 3(17) 7(9)", outputFile.ReadLine());
        Assert.AreEqual("3: 4(20) 6(7)", outputFile.ReadLine());
        Assert.AreEqual("5: 7(10)", outputFile.ReadLine());
        outputFile.Close();
    }

    [Test]
    public void ExceptionShouldBeThrownIfSystemIsNotConnected()
    {
        var inputFile = new StreamWriter(File.Open(inputFilePath, FileMode.Create));
        inputFile.WriteLine("0: 1(10) 3(40) 5(10) 6(15)");
        inputFile.WriteLine("1: 2(16) 4(20) 6(11)");
        inputFile.WriteLine("2: 5(1)");
        inputFile.WriteLine("3: 4(8) 5(17)");
        inputFile.WriteLine("4: 5(9)");
        inputFile.WriteLine("7:");
        inputFile.Close();

        Assert.Throws<WrongInputException>(() => RoutersUtility.GenerateConfig(inputFilePath, outputFilePath));
    }
}