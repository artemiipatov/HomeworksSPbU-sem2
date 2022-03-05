using NUnit.Framework;
using StackCalculator;

namespace ListBasedStack.Tests;

public class Tests
{
    private IStack stack = new StackCalculator.ListBasedStack();

    [SetUp]
    public void Setup()
    {
        stack = new StackCalculator.ListBasedStack();
    }

    [Test]
    public void PushShallWork()
    {
        stack.Push(24.4);
        Assert.IsFalse(stack.IsEmpty());
    }

    [Test]
    public void PopShallWorkCorrectly()
    {
        stack.Push(10.9);
        Assert.AreEqual(10.9, stack.Pop());
    }

    [Test]
    public void FirstAddedElementShouldBeTheLastInStackAndLastAddedShouldBeTheFirst()
    {
        stack.Push(30.1);
        stack.Push(10);
        stack.Push(8);
        Assert.AreEqual(8, stack.Pop());
        stack.Pop();
        Assert.AreEqual(30.1, stack.Pop());
    }

    [Test]
    public void StackShouldBeEmptyAfterPushAndPop()
    {
        stack.Push(1);
        stack.Pop();
        Assert.IsTrue(stack.IsEmpty());
    }

    [Test]
    public void PopFromEmptyStackShouldReturnNull()
    {
        Assert.IsNull(stack.Pop());
    }

    [Test]
    public void NewStackShouldBeEmpty()
    {
        Assert.IsTrue(stack.IsEmpty());
    }

    [Test]
    public void StackShouldBeAbleToReturnAllPushedItems()
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