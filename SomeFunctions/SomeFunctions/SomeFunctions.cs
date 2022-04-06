namespace SomeFunctions;

public static class SomeFunctions<T>
{
    public static List<T> Map(List<T> sourceList, Func<T, T> func) => sourceList.Select(func).ToList();

    public static List<T> Filter(List<T> sourceList, Func<T, bool> func) => sourceList.Where(func).ToList();

    public static T Fold(List<T> sourceList, T acc, Func<T, T, T> func) => sourceList.Aggregate(acc, func);
}