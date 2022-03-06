using System.Collections.Generic;
using NUnit.Framework;
using StackCalculator;

namespace StackTests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    private static IEnumerable<IStack> StackTestData
    {
        get
        {
            yield return new ListBasedStack();
            yield return new ArrayBasedStack();
        }
    }

    [Test, TestCaseSource(nameof(StackTestData))]
    public void PushShallWork(IStack stack)
    {
        stack.Push(24.4);
        Assert.IsFalse(stack.IsEmpty());
    }

    [Test, TestCaseSource(nameof(StackTestData))]
    public void PopShallWorkCorrectly(IStack stack)
    {
        stack.Push(10.9);
        Assert.AreEqual(10.9, stack.Pop());
    }

    [Test, TestCaseSource(nameof(StackTestData))]
    public void FirstAddedElementShouldBeTheLastInStackAndLastAddedShouldBeTheFirst(IStack stack)
    {
        stack.Push(30.1);
        stack.Push(10);
        stack.Push(8);
        Assert.AreEqual(8, stack.Pop());
        stack.Pop();
        Assert.AreEqual(30.1, stack.Pop());
    }

    [Test, TestCaseSource(nameof(StackTestData))]
    public void StackShouldBeEmptyAfterPushAndPop(IStack stack)
    {
        stack.Push(1);
        stack.Pop();
        Assert.IsTrue(stack.IsEmpty());
    }

    [Test, TestCaseSource(nameof(StackTestData))]
    public void PopFromEmptyStackShouldReturnNull(IStack stack)
    {
        Assert.IsNull(stack.Pop());
    }

    [Test, TestCaseSource(nameof(StackTestData))]
    public void NewStackShouldBeEmpty(IStack stack)
    {
        Assert.IsTrue(stack.IsEmpty());
    }

    [Test, TestCaseSource(nameof(StackTestData))]
    public void StackShouldBeAbleToReturnAllPushedItems(IStack stack)
    {
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        stack.Push(4);
        stack.Push(5);
        Assert.AreEqual(5, stack.Pop());
        Assert.AreEqual(4, stack.Pop());
        Assert.AreEqual(3, stack.Pop());
        Assert.AreEqual(2, stack.Pop());
        Assert.AreEqual(1, stack.Pop());
    }
}