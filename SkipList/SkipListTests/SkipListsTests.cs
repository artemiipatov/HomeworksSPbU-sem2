namespace SkipListTests;

using NUnit.Framework;
using System;
using System.Collections.Generic;
using SkipList;

public class Tests
{
    private static IEnumerable<object> SkipListTestData
    {
        get
        {
            IList<int> intSkipList = new SkipList<int>();
            intSkipList.Add(0);
            intSkipList.Add(1);
            intSkipList.Add(2);
            intSkipList.Add(3);
            intSkipList.Add(4);
            intSkipList.Add(5);
            intSkipList.Add(6);
            intSkipList.Add(7);
            intSkipList.Add(8);
            intSkipList.Add(9);
            intSkipList.Add(10);
            yield return new TestCaseData(intSkipList, typeof(int), new[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10});
            
            IList<string> stringSkipList = new SkipList<string>();
            stringSkipList.Add("str0");
            stringSkipList.Add("str1");
            stringSkipList.Add("str2");
            stringSkipList.Add("str3");
            stringSkipList.Add("str4");
            stringSkipList.Add("str5");
            stringSkipList.Add("str6");
            stringSkipList.Add("str7");
            stringSkipList.Add("str8");
            stringSkipList.Add("str9");
            yield return new TestCaseData(stringSkipList, typeof(string), new[] {"str0", "str1", "str2", "str3", "str4", "str5", "str6", "str7", "str8", "str9"});
        }
    }
    
    [Test]
    public void TestAddRemoveAndContainsMethods()
    {
        // var testSkipList = new SkipList.SkipList<int> ();
        IList<int> intSkipList = new SkipList<int>();
        
        intSkipList.Remove(3);
        Assert.IsFalse(intSkipList.Contains(3));
        intSkipList.Add(3);
        Assert.IsTrue(intSkipList.Contains(3));
        intSkipList.Add(5);
        Assert.IsTrue(intSkipList.Contains(5));
        intSkipList.Add(1);
        Assert.IsTrue(intSkipList.Contains(1));
        intSkipList.Add(0);
        Assert.IsTrue(intSkipList.Contains(0));
        intSkipList.Add(9);
        Assert.IsTrue(intSkipList.Contains(9));
        intSkipList.Add(5);
        Assert.IsTrue(intSkipList.Contains(5));
        intSkipList.Add(7);
        Assert.IsTrue(intSkipList.Contains(7));
        intSkipList.Add(2);
        Assert.IsTrue(intSkipList.Contains(2));
        intSkipList.Add(4);
        Assert.IsTrue(intSkipList.Contains(4));
        intSkipList.Add(10);
        Assert.IsTrue(intSkipList.Contains(10));
    
        intSkipList.Remove(7);
        Assert.IsFalse(intSkipList.Contains(7));
        intSkipList.Remove(2);
        Assert.IsFalse(intSkipList.Contains(2));

        IList<string> stringSkipList = new SkipList<string>();
        stringSkipList.Remove("str1");
        Assert.IsFalse(stringSkipList.Contains("str1"));
        stringSkipList.Add("str2");
        Assert.IsTrue(stringSkipList.Contains("str2"));
        stringSkipList.Add("str5");
        Assert.IsTrue(stringSkipList.Contains("str5"));
        stringSkipList.Add("str9");
        Assert.IsTrue(stringSkipList.Contains("str9"));
        stringSkipList.Add("str8");
        Assert.IsTrue(stringSkipList.Contains("str8"));
        stringSkipList.Add("str4");
        Assert.IsTrue(stringSkipList.Contains("str4"));
        stringSkipList.Add("str6");
        Assert.IsTrue(stringSkipList.Contains("str6"));
        stringSkipList.Add("str1");
        Assert.IsTrue(stringSkipList.Contains("str1"));
        stringSkipList.Add("str1");
        Assert.IsTrue(stringSkipList.Contains("str1"));

        stringSkipList.Remove("str6");
        Assert.IsFalse(stringSkipList.Contains("str6"));
        stringSkipList.Remove("str1");
        Assert.IsTrue(stringSkipList.Contains("str1"));
        stringSkipList.Remove("str1");
        Assert.IsFalse(stringSkipList.Contains("str1"));
        stringSkipList.Remove("str5");
        Assert.IsFalse(stringSkipList.Contains("str5"));
        stringSkipList.Remove("str8");
        Assert.IsFalse(stringSkipList.Contains("str8"));
        stringSkipList.Remove("str9");
        Assert.IsFalse(stringSkipList.Contains("str9"));
        stringSkipList.Remove("str6");
        Assert.IsFalse(stringSkipList.Contains("str6"));
        stringSkipList.Remove("str2");
        Assert.IsFalse(stringSkipList.Contains("str2"));
    }

    [TestCaseSource(nameof(SkipListTestData))]
    public void TestClearMethod<T>(IList<T> skipList, Type type, T[] array)
    {
        skipList.Clear();
        if (type == typeof(int))
        {
            Assert.IsTrue((skipList as SkipList<int>)!.IsEmpty());
        }
        else if (type == typeof(string))
        {
            Assert.IsTrue((skipList as SkipList<string>)!.IsEmpty());
        }
    }
    
    [TestCaseSource(nameof(SkipListTestData))]
    public void TestGetElementByIndex<T>(IList<T> skipList, Type type, T[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Assert.AreEqual(array[i], skipList[i]);
        }
    }
    
    [TestCaseSource(nameof(SkipListTestData))]
    public void TestIndexOfMethod<T>(IList<T> skipList, Type type, T[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Assert.AreEqual(i, skipList.IndexOf(array[i]));
        }
    }
    
    [TestCaseSource(nameof(SkipListTestData))]
    public void TestRemoveAt<T>(IList<T> skipList, Type type, T[] array)
    {
        skipList.RemoveAt(skipList.Count - 1);
        skipList.RemoveAt(5);
        skipList.RemoveAt(0);
        Assert.IsFalse(skipList.Contains(array[0]));
        Assert.IsFalse(skipList.Contains(array[5]));
        Assert.IsFalse(skipList.Contains(array[^1]));
    }

    [TestCaseSource(nameof(SkipListTestData))]
    public void TestCopyToMethod<T>(IList<T> skipList, Type type, T[] array)
    {
        T[] destinationArray = new T[array.Length];
        skipList.CopyTo(destinationArray, 0);
        for (int i = 0; i < array.Length; i++)
        {
            Assert.AreEqual(destinationArray[i], array[i]);
        }

        destinationArray = new T[array.Length - 5];
        skipList.CopyTo(destinationArray, 5);
        for (int i = 5; i < array.Length; i++)
        {
            Assert.AreEqual(destinationArray[i - 5], array[i]);
        }
    }
    
    [TestCaseSource(nameof(SkipListTestData))]
    public void TestGetEnumeratorMethod<T>(IList<T> skipList, Type type, T[] array)
    {
        var enumerator = skipList.GetEnumerator();
        enumerator.MoveNext();
        for (int i = 0; i < skipList.Count; i++)
        {
            Assert.AreEqual(array[i], enumerator.Current);
            enumerator.MoveNext();
        }
        enumerator.Dispose();
        
        int counter = 0;
        foreach (var element in skipList)
        {
            Assert.AreEqual(array[counter], element);
            counter++;
        }

        Assert.AreEqual(array.Length, counter);
    }
    
    [TestCaseSource(nameof(SkipListTestData))]
    public void TestCountProperty<T>(IList<T> skipList, Type type, T[] array)
    {
        Assert.AreEqual(array.Length, skipList.Count);
    }
}