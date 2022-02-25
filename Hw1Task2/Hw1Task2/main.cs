using Bwt;

Console.WriteLine("Input string: ");
string str = Console.ReadLine();
(string, int) result = Transformation.Bwt(str);
Console.WriteLine(result.Item1);
Console.WriteLine($"{Transformation.BwtInverse(result.Item1, result.Item2)}");