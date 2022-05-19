using System;
using System.Collections.Generic;

namespace bubbleSortTests;

/// <summary>
/// Class with comparer. Comparer compares two strings by their length
/// </summary>
public class StringComparerByLength : IComparer<string>
{
    public int Compare(string? x, string? y)
    {
        if (x == null || y == null)
        {
            throw new ArgumentNullException();
        }

        if (x.Length > y.Length)
        {
            return 1;
        }
        if (x.Length < y.Length)
        {
            return -1;
        }
        return 0;
    }
}