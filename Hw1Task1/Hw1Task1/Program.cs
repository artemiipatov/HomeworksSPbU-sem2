using System;

Console.WriteLine("Input array: ");
string[] strings = Console.ReadLine().Split();
int[] ints = Array.ConvertAll(strings, int.Parse);

Sort(ints);
foreach(int number in ints)
{
    Console.WriteLine(number);
}

static void Sort(int[] array)
{
    for (int index = 1; index < array.Length; index++)
    {
        int i = index;
        while (i > 0 && array[i] < array[i - 1])
        {
            (array[i - 1], array[i]) = (array[i], array[i - 1]);
            --i;
        }
    }
}