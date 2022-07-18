using System.Collections.Generic;

namespace bubbleSortTests;

/// <summary>
/// Class with comparer. Comparer compares two decimal values
/// </summary>
public class DecimalComparer : IComparer<decimal>
{
    public int Compare(decimal x, decimal y)
    {
        if (x - y > 0)
        {
            return 1;
        }
        if (x - y < 0)
        {
            return -1;
        }
        return 0;
    }
}