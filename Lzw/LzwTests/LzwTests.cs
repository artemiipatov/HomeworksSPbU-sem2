namespace LzwTests;

using System.IO;
using NUnit.Framework;
using Lzw;

public class LzwTests
{
    [Test]
    public void CompressShouldCreateNewDotZippedFile()
    {
        Lzw.Compress("../../../skyrim_level_up.mp3", true);
        Assert.IsTrue(File.Exists("../../../skyrim_level_up.mp3.zipped"));
        File.Delete("../../../skyrim_level_up.mp3.zipped");
    }

    [Test]
    public void AfterDecompressingFileShouldBeTheSameAsOriginalAndCoefficientShouldBeCorrect()
    {
        double coefficient = Lzw.Compress("../../../skyrim_level_up.mp3", true);
        Lzw.Decompress("../../../skyrim_level_up.mp3.zipped");
        BinaryReader nonzipped = new BinaryReader(File.Open("../../../skyrim_level_up.mp3", FileMode.Open));
        BinaryReader unzipped = new BinaryReader(File.Open("../../../original.unzipped.skyrim_level_up.mp3", FileMode.Open));
        Assert.Less(System.Math.Abs(coefficient - (double) new FileInfo("../../../skyrim_level_up.mp3").Length / new FileInfo("../../../skyrim_level_up.mp3.zipped").Length), 0.000000000001);
        Assert.AreEqual(nonzipped.BaseStream.Length, unzipped.BaseStream.Length);
        while (true)
        {
            try
            {
                Assert.AreEqual(nonzipped.ReadByte(), unzipped.ReadByte());
            }
            catch (EndOfStreamException)
            {
                break;
            }
        }
        nonzipped.Close();
        unzipped.Close();
        File.Delete("../../../skyrim_level_up.mp3.zipped");
        File.Delete("../../../original.unzipped.skyrim_level_up.mp3");

        coefficient = Lzw.Compress("../../../slick.bin", true);
        Lzw.Decompress("../../../slick.bin.zipped");
        nonzipped = new BinaryReader(File.Open("../../../slick.bin", FileMode.Open));
        unzipped = new BinaryReader(File.Open("../../../original.unzipped.slick.bin", FileMode.Open));
        Assert.Less(System.Math.Abs(coefficient - (double) new FileInfo("../../../slick.bin").Length / new FileInfo("../../../slick.bin.zipped").Length), 0.000000000001);
        Assert.AreEqual(nonzipped.BaseStream.Length, unzipped.BaseStream.Length);
        while (true)
        {
            try
            {
                Assert.AreEqual(nonzipped.ReadByte(), unzipped.ReadByte());
            }
            catch (EndOfStreamException)
            {
                break;
            }
        }
        nonzipped.Close();
        unzipped.Close();
        File.Delete("../../../slick.bin.zipped");
        File.Delete("../../../original.unzipped.slick.bin");

        coefficient = Lzw.Compress("../../../text.txt", true);
        Lzw.Decompress("../../../text.txt.zipped");
        nonzipped = new BinaryReader(File.Open("../../../text.txt", FileMode.Open));
        unzipped = new BinaryReader(File.Open("../../../original.unzipped.text.txt", FileMode.Open));
        Assert.Less(System.Math.Abs(coefficient - (double) new FileInfo("../../../text.txt").Length / new FileInfo("../../../text.txt.zipped").Length), 0.000000000001);
        Assert.AreEqual(nonzipped.BaseStream.Length, unzipped.BaseStream.Length);
        while (true)
        {
            try
            {
                Assert.AreEqual(nonzipped.ReadByte(), unzipped.ReadByte());
            }
            catch (EndOfStreamException)
            {
                break;
            }
        }
        nonzipped.Close();
        unzipped.Close();
        File.Delete("../../../text.txt.zipped");
        File.Delete("../../../original.unzipped.text.txt");
    }

    [Test]
    public void LzwWithBwtVsLzwWithoutBwt()
    {
        double coefficientWithBwt = Lzw.Compress("../../../skyrim_level_up.mp3", true);
        double coefficientWithoutBwt = Lzw.Compress("../../../skyrim_level_up.mp3", false);
        Assert.IsTrue(coefficientWithBwt > coefficientWithoutBwt);
        File.Delete("../../../skyrim_level_up.mp3.zipped");
    }
}