namespace Bwt;
using System;
// class with two public methods for burrows-wheeler transformation
static class Transformation
{
    private readonly static int asciiSize = 128; // change

    public static (string transformedString, int index) Bwt(string str)
    {
        string[] rotations = GetRotations(str);
        Sort(rotations);
        var transformedString = "";
        foreach(var rotation in rotations)
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
    private static void Sort(string[] rotations)
    {
        for (int index = 1; index < rotations.Length; index++)
        {
            int i = index;
            while (i > 0 && String.Compare(rotations[i], rotations[i - 1], StringComparison.Ordinal) < 0)
            {
                (rotations[i - 1], rotations[i]) = (rotations[i], rotations[i - 1]);
                --i;
            }
        }
    }

    public static string BwtInverse(string str, int index)
    {
        string sortedString = GetSortedString(str);
        int[] numbers = GetNumbers(str, sortedString);
        return GetOriginalString(str, index, numbers);
    }

    private static string GetSortedString(string str)
    {
        var assistantArray = new int[asciiSize];
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
        var frequencies = new int[asciiSize];
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