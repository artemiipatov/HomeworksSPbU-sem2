using NUnit.Framework;

namespace StackCalculatorTests;
using StackCalculator;

public class Tests
{
    private IStack _arrayBasedStack = new ArrayBasedStack();
    private IStack _listBasedStack = new ListBasedStack();
    [SetUp]
    public void Setup()
    {
        _arrayBasedStack = new ArrayBasedStack();
        _listBasedStack = new ListBasedStack();
    }

    [Test]
    public void EvaluationResultShouldBeCorrectInCommonCases()
    {
        Assert.AreEqual(59.5, StackCalculator.Evaluate("100 2 + 51 / 4 / 59 +", _arrayBasedStack));
        Assert.AreEqual(0.25, StackCalculator.Evaluate("32 2 / 2 / 2 / 2 / 2 / 2 / 2 /", _arrayBasedStack));
        Assert.AreEqual(157.5,StackCalculator.Evaluate("219 3 / 33 - 20 + 3 * 8 / 7 *", _arrayBasedStack));
        Assert.AreEqual(-33965.261, StackCalculator.Evaluate("55 33 913 1030004 + 1000 / * -", _arrayBasedStack));
        Assert.AreEqual(1000, StackCalculator.Evaluate("1000", _arrayBasedStack));
    }

    [Test]
    public void EvaluationResultShouldBeCorrectInNegativeNumbersCase()
    {
        Assert.AreEqual(-75, StackCalculator.Evaluate("-100 50 - -10 / -5 *", _arrayBasedStack));
        Assert.AreEqual(-51, StackCalculator.Evaluate("-90 -85 * -150 /", _arrayBasedStack));
    }

    [Test]
    public void EvaluateShouldReturnNullIfInputIsIncorrect()
    {
        Assert.IsNull(StackCalculator.Evaluate("100 9510985", _arrayBasedStack));
        Assert.IsNull(StackCalculator.Evaluate("+ - ", _arrayBasedStack));
        Assert.IsNull(StackCalculator.Evaluate("", _arrayBasedStack));
        Assert.IsNull(StackCalculator.Evaluate("abd 123 +", _arrayBasedStack));
    }

    [Test]
    public void EvaluateShouldReturnNullAfterDividingByZero()
    {
        Assert.IsNull(StackCalculator.Evaluate("100 0 /", _arrayBasedStack));
    }
}