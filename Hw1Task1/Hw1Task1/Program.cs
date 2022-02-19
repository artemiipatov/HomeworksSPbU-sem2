using System;

Console.WriteLine("Input array (30 integers limit): ");
string[] strings = Console.ReadLine().Split();
int[] ints = Array.ConvertAll(strings, int.Parse);

InsertionSort.Sort(ints);
foreach(int number in ints)
{
    Console.WriteLine(number);
}

class InsertionSort
{
    public static void Sort(int[] array)
    {
        for (int index = 1; index < array.Length; index++)
        {
            int i = index;
            while (i > 0 && array[i] < array[i - 1])
            {
                int temp = array[i - 1];
                array[i - 1] = array[i];
                array[i] = temp;
                --i;
            }
        }
    }
}