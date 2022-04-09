using System.Collections;
using System.Diagnostics.CodeAnalysis;
namespace Bwt;

using System;

// class with two public methods for burrows-wheeler transformation
public static class Transformation
{
    private class ByteArrayComparer : IComparer
    {
        [SuppressMessage("ReSharper.DPA", "DPA0002: Excessive memory allocations in SOH", MessageId = "type: System.Byte; size: 2108MB")]
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

    private const int UnicodeSize = 65536;
    private const int BytesToRead = 8192;

    /// <summary>
    /// forward burrows-wheeler transformation. Returns transformed string and index of the original string in the array of sorted rotations. 
    /// </summary>
    /// <param name="path"></param>
    [SuppressMessage("ReSharper.DPA", "DPA0002: Excessive memory allocations in SOH", MessageId = "type: System.Byte[]")]
    [SuppressMessage("ReSharper.DPA", "DPA0002: Excessive memory allocations in SOH", MessageId = "type: System.Byte")]
    public static void Bwt(string path)
    {
        using var binReader = new BinaryReader(File.Open(path, FileMode.Open));
        string nameOfNewFile = "../../../" + GetNameOfFile(path) + ".transformed";
        using var newFile = new BinaryWriter(File.Open(nameOfNewFile, FileMode.Create));
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

        File.SetAttributes(nameOfNewFile, FileAttributes.Hidden);
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
    public static void BwtInverse(string path)
    {
        using var inputFile = new BinaryReader(File.Open(path, FileMode.Open));
        string nameOfNewFile = ("../../../" + "original." + GetNameOfFile(path)).Split(".transformed")[0];
        using var outputFile = new BinaryWriter(File.Open(nameOfNewFile, FileMode.Create));
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
        string name1 = "";
        while (path[index] != '/' && index != -1 && path[index] != '\\')
        {
            name1 = path[index] + name1;
            index -= 1;
        }

        index = name1.Length - 1;
        string name2 = "";
        while (!name2.Contains("unzipped") && index != -1)
        {
            name2 = name1[index] + name2;
            index -= 1;
        }
        return name2;
    }
}