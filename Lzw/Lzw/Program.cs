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

using Bwt;
Transformation.Bwt("/home/strider/repos/HomeworksSPbU-sem2/Lzw/Lzw/slick.bin");
Transformation.BwtInverse("/home/strider/repos/HomeworksSPbU-sem2/Lzw/Lzw/.transformed");