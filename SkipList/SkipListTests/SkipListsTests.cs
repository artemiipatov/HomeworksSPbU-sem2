using System.Linq;

namespace SkipListTests;

using NUnit.Framework;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestAddRemoveAndContainsMethods()
    {
        var testSkipList = new SkipList.SkipList<int> ();
        testSkipList.Remove(3);
        Assert.IsFalse(testSkipList.Contains(3));
        testSkipList.Add(3);
        Assert.IsTrue(testSkipList.Contains(3));
        testSkipList.Add(5);
        Assert.IsTrue(testSkipList.Contains(5));
        testSkipList.Add(1);
        Assert.IsTrue(testSkipList.Contains(1));
        testSkipList.Add(0);
        Assert.IsTrue(testSkipList.Contains(0));
        testSkipList.Add(9);
        Assert.IsTrue(testSkipList.Contains(9));
        testSkipList.Add(5);
        Assert.IsTrue(testSkipList.Contains(5));
        testSkipList.Add(7);
        Assert.IsTrue(testSkipList.Contains(7));
        testSkipList.Add(2);
        Assert.IsTrue(testSkipList.Contains(2));
        testSkipList.Add(4);
        Assert.IsTrue(testSkipList.Contains(4));
        testSkipList.Add(10);
        Assert.IsTrue(testSkipList.Contains(10));

        testSkipList.Remove(7);
        Assert.IsFalse(testSkipList.Contains(7));
        testSkipList.Remove(2);
        Assert.IsFalse(testSkipList.Contains(2));
    }

    [Test]
    public void TestRemoveAt()
    {
        var testSkipList = new SkipList.SkipList<int>();
        testSkipList.Add(0);
        testSkipList.Add(1);
        testSkipList.Add(2);
        testSkipList.Add(3);
        testSkipList.Add(4);
        testSkipList.Add(5);
        testSkipList.Add(5);
        testSkipList.Add(5);
        testSkipList.Add(5);
        testSkipList.Add(6);
        testSkipList.Add(7);
        testSkipList.Add(8);
        testSkipList.Add(8);
        testSkipList.Add(9);
        
        testSkipList.RemoveAt(5);
        testSkipList.RemoveAt(0);
        testSkipList.RemoveAt(4);
        testSkipList.RemoveAt(9);
        testSkipList.RemoveAt(9);
        Assert.IsFalse(testSkipList.Contains(9));
        Assert.IsFalse(testSkipList.Contains(0));
    }
}