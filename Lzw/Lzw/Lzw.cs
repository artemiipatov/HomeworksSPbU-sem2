namespace Lzw;

using System.Collections;
using Bwt;
using Trie;

public static class Lzw
{
    /// <summary>
    /// Compressing method of lzw algorithm
    /// </summary>d
    /// <param name="path"></param>
    /// <returns>Coefficient of compression</returns>
    public static double Compress(string path)
    {
        Transformation.Bwt(path);
        BitArray code = new BitArray(64);
        // Создаем дерево
        Trie sequences = new Trie();
        for (var i = 0; i < 256; i++)
        {
            sequences.AddItem(new byte[] { (byte)i });
        }

        string nameOfTransformedFile = "../../../" + GetNameOfFile(path) + ".transformed";
        string nameOfZippedFile = "../../../" + GetNameOfFile(path) + ".zipped";
        using (BinaryReader binFile = new BinaryReader(File.Open(nameOfTransformedFile, FileMode.Open)))
        {
            byte[] readBytes = new byte[1024]; // Подумать насчет размера
            readBytes[0] = binFile.ReadByte();
            int byteArrayIndex = 1;
            int bitArrayIndex = 63;
            int maxCodeLength = 8;
            int powerOfTwo = (int)Math.Pow(2, 8); // Поменять название переменной
            
            using BinaryWriter newBinFile = new BinaryWriter(File.Open(nameOfZippedFile, FileMode.Create));
            while (true)
            {
                try
                {
                    readBytes[byteArrayIndex] = binFile.ReadByte();
                    if (!sequences.Contains(readBytes[0..(byteArrayIndex + 1)]))
                    {
                        sequences.AddItem(readBytes[0..(byteArrayIndex + 1)]);
                        int codeOfByteSequence = sequences.GetNumber(readBytes[0..byteArrayIndex]);
                        readBytes[0] = readBytes[byteArrayIndex];
                        byteArrayIndex = 1;
                        bitArrayIndex = bitArrayIndex - maxCodeLength + 1;
                        int bitArrayIndexBeforeCycle = bitArrayIndex;
                        while (codeOfByteSequence != 0)
                        {
                            code[bitArrayIndex] = codeOfByteSequence % 2 == 1;
                            codeOfByteSequence /= 2;
                            ++bitArrayIndex;
                        }

                        bitArrayIndex = bitArrayIndexBeforeCycle - 1;
                        while ((63 - bitArrayIndex) >= 8)
                        {
                            byte[] byteToFile = new byte[1];
                            BitArray oneByteArrayOfBits = new BitArray(8);
                            for (int i = 0; i < 8; i++)
                            {
                                oneByteArrayOfBits[7 - i] = code[63 - i];
                            }
                            oneByteArrayOfBits.CopyTo(byteToFile, 0);
                            newBinFile.Write(byteToFile);
                            code.LeftShift(8);
                            bitArrayIndex += 8;
                        }
                        if (sequences.Size >= powerOfTwo)
                        {
                            ++maxCodeLength;
                            powerOfTwo = (int)Math.Pow(2, maxCodeLength);
                        }
                    }
                    else
                    {
                        ++byteArrayIndex;
                    }
                }
                catch (EndOfStreamException)
                {
                    if (byteArrayIndex >= 1)
                    {
                        int codeOfByteSequence = sequences.GetNumber(readBytes[0..byteArrayIndex]);
                        bitArrayIndex = bitArrayIndex - maxCodeLength + 1;
                        int bitArrayIndexBeforeCycle = bitArrayIndex;
                        while (codeOfByteSequence != 0)
                        {
                            code[bitArrayIndex] = codeOfByteSequence % 2 == 1;
                            codeOfByteSequence /= 2;
                            ++bitArrayIndex;
                        }

                        bitArrayIndex = bitArrayIndexBeforeCycle - 1;
                    }
                    while (bitArrayIndex <= 63)
                    {
                        byte[] byteToFile = new byte[1];
                        BitArray oneByteArrayOfBits = new BitArray(8);
                        for (int i = 0; i < 8; i++)
                        {
                            oneByteArrayOfBits[7 - i] = code[63 - i];
                        }
                        oneByteArrayOfBits.CopyTo(byteToFile, 0);
                        newBinFile.Write(byteToFile);
                        code.LeftShift(8);
                        bitArrayIndex += 8;
                    }

                    break;
                }
            }
        }
        File.Delete(nameOfTransformedFile);
        return (double) new FileInfo(path).Length / new FileInfo(nameOfZippedFile).Length;
    }
    
