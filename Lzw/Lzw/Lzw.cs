using System.Collections.Specialized;
using System.Linq.Expressions;
using System.Transactions;

namespace Lzw;

using System.Collections;
using Bwt;
using Trie;

public static class Lzw
{
    // Поправить: когда появляются 9-битные коды, то все коды должны состоять из 9 элементов, когда 10-битные -- из 10 и т. д.
    public static void Compress(string path)
    {
        Transformation.Bwt(path);
        BitArray code = new BitArray(32);
        // Создаем дерево
        Trie sequences = new Trie();
        for (var i = 0; i < 256; i++)
        {
            sequences.AddItem(new byte[] { (byte)i });
        }
        using (BinaryReader binFile = new BinaryReader(File.Open("../../../.transformed", FileMode.Open)))
        {
            byte[] readBytes = new byte[1024]; // Подумать насчет размера
            readBytes[0] = binFile.ReadByte();
            int byteArrayIndex = 1;
            int bitArrayIndex = 31;
            using BinaryWriter newBinFile = new BinaryWriter(File.Open("../../../" + GetNameOfFile(path) + ".zipped", FileMode.Create));

            while (true)
            {
                // readByte = binFile.ReadByte();
                try
                {
                    readBytes[byteArrayIndex] = binFile.ReadByte();
                    if (!sequences.Contains(readBytes[0..(byteArrayIndex + 1)]))
                    {
                        sequences.AddItem(readBytes[0..(byteArrayIndex + 1)]);
                        int codeOfByteSequence = sequences.GetNumber(readBytes[0..byteArrayIndex]);
                        readBytes[0] = readBytes[byteArrayIndex];
                        byteArrayIndex = 1;
                        while (codeOfByteSequence != 0)
                        {
                            code.RightShift(1);
                            code[31] = codeOfByteSequence % 2 == 1;
                            codeOfByteSequence /= 2;
                            --bitArrayIndex;
                        }
                        while ((31 - bitArrayIndex + 1) >= 8)
                        {
                            byte[] byteToFile = new byte[1];
                            BitArray oneByteArrayOfBits = new BitArray(8);
                            for (int i = 0; i < 8; i++)
                            {
                                oneByteArrayOfBits[7 - i] = code[31 - i];
                            }
                            oneByteArrayOfBits.CopyTo(byteToFile, 0);
                            newBinFile.Write(byteToFile);
                            code.LeftShift(8);
                            bitArrayIndex += 8;
                        }
                    }
                    else
                    {
                        ++byteArrayIndex;
                    }
                }
                catch (EndOfStreamException)
                {
                    if (bitArrayIndex != 31)
                    {
                        byte[] byteToFile = new byte[1];
                        BitArray oneByteArrayOfBits = new BitArray(8);
                        for (int i = 0; i < 8; i++)
                        {
                            oneByteArrayOfBits[7 - i] = code[31 - i];
                        }
                        oneByteArrayOfBits.CopyTo(byteToFile, 0);
                        newBinFile.Write(byteToFile);
                    }
                    break;
                }
            }
        }
        File.Delete("../../../.transformed");
    }

    private static string GetNameOfFile(string path)
    {
        int index = path.Length - 1;
        string name = "";
        while (path[index] != '/' && index != -1)
        {
            name = path[index] + name;
            index -= 1;
        }
        return name;
    }
    
    public static void Decompress(string path)
    {
        
    }
}