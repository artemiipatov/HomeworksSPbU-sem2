// using System.Text;
// namespace Bwt;
//
// using System;
//
// // После применения алгоритма зива лемпеля нужно будет удалять .transformed.txt
//
// // class with two public methods for burrows-wheeler transformation
// static class Transformation
// {
//     private readonly static int UnicodeSize = 65536;
//
//     /// <summary>
//     /// forward burrows-wheeler transformation. Returns transformed string and index of the original string in the array of sorted rotations. 
//     /// </summary>
//     /// <param name="path"></param>
//     /// <returns></returns>
//     public static void Bwt(string path)
//     {
//         using FileStream fstream = new FileStream(path, FileMode.Open);
//         byte[] buffer = new byte[fstream.Length];
//         fstream.Read(buffer, 0, buffer.Length);
//         string text = Encoding.Default.GetString(buffer);
//         string[] rotations = GetRotations(text);
//         Sort(rotations);
//
//         using (var newFile =в new StreamWriter("../../../.transformed"))
//         {
//             newFile.WriteLine(Array.IndexOf(rotations, text));
//             foreach (var rotation in rotations)
//             {
//                 newFile.Write(Convert.ToString(rotation[rotation.Length - 1]), 0, 1);
//             }
//         }
//         File.SetAttributes("../../../.transformed", FileAttributes.Hidden);
//     }
//
//     private static string[] GetRotations(string str)
//     {
//         var rotations = new string[str.Length];
//         for (int i = 0; i < str.Length; i++)
//         {
//             rotations[i] = str.Substring(i) + str.Substring(0, i);
//         }
//         return rotations;
//     }
//
//     private static void Sort(string[] rotations)
//     {
//         for (int index = 1; index < rotations.Length; index++)
//         {
//             int i = index;
//             while (i > 0 && String.Compare(rotations[i], rotations[i - 1], StringComparison.Ordinal) < 0)
//             {
//                 (rotations[i - 1], rotations[i]) = (rotations[i], rotations[i - 1]);
//                 --i;
//             }
//         }
//     }
//
//     /// <summary>
//     /// Inverse Burrows-Wheeler transformation. Returns original string.
//     /// </summary>
//     /// <param name="str"></param>
//     /// <param name="index"></param>
//     /// <param name="path"></param>
//     /// <returns></returns>
//     public static void BwtInverse(string path) 
//     {
//         using var file = new StreamReader(path);
//         var index = int.Parse(file.ReadLine());
//         var text = file.ReadToEnd();
//         string sortedString = GetSortedString(text);
//         int[] numbers = GetNumbers(text, sortedString);
//         File.WriteAllText("../../../originalText.txt", GetOriginalString(text, index, numbers));
//     }
//
//     private static string GetSortedString(string str)
//     {
//         var assistantArray = new int[UnicodeSize];
//         foreach (var ch in str)
//         {
//             ++assistantArray[((int)ch)];
//         }
//         var sortedArray = new char[str.Length];
//         int pos = 0;
//         for (int i = 0; i < assistantArray.Length; ++i)
//         {
//             for (int j = 0; j < assistantArray[i]; ++j)
//             {
//                 sortedArray[pos] = (char)i;
//                 ++pos;
//             }
//         }
//         return new string(sortedArray);
//     }
//
//     private static int[] GetNumbers(string str, string sortedString)
//     {
//         var frequencies = new int[UnicodeSize];
//         var numbers = new int[str.Length];
//         for (int i = 0; i < str.Length; ++i)
//         {
//             numbers[i] = sortedString.IndexOf(str[i]) + frequencies[((int)str[i])];
//             ++frequencies[((int)str[i])]; 
//         }
//         return numbers;
//     }
//
//     private static string GetOriginalString(string str, int pos, int[] numbers)
//     {
//         string result = "";
//         for (int i = 0; i < str.Length; ++i)
//         {
//             result = str[pos] + result;
//             pos = numbers[pos];
//         }
//         return result;
//     }
// }


using System.Collections;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
namespace Bwt;

using System;

// После применения алгоритма зива лемпеля нужно будет удалять .transformed.txt

// class with two public methods for burrows-wheeler transformation
static class Transformation
{
    private readonly static int UnicodeSize = 65536;

    /// <summary>
    /// forward burrows-wheeler transformation. Returns transformed string and index of the original string in the array of sorted rotations. 
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static void Bwt(string path)
    {
        byte[] fileBytes = File.ReadAllBytes(path);
        byte[][] rotations = GetRotations(fileBytes);
        Sort(rotations);

        using (var newFile = new BinaryWriter(File.Open("../../../.transformed", FileMode.Create)))
        {
            newFile.Write(IndexOfByteArray(rotations, fileBytes));
            foreach (var rotation in rotations)
            {
                newFile.Write(rotation[rotation.Length - 1]);
            }
        }
        File.SetAttributes("../../../.transformed", FileAttributes.Hidden);
    }

