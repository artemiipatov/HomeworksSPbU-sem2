using Bwt;

Console.Write("Input string: ");
string? str = Console.ReadLine();
(string, int) result = Transformation.Bwt(str);
Console.WriteLine($"Transformed: {result.Item1}");
Console.WriteLine($"Original string: {Transformation.BwtInverse(result.Item1, result.Item2)}");