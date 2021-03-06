namespace FunctionsTests;

using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

public class Tests
{
    [Test]
    public void MapFunctionIsGeneric()
    {
        Assert.AreEqual(SomeFunctions.SomeFunctions.Map<int, int>(new List<int>() {1, 2, 3, 4, 5, 6}, x => x * 2),
            new List<int>() {2, 4, 6, 8, 10, 12});
        Assert.AreEqual(SomeFunctions.SomeFunctions.Map<string, string>(new List<string>() {"a", "b", "c", "d", "e"}, x => x + "1"),
            new List<string>() {"a1", "b1", "c1", "d1", "e1"});
        Assert.AreEqual(SomeFunctions.SomeFunctions.Map<List<int>, List<int>>(new List<List<int>>() {new List<int> {1, 2, 3}, new List<int> {4, 5, 6}, new List<int> {7, 8, 9}}, x => x.Select(i => i * 2).ToList()),
            new List<List<int>>() {new List<int> {2, 4, 6}, new List<int> {8, 10, 12}, new List<int> {14, 16, 18}});
    }

    [Test]
    public void FilterFunctionIsGeneric()
    {
        Assert.AreEqual(SomeFunctions.SomeFunctions.Filter<int>(new List<int>() {1, 2, 3, 4, 5, 6}, x => x % 2 == 0),
            new List<int>() { 2, 4, 6 });
        Assert.AreEqual(SomeFunctions.SomeFunctions.Filter<string>(new List<string>() {"abac", "bgklfa", "abfac", "ac"}, x => x.Contains("ac")),
            new List<string>() {"abac", "abfac", "ac"});
        Assert.AreEqual(SomeFunctions.SomeFunctions.Filter<List<int>>(new List<List<int>>() {new List<int> {80, 90, 100}, new List<int> {1, 2, 3}, new List<int> {4, 5, 6}, new List<int> {8, 10, 12}}, x => x.All(i => i % 2 == 0)),
            new List<List<int>>() {new List<int> {80, 90, 100}, new List<int> {8, 10, 12}});
    }

    [Test]
    public void FoldFunctionIsGeneric()
    {
        Assert.AreEqual(SomeFunctions.SomeFunctions.Fold<int, int>(new List<int>() {1, 2, 3, 4, 5, 6}, 1, (x, y) => x*y),
            720);
        Assert.AreEqual(SomeFunctions.SomeFunctions.Fold<string, string>(new List<string>() {"ab", "c", "defg", "hijklmn"}, "", (x, y) => x + y),
            "abcdefghijklmn");
        Assert.AreEqual(SomeFunctions.SomeFunctions.Fold<List<int>, List<int>>(new List<List<int>>() {new List<int> {1, 2, 3}, new List<int> {4, 5, 6}, new List<int> {7, 8, 9}}, new List<int> {},(x, y) => x.Concat(y).ToList()),
            new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9});
    }
}