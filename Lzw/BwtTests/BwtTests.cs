using System;
using System.IO;
using NUnit.Framework;

namespace BwtTests;
using Bwt;

public class Tests
{
    [SetUp]
    public void Setup()
    {
        
    }

    // [SetUpFixture]
    // public class MySetUpClass
    // {
    //     [OneTimeSetUp]
    //     public void ExecuteTransformations()
    //     {
    //         Transformation.Bwt("../../../skyrim_level_up.mp3");
    //         Transformation.Bwt("../../../slick.bin");
    //         Transformation.Bwt("../../../text.txt");
    //     }
    // }
    //
    // тестирвоать нужно всего два метода. Тесты: 1) после трансформации размер у файла увеличен на несколько бит (из-за индексов строк). 2) после бвт и бвтинверс та же самая последовательность байтов (прогнать на разных файлах: txt, .bin, .mp3)
    // 

    [Test]
    public void AfterTransformationSizeOfFileShouldBeSlightlyIncreased()
    {
        Transformation.Bwt("../../../skyrim_level_up.mp3");
        FileInfo originalFile = new FileInfo("../../../skyrim_level_up.mp3");
        FileInfo transformedFile = new FileInfo("../../../skyrim_level_up.mp3.transformed");
        Assert.AreEqual(originalFile.Length, transformedFile.Length - 84);
    }
    
    [Test]
    public void FileShouldNotBeChangedAfterBwtAndInverseBwt()
    {
        Transformation.Bwt("../../../skyrim_level_up.mp3");
        BinaryReader originalFile = new BinaryReader(File.Open("../../../skyrim_level_up.mp3", FileMode.Open));
        Transformation.BwtInverse("../../../skyrim_level_up.mp3.transformed");
        BinaryReader bwtInversedFile = new BinaryReader(File.Open("../../../original.skyrim_level_up.mp3", FileMode.Open));
        Assert.AreEqual(originalFile.BaseStream.Length, bwtInversedFile.BaseStream.Length);
        while (true)
        {
            try
            {
                Assert.AreEqual(originalFile.ReadByte(), bwtInversedFile.ReadByte());
            }
            catch (EndOfStreamException)
            {
                originalFile.Close();
                bwtInversedFile.Close();
                break;
            }
        }
        originalFile.Close();
        bwtInversedFile.Close();
        
        Transformation.Bwt("../../../slick.bin");
        originalFile = new BinaryReader(File.Open("../../../slick.bin", FileMode.Open));
        Transformation.BwtInverse("../../../slick.bin.transformed");
        bwtInversedFile = new BinaryReader(File.Open("../../../original.slick.bin", FileMode.Open));
        Assert.AreEqual(originalFile.BaseStream.Length, bwtInversedFile.BaseStream.Length);
        while (true)
        {
            try
            {
                Assert.AreEqual(originalFile.ReadByte(), bwtInversedFile.ReadByte());
            }
            catch (EndOfStreamException)
            {
                originalFile.Close();
                bwtInversedFile.Close();
                break;
            }
        }
        originalFile.Close();
        bwtInversedFile.Close();

        Transformation.Bwt("../../../text.txt");
        originalFile = new BinaryReader(File.Open("../../../text.txt", FileMode.Open));
        Transformation.BwtInverse("../../../text.txt.transformed");
        bwtInversedFile = new BinaryReader(File.Open("../../../original.text.txt", FileMode.Open));
        Assert.AreEqual(originalFile.BaseStream.Length, bwtInversedFile.BaseStream.Length);
        while (true)
        {
            try
            {
                Assert.AreEqual(originalFile.ReadByte(), bwtInversedFile.ReadByte());
            }
            catch (EndOfStreamException)
            {
                originalFile.Close();
                bwtInversedFile.Close();
                break;
            }
        }
        originalFile.Close();
        bwtInversedFile.Close();
        File.Delete("../../../original.skyrim_level_up.mp3");
        File.Delete("../../../original.slick.bin");
        File.Delete("../../../original.text.txt");
        File.Delete("../../../skyrim_level_up.mp3.transformed");
        File.Delete("../../../slick.bin.transformed");
        File.Delete("../../../text.txt.transformed");
    }
}