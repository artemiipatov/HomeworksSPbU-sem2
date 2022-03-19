using NUnit.Framework;

namespace TrieTests;
using Trie;

public class Tests
{
    private Trie testTrie = new Trie();
    [SetUp]
    public void Setup()
    {
        testTrie = new Trie();
    }

    [Test]
    public void TrieShouldNotContainItemsAfterAddAndRemove()
    {
        testTrie.AddItem(new byte[] { 1, 2, 3 });
        testTrie.AddItem(new byte[] { 1, 2, 3, 8, 43, 155, 90, 4 });
        testTrie.AddItem(new byte[] { 1, 2, 3, 220, 29, 3, 94, 14, 123 });
        testTrie.Remove(new byte[] { 1, 2, 3 });
        Assert.IsTrue(testTrie.Contains(new byte[] { 1, 2, 3, 8, 43, 155, 90, 4 }) && testTrie.Contains(new byte[] { 1, 2, 3, 220, 29, 3, 94, 14, 123 }) && !testTrie.Contains(new byte[] { 1, 2, 3 }));
        testTrie.Remove(new byte[] { 1, 2, 3, 8, 43, 155, 90, 4 });
        Assert.IsTrue(testTrie.Contains(new byte[] { 1, 2, 3, 220, 29, 3, 94, 14, 123 }));
        testTrie.Remove(new byte[] { 1, 2, 3, 220, 29, 3, 94, 14, 123 });
        Assert.IsFalse(testTrie.Contains(new byte[] { 1, 2, 3, 8, 43, 155, 90, 4 }) || testTrie.Contains(new byte[] { 1, 2, 3, 220, 29, 3, 94, 14, 123 }) || testTrie.Contains(new byte[] { 1, 2, 3 }));
    }

    [Test]
    public void TrieShouldContainValueAfterAddingIt()
    {
        testTrie.AddItem(new byte[] {1, 2, 3});
        Assert.IsTrue(testTrie.Contains(new byte[] {1, 2, 3}));
    }

    [Test]
    public void RemoveShouldReturnFalseIfTrieContainsNoSuchValue()
    {
        testTrie.AddItem(new byte[] {1, 2, 3});
        Assert.IsFalse(testTrie.Remove(new byte[] {1, 2, 3, 4}));
    }

    [Test]
    public void RemoveShouldReturnTrueIfValueHasBeenRemoved()
    {
        testTrie.AddItem(new byte[] { 1, 2, 3, 8, 43, 155, 90, 4 });
        Assert.IsTrue(testTrie.Remove(new byte[] { 1, 2, 3, 8, 43, 155, 90, 4 }));
    }

    [Test]
    public void HowManyStartsWithPrefixShouldReturn3()
    {
        testTrie.AddItem(new byte[] { 1, 2, 3 });
        testTrie.AddItem(new byte[] { 1, 2, 3, 8, 43, 155, 90, 4 });
        testTrie.AddItem(new byte[] { 1, 2, 3, 220, 29, 3, 94, 14, 123 });
        Assert.AreEqual(testTrie.HowManyStartsWithPrefix(new byte[] { 1, 2, 3 }), 3);
    }

    [Test]
    public void HowManyStartsWithPrefixesShouldReturn0()
    {
        testTrie.AddItem(new byte[] { 1, 2, 3 });
        testTrie.AddItem(new byte[] { 4, 5, 6 });
        Assert.Zero(testTrie.HowManyStartsWithPrefix(new byte[] { 7, 8, 9 }));
    }

    [Test]
    public void TrieShouldContainTwoValuesTrieShouldNotContainThirdValue()
    {
        testTrie.AddItem(new byte[] { 1, 2, 3 });
        testTrie.AddItem(new byte[] { 4, 5, 6 });
        Assert.IsTrue(testTrie.Contains(new byte[] { 1, 2, 3 }));
        Assert.IsTrue(testTrie.Contains(new byte[] { 4, 5, 6 }));
        Assert.IsFalse(testTrie.Contains(new byte[] { 7, 8, 9 }));
    }

    [Test]
    public void AllMethodsShouldSuccessfullyDealWithEmptyTrie()
    {
        Assert.IsFalse(testTrie.Remove(new byte[] { 1, 2, 3 }));
        Assert.IsFalse(testTrie.Contains(new byte[] { 4, 5, 6 }));
        Assert.Zero(testTrie.HowManyStartsWithPrefix(new byte[] { 7, 8, 9 }));
    }
}