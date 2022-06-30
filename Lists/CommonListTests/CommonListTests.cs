using System;
using System.Collections.Generic;
using NUnit.Framework;
using Lists;

namespace ListsTests;

public class Tests
{
    private static IEnumerable<CommonList> ListTestData
    {
        get
        {
            yield return new CommonList();
            yield return new UniqueList();
        }
    }
    
    [TestCaseSource(nameof(ListTestData))]
    public void CommonListShouldContainValuesAfterAddingThem(CommonList list)
    {
        list.Add(1);
        list.Add(2);
        list.Add(3);
        Assert.AreEqual(1, list.Get(0));
        Assert.AreEqual(2, list.Get(1));
        Assert.AreEqual(3, list.Get(2));
    }

    [TestCaseSource(nameof(ListTestData))]
    public void CommonListShouldCorrectlyRemoveValueByPosition(CommonList list)
    {
        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Add(4);
        list.Remove(1);
        Assert.AreEqual(3, list.Get(1));
        list.Remove(2);
        Assert.AreEqual(2, list.Length);
    }

    public void LengthPropertyShouldHaveCorrectValueAfterChangingList(CommonList list)
    {
        Assert.AreEqual(0, list!.Length);
        list.Add(1);
        list.Add(1);
        Assert.AreEqual(2, list.Length);
        list.Add(1);
        list.Add(1);
        list.Add(1);
        Assert.AreEqual(5, list.Length);
        list.Remove(3);
        Assert.AreEqual(4, list.Length);
        list.Remove(0);
        list.Remove(2);
        Assert.AreEqual(2, list.Length);
        list.Remove(1);
        list.Remove(0);
        Assert.AreEqual(0, list.Length);
    }

    [TestCaseSource(nameof(ListTestData))]
    public void ChangeValueMethodShouldCorrectlyChangeValueByPosition(CommonList list)
    {
        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Add(4);
        list.ChangeValue(2, 2022);
        Assert.AreEqual(2022, list.Get(2));
        list!.ChangeValue(0, 777);
        Assert.AreEqual(777, list.Get(0));
    }

    [TestCaseSource(nameof(ListTestData))]
    public void ItemNotFoundExceptionShouldBeRaisedInCaseOfRemovingNonExistingItem(CommonList list)
    {
        list.Add(1);
        list.Add(2);
        list.Add(3);
        Assert.Throws<IndexOutOfRangeException>(() => list.Remove(3));
        list.Remove(2);
        list.Remove(1);
        list.Remove(0);
        Assert.Throws<ItemNotFoundException>(() => list.Remove(0));
    }

    [TestCaseSource(nameof(ListTestData))]
    public void ItemNotFoundExceptionShouldBeRaisedInCaseOfChangingNonExistingItem(CommonList list)
    {
        list.Add(1);
        list.Add(2);
        list.Add(3);
        Assert.Throws<IndexOutOfRangeException>(() => list.ChangeValue(10, 128));
        list.Remove(2);
        list.Remove(1);
        list.Remove(0);
        Assert.Throws<ItemNotFoundException>(() => list.ChangeValue(0, 256));
    }
    
    [TestCaseSource(nameof(ListTestData))]
    public void ItemNotFoundExceptionShouldBeRaisedInCaseOfGettingNonExistingItem(CommonList list)
    {
        list.Add(1);
        list.Add(2);
        list.Add(3);
        Assert.Throws<IndexOutOfRangeException>(() => list.Get(10));
        list.Remove(2);
        list.Remove(1);
        list.Remove(0);
        Assert.Throws<ItemNotFoundException>(() => list.Get(0));
    }
}