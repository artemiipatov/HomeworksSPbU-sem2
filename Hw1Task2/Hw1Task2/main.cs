using Bwt;

Console.WriteLine("Input string: ");
string str = Console.ReadLine();
string transformedString = Transformation.Bwt(str);
Console.WriteLine(transformedString);
Console.WriteLine(Transformation.BwtInverse(transformedString));