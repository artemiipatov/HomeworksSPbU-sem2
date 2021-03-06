using NUnit.Framework;

namespace LzwTests;
using Lzw;

public class TrieTests
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
        _testTrie.AddItem(new byte[] { 1, 2, 3 });
        _testTrie.AddItem(new byte[] { 1, 2, 3, 8, 43, 155, 90, 4 });
        _testTrie.AddItem(new byte[] { 1, 2, 3, 220, 29, 3, 94, 14, 123 });
        _testTrie.Remove(new byte[] { 1, 2, 3 });
        Assert.IsTrue(_testTrie.Contains(new byte[] { 1, 2, 3, 8, 43, 155, 90, 4 }) && _testTrie.Contains(new byte[] { 1, 2, 3, 220, 29, 3, 94, 14, 123 }) && !_testTrie.Contains(new byte[] { 1, 2, 3 }));
        _testTrie.Remove(new byte[] { 1, 2, 3, 8, 43, 155, 90, 4 });
        Assert.IsTrue(_testTrie.Contains(new byte[] { 1, 2, 3, 220, 29, 3, 94, 14, 123 }));
        _testTrie.Remove(new byte[] { 1, 2, 3, 220, 29, 3, 94, 14, 123 });
        Assert.IsFalse(_testTrie.Contains(new byte[] { 1, 2, 3, 8, 43, 155, 90, 4 }) || _testTrie.Contains(new byte[] { 1, 2, 3, 220, 29, 3, 94, 14, 123 }) || _testTrie.Contains(new byte[] { 1, 2, 3 }));
    }

    [Test]
    public void TrieShouldContainValueAfterAddingIt()
    {
        _testTrie.AddItem(new byte[] {1, 2, 3});
        Assert.IsTrue(_testTrie.Contains(new byte[] {1, 2, 3}));
    }

    [Test]
    public void RemoveShouldReturnFalseIfTrieContainsNoSuchValue()
    {
        _testTrie.AddItem(new byte[] {1, 2, 3});
        Assert.IsFalse(_testTrie.Remove(new byte[] {1, 2, 3, 4}));
    }

    [Test]
    public void RemoveShouldReturnTrueIfValueHasBeenRemoved()
    {
        _testTrie.AddItem(new byte[] { 1, 2, 3, 8, 43, 155, 90, 4 });
        Assert.IsTrue(_testTrie.Remove(new byte[] { 1, 2, 3, 8, 43, 155, 90, 4 }));
    }

    [Test]
    public void TrieShouldContainTwoValuesTrieShouldNotContainThirdValue()
    {
        _testTrie.AddItem(new byte[] { 1, 2, 3 });
        _testTrie.AddItem(new byte[] { 4, 5, 6 });
        Assert.IsTrue(_testTrie.Contains(new byte[] { 1, 2, 3 }));
        Assert.IsTrue(_testTrie.Contains(new byte[] { 4, 5, 6 }));
        Assert.IsFalse(_testTrie.Contains(new byte[] { 7, 8, 9 }));
    }

    [Test]
    public void AllMethodsShouldSuccessfullyDealWithEmptyTrie()
    {
        Assert.IsFalse(_testTrie.Remove(new byte[] { 1, 2, 3 }));
        Assert.IsFalse(_testTrie.Contains(new byte[] { 4, 5, 6 }));
    }
}