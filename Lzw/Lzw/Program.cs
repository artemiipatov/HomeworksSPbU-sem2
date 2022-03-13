// using (BinaryReader file = new BinaryReader(File.Open("fontawesome-webfont.bin", FileMode.Open)))
// {
//     while (true)
//     {
//         try
//         {
//             var str = file.ReadByte();
//             Console.Write(str);
//         }
//         catch (Exception e)
//         {
//             Console.WriteLine("Error");
//         }
//     }
// }

// using Bwt;
// Transformation.Bwt("/home/strider/repos/HomeworksSPbU-sem2/Lzw/Lzw/slick.bin");
// Transformation.BwtInverse("/home/strider/repos/HomeworksSPbU-sem2/Lzw/Lzw/.transformed");
//
// using System.Collections;
// using Microsoft.VisualBasic;
//
// BitArray myBitArray = new BitArray(new bool[] {true, false, true, true, false, false, false, true});
// byte[] bytes = new Byte[1];
// myBitArray.CopyTo(bytes, 0);
// Console.WriteLine("Hello, world!");

Lzw.Lzw.Compress("/home/strider/repos/HomeworksSPbU-sem2/Lzw/Lzw/anotherText.txt");