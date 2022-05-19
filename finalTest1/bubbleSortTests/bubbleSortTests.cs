using System.Collections.Generic;
using finalTest1;
using NUnit.Framework;

namespace bubbleSortTests;

public class Tests
{
    [Test]
    public void BubbleSortWithIntComparerWorksProperly()
    {
        IList<decimal> decimalList = new List<decimal> { 0.54315m, 0.1452193m, 8945.1243m, 1804858124560, 8 };
        decimal[] correctResult = {0.1452193m, 0.54315m, 8, 8945.1243m, 1804858124560};
        BubbleSort.Sort(decimalList, new DecimalComparer());
        for (int i = 0; i < correctResult.Length; i++)
        {
            Assert.AreEqual(correctResult[i], decimalList[i]);
        }
    }

    [Test]
    public void BubbleSortWithStringComparerWorksProperly()
    {
        IList<string> stringList = new List<string> {"Represents", "a", "strongly", "typed", "list", "of", "objects"};
        string[] correctResult = {"a", "of", "list", "typed", "objects", "strongly", "Represents"};
        BubbleSort.Sort(stringList, new StringComparerByLength());
        for (int i = 0; i < correctResult.Length; i++)
        {
            Assert.AreEqual(correctResult[i], stringList[i]);
        }
    }

    [Test]
    public void BubbleSortWithArrayOfIntsComparerWorksProperly()
    {
        IList<int[]> intArraysList = new List<int[]> {new[]{2, 1, 5},  new[]{10, 9, 8}, new[]{9, 4, 3}, new[]{100, 5001, 30}, new[]{8, 0, 0}};
        int[][] correctResult = {new[] {2, 1, 5}, new[] {8, 0, 0}, new[] {9, 4, 3}, new[] {10, 9, 8}, new[] {100, 5001, 30}};
        BubbleSort.Sort(intArraysList, new IntArraysComparerBySums());
        for (int i = 0; i < correctResult.Length; i++)
        {
            Assert.AreEqual(correctResult[i], intArraysList[i]);
        }
    }

    [Test]
    public void BubbleSortWorksProperlyOnBoundaryValues()
    {
        IList<decimal> decimalList = new List<decimal> {1, 2, 3, 4, 5, 6};
        decimal[] correctResult = {1, 2, 3, 4, 5, 6};
        BubbleSort.Sort(decimalList, new DecimalComparer());
        for (int i = 0; i < correctResult.Length; i++)
        {
            Assert.AreEqual(correctResult[i], decimalList[i]);
        }

        decimalList = new List<decimal> {6, 5, 4, 3, 2, 1};
        BubbleSort.Sort(decimalList, new DecimalComparer());
        for (int i = 0; i < correctResult.Length; i++)
        {
            Assert.AreEqual(correctResult[i], decimalList[i]);
        }

        decimalList = new List<decimal> {0, 0, 0, 0, 0};
        correctResult = new decimal[] {0, 0, 0, 0, 0};
        BubbleSort.Sort(decimalList, new DecimalComparer());
        for (int i = 0; i < correctResult.Length; i++)
        {
            Assert.AreEqual(correctResult[i], decimalList[i]);
        }

        decimalList = new List<decimal>();
        BubbleSort.Sort(decimalList, new DecimalComparer());
        Assert.AreEqual(0, decimalList.Count);
    }
}