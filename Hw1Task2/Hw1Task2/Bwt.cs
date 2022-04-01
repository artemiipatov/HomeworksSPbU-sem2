namespace Bwt;

using System;

// class with two public methods for burrows-wheeler transformation
static class Transformation
{
    private readonly static int unicodeSize = 65536;

    /// <summary>
    /// forward burrows-wheeler transformation. Returns transformed string and index of the original string in the array of sorted rotations. 
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static (string transformedString, int index) Bwt(string? str)
    {
        if (str == null)
        {
            throw new NullReferenceException("Null argument has been given");
        }
        
        string[] rotations = GetRotations(str);
        Array.Sort(rotations, StringComparer.Ordinal);
        var transformedString = "";
        foreach (var rotation in rotations)
        {
            transformedString += rotation[rotation.Length - 1];
        }
        return (transformedString, Array.IndexOf(rotations, str));
    }

    private static string[] GetRotations(string str)
    {
        var rotations = new string[str.Length];
        for (int i = 0; i < str.Length; i++)
        {
            rotations[i] = str.Substring(i) + str.Substring(0, i);
        }
        return rotations;
    }
    
    /// <summary>
    /// Inverse Burrows-Wheeler transformation. Returns original string.
    /// </summary>
    /// <param name="str"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public static string BwtInverse(string str, int index)
    {
        string sortedString = GetSortedString(str);
        int[] numbers = GetNumbers(str, sortedString);
        return GetOriginalString(str, index, numbers);
    }

    private static string GetSortedString(string str)
    {
        var assistantArray = new int[unicodeSize];
        foreach (var ch in str)
        {
            ++assistantArray[((int)ch)];
        }
        var sortedArray = new char[str.Length];
        int pos = 0;
        for (int i = 0; i < assistantArray.Length; ++i)
        {
            for (int j = 0; j < assistantArray[i]; ++j)
            {
                sortedArray[pos] = (char)i;
                ++pos;
            }
        }
        return new string(sortedArray);
    }

    private static int[] GetNumbers(string str, string sortedString)
    {
        var frequencies = new int[unicodeSize];
        var numbers = new int[str.Length];
        for (int i = 0; i < str.Length; ++i)
        {
            numbers[i] = sortedString.IndexOf(str[i]) + frequencies[((int)str[i])];
            ++frequencies[((int)str[i])]; 
        }
        return numbers;
    }
    
    private static string GetOriginalString(string str, int pos, int[] numbers)
    {
        string result = "";
        for (int i = 0; i < str.Length; ++i)
        {
            result = str[pos] + result;
            pos = numbers[pos];
        }
        return result;
    }
}