namespace ParseTreeTests;

using System.IO;
using NUnit.Framework;
using ParseTree;

public class Tests
{
    [Test]
    public void TestFirstLargeExpressionEvaluation()
    {
        var strWriter = new StreamWriter(File.Open("../../../testExpression.txt", FileMode.Create));
        strWriter.Write("* (- 89 (/ 50 (+ 10 15))) (- 117 (/ 954 9))");
        strWriter.Close();
        var testTree = new ParseTree();
        testTree.Parse("../../../testExpression.txt");
        Assert.AreEqual(957, testTree.Eval());
    }

    [Test]
    public void TestSecondLargeExpressionEvaluation()
    {
        var strWriter = new StreamWriter(File.Open("../../../testExpression.txt", FileMode.Create));
        strWriter.Write("- (* (- 29 13) 3) (/ (+ 2000 322) 43)");
        strWriter.Close();
        var testTree = new ParseTree();
        testTree.Parse("../../../testExpression.txt");
        Assert.AreEqual(-6, testTree.Eval());
    }
    
    [Test]
    public void EvaluationOfExpressionWithNegativeValueShouldBeCorrect()
    {
        var strWriter = new StreamWriter(File.Open("../../../testExpression.txt", FileMode.Create));
        strWriter.Write("(* (- (* 43 42) (+ (/ 324 18) -3459)) 2)");
        strWriter.Close();
        var testTree = new ParseTree();
        testTree.Parse("../../../testExpression.txt");
        Assert.AreEqual(10494, testTree.Eval());
    }
}