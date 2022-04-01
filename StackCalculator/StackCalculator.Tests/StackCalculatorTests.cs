using System.Collections.Generic;
using NUnit.Framework;

namespace StackCalculatorTests;
using StackCalculator;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    private static IEnumerable<IStack> CalcTestData
    {
        get
        {
            yield return new ListBasedStack();
            yield return new ArrayBasedStack();
        }
    }

    [Test, TestCaseSource(nameof(CalcTestData))]
    public void EvaluationResultShouldBeCorrectInCommonCases(IStack stack)
    {
        Assert.AreEqual(59.5, StackCalculator.Evaluate("100 2 + 51 / 4 / 59 +", stack));
        Assert.AreEqual(0.25, StackCalculator.Evaluate("32 2 / 2 / 2 / 2 / 2 / 2 / 2 /", stack));
        Assert.AreEqual(157.5,StackCalculator.Evaluate("219 3 / 33 - 20 + 3 * 8 / 7 *", stack));
        Assert.AreEqual(-33965.261, StackCalculator.Evaluate("55 33 913 1030004 + 1000 / * -", stack));
        Assert.AreEqual(1000, StackCalculator.Evaluate("1000", stack));
    }

    [Test, TestCaseSource(nameof(CalcTestData))]
    public void EvaluationResultShouldBeCorrectInNegativeNumbersCase(IStack stack)
    {
        Assert.AreEqual(-75, StackCalculator.Evaluate("-100 50 - -10 / -5 *", stack));
        Assert.AreEqual(-51, StackCalculator.Evaluate("-90 -85 * -150 /", stack));
    }

    [Test, TestCaseSource(nameof(CalcTestData))]
    public void EvaluateShouldReturnNullIfInputIsIncorrect(IStack stack)
    {
        Assert.IsNull(StackCalculator.Evaluate("100 9510985", stack));
        Assert.IsNull(StackCalculator.Evaluate("+ - ", stack));
        Assert.IsNull(StackCalculator.Evaluate("", stack));
        Assert.IsNull(StackCalculator.Evaluate("abd 123 +", stack));
    }

    [Test, TestCaseSource(nameof(CalcTestData))]
    public void EvaluateShouldReturnNullAfterDividingByZero(IStack stack)
    {
        Assert.IsNull(StackCalculator.Evaluate("100 0 /", stack));
    }
}