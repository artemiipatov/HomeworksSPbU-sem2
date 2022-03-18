using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
namespace Bwt;

using System;

// class with two public methods for burrows-wheeler transformation
public static class Transformation
{
    private class ByteArrayComparer : IComparer
    {
        int IComparer.Compare(object? obj1, object? obj2)
        {
            IEnumerable enumerable1 = obj1 as IEnumerable ?? throw new InvalidOperationException();
            IEnumerable enumerable2 = obj2 as IEnumerable ?? throw new InvalidOperationException();
            IEnumerator enumerator1 = enumerable1.GetEnumerator();
            IEnumerator enumerator2 = enumerable2.GetEnumerator();
            enumerator1.MoveNext();
            enumerator2.MoveNext();
            while (true)
            {
                if ((byte)enumerator1.Current != (byte)enumerator2.Current)
                {
                    return (byte)enumerator1.Current > (byte)enumerator2.Current ? 1 : -1;
                }

                if (!enumerator1.MoveNext() || !enumerator2.MoveNext())
                {
                    break;
                }
            }
            return 0;
        }
    }
    private static readonly int UnicodeSize = 65536;
    private static readonly int BytesToRead = 8192; 
    /// <summary>
    /// forward burrows-wheeler transformation. Returns transformed string and index of the original string in the array of sorted rotations. 
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static void Bwt(string path)
    {
        using var binReader = new BinaryReader(File.Open(path, FileMode.Open));
        using (var newFile = new BinaryWriter(File.Open("../../../.transformed", FileMode.Create)))
        {
            while (true)
            {
                byte[] fileBytes = binReader.ReadBytes(BytesToRead);
                if (fileBytes.Length == 0)
                {
                    break;
                }
                byte[][] rotations = GetRotations(fileBytes);
                // Sort(rotations);
                Array.Sort(rotations, new ByteArrayComparer());
                newFile.Write(IndexOfByteArray(rotations, fileBytes));
                foreach (var rotation in rotations)
                {
                    newFile.Write(rotation[^1]);
                }
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

    private static void Sort(byte[][] rotations)
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
        using var inputFile = new BinaryReader(File.Open(path, FileMode.Open));
        using var outputFile = new BinaryWriter(File.Open("../../../" + GetNameOfFile(path), FileMode.Create));
        while (true)
        {
            try
            {
                var index = inputFile.ReadInt32();
                byte[] fileBytes = inputFile.ReadBytes(BytesToRead);
                byte[] sortedBytes = fileBytes.ToArray();
                Array.Sort(sortedBytes);
                int[] numbers = GetNumbers(fileBytes, sortedBytes);
                outputFile.Write(GetOriginalString(fileBytes, index, numbers));
            }
            catch (EndOfStreamException)
            {
                break;
            }
        }
    }
    
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
    
    private static string GetNameOfFile(string path)
    {
        int index = path.Length - 1;
        string name = "";
        while (!name.Contains("unzipped") && index != -1)
        {
            name = path[index] + name;
            index -= 1;
        }
        return name;
    }
}