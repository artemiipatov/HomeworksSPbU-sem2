using System;
using System.Collections.Generic;
using System.Linq;

namespace bubbleSortTests;

/// <summary>
/// Class with comparer. Comparer compares two integer arrays by sum of their elements
/// </summary>
public class IntArraysComparerBySums : IComparer<int[]>
{
    public int Compare(int[]? x, int[]? y)
    {
        if (x == null || y == null)
        {
            throw new ArgumentNullException();
        }

        return x.Sum() - y.Sum();
    }
}