    private static byte[][] GetRotations(byte[] fileBytes)
    {
        var rotations = new byte[fileBytes.Length][];
        for (int i = 0; i < fileBytes.Length; i++)
        {
            rotations[i] = new byte[fileBytes.Length];
        }
        for (int i = 0; i < fileBytes.Length; i++)
        {
            for (int j = 0; j < fileBytes.Length; j++)
            {
                rotations[i][((i + j) < fileBytes.Length ? (i + j) : i + j - fileBytes.Length)] = fileBytes[j];
            }
        }
        return rotations;
    }

    private static void Sort(byte[][] rotations) // Заменить на merge sort
    {
        for (int index = 1; index < rotations.Length; index++)
        {
            int i = index;
            while (i > 0 && ((IStructuralComparable) rotations[i]).CompareTo(rotations[i - 1], Comparer<byte>.Default) < 0)
            {
                (rotations[i - 1], rotations[i]) = (rotations[i], rotations[i - 1]);
                --i;
            }
        }
    }

    private static int IndexOfByteArray(byte[][] sourceArray, byte[] byteArray)
    {
        for (int i = 0; i < sourceArray.Length; ++i)
        {
            if (sourceArray[i].SequenceEqual(byteArray))
            {
                return i;
            }
        }
        return -1;
    }

    /// <summary>
    /// Inverse Burrows-Wheeler transformation. Returns original string.
    /// </summary>
    /// <param name="str"></param>
    /// <param name="index"></param>
    /// <param name="path"></param>
    /// <returns></returns>
    public static void BwtInverse(string path)
    {
        // using var file = new StreamReader(path);
        // var index = int.Parse(file.ReadLine());
        // var text = file.ReadToEnd();
        using var file = new BinaryReader(File.Open(path, FileMode.Open));
        var index = file.ReadInt32();
        byte[] fileBytes = file.ReadBytes((int)file.BaseStream.Length - 4);
        // for (int i = 0; i < file.Length; i++)
        byte[] sortedBytes = new byte[fileBytes.Length];
        sortedBytes = fileBytes.ToArray();
        // string sortedBytes = GetSortedBytes(fileBytes);
        Array.Sort(sortedBytes);
        int[] numbers = GetNumbers(fileBytes, sortedBytes);
        using (BinaryWriter outputFile = new BinaryWriter(File.Open("../../../originalText.txt", FileMode.Create)))
        {
            outputFile.Write(GetOriginalString(fileBytes, index, numbers));
        }
    }

    // private static string GetSortedBytes(byte[] fileBytes)
    // {
    //     // Array.Sort(fileBytes);
    //     var assistantArray = new int[UnicodeSize];
    //     foreach (var ch in fileBytes)
    //     {
    //         ++assistantArray[((int)ch)];
    //     }
    //     var sortedArray = new char[fileBytes.Length];
    //     int pos = 0;
    //     for (int i = 0; i < assistantArray.Length; ++i)
    //     {
    //         for (int j = 0; j < assistantArray[i]; ++j)
    //         {
    //             sortedArray[pos] = (char)i;
    //             ++pos;
    //         }
    //     }
    //     return new string(sortedArray);
    // }

    // private static int[] GetNumbers(string str, string sortedString)
    // {
    //     var frequencies = new int[UnicodeSize];
    //     var numbers = new int[str.Length];
    //     for (int i = 0; i < str.Length; ++i)
    //     {
    //         numbers[i] = sortedString.IndexOf(str[i]) + frequencies[((int)str[i])];
    //         ++frequencies[((int)str[i])]; 
    //     }
    //     return numbers;
    // }

    private static int[] GetNumbers(byte[] fileBytes, byte[] sortedBytes)
    {
        var frequencies = new int[UnicodeSize];
        var numbers = new int[fileBytes.Length];
        for (int i = 0; i < fileBytes.Length; ++i)
        {
            numbers[i] = Array.IndexOf(sortedBytes, fileBytes[i]) + frequencies[((int)fileBytes[i])];
            ++frequencies[((int)fileBytes[i])];
        }
        return numbers;
    }

    private static byte[] GetOriginalString(byte[] fileBytes, int pos, int[] numbers)
    {
        byte[] result = new byte[fileBytes.Length];
        for (int i = fileBytes.Length - 1; i >= 0; --i)
        {
            result[i] = fileBytes[pos];
            pos = numbers[pos];
        }
        return result;
    }
}