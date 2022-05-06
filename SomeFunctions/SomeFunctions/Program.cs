foreach (var v in SomeFunctions.SomeFunctions.Map<string>(new List<string>() {"1", "2", "3"}, x => x + '4'))
{
    Console.WriteLine(v);
}

foreach (var v in SomeFunctions.SomeFunctions.Filter<int>(new List<int>() {1, 2, 3, 4, 5, 6}, x => x % 2 == 0))
{
    Console.WriteLine(v);
}
