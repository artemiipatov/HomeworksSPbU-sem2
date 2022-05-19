namespace finalTest1;

/// <summary>
/// Class with bubble sort method
/// </summary>
public static class BubbleSort
{
    /// <summary>
    /// Implementation of bubble sort on generics
    /// </summary>
    /// <param name="list">List of T type elements</param>
    /// <param name="comparer">Comparer for comparing T type values</param>
    public static void Sort<T>(IList<T> list, IComparer<T> comparer)
    {
        for (int i = 0; i < list.Count; i++)
        {
            bool elementsWereNotSwapped = true;
            for (int j = 0; j < list.Count - i - 1; j++)
            {
                if (comparer.Compare(list[j], list[j + 1]) > 0)
                {
                    (list[j], list[j + 1]) = (list[j + 1], list[j]);
                    elementsWereNotSwapped = false;
                }
            }

            if (elementsWereNotSwapped)
            {
                return;
            }
        }
    }
}