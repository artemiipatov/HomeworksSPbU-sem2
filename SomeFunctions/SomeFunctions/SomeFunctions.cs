namespace SomeFunctions;

public static class SomeFunctions
{

    /// <summary>
    /// Applies lambda function to all list elements
    /// </summary>
    /// <param name="sourceList"></param>
    /// <param name="func"></param>
    /// <returns>List with transformed values</returns>
    public static List<T> Map<T>(List<T> sourceList, Func<T, T> func) => sourceList.Select(func).ToList();

    /// <summary>
    /// Returns list of elements for which given function returns true
    /// </summary>
    /// <param name="sourceList"></param>
    /// <param name="func"></param>
    /// <returns>Filtered list</returns>
    public static List<T> Filter<T>(List<T> sourceList, Func<T, bool> func) => sourceList.Where(func).ToList();

    /// <summary>
    /// Returns accumulated value. Accumulate value is the result of applying given lambda funtion to all list values and current accumulated value
    /// </summary>
    /// <param name="sourceList"></param>
    /// <param name="acc"></param>
    /// <param name="func"></param>
    /// <returns>Accumulated value</returns>
    public static T Fold<T>(List<T> sourceList, T acc, Func<T, T, T> func) => sourceList.Aggregate(acc, func);
}