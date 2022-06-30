namespace SomeFunctions;

public static class SomeFunctions
{
    /// <summary>
    /// Applies lambda function to all list elements
    /// </summary>
    /// <returns>List with transformed values</returns>
    public static List<TResult> Map<T, TResult>(List<T> sourceList, Func<T, TResult> func)
    {
        var newList = new List<TResult>();
        foreach (var element in sourceList)
        {
            newList.Add(func(element));
        }

        return newList;
    }

    /// <summary>
    /// Returns list of elements for which given function returns true
    /// </summary>
    /// <returns>Filtered list</returns>
    public static List<T> Filter<T>(List<T> sourceList, Func<T, bool> func)
    {
        var newList = new List<T>();
        foreach (var element in sourceList)
        {
            if (func(element))
            {
                newList.Add(element);
            }
        }

        return newList;
    }

    /// <summary>
    /// Returns accumulated value. Accumulate value is the result of applying given lambda funtion to all list values and current accumulated value
    /// </summary>
    /// <returns>Accumulated value</returns>
    public static TResult Fold<T, TResult>(List<T> sourceList, TResult acc, Func<TResult, T, TResult> func)
    {
        var newList = new List<TResult>();
        foreach (var element in sourceList)
        {
            acc = func(acc, element);
        }

        return acc;
    }
}