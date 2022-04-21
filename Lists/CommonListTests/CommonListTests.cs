namespace ListsTests;

using Exceptions;
using NUnit.Framework;
using Lists;

public class Tests
{
    private CommonList? _commonList;
    
    [SetUp]
    public void Setup()
    {
        _commonList = new CommonList();
    }

    [Test]
    public void CommonListShouldContainValuesAfterAddingThem()
    {
        _commonList!.Add(1);
        _commonList!.Add(2);
        _commonList!.Add(3);
        Assert.AreEqual(_commonList.Get(0), 1);
        Assert.AreEqual(_commonList.Get(1), 2);
        Assert.AreEqual(_commonList.Get(2), 3);
    }

    [Test]
    public void CommonListShouldCorrectlyRemoveValueByPosition()
    {
        _commonList!.Add(1);
        _commonList!.Add(2);
        _commonList!.Add(3);
        _commonList!.Add(4);
        _commonList.Remove(1);
        Assert.AreEqual(_commonList.Get(1), 3);
        _commonList.Remove(2);
        Assert.AreEqual(_commonList.Length, 2);
    }

    [Test]
    public void LengthPropertyShouldHaveCorrectValueAfterChangingList()
    {
        Assert.AreEqual(0, _commonList!.Length);
        _commonList!.Add(1);
        _commonList!.Add(1);
        Assert.AreEqual(2, _commonList.Length);
        _commonList!.Add(1);
        _commonList!.Add(1);
        _commonList!.Add(1);
        Assert.AreEqual(5, _commonList.Length);
        _commonList.Remove(3);
        Assert.AreEqual(4, _commonList.Length);
        _commonList.Remove(0);
        _commonList.Remove(2);
        Assert.AreEqual(2, _commonList.Length);
        _commonList.Remove(1);
        _commonList.Remove(0);
        Assert.AreEqual(0, _commonList.Length);
    }

    [Test]
    public void ChangeValueMethodShouldCorrectlyChangeValueByPosition()
    {
        _commonList!.Add(1);
        _commonList!.Add(2);
        _commonList!.Add(3);
        _commonList!.Add(4);
        _commonList.ChangeValue(2, 2022);
        Assert.AreEqual(_commonList.Get(2), 2022);
        _commonList!.ChangeValue(0, 777);
        Assert.AreEqual(_commonList.Get(0), 777);
    }

    [Test]
    public void ItemNotFoundExceptionShouldBeRaisedInCaseOfRemovingNonExistingItem()
    {
        _commonList!.Add(1);
        _commonList!.Add(2);
        _commonList!.Add(3);
        Assert.Throws<ItemNotFoundException>(() => _commonList.Remove(3));
        _commonList!.Remove(2);
        _commonList!.Remove(1);
        _commonList!.Remove(0);
        Assert.Throws<ItemNotFoundException>(() => _commonList.Remove(0));
    }
    
    [Test]
    public void ItemNotFoundExceptionShouldBeRaisedInCaseOfChangingNonExistingItem()
    {
        _commonList!.Add(1);
        _commonList!.Add(2);
        _commonList!.Add(3);
        Assert.Throws<ItemNotFoundException>(() => _commonList.ChangeValue(10, 128));
        _commonList!.Remove(2);
        _commonList!.Remove(1);
        _commonList!.Remove(0);
        Assert.Throws<ItemNotFoundException>(() => _commonList.ChangeValue(0, 256));
    }
    
    [Test]
    public void ItemNotFoundExceptionShouldBeRaisedInCaseOfGettingNonExistingItem()
    {
        _commonList!.Add(1);
        _commonList!.Add(2);
        _commonList!.Add(3);
        Assert.Throws<ItemNotFoundException>(() => _commonList.Get(10));
        _commonList!.Remove(2);
        _commonList!.Remove(1);
        _commonList!.Remove(0);
        Assert.Throws<ItemNotFoundException>(() => _commonList.Get(0));
    }

}