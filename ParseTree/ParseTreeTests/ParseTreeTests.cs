using System.IO;
using NUnit.Framework;

namespace ParseTreeTests;
using ParseTree;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void EvaluationOfLargeExpressionsShouldBeCorrect()
    {
        StreamWriter strWriter = new StreamWriter(File.Open("../../../testExpression.txt", FileMode.Create));
        strWriter.Write("* (- 89 (/ 50 (+ 10 15))) (- 117 (/ 954 9))");
        strWriter.Close();
        IParseTree testTree = new ParseTree();
        testTree.Parse("../../../testExpression.txt");
        Assert.AreEqual(testTree.Eval(), 957);
        
        strWriter = new StreamWriter(File.Open("../../../testExpression.txt", FileMode.Create));
        strWriter.Write("(* (- (* 43 42) (+ (/ 324 18) -3459)) 2)");
        strWriter.Close();
        testTree = new ParseTree();
        testTree.Parse("../../../testExpression.txt");
        Assert.AreEqual(testTree.Eval(), 10494);
        
        strWriter = new StreamWriter(File.Open("../../../testExpression.txt", FileMode.Create));
        strWriter.Write("- (* (- 29 13) 3) (/ (+ 2000 322) 43)");
        strWriter.Close();
        testTree = new ParseTree();
        testTree.Parse("../../../testExpression.txt");
        Assert.AreEqual(testTree.Eval(), -6);
    }
}