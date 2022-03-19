using System.IO;
using NUnit.Framework;

namespace LzwTests;
using Lzw;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void CompressShouldCreateNewDotZippedFile()
    {
        Lzw.Compress("../../../skyrim_level_up.mp3");
        Assert.IsTrue(File.Exists("../../../skyrim_level_up.mp3.zipped"));
        File.Delete("../../../skyrim_level_up.mp3.zipped");
    }

    [Test]
    public void AfterDecompressingFileShouldBeTheSameAsOriginal()
    {
        Lzw.Compress("../../../skyrim_level_up.mp3");
        Lzw.Decompress("../../../skyrim_level_up.mp3.zipped");
        BinaryReader nonzipped = new BinaryReader(File.Open("../../../skyrim_level_up.mp3", FileMode.Open));
        BinaryReader unzipped = new BinaryReader(File.Open("../../../original.unzipped.skyrim_level_up.mp3", FileMode.Open));
        Assert.AreEqual(nonzipped.BaseStream.Length, unzipped.BaseStream.Length);
        while (true)
        {
            try
            {
                Assert.AreEqual(nonzipped.ReadByte(), unzipped.ReadByte());
            }
            catch (EndOfStreamException)
            {
                nonzipped.Close();
                unzipped.Close();
                break;
            }
        }
        nonzipped.Close();
        unzipped.Close();
        File.Delete("../../../skyrim_level_up.mp3.zipped");
        File.Delete("../../../original.unzipped.skyrim_level_up.mp3");

        Lzw.Compress("../../../slick.bin");
        Lzw.Decompress("../../../slick.bin.zipped");
        nonzipped = new BinaryReader(File.Open("../../../slick.bin", FileMode.Open));
        unzipped = new BinaryReader(File.Open("../../../original.unzipped.slick.bin", FileMode.Open));
        Assert.AreEqual(nonzipped.BaseStream.Length, unzipped.BaseStream.Length);
        while (true)
        {
            try
            {
                Assert.AreEqual(nonzipped.ReadByte(), unzipped.ReadByte());
            }
            catch (EndOfStreamException)
            {
                nonzipped.Close();
                unzipped.Close();
                break;
            }
        }
        nonzipped.Close();
        unzipped.Close();
        File.Delete("../../../slick.bin.zipped");
        File.Delete("../../../original.unzipped.slick.bin");

        Lzw.Compress("../../../text.txt");
        Lzw.Decompress("../../../text.txt.zipped");
        nonzipped = new BinaryReader(File.Open("../../../text.txt", FileMode.Open));
        unzipped = new BinaryReader(File.Open("../../../original.unzipped.text.txt", FileMode.Open));
        Assert.AreEqual(nonzipped.BaseStream.Length, unzipped.BaseStream.Length);
        while (true)
        {
            try
            {
                Assert.AreEqual(nonzipped.ReadByte(), unzipped.ReadByte());
            }
            catch (EndOfStreamException)
            {
                nonzipped.Close();
                unzipped.Close();
                break;
            }
        }
        nonzipped.Close();
        unzipped.Close();
        File.Delete("../../../text.txt.zipped");
        File.Delete("../../../original.unzipped.text.txt");
    }
}