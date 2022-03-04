using NUnit.Framework;
using Hw2Task1;

namespace TrieTests;

public class Tests
{
    private Trie testTrie = new Trie();
    [SetUp]
    public void Setup()
    {
        testTrie = new Trie();
    }
    
    [Test] // smoke testing
    public void TrieShouldNotContainItemsAfterAddAndRemove() // Здесь можно сразу проверять, удаляется ли одна строки после удаления другой строки, начинающейся с того же префикса
    {
        testTrie.AddItem("test");
        testTrie.AddItem("testtest");
        testTrie.AddItem("test123");
        testTrie.Remove("test");
        testTrie.Remove("testtest");
        testTrie.Remove("test123");
        Assert.IsFalse(testTrie.Contains("test") || testTrie.Contains("testtest") || testTrie.Contains("test123"));
    }

    [Test]
    public void TrieShouldContainValueAfterAddingIt()
    {
        testTrie.AddItem("test");
        Assert.IsTrue(testTrie.Contains("test"));
    }

    [Test]
    public void RemoveShouldReturnFalseIfTrieContainsNoSuchValue()
    {
        testTrie.AddItem("test");
        Assert.IsFalse(testTrie.Remove("test0"));
    }

    [Test]
    public void RemoveShouldReturnTrueIfValueHasBeenRemoved()
    {
        testTrie.AddItem("test123");
        Assert.IsTrue(testTrie.Remove("test123"));
    }

    [Test]
    public void HowManyStartsWithPrefixShouldReturn3()
    {
        testTrie.AddItem("test");
        testTrie.AddItem("testtest");
        testTrie.AddItem("test123");
        Assert.AreEqual(testTrie.HowManyStartsWithPrefix("test"), 3);
    }

    [Test]
    public void HowManyStartsWithPrefixesShouldReturn0()
    {
        testTrie.AddItem("item");
        testTrie.AddItem("string");
        Assert.Zero(testTrie.HowManyStartsWithPrefix("test"));
    }

    [Test]
    public void TrieShouldContainTwoValuesTrieShouldNotContainThirdValue()
    {
        testTrie.AddItem("item");
        testTrie.AddItem("string");
        Assert.IsTrue(testTrie.Contains("item"));
        Assert.IsTrue(testTrie.Contains("string"));
        Assert.IsFalse(testTrie.Contains("object"));
    }
}