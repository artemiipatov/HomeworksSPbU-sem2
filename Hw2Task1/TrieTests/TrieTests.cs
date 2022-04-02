using NUnit.Framework;
using Hw2Task1;

namespace TrieTests;

/// <summary>
/// Module tests for trie 
/// </summary>
public class Tests
{
    private Trie _testTrie = new Trie();
    [SetUp]
    public void Setup()
    {
        _testTrie = new Trie();
    }

    [Test]
    public void TrieShouldNotContainItemsAfterAddAndRemove()
    {
        _testTrie.AddItem("test");
        _testTrie.AddItem("testtest");
        _testTrie.AddItem("test123");
        _testTrie.Remove("test");
        Assert.IsTrue(_testTrie.Contains("testtest") && _testTrie.Contains("test123") && !_testTrie.Contains("test"));
        _testTrie.Remove("testtest");
        Assert.IsTrue(_testTrie.Contains("test123"));
        _testTrie.Remove("test123");
        Assert.IsFalse(_testTrie.Contains("test") || _testTrie.Contains("testtest") || _testTrie.Contains("test123"));
    }

    [Test]
    public void TrieShouldContainValueAfterAddingIt()
    {
        _testTrie.AddItem("test");
        Assert.IsTrue(_testTrie.Contains("test"));
    }

    [Test]
    public void RemoveShouldReturnFalseIfTrieContainsNoSuchValue()
    {
        _testTrie.AddItem("test");
        Assert.IsFalse(_testTrie.Remove("test0"));
    }

    [Test]
    public void RemoveShouldReturnTrueIfValueHasBeenRemoved()
    {
        _testTrie.AddItem("test123");
        Assert.IsTrue(_testTrie.Remove("test123"));
    }

    [Test]
    public void HowManyStartsWithPrefixShouldReturn3()
    {
        _testTrie.AddItem("test");
        _testTrie.AddItem("testtest");
        _testTrie.AddItem("test123");
        Assert.AreEqual(_testTrie.HowManyStartsWithPrefix("test"), 3);
    }

    [Test]
    public void HowManyStartsWithPrefixesShouldReturn0()
    {
        _testTrie.AddItem("item");
        _testTrie.AddItem("string");
        Assert.Zero(_testTrie.HowManyStartsWithPrefix("test"));
    }

    [Test]
    public void TrieShouldContainTwoValuesTrieShouldNotContainThirdValue()
    {
        _testTrie.AddItem("item");
        _testTrie.AddItem("string");
        Assert.IsTrue(_testTrie.Contains("item"));
        Assert.IsTrue(_testTrie.Contains("string"));
        Assert.IsFalse(_testTrie.Contains("object"));
    }

    [Test]
    public void AllMethodsShouldSuccessfullyDealWithEmptyTrie()
    {
        Assert.IsFalse(_testTrie.Remove("item"));
        Assert.IsFalse(_testTrie.Contains("string"));
        Assert.Zero(_testTrie.HowManyStartsWithPrefix("object"));
    }
}