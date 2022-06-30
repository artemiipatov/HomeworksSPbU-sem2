using NUnit.Framework;
using Lists;

namespace ListsTests;

public class UniqueListTests
{
    private UniqueList _uniqueList = new();
    
    [SetUp]
    public void Setup()
    {
        _uniqueList = new UniqueList();
    }

    [Test]
    public void UniqueListShouldContainOnlyDifferentValues()
    {
        _uniqueList.Add(0);
        _uniqueList.Add(1);
        _uniqueList.Add(2);
        Assert.Throws<AddingExistingItemException>(() => _uniqueList.Add(2));
        Assert.Throws<AddingExistingItemException>(() => _uniqueList.Add(1));
        Assert.Throws<AddingExistingItemException>(() => _uniqueList.Add(0));
        _uniqueList.Add(3);
        for (int i = 0; i < _uniqueList.Length; i++)
        {
            Assert.AreEqual(i, _uniqueList.Get(i));
        }
    }
}