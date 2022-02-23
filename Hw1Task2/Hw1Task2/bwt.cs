namespace Bwt;
using System;
// class with two public methods for burrows-wheeler transformation
static class Transformation
{
    public static int asciiSize = 256;
    public static string Bwt(string str)
    {
        str += '\0';
        string[] suffixes = GetSuffixes(str);
        Sort(suffixes);
        string result = "";
        for (int i = 0; i < suffixes.Length; i++)
        {
            int index = str.Length - suffixes[i].Length - 1;
            result += str[index < 0 ? str.Length - 1 : index];
        }
        return result;
    }

    private static string[] GetSuffixes(string str)
    {
        var suffixes = new string[str.Length];
        for (int i = 0; i < str.Length; i++)
        {
            suffixes[i] = str.Substring(i);
        }
        return suffixes;
    }

    private static void Sort(string[] suffixes)
    {
        for (int index = 1; index < suffixes.Length; index++)
        {
            int i = index;
            while (i > 0 && String.Compare(suffixes[i], suffixes[i-1]) < 0)
            {
                (suffixes[i - 1], suffixes[i]) = (suffixes[i], suffixes[i - 1]);
                --i;
            }
        }
    }

    public static string BwtInverse(string str)
    {
        string sortedString = GetSortedString(str);
        int[] numbers = GetNumbers(str, sortedString);
        string sequence = GetOriginalString(str, sortedString, numbers);
        return sequence.Remove(sequence.IndexOf('\0'), 1);
    }

    private static string GetSortedString(string str)
    {
        var assistantArray = new int[asciiSize];
        foreach (var ch in str)
        {
            ++assistantArray[ch];
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
        var frequencies = new int[asciiSize];
        var numbers = new int[str.Length];
        for (int i = 0; i < str.Length; ++i)
        {
            numbers[i] = sortedString.IndexOf(str[i]) + frequencies[(int)str[i]];
            ++frequencies[(int)str[i]]; 
        }
        return numbers;
    }

    private static string GetOriginalString(string str, string sortedString, int[] numbers)
    {
        string result = "";
        int pos = str.IndexOf('\0');
        for (int i = 0; i < str.Length; ++i)
        {
            result += str[pos];
            pos = Array.IndexOf(numbers, pos);
        }
        return result;
    }
}