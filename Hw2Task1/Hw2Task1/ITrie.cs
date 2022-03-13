namespace Hw2Task1;

public interface ITrie
{
    bool AddItem(string element);

    bool Remove(string element);

    bool Contains(string element);

    int HowManyStartsWithPrefix(string prefix);
}