    /// <summary>
    /// Decompressing method of lzw algorithm
    /// </summary>
    /// <param name="path"></param>
    public static void Decompress(string path)
    {
        var pathToUnzippedFile = ("../../../unzipped." + GetNameOfFile(path)).Split(".zipped")[0];
        using BinaryReader inputFile = new BinaryReader(File.Open(path, FileMode.Open));
        using BinaryWriter outputFile = new BinaryWriter(File.Open(pathToUnzippedFile, FileMode.Create));
        
        // переменная для количества бит, которые нужно считывать на текущий момент (перевеодим в байты, округляем в большую сторону -- получаем количество
        // байт, которые нужно считать
        int numberOfBitsToRead = 9;
        int numberOfBytesToRead = 2;
        int powerOfTwo = (int)Math.Pow(2, numberOfBitsToRead);
        
        int bitArrayLength = 1024;
        BitArray code = new BitArray(bitArrayLength);
        int bitArrayIndex = code.Length - 1;

        // создаем словарь
        Dictionary<int, byte[]> sequences = new Dictionary<int, byte[]>();
        
        // Заполняем словарь одиночными байтами
        for (var i = 0; i < 256; i++)
        {
            sequences.Add(i, new byte[] { (byte)i });
        }
        byte[] previousByteSequence = new byte[1024];
        previousByteSequence[0] = inputFile.ReadByte(); // Код первого считанного байта известен сразу, потому что первая последовательность байтов кодируется одним байтом
        int curIndexOfPreviousByteSequence = 1;
        
        outputFile.Write(previousByteSequence[0]);

        int counter = 256;
        while (true)
        {
            bool isEof = false;
            // считали определенное количество байтов, закинули их все в общий массив битов.
            for (int i = 0; i < numberOfBytesToRead; i++)
            {
                int readByte;
                try
                {
                    readByte = inputFile.ReadByte();
                }
                catch (EndOfStreamException)
                {
                    isEof = true;
                    break;
                }

                bitArrayIndex -= 7;
                int bitArrayIndexBeforeCycle = bitArrayIndex;
                for (int _ = 0; _ < 8; _++)
                {
                    code[bitArrayIndex] = readByte % 2 == 1;
                    readByte /= 2;
                    ++bitArrayIndex;
                }
                bitArrayIndex = bitArrayIndexBeforeCycle - 1;
            }
            
            while (bitArrayLength - 1 - bitArrayIndex >= numberOfBitsToRead)
            {
                // только что считанные биты (количеством numberOfBitsToRead) преобразовали в интовые коды
                int indexOfSequenceInDict = 0;
                for (int i = 0; i < numberOfBitsToRead; i++)
                {
                    indexOfSequenceInDict = indexOfSequenceInDict * 2 + (code[bitArrayLength - 1 - i] ? 1 : 0);
                }

                // Убрали из массива уже преобразованные биты
                code.LeftShift(numberOfBitsToRead);
                bitArrayIndex += numberOfBitsToRead;
                // ++counter;

                if (indexOfSequenceInDict == sequences.Count)
                {
                    previousByteSequence[curIndexOfPreviousByteSequence] = previousByteSequence[0];
                    outputFile.Write(previousByteSequence[0..(curIndexOfPreviousByteSequence + 1)]);
                    sequences.Add(sequences.Count, previousByteSequence[0..(curIndexOfPreviousByteSequence + 1)]);
                }
                else
                {
                    // последовательность битов с этим кодом кладем в файл
                    outputFile.Write(sequences[indexOfSequenceInDict]);
                
                    // Предыдущую последовательность, конкатенированную с первым байтом текущей последовательности нужно положить в словарь
                    previousByteSequence[curIndexOfPreviousByteSequence] = sequences[indexOfSequenceInDict][0];
                    sequences.Add(sequences.Count, previousByteSequence[0..(curIndexOfPreviousByteSequence + 1)]);
                }

                // После добавления в словарь нужно высчитать количество бит, которое нужно считывать.
                if (sequences.Count >= powerOfTwo - 1)
                {
                    ++numberOfBitsToRead;
                    numberOfBytesToRead = (int) Math.Ceiling((double) numberOfBitsToRead / 8.0);
                    powerOfTwo *= 2;
                }

                // кладем предыдущие байты в previousByteSequence
                for (int i = 0; i < sequences[indexOfSequenceInDict].Length; i++)
                {
                    previousByteSequence[i] = sequences[indexOfSequenceInDict][i];
                }

                curIndexOfPreviousByteSequence = sequences[indexOfSequenceInDict].Length;
            }
            if (isEof)
            {
                outputFile.Close();
                Transformation.BwtInverse(pathToUnzippedFile);
                File.Delete(pathToUnzippedFile);
                break;
            }
        }
    }

    private static string GetNameOfFile(string path)
    {
        int index = path.Length - 1;
        string name = "";
        while (path[index] != '/' && index != -1 && path[index] != '\\')
        {
            name = path[index] + name;
            index -= 1;
        }
        return name;
    }